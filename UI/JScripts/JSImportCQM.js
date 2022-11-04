function UploadImage_FileUploading(sender, args) {
    let filename = args.get_fileName();
    if (filename.endsWith(".zip") == false) {
        args.set_cancel(true);
    }

        if (window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable != null && window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable != undefined) {
            window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable.value = "true";


        }
    

    document.getElementById("btnImport").disabled = false;;
    
}

function UploadImage_FileUploadRemoved(sender, args) {
    if (window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable != null && window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable != undefined) {
        window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable.value = "false";
    }
}

function C2Import() {
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
    DisplayErrorMessage('1011193');
 
}

function C2ImportClose() {
    ToolStripAlertHidexml();
    DisplayErrorMessage('7050012');
    { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
}

