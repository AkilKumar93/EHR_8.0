
function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow) oWindow = window.radWindow;
    else if (window.frameElement != null && window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
    return oWindow;
}

function btnFindPatient_Clicked(sender, args) {
    var oBrowserWnd = GetRadWindow().BrowserWindow;
    var childWindow = oBrowserWnd.radopen("frmFindPatient.aspx", "MessageWindow");
    setTimeout(
        function () {
            childWindow.SetModal(true);
            childWindow.remove_close(OnClientCloseFindPatient);
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
    return false;
}
	function OnClientCloseFindPatient(oWindow, args) 
    {
       var arg = args.get_argument();
       if (arg)
       {
           var HumanId = arg.HumanId;
           var PatientName = arg.PatientName;
           var PatientDOB = arg.PatientDOB;
         if(HumanId!="0")    
         {
             document.getElementById("txtPatientID").value = HumanId;
             document.getElementById("txtPatientName").value = PatientName;
             document.getElementById("txtDOB").value = PatientDOB;
         }
       }
 
    }
function ClearAll()
   {
    	var IsClearAll=DisplayErrorMessage('600005');
	   if(IsClearAll==true)
	   {
        document.getElementById('InvisibleButton').click();
        return true;
       }
       else
       {
         return false;
       }
 }

 function btnClose_Clicked(sender, args) 
{
      var IsCancel;
      IsCancel = DisplayErrorMessage('131313');
      if (IsCancel == true) {
          self.close();
      }
      else {
          args._cancel = true;
      }
  }