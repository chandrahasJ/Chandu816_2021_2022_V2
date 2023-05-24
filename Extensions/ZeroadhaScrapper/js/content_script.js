let generateJsonDataForMarketDepth = () => {
  let marketDepth = $(".market-depth");
  try {
    if (marketDepth && marketDepth.length != 0) {
      var zeroadhaScapper = {};
      var marketDepths = [];
      zeroadhaScapper.marketDepths = marketDepths;

      $(marketDepth).each(function (index, marketDepthObject) {
        try {
          let name = $(marketDepthObject)
            .parent()
            .find("span.nice-name")
            .text()
            .trim();
          let strikePrice = $(marketDepthObject)
            .parent()
            .find("span.last-price")
            .text()
            .trim();

          let buyBidTotal = $(marketDepthObject)
            .find(".buy > tfoot > tr > td.text-right")
            .text()
            .trim();
          let sellBidTotal = $(marketDepthObject)
            .find(".sell > tfoot > tr > td.text-right")
            .text()
            .trim();
          let volume = $(marketDepthObject)
            .find("div.ohlc> div.row:eq(2) > div.columns:eq(0) > span.value")
            .text()
            .trim();
          let o = $(marketDepthObject)
                  .find("div.ohlc> div.row:eq(0) > div.columns:eq(0) > a.value")
                  .text()
                  .trim();
          let h = $(marketDepthObject)
                  .find("div.ohlc> div.row:eq(0) > div.columns:eq(1) > a.value")
                  .text()
                  .trim();
          let l = $(marketDepthObject)
                  .find("div.ohlc> div.row:eq(1) > div.columns:eq(0) > a.value")
                  .text()
                  .trim();
          let c = $(marketDepthObject)
                  .find("div.ohlc> div.row:eq(1) > div.columns:eq(1) > a.value")
                  .text()
                  .trim();
          let oi = $(marketDepthObject)
                  .find("div.ohlc> div.row:eq(4) > div.columns:eq(1) > span.value")
                  .text()
                  .trim();

          var marketDepthData = {
            name: name,
            strikePrice: strikePrice,
            buyBidTotal: buyBidTotal,
            sellBidTotal: sellBidTotal,
            volume: volume,
            o : o,
            h : h,
            l : l,
            c : c,
            oi : oi
          };
          zeroadhaScapper.marketDepths.push(marketDepthData);
        } catch (ex) {
          console.log("Error occured in content script js" + ex);
        }
      });
      if (
        zeroadhaScapper &&
        zeroadhaScapper.marketDepths &&
        zeroadhaScapper.marketDepths.length != 0
      ) {
        /* Inform the background page that 
                 this tab should have a page-action. */
        chrome.runtime.sendMessage({
          type: "setScrappedData",
          zeroadhaScapperData: zeroadhaScapper,
        });
      } else {
        chrome.runtime.sendMessage({
          type: "setScrappedData",
          zeroadhaScapperData: {},
        });
      }
    } else {
      chrome.runtime.sendMessage({
        type: "setScrappedData",
        zeroadhaScapperData: {},
      });
    }
  } catch (ex) {
    console.log('outer content script '+ex)
  }
};

var disposeIDForSetInterval = setInterval(generateJsonDataForMarketDepth, 700);
