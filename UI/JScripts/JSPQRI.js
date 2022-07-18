
function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow)
        oWindow = window.radWindow;
    else if (window.frameElement && window.frameElement.radWindow)
        oWindow = window.frameElement.radWindow;
    return oWindow;
}

function btnCancel_Clicked() {
    var button2 = document.getElementById('btnSave');
    if (!(button2.disabled)) {
        if (document.getElementById(GetClientId("hdnMessageType")).value == "") {
            DisplayErrorMessage('9093040');
            return false;
        }
        else if (document.getElementById(GetClientId("hdnMessageType")).value == "Yes") {
        document.getElementById('btnSave').click();
            document.getElementById(GetClientId('btnSave')).disabled = false;
            return false;
        }
        else if (document.getElementById(GetClientId("hdnMessageType")).value == "No") {
            document.getElementById(GetClientId("hdnMessageType")).value = "";
            GetRadWindow().set_behaviors(Telerik.Web.UI.WindowAutoSizeBehaviors.Close);
            GetRadWindow().close();
        }
        else if (document.getElementById(GetClientId("hdnMessageType")).value == "Cancel") {
            document.getElementById(GetClientId("hdnMessageType")).value = "";
            return false;
        }
    }
    else {
        GetRadWindow().set_behaviors(Telerik.Web.UI.WindowAutoSizeBehaviors.Close);
        GetRadWindow().close();
    }
}

function chkTobaccoUseYes_Clicked() {
    var chkTobaccoUseYes = document.getElementById('chkTobaccoUseYes');
    var chkTobaccoUseNo = document.getElementById('chkTobaccoUseNo');
    var cboTobaccoUse = document.getElementById('cboTobaccoUse');


    if (chkTobaccoUseYes.checked == false && chkTobaccoUseNo.checked == false) {
        cboTobaccoUse.disabled = true;
    }
    else {
        cboTobaccoUse.disabled = false;
    }


    if (chkTobaccoUseNo.checked) {
        chkTobaccoUseYes.checked = true;
        chkTobaccoUseNo.checked = false;
    }

        enableButton();
}
function chkTobaccoUseNo_Clicked()
{
    var chkTobaccoUseYes = document.getElementById('chkTobaccoUseYes');
    var chkTobaccoUseNo = document.getElementById('chkTobaccoUseNo');
    var cboTobaccoUse = document.getElementById('cboTobaccoUse');

    if (chkTobaccoUseYes.checked == false && chkTobaccoUseNo.checked == false) {
        cboTobaccoUse.disabled = true;
    }
    else {
        cboTobaccoUse.disabled = false;
    }

    if (chkTobaccoUseYes.checked) {
        chkTobaccoUseYes.checked = false;
        chkTobaccoUseNo.checked = true;
    }

    enableButton();
}

function chkTobaccoCessation_Clicked() {
    var chkTobaccoCessation = document.getElementById('chkTobaccoCessation');
    if (chkTobaccoCessation.checked == true) {
        document.getElementById('cboTobaccoCessationComments').disabled = false;
        
    }
    else {
        document.getElementById('cboTobaccoCessationComments').disabled = true;
        document.getElementById('cboTobaccoCessationComments').selectedIndex = "0";
    }
    enableButton();
}

function chkSmokingHabitYes_Clicked() {
    var chkSmokingHabitYes = document.getElementById('chkSmokingHabitYes');
    var chkSmokingHabitNo = document.getElementById('chkSmokingHabitNo');
    var cboSmokingHabit = document.getElementById('cboSmokingHabit');
    if (chkSmokingHabitYes.checked == true) {
        cboSmokingHabit.disabled = false;
        chkSmokingHabitNo.checked = false;
    }
    else {

        cboSmokingHabit.disabled = true;
        cboSmokingHabit.selectedIndex = "0";
    }


    if (chkSmokingHabitNo.checked == false && chkSmokingHabitYes.checked ==false)  
    {
     cboSmokingHabit.disabled = true;
        cboSmokingHabit.selectedIndex = "0";

    }  
    enableButton();
}

function chkSmokingHabitNo_Clicked() {
    var chkSmokingHabitYes = document.getElementById('chkSmokingHabitYes');
    var chkSmokingHabitNo = document.getElementById('chkSmokingHabitNo');
    var cboSmokingHabit = document.getElementById('cboSmokingHabit');
    if (chkSmokingHabitNo.checked == true) {
        cboSmokingHabit.disabled = true;
        cboSmokingHabit.selectedIndex = "0";
        chkSmokingHabitYes.checked = false;
    }

    if (chkSmokingHabitNo.checked == false && chkSmokingHabitYes.checked == false)  
    {
     cboSmokingHabit.disabled = true;
        cboSmokingHabit.selectedIndex = "0";

    }  

    enableButton();
}

function chkSmokingCessation_Clicked() {
    var chkSmokingCessation = document.getElementById('chkSmokingCessation');
    if (chkSmokingCessation.checked == true) {
        document.getElementById('cboSmokingCessationComments').disabled = false;
        
    }
    else {
        document.getElementById('cboSmokingCessationComments').disabled = true;
        document.getElementById('cboSmokingCessationComments').selectedIndex = "0";
    }
    enableButton();
}

function chkBMIFollowUp_Clicked() {
    var chkBMIFollowUp = document.getElementById('chkBMIFollowUp');
    if (chkBMIFollowUp.checked == true) {
        document.getElementById('cboFollowUpComments').disabled = false;
       
    }
    else {
        document.getElementById('cboFollowUpComments').disabled = true;
        document.getElementById('cboFollowUpComments').selectedIndex = "0";
    }
    enableButton();
}

function enableButton() {
    
    document.getElementById('Client_saveCheckingFlag').value = "true";
    document.getElementById('btnSave').disabled = false;
}

function ClosePQRI() {
    var Own = GetRadWindow();
    Own.add_close(CloseICon);

}

function CloseICon() {

    var button2 = $find("btnSave");
    if (button2._enabled) {
        var IsClearAll = DisplayErrorMessage('110002');
        if (IsClearAll == true) {
            button2.click();
            self.close();
        }
        else {
            self.close();
        }

    }
    else {
        self.close();
    }

    return;
}



function btnsave_click() {
    document.getElementById('hdnCheckedChangeFlag').value = 'true';
    
}


function close() {

    GetRadWindow().set_behaviors(Telerik.Web.UI.WindowAutoSizeBehaviors.Close);
    GetRadWindow().close();
}
function OnPQRILoad() {
    $("span[mand=Yes]").addClass('MandLabelstyle');
    $("span[mand=Yes]").each(function () {
        $(this).html($(this).html().replace("*", "<span class='manredforstar'>*</span>"));
    });
}

function chkShowActiveloading() {
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
}