function  WillingCancelGrid()
 {
  var index=parseInt(document.getElementById("hdnWillingGridIndex").value);
 var dt=new Date();
var now=new Date();
var utc=(now.getUTCMonth()+1)+'/'+("0" +now.getUTCDate()).slice(-2)+'/'+now.getUTCFullYear();
var minutes;
var seconds;
if(now.getUTCMinutes()<10)
{
minutes='0'+now.getUTCMinutes();
}
else
{
minutes=now.getUTCMinutes();
}
if(now.getUTCSeconds()<10)
{
seconds='0'+now.getUTCSeconds();
}
else
{
seconds=now.getUTCSeconds();

}
utc+=' '+now.getUTCHours()+':'+minutes+':'+seconds;
document.getElementById(GetClientId("hdnLocalTime")).value=utc;

  var grdWillingPatientList=$find('grdWillingPatientList');
 var MasterTable=grdWillingPatientList.get_masterTableView();
row=MasterTable.get_dataItems()[index];
var result=new Object();
 document.getElementById(GetClientId("hdnApptDate")).value = MasterTable.getCellByColumnUniqueName(row, "AppointmentDateandTime").innerHTML;
 document.getElementById(GetClientId("hdnFacilityName")).value = MasterTable.getCellByColumnUniqueName(row, "Facility").innerHTML;
document.getElementById(GetClientId("hdnProviderName")).value = MasterTable.getCellByColumnUniqueName(row, "Provider").innerHTML;
document.getElementById(GetClientId("hdnHumanID")).value= MasterTable.getCellByColumnUniqueName(row, "Account#").innerHTML;
document.getElementById(GetClientId("hdnEncounterID")).value = MasterTable.getCellByColumnUniqueName(row, "EncounterID").innerHTML;
document.getElementById(GetClientId("hdnPhysicianID")).value = MasterTable.getCellByColumnUniqueName(row, "PhysicianID").innerHTML;
document.getElementById(GetClientId("hdnApptTime")).value = MasterTable.getCellByColumnUniqueName(row, "Time").innerHTML;
var result=new Object();
if(window.opener)
{ 
window.opener.returnValue = result;
}
 window.returnValue=result;
 returnToParent(result)
 } 
 
 function grdWillingCancelList_RowClick(sender,args)
{
document.getElementById('hdnWillingGridIndex').value=args._itemIndexHierarchical;
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
