$(document).ready(function () {
    $('#btnCancel').click(function () {
        //alert('Test');
        var cntMail = "";

        if (document.getElementById("hdnInboxCnt") != null && document.getElementById("hdnInboxCnt") != undefined)
            cntMail = document.getElementById("hdnInboxCnt").value;
        if ($(top.window.document).find("#tsMailbox")[0] != null && $(top.window.document).find("#tsMailbox")[0] != undefined)
            $(top.window.document).find("#tsMailbox")[0].innerText = "MAIL : " + cntMail;
        if (sessionStorage.getItem("MailClinicalCnt") != null && sessionStorage.getItem("MailClinicalCnt") != undefined) {
            var val = sessionStorage.getItem("MailClinicalCnt").split(':')[0] + ":" + cntMail;
            sessionStorage.setItem("MailClinicalCnt", val);
        }

        if (document.getElementById(GetClientId("rdbtnCompose")).checked == true) {
            var iframe = document.getElementById("ifrmCompose");
            var contentWindow = iframe.contentWindow.$telerik.radControls;
            for (var count = (contentWindow.length - 1) ; count >= 0; count--) {
                if (contentWindow[count]._element.id == "btnSend") {
                    if (contentWindow[count].get_enabled() == true) {
                        if ((document.getElementById(GetClientId("hdnMessageType")).value == "") || (iframe.contentWindow.window.document.getElementById("hdnType").value == "")) {
                            document.getElementById("hdnToEnableSave").value = "Enabled";
                            iframe.contentWindow.window.document.getElementById("hdnType").value = "ToTrigger";
                            DisplayErrorMessage('295017');
                        }
                        else if (document.getElementById(GetClientId("hdnMessageType")).value == "Yes") {
                            iframe.contentWindow.window.document.getElementById("hdnType").value = "Yes";
                            contentWindow[count].click(true);
                            contentWindow[count].set_enabled(true);
                            document.getElementById("hdnToEnableSave").value = "NotEnabled";
                            return false;
                        }
                        else if (document.getElementById(GetClientId("hdnMessageType")).value == "No") {
                            document.getElementById(GetClientId("hdnMessageType")).value = "";
                            iframe.contentWindow.window.document.getElementById("hdnType").value = "";
                            document.getElementById("hdnToEnableSave").value = "NotEnabled";
                            close();
                        }
                        else if (document.getElementById(GetClientId("hdnMessageType")).value == "Cancel") {
                            document.getElementById(GetClientId("hdnMessageType")).value = "";
                            iframe.contentWindow.window.document.getElementById("hdnType").value = "";
                            document.getElementById("hdnToEnableSave").value = "NotEnabled";
                            contentWindow[count].set_enabled(true);
                            return false;
                        }
                    }
                    else {
                        close();
                    }
                }
            }
        }
        else {
            close();
        }
    });
});
function OnCommand(sender, args) {
    if (args.get_commandName() == "Download") {
        { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }


        setTimeout(function () {
            if (sessionStorage.getItem('StartLoading') == 'true') {
                if (jQuery(window.top.parent.parent.parent.parent.document.body).find('#resultLoading').attr('id') != 'resultLoading') {
                    jQuery(window.top.parent.parent.parent.parent.document.body).append('<div id="resultLoading" class="masterLoad" style="display:none"><div><img src="./Resources/loadimage.gif" style="opacity:0.7;height:30px;width:30px;"><div style="font-size:16px;padding-top:5px;padding-left:15px;">Loading...</div></div><div class="bg"></div></div>');
                }
                else {
                    jQuery(window.top.parent.parent.parent.parent.document.body).find('#resultLoading').remove();
                    jQuery(window.top.parent.parent.parent.parent.document.body).append('<div id="resultLoading" class="masterLoad" style="display:none"><div><img src="./Resources/loadimage.gif" style="opacity:0.7;height:30px;width:30px;"><div style="font-size:16px;padding-top:5px;padding-left:15px;">Loading...</div></div><div class="bg"></div></div>');
                }
                jQuery(window.top.parent.parent.parent.parent.parent.parent.document.body).find('#resultLoading').css({
                    'display': 'block',
                    'width': '100%',
                    'height': '100%',
                    'position': 'fixed',
                    'z-index': '10000000',
                    'top': '0',
                    'left': '0',
                    'right': '0',
                    'bottom': '0',
                    'margin': 'auto'
                });
                jQuery(window.top.parent.parent.parent.parent.parent.parent.document.body).find('#resultLoading .bg').css({
                    'background': '#ffffff',
                    'opacity': '0.7',
                    'width': '100%',
                    'height': '100%',
                    'position': 'absolute',
                    'top': '0'
                });
                jQuery(window.top.parent.parent.parent.parent.parent.parent.document.body).find('#resultLoading>div:first').css({
                    'width': '250px',
                    'height': '75px',
                    'text-align': 'center',
                    'position': 'fixed',
                    'top': '0',
                    'left': '0',
                    'right': '0',
                    'bottom': '0',
                    'margin': 'auto',
                    'font-size': '16px',
                    'z-index': '10',
                    'color': '#000000'
                });
                jQuery(window.top.parent.parent.parent.parent.parent.parent.document.body).find('#resultLoading .bg').height('100%');
                jQuery(window.top.parent.parent.parent.parent.parent.parent.document.body).find('#resultLoading').fadeIn(300);
                jQuery(window.top.parent.parent.parent.parent.document.body).css('cursor', 'wait');
            }
        }, 200);
        deleteCookie();

        var timeInterval = 500; // milliseconds (checks the cookie for every half second )

        var loop = setInterval(function () {
            if (IsCookieValid()) {
                jQuery(window.top.parent.parent.parent.parent.parent.parent.document.body).find('#resultLoading .bg').height('100%');
                jQuery(window.top.parent.parent.parent.parent.parent.parent.document.body).find('#resultLoading').fadeOut(300);
                jQuery(window.top.parent.parent.parent.parent.document.body).css('cursor', 'default');
                if (jQuery(window.top.parent.parent.parent.parent.parent.parent.document.body).find('#resultLoading').css('display') == 'block')
                    jQuery(window.top.parent.parent.parent.parent.parent.parent.document.body).find('#resultLoading').remove(); clearInterval(loop)



            }

        }, timeInterval);
    }
}
function Providerchange() {


    EnableSave();
    $find("txtSentTo").value = ""
    $find("txtSentTo").disable();
    $find("cboProvider").enable();
    $find("txtDirectAddress").disable();
    $find("txtSentTo").clear();
    $find("txtDirectAddress").clear();
    $find("cboProvider").clearSelection();
}
function DisableControls() {


    $find("txtSentTo").enable();
    $find("cboProvider").disable();
    $find("cboProvider").clearSelection();

    $find("txtDirectAddress").clear();

    $find("txtDirectAddress").disable();

    EnableSave();



}
function DownloadFile(e) {


    document.getElementById("hdnpath").value = e.attributes["path"].value;
    document.getElementById("btndownload").click();

}
function OnRowDblClick(sender, eventArgs) {
    var index = eventArgs._itemIndexHierarchical;
    var grid = $find('grdMailBox');
    var MasterTable = grid.get_masterTableView();
    var row = MasterTable.get_dataItems()[index];
    var cellFrom = MasterTable.getCellByColumnUniqueName(row, "From");
    var cellSubject = MasterTable.getCellByColumnUniqueName(row, "Subject");
    var cellDate = MasterTable.getCellByColumnUniqueName(row, "Date");
    var cellToAddress = MasterTable.getCellByColumnUniqueName(row, "ToAddress");
    var cellBody = MasterTable.getCellByColumnUniqueName(row, "Body");
    var cellDateTime = MasterTable.getCellByColumnUniqueName(row, "DateTime");
    var FileName = MasterTable.getCellByColumnUniqueName(row, "Filename");
    var txtMessage = "\r\n";
    txtMessage += "\r\n---------------------------------------------------------";

    if (document.getElementById('rdbtnSentitems').checked) {
        txtMessage += "\r\n" + "From :  " + cellToAddress.innerHTML;
        txtMessage += "\r\n" + "To :  " + cellFrom.innerHTML;
    }
    if (document.getElementById('rdbtnInbox').checked) {
        txtMessage += "\r\n" + "From :  " + cellFrom.innerHTML;
        txtMessage += "\r\n" + "To :  " + cellToAddress.innerHTML;
    }



    txtMessage += "\r\n" + "Message Date&Time :  " + cellDateTime.innerHTML;
    txtMessage += "\r\n" + "Subject :  " + cellSubject.innerHTML.replace("&nbsp;", "\r\n");
    txtMessage += "\r\n" + "Body :  " + cellBody.innerHTML.replace("&nbsp;", "\r\n");

    var PatientID = document.getElementById('hdnPatientID').value;
    var EmailID = document.getElementById('hdnEmailID').value;
    var EncounterID = document.getElementById('hdnEncounterID').value;
    var Role = document.getElementById("hdnRole").value;
    var pateintporatal = document.getElementById("hdnIsPatientPortal").value;
    var code = window.btoa(unescape(encodeURIComponent(txtMessage)));

    var obj = new Array();
    obj.push("PatientID=" + PatientID);
    obj.push("EmailID=" + EmailID);
    obj.push("EncounterID=" + EncounterID);
    obj.push("BodyMessage=" + code);
    obj.push("Role=" + Role)
    obj.push("IS_Patient_Portal=" + pateintporatal);
    obj.push("FileName=" + FileName.innerHTML);
    setTimeout(function () { GetRadWindow().BrowserWindow.openModal("frmMailMessage.aspx", 700, 650, obj, "MessageWindow"); }, 0);

}
function enableprovider() {

   
    $find("rdbtnProvider").enable();
 
}
function cmboproviderchange() {
    if (document.getElementById("cboProvider").value == "Others") {

        $find("txtDirectAddress").enable();

        $find("txtDirectAddress").focus();
        document.getElementById("txtDirectAddress").value = "";
    }
    else {
        $find("txtDirectAddress").disable();
        
        document.getElementById("txtDirectAddress").value = "";

    }
    EnableSave();
}
function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow) oWindow = window.radWindow;
    else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
    return oWindow;
}
function Reply() {
    var PatientID = document.getElementById('hdnPatientID').value;
    var EmailID = document.getElementById('hdnEmailID').value;
    var EncounterID = document.getElementById('hdnEncounterID').value;
    var Role = document.getElementById("hdnRole").value;
    var pateintporatal = document.getElementById("hdnIsPatientPortal").value;
    var obj = new Array();
    obj.push("ScreenMode=" + "ReplyMessage");
    obj.push("PatientID=" + PatientID);
    obj.push("LoginEmailID=" + EmailID);
    obj.push("Encounter_ID=" + EncounterID);
    obj.push("Role=" + Role);
    obj.push("IS_Patient_Portal=" + pateintporatal);
    setTimeout(function () { GetRadWindow().BrowserWindow.openModal("frmSendHealthRecord.aspx", 460, 750, obj, "MessageWindow"); }, 0);
}
function Forward() {

    var PatientID = document.getElementById('hdnPatientID').value;
    var EmailID = document.getElementById('hdnEmailID').value;
    var EncounterID = document.getElementById('hdnEncounterID').value;
    var Role = document.getElementById("hdnRole").value;
    var pateintporatal = document.getElementById("hdnIsPatientPortal").value;
    var obj = new Array();
    obj.push("ScreenMode=" + "ForwardMessage");
    obj.push("PatientID=" + PatientID);
    obj.push("LoginEmailID=" + EmailID)
    obj.push("Encounter_ID=" + EncounterID);
    obj.push("Role=" + Role)
    obj.push("IS_Patient_Portal=" + pateintporatal);
    obj.push("Attachment=" + document.getElementById("hdnmailPath").value)
    setTimeout(function () { GetRadWindow().BrowserWindow.openModal("frmSendHealthRecord.aspx", 460, 607, obj, "MessageWindow"); }, 0);
}

function btnCancel_Clicked() {
    //BugID:48547
    var cntMail = "";

    if (document.getElementById("hdnInboxCnt") != null && document.getElementById("hdnInboxCnt") != undefined)
        cntMail = document.getElementById("hdnInboxCnt").value;
    if ($(top.window.document).find("#tsMailbox")[0] != null && $(top.window.document).find("#tsMailbox")[0] != undefined)
        $(top.window.document).find("#tsMailbox")[0].innerText = "MAIL : " + cntMail;
    if (sessionStorage.getItem("MailClinicalCnt") != null && sessionStorage.getItem("MailClinicalCnt") != undefined) {
        var val = sessionStorage.getItem("MailClinicalCnt").split(':')[0] + ":" + cntMail;
        sessionStorage.setItem("MailClinicalCnt", val);
    }

    if (document.getElementById(GetClientId("rdbtnCompose")).checked == true) {
        var iframe = document.getElementById("ifrmCompose");
        var contentWindow = iframe.contentWindow.$telerik.radControls;
        for (var count = (contentWindow.length - 1) ; count >= 0; count--) {
            if (contentWindow[count]._element.id == "btnSend") {
                if (contentWindow[count].get_enabled() == true) {
                    if ((document.getElementById(GetClientId("hdnMessageType")).value == "") || (iframe.contentWindow.window.document.getElementById("hdnType").value == "")) {
                        document.getElementById("hdnToEnableSave").value = "Enabled";
                        iframe.contentWindow.window.document.getElementById("hdnType").value = "ToTrigger";
                        DisplayErrorMessage('295017');
                    }
                    else if (document.getElementById(GetClientId("hdnMessageType")).value == "Yes") {
                        iframe.contentWindow.window.document.getElementById("hdnType").value = "Yes";
                        contentWindow[count].click(true);
                        contentWindow[count].set_enabled(true);
                        document.getElementById("hdnToEnableSave").value = "NotEnabled";
                        return false;
                    }
                    else if (document.getElementById(GetClientId("hdnMessageType")).value == "No") {
                        document.getElementById(GetClientId("hdnMessageType")).value = "";
                        iframe.contentWindow.window.document.getElementById("hdnType").value = "";
                        document.getElementById("hdnToEnableSave").value = "NotEnabled";
                        close();
                    }
                    else if (document.getElementById(GetClientId("hdnMessageType")).value == "Cancel") {
                        document.getElementById(GetClientId("hdnMessageType")).value = "";
                        iframe.contentWindow.window.document.getElementById("hdnType").value = "";
                        document.getElementById("hdnToEnableSave").value = "NotEnabled";
                        contentWindow[count].set_enabled(true);
                        return false;
                    }
                }
                else {
                    close();
                }
            }
        }
    }
    else {
        close();
    }

}
function Message() {
    { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
}

function close() {
    var oWindow = null;
    if (window.radWindow)
        oWindow = window.radWindow;
    else if (window.frameElement.radWindow)
        oWindow = window.frameElement.radWindow;
    if ((oWindow != null) || (oWindow != undefined))
        oWindow.close();
    else {
        window.parent.close();
    }
}
function OnSendCancel() {
    if ($find("btnSend").get_enabled() == true) {
        if (document.getElementById(GetClientId("hdnMessageType")).value == "") {
            DisplayErrorMessage('9093040');
            return false;
        }
        else if (document.getElementById(GetClientId("hdnMessageType")).value == "Yes") {
            $find("btnSend").click(true);
            $find("btnSend").set_enabled(true);
            return false;
        }
        else if (document.getElementById(GetClientId("hdnMessageType")).value == "No") {
            document.getElementById(GetClientId("hdnMessageType")).value = "";
            self.close();
        }
        else if (document.getElementById(GetClientId("hdnMessageType")).value == "Cancel") {
            document.getElementById(GetClientId("hdnMessageType")).value = "";
            return false;
        }
    }
    else {
        self.close();
    }
}


function onsendclicked() {
    if ($find("btnSend").get_enabled() == true) {
        { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
    }
    else
        return false;
}
function closeForSend() {
    self.close();
}


