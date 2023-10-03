$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "WebServices/TestService.asmx/LoadTestTab",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (data) {
            if (data.d != '') {
                for (var i = 0; i < data.d.split('^').length; i++) {
                    var TabName = "#li" + data.d.split('^')[i].replace(/ /g, '');
                    $(TabName)[0].attributes.style.value = "display:block";
                }
                var FirstName = $("ul#myTabs")[0].innerText.split(/\n/g)[0];
                if (FirstName == "Mini Mental Status Exam") {
                    var target = $('#myTabs li:eq(0) a').tab('show');
                    localStorage.setItem("PrevSubTab", target[0].innerText);
                }
                if (FirstName == "Depression Screening") {
                    var target = $('#myTabs li:eq(1) a').tab('show');
                    localStorage.setItem("PrevSubTab", target[0].innerText);
                }
                if (FirstName == "Spiritual Care Assessment") {
                    var target = $('#myTabs li:eq(2) a').tab('show');
                    localStorage.setItem("PrevSubTab", target[0].innerText);
                }
                if (FirstName != null) {
                    $("#i" + FirstName.replace(/ /g, ''))[0].attributes[2].value = "frmTest.aspx?TabName=" + FirstName;
                }
            }
            else {
                DisplayErrorMessage('1180008');
                { sessionStorage.setItem('StartLoading', 'true'); StopLoadFromPatChart(); }
            }
        },
        error: function OnError(xhr) {
            if (xhr.status == 999)
                window.location = "/frmSessionExpired.aspx";
            else {
                var log = JSON.parse(xhr.responseText);
                console.log(log);
                alert("USER MESSAGE:\n" +
                                    ". Cannot process request. Please Login again and retry. \nEXCEPTION DETAILS: \n" +
                                   "Message: " + log.Message);
            }
             {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
        }
    });
});
var bPlanCancel = false;
var PrevTab;
var CurTab;
var bPlanCancel = false;
var dvdialog;
$('.nav-tabs a').on('shown.bs.tab', function (event) {
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
    CurTab = $(event.target);         // active tab
    PrevTab = $(event.relatedTarget);  // previous tab     
    localStorage.setItem("PrevSubTab", CurTab[0].innerText);
    if (window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable.value == "true" && localStorage.getItem("bSave") == "false") {

            event.preventDefault();
            event.stopPropagation();
            { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
            if (PrevTab[0].innerText == "Mini Mental Status Exam") {
                event.preventDefault();
                event.stopPropagation();
                $('.clsIframe').contents()[0].all.namedItem('btnSave').click();
                if (localStorage.getItem("bSave") == "true") {
                    paneID = $(event.target).attr('href');
                    ClickTab($(event.target)[0].innerText);
                }
                else {
                    window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable.value = "false";
                    PrevTab.tab('show');
                    return;
                }
            }
            else if (PrevTab[0].innerText == "Depression Screening") {
                event.preventDefault();
                event.stopPropagation();
                $('.clsIframe').contents()[1].all.namedItem('btnSave').click();
                if (localStorage.getItem("bSave") == "true") {
                    paneID = $(event.target).attr('href');
                    ClickTab($(event.target)[0].innerText);
                }
                else {
                    window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable.value = "false";
                    PrevTab.tab('show');
                    return;
                }
            }
            else if (PrevTab[0].innerText == "Spiritual Care Assessment") {
                event.preventDefault();
                event.stopPropagation();
                $('.clsIframe').contents()[2].all.namedItem('btnSave').click();
                if (localStorage.getItem("bSave") == "true") {
                    paneID = $(event.target).attr('href');
                    ClickTab($(event.target)[0].innerText);
                }
                else {
                    window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable.value = "false";
                    PrevTab.tab('show');
                    return;
                }
            }
            return;
        

        // {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
        //event.preventDefault();
        //event.stopPropagation();
        //$(top.window.document).find("body").append("<div id='dvdialog' style='min-height: 65px !important; width: auto; max-height: none; height: auto; display: none;'>" +
        //                    "<p style='font-family: Verdana,Arial,sans-serif; font-size: 13.5px;'>There are unsaved changes.Do you want to save them?</p></div>");
        //dvdialog = window.parent.parent.parent.parent.document.getElementsByTagName('div').namedItem('dvdialog');
        //$(dvdialog).dialog({
        //    modal: true,
        //    title: "Capella -EHR",
        //    position: {
        //        my: 'left' + " " + 'center',
        //        at: 'center' + " " + 'center + 100px'

        //    },
        //    buttons: {
        //        "Yes": function () {
        //            { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
        //            $(dvdialog).dialog("close");
        //            $(dvdialog).remove();
        //            if (PrevTab[0].innerText == "Mini Mental Status Exam") {
        //                event.preventDefault();
        //                event.stopPropagation();
        //                $('.clsIframe').contents()[0].all.namedItem('btnSave').click();
        //                if (localStorage.getItem("bSave") == "true") {
        //                    paneID = $(event.target).attr('href');
        //                    ClickTab($(event.target)[0].innerText);
        //                }
        //                else {
        //                    window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable.value = "false";
        //                    PrevTab.tab('show');
        //                    return;
        //                }
        //            }
        //            else if (PrevTab[0].innerText == "Depression Screening") {
        //                event.preventDefault();
        //                event.stopPropagation();
        //                $('.clsIframe').contents()[1].all.namedItem('btnSave').click();
        //                if (localStorage.getItem("bSave") == "true") {
        //                    paneID = $(event.target).attr('href');
        //                    ClickTab($(event.target)[0].innerText);
        //                }
        //                else {
        //                    window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable.value = "false";
        //                    PrevTab.tab('show');
        //                    return;
        //                }
        //            }
        //            else if (PrevTab[0].innerText == "Spiritual Care Assessment") {
        //                event.preventDefault();
        //                event.stopPropagation();
        //                $('.clsIframe').contents()[2].all.namedItem('btnSave').click();
        //                if (localStorage.getItem("bSave") == "true") {
        //                    paneID = $(event.target).attr('href');
        //                    ClickTab($(event.target)[0].innerText);
        //                }
        //                else {
        //                    window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable.value = "false";
        //                    PrevTab.tab('show');
        //                    return;
        //                }
        //            }
        //            return;
        //        },
        //        "No": function () {
        //            var vv;
        //            { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
        //            window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable.value = "false";
        //            $(dvdialog).dialog("close");
        //            $(dvdialog).remove();
        //            paneID = $(event.target).attr('href');
        //            var FirstName = $(event.target)[0].innerText;
        //            if (FirstName != null)
        //            {
        //                $("#i" + FirstName.replace(/ /g, ''))[0].attributes[2].value = "frmTest.aspx?TabName=" + FirstName;
        //                vv = "frmTest.aspx?TabName=" + FirstName;
        //            }
        //            src = $(paneID).attr('data-src');
        //            src = vv;
        //            $(paneID + " iframe").attr("src", src);

        //            $(paneID + " iframe").attr("src", src);

        //        },
        //        "Cancel": function () {
        //            { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
        //            bPlanCancel = true;
        //            window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable.value = "false";
        //            $(dvdialog).dialog("close");
        //            $(dvdialog).remove();
        //            PrevTab.tab('show');
        //            return;

        //        }
        //    }
        //});
    }
    else {
        if ($(".ui-dialog").is(":visible")) {
            $(dvdialog).dialog("close");
            $(dvdialog).remove();
        }
        if (bPlanCancel == false) {
            var vv;
            localStorage.setItem("bSave", "false");
            paneID = $(event.target).attr('href');
            var FirstName = $(event.target)[0].innerText;
            if (FirstName != null) {
                $("#i" + FirstName.replace(/ /g, ''))[0].attributes[2].value = "frmTest.aspx?TabName=" + FirstName;
            }
            src = $(paneID).attr('data-src');
            src = vv;
            $(paneID + " iframe").attr("src", src);
        } else {
            bPlanCancel = false;
            localStorage.setItem("bSave", "false");
            window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable.value = "true";
             {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
        }

    }
   
});
function ClickTab(value) {

    var FirstName = value;
    localStorage.setItem("bSave", "false");
    if(FirstName!=null) {
        $("#i" + FirstName.replace(/ /g, ''))[0].attributes[2].value = "frmTest.aspx?TabName=" + FirstName;
    }
}
