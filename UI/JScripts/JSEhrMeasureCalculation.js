function btnClose_Clicked(sender,args)
	{
         var oWindow = null;
          if (window.radWindow)
               oWindow = window.radWindow;
          else if (window.frameElement.radWindow)
               oWindow = window.frameElement.radWindow;
          if(oWindow!=null)
           oWindow.close();
	}

	
function OpenPDF()
{
var obj=new Array();
obj.push("SI="+document.getElementById('SelectedItem').value);
obj.push("Location="+"DYNAMIC");
obj.push("PageTitle="+"EHR Measure Calculation");
setTimeout(function(){GetRadWindow().BrowserWindow.openModal('frmPrintPDF.aspx',835,900,obj,"MeasureCalculationWindow");},0);
}

function GetRadWindow() 
{
     var oWindow = null;
     if (window.radWindow) oWindow = window.radWindow;
     else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
     return oWindow;
}

function GenerateMeasures()
{
    $("#btnGenerate").click();
    return true;
}
function DateValidattion()
{
var FromDate=document.getElementById ('dtpFromDate').value;
var ToDate=document.getElementById('dtpToDate').value;
if(FromDate =="" && ToDate =="")
{
DisplayErrorMessage('380006');
}
}
function ClearAllValues()
{
if(DisplayErrorMessage('300301'))
{
var today = new Date();
var year=today.getFullYear()+"-01"+"-02";
$find("dtpToDate").set_selectedDate(new Date(today));
$find("dtpFromDate").set_selectedDate(new Date(year));;
$find("txtClearedYes").clear();
$find("txtClearedNo").clear();
var tableView = $find("grdMeasureCalculation").get_masterTableView();
var dataItems = tableView.get_dataItems();
tableView.set_dataSource([]); 
tableView.dataBind(); 
$find("dtpReportingDate").set_selectedDate(new Date(today));
$find("dtpStartDate").set_selectedDate(new Date(today));
$find("txtBeforeReporting").clear();
}
}