function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow)
        oWindow = window.radWindow;
    else if (window.frameElement.radWindow)
        oWindow = window.frameElement.radWindow;
    return oWindow;
}

function LoadingWindow() {
    var oWnd = GetRadWindow();
    if (oWnd != null && oWnd != undefined)
        oWnd.add_close(OnClientClose);
}

function btnSaveClicked() {
    var now = new Date();
    var then = now.getDay() + '-' + (now.getMonth() + 1) + '-' + now.getFullYear(); then += ' ' + now.getHours() + ':' + now.getMinutes() + ':' + now.getSeconds();
    var utc = (now.getUTCMonth() + 1) + '/' + now.getUTCDate() + '/' + now.getUTCFullYear(); utc += ' ' + now.getUTCHours() + ':' + now.getUTCMinutes() + ':' + now.getUTCSeconds();
    document.getElementById("hdnLocalTime").value = utc;
    document.getElementById("hdnClose").value = "FALSE";
    StartLoadingImage();
}

function Validate() {
    if (document.getElementById('cboPhysicianName').value.trim() != "") {
        document.getElementById("btnAdd").disabled = false;
        document.getElementById("hdnClose").value = "TRUE";
        return true;
    }
    else {
        DisplayErrorMessage('1007003');
        return false;
    }
}

function btnClose_Clicked(sender, args) {
    if (!document.getElementById("btnAdd").disabled) {
        if (document.getElementById("hdnMessageType").value == "") {
            DisplayErrorMessage('182224');
        }
        else if (document.getElementById("hdnMessageType").value == "Yes") {
            document.getElementById('btnAdd').click();
            document.getElementById('btnAdd').disabled = true;
            window.parent.parent.parent.parent.theForm.ctl00$IsSaveEnable.value = "false";
            DisplayErrorMessage('1007001');
            document.getElementById(GetClientId("hdnMessageType")).value = "";
            self.close();
        }
        else if (document.getElementById("hdnMessageType").value == "No") {
            document.getElementById("hdnMessageType").value = "";
            window.parent.parent.parent.parent.theForm.ctl00$IsSaveEnable.value = "false";
            GetRadWindow().close();
        }
        else if (document.getElementById("hdnMessageType").value == "Cancel") {
            document.getElementById("hdnMessageType").value = "";
            document.getElementById('btnAdd').disabled = false;
            return false;
        }
    }
    else {
        CloseWindows();
    }

}

function CloseWindows() {
    var oWnd = GetRadWindow();
    oWnd.close();
}

function OnClientClose(oWnd) {

    if (document.getElementById("hdnClose").value == "TRUE") {
        CheckSaveClose();
    }
}

function CDSLoad()
{
     {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
}