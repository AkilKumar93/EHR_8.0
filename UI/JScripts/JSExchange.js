
function EditorSummary_Load(sender, args) {
    sender.set_editable(true);
}
function btnSubmit_ClientClick(sender, args) {

    if (DisplayErrorMessage('9006') == true) {
        sender.set_autoPostBack(true);
        return;
    }
    else {
        sender.set_autoPostBack(false);
    }
}

function btnClose_Click() {
    self.close();
    return;
}
function downloadURI(uri) {
    { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
    var link = document.createElement('a'); link.download = "Immunization_Response"; link.href = uri; link.click();
}
function Download(event) {
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
    var filelocation = document.getElementById('hdnXmlPath').value;
    var sValue = document.getElementById(event.id).nextSibling.innerHTML
    var sCheck = filelocation + ' ' + sValue;
    if (sCheck.toUpperCase() == "ADMIT / VISIT NOTIFICATION WITH ACKNOWLEDGEMENT") {
        var objACO = openModalProgress("frmImmunizationRegistry.aspx?TabName=SyndromicSurveillance|ADMIT / VISIT NOTIFICATION WITH ACKNOWLEDGEMENT", 520, 665, null, "RadExchangeWindow");
        var win = $find("RadExchangeWindow");
        win.hide();
    }
    else if (sCheck.toUpperCase() == "DISCHARGE / END VISIT WITH ACKNOWLEDGEMENT") {
        var objACO = openModalProgress("frmImmunizationRegistry.aspx?TabName=SyndromicSurveillance|DISCHARGE / END VISIT WITH ACKNOWLEDGEMENT", 500, 500, null, "RadExchangeWindow");
        var win = $find("RadExchangeWindow");
        win.hide();
    }
    else if (sCheck.toUpperCase() == "REGISTER PATIENT WITH ACKNOWLEDGEMENT") {
        var objACO = openModalProgress("frmImmunizationRegistry.aspx?TabName=SyndromicSurveillance|REGISTER PATIENT WITH ACKNOWLEDGEMENT", 500, 500, null, "RadExchangeWindow");
        var win = $find("RadExchangeWindow");
        win.hide();
    }
    else if (sCheck.toUpperCase() == "UPDATE PATIENT INFORMATION WITH ACKNOWLEDGEMENT") {
        var objACO = openModalProgress("frmImmunizationRegistry.aspx?TabName=SyndromicSurveillance|UPDATE PATIENT INFORMATION WITH ACKNOWLEDGEMENT", 500, 500, null, "RadExchangeWindow");
        var win = $find("RadExchangeWindow");
        win.hide();
    }
    else if (sCheck.toUpperCase() == "ADMIT / VISIT NOTIFICATION WITHOUT ACKNOWLEDGEMENT") {
        var objACO = openModalProgress("frmImmunizationRegistry.aspx?TabName=SyndromicSurveillance|ADMIT / VISIT NOTIFICATION WITHOUT ACKNOWLEDGEMENT", 560, 680, null, "RadExchangeWindow");
        var win = $find("RadExchangeWindow");
        win.hide();
    }
    else if (sCheck.toUpperCase() == "DISCHARGE / END VISIT WITHOUT ACKNOWLEDGEMENT") {
        var objACO = openModalProgress("frmImmunizationRegistry.aspx?TabName=SyndromicSurveillance|DISCHARGE / END VISIT WITHOUT ACKNOWLEDGEMENT", 500, 500, null, "RadExchangeWindow");
        var win = $find("RadExchangeWindow");
        win.hide();
    }
    else if (sCheck.toUpperCase() == "REGISTER PATIENT WITHOUT ACKNOWLEDGEMENT") {
        var objACO = openModalProgress("frmImmunizationRegistry.aspx?TabName=SyndromicSurveillance|REGISTER PATIENT WITHOUT ACKNOWLEDGEMENT", 500, 500, null, "RadExchangeWindow");
        var win = $find("RadExchangeWindow");
        win.hide();
    }
    else if (sCheck.toUpperCase() == "UPDATE PATIENT INFORMATION WITHOUT ACKNOWLEDGEMENT") {
        var objACO = openModalProgress("frmImmunizationRegistry.aspx?TabName=SyndromicSurveillance|UPDATE PATIENT INFORMATION WITHOUT ACKNOWLEDGEMENT", 500, 500, null, "RadExchangeWindow");
        var win = $find("RadExchangeWindow");
        win.hide();
    }
   
}
function DisplayResponseInfo(ResponseInfo) {
    
    if (ResponseInfo.trim().toString() != "") {
        $("#patientInfo").find("tr:gt(0)").remove();
        $("#immScheduleInfo").find("tr:gt(0)").remove();
        $("#immHistoryInfo").find("tr:gt(0)").remove();
        $("#immForcastInfo").find("tr:gt(0)").remove();
        var ResponseInfo = JSON.parse(ResponseInfo);
        var PatientData = ResponseInfo.PatientInfo;
        var ImmSchedule = ResponseInfo.ImmScheduleInfo;
        var ImmHistory = ResponseInfo.ImmHistoryInfo;
        var ImmForecast = ResponseInfo.ImmHistoryForcstInfo;
        if (PatientData != undefined && PatientData.length > 0) {
            $('#patientInfo').append("<tr><td>" + PatientData[0].PID + "</td><td>" + PatientData[0].PatientName + "</td><td>" + PatientData[0].DOB + "</td><td>" + PatientData[0].Gender + "</td></tr>");
        }
        if (ImmSchedule != undefined && ImmSchedule.length > 0) {
            for (var i = 0; i < ImmSchedule.length; i++) {
                $('#immScheduleInfo').append("<tr><td>" + ImmSchedule[i].Imm_Schedule + "</td></tr>");
            }

        }
        else {
            $('#immScheduleInfo').css("display", "none");
        }
        if (ImmHistory != undefined && ImmHistory.length > 0) {
            for (var i = 0; i < ImmHistory.length; i++) {
                $('#immHistoryInfo').append("<tr><td>" + ImmHistory[i].Vaccine_Group + "</td><td>" + ImmHistory[i].Vaccine_Administered + "</td><td>" + ImmHistory[i].Date_Administered + "</td><td>" + ImmHistory[i].Valid_Dose + "</td><td>" + ImmHistory[i].Validity_Reason + "</td><td>" + ImmHistory[i].Completion_Status + "</td></tr>");
            }
        }
        else {
            $('#immHistoryInfo').css("display", "none");
            $('#fldImmHis').css("display", "none");

        }
        if (ImmForecast != undefined && ImmForecast.length > 0) {
            for (var i = 0; i < ImmForecast.length; i++) {
                $('#immForcastInfo').append("<tr><td>" + ImmForecast[i].Vaccine_Group + "</td><td>" + ImmForecast[i].Due_Date + "</td><td>" + ImmForecast[i].Earliest_Date_To_Give + "</td><td>" + ImmForecast[i].Latest_Date_To_Give + "</td></tr>");
            }
        }
        else {
            $('#immForcastInfo').css("display", "none");
            $('#fldImmForecast').css("display", "none");

        }
    }
}
function PopulateGrid(stDateTime) {
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
    $("#DatesListItems a").css("color", "blue");
    $(event.currentTarget).css("color", "grey");
    $.ajax({
        type: "POST",
        url: "frmExchange.aspx/PopulatePatientImmHistoryData",
        data: JSON.stringify({ DateTimeInfo: stDateTime }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            ResponseInfo = data.d;
            DisplayResponseInfo(ResponseInfo);
            { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
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
            { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
        }
    });
}