function OpenfindPatient(sender, args) {
    var oBrowserWnd = GetRadWindow().BrowserWindow;
    var childWindow = oBrowserWnd.radopen("frmFindPatient.aspx", "ModalWindow");
    setTimeout(
        function () {

            childWindow.SetModal(true);
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

    sender.set_autoPostBack(false);
}
function OnClientCloseFindPatient(oWindow, args) {
    var arg = args.get_argument();
    if (arg) {
        var HumanId = arg.HumanId;
        document.getElementById(GetClientId('hdnAccountNo')).value = HumanId;
        document.getElementById('txtPatientname').value = HumanId;
    }

}

function btnClose_Click() {
    self.close();
    return;
}

function OpenPDF()                                      // To Open the Generated Multiple XML files in Human Readable Format
{
    var filelist = document.getElementById('hdnFileList').value;
    var files = filelist.toString().split("~");
    for (var i = 0; i < files.length; i++) {
        var file = files[i];
        window.open(file);
    }

}

function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow) oWindow = window.radWindow;
    else if (window.frameElement != null && window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
    return oWindow;
}

function ShowSuccess(value) {
    alert("Sent To" + value);
}
function ShowFailure(value) {
    alert("Sending Failed To" + value);
}
function btnGenerate_ClientClick(sender, args) {
    var from_date = document.getElementById('dtpFromDate');
    var to_date = document.getElementById('dtpToDate');
    if(from_date.control.get_selectedDate() > to_date.control.get_selectedDate())
    {
        DisplayErrorMessage('110029');
        args.set_cancel(true);
        return;
    }
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
}

function Downloadfile() {
     {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
    document.getElementById("Invisiblebuttons").click();
}

function downloadURI(uri) {
     {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
    var link = document.createElement('a'); link.download = "CCD"; link.href = uri; link.click();
}

function btnSubmit_ClientClick(sender, args) {
    self.close();
    return;
}
var validFilesTypes = ["exe"];
function ValidationbulkFile() {   
   
    var file = $('#fileupload');
    var path = file.val();
    var ext = path.substring(path.lastIndexOf(".") + 1, path.length).toLowerCase();
    var isValidFile = false;

    for (var i=0; i<validFilesTypes.length; i++)
    {
        if (ext==validFilesTypes[i])
        {
            isValidFile=true;
            break;
        }
    }

    if (!isValidFile)
    {
        $("#btnUpload").click();
        
    }
    else {
        $('#filerror').val("");
    }
    return true;
}
function ScheduleLoad() {   
    { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
    DisplayErrorMessage('1007016');
}
