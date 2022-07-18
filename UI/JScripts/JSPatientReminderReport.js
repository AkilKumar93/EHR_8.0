function OpenMedicationManagar(sender, args) {
    sender.set_autoPostBack(false);
    var obj = new Array();
    obj.push("SearchType=Rule");
    var result = openModal("frmMedicationManager.aspx", 635, 630, obj, "MessageWindow");
    $find('MessageWindow').add_close(OnClientCloseMedication);

}

function OnClientCloseMedication(oWindow, args) {
    var arg = args.get_argument();
    if (arg) {
        var Rule = arg.Rule;
        if (Rule != '') {
            document.getElementById('hdnRule').value = Rule;
            document.getElementById('btnRule').click();

        }
    }
}
function OpenPDF() {
    var obj = new Array();
    obj.push("SI=" + document.getElementById('SelectedItem').value);
    obj.push("Location=" + "DYNAMIC");
    setTimeout(function() {
        GetRadWindow().BrowserWindow.openModal('frmPrintPDF.aspx', 835, 900, obj, "MessageWindow");
    }, 0);
}

function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow) oWindow = window.radWindow;
    else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
    return oWindow;
}

function ShowLoading() {
    document.getElementById("divLoading").style.display = "block";
}

function Close() {
    GetRadWindow().close();
}

function SendMsg(to_add, sub, mail, lstHuman, CheckCount, Ismessage) {
    if (Ismessage.toUpperCase() == "TRUE") {
        var oWnd = GetRadWindow();
        var childWindow = oWnd.BrowserWindow.radopen("frmSendHealthRecord.aspx?Scn_Name=Reminder&To=" + to_add + "&sub=" + sub + "&lstHuman=" + lstHuman + "&RuleID=" + document.getElementById("hdnRuleID").value, "RadWindowSendMail");
        SetRadWindowProperties(childWindow, 400, 600);
        return false;
    } else if ((CheckCount != "0" && CheckCount != "1") && to_add != "") {
        DisplayErrorMessage('7420007');
        var oWnd = GetRadWindow();
        var childWindow = oWnd.BrowserWindow.radopen("frmSendHealthRecord.aspx?Scn_Name=Reminder&To=" + to_add + "&sub=" + sub + "&lstHuman=" + lstHuman + "&RuleID=" + document.getElementById("hdnRuleID").value, "RadWindowSendMail");
        SetRadWindowProperties(childWindow, 400, 600);
        return false;
    }
    if (to_add == "") {
        DisplayErrorMessage('7420007');
        return false;
    }
    return false;
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
function getDropdownListSelectedText() {
    var DropdownList = document.getElementById("cboRule");
    var value = DropdownList.value;
    document.getElementById("hdnRule").value = value;
}
 
function onloadpatientremainder() {
    $("span[mand=Yes]").addClass('MandLabelstyle');
    $("span[mand=Yes]").each(function () {
        $(this).html($(this).html().replace("*", "<span class='manredforstar'>*</span>"));
    });
    $("[id*=pbDropdown]").addClass('pbDropdownBackground');
}