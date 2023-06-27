   var EnableAutoSave;
   function btnClose_Clicked(sender, args) 
    {
	    if(EnableAutoSave==true)
	    {
	        CellSelectedforClose("");
	        { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }//BugID:53790
	    }
	    else
	    {
	        GetRadWindow().close();
	        { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }//BugID:53790
	        top.window.setTimeout(function () {
	            window.top.location.href = "frmMyQueueNew.aspx";
	        }, 5000);
	    }

   }
   function wellnessnote() {
       { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
       $(top.window.document).find('#ProcessiFrameNotes')[0].contentDocument.location.href = "frmWellnessNotes.aspx?SubMenuName=WELLNESS NOTES" + "&Menu=True";
       $(top.window.document).find("#ModalTtleNotes")[0].textContent = "Wellness Notes";
       var DateTime = new Date();
       var strYear = DateTime.getFullYear();
       var strMonth = DateTime.getMonth() + 1;
       var strDay = DateTime.getDate();
       var strHours = DateTime.getHours();
       var strMinutes = DateTime.getMinutes();
       var strSeconds = DateTime.getSeconds();
       if (strMonth.toString().length == 1)
           strMonth = "0" + strMonth;
       if (strDay.toString().length == 1)
           strDay = "0" + strDay;
       if (strMinutes.toString().length == 1)
           strMinutes = "0" + strMinutes;
       var testStieng = strHours.toString() + ":" + strMinutes.toString() + ":" + strSeconds.toString();
       var timeString = testStieng.toString();
       var H = +timeString.substr(0, 2);
       var h = H % 12 || 12;
       var ampm = H < 12 ? "AM" : "PM";
       if (h.toString().length == 1)
           h = "0" + h;
       timeString = h + timeString.substr(2, 6) + ampm;
       document.getElementById(GetClientId("hdnLocalTime")).value = strYear + "" + strMonth + "" + strDay + " " + timeString.replace(":", "").replace(":", "");
      
       var obj = new Array();
       obj.push("Date=" + document.getElementById(GetClientId("hdnLocalTime")).value);//document.getElementById(GetClientId("hdnLocalTime")).value

       StopLoadingImage();
   }
	function OpenAddUpdateKeywords(FieldName)
   {
       var obj=new Array(); 
       obj.push("FieldName="+FieldName);
       var result=openModal("frmAddorUpdateKeywords.aspx",550,655,obj,'MessageWindow');
       var currWindow=$find('MessageWindow');
       currWindow.set_behaviors(-Telerik.Web.UI.WindowAutoSizeBehaviors.Close);
       return false;   
    }
	function OpenPDF(FaxSubject)
    {
        var obj=new Array();
        obj.push("SI=" + document.getElementById('hdnSelectedItem').value);
        
        obj.push("Location=" + "DYNAMIC");
        obj.push("FaxSubject=" + FaxSubject);
        setTimeout(function () { GetRadWindow().BrowserWindow.openModal('frmPrintPDF.aspx', 800, 1000, obj); }, 0);
    }
    function OpenPDFStatic(fileNotFound, screen,DownloadDoc)
    {
        if (document.getElementById('hdnSelectedItem').value!="")
        {
            var obj=new Array();
            obj.push("SI="+document.getElementById('hdnSelectedItem').value);
            obj.push("Location="+"STATIC");
            setTimeout(function () { GetRadWindow().BrowserWindow.openModal('frmPrintPDF.aspx', 800, 1000, obj); }, 0);
        }
        if(screen != null && screen!="")
        {
            openProgress(screen);
        }

        if (DownloadDoc != null && DownloadDoc != "") {
            setTimeout(function () {
                var sPath = ""
                sPath = "frmWellnessNotes.aspx?PatientDocuments=Patient_Documents&CheckedDocumnts=" + DownloadDoc;;
                $(top.window.document).find("#PlanModal").modal({ backdrop: "static", keyboard: false }, 'show');
                $(top.window.document).find("#ProcessiFrame")[0].contentDocument.location.href = sPath;
                $(top.window.document).find("#PlanModal").modal('hide');
                return false;
            }, 0);
        }
    }

    function openProgress(screen)
    {
       var obj=new Array();      
       var now=new Date();
       var date = now.toUTCString();
       obj.push("Date="+date);  
       obj.push("Menu=" + "PDF");
         if(screen=='Pro|Con' || screen=='Con|Pro')
         {
           var objWindow=$find("RadWindow3");
       
           var objConsult= openModalProgress("frmConsultationNotes.aspx",700,750,obj,"RadWindow3");
          var win = $find("RadWindow3");
          win.hide();
          if(document.getElementById(GetClientId("hdnHumanID"))!=null && document.getElementById(GetClientId("hdnHumanID")).value!="" && document.getElementById(GetClientId("hdnHumanID")).value!="0")
          {
           if(document.getElementById(GetClientId("hdnEncounterId"))!=null && document.getElementById(GetClientId("hdnEncounterId")).value!="" && document.getElementById(GetClientId("hdnEncounterId")).value!="0")
           {
               if ($('#ProcessiFrameNotesCheckout').length > 0)
                   $('#ProcessiFrameNotesCheckout')[0].contentDocument.location.href = "frmSummaryNew.aspx?Menu=PDF&TabMode=true";
               if ($("#ModalTtleNotes").length > 0)
                   $("#ModalTtleNotes")[0].textContent = "Progress Notes";
               

           }     
          }
        }
        else if(screen=='Pro')
        {
         if(document.getElementById(GetClientId("hdnHumanID"))!=null && document.getElementById(GetClientId("hdnHumanID")).value!="" && document.getElementById(GetClientId("hdnHumanID")).value!="0")
          {
           if(document.getElementById(GetClientId("hdnEncounterId"))!=null && document.getElementById(GetClientId("hdnEncounterId")).value!="" && document.getElementById(GetClientId("hdnEncounterId")).value!="0")
           {
               var oBrowserWnd = GetRadWindow().BrowserWindow;
               if ($("#ProcessiFrameNotesCheckout").length > 0)
                   $('#ProcessiFrameNotesCheckout')[0].contentDocument.location.href = "frmSummaryNew.aspx?Menu=PDF"+"&TabMode=true";
               if ($("#ModalTtleNotes").length > 0)
                   $("#ModalTtleNotes")[0].textContent = "Progress Notes";
              
           }
          }   
     
        }
        else if(screen=='Con')
        {
          var objConsult= openModalProgress("frmConsultationNotes.aspx",10,10,obj,"RadWindow3");   
          var win = $find("RadWindow3");
          win.hide();     
     }
  if (document.getElementById('hdnXmlPath').value != null && document.getElementById('hdnXmlPath').value != "")
   {
       OpenClinicalSmry();
   }

 }

 function GetRadWindow() 
    {
        var oWindow = null;
        if (window.radWindow) oWindow = window.radWindow;
        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
        return oWindow;
    }
    


 function OpenPaymentCollection() {
     var obj = new Array();
     var ScreenMode = "COLLECT COPAY";
     obj.push("EncounterID=" + document.getElementById('hdnEncID').value);
     obj.push("sScreenMode=" + ScreenMode);

     // var objACO = openModal("frmPatientPayment.aspx", 450, 1190, obj, 'RadWindowPatient');
     var objACO = openModal("frmPatientPayment.aspx", 450, 1047, obj, "RadWindowPatient");

 }

function OpenfollowupAppointment() 
{
    var obj=new Array();
    setTimeout(   
    function()
    {
       var oWnd = GetRadWindow();
       var childWindow=oWnd.BrowserWindow.radopen("frmAppointments.aspx?Duedate="+document.getElementById('hdnDuedate').value +"&hdnSourceScreen=Menu"+"&MasterPage="+"YES","AppointmentWindow");
       childWindow.SetModal(true);
       childWindow.set_visibleStatusbar(false);
       childWindow.setSize(1265, 890);
       childWindow.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close|Telerik.Web.UI.WindowBehaviors.Move);
       childWindow.set_iconUrl("Resources/16_16.ico"); 
       childWindow.set_keepInScreenBounds(true);
       childWindow.set_centerIfModal(true);
       childWindow.center();
       },0);
       setTimeout(
    function () {
        var oWnd = GetRadWindow();
        var now = new Date();
        var then = now.getDay() + '-' + (now.getMonth() + 1) + '-' + now.getFullYear(); then += ' ' + now.getHours() + ':' + now.getMinutes() + ':' + now.getSeconds();
        var utc = (now.getUTCMonth() + 1) + '/' + now.getUTCDate() + '/' + now.getUTCFullYear(); utc += ' ' + now.getUTCHours() + ':' + now.getUTCMinutes() + ':' + now.getUTCSeconds();
        var localtime = utc;


       


        var human_Details = document.getElementById('HiddenhumanDetails').value;
        var obj = new Array();
        obj.push("Human_id=" + human_Details.split('~')[0]);
        obj.push("PatientName=" + human_Details.split('~')[1]);
        obj.push("PatientDOB=" + human_Details.split('~')[2]);
        obj.push("HumanType=" + human_Details.split('~')[3]);
        obj.push("Home_Phone=" + human_Details.split('~')[4]);
        obj.push("Cell_Phone=" + human_Details.split('~')[5]);
        obj.push("Encounter_Provider_ID=" + human_Details.split('~')[6]);



        var childWindows = oWnd.BrowserWindow.radopen("frmEditAppointment.aspx?" + "&Human_id=" + human_Details.split('~')[0] +
                    "&PatientName=" + human_Details.split('~')[1] + "&PatientDOB=" + human_Details.split('~')[2] + "&HumanType=" + human_Details.split('~')[3] +
                    "&facility=" + fac +  "&Home_Phone=" + human_Details.split('~')[4] + "&Cell_Phone=" + human_Details.split('~')[5] + "&Encounter_Provider_ID=" + human_Details.split('~')[6] +
                    "&PhysicianName="+document.getElementById('hdnPhyName').value + "&PhysicianID=" + document.getElementById('hdnPhyID').value +
                    "&SelectedDate=" + document.getElementById('hdnDuedate').value + "&CurrentProcess=SCHEDULED" + "&EncounterID=0" + "&LocalTime=" + localtime, "WindowEdit");
        childWindows.SetModal(false);
        childWindows.set_visibleStatusbar(false);
        childWindows.setSize(800, 800);
        childWindows.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close | Telerik.Web.UI.WindowBehaviors.Move);
        childWindows.set_iconUrl("Resources/16_16.ico");
        childWindows.set_keepInScreenBounds(true);
        childWindows.set_centerIfModal(true);
        childWindows.center();

        childWindows.add_close(RefreshScheduler);
        function RefreshScheduler(oWindow, args) {
            if (childWindow != undefined)
                childWindow.close();

            var oWnd = GetRadWindow();
            var childWindow = oWnd.BrowserWindow.radopen("frmAppointments.aspx?Duedate=" + document.getElementById('hdnDuedate').value + "&hdnSourceScreen=Menu" + "&MasterPage=" + "YES", "AppointmentWindow");
            childWindow.SetModal(true);
            childWindow.set_visibleStatusbar(false);
            childWindow.setSize(1265, 890);
            childWindow.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close | Telerik.Web.UI.WindowBehaviors.Move);
            childWindow.set_iconUrl("Resources/16_16.ico");
            childWindow.set_keepInScreenBounds(true);
            childWindow.set_centerIfModal(true);
            childWindow.center();
        }

    }, 0);
var fac = document.getElementById('hdnFacility').value;
if(fac.indexOf("#")!=-1)
    fac = fac.replace("#", "_");
{ sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
$('#lstSurgeryName').find('li').addClass('Editabletxtbox');
}



	function CellSelectedforClose(value)
	{
	    if(DisplayErrorMessage('430002')==true)
        {
        document.getElementById('hdnIsCheckout').value="true";
        document.getElementById('hdnIsFormClosed').value="true";
        }
        else
        {
            GetRadWindow().close();
        }
	}
	 function GetUTCTime()
    {
        var now=new Date();
        var utc=(now.getUTCMonth()+1)+'/'+now.getUTCDate()+'/'+now.getUTCFullYear();utc+=' '+now.getUTCHours()+':'+now.getUTCMinutes()+':'+now.getUTCSeconds();
        document.getElementById(GetClientId("hdnLocalTime")).value = utc;
        document.getElementById('HiddenDLC').value = document.getElementById('DLC_txtDLC').value;
    }
    function clientclick() 
    {
        { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
    }
    function ShowLoading()
    {
        document.getElementById("divLoading").style.display="block";
    }
function TextChange()
{
    EnableAutoSave = true;
    document.getElementById('HiddenDLC').value = document.getElementById('DLC_txtDLC').value;
   
    
}
function EnableSave(e) {
    EnableAutoSave = true;
    document.getElementById('HiddenDLC').value = document.getElementById('DLC_txtDLC').value;
    
}

function cboIsDocumentGiven_SelectedIndexChanged(sender,args)
{
	EnableAutoSave=true;
}
function cboRelationship_SelectedIndexChanged(sender,args)
{
	EnableAutoSave=true;
}
function OpenClinicalSmry() {
    var obj = new Array();
    if (document.getElementById('hdnXmlPath').value != null && document.getElementById('hdnXmlPath').value != "") {
        var filelocation = document.getElementById('hdnXmlPath').value; 
        window.open(filelocation, "CDA Human Readable", "", "")
    }
}

function Checkout(sender, args)

{
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
  
    GetUTCTime();

    if ((event.target.name == 'btnCheckOut' && document.getElementById("hdnButtonName").value == "") || (event.target.name == 'btnCheckOut' && document.getElementById("hdnButtonName").value == "btnMessageType") || document.getElementById("hdnButtonName").value == "btnCheckOut") 
    {
        EnableAutoSave = false;
         document.getElementById("hdnButtonName").value = event.target.name;
         if (document.getElementById("txtDueDate").value != "" || document.getElementById("txtFollowReasonNotes").value != "") 
         {
             if (window.parent.parent.theForm.ctl00_hdnAppoinment.value != "true") 
             {
                 if (document.getElementById("hdnMessageType").value == "") 
                 {
                     DisplayErrorMessage('430008');
                     { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
                     $('#chklstPrintDocuments').find('li').addClass('Editabletxtbox');
                 }
                 else if (document.getElementById("hdnMessageType").value == "Yes") 
                 {
                     EnableAutoSave = false;
                     document.getElementById('hdnIsCheckout').value = "true";
                     document.getElementById('hdnIsFormClosed').value = "true";
                     document.getElementById('btnFollowupAppointment').click();
                     return true;
                 }
                 else if (document.getElementById("hdnMessageType").value == "No") 
                 {
                     document.getElementById("hdnMessageType").value = "";
                     if (document.getElementById('txtDueDate').value != "") 
                     {
                         OpenfollowupAppointment();
                     }
                     else 
                     {
                         document.getElementById('hdnDuedate').value = document.getElementById('hdnLocalTime').value;
                         OpenfollowupAppointment();
                     }
                     
                 }
                 else if (document.getElementById("hdnMessageType").value == "Cancel") {
                     document.getElementById("hdnMessageType").value = "";
                      {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
                 }
             }
             else 
             {
                 document.getElementById('hdnIsCheckout').value = "true";
                 document.getElementById('hdnIsFormClosed').value = "true";
                 document.getElementById('btnFollowupAppointment').click();
                 window.parent.parent.theForm.ctl00_hdnAppoinment.value = false;
                 return true;
             }
         }
         else 
         {
             document.getElementById('hdnIsCheckout').value = "true";
             document.getElementById('hdnIsFormClosed').value = "true";
             document.getElementById('btnFollowupAppointment').click();             
         }
     }
     else if ((event.target.name == 'btnClose' && document.getElementById("hdnButtonName").value == "") || (event.target.name == 'btnClose' && document.getElementById("hdnButtonName").value == "btnMessageType") || document.getElementById("hdnButtonName").value == "btnClose") 
     {
        document.getElementById("hdnButtonName").value = event.target.name;
         if (EnableAutoSave == true) 
         {
             if (document.getElementById("hdnMessageType").value == "") 
             {
                 DisplayErrorMessage('430002');
                  {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
             }
             else if (document.getElementById("hdnMessageType").value == "Yes")
             {
                 document.getElementById('hdnIsCheckout').value = "true";
                 document.getElementById('hdnIsFormClosed').value = "false";
                 document.getElementById('btnFollowupAppointment').click();                 
                 return true;
                 self.close();
             }
             else if (document.getElementById("hdnMessageType").value == "No") 
             {
                 document.getElementById("hdnMessageType").value = "";
                 self.close();
                  {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
             }
             else if (document.getElementById("hdnMessageType").value == "Cancel") 
             {
                 document.getElementById("hdnMessageType").value = "";
                  {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
             }
             event.preventDefault; 
         }
         else 
         {
             GetRadWindow().close();
              {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
         }         
     }    
}
function ShowPatientSummary() {
    var obj = new Array();
    var Humanid = document.getElementById(GetClientId("hdnHumanID")).value;
    obj.push("EncounterID=0");
    obj.push("humanID=" + Humanid);
    obj.push("EncStatus=''");
    obj.push("bShowPat=true");
    obj.push("sScreenMode=EVSUMMARY");
    openModal("frmQuickpatientcreate.aspx", 730, 1020, obj, "ctl00_ModalWindow");
}
