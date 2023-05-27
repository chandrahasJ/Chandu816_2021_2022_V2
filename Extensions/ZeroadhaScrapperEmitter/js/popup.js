PE = {
    "Sell" : 0,
    "Buy" : 0
};

CE = {
    "Sell" : 0,
    "Buy" : 0
}


document.addEventListener('DOMContentLoaded', function () {
    var links = document.getElementsByTagName("a");
    for (var i = 0; i < links.length; i++) {
        (function () {
            var ln = links[i];
            var location = ln.href;
            ln.onclick = function () {
                chrome.tabs.create({active: true, url: location});
            };
        })();
    }
});

function calculatePEAndCE(marketDepth){
    if(contains(marketDepth.name, " PE")){
        PE.Buy = parseFloat(PE.Buy) + parseFloat(marketDepth.buyBidTotal.replaceAll(',',''));
         PE.Sell = parseFloat(PE.Sell) + parseFloat(marketDepth.sellBidTotal.replaceAll(',',''));
    } 
    else if(contains(marketDepth.name, " CE")){
        CE.Buy = parseFloat(CE.Buy) + parseFloat(marketDepth.buyBidTotal.replaceAll(',',''));
        CE.Sell = parseFloat(CE.Sell) + parseFloat(marketDepth.sellBidTotal.replaceAll(',',''));
    } else {
        //Not Required...
    }
}

function contains(string, substring) {
    return string.indexOf(substring) !== -1;
}

function checkAndSetPEorCE(name){
    if(contains(name, " CE")){
        return "class='lightGreen'"
    } 
    else if(contains(name, " PE")){
        return "class='lightRed'"
    } else {
        return ""
    }
}

function getTableHeader(){
    var header =  
        `<thead>
            <tr>
                <th scope="col"><label>Name</label></th>
                <th scope="col"><label>Strike Price</label></th>
                <th scope="col"><label>Buy</label></th>
                <th scope="col"><label>Sell</label></th>
                <th scope="col"><label>O</label></th>
                <th scope="col"><label>H</label></th>
                <th scope="col"><label>L</label></th>
                <th scope="col"><label>C</label></th>
                <th scope="col"><label>Volume</label></th>
                <th scope="col"><label>OI</label></th>
            </tr>
        </thead>`;
    return header;
}

function getTableBody(marketDepth){
    var bodyData  =
    `<tr ${checkAndSetPEorCE(marketDepth.name)}>
        <td>${marketDepth.name}</td>
        <td>${marketDepth.strikePrice}</td>
        <td>${marketDepth.buyBidTotal}</td>
        <td>${marketDepth.sellBidTotal}</td>
        <td>${marketDepth.o}</td>
        <td>${marketDepth.h}</td>
        <td>${marketDepth.l}</td>
        <td>${marketDepth.c}</td>        
        <td>${marketDepth.volume}</td>
        <td>${marketDepth.oi}</td>
    </tr>`;
    return bodyData;
}

function getTableBodyForPEorCE(PEorCE, className){
    var bodyData  =
    `<tr class="${className}"> 
        <td class="block"></td>      
        <td class="block">Total</td>  
        <td>${PEorCE.Buy.toLocaleString()}</td>
        <td>${PEorCE.Sell.toLocaleString()}</td>
        <td colspan="6"></td>
    </tr>`;
    return bodyData;
}


function getDataFromBackgroundJS(){    
    try{
        chrome.tabs.query({active: true, currentWindow: true}, function(tabs) {
            chrome.runtime.sendMessage({type: "getScrappedData", id: tabs[0].id}, function(object) {
            try{
                var tableData = '<table class="table">';
                tableData = tableData + getTableHeader();
                if(object != null && object.marketDepths != null && object.marketDepths.length != 0){    
                    let tableBody = ''        
                    PE.Buy = 0;
                    PE.Sell = 0;
                    CE.Buy = 0;
                    CE.Sell = 0;

                    for (const marketDepth of object.marketDepths) {                        
                        tableBody += getTableBody(marketDepth);
                        calculatePEAndCE(marketDepth);
                    }        

                    let tableBodyForPEAndCE = '';                                
                    if(CE.Buy != 0 || CE.Sell != 0) {
                        tableBodyForPEAndCE += getTableBodyForPEorCE(CE, "lightGreen")
                    }
                    if(PE.Buy != 0 || PE.Sell != 0){
                        tableBodyForPEAndCE += getTableBodyForPEorCE(PE, "lightRed")
                    }

                    tableData += tableBodyForPEAndCE;
                    tableData += tableBody;
                }
                else{
                    tableData += '<tr><td colspan="10"><h4>No Data</h4></td><tr>'
                }
                tableData  = tableData + '</table>';
                $('div.showData').html(tableData); 
                
            }
            catch(ex){
                console.log('Error occured in popup js' +ex)
            }
            });
        });
    }
    catch(ex){
        console.log('Error occured in outer popup js' +ex)
    }
}

setInterval(getDataFromBackgroundJS, 800)




