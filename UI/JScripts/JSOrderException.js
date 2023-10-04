function btn_Match_Clicked(sender, eventArgs)
{ { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();} }
function OnMatch()
{  {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();} DisplayErrorMessage('7100008'); }


function enableField(ChkValue)
    {
    var  pcontrol = document.getElementById(ChkValue);
     if(pcontrol.checked==true)
           {
             document.getElementById("chkSearchbyfacility").checked=false;
             document.getElementById("chkShowAllResults").checked=false;
             document.getElementById("pnlSearchbyfacility").disabled=true;
             document.getElementById("cboFacilityList").SelectedIndex=0;
             document.getElementById("pnlFindbyPatient").enabled=true;
           }
    }
    function Result(iResultMasterID)
    {
    
    var obj=new Array();
obj.push("Result_Master_ID="+iResultMasterID);
obj.push("Order_ID=0");
obj.push("strScreenName=ORDER EXCEPTION");
        obj.push("bMovetonextprocess=false");
//Jira CAP-1144
    //setTimeout(function(){GetRadWindow().BrowserWindow.openModal("frmLabResult.aspx",750,845,obj,"MessageWindow");},0);
        setTimeout(openNonModal("frmLabResult.aspx", 780, 1250, obj), 0);
    }
      function FindPatient()
     {
         var obj=new Array();
         var result = openModal("frmFindPatient.aspx", 251, 1200, obj, 'MessageWindow');
         var winObj=$find('MessageWindow');
         winObj.add_close(OnClientCloseOrderManagement);
     }
     function OnRowSelected(sender, eventArgs) 
     {
       var rowindex = eventArgs.get_itemIndexHierarchical();
       var accno=eventArgs.get_gridDataItem()._element.cells[0].innerHTML;
       var patName=eventArgs.get_gridDataItem()._element.cells[7].innerHTML;
       var DOB=eventArgs.get_gridDataItem()._element.cells[8].innerHTML;
       var txtGen=eventArgs.get_gridDataItem()._element.cells[9].innerHTML;
       if(accno!="&nbsp;")
       {
            $find('txtAccountNumber').set_value(accno);
            $find('txtPatientName').set_value(patName);
            $find('txtDOB').set_value(DOB);
            $find('txtGender').set_value(txtGen);
       }
    }
     function OnClientCloseOrderManagement(oWindow, args) 
    {
       var arg = args.get_argument();
       if (arg)
       {
        document.getElementById(GetClientId("hdnHumanID")).value=arg.HumanId;
        document.getElementById('InvisibleButton').click();           
         
       }
 
    }
    function GetRadWindow() 
{
     var oWindow = null;
     if (window.radWindow) oWindow = window.radWindow;
     else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
     return oWindow;
}
 function HandleOnCheck()
    {
            var target = event.target || event.srcElement;
            var chkLst = document.getElementById('chklPhysicianlist').getElementsByTagName('input');
            for(var item=0;item<chkLst.length;item++)
            {
                if(target.id!=chkLst[item].id)
                chkLst[item].checked=false;
            }
    }
    
function RadWindowClose()
{
//Jira CAP-1144
        //var oWindow = null;
        //  if (window.radWindow)
        //       oWindow = window.radWindow;
        //  else if (window.frameElement.radWindow)
        //       oWindow = window.frameElement.radWindow;
        //  if(oWindow!=null)
    //   oWindow.close();
    window.close();
}

function txtToolTip(txtname)
{
var txtTool=document.getElementById(txtname); 
if(txtTool.value.length>0)
{
txtTool.title=txtTool.value;
}
}

function Clear()
{
    var IsClearAll=DisplayErrorMessage('200005');
	if(IsClearAll==true)
	{
        return true;
    }
    return false;
}

function btnFindPatient_Clicked(sender,args)
	{
	  var obj=new Array();
	  var result = openModal("frmFindPatient.aspx", 251, 1200, obj, 'MessageWindow');
         var winObj=$find('MessageWindow');
         winObj.add_close(OnClientCloseOrderManagement);
	}
	
	function btnViewPendingOrder_Clicked(sender,args)
	{
	     var obj=new Array();
         var result=openModal("frmOrderManagement.aspx",650,1130,obj,'MessageWindow');
	}
	
	function checkRadioButton()
	{
	    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
	document.getElementById('SearchClick').click();
	}
	function check()
	{
	    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
	}
	
	function  checkOnclcik()    
	{
	if(document.getElementById('chkNoOrders').checked==true)
	   deselect();
	}
	function deselect()
 {
 
   var masterTable = $find("grdOutstandingOrders").get_masterTableView();
   var row = masterTable.get_dataItems();
   for (var i = 0; i < row.length; i++)
   {
     masterTable.get_dataItems()[i].set_selected(false);
   }
}

	function btnSearch_Clicked(sender,args)
	{
	    
	    if ($telerik.findDatePicker("frmDate")._element.value != "" && $telerik.findDatePicker("toDate")._element.value == "") {//BugID:46054
	        DisplayErrorMessage('7100015');
	        sender.set_autoPostBack(false);
	    }
	    else {
	        sender.set_autoPostBack(true);
	        { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
	    }
	    
	}

function btnMatchOrders_Clicked(sender,args)
	{
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
	
	}


	
	function grdUnassignedResults_OnRowClick(sender,args)
	{
	    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
	}

	function LabExcepLoad() {
	    { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
	}
	