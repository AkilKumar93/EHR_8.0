$(document).ready(function () {
    
    $(top.window.document).find("#btnClosed")[0].hidden = true;
});

function Validation() {
    if (document.getElementById("txtEnterDescription").value.length == 0 && document.getElementById("txtEnterCptCode").value.length == 0) {
        alert("Please enter either the CPT Code or the Description.");
        return false;
    }
}
function AllowAlphabets(e) {
    isIE = document.all ? 1 : 0
    keyEntry = !isIE ? e.which : event.keyCode;
    if (((keyEntry >= '65') && (keyEntry <= '90')) || ((keyEntry >= '97') && (keyEntry <= '122')) || (keyEntry == '46') || (keyEntry == '32') || keyEntry == '45')
        return true;
    else {
        return false;
    }
}
function saveprocedure() {
    var elementref = document.getElementById('trvAllProcedure');

    var checkboxarray = elementref.getElementsByTagName('')
    for (var i = 0; i < checkBoxArray.length; i++) {
        var checkBoxRef = checkBoxArray[i];

        if (checkBoxRef.checked == true) {
            var labelArray = checkBoxRef.parentNode.getElementsByTagName('label');

            Session["ICD"] = labelArray;
            Session["SelectDescription"] = labelArray;

            if (labelArray.length > 0) {
                if
            (checkedValues.length > 0)
                    checkedValues += ',';

                checkedValues += labelArray[i].innerHTML;
                break;
            }
        }
    }
}

function GetCPTValue() {    

    var Result = new Object();
    var options = document.getElementById("chklstcptanddesclist");
    var ckeckBoxs = options.getElementsByTagName('input');
    if (ckeckBoxs != undefined) {
        for (i = 0; i < ckeckBoxs.length; i++) {
            if (ckeckBoxs[i].checked == true) {
                if (Result.SelectedCPT == undefined && document.getElementById("hdnCPT").value == "") {
                    Result.SelectedCPT = options.getElementsByTagName('label')[i].innerText;
                    document.getElementById("hdnCPT").value = options.getElementsByTagName('label')[i].innerText;
                    sessionStorage.setItem("AllProc_SelectCPT", Result.SelectedCPT);
                }
                else {
                    Result.SelectedCPT += '|' + options.getElementsByTagName('label')[i].innerText;
                    document.getElementById("hdnCPT").value += '|' + options.getElementsByTagName('label')[i].innerText;
                    sessionStorage.setItem("AllProc_SelectCPT", Result.SelectedCPT);
                }
            }

            ckeckBoxs[i].checked = false;
        }
        Result.SelectedCPT = document.getElementById("hdnCPT").value;
        sessionStorage.setItem("AllProc_SelectCPT", Result.SelectedCPT);
        document.getElementById("hdnCPT").value = "";
    }
    if (Result.SelectedCPT != null && Result.SelectedCPT != undefined) {
        DisplayErrorMessage("220204");
        $find('btnMoveToProcedure').set_enabled(false);
    }
    window.returnValue = Result;
    returnToParent(Result);
    return true;

}

function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow) oWindow = window.radWindow;
    else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
    return oWindow;
}

function GetCPTValueMoveToProcedure() 
{   
    var Result = new Object();
    var options = document.getElementById("chklstcptanddesclist");
    var ckeckBoxs = options.getElementsByTagName('input');
    if (ckeckBoxs != undefined) 
    {
        for (i = 0; i < ckeckBoxs.length; i++) 
        {
            if (ckeckBoxs[i].checked == true) 
            {
                if (Result.SelectedCPT == undefined && document.getElementById("hdnCPT").value == "")
                {
                    Result.SelectedCPT = options.getElementsByTagName('label')[i].innerText;
                    sessionStorage.setItem("AllProc_SelectCPT", Result.SelectedCPT);
                    document.getElementById("hdnCPT").value = options.getElementsByTagName('label')[i].innerText;
                }
                else 
                {                   
                  Result.SelectedCPT += '|' + options.getElementsByTagName('label')[i].innerText;
                  document.getElementById("hdnCPT").value += '|' + options.getElementsByTagName('label')[i].innerText;
                  sessionStorage.setItem("AllProc_SelectCPT", Result.SelectedCPT);
                    
                }
            }
            
            ckeckBoxs[i].checked = false;

        }
    }
    if (Result.SelectedCPT != null && Result.SelectedCPT != undefined)
    {
        DisplayErrorMessage("220204");
    }
}
function GetCPTValueClose() 
{   
    var Result = new Object();
    var options = document.getElementById("chklstcptanddesclist");
    if(options!=null && options!=undefined)
    {
    var ckeckBoxs = options.getElementsByTagName('input');
    if (ckeckBoxs != undefined) 
    {
        for (i = 0; i < ckeckBoxs.length; i++) 
        {
            if (ckeckBoxs[i].checked == true) 
            {
                if (Result.SelectedCPT == undefined && document.getElementById("hdnCPT").value =="")
                {
                    Result.SelectedCPT = options.getElementsByTagName('label')[i].innerText;
                    document.getElementById("hdnCPT").value = options.getElementsByTagName('label')[i].innerText;
                    sessionStorage.setItem("AllProc_SelectCPT", Result.SelectedCPT);
                }
                else 
                {
                    Result.SelectedCPT += '|' + options.getElementsByTagName('label')[i].innerText;
                    document.getElementById("hdnCPT").value += '|' + options.getElementsByTagName('label')[i].innerText;
                    sessionStorage.setItem("AllProc_SelectCPT", Result.SelectedCPT);
                }
            }
            ckeckBoxs[i].checked = false;
            
        }
        Result.SelectedCPT = document.getElementById("hdnCPT").value;
        sessionStorage.setItem("AllProc_SelectCPT", Result.SelectedCPT);
        document.getElementById("hdnCPT").value = "";
    }
    if (Result.SelectedCPT != null && Result.SelectedCPT != undefined) 
    {
        $find('btnMoveToProcedure').set_enabled(false);
    }
    }
    window.returnValue = Result;
    returnToParent(Result);
    return true;
}

function returnToParent(args) {
    var oArg = new Object();
    oArg.result = args;
    var oWnd = GetRadWindow();
    if (oWnd != null) {
        oWnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close);
        if (oArg.result) {
            oWnd.close(oArg.result);
        }
        else {
            oWnd.close(oArg.result);
        }
    }
    else {
        $(top.window.document).find('#btnClosed')[0].click(oArg.result);
         {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
    }
}

function Close(sender,args) 
{
    var Status = $find("btnMoveToProcedure")._enabled;
    if (Status != undefined && Status == true) 
    {
        if (document.getElementById("hdnMessageType").value == "") 
        {
            args.set_cancel(true);
            DisplayErrorMessage('220108');
             {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
            sender.set_autoPostBack(false);
        }
        else if (document.getElementById("hdnMessageType").value == "Yes") 
        {
            GetCPTValue();
            document.getElementById("hdnMessageType").value = "";
        }
        else if (document.getElementById("hdnMessageType").value == "No") 
        {
            document.getElementById("hdnMessageType").value = ""
            $find("btnMoveToProcedure")._enabled = "false";
            $(top.window.document).find('#btnClosed')[0].click();
             {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
            self.close();
        }
        else if (document.getElementById("hdnMessageType").value == "Cancel") 
        {
           
            document.getElementById("hdnMessageType").value = "";
             {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
        }
    }
    else 
    {
        GetCPTValueClose();
    }

}

function OnClientSearchClick()
{
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
}

function OnClientMoveToProcedureClick() {
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
}
function ChkBoxSelected()
{
    var chkList = document.getElementById("chklstcptanddesclist");
    if ($('#chklstcptanddesclist input:checked').length > 0)
        $find('btnMoveToProcedure').set_enabled(true);
    else
        $find('btnMoveToProcedure').set_enabled(false);
}