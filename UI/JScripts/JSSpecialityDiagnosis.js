

function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow) oWindow = window.radWindow;
    else if (window.frameElement != null && window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
    return oWindow;
}

function OpenDiagnosis() {
    var TreeView = $find("trvCodeLibrary");
    var SelectedItems = TreeView.get_checkedNodes();
    var Result = new Object();

    for (var i = 0; i < SelectedItems.length; i++) {
        if (Result.SelectedICD == null)
            Result.SelectedICD = SelectedItems[i].get_text();
        else
            Result.SelectedICD += '$' + SelectedItems[i].get_text();
    }

    window.returnValue = Result;
    self.close();
    return true;
}

function btnSearch_ClientClicked(sender, args) {
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
}

function trvCodeLibrary_NodeClickingClient(sender, args) 
{
    currentNode = args.get_node();
    currentNode.set_checked(!currentNode.get_checked());
    $find("btnMoveToSelectedAssessment").set_enabled(true)
}

function trvCodeLibrary_NodeCheckingClient(sender, args) 
{
    currentNode = args.get_node();
    currentNode.select();
    $find("btnMoveToSelectedAssessment").set_enabled(true)
}


function CloseWindow() {
    var result = new Object();
    result.medList = document.getElementById("finalProblemList").value;
    returnToParent(result);
}


function returnToParent(args) {
    var oWnd = GetRadWindow();
    if (oWnd != null) {
        oWnd.close(args);
    }
    else {
        $(top.window.document).find('#btnClosed')[0].click(args);
         {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
    }
}


function CloseDiag() {
    var Own = GetRadWindow();
    Own.add_close(CloseWindowCross);
}
function CloseWindowCross() {

    var result = new Object();
    result.medList = document.getElementById("finalProblemList").value;
    var Own = GetRadWindow();
    Own.returnValue = result;
    returnToParent(result);
}
function ParentHiddenField() {


    window.parent.theForm.ctl00$HiddenForCross.value = document.getElementById("finalProblemList").value;

}

function WindowCloseForPBList() {
    var Own = GetRadWindow();
    Own.close();
}
function txtICDCode_OnKeyPress(sender, args) {
var txtbox=sender._textBoxElement
	if(txtbox.value.length<10)
	{
	    if ((args._keyCode > 47 && args._keyCode < 58) || args._keyCode == 46 || args._keyCode == 101 || args._keyCode == 118) {
        args._cancel = false;
    }
    else {
        args._cancel = true;
    }
    }
    else {
        args._cancel = true;
    }
    if(args._keyCode==13)
    {
    document.getElementById("btnSearch").click();
    }
}
function txtDescription_OnKeyPress(sender, args) {
    if(args._keyCode==13)
    {
    document.getElementById("btnSearch").click();
    }
}
function ShowLoadCursor()
{
 document.getElementById("divLoading").style.display = "block";
}
	
	function btnMoveToSelectedAssessment_Clicked(sender,args)
	{
	    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
	}


function btnQuit_Clicked(sender, args)
{
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
    if ($find("btnMoveToSelectedAssessment")._enabled == true || document.getElementById("hdnEandMIcd").value != "") 
    {
        if (document.getElementById("hdnEandMCode").value != "" && $find("btnMoveToSelectedAssessment")._enabled == true)
        {
            if (document.getElementById("hdnMessageType").value == "")
            {
                args.set_cancel(true);
                DisplayErrorMessage('220206');
                 {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
                sender.set_autoPostBack(false);
            }
            else if (document.getElementById("hdnMessageType").value == "Yes") 
            {
                $find("btnMoveToSelectedAssessment").click();
                DisplayErrorMessage('220205');
                 {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
                document.getElementById("hdnMessageType").value = "";
                $(top.window.document).find("#btnClosed")[0].click();
            }
            else if (document.getElementById("hdnMessageType").value == "No") 
            {
                document.getElementById("hdnMessageType").value = ""
                // $find("btnMoveToSelectedAssessment")._enabled = "false";
                $find("btnMoveToSelectedAssessment").set_enabled(false)
                 {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
                $(top.window.document).find("#btnClosed")[0].click();
            }
            else if (document.getElementById("hdnMessageType").value == "Cancel") 
            {
                document.getElementById("hdnMessageType").value = "";
                 {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
            }
        }
        else if (document.getElementById("hdnEandMCode").value == "" && $find("btnMoveToSelectedAssessment")._text != "Move to manage problem list") {            
            if (document.getElementById("hdnMessageType").value == "") 
            {
                args.set_cancel(true);
                DisplayErrorMessage('220206');
                 {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
                sender.set_autoPostBack(false);
            }
            else if (document.getElementById("hdnMessageType").value == "Yes") 
            {
                $find("btnMoveToSelectedAssessment").click();
                DisplayErrorMessage('220205');
                 {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
                document.getElementById("hdnMessageType").value = "";
                $(top.window.document).find("#btnClosed")[0].click();
            }
            else if (document.getElementById("hdnMessageType").value == "No") 
            {
                document.getElementById("hdnMessageType").value = ""
                $find("btnMoveToSelectedAssessment").set_enabled(false)
                 {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
                $(top.window.document).find("#btnClosed")[0].click();
            }
            else if (document.getElementById("hdnMessageType").value == "Cancel") 
            {
                document.getElementById("hdnMessageType").value = "";
                 {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
            }
        }
        else if ($find("btnMoveToSelectedAssessment")._text == "Move to manage problem list") 
        {
            if ($find("btnMoveToSelectedAssessment")._enabled == true) 
            {
                if (document.getElementById("hdnMessageType").value == "") 
                {
                    document.getElementById("hdnMessageType").value == "Yes";
                    args.set_cancel(true);
                    DisplayErrorMessage('220206');
                     {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
                    sender.set_autoPostBack(false);
                }
                else if (document.getElementById("hdnMessageType").value == "Yes") 
                {
                    $find("btnMoveToSelectedAssessment").click();
                    DisplayErrorMessage('220205');
                     {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
                    document.getElementById("hdnMessageType").value = "";
                    $(top.window.document).find("#btnClosed")[0].click();
                }
                else if (document.getElementById("hdnMessageType").value == "No") 
                {
                    document.getElementById("hdnMessageType").value = ""
                    $find("btnMoveToSelectedAssessment").set_enabled(false)
                     {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
                    $(top.window.document).find("#btnClosed")[0].click();
                }
                else if (document.getElementById("hdnMessageType").value == "Cancel") 
                {
                    document.getElementById("hdnMessageType").value = "";
                     {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
                }
            }
            else 
            {
                 {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
                $(top.window.document).find("#btnClosed")[0].click();
            }

        }
        if (document.getElementById("hdnEandMIcd").value != "" && document.getElementById("hdnEandMCode").value != "") 
        {
            sender.set_autoPostBack(true);
        }
    }
    else 
    {
        $(top.window.document).find("#btnClosed")[0].click();
    }

}

function openMutuallyExclusive(inc, sQuestionList, sSelectedQuestion, QueryHierarchy, sSelected_ICDs) 
{
    var oWnd = GetRadWindow();
    if (oWnd != null && oWnd != undefined) {
        var childWindow = oWnd.BrowserWindow.radopen("frmMutuallyExclusive.aspx?key=" + "openMutuallyExclusive" + inc + "&QuestionList=" + sQuestionList + "&selectedQuestion=" + sSelectedQuestion + "&queryHierarchy=" + QueryHierarchy + "&selected_ICDs=" + sSelected_ICDs, 355, 775, null, 'MessageWindow');
        SetRadWindowProperties(childWindow, 355, 775);
        childWindow.set_behaviors(Telerik.Web.UI.WindowBehaviors.None);
        childWindow.add_close(OnClientCloseQuestions);
    }
}

function OnClientCloseQuestions(oWindow, args) {

    if (document.getElementById('btnInvisible') != null)
        document.getElementById('btnInvisible').click();
    else
        self.close();
    return false;
}
function openMutuallyExclusiveforQuestion(inc, sQuestionList, sSelectedQuestion, QueryHierarchy, sSelected_ICDs) {
    window.location.href = "frmMutuallyExclusive.aspx?key=" + inc + "&QuestionList=" + sQuestionList + "&selectedQuestion=" + sSelectedQuestion + "&queryHierarchy=" + QueryHierarchy + "&selected_ICDs=" + sSelected_ICDs;
}

function closewindow() {
    var oWindow = null;
    if (window.radWindow)
        oWindow = window.radWindow;
    else if (window.frameElement.radWindow)
        oWindow = window.frameElement.radWindow;
    if (oWindow != null)
        oWindow.close();
}

function openMultiSelectQuestion(inc, sQuestionList, sSelectedQuestion, QueryHierarchy, sSelected_ICDs) {
    var obj = new Array();
    window.location.href = "frmMultiSelect.aspx?key=" + "openMultiSelect" + inc + "&QuestionList=" + sQuestionList + "&selectedQuestion=" + sSelectedQuestion + "&queryHierarchy=" + QueryHierarchy + "&selected_ICDs=" + sSelected_ICDs;
}

function openMultiSelect(inc, sQuestionList, sSelectedQuestion, QueryHierarchy, sSelected_ICDs)
 {
    var oWnd = GetRadWindow();
    if (oWnd != null && oWnd != undefined) {
        var childWindow = oWnd.BrowserWindow.radopen("frmMultiSelect.aspx?key=" + "openMultiSelect" + inc + "&QuestionList=" + sQuestionList + "&selectedQuestion=" + sSelectedQuestion + "&queryHierarchy=" + QueryHierarchy + "&selected_ICDs=" + sSelected_ICDs, "MessageWindow");
        SetRadWindowProperties(childWindow, 355, 775);
        childWindow.set_behaviors(Telerik.Web.UI.WindowBehaviors.None);
        childWindow.add_close(OnClientCloseFormView);

        var windowName = $find('RadWindowForDiag');

        if (windowName != null)
            windowName.close();
    }

}
function OnClientCloseFormView(oWindow, args) {
    if (document.getElementById('btnInvisible') != null)
        document.getElementById('btnInvisible').click();
}

function SetRadWindowProperties(childWindow, height, width) {
    childWindow.SetModal(true);
    childWindow.set_visibleStatusbar(false);
    childWindow.setSize(width, height);
    childWindow.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close | Telerik.Web.UI.WindowBehaviors.Move);
    childWindow.set_iconUrl("Resources/16_16.ico");
    childWindow.set_keepInScreenBounds(true);
    childWindow.set_centerIfModal(true);
    childWindow.center();
}
function OnSpecialityLoad()
{
    
    if (window.innerHeight >= 490)
    {
        document.getElementById("pntTree").style.height = "400px";
        document.getElementById("trvCodeLibrary").style.height = "365px";
        document.cookie = "trvCodeLibHgt=360";
        document.cookie = "trvCodeLibWdt=590";
    }
    else if (window.innerHeight >= 444 && window.innerHeight <= 489) {

        document.getElementById("pntTree").style.height = "320px";
        document.getElementById("trvCodeLibrary").style.height = "285px";
        document.cookie = "trvCodeLibHgt=280";
        document.cookie = "trvCodeLibWdt=685";
    }
    else
    {
        document.getElementById("pntTree").style.height = "400px";
        document.getElementById("trvCodeLibrary").style.height = "364px";
        document.cookie = "trvCodeLibHgt=210";
        document.cookie = "trvCodeLibWdt=640";
    }
    { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
}