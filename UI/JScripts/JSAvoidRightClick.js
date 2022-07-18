
var lstSummary = [];
function onchangeCheckBox(){
$("#SummaryCheckList input[type=checkbox]").change(function () {
    
    if ($(this)[0].labels[0].innerText == "All") {
        
        $($('#SummaryCheckList')[0]).find("input[type='checkbox']:checked").removeAttr("checked");
        $($($('#SummaryCheckList')[0]).find("input[type='checkbox']")[0])[0].checked = "true";
        lstSummary = [];
    }
    else {
        $($($('#SummaryCheckList')[0]).find("input[type='checkbox']")[0]).removeAttr("checked");
    }
    if (this.checked) {
        if (lstSummary.includes($(this)[0].labels[0].innerText) == false) {
            lstSummary.push($(this)[0].labels[0].innerText);
        }
    }
    else {
        const index = lstSummary.indexOf($(this)[0].labels[0].innerText);

        if (index !== -1) {
            lstSummary.splice(index, 1);
        }
    }
    //{ sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
    
      
    //var WSData = JSON.stringify({ data: lstSummary });
     
    //$.ajax({
    //    type: "POST",
    //    url: "frmSummaryOfCare.aspx/GeneratePDFforSummary",
    //    data: WSData,
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "json",
    //    success: function (data) {
    //        $("#PDFLOAD").attr("src", data.d);
    //        { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
    //        return true;
    //    },
    //    error: function OnError(xhr) {
    //        if (xhr.status == 999)
    //            window.location = xhr.statusText;
    //        else {
    //            var log = JSON.parse(xhr.responseText);
    //            console.log(log);
    //            alert("USER MESSAGE:\n" +
    //                                ". Cannot process request. Please Login again and retry. \nEXCEPTION DETAILS: \n" +
    //                               "Message: " + log.Message);
    //        }
    //        { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
    //    }
    //});
    
});
}
    function remove(lstSummary, element) {
   
    }

