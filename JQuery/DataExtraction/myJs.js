$(document).ready((e) => {
    
    $('#divDataFromFile').html(domdata);
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