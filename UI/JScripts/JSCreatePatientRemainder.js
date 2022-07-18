function DxClicked() {
    document.getElementById("typeButtton").value = "DX";

    setTimeout(
        function() {
            var oWnd = GetRadWindow();
            var childWindow = oWnd.BrowserWindow.radopen("frmSpecialityDiagnosis.aspx?sourceScreen=PATIENT REMINDER", "RadWindow1");
            childWindow.SetModal(true);
            childWindow.set_visibleStatusbar(false);
            childWindow.setSize(632, 632);
            childWindow.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close | Telerik.Web.UI.WindowBehaviors.Move);
            childWindow.set_iconUrl("Resources/16_16.ico");
            childWindow.set_keepInScreenBounds(true);
            childWindow.set_centerIfModal(true);
            childWindow.center();
            childWindow.add_close(OnOpendPatientChartClick);
        }, 0);
}

function RxClicked() {
    document.getElementById("typeButtton").value = "RX";

    setTimeout(
        function() {
            var oWnd = GetRadWindow();
            var childWindow = oWnd.BrowserWindow.radopen("frmMedicationManager.aspx?SearchType=Medication", "ctl00_CreatePatientModalWindow");
            childWindow.SetModal(true);
            childWindow.set_visibleStatusbar(false);
            childWindow.setSize(632, 632);
            childWindow.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close | Telerik.Web.UI.WindowBehaviors.Move);
            childWindow.set_iconUrl("Resources/16_16.ico");
            childWindow.set_keepInScreenBounds(true);
            childWindow.set_centerIfModal(true);
            childWindow.center();
            childWindow.add_close(OnOpendPatientChartClick);
        }, 0);

    return false;
}

function RAndXClicked() {
    document.getElementById("typeButtton").value = "R&X";

    setTimeout(
        function() {
            var oWnd = GetRadWindow();
            var childWindow = oWnd.BrowserWindow.radopen("frmMedicationManager.aspx?SearchType=Medication_Aler", "ctl00_CreatePatientModalWindow");
            childWindow.SetModal(true);
            childWindow.set_visibleStatusbar(false);
            childWindow.setSize(632, 632);
            childWindow.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close | Telerik.Web.UI.WindowBehaviors.Move);
            childWindow.set_iconUrl("Resources/16_16.ico");
            childWindow.set_keepInScreenBounds(true);
            childWindow.set_centerIfModal(true);
            childWindow.center();
            childWindow.add_close(OnOpendPatientChartClick);
        }, 0);

    return false;
}

function LabResultClicked() {
    document.getElementById("typeButtton").value = "LabResult";

    setTimeout(
        function() {
            var oWnd = GetRadWindow();
            var childWindow = oWnd.BrowserWindow.radopen("frmMedicationManager.aspx?SearchType=LabResult", "ctl00_CreatePatientModalWindow");
            childWindow.SetModal(true);
            childWindow.set_visibleStatusbar(false);
            childWindow.setSize(632, 632);
            childWindow.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close | Telerik.Web.UI.WindowBehaviors.Move);
            childWindow.set_iconUrl("Resources/16_16.ico");
            childWindow.set_keepInScreenBounds(true);
            childWindow.set_centerIfModal(true);
            childWindow.center();
            childWindow.add_close(OnOpendPatientChartClick);
        }, 0);

    return false;

}

function concatLabResult(text) {
    var txtBox = '';
    var temp = text.split('+');
    for (var i = 0; i < temp.length; i++) {
        if (temp[i] != '') {
            var temp1 = temp[i].split('|');


            txtBox += temp1[1] + ";";
        }

    }

    return txtBox;
}

function ConcateTextValue(text) {
    var txtBox = '';
    var temp = text.split(';');
    for (var i = 0; i < temp.length; i++) {
        if (temp[i] != '') {
            var temp1 = temp[i].split('+');


            txtBox += temp1[1] + ";";
        }

    }

    return txtBox;
}

function OnOpendPatientChartClick(oWindow, args) {
    var arg = args.get_argument();

    if (arg || window.parent.theForm.ctl00$HiddenForCross.value != "") {
        window.parent.parent.parent.parent.theForm.ctl00$IsSaveEnable.value = "true";
        if (document.getElementById("typeButtton").value == "DX") {
            if (window.parent.theForm.ctl00$HiddenForCross.value != "")
                $find("txtProblem").set_value(window.parent.theForm.ctl00$HiddenForCross.value);
            else if (arg)
                $find("txtProblem").set_value(arg.medList);

            document.getElementById("txtProblemTag").value = "";
            document.getElementById("btnAdd").disabled = false
        }
        if (document.getElementById("typeButtton").value == "RX") {
            var retu = "";
            var txtBox = "";
            $find("txtMedication").set_value("");
            txtBox = ConcateTextValue(document.getElementById("txtMedicationTag").value);
            document.getElementById("txtMedicationTag").value = arg.medList;
            retu = ConcateTextValue(arg.medList);

            if (retu != txtBox)
                txtBox += retu;

            $find("txtMedication").set_value(txtBox);
        }

        if (document.getElementById("typeButtton").value == "R&X") {
            var retu = "";
            var txtBox = "";
            $find("txtMedicationAllergy").set_value("");

            txtBox = ConcateTextValue(document.getElementById("txtMedicationAllergyTag").value);
            document.getElementById("txtMedicationAllergyTag").value = arg.medList;
            retu = ConcateTextValue(arg.medList);
            if (retu != txtBox)
                txtBox += retu;

            $find("txtMedicationAllergy").set_value(txtBox);

        }

        if (document.getElementById("typeButtton").value == "LabResult") {
            var txtBox = concatLabResult(document.getElementById("txtLabTestResultTag").value);
            document.getElementById("txtLabTestResultTag").value = arg.LabResult;

            var retu = concatLabResult(arg.LabResult);
            if (retu != txtBox)
                txtBox += retu;


            $find("txtLabTestResult").set_value(txtBox);
            document.getElementById('PnlValue').disabled = false;
            $find('cboRange').set_enabled(true);
            document.getElementById('txtValueFrom').disabled = false;
        }
        document.getElementById('btnAdd').disabled = false;
    }
    window.parent.theForm.ctl00$HiddenForCross.value = "";
}

function DeleteGrid() {
    var delete_row = DisplayErrorMessage('280004');
    if (delete_row == true) {
        document.getElementById("btnInvisible").click();
    } else {
        args._cancel = true;
    }
}

function setRadWindowProperties(childWindow, height, width) {
    childWindow.SetModal(true);
    childWindow.set_visibleStatusbar(false);
    childWindow.setSize(width, height);
    childWindow.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close | Telerik.Web.UI.WindowBehaviors.Move);
    childWindow.set_iconUrl("Resources/16_16.ico");
    childWindow.set_keepInScreenBounds(true);
    childWindow.set_centerIfModal(true);
    childWindow.center();
}

function btnClearAll_Clicked(sender, args) {

    var btnClear = document.getElementById("btnClearAll");

    var IsClearAll;
    if (btnClear.value == "Clear All")
        IsClearAll = DisplayErrorMessage('200005');
    else
        IsClearAll = DisplayErrorMessage('290020');
    if (IsClearAll == true) {
        $find("cboRange").clearSelection();
        $find("cboAgeRange").clearSelection();
        $find("cboGender").clearSelection();
        $find("cboRace").clearSelection();
        $find("cboEthnicity").clearSelection();
        $find("cboStatus").clearSelection();
        $find("cboCommunication").clearSelection();
        $find("txtRuleName").clear();
        document.getElementById("txtRuleName").value = "";
        $find("txtDescription").clear();
        $find("txtProblem").clear();
        $find("txtMedication").clear();
        $find("txtMedicationAllergy").clear();
        $find("txtLabTestResult").clear();
        $find("txtValueFrom").clear();
        $find("txtAgeFrom").clear();
        $find("txtAgeTo").clear();
        if ($find("txtAlertDay") != null) {
            $find("txtAlertDay").clear();
            $find("txtFrequency").clear();
        }
        document.getElementById("txtExpectedResult_txtDLC").value = "";
        if (btnClear.value != "Clear All") {
            document.getElementById("btnAdd").disabled = true;
            window.parent.parent.parent.parent.theForm.ctl00$IsSaveEnable.value = "false";
        }


        document.getElementById("btnAdd").value = "Add";
        btnClear.value = "Clear All";
    }
}

function txtLabTestResultClear() {
    $find("txtLabTestResult").clear();
}

function txtMedicationAllergyClear() {
    $find("txtMedicationAllergy").clear();
}

function txtMedicationClear() {
    $find("txtMedication").clear();
}

function txtProblemClear() {

    $find("txtProblem").clear();
}


function cboRange_SelectedIndexChanged(sender, args) {
    window.parent.parent.parent.parent.theForm.ctl00$IsSaveEnable.value = "true";
    document.getElementById("btnAdd").disabled = false;
}


function cboGender_SelectedIndexChanged(sender, args) {
    window.parent.parent.parent.parent.theForm.ctl00$IsSaveEnable.value = "true";
    document.getElementById("btnAdd").disabled = false;
}

function cboCommunication_SelectedIndexChanged(sender, args) {
    window.parent.parent.parent.parent.theForm.ctl00$IsSaveEnable.value = "true";
    document.getElementById("btnAdd").disabled = false;
}

function cboRace_SelectedIndexChanged(sender, args) {
    window.parent.parent.parent.parent.theForm.ctl00$IsSaveEnable.value = "true";
        document.getElementById("btnAdd").disabled = false;
}

function cboEthnicity_SelectedIndexChanged(sender, args) {
    window.parent.parent.parent.parent.theForm.ctl00$IsSaveEnable.value = "true";
    document.getElementById("btnAdd").disabled = false;
}

function cboStatus_SelectedIndexChanged(sender, args) {
    window.parent.parent.parent.parent.theForm.ctl00$IsSaveEnable.value = "true";
    document.getElementById("btnAdd").disabled = false;
}

function cboAgeRange_SelectedIndexChanged(sender, args) {
    window.parent.parent.parent.parent.theForm.ctl00$IsSaveEnable.value = "true";
    document.getElementById("btnAdd").disabled = false;
}

function btnClose_Clicked(sender, args) {
        if (document.getElementById("btnAdd").disabled == false) {
            if (document.getElementById("hdnMessageType").value == "") {
                DisplayErrorMessage('182224');
            } else if (document.getElementById("hdnMessageType").value == "Yes") {
                document.getElementById('btnAdd').click();
                document.getElementById('btnAdd').disabled = true;
                window.parent.parent.parent.parent.theForm.ctl00$IsSaveEnable.value = "false";
                DisplayErrorMessage('7410002');
                document.getElementById(GetClientId("hdnMessageType")).value = "";
                self.close();
            } else if (document.getElementById("hdnMessageType").value == "No") {
                document.getElementById("hdnMessageType").value = ""
                window.parent.parent.parent.parent.theForm.ctl00$IsSaveEnable.value = "false";
                GetRadWindow().close();
            } else if (document.getElementById("hdnMessageType").value == "Cancel") {
                document.getElementById("hdnMessageType").value = ""
                args.set_cancel(true);
            }
        } else {
            GetRadWindow().close();
        }

    }
function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow)
        oWindow = window.radWindow;
    else if (window.frameElement.radWindow)
        oWindow = window.frameElement.radWindow;
    return oWindow;
}

function KeyPress() {
    window.parent.parent.parent.parent.theForm.ctl00$IsSaveEnable.value = "true";
    document.getElementById("btnAdd").disabled = false;
}

function formClosed() {
    var oWnd = GetRadWindow();
    oWnd.close();
}

function CloseReport() {
    var Own = GetRadWindow();
    Own.add_close(CloseCrossReport);
}

function CloseCrossReport() {
    try {

        var button2 = document.getElementById("btnAdd");

        if (!button2.disabled) {
            var IsClearAll = DisplayErrorMessage('110002');
            if (IsClearAll == true) {
                button2.click();
                self.close();
            } else {
                self.close();
            }

        } else {
            self.close();
        }
        return;
    } catch (e) {}
}

function AutoSaveButtonStatus(isEnable) {
    window.parent.parent.parent.parent.theForm.ctl00$IsSaveEnable.value = isEnable;
}

function onloadcreatepatient() {
    $("span[mand=Yes]").addClass('MandLabelstyle');
    $("span[mand=Yes]").each(function () {
        $(this).html($(this).html().replace("*", "<span class='manredforstar'>*</span>"));
    });
    $("[id*=pbDropdown]").addClass('pbDropdownBackground');
}