function ClearCheckBoxes(ControlID, FromScreen) {
    var Type = document.getElementsByTagName("INPUT");
    for (var i = 0; i < Type.length; i++) {
        if (Type[i].type == "radio") {
            if (FromScreen == "GrowthChart") {
                { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
                if (Type[i].value != ControlID) {
                    document.getElementById(Type[i].id).checked = false;
                }
            }
            else if (FromScreen == "FlowSheet") {
                if (Type[i].value != ControlID) {
                    document.getElementById(Type[i].id).checked = false;
                }
                if (ControlID == "rdRange") {
                    if (document.getElementById(Type[i].id).checked == true) {
                        document.getElementById('fromDate').disabled = false;
                        document.getElementById('todate').disabled = false;
                        $find('fromDate').set_enabled(true);
                        $find('fromDate').clear();
                        $find("fromDate")._dateInput.clear();
                        $find('todate').set_enabled(true);
                        $find('todate').clear();
                        $find('todate')._dateInput.clear();
                    }
                }
                else {
                    document.getElementById('fromDate_dateInput').value = '';
                    document.getElementById('todate_dateInput').value = '';
                    document.getElementById('fromDate').disabled = true;
                    document.getElementById('todate').disabled = true;
                    $find('fromDate').set_enabled(false);
                    $find('todate').set_enabled(false);
                    $find('fromDate').clear();
                    $find('todate').clear();
                    $find("fromDate")._dateInput.set_invalid(false);
                    $find("todate")._dateInput.set_invalid(false);
                }
            }
        }
    }
}

function CellSelected(sender, eventArgs) {
    var obj = new Array();
    var RowIndex = eventArgs._itemIndexHierarchical;
    var grid = $find("grdFlowSheet");
    var MasterTable = grid.get_masterTableView();
    var row = MasterTable.get_dataItems()[RowIndex];
    var Category = MasterTable.getCellByColumnUniqueName(row, "Category").innerHTML;
    if (sender.get_selectedCellsIndexes()[0].endsWith('&column') == true) {
        var Checkbox = document.getElementsByTagName('INPUT');
        var checkedName;
        var PhyId;
        var FromDate = new Date();
        var ToDate = new Date();
        for (var i = 0; i < Checkbox.length; i++) {
            if (Checkbox[i].type == "radio") {
                if (Checkbox[i].value == "rdAll") {
                    if (document.getElementById(Checkbox[i].id).checked == true) {
                        checkedName = "ALL";
                        break;
                    }
                }
                else if (Checkbox[i].value == "rdLast3Month") {
                    if (document.getElementById(Checkbox[i].id).checked == true) {
                        checkedName = "LAST3";

                        FromDate.setMonth(FromDate.getMonth() - 3);
                        ToDate.setDate(ToDate.getDate() + 1);
                        FromDate = FromDate.format("yyyy-MM-dd");
                        ToDate = ToDate.format("yyyy-MM-dd");
                        break;
                    }
                }
                else if (Checkbox[i].value == "rdLast6Month") {
                    if (document.getElementById(Checkbox[i].id).checked == true) {
                        checkedName = "LAST6";
                        FromDate.setMonth(FromDate.getMonth() - 6);
                        ToDate.setDate(ToDate.getDate() + 1);
                        FromDate = FromDate.format("yyyy-MM-dd");
                        ToDate = ToDate.format("yyyy-MM-dd");
                        break;
                    }
                }
                else if (Checkbox[i].value == "rdLast12Month") {
                    if (document.getElementById(Checkbox[i].id).checked == true) {
                        checkedName = "LAST12";
                        FromDate.setMonth(FromDate.getMonth() - 12);
                        ToDate.setDate(ToDate.getDate() + 1);
                        FromDate = FromDate.format("yyyy-MM-dd");
                        ToDate = ToDate.format("yyyy-MM-dd");
                    }
                }
                else if (Checkbox[i].value == "rdRange") {
                    if (document.getElementById(Checkbox[i].id).checked == true) {
                        if (document.getElementById("fromDate").value == "" && document.getElementById("todate").value == "") {
                            checkedName = "ALL";
                        }
                        else {
                            checkedName = "DATE";
                            if (document.getElementById("fromDate").value != "") {
                                FromDate = document.getElementById("fromDate").value;
                            }
                            if (document.getElementById("todate").value != "") {
                                ToDate = document.getElementById("todate").value;
                            }
                        }

                    }
                }
            }
        }

        PhyId = document.getElementById("hdnPhyId").value;
       
        var objWindow = $find('ModalWindow');
        setTimeout(function () {
            objWindow.BrowserWindow.radopen('frmFlowSheetGraph.aspx?Selected=' + checkedName + "&FTN=" + document.getElementById('cboFlowSheet').value + "&FD=" + FromDate + "&TD=" + ToDate + "&PhyID=" + PhyId + "&Category=" + Category, 'ModalWindow');
            objWindow.setSize(950, 700);
            objWindow.set_title(objWindow.get_title());
            objWindow.set_showContentDuringLoad(false);
            objWindow.set_reloadOnShow(true);
            objWindow.SetModal(true);
            objWindow.set_visibleStatusbar(false);
            objWindow.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close | Telerik.Web.UI.WindowBehaviors.Move);
            objWindow.set_iconUrl("Resources/16_16.ico");
            objWindow.set_keepInScreenBounds(true);
            objWindow.set_centerIfModal(true);
            objWindow.center();
            sender.clearSelectedCells();
        }, 0);
    }
   
    return false;
}
function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow) oWindow = window.radWindow;
    else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
    return oWindow;
}
function OpenFlowSheetManager() {
    var obj = new Array();
    var result = openModal("frmFlowSheetManager.aspx", 550, 840, obj, "ModalWindow");
    var WindowName = $find('ModalWindow');
    WindowName.add_close(OnclientCloseFlowSheetManager);
    return false;
}



function btnClearAll_Clicked(sender, args) {

    var IsClearAll = DisplayErrorMessage('200005');
    if (sender != undefined) {
        sender.set_autoPostBack(false);
    }
    if (IsClearAll == true) {

      

        document.getElementById('rdAll').checked = true;

        document.getElementById('rdRange').checked = false;
        document.getElementById('rdLast3Month').checked = false;
        document.getElementById('rdLast6Month').checked = false;
        document.getElementById('rdLast12Month').checked = false;

        document.getElementById('fromDate_dateInput').value = '';
        document.getElementById('todate_dateInput').value = '';

        $find('fromDate').set_enabled(false);
        $find('todate').set_enabled(false);

        $find("fromDate")._dateInput.set_invalid(false);
        $find("todate")._dateInput.set_invalid(false);

        var combo = $find('cboFlowSheet');
        var item = combo.findItemByText(' ');
        if (item) {
            item.select();
        }
        $find("cboPhysician").clearSelection();
        
        //if (document.getElementById('cboPhysician').disabled == false) {
        //    $find("cboPhysician").clearSelection();
        //}

       

        try {
            var tableView = $find('grdFlowSheet').get_masterTableView();

            if (tableView != null) {
                document.getElementById('IsFromClear').value = 'Y';
                var dataItems = tableView.get_dataItems();
                for (var i = 0; i < dataItems.length; i++) {
                    tableView.deleteItem(dataItems[i].get_element());
                }
            }
        } catch (e) {
            document.getElementById('IsFromClear').value = 'Y';
        }
        if (sender != undefined) {
            sender.set_autoPostBack(false);
        }
    }
}

function OnClientItemSelectedIndexChanging(sender, args) {

    if (args.get_item().get_checked() == false) {
        args.get_item().set_checked(true);
    }
    else {
        args.get_item().set_checked(false);
    }
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
}
function OnClientItemSelectedIndexChangingFlowSheet(sender, args) {

    if (args.get_item().get_checked() == false) {
        args.get_item().set_checked(true);
    }
    else {
        args.get_item().set_checked(false);
    }
    EnableSave();
}
function OnClientItemChecked(sender, args) {
    if (args.get_item().get_checked() == false) {
        args.get_item().set_selected(args.get_item().set_selected(true));
    }
    else {
        args.get_item().set_selected(args.get_item().set_selected(false));
    }
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
}
function OpenPDF(filename, sFaxSubject) {
    var obj = new Array();
    obj.push("SI=" + filename);
    obj.push("Location=" + "CHART");
    obj.push("FaxSubject=" + sFaxSubject);
    var objWindow = GetRadWindow();
    setTimeout(function () {
        objWindow.BrowserWindow.openModal("frmPrintPDF.aspx", 750, 900, obj, "PDFWindow"); 
    }
, 0);
}
function EnableSave() {
    document.getElementById('btnAddandGenerate').disabled = false;
    document.getElementById('btnAdd').disabled = false;

}
function CloseWindow(sender, args) {
    if (document.getElementById('btnOk').control._enabled == true) {
        sender.set_autoPostBack(false);
        if (document.getElementById("hdnMessageType").value == "") {
            DisplayErrorMessage('230006');
        }
        else
            if (document.getElementById("hdnMessageType").value == "Yes") {
                document.getElementById('btnOk').click();
                document.getElementById("hdnMessageType").value = "";
            }
            else if (document.getElementById("hdnMessageType").value == "No") {
                document.getElementById("hdnMessageType").value = "";
                self.close();
            }
            else {
                document.getElementById("hdnMessageType").value = "";
                return false;
            }
    }
    else {
        self.close();
    }
}
function btnCancel_Clicked() {
    if (document.getElementById('btnOk').enabled == true) {

        if (document.getElementById("hdnMessageType").value == "") {
            DisplayErrorMessage('230006');
        }
        else
            if (document.getElementById("hdnMessageType").value == "Yes") {
                document.getElementById('btnOk').click();
                document.getElementById("hdnMessageType").value = "";
            }
            else if (document.getElementById("hdnMessageType").value == "No") {
                document.getElementById("hdnMessageType").value = "";
                self.close();
            }
            else {
                document.getElementById("hdnMessageType").value = "";
                return false;
            }
        return false;
    }
    else {
        self.close();
    }
}
function OpenFlowSheet(FlowSheetName) {
    var Result = new Object();
    Result.IsAddGeneratedClicked = true;
    Result.SelectedItem = FlowSheetName;
    DisplayErrorMessage('200028');
    returnToParent(Result);

}

function DeleteItem(value) {

    var Continue = DisplayErrorMessage('102006');

    if (Continue == undefined) {
        document.getElementById('DelID').value = value;
        return;
    }
    else if (Continue) {
        { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
        document.getElementById('InvisibleButton').click();
    }
    else {
         {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
        return;
    }
}
function Close() {
    var GetResult = new Object();
    GetResult.hdnSearchResults = document.getElementById('hdnSearchResults').value;
    returnToParent(GetResult);
}
function CloseSearchAll() {
    var GetResult = new Object();
    var returnValue = DisplayErrorMessage('6400011');
    GetResult.hdnSearchResults = document.getElementById('hdnSearchResults').value;
    returnToParent(GetResult);
}

function FlowSheetManagerClearAll() {

    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}

    var btnClearAll = document.getElementById('btnClearAll').value;

    var IsClearAll;

    if (btnClearAll == "Clear All") {
        IsClearAll = DisplayErrorMessage('200005');
    } else {
        IsClearAll = DisplayErrorMessage('020008');
    }

    if (IsClearAll == true) {
        document.getElementById('InvisibleButtonClear').click();
    } else if (IsClearAll == false) {
        document.getElementById('btnAddandGenerate').disabled = false;
        document.getElementById('btnAdd').disabled = false;
         {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
    }
    else {
        document.getElementById('btnAddandGenerate').disabled = false;
        document.getElementById('btnAdd').disabled = false;
    }
}


function ShowLoading() {
    document.getElementById("divLoading").style.display = "block";
}
function OnclientCloseFlowSheetManager(oWindow, args) {
    var arg = args.get_argument();
    if (arg) {
        var result = arg;

        if (result.IsAddGeneratedClicked == true) {
            document.getElementById('SelectedItem').value = result.SelectedItem;

            var combo = $find('cboFlowSheet');
            var item = combo.findItemByText(result.SelectedItem);
            if (item) {
                item.select();
            }

            var cboFlowsheetTemplate = document.getElementById('cboFlowSheet_Input');

            if (cboFlowsheetTemplate.value == '' ||
                cboFlowsheetTemplate.value == ' ') {
                cboFlowsheetTemplate.value = result.SelectedItem;
            }

            document.getElementById('btnGet').click();
        }
    }
    else {
        __doPostBack('pbLibraryCondition');
    }
}
function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow) oWindow = window.radWindow;
    else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
    return oWindow;
}


function returnToParent(args) {
    var oArg = new Object();
    oArg.result = args;
    var oWnd = GetRadWindow();
    if (oArg.result) {
        oWnd.close(oArg.result);
    }
    else {
        oWnd.close(oArg.result);
    }
}
function OpenSearchAllResults() {
    var obj = new Array();
    var Result = openModal("frmSearchAllResults.aspx", 525, 623, obj, 'MessageWindow');
    var WindowName = $find('MessageWindow');
    WindowName.set_behaviors(-Telerik.Web.UI.WindowAutoSizeBehaviors.Close);
    WindowName.add_close(OnClientCloseSearchAllResults);
    return false;
}
function OnClientCloseSearchAllResults(oWindow, args) {
    var arg = args.get_argument();
    if (arg) {
        var Result = arg.hdnSearchResults;
        if (Result != null) {
            document.getElementById('hdnSearchResults').value = Result;
            var SearchList = document.getElementById('hdnSearchResults').value.split("|");
            var FlowList = $find("chklstResultItems");
            var duplicate;
            for (var i = 0; i < FlowList._itemData.length; i++) {
                for (var j = 0; j < SearchList.length; j++) {
                    var values = SearchList[j].split("_");
                    if (FlowList._itemData[i].value == values[0]) {
                        if (duplicate == null) {
                            duplicate = SearchList[j];
                        }
                        else {
                            duplicate = duplicate + "|" + SearchList[j];
                        }
                    }
                }
            }
            document.getElementById('hdnAddResults').value = duplicate;
            document.getElementById('SearchButton').click();
        }
    }
}
function ValidationMngr() {

    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}

    if (document.getElementById('txtTemplate').value == '') {
        DisplayErrorMessage('102002');
        var txttemp = document.getElementById('txtTemplate').focus();
         {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
        return false;
    }
    else
        if (document.getElementById('txtTemplate').value.trim() == '') {
            DisplayErrorMessage('102014');
             {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
            return false;
        }
        else if (($find('chklstVitalsDataItems')._checkedIndices.length == 0) && ($find('chklstResultItems')._checkedIndices.length == 0)) {
            DisplayErrorMessage('102004');
             {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
            return false;
        }
}


function cboFlowSheet_SelectedIndexChanged(sender, args) {
    document.getElementById('SelectedItem').value = document.getElementById('cboFlowSheet').value;

}

function btnPrintChart_Clicked(sender) {
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
    var Type = document.getElementsByTagName("INPUT");
    var enableEvent = false;
    for (var i = 0; i < Type.length; i++) {
        if (Type[i].type == "radio") {
            if (Type[i].id.toString().indexOf('chk') >= 0) {
                if (document.getElementById(Type[i].id).checked == true) {
                    enableEvent = true;
                }
            }
        }
    }
    if (enableEvent == true) {

    }
    else {
        DisplayErrorMessage('102013');
         {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
        return false;
    }
}

function btnOkSearch_Clicked(sender, args) {
   
    var CHK = document.getElementById('chkSearchDescription');
    var checkbox = CHK.getElementsByTagName("input");
    var counter = 0;
    for (var i = 0; i < checkbox.length; i++) {
        if (checkbox[i].checked) {
            counter++;
        }
    }
    if (counter > 0) {
        return true;
    }
    else {
        DisplayErrorMessage('6400012');
         {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
        return false;
        CHK.focus();
    }

}

function printchart(FileName,sFaxSubject) {
    var obj = new Array();
    obj.push("SI=" + FileName + "Location=CHART");
    $(top.window.document).find('#ProcessModalGrowthChart').modal({ backdrop: 'static', keyboard: false }, 'show');
    var sPath = ""
    sPath = "frmPrintPDF.aspx?SI=" + FileName + "&Location=CHART" + "&FaxSubject="+sFaxSubject;
    $(top.window.document).find('#ProcessFrameGrowthChart')[0].contentDocument.location.href = sPath;
    $(top.window.document).find("#ModalTitleGrowthChart")[0].textContent = "PDF";
}

// For Validaation... Ponmozhi Vendan T.
function btnGet_Clicked(sender, args) {

    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}

    var cboPhysician = document.getElementById('cboPhysician');

    if (cboPhysician.value == ' ' ||
        cboPhysician.value == '') {
        DisplayErrorMessage('103002');
         {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
        cboPhysician.focus();
        sender.set_autoPostBack(false);
        return false;
    }
    var cboFlowsheetTemplate = document.getElementById('cboFlowSheet_Input');

    if (cboFlowsheetTemplate.value == ' ' ||
        cboFlowsheetTemplate.value == '') {
        DisplayErrorMessage('103001');
         {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
        cboFlowsheetTemplate.focus();
        sender.set_autoPostBack(false);
        return false;
    }

    var rdRange = document.getElementById('rdRange');

    if (rdRange.checked) {

        var fromDate = document.getElementById('fromDate_dateInput');
        var fromDateValue = fromDate.value;

        if (fromDateValue == '') {
            DisplayErrorMessage('103003');
             {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
            fromDate.focus();
            sender.set_autoPostBack(false);
            return false;
        }
        var toDate = document.getElementById('todate_dateInput');
        var toDateValue = toDate.value;

        if (toDateValue == '') {
            DisplayErrorMessage('103004');
             {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
            toDate.focus();
            sender.set_autoPostBack(false);
            return false;
        }


        fromDateValue = new Date(fromDateValue);
        toDateValue = new Date(toDateValue);

        if (fromDateValue == "Invalid Date") {
            DisplayErrorMessage('150004');
             {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
            fromDate.value = '';
            fromDate.focus();
            sender.set_autoPostBack(false);
            return false;
        }

        if (toDateValue == "Invalid Date") {
            DisplayErrorMessage('150004');
             {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
            toDate.value = '';
            toDate.focus();
            sender.set_autoPostBack(false);
            return false;
        }

        if (toDateValue < fromDateValue) {
            DisplayErrorMessage('103005');
             {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
            sender.set_autoPostBack(false);
            return false;
        }

        var today = new Date();

        if (today < fromDateValue) {
            DisplayErrorMessage('103008');
             {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
            fromDate.focus();
            sender.set_autoPostBack(false);
            return false;
        }

        if (today < toDateValue) {
            DisplayErrorMessage('103009');
             {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
            toDate.focus();
            sender.set_autoPostBack(false);
            return false;
        }
    }
    sender.set_autoPostBack(true);
}

function SearchValidate() {

    var txtDescription = document.getElementById('txtDescription');

    if (txtDescription.value == ' ' ||
        txtDescription.value == '') {
        DisplayErrorMessage('640008');
        txtDescription.focus();
        return false;
    }
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
    return true;
}

function btnSearchClear() {

    var txtDescription = document.getElementById('txtDescription');
    txtDescription.value = '';

    var lblMessage = document.getElementById('lblMessage');

    if (lblMessage) {
        lblMessage.style.visibility = "hidden";
    }
    var chkSearchDescription = document.getElementById('chkSearchDescription');
    chkSearchDescription.innerHTML = '<div class="rlbGroup rlbGroupRight"></div>';
    console.log(chkSearchDescription);

    return false;
}

function OnItemCommand(sender, eventArgs) {
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
    document.getElementById('hdnSelectedIndex').value = eventArgs.get_commandArgument();
}
