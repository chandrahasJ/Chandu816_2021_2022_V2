$(document).ready((e) => {
    var url = this.window.location.toString();
    console.log(url +"   "+ url.indexOf("getwpfmvvm.html") + "   "+ url.indexOf("run.html"));
    
    if(url.indexOf("run.html") != -1){        
        console.log("a");
        $('#divDataFromFile').html(domdata);
    }
    else if(url.indexOf("getwpfmvvm.html") != -1){
        $('#divDataFromFile').html(domDataMVVM);
    }
    var spans = $("#divDataFromFile").find("span.ytd-playlist-panel-video-renderer");
   
    var data = "";
    var i = 0;

    spans.each((e) => {
        
        var spanTitle = spans[e].title;
        if(spanTitle != ""){
            i++;
            data += "<p>\""+spanTitle+"\",</p>"
        }
    });
    $("#divRenderData").html(data);

}); 