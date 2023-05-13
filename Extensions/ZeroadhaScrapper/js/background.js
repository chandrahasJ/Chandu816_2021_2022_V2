chrome.runtime.onMessage.addListener(
    function(message, sender, sendResponse) {
        try {            
            switch(message.type) {
                case "setScrappedData":
                    temp = message.zeroadhaScapperData;                                   
                    break;
                case "getScrappedData": 
                    sendResponse(temp);
                    break;
                default:
                    console.error("Unrecognised message: ", message);
            }
        }
        catch(ex) {
            console.log('Error occured in background js' +ex)
        }
    }
); 
 