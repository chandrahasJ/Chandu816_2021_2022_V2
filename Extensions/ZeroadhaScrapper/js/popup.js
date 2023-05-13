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

function getTableHeader(){
    var header =  
        `<thead>
            <tr>
                <th scope="col"><label>Name</label></td>
                <th scope="col"><label>Strike Price</label></td>
                <th scope="col"><label>Bid Buy</label></td>
                <th scope="col"><label>Bid Sell</label></td>
                <th scope="col"><label>Volume</label></td>
            </tr>
        </thead>`;
    return header;
}

function getTableBody(marketDepth){
    var bodyData  =
    `<tr>
        <td>${marketDepth.name}</td>
        <td>${marketDepth.strikePrice}</td>
        <td>${marketDepth.buyBidTotal}</td>
        <td>${marketDepth.sellBidTotal}</td>
        <td>${marketDepth.volume}</td>
    </tr>`;
    return bodyData;
}


function getDataFromBackgroundJS(){    
    try{
        chrome.tabs.query({active: true, currentWindow: true}, function(tabs) {
            chrome.runtime.sendMessage({type: "getScrappedData", id: tabs[0].id}, function(object) {
            try{
                /* ... */ 
                var tableData = '<table class="table table-striped">';
                tableData = tableData + getTableHeader();
                if(object != null && object.marketDepths != null && object.marketDepths.length != 0){            
                    for (const marketDepth of object.marketDepths) {
                        tableData += getTableBody(marketDepth) 
                    }            
                }
                else{
                    tableData += '<tr><td colspan="5"><h4>No Data</h4></td><tr>'
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

setInterval(getDataFromBackgroundJS, 1000)




