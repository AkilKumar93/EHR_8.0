$(document).ready(function () {   
    $('#faxtab a:first').tab('show');
    $("#tabfax_Compose").on('click', function () {       
        var sPath = ""
        sPath = "frmEFax.aspx";
        $("#TabComposeFrame")[0].contentDocument.location.href = sPath;
    });
    $("#tabfax_Outbox").on('click', function () {      
        var sPath = ""
        sPath = "HtmlEFaxOutbox.html";
        $("#TabOutboxFrame")[0].contentDocument.location.href = sPath;
    });
});

