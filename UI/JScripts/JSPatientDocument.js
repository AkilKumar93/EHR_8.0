$(document).ready(function () {
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
    var username = "";
    $.ajax({
        type: "POST",
        url: "frmPatientDocuments.aspx/FillPatientDocuments",
        data: JSON.stringify({
            "sUsername": username,
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (data) {
            var objdata = $.parseJSON(data.d);

            if (objdata.UserLookup.length > 0) {
                for (var i = 0; i < objdata.UserLookup.length; i++) {
                    var chkid = "chk_" + objdata.UserLookup[i].Value;
                    $('#divchkpatientdocument').append("<input  type='checkbox' id='" + chkid + "' value='" + objdata.UserLookup[i].Description + "'  /> " + objdata.UserLookup[i].Value + "<br />");
                }
            }
            { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
        },
        failure: function (data) {
            { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
            if (xhr.status == 999)
                window.location = xhr.statusText;
            else {
                var log = JSON.parse(xhr.responseText);
                console.log(log);
                alert("USER MESSAGE:\n" +
                                    ". Cannot process request. Please Login again and retry. \nEXCEPTION DETAILS: \n" +
                                   "Message: " + log.Message);
            }
        }
    });

});

$("#btnPrint").click(function () {
    var chk = $('#divchkpatientdocument input:checked');
    if ($('#divchkpatientdocument input').length == 0) {
        DisplayErrorMessage('5003');
    }
    else if (chk.length == 0) {
        DisplayErrorMessage('5002');
    }
    else {
        var rows = $("#tblPlan tbody tr");
        var CheckedDocumnts = "";
        var CheckedDocumnts1 = "";
        var ViewDocuments = "";
        var progress = false;
        var con = false;
        var well = false;
        var summary = false;
        for (var i = 0; i < chk.length; i++) {
            if (CheckedDocumnts1 == "") {
                CheckedDocumnts1 = chk[i].defaultValue;
            }
            else {
                CheckedDocumnts1 += ':' + chk[i].defaultValue;
            }
        }
        var Data = [CheckedDocumnts1];
        $.ajax({
            type: "POST",
            url: "frmPatientDocuments.aspx/FindPatientDocument",
            data: JSON.stringify({
                "data": Data,
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: function (data) {
                var objdata = $.parseJSON(data.d);
                var selectitems = objdata.SelectedFile;
                var files = objdata.Files;
                var selectfile = selectitems.split(",");
                
                for (var i = 0; i < selectfile.length; i++) {
                    if (selectfile[i].toUpperCase().indexOf("PROGRESS NOTE") >= 0) {
                        progress = true;
                    }
                    if (selectfile[i].toUpperCase().indexOf("CONSULTATION NOTE") >= 0) {
                        con = true;
                    }
                    if (selectfile[i].toUpperCase().indexOf("WELLNESS NOTE") >= 0) {
                        well = true;
                    }
                    if (selectfile[i].toUpperCase().indexOf("CLINICAL SUMMARY") >= 0) {
                        summary = true;
                        OpenClinicalSmry_Plan(summary);
                    }
                    if (selectfile[i].indexOf(".DO") >= 0) {
                        if (CheckedDocumnts == "" && selectfile[i].indexOf(".") >= 0) {
                            CheckedDocumnts = selectfile[i];
                        }
                        else if (selectfile[i].indexOf(".") >= 0) {
                            CheckedDocumnts += '|' + selectfile[i];
                        }
                    }
                    else {
                        if (ViewDocuments == "" && selectfile[i].indexOf(".") >= 0) {
                            ViewDocuments = selectfile[i].replace(".pdf", "");
                        }
                        else if (selectfile[i].indexOf(".") >= 0) {
                            ViewDocuments += '|' + selectfile[i].replace(".pdf", "");
                        }
                    }


                }
                if (CheckedDocumnts == "" && chk.length == 0) {
                    DisplayErrorMessage('110805');
                    { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
                    return;
                }
                if (files != "" && chk.length > 0) {
                    DisplayErrorMessageList('110806', files);
                }
                if (progress) {
                    var sPath = ""
                    sPath = "frmSummaryNew.aspx?Menu=PDF";
                    //BugID:42305
                    $(top.window.document).find("#PlanModal").modal({ backdrop: "static", keyboard: false }, 'show');
                    $(top.window.document).find('#ProcessiFrame')[0].contentDocument.location.href = sPath;
                    $(top.window.document).find('#PlanModal').modal('hide');

                }
                if (con) {
                    sPath = "frmConsultationNotes.aspx?Menu=PDF";
                    $(top.window.document).find("#PlanModal").modal({ backdrop: "static", keyboard: false }, 'show');
                    $(top.window.document).find('#ProcessiFrame')[0].contentDocument.location.href = sPath;
                    $(top.window.document).find('#PlanModal').modal('hide');
                }
                if (well) {
                    $(top.window.document).find("#PlanModal").modal({ backdrop: "static", keyboard: false }, 'show');
                    $(top.window.document).find('#ProcessiFrame')[0].contentDocument.location.href = "frmWellnessNotes.aspx?SubMenuName=WELLNESS NOTES" + "&Menu=True";
                    $(top.window.document).find('#PlanModal').modal('hide');

                }
                if (ViewDocuments != "") {
                    var obj = new Array();
                    obj.push("SI=" + ViewDocuments);
                    obj.push("Location=" + "STATIC");
                    $(top.window.document).find('#ProcessModalPatientDocuments').modal({ backdrop: 'static', keyboard: false }, 'show');
                    var sPath = ""
                    sPath = "frmPrintPDF.aspx?SI=" + ViewDocuments + "&Location=STATIC";
                    $(top.window.document).find("#mdldlgPatientDocuments")[0].style.width = "85%";
                    //$(top.window.document).find("#mdldlg")[0].style.height = "98%";
                    $(top.window.document).find("#mdldlgPatientDocuments")[0].style.height = "62%";
                    $(top.window.document).find("#ProcessFramePatientDocuments")[0].style.height = "500px";
                    $(top.window.document).find("#ProcessFramePatientDocuments")[0].style.width = "99%";
                    //$(top.window.document).find("#ProcessModal")[0].style.height = "99%";
                    $(top.window.document).find("#ProcessModalPatientDocuments")[0].style.height = "100%";
                    $(top.window.document).find("#ProcessModalPatientDocuments")[0].style.width = "";
                    $(top.window.document).find("#ProcessModalPatientDocuments")[0].style.zIndex = "5001";
                    $(top.window.document).find('#ProcessFramePatientDocuments')[0].contentDocument.location.href = sPath;
                    $(top.window.document).find("#ModalTitlePatientDocuments")[0].textContent = "Print Documents";


                }
                if (CheckedDocumnts != "") {
                    var sPath = ""
                    sPath = "frmWellnessNotes.aspx?PatientDocuments=Patient_Documents&CheckedDocumnts=" + CheckedDocumnts;;
                    $(top.window.document).find("#PlanModal").modal({ backdrop: "static", keyboard: false }, 'show');
                    $(top.window.document).find("#ProcessiFrame")[0].contentDocument.location.href = sPath;
                    $(top.window.document).find("#PlanModal").modal('hide');
                }

                
            },
            error: function OnError(xhr) {
                if (xhr.status == 999)
                    window.location = xhr.statusText;
                else {
                    var log = JSON.parse(xhr.responseText);
                    console.log(log);
                    alert("USER MESSAGE:\n" +
                                        ". Cannot process request. Please Login again and retry. \nEXCEPTION DETAILS: \n" +
                                       "Message: " + log.Message);
                }
                { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
            }
        });


        

        
    }

});

function OpenClinicalSmry_Plan(summary) {
    $(top.window.document).find('#ProcessPlan').modal({ backdrop: 'static', keyboard: false }, 'show');
    var sPath = ""
    sPath = "frmClinicalSummary.aspx";
    $(top.window.document).find("#mdldlgPlan")[0].style.width = "1020px";
    $(top.window.document).find("#mdldlgPlan")[0].style.height = "560px";
    $(top.window.document).find("#ProcessFrame2")[0].style.height = "465px";
    $(top.window.document).find("#ProcessFrame2")[0].style.width = "1000px";
    $(top.window.document).find("#mdldlgPlan").css("margin-top", "30px !important");
    
    $(top.window.document).find("#ProcessPlan")[0].style.zIndex = "5000";
    $(top.window.document).find('#ProcessFrame2')[0].contentDocument.location.href = sPath;
    $(top.window.document).find("#ModalTitle2")[0].textContent = "Clinical Summary";
}