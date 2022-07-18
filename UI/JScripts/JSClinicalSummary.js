function OpenPDF() {
    var obj = new Array();
    obj.push("SI=" + document.getElementById('hdnPrintFilePath').value);
    obj.push("Location=" + "DYNAMIC");
    document.getElementById("btnDownloadXML").click();

    var filelocation = document.getElementById('hdnXmlPath').value; // To open the generated XML in Human readable format
    window.open(filelocation, "CDA Human Readable", "", "")
     {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
}


function OpenAltovaPDF() {
    var obj = new Array();
    obj.push("SI=" + document.getElementById('hdnPrintFilePath').value);
    obj.push("Location=" + "DYNAMIC");
    document.getElementById("btnDownloadXML").click();

    var filelocation = document.getElementById('hdnXmlPath').value; // To open the generated XML in Human readable format
    window.open(filelocation, "CDA Human Readable", "", "")
    ToolStripAlertHidexml();
    { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
}

function OpenErrorAltova() {
    ToolStripAlertHidexml();
    { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
}

function OpenWarningAltova() {
    ToolStripAlertHidexml();
    { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
    DisplayErrorMessage('1011192');
}
function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow) oWindow = window.radWindow;
    else if (window.frameElement != null && window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
    return oWindow;
}
function Select() {
    var Control = document.getElementById("pnlEncounterDetails").getElementsByTagName("input");
    for (var i = 0; i < Control.length; i++) {
        if (document.getElementById("chkCheckAll").checked == true) {
            if (Control[i].type == "checkbox") {
                Control[i].checked = true
            }
        }
        else {
            if (Control[i].type == "checkbox") {
                Control[i].checked = false;
            }
        }
    }
}

function ClearAll() {
    var Control = document.getElementById("pnlEncounterDetails").getElementsByTagName("input");
    for (var i = 0; i < Control.length; i++) {
        if (Control[i].type == "checkbox") {
            Control[i].checked = false;
        }
    }
    document.getElementById("chkCheckAll").checked = false;
    return false;
}
function ShowSuccess(value) {
    alert("Sent To" + value);
}
function ShowFailure(value) {
    alert("Sending Failed To" + value);
}

function btnSendSummary_Clicked(sender, args) {
    var Email = $("#DLCRecAdd_txtDLC")[0].value;
    if (Email != '') {
        if (!IsEmail(Email))
        {
            DisplayErrorMessage('420030');
            document.getElementById('DLCRecAdd_txtDLC').focus();
            sender.set_autoPostBack(false);
            return;
        }
        else
        {
            sender.set_autoPostBack(true);
        }
    }
    else
    {
        DisplayErrorMessage('390018');
        document.getElementById('DLCRecAdd_txtDLC').focus();
        sender.set_autoPostBack(false);
        return;
    }
}

function IsEmail(Email) {
    var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    return expr.test(Email);
}

function GenerateXML()
{   { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
}

function GenerateXMLAltova() {
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
    DisplayErrorMessage('1011191');
}

function StopLoad()
{
     {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
}

function SendCerner() {
    if (document.getElementById('hdnXmlPath').value == "") {
        DisplayErrorMessage('1007015');
    }
    
}