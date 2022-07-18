function btnClear(btnId, sSearchType)
{
    var btnClear = document.getElementById(btnId);    
    
     if (sSearchType == "ProblemList")
     {
        document.getElementById("lblError").visible = false;
        $find("txtEnterDescription").clear();
        $find("txtICDCode").clear();
        $find("chklstSearchICD").Items.clear();        
     }
     else
     {        
        $find("grdMedicationList").Items.clear();
        $find("lblResult").clear();                     
     }

     $find("btnSearch").disable();            
}

function closeMedication()
{
    var result = new Object();
    result.finalProbList = document.getElementById("finalProblemList").value;
    result.medList = document.getElementById("selectedMedicationList").value;
    result.medallrgyList = document.getElementById("selectedMedicationList").value;
    result.iProblemList = document.getElementById("iProblemList").value;
    result.ilistproblem = document.getElementById("ilstproblem").value;
    result.Rule = document.getElementById("hdnRule").value;
     result.LabResult=document.getElementById("hdnLabResult").value;
    returnToParent(result);    
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
        oWnd.close(oArg.result);
    else 
        oWnd.close(oArg.result);
}

 
function btnSearchMed_Clicked(sender,args)
{
 var txtbox=$find("txtMedicationName");
 if (txtbox._text.trim() == "") {
     if (document.getElementById('lblMedicationName') != null && (document.getElementById('lblMedicationName').getAttribute("descName") == "GenerateListMedication" || document.getElementById('lblMedicationName').getAttribute("descName") == "MedicationAllergy")) {
         DisplayErrorMessage('7040006');
         sender.set_autoPostBack(false);
     }
     else {
         DisplayErrorMessage('7040005');
         sender.set_autoPostBack(false);
     }
 }
 else {
     document.getElementById("divLoading").style.display = "block";
     sender.set_autoPostBack(true);
 }
}

	function btnSearch_ClientClicked(sender,args)
	{
	 document.getElementById("divLoading").style.display="block";
	}

 function btnClearMed_Clicked(sender,args)
	{
	    $find("txtMedicationName").clear();
	    var view = document.getElementById('grdMedicationList').control.MasterTableView;
	    view.set_dataSource([]);
	    view.dataBind();
	    document.getElementById('grdMedicationList').control.MasterTableView.HeaderRow.hidden=true;
	    document.getElementById('lblResult').textContent="";
	}

function btnClearAll_ClientClicked(sender,args)
{
    $find("txtEnterDescription").clear();
    $find("txtICDCode").clear();
    document.getElementById("lblError").visible = false;
}
     