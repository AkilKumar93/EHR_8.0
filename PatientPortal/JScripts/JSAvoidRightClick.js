
var lstSummary = [];
function onchangeCheckBox(){
$("#SummaryCheckList input[type=checkbox]").change(function () {
    debugger;
    if ($(this)[0].labels[0].innerText == "All") {
        
        $($('#SummaryCheckList')[0]).find("input[type='checkbox']:checked").removeAttr("checked");
        $($($('#SummaryCheckList')[0]).find("input[type='checkbox']")[0])[0].checked = "true";
        lstSummary = [];
    }
    else {
        $($($('#SummaryCheckList')[0]).find("input[type='checkbox']")[0]).removeAttr("checked");
    }
    if (this.checked) {
        lstSummary.push($(this)[0].labels[0].innerText);
    }
    else {
        const index = lstSummary.indexOf($(this)[0].labels[0].innerText);

        if (index !== -1) {
            lstSummary.splice(index, 1);
        }
    }
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
    debugger;
      
    var WSData = JSON.stringify({ data: lstSummary });
     
    $.ajax({
        type: "POST",
        url: "frmSummaryOfCare.aspx/GeneratePDFforSummary",
        data: WSData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $("#PDFLOAD").attr("src", data.d);
            { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
            //$("#PDFLOAD").attr("src", data.d);
        },
        error: function OnError(xhr) {
            if (xhr.status == 999)
                window.location = "/frmSessionExpired.aspx";
            else {
                var log = JSON.parse(xhr.responseText);
                console.log(log);
                alert("USER MESSAGE:\n" + xhr.status + "-" + xhr.statusText +
                    ". \nCannot process request. Please Login again and retry. If issue persists, Please contact Support.\n\nEXCEPTION DETAILS: \nException Type" +
                    log.ExceptionType + " \nMessage: " + log.Message);
            }
            { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
        }
    });
    
});
}
    function remove(lstSummary, element) {
   
    }

    //function mouseDown(n) { try { if (2 == event.button || 3 == event.button) return !1 } catch (n) { if (3 == n.which) return !1 } } document.oncontextmenu = function () { return !1 }, document.onmousedown = mouseDown;