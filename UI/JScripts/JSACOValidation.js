function SetPatientAcceptEnableDisable() {

}
function SetDirtyFlag()
{
    var ObjIsDirty = document.getElementById("hdnIsDirty");
    ObjIsDirty.value=true;
}
     function GetRadWindow() 
    {
        var oWindow = null;
        if (window.radWindow) oWindow = window.radWindow;
        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
        return oWindow;
    }
    
    
    function returnToParent(args)
     {
            var oArg = new Object();
            oArg.result = args;
            var oWnd = GetRadWindow();
            if (oArg.result)
            {
                 oWnd.close(oArg.result);
            }
            else 
            {
                oWnd.close(oArg.result);
            }
     }
     function MoveToValidation()
     {
        var chkPFSHVerifiedObj=document.getElementById("chkPFSHVerified");
        if(chkPFSHVerifiedObj!=null && chkPFSHVerifiedObj.checked==false)
        {
         alert("You have to verify PFSH before continuing.");
         return false;
        }
        return true;
    }
    function ReAdjustWindowSize() {
        var win = GetRadWindow();
        win.SetSize(530, 125);
        win.SetTitle('PFSH Verification');
        window.document.title = 'PFSH Verification';
    }

    function checkAutoSave()
    {
        var checkAutoSave = localStorage.getItem('AvutoSaveCheck');

        if (checkAutoSave == "true") {
            localStorage.removeItem('AvutoSaveCheck');
        }
        

    }