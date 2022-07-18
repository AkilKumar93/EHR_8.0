    function KeyPress(sender,args)
	{
	var text = sender.get_value() + args.get_keyCharacter();
       if (!text.match('^[0-9]+$'))
           args.set_cancel(true);
	}
	function CheckChange()
    {
    GetUTCTime();
    $find('btnOK').set_enabled(true);
    }
    function GetUTCTime() 
    {
    
        var dt = new Date();
        var now = new Date();
        var utc = (now.getUTCMonth() + 1) + '/' + ("0" + now.getUTCDate()).slice(-2) + '/' + now.getUTCFullYear();
        var minutes;
        var seconds;
        if (now.getUTCMinutes() < 10) {
            minutes = '0' + now.getUTCMinutes();
        }
        else {
            minutes = now.getUTCMinutes();
        }
        if (now.getUTCSeconds() < 10) {
            seconds = '0' + now.getUTCSeconds();
        }
        else {
            seconds = now.getUTCSeconds();

        }
        utc += ' ' + now.getUTCHours() + ':' + minutes + ':' + seconds;
        document.getElementById("hdnLocalTime").value = utc;
    }
    function ClearAll()
    {
    var Save=$find('btnOK');
    if(Save.get_enabled())
    {
    if( DisplayErrorMessage('9093034'))
    {
    var Contol = document.getElementsByTagName('input');
    for(var i=0; i < Contol.length; i++)
    {
    if(Contol[i].type == 'checkbox')
    {
        Contol[i].checked =false;
    }
    }
    var CurrentDate = new Date();
    var Combo=$find('cboGACalculationMethod');
    Combo.clearSelection();
    document.getElementById("txtGADays").value="";
    document.getElementById("txtGAWeeks").value="";
    document.getElementById("txtAdditionalInfo").value="";
    document.getElementById("txtNumberofFetuses").value="";
    document.getElementById("txtAgeofEggDonor").value="";
    document.getElementById("txtUltrasoundCRLLength").value="";
    document.getElementById("txtUltrasoundCRLLengthTwinB").value="";
    document.getElementById("txtNuchalTranslucency").value="";
    document.getElementById("txtNuchalTranslucencyTwinB").value="";
    document.getElementById("txtSonographerLastName").value="";
    document.getElementById("txtSonographerFirstName").value="";
    document.getElementById("txtSonographerIDNumber").value="";
    document.getElementById("txtSiteNumber").value="";
    document.getElementById("txtReadingPhysicianID").value="";
    var dtpGADateofCalculation=$find('dtpGADateofCalculation');
    var dtpGADate=$find('dtpGADate');
    dtpGADateofCalculation.set_selectedDate(CurrentDate);
    dtpGADate.set_selectedDate(CurrentDate);
    $find('btnOK').set_enabled(false)
    }
    }
    }

function IsNumeric(key)
{
var keycode = (key.which) ? key.which : key.keyCode;
if (!(keycode==8||keycode==46)&&(keycode < 48 || keycode > 57))
{
return false;
}
return true;
}
function IsCheckBox(to)
{
if(document.getElementById(to).checked=true)
{
document.getElementById(to).checked=false;
}
}


 function ClearAllCytology()
 {
    var Save=$find('btnSave');
    if(Save.get_enabled())
    {
    if( DisplayErrorMessage('9093034'))
    {
    var Contol = document.getElementsByTagName('input');
    for(var i=0; i < Contol.length; i++)
    {
    if(Contol[i].type == 'checkbox')
    {
        Contol[i].checked =false;
    }
    }
    var CurrentDate = new Date();
    document.getElementById("txtDatesResults").value="";
    var dtpLMPDate=$find('dtpLMPDate');
    dtpLMPDate.set_selectedDate(CurrentDate);
    }
    }
 }
function CheckChangeCyt(to)
{
if(document.getElementById(to).checked=true)
{
document.getElementById(to).checked=false;
}
}
function CloseQuestionSetAOE()
 {
  var Save=$find('btnOK');
  if(Save.get_enabled())
  {
  if(DisplayErrorMessage('9093035')==false)
  {
  self.close();
  }
  }
  else
  {
    self.close();
  }
 }
 function ClearAllAOE(sender, args)
 {
    var Save=$find('btnOK');
    if(Save.get_enabled())
    {
    if( DisplayErrorMessage('9093034'))
    {
    sender.set_autoPostBack(true);
    }
    else
    {
     sender.set_autoPostBack(false);
    }
    }
    return false;
 }
 function EnableSave()
 {
 GetUTCTime();
 var Save=$find('btnOK');
 Save.set_enabled(true);
 }
 
 function txtbox_OnKeyPress(sender,args)
 {
	GetUTCTime();
    var Save=$find('btnOK');
    Save.set_enabled(true);
    var ClearAll=$find('btnClearAll');
    ClearAll.set_enabled(true);
}

//Added By Suvarnni For YesNoCancel
function CloseQuestionSet(sender,args) 
{
    var Save = $find('btnOK');
    if (Save.get_enabled()) 
    {
        if (document.getElementById("hdnMessageType").value == "") 
        {
            document.getElementById("hdnMessageType").value == "Yes";
            CheckChange();
            __doPostBack('btnOK', "true");
            document.getElementById("hdnMessageType").value = "";
            self.close();
            //DisplayErrorMessage('1105002');
            //sender.set_autoPostBack(false);
        }
        //else if (document.getElementById("hdnMessageType").value == "Yes") 
        //{
        //    CheckChange();
        //    __doPostBack('btnOK', "true");
        //    document.getElementById("hdnMessageType").value = "";
        //    self.close();
        //}
        //else if (document.getElementById("hdnMessageType").value == "No") 
        //{
        //    document.getElementById("hdnMessageType").value = ""
        //    self.close();
        //}
        //else if (document.getElementById("hdnMessageType").value == "Cancel") 
        //{
        //    document.getElementById("hdnMessageType").value = "";
        //    $find('btnOK').set_enabled(true);
        //    return false;
        //}
    }
    else 
    {
        self.close();
    }
}

function CloseQuestionSetCytology(sender,args)
 {
  var Save=$find('btnSave');
  if(Save.get_enabled())
  {
      if (document.getElementById("hdnMessageType").value == "") 
      {
          document.getElementById("hdnMessageType").value == "Yes";
          GetUTCTime();
          __doPostBack('btnSave', "true");
          document.getElementById("hdnMessageType").value = "";
          self.close();
          //DisplayErrorMessage('1105002');
          //sender.set_autoPostBack(false);
      }
      //else if (document.getElementById("hdnMessageType").value == "Yes") 
      //{
      //    GetUTCTime();
      //    __doPostBack('btnSave', "true");
      //    document.getElementById("hdnMessageType").value = "";
      //    self.close();
      //}
      //else if (document.getElementById("hdnMessageType").value == "No") 
      //{
      //    document.getElementById("hdnMessageType").value = ""
      //    self.close();
      //}
      //else if (document.getElementById("hdnMessageType").value == "Cancel") 
      //{
      //    document.getElementById("hdnMessageType").value = "";
      //    $find('btnSave').set_enabled(true);
      //    return false;
      //}
  }
  else
  {
    self.close();
  }
 }