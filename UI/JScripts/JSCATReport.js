var now = new Date();
var month = (now.getMonth() + 1);
var day = now.getDate();
if (month < 10)
    month = "0" + month;
if (day < 10)
    day = "0" + day;
var today = now.getFullYear() + '-' + month + '-' + day;
var PhysicianList;
var AllPhysicianList;
var UserRole;
var UserID;

$(document).ready(function () {
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
    $.ajax({
        type: "POST",
        url: "frmCATReport.aspx/CATReportLoad",
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        success: function success(data) {
            
            var CATReportLoadList = JSON.parse(data.d);
            $('#txtFacilityName').val(CATReportLoadList.FacilityName);
            $('#txtFacilityName')[0].title = $('#txtFacilityName').val();
            PhysicianList = CATReportLoadList.PhysicianList;
            AllPhysicianList = CATReportLoadList.AllPhysicianList;
            UserRole = CATReportLoadList.UserRole;
            UserID = CATReportLoadList.UserID;
            $("#lstPhysicianName option").remove();
            $("#lstPhysicianName").append('<option value="' + '0' + '">' + "--Select Physician--" + '</option>');
            for (i = 0; i < PhysicianList.length; i++) {
                var arrName = PhysicianList[i].PhyPrefix + " " + PhysicianList[i].PhyFirstName + " " + PhysicianList[i].PhyMiddleName + " " + PhysicianList[i].PhyLastName + " " + PhysicianList[i].PhySuffix;
                var arrID = PhysicianList[i].Id;
                $("#lstPhysicianName").append('<option value="' + arrID + '">' + arrName + '</option>');
            }
            if (UserRole == "Physician") {
                $('#lstPhysicianName option[value="' + UserID + '"]').prop("selected", true);
            }
            $('#dtpFromDOS,#dtpToDOS').val(today);
            $('#dtpFromDOS,#dtpToDOS').attr({ "max": '9999-12-31' });
            { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }

        },
        error: function onerror(xhr) {
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
});

function chkSelectAll_Click() {
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
    if ($("#chkSelectAll")[0].checked == true) {
        $("#lstPhysicianName option").remove();
        $("#lstPhysicianName").append('<option value="' + '0' + '">' + "--Select Physician--" + '</option>');
        for (i = 0; i < AllPhysicianList.length; i++) {
            var arrName = AllPhysicianList[i].PhyPrefix + " " + AllPhysicianList[i].PhyFirstName + " " + AllPhysicianList[i].PhyMiddleName + " " + AllPhysicianList[i].PhyLastName + " " + AllPhysicianList[i].PhySuffix;
            var arrID = AllPhysicianList[i].Id;
            $("#lstPhysicianName").append('<option value="' + arrID + '">' + arrName + '</option>');
        }
        if (UserRole == "Physician") {
            $('#lstPhysicianName option[value="' + UserID + '"]').prop("selected", true);
        }
    }
    else {
        $("#lstPhysicianName option").remove();
        $("#lstPhysicianName").append('<option value="' + '0' + '">' + "--Select Physician--" + '</option>');
        for (i = 0; i < PhysicianList.length; i++) {
            var arrName = PhysicianList[i].PhyPrefix + " " + PhysicianList[i].PhyFirstName + " " + PhysicianList[i].PhyMiddleName + " " + PhysicianList[i].PhyLastName + " " + PhysicianList[i].PhySuffix;
            var arrID = PhysicianList[i].Id;
            $("#lstPhysicianName").append('<option value="' + arrID + '">' + arrName + '</option>');
        }
        if (UserRole == "Physician") {
            $('#lstPhysicianName option[value="' + UserID + '"]').prop("selected", true);
        }
    }
    { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
}

function FindPatient() {
    var oBrowserWnd = GetRadWindow().BrowserWindow;
    var childWindow = oBrowserWnd.radopen("frmFindPatient.aspx", "CATReportWindow");
    setTimeout(
    function () {
        childWindow.SetModal(true);
        childWindow.remove_close(OnClientCloseFindPatient);
        childWindow.set_visibleStatusbar(false);
        childWindow.setSize(1200, 251);
        childWindow.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close | Telerik.Web.UI.WindowBehaviors.Move);
        childWindow.set_iconUrl("Resources/16_16.ico");
        childWindow.set_keepInScreenBounds(true);
        childWindow.set_centerIfModal(true);
        childWindow.set_showContentDuringLoad(false);
        childWindow.set_reloadOnShow(true);
        childWindow.center();
        childWindow.add_close(OnClientCloseFindPatient);

    }, 0);
    return false;
}

function OnClientCloseFindPatient(oWindow, args) {
    var arg = args.get_argument();
    if (arg != undefined) {
        $("#txtPatientName").val(arg.PatientName);
        $("#txtPatientName")[0].title = arg.PatientName;
        $("#hdnPatientValues").val(arg.HumanId);
    }
}

function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow) oWindow = window.radWindow;
    else if (window.frameElement != null && window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
    return oWindow;
}

function btnClearAll_Click() {
    $("#chkSelectAll")[0].checked = false;
    $("#lstPhysicianName option").remove();
    $("#lstPhysicianName").append('<option value="' + '0' + '">' + "--Select Physician--" + '</option>');
    for (i = 0; i < PhysicianList.length; i++) {
        var arrName = PhysicianList[i].PhyPrefix + " " + PhysicianList[i].PhyFirstName + " " + PhysicianList[i].PhyMiddleName + " " + PhysicianList[i].PhyLastName + " " + PhysicianList[i].PhySuffix;
        var arrID = PhysicianList[i].Id;
        $("#lstPhysicianName").append('<option value="' + arrID + '">' + arrName + '</option>');
    }
    $("#txtPatientName").val("");
    $("#txtPatientName")[0].title = "";
    $("#hdnPatientValues").val("");
    $('#dtpFromDOS,#dtpToDOS').val(today);
    $('#dtpFromDOS,#dtpToDOS').attr({ "max": '9999-12-31' });
}

function Report_Click() {

    var FromDOS = $('#dtpFromDOS').val();
    var ToDOS = $('#dtpToDOS').val();

    if (FromDOS == "")
        FromDOS = "0001-01-01";
    if (ToDOS == "")
        ToDOS = "9999-12-01";

    if ($('#dtpFromDOS')[0].validationMessage == "Please enter a valid value. The field is incomplete or has an invalid date.") {
        DisplayErrorMessage('9001');
        return true;
    }
    else if ($('#dtpToDOS')[0].validationMessage == "Please enter a valid value. The field is incomplete or has an invalid date.") {
        DisplayErrorMessage('9002');
        return true;
    }
    else if (FromDOS > ToDOS) {
        DisplayErrorMessage('9003');
        return true;
    }

    var sFacilityName = $('#txtFacilityName').val().replace("#", "%23");

    var sPhysicianName = "ALL";
    var sPhysicianID = "%25";

    if (parseInt($("#lstPhysicianName option:selected").val()) > 0) {
        sPhysicianName = $("#lstPhysicianName option:selected").text();
        sPhysicianID = $("#lstPhysicianName option:selected").val();
    }

    var sPatientName = "ALL";
    var sPatientID = "%25";

    if (parseInt($("#hdnPatientValues").val()) > 0) {
        sPatientName = $("#txtPatientName").val().trim();
        sPatientID = $("#hdnPatientValues").val();
    }

    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "frmCATReport.aspx/btnGenerateReport_Click",
        data: "{'sFacilityName':'" + sFacilityName + "', 'sPhysicianName':'" + sPhysicianName + "','sPhysicianID':'" + sPhysicianID + "', 'sPatientName':'" + sPatientName + "','sPatientID':'" + sPatientID + "','FromDOS':'" + FromDOS + "','ToDOS':'" + ToDOS + "'}",
        dataType: "json",
        success: function (data) {
            window.setTimeout(function () { document.getElementById("iFrame").src = data.d }, 50);
            { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
        },
        error: function onerror(xhr) {
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
    return false;
}

function btnReportClose_Click() {
    self.close();
}