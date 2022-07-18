window.onload = function () 
{
    if (window.dialogArguments!=null)
    {
    var obj1=new Object();
obj1.AccNo=document.getElementById(GetClientId('txtAccountNumber')).value;
window.dialogArgument=obj1;
    }
     {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
 }
 function closeWindow(aWindow) {
    GetRadWindow().close();
} 
function RefreshBackPage()
{
window.alert("Moved Successfully");
window.location="frmBillingAndDenialQueue.aspx";
}
  function showStartTime() { 
            var dt = new Date(); 
  var now = new Date(); 
  var then = now.getDay()+'-'+(now.getMonth()+1)+'-'+now.getFullYear(); 
      then += ' '+now.getHours()+':'+now.getMinutes()+':'+now.getSeconds(); 
     var utc=(now.getUTCMonth()+1)+'/'+now.getUTCDate()+'/'+now.getUTCFullYear();
utc+=' '+now.getUTCHours()+':'+now.getUTCMinutes()+':'+now.getUTCSeconds();
        document.getElementById(GetClientId("hdnDOPStart")).value=utc;
        }
  function CloseWindow()
    {
    var Result=new Object();
    Result.ExcHumanList=document.getElementById(GetClientId('hdnExceptionList')).value;
    Result.Amount=document.getElementById("hdnTotalAmount").value;
    if(window.opener){ window.opener.returnValue = Result; }
    window.returnValue=Result;
    returnToParent(Result);          
    }   
function showTime() 
{ 
            var dt = new Date(); 
  var now = new Date(); 
  var then = now.getDay()+'-'+(now.getMonth()+1)+'-'+now.getFullYear(); 
      then += ' '+now.getHours()+':'+now.getMinutes()+':'+now.getSeconds(); 
      var utc=(now.getUTCMonth()+1)+'/'+now.getUTCDate()+'/'+now.getUTCFullYear();
utc+=' '+now.getUTCHours()+':'+now.getUTCMinutes()+':'+now.getUTCSeconds();
        document.getElementById(GetClientId("hdnDateAndTime")).value=utc;
 document.getElementById('divLoading').style.display="block";      
 }
 function isNumericKey(e)
{
var charInp = window.event.keyCode; 
    if (charInp > 31 && (charInp < 48 || charInp > 57) && (charInp!=46)) 
{
 return false;
 }
    return true;
}
        function isNumberKey(evt)
{
    var charCode = (evt.which) ? evt.which : event.keyCode;
    return (charCode<=31 ||  charCode==44 ||  charCode==46 || (charCode>=48 && charCode<=57));
}
 
function validCurrency(amt)
{
    return amt.match(/^\d*(.\d{0,2})?$/);
}
 
function validateForm(formObj)
{
    var splitnumber=document.getElementById(GetClientId('txtAmount')).value.split(',');
    for (var key in splitnumber)
    {
    var eachno=splitnumber[key];    
    if(!validCurrency(eachno))
    {
        alert('You must enter a valid dollar amount in Amount.');
        document.getElementById(GetClientId('txtAmount')).select();
        document.getElementById(GetClientId('txtAmount')).focus();
        return false;
    }
    }  
    
     var splitnumber=document.getElementById(GetClientId('txtBilledCharge')).value.split(',');
    for (var key in splitnumber)
    {
    var eachno=splitnumber[key];    
    if(!validCurrency(eachno))
    {
        alert('You must enter a valid dollar amount in BilledCharge.');
        document.getElementById(GetClientId('txtBilledCharge')).select();
        document.getElementById(GetClientId('txtBilledCharge')).focus();
        return false;
    }
    }  
    return true;
}
function CloseException()
{
window.parent.parent.location.href ="frmMyQueueNew.aspx";
self.close();

}
function OpenPatientDemographics()
     {  
     if (document.getElementById(GetClientId('txtAccountNumber')).value!="")
     {  
     setTimeout(
        function()
    {
        var obj =new Object();
        obj.HumanID=document.getElementById(GetClientId('txtAccountNumber')).value;
        obj.FromScreen="Review Exception";
var oWnd = GetRadWindow();
 var childWindow=oWnd.BrowserWindow.radopen("frmPatientDemographics.aspx?HumanID="+obj.HumanID+"&FromScreen="+obj.FromScreen,"ctl00_ReviewExceptionModalWindow");
 setRadWindowProperties(childWindow,1300,1120);            
        },0);   
       }
     }
        function GetClientId(strid)
{var count=document.forms[0].length;var i=0;var eleName;for(i=0;i<count;i++)
{eleName=document.forms[0].elements[i].id;pos=eleName.indexOf(strid);if(pos>=0)break;}
return eleName;}
function OpenDisplayObject()
    {
     var obj=new Array();
     var sWorksetID =document.getElementById(GetClientId("hdnWFObjectID")).value;
     var sObjType =document.getElementById(GetClientId("hdnObjectType")).value;
      var sObjSystemID =document.getElementById(GetClientId("hdnExcID")).value;
     obj.push("WorksetID="+sWorksetID);
     obj.push("ObjType="+sObjType);
      obj.push("ObjSystemID="+sObjSystemID);
     var Result=openNonModal("frmNewDisplayObject.aspx",940,1170,obj);
     
     if(Result== null)
     return false;
   }
    function OpenViewBatch()
    {
   if( document.getElementById(GetClientId("hdnFilePath")).value.length!=0)
   {
     var obj=new Array();
     obj.push("FilePath="+document.getElementById(GetClientId("hdnFilePath")).value);
 obj.push("HumanID="+document.getElementById(GetClientId("txtAccountNumber")).value);
 obj.push("BatchName="+document.getElementById(GetClientId("txtBatchName")).value);
 obj.push("DOOS="+document.getElementById(GetClientId("txtDOOS")).value);
    var Result=openNonModal("frmViewBatch.aspx",900,1500,obj);
     if(Result== null)
     return false;
     }
   }   
     function OpenChargePosting()
     {    
     if (document.getElementById(GetClientId('txtDocType')).value=="CHARGE_POSTING")
     {     
     setTimeout(
        function()
    {
        var obj =new Object();
        obj.ObjSystenID=document.getElementById(GetClientId('txtExceptionID')).value;
        obj.WFObjectID=document.getElementById(GetClientId('txtWfObjectId')).value;
        obj.CurrentProcess=document.getElementById(GetClientId('txtCurrentProcess')).value;
        obj.FromScreen="Review Exception";
var oWnd = GetRadWindow();
 var childWindow=oWnd.BrowserWindow.radopen("frmCodingAndChargePosting.aspx?HumanID="+obj.HumanID+"&FromScreen="+obj.FromScreen+"&ObjSystemID="+obj.ObjSystenID+"&WFObjectID="+obj.WFObjectID+"&CurrentProcess="+obj.CurrentProcess,"ctl00_ReviewExceptionModalWindow");
 setRadWindowProperties(childWindow,1100,1250);            
        },0);   
       }
     }
     function SaveValidation()
{
var dt=new Date();
var now=new Date();
var then=now.getDay()+'-'+(now.getMonth()+1)+'-'+now.getFullYear();then+=' '+now.getHours()+':'+now.getMinutes()+':'+now.getSeconds();
var utc=(now.getUTCMonth()+1)+'/'+now.getUTCDate()+'/'+now.getUTCFullYear();utc+=' '+now.getUTCHours()+':'+now.getUTCMinutes()+':'+now.getUTCSeconds();
document.getElementById(GetClientId("hdnLocalTime")).value=utc;

if(document.getElementById(GetClientId("cboExceptionType")).value=="")
{
    DisplayErrorMessage('3090036');
    document.getElementById(GetClientId("cboExceptionType")).focus();
    return false;
}
if(document.getElementById(GetClientId("cboCategory")).value=="")
{
    DisplayErrorMessage('3090037');
    document.getElementById(GetClientId("cboCategory")).focus();
    return false;
}   
if(document.getElementById(GetClientId("txtPageNumber")).value=="")
{
    DisplayErrorMessage('3090001');
    document.getElementById(GetClientId("txtPageNumber")).focus();
    return false;
}
if(document.getElementById(GetClientId("txtPageNumber")).value!="")
{
    var sSplitPageNo=document.getElementById(GetClientId("txtPageNumber")).value.split(',');
    if (sSplitPageNo.length!=0)
    {
    var i=0;
    for (i=0;i<sSplitPageNo.length;i++)
    {
        if (sSplitPageNo[i]=="")
        {
        DisplayErrorMessage('3090001');
        document.getElementById(GetClientId("txtPageNumber")).focus();
        return false;
        }

    }
    }
}
if (document.getElementById(GetClientId("txtPageNumber")).value.split(',').length!=document.getElementById(GetClientId("txtDOS")).value.split(',').length)
{
DisplayErrorMessage('3090027');
document.getElementById(GetClientId("txtDOS")).focus();
return false;
}
if(document.getElementById(GetClientId("txtPatientName")).value=="")
{
DisplayErrorMessage('3090002');
document.getElementById(GetClientId("txtPatientName")).focus();
return false;
}
if(document.getElementById(GetClientId("txtAccountNumber")).value=="")
{
DisplayErrorMessage('3090003');
document.getElementById(GetClientId("txtAccountNumber")).focus();
return false;
}
if(document.getElementById(GetClientId("txtEncounterID")).value=="")
{
DisplayErrorMessage('3090004');
document.getElementById(GetClientId("txtEncounterID")).focus();
return false;
}
if(document.getElementById(GetClientId("cboDoctorList")).value=="")
{
DisplayErrorMessage('3090038');
document.getElementById(GetClientId("cboDoctorList")).focus();
return false;
}
if(document.getElementById(GetClientId("cboFieldName")).value=="")
{
DisplayErrorMessage('3090039');
document.getElementById(GetClientId("cboFieldName")).focus();
return false;
}
if(document.getElementById(GetClientId("txtCptCode")).value=="")
{
DisplayErrorMessage('3090007');
document.getElementById(GetClientId("txtCptCode")).focus();
return false;
}
if(document.getElementById(GetClientId("txtCptCode")).value!="")
{
    var sSplitCPT=document.getElementById(GetClientId("txtCptCode")).value.split(',');
    if (sSplitCPT.length!=0)
    {
    var i=0;
    for (i=0;i<sSplitCPT.length;i++)
    {
    if (sSplitCPT[i]=="")
    {
    DisplayErrorMessage('3090007');
    document.getElementById(GetClientId("txtCptCode")).focus();
    return false;
    }
    }
    if (document.getElementById(GetClientId("txtCptCode")).value.split(',').length!=document.getElementById(GetClientId("txtDOS")).value.split(',').length)
    {
    DisplayErrorMessage('3090028');
    document.getElementById(GetClientId("txtCptCode")).focus();
    return false;
    }
    }
}
if(document.getElementById(GetClientId("txtAmount")).value=="")
{
    DisplayErrorMessage('3090008');
    document.getElementById(GetClientId("txtAmount")).focus();
    return false;
}
if(document.getElementById(GetClientId("txtAmount")).value!="")
{
    var sSplitAmount=document.getElementById(GetClientId("txtAmount")).value.split(',');
    if (sSplitAmount.length!=0)
    {
    var i=0;
    for (i=0;i<sSplitAmount.length;i++)
    {
    if (sSplitAmount[i]=="")
    {
    DisplayErrorMessage('3090008');
    document.getElementById(GetClientId("txtAmount")).focus();
    return false;
    }
    }
    }
}
if (document.getElementById(GetClientId("txtCptCode")).value.split(',').length!=document.getElementById(GetClientId("txtAmount")).value.split(',').length)
{
DisplayErrorMessage('3090029');
document.getElementById(GetClientId("txtAmount")).focus();
return false;
}
if(document.getElementById(GetClientId("txtNo")).value=="")
{
DisplayErrorMessage('3090006');
document.getElementById(GetClientId("txtNo")).focus();
return false;
}
if(document.getElementById(GetClientId("cboInsuranceName")).value=="")
{
DisplayErrorMessage('3090041');
document.getElementById(GetClientId("cboInsuranceName")).focus();
return false;
}
if(document.getElementById(GetClientId("cboReasonCode")).value=="")
{
DisplayErrorMessage('3090042');
document.getElementById(GetClientId("cboReasonCode")).focus();
return false;
}
if(document.getElementById(GetClientId("txtBilledCharge")).value=="")
{
DisplayErrorMessage('3090031');
document.getElementById(GetClientId("txtBilledCharge")).focus();
return false;
}
if(document.getElementById(GetClientId("txtBilledCharge")).value!="")
{
    var sSplitCPT=document.getElementById(GetClientId("txtBilledCharge")).value.split(',');
    if (sSplitCPT.length!=0)
    {
    var i=0;
    for (i=0;i<sSplitCPT.length;i++)
    {
    if (sSplitCPT[i]=="")
    {
    DisplayErrorMessage('3090031');
    document.getElementById(GetClientId("txtBilledCharge")).focus();
    return false;
    }
    }
    if (document.getElementById(GetClientId("txtBilledCharge")).value.split(',').length!=document.getElementById(GetClientId("txtCptCode")).value.split(',').length)
    {
    DisplayErrorMessage('3090032');
    document.getElementById(GetClientId("txtBilledCharge")).focus();
    return false;
    }
    }
}
if(document.getElementById(GetClientId("txtIssues")).value=="")
{
DisplayErrorMessage('3090010');
document.getElementById(GetClientId("txtIssues")).focus();
return false;
}
}
function SaveValidationinReviewException()
{
var dt=new Date();
var now=new Date();
var then=now.getDay()+'-'+(now.getMonth()+1)+'-'+now.getFullYear();then+=' '+now.getHours()+':'+now.getMinutes()+':'+now.getSeconds();
var utc=(now.getUTCMonth()+1)+'/'+now.getUTCDate()+'/'+now.getUTCFullYear();utc+=' '+now.getUTCHours()+':'+now.getUTCMinutes()+':'+now.getUTCSeconds();
document.getElementById(GetClientId("hdnLocalTime")).value=utc;

if(document.getElementById(GetClientId("txtPageNumber")).value!="")
{
    var sSplitPageNo=document.getElementById(GetClientId("txtPageNumber")).value.split(',');
    if (sSplitPageNo.length!=0)
    {
    var i=0;
    for (i=0;i<sSplitPageNo.length;i++)
    {
        if (sSplitPageNo[i]=="")
        {
        DisplayErrorMessage('4130012');
        document.getElementById(GetClientId("txtPageNumber")).focus();
        return false;
        }
        if (sSplitPageNo[i]>document.getElementById(GetClientId("hdnNoofImagesRcvd")).value)
        {
        var sErrorPageNo=sSplitPageNo[i]+"-"+document.getElementById(GetClientId("hdnNoofImagesRcvd")).value;
        DisplayErrorMessage('4130013',sErrorPageNo);
        document.getElementById(GetClientId("txtPageNumber")).focus();
        return false;
        }
    }
    }
}
if(document.getElementById(GetClientId("txtAccountNumber")).value=="")
{
DisplayErrorMessage('4130014');
document.getElementById(GetClientId("txtAccountNumber")).focus();
return false;
}
if(document.getElementById(GetClientId("txtPatientName")).value=="")
{
DisplayErrorMessage('4130012');
document.getElementById(GetClientId("txtPatientName")).focus();
return false;
}
if(document.getElementById(GetClientId("txtEncounterID")).value=="")
{
DisplayErrorMessage('4130016');
document.getElementById(GetClientId("txtEncounterID")).focus();
return false;
}
if(document.getElementById(GetClientId("txtCptCode")).value=="")
{
DisplayErrorMessage('4130017');
document.getElementById(GetClientId("txtCptCode")).focus();
return false;
}
if(document.getElementById(GetClientId("txtCptCode")).value!="")
{
    var sSplitCPT=document.getElementById(GetClientId("txtCptCode")).value.split(',');
    if (sSplitCPT.length!=0)
    {
    var i=0;
    for (i=0;i<sSplitCPT.length;i++)
    {
    if (sSplitCPT[i]=="")
    {
    DisplayErrorMessage('4130017');
    document.getElementById(GetClientId("txtCptCode")).focus();
    return false;
    }
    }
    if (document.getElementById(GetClientId("txtCptCode")).value.split(',').length!=document.getElementById(GetClientId("txtDOS")).value.split(',').length)
    {
    DisplayErrorMessage('3090028');
    document.getElementById(GetClientId("txtCptCode")).focus();
    return false;
    }
    }
}
if(document.getElementById(GetClientId("txtDOS")).value=="")
{
DisplayErrorMessage('4130019');
document.getElementById(GetClientId("txtDOS")).focus();
return false;
}
if (document.getElementById(GetClientId("txtPageNumber")).value.split(',').length!=document.getElementById(GetClientId("txtDOS")).value.split(',').length)
{
DisplayErrorMessage('4130024');
document.getElementById(GetClientId("txtDOS")).focus();
return false;
}
if(document.getElementById(GetClientId("txtAmount")).value!="")
{
    var sSplitAmount=document.getElementById(GetClientId("txtAmount")).value.split(',');
    if (sSplitAmount.length!=0)
    {
    var i=0;
    for (i=0;i<sSplitAmount.length;i++)
    {
    if (sSplitAmount[i]=="")
    {
    DisplayErrorMessage('4130025');
    document.getElementById(GetClientId("txtAmount")).focus();
    return false;
    }
    }
    }
}
if (document.getElementById(GetClientId("txtCptCode")).value.split(',').length!=document.getElementById(GetClientId("txtAmount")).value.split(',').length)
{
DisplayErrorMessage('4130026');
document.getElementById(GetClientId("txtAmount")).focus();
return false;
}
if(document.getElementById(GetClientId("txtIntChkWarrantNo")).value=="")
{
DisplayErrorMessage('4130027');
document.getElementById(GetClientId("txtIntChkWarrantNo")).focus();
return false;
}
if(document.getElementById(GetClientId("txtBilledCharge")).value!="")
{
    var sSplitBilledCharge=document.getElementById(GetClientId("txtBilledCharge")).value.split(',');
    if (sSplitBilledCharge.length!=0)
    {
    var i=0;
    for (i=0;i<sSplitBilledCharge.length;i++)
    {
    if (sSplitBilledCharge[i]=="")
    {
    DisplayErrorMessage('4130028');
    document.getElementById(GetClientId("txtBilledCharge")).focus();
    return false;
    }
    }
    }
}
if (document.getElementById(GetClientId("txtCptCode")).value.split(',').length!=document.getElementById(GetClientId("txtBilledCharge")).value.split(',').length)
{
DisplayErrorMessage('4130029');
document.getElementById(GetClientId("txtBilledCharge")).focus();
return false;
}
if(document.getElementById(GetClientId("txtIssues")).value=="")
{
DisplayErrorMessage('4130030');
document.getElementById(GetClientId("txtIssues")).focus();
return false;
}
if(document.getElementById(GetClientId("txtReviewText")).value=="")
{
DisplayErrorMessage('4130031');
document.getElementById(GetClientId("txtReviewText")).focus();
return false;
}
}
function GetRadWindow()
{
var oWindow = null;
if (window.radWindow) oWindow = window.radWindow;
else if (window.frameElement!=null&&window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
if(oWindow==null)
{
oWindow=$find(ModalWndw);
}
return oWindow;
}


function returnToParent(args)
{
var oArg = new Object();
oArg.result = args;
var oWnd = GetRadWindow();
if(oWnd!=null)
{
if (oArg.result)
{
oWnd.close(oArg.result);
}
else
{
oWnd.close(oArg.result);
}
}
else
{
self.close();
}
}
function setRadWindowProperties(childWindow,height,width)
{
       childWindow.SetModal(true);
       childWindow.set_visibleStatusbar(false);
       childWindow.setSize(width, height);
       childWindow.set_behaviors(Telerik.Web.UI.WindowBehaviors.Move);
       childWindow.set_iconUrl("Resources/16_16.ico");
       childWindow.set_keepInScreenBounds(true);
       childWindow.set_centerIfModal(true);
       childWindow.center();
}
function chkSelectAll_CheckedChanged(checkBox)
{  
    var grid = $find("ctl00_C5POBody_grdReviewException");
    var masterTable = grid.get_masterTableView(); 
    
    for (var i = 0; i < masterTable.get_dataItems().length; i++) 
    { 
        var gridItemElement = masterTable.get_dataItems()[i].findElement("chkSelect"); 
        if (checkBox.checked) 
            gridItemElement.checked = true; 
        else
            gridItemElement.checked = false; 
    }    
}
function chkSelectAlll_CheckedChanged(checkBox)
{  
    var grid = $find("grdAddException");
    var masterTable = grid.get_masterTableView(); 
    
    for (var i = 0; i < masterTable.get_dataItems().length; i++) 
    { 
        var gridItemElement = masterTable.get_dataItems()[i].findElement("chkSelect"); 
        if (checkBox.checked) 
            gridItemElement.checked = true; 
        else
            gridItemElement.checked = false; 
    }    
}
function OpenPatInsurancePolicy(ctrl)
{
var Id=ctrl.id;
var obj=new Array();
obj.push("HumanId="+document.getElementById(GetClientId("txtAccountNumber")).value);
openModal("frmPatientInsurancePolicyMaintenance.aspx",650,1160,obj,"ct100_ReviewExceptionWindow");
var WindowName=$find('ct100_ReviewExceptionWindow');
WindowName.add_close(ClosePatInsurancePolicy)
{
function ClosePatInsurancePolicy(ownd,args)
{
var Result = args.get_argument();
if(Result)
{
if(Id=="ctl00_C5POBody_imgPriInsurance")
{
 document.getElementById(GetClientId("txtPriInsurance")).value=Result.PlanName;
}
if(Id=="ctl00_C5POBody_imgSecInsurance")
{
 document.getElementById(GetClientId("txtSecInsurance")).value=Result.PlanName;
}
if(Id=="ctl00_C5POBody_imgTriInsurance")
{
 document.getElementById(GetClientId("txtTriInsurance")).value=Result.PlanName;
}
}
}
}
}

function OpenPatPriInsurancePolicyADDException(ctrl)
{
var Id=ctrl.id;
var obj=new Array();
obj.push("HumanId="+document.getElementById(GetClientId("txtAccountNumber")).value);
openModal("frmPatientInsurancePolicyMaintenance.aspx",650,1160,obj,"ADDNewExceptionWindow");
var WindowName=$find('ADDNewExceptionWindow');
WindowName.add_close(ReviewClosePatInsurancePolicy)
{
function ReviewClosePatInsurancePolicy(ownd,args)
{
var Result = args.get_argument();
if(Result)
{
if(Id=="imgPriInsurancePlus")
{
 document.getElementById(GetClientId("txtPriInsurance")).value=Result.PlanName;
}
}
}
}
}
function OpenPatSecInsurancePolicyADDException(ctrl)
{
var Id=ctrl.id;
var obj=new Array();
obj.push("HumanId="+document.getElementById(GetClientId("txtAccountNumber")).value);
openModal("frmPatientInsurancePolicyMaintenance.aspx",650,1160,obj,"ADDNewExceptionWindow");
var WindowName=$find('ADDNewExceptionWindow');
WindowName.add_close(ReviewClosePatInsurancePolicy)
{
function ReviewClosePatInsurancePolicy(ownd,args)
{
var Result = args.get_argument();
if(Result)
{
if(Id=="imgtxtSecInsuranceplus")
{
 document.getElementById(GetClientId("txtSecInsurance")).value=Result.PlanName;
}
}
}
}
}

function OpenPatTriInsurancePolicyADDException(ctrl)
{
var Id=ctrl.id;
var obj=new Array();
obj.push("HumanId="+document.getElementById(GetClientId("txtAccountNumber")).value);
openModal("frmPatientInsurancePolicyMaintenance.aspx",650,1160,obj,"ADDNewExceptionWindow");
var WindowName=$find('ADDNewExceptionWindow');
WindowName.add_close(ReviewClosePatInsurancePolicy)
{
function ReviewClosePatInsurancePolicy(ownd,args)
{
var Result = args.get_argument();
if(Result)
{
if(Id=="imgtxtTriInsuranceplus")
{
 document.getElementById(GetClientId("txtTerInsurance")).value=Result.PlanName;
}
}
}
}
}

function ADDExceptionClearSelectedPriInsurance(ctrl)
{
var Id=ctrl.id;
if(Id=="imgClearPriInsurance")
{
document.getElementById(GetClientId("txtPriInsurance")).value="";
}
}
function ADDExceptionClearSelectedSecInsurance(ctrl)
{
var Id=ctrl.id;
if(Id=="imgClearSecInsurance")
{
document.getElementById(GetClientId("txtSecInsurance")).value="";
}
}

function ADDExceptionClearSelectedTriInsurance(ctrl)
{
var Id=ctrl.id;
if(Id=="imgClearTriInsurance")
{
 document.getElementById(GetClientId("txtTerInsurance")).value="";
}
}



function ClearSelectedInsurance(ctrl)
{
var Id=ctrl.id;
if(Id=="ctl00_C5POBody_imgClearPriInsurance")
{
document.getElementById(GetClientId("txtPriInsurance")).value="";
}
if(Id=="ctl00_C5POBody_imgClearSecInsurance")
{
document.getElementById(GetClientId("txtSecInsurance")).value="";
}
if(Id=="ctl00_C5POBody_imgClearTriInsurance")
{
 document.getElementById(GetClientId("txtTerInsurance")).value="";

}
}
function GetDateAndTime()
{

    var dt = new Date();
    var now = new Date();
    var utc = (now.getUTCMonth() + 1) + '/' + ("0" + now.getUTCDate()).slice(-2) + '/' + now.getUTCFullYear();
    var minutes;
    var seconds;
    if (now.getUTCMinutes() < 10)
     {
        minutes = '0' + now.getUTCMinutes();
    }
    else 
    {
        minutes = now.getUTCMinutes();
    }
    if (now.getUTCSeconds() < 10)
     {
        seconds = '0' + now.getUTCSeconds();
    }
    else 
    {
        seconds = now.getUTCSeconds();

    }
    utc += ' ' + now.getUTCHours() + ':' + minutes + ':' + seconds;
     document.getElementById(GetClientId("hdnDateAndTime")).value = utc;
}

function MoveToChange()
{
EnableUpdate();
var Dropdown=document.getElementById(GetClientId("ddlMoveTo"));
var MoveTo=document.getElementById(GetClientId("ddlMoveTo")).options[Dropdown.selectedIndex].text;
var Docsubtype=document.getElementById(GetClientId("hdnSubDocType")).value;
if(MoveTo.toUpperCase()=="OPERATOR")
{      
    var InternalResponse = document.getElementById("ctl00_C5POBody_lblInternalResponse").innerText;
    if(InternalResponse.indexOf('*')==-1)
    {
    document.getElementById("ctl00_C5POBody_lblInternalResponse").innerText = document.getElementById("ctl00_C5POBody_lblInternalResponse").innerText +"*";
    document.getElementById("ctl00_C5POBody_lblInternalResponse").style.color ="red";
    document.getElementById("ctl00_C5POBody_lblClientResponse").innerText =document.getElementById("ctl00_C5POBody_lblClientResponse").innerText.replace('*','');
    document.getElementById("ctl00_C5POBody_lblClientResponse").style.color ='black';
    }    
    if(document.getElementById(GetClientId("txtIntelResponse_txtDLC")).value=="")
    {
     document.getElementById(GetClientId("txtIntelResponse_txtDLC")).focus();
     return;
    }
}
if(MoveTo.toUpperCase()!="OPERATOR")
{
    var InternalResponse = document.getElementById("ctl00_C5POBody_lblInternalResponse").innerText;    
    document.getElementById("ctl00_C5POBody_lblInternalResponse").innerText = document.getElementById("ctl00_C5POBody_lblInternalResponse").innerText .replace('*','');
    document.getElementById("ctl00_C5POBody_lblInternalResponse").style.color ="black";
    document.getElementById("ctl00_C5POBody_lblClientResponse").innerText =document.getElementById("ctl00_C5POBody_lblClientResponse").innerText.replace('*','');
    document.getElementById("ctl00_C5POBody_lblClientResponse").style.color ='black';       
}
if(Docsubtype.toUpperCase()=="OFFICE_VISIT")
{
    if(MoveTo.toUpperCase()=="HOSPITALS")
    {
    DisplayErrorMessage('9093032');
    document.getElementById(GetClientId("ddlMoveTo")).focus();
    return;
    }
    if(document.getElementById(GetClientId("txtClientResponse_txtDLC")).value=="")
    {
    var ClientResponse = document.getElementById("ctl00_C5POBody_lblClientResponse").innerText;
    if(ClientResponse.indexOf('*')==-1)
    {
    document.getElementById("ctl00_C5POBody_lblClientResponse").innerText =document.getElementById("ctl00_C5POBody_lblClientResponse").innerText +"*";
    document.getElementById("ctl00_C5POBody_lblClientResponse").style.color ="red";
    document.getElementById("ctl00_C5POBody_lblInternalResponse").innerText =document.getElementById("ctl00_C5POBody_lblInternalResponse").innerText.replace('*','');
    document.getElementById("ctl00_C5POBody_lblInternalResponse").style.color ='black';
    }   
    
     DisplayErrorMessage('9093023');
     document.getElementById(GetClientId("txtClientResponse_txtDLC")).focus();
     return;
    }
    document.getElementById(GetClientId("ddlMoveTo")).selectedIndex = 0;
}
if(Docsubtype.toUpperCase().startsWith("HOSPITAL"))
{
    if(MoveTo.toUpperCase()=="CLINIC")
    {
    DisplayErrorMessage('9093020');
    document.getElementById(GetClientId("ddlMoveTo")).focus();
    return;
    }
    if(document.getElementById(GetClientId("txtClientResponse_txtDLC")).value=="")
    {
     DisplayErrorMessage('9093023');
     document.getElementById(GetClientId("txtClientResponse_txtDLC")).focus();
     return;
    } 
}
 
}
function ResetException()
{
    if(DisplayErrorMessage('110002')==true)
    {
    document.getElementById(GetClientId('btnUpdate')).click();
    }
}
function OpenViewTransaction()
{
var obj=new Array();
obj.push("FromScreen=ReviewException");
var grid=$find("ctl00_C5POBody_grdReviewException");
var MasterTable=grid.get_masterTableView();
if(grid!=null)
{
    for (var i = 0; i < MasterTable.get_dataItems().length; i++) 
    { 
        var gridItemElement = MasterTable.get_dataItems()[i].findElement("chkSelect"); 
        if(gridItemElement.checked==true)
        {
          row=MasterTable.get_dataItems()[i];
          if(document.getElementById(GetClientId("hdnChargeLineItemIDs")).value.indexOf(",")>=0)
          {
          document.getElementById(GetClientId("hdnChargeLineItemIDs")).value=document.getElementById(GetClientId("hdnChargeLineItemIDs")).value+","+MasterTable.getCellByColumnUniqueName(row, "ChargeID").innerHTML;
          }
          else 
          {
          document.getElementById(GetClientId("hdnChargeLineItemIDs")).value=MasterTable.getCellByColumnUniqueName(row, "ChargeID").innerHTML;
          }
        }
    }    
}
obj.push("ChargeLineItemIDs="+document.getElementById(GetClientId("hdnChargeLineItemIDs")).value);
obj.push("AccountNum=" + document.getElementById(GetClientId("txtAccountNumber")).value);
openModal("frmViewTransaction.aspx", 750, 1255, obj, "ct100_ReviewExceptionWindow");
var WindowName=$find('ct100_ReviewExceptionWindow');
WindowName.add_close(CloseViewTransaction)
{
function CloseViewTransaction(ownd,args)
{
return false;
}
}
}
function EnableUpdate()
{
GetDateAndTime();
document.getElementById(GetClientId('btnUpdate')).disabled=false;
}
function OpenViewTransactionException()
{
var obj=new Array();
obj.push("FromScreen=ReviewException");
var grid=$find("grdAddException");
var MasterTable=grid.get_masterTableView();
if(grid!=null)
{
    for (var i = 0; i < MasterTable.get_dataItems().length; i++) 
    { 
        var gridItemElement = MasterTable.get_dataItems()[i].findElement("chkSelect"); 
        if(gridItemElement.checked==true)
        {
          row=MasterTable.get_dataItems()[i];
          if(document.getElementById(GetClientId("hdnChargeLineItemIDs")).value.indexOf(",")>0)
          {
          document.getElementById(GetClientId("hdnChargeLineItemIDs")).value=document.getElementById(GetClientId("hdnChargeLineItemIDs")).value+","+MasterTable.getCellByColumnUniqueName(row, "ChargeID").innerHTML;
          }
          else 
          {
          document.getElementById(GetClientId("hdnChargeLineItemIDs")).value=MasterTable.getCellByColumnUniqueName(row, "ChargeID").innerHTML;
          }
        }
    }    
}
obj.push("ChargeLineItemIDs="+document.getElementById(GetClientId("hdnChargeLineItemIDs")).value);
obj.push("AccountNum=" + document.getElementById(GetClientId("txtAccountNumber")).value);
openModal("frmViewTransaction.aspx", 750, 1255, obj, "ADDNewExceptionWindow");
var WindowName=$find('ADDNewExceptionWindow');
WindowName.add_close(CloseViewTransaction)
{
function CloseViewTransaction(ownd,args)
{
return false;
}
}
}

function CheckCheckBox(ctrl)
{
EnableUpdate();
var Checkbox=ctrl.id;
if(document.getElementById(GetClientId(Checkbox)).checked==true)
{
if(Checkbox=="ctl00_C5POBody_chkAddComments")
{
if(document.getElementById(GetClientId("txtComments_txtDLC")).value=="")
{
document.getElementById(GetClientId(Checkbox)).checked=false;
return;
}
}
if(Checkbox=="ctl00_C5POBody_chkAddReviewComments")
{
if(document.getElementById(GetClientId("txtReviewComments_txtDLC")).value=="")
{
document.getElementById(GetClientId(Checkbox)).checked=false;
return;
}
}
if(Checkbox=="ctl00_C5POBody_chkAddIntelResponse")
{
if(document.getElementById(GetClientId("txtIntelResponse_txtDLC")).value=="")
{
DisplayErrorMessage('9093022');
document.getElementById(GetClientId(Checkbox)).checked=false;
return;
}
}
if(Checkbox=="ctl00_C5POBody_chkAddClientResponse")
{
if(document.getElementById(GetClientId("txtClientResponse_txtDLC")).value=="")
{
DisplayErrorMessage('9093023');
document.getElementById(GetClientId(Checkbox)).checked=false;
return;
}
}
}
}
function ReviewExceptionValidation()
{
EnableUpdate();
var CurrentProcess=document.getElementById(GetClientId("hdnCurrentProcess")).value;
if(CurrentProcess.toUpperCase()== "PENDING_REVIEW" || CurrentProcess.toUpperCase() == "PENDING_COD_REVIEW" || CurrentProcess.toUpperCase() == "CALL")
{
 if(document.getElementById(GetClientId("txtIntelResponse_txtDLC")).value=="")
 {
     DisplayErrorMessage('9093022');
     document.getElementById(GetClientId("txtIntelResponse_txtDLC")).focus();
     return;
 }
 if(document.getElementById(GetClientId("txtReviewComments_txtDLC")).value=="")
 {
     DisplayErrorMessage('9093031');
     document.getElementById(GetClientId("txtReviewComments_txtDLC")).focus();
     return;
 }
 return false;
}
}
function ViewDetails()
{
    if (document.getElementById(GetClientId("hdnObjectType")).value != "WORKSET") 
    {
        var obj = new Array();
        var sWorksetID = document.getElementById(GetClientId("hdnWFObjectID")).value;
        var sHuman = document.getElementById(GetClientId("txtAccountNumber")).value;
        obj.push("WorksetID=" + sWorksetID);
        obj.push("HumanID=" + sHuman);
        var Result = openNonModal("frmNewDisplayObject.aspx", 900, 1200, obj, "ct100_ReviewExceptionWindow");
        if (Result == null)
            return false;
    }
}
function Redirect(sTargetPageURL)
{
     window.location.href = sTargetPageURL ;
}
function LoadException(){
     {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}}