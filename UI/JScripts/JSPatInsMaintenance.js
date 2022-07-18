function openwindow() {
    var index = parseInt(document.getElementById("hdnSelectedIndex").value) + 1;
    var grid = document.getElementById("grdPolicyInformation");
    var Row = grid.rows[index];
    if (Row) {
        insHumanId = Row.cells[11].innerHTML;
        InsPlan = Row.cells[14].innerHTML;
        HumanId = document.getElementById("hdnHumanID").value;//document.getElementById("txtAccountNo").value;

        setTimeout(
    function () {
        var oWnd = GetRadWindow();

        var childWindow = oWnd.BrowserWindow.radopen("frmAddInsurancePolicies.aspx?HumanId=" + HumanId + "&InsPlan=" + InsPlan + "&InsHumanId=" + insHumanId + "&PatientType=" + document.getElementById("divPatientstrip").innerText.split('|')[6].split(':')[1] + "&CurrentProcess=" + document.getElementById("hdnCurrentProcess").value + "EncounterId=" + document.getElementById("hdnEncounterID").value, "PatInsuredMaintanenceModalWindow");
        SetRadWindowProperties(childWindow, 850, 1140);
        childWindow.add_close(ViewUpdatePolicyInformationClick);
        childWindow.remove_close(CloseAddInsWindow);
        childWindow.remove_close(AddSelfClick);
    }, 0);

    }
    else {
        DisplayErrorMessage('420021');
        return false;
    }
    return false;
}
function openAddinswindow() {
    HumanId = document.getElementById("hdnHumanID").value
    txtPatientlastname = document.getElementById("divPatientstrip").innerText.split('|')[0].split(',')[0].trim();//document.getElementById("txtPatientLastName").value
    txtPatientfirstname = document.getElementById("divPatientstrip").innerText.split('|')[0].split(',')[1].trim();//document.getElementById("txtPatientFirstName").value
    txtExternalAccNo = document.getElementById("divPatientstrip").innerText.split('|')[4].split(':')[1].trim();//document.getElementById("txtPatientExternalAccNo").value;
    txtAccNo = document.getElementById("divPatientstrip").innerText.split('|')[3].split(':')[1].trim();//document.getElementById("hdnInsuredHumanID").value
    txtPateintType = document.getElementById("divPatientstrip").innerText.split('|')[6].split(':')[1].trim();//document.getElementById("hdnInsuredHumanID").value
    var obj = new Array();
    setTimeout(
    function () {
        var oWnd = GetRadWindow();
        var oManager = oWnd.get_windowManager();

        var childWindow = oManager.BrowserWindow.radopen("frmAddInsurancePolicies.aspx?HumanId=" + HumanId + "&InsuranceType=" + true + "&LastName=" + txtPatientlastname + "&FirstName=" + txtPatientfirstname + "&ExAccountNo=" + txtExternalAccNo + "&InsuredHumanID=" + txtAccNo + "&PatientType=" + txtPateintType + "&EncounterId=" + document.getElementById("hdnEncounterID").value, "PatInsuredMaintanenceModalWindow");
        SetRadWindowProperties(childWindow, 800, 1125);
        childWindow.add_close(CloseAddInsWindow);
        childWindow.remove_close(ViewUpdatePolicyInformationClick);
        childWindow.remove_close(AddSelfClick);
    }, 0);

    return false;
}
function openDemographicswindow() {
    var index = parseInt(document.getElementById("hdnSelectedIndex").value) + 1;
    var grid = document.getElementById("grdPolicyInformation");
    var Row = grid.rows[index];
    if (Row) {
        insHumanId = Row.cells[11].innerHTML;
        var obj = new Array();

        obj.push("HumanId=" + insHumanId);
        obj.push("bInsurance=" + false);
        obj.push("EncounterId=" + document.getElementById("hdnEncounterID").value);
        setTimeout(
    function () {
        var oWnd = GetRadWindow();

        var result = oWnd.BrowserWindow.openModal("frmPatientDemographics.aspx", 1230, 1130, obj, "PatInsuredMaintanenceModalWindow");
    }, 0);



    }
    else {
        DisplayErrorMessage('420021');
    }
    return false;
}
function openAddinswindowForSelf() {
    HumanId = document.getElementById("hdnHumanID").value
    txtPatientlastname = document.getElementById("divPatientstrip").innerText.split('|')[0].split(',')[0].trim();//document.getElementById("txtPatientLastName").value
    txtPatientfirstname = document.getElementById("divPatientstrip").innerText.split('|')[0].split(',')[1].trim();//document.getElementById("txtPatientFirstName").value
    txtExternalAccNo = document.getElementById("divPatientstrip").innerText.split('|')[4].split(':')[1].trim();//document.getElementById("txtPatientExternalAccNo").value;
    txtPateintType = document.getElementById("divPatientstrip").innerText.split('|')[6].split(':')[1].trim();//document.getElementById("hdnInsuredHumanID").value

    setTimeout(
    function () {
        var oWnd = GetRadWindow();

        var childWindow = oWnd.BrowserWindow.radopen("frmAddInsurancePolicies.aspx?HumanId=" + HumanId + "&LastName=" + txtPatientlastname + "&FirstName=" + txtPatientfirstname + "&ExAccountNo=" + txtExternalAccNo + "&sSelf=Self" + "&PatientType=" + document.getElementById("divPatientstrip").innerText.split('|')[6].split(':')[1] + "EncounterId=" + document.getElementById("hdnEncounterID").value, "PatInsuredMaintanenceModalWindow");
        SetRadWindowProperties(childWindow, 850, 1140);
        childWindow.add_close(AddSelfClick);
        childWindow.remove_close(CloseAddInsWindow);
        childWindow.remove_close(ViewUpdatePolicyInformationClick);
    }, 0);

    return false;
}
function CloseWindow() {
    self.close();
}
function OpenEligibilityHistory() {
    HumanId = document.getElementById("hdnHumanID").value
    
    txtPatientlastname = document.getElementById("divPatientstrip").innerText.split('|')[0].split(',')[0].trim();//document.getElementById("txtPatientLastName").value
    txtPatientfirstname = document.getElementById("divPatientstrip").innerText.split('|')[0].split(',')[1].trim();//document.getElementById("txtPatientFirstName").value
    txtExternalAccNo = document.getElementById("divPatientstrip").innerText.split('|')[4].split(':')[1].trim();//document.getElementById("txtPatientExternalAccNo").value;
    txtAccNo = document.getElementById("divPatientstrip").innerText.split('|')[3].split(':')[1].trim();//document.getElementById("hdnInsuredHumanID").value
    txtPateintType = document.getElementById("divPatientstrip").innerText.split('|')[6].split(':')[1].trim();//document.getElementById("hdnInsuredHumanID").value
    txtPatientDOB = document.getElementById("divPatientstrip").innerText.split('|')[1].trim();
    txtPatientSex = document.getElementById("divPatientstrip").innerText.split('|')[2].trim()
    var index = parseInt(document.getElementById("hdnSelectedIndex").value) + 1;
    var grid = document.getElementById("grdPolicyInformation");
    var Row = grid.rows[index];
    if (Row) {
        insPlanId = Row.cells[15].innerHTML;
        var obj = new Array();
        obj.push("HumanId=" + HumanId);
        obj.push("InsuranceType=" + true);
        obj.push("LastName=" + txtPatientlastname);
        obj.push("FirstName=" + txtPatientfirstname);
        obj.push("ExAccountNo=" + txtExternalAccNo);
        obj.push("DOB=" + txtPatientDOB);
        obj.push("PatientSex=" + txtPatientSex);
        obj.push("InsPlanID=" + insPlanId);
        var result = openModal("frmViewEligibilityHistory.aspx", 480, 880, obj, "PatInsuredMaintanenceModalWindow");

    }
    else {
        DisplayErrorMessage('420021');
        return false;
    }
}

function IsPlanSelected() {
    var index = parseInt(document.getElementById("hdnSelectedIndex").value) + 1;
    if (isNaN(index)) {
        DisplayErrorMessage('420021');
        return false;
    }
    else {
        { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
        return true;
    }
}
function ClosePatInsuredMaintanence() {
    if (CloseWithWarning() == false) {
        return false;
    }
    else {
        var grdPolicyInformation = document.getElementById("grdPolicyInformation");
        var index = parseInt(document.getElementById("hdnSelectedIndex").value) + 1;
        var row = grdPolicyInformation.rows[index];
        var result = new Object();
        if (row != undefined) {
            result.PlanName = row.cells[2].innerHTML;
            result.PolicyHolderId = row.cells[5].innerHTML;
            result.id = row.cells[14].innerHTML;
            result.InsPlanID = row.cells[15].innerHTML;
            result.CarrierID = row.cells[16].innerHTML;
            result.PlanType = row.cells[17].innerHTML;
        }
        if (window.opener) {
            window.opener.returnValue = result;
        }
        window.returnValue = result;
        returnToParent(result);
    }
   
}
function CloseWithWarning() {
    var IsTrue = false;
    var grid = document.getElementById("grdPolicyInformation");
    var rowCount = grid.rows;
    for (var i = 0; i < rowCount.length; i++) {
        if ((grid.rows[i].cells[1].innerHTML == "&nbsp;" || grid.rows[i].cells[1].innerText == " ") && grid.rows[i].cells[4].innerText.toUpperCase() == "YES") {
            IsTrue = true;
            break;
        }
    }
    if (IsTrue == true) {
        DisplayErrorMessage('420039', '', grid.rows[i].cells[2].innerText);
        return false;
        returnToParent(null);
    }
    else {
        if (document.getElementById("hdnSelectedIndex").value != "") {
            var index = parseInt(document.getElementById("hdnSelectedIndex").value) + 1;
            var row = grid.rows[index];
            var result = new Object();
            if (row != undefined) {
                result.PlanName = row.cells[2].innerHTML;
                result.PolicyHolderId = row.cells[5].innerHTML;
                result.id = row.cells[14].innerHTML;
                result.InsPlanID = row.cells[15].innerHTML;
                result.CarrierID = row.cells[16].innerHTML;
                result.PlanType = row.cells[17].innerHTML;
            }
            returnToParent(result);
        }
        else {
            returnToParent(null);
        }
    }
    
}

function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow) oWindow = window.radWindow;
    else if (window.frameElement != null && window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
    return oWindow;
}


function returnToParent(args) {
    var oArg = new Object();
    oArg.result = args;
    var oWnd = GetRadWindow();
    if (oWnd != null) {
        if (oArg.result) {
            oWnd.close(oArg.result);
        }
        else {

            oWnd.close(oArg.result);
        }
    }
    else {
        self.close();
    }
}


function AddSelfClick(oWindow, args) {
    document.getElementById("btnAddInsSelfRefresh").click();

}
function CloseAddInsWindow(oWindow, args) {

    document.getElementById("btnAddInsSelfRefresh").click();

}
function ViewUpdatePolicyInformationClick(oWindow, args) {

    document.getElementById("btnUpdateInformationRefresh").click();
}

function SetRadWindowProperties(childWindow, height, width) {
    childWindow.SetModal(true);
    childWindow.set_visibleStatusbar(false);
    childWindow.setSize(width, height);
    childWindow.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close | Telerik.Web.UI.WindowBehaviors.Move);
    childWindow.set_iconUrl("Resources/16_16.ico");
    childWindow.set_keepInScreenBounds(true);
    childWindow.set_centerIfModal(true);
    childWindow.center();
}

function OpenPerformEV() {
    var obj = new Array();
    var obj = new Array();
    var index = parseInt(document.getElementById("hdnSelectedIndex").value) + 1;
    var grid = document.getElementById("grdPolicyInformation");
    var Row = grid.rows[index];
    if (Row) {
    InsPlanId = Row.cells[15].innerHTML;
    obj.push("InsPlanId=" + InsPlanId);
    obj.push("IsPatInsurance=" + "true");
    var result = openModalPerformEV("frmPerformEV.aspx", 620, 1200, obj, "PerformEVWindow");
    var WindowName = $find('PerformEVWindow');
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }

   }
   else {
       DisplayErrorMessage('420021');
       return false;
   }
}


