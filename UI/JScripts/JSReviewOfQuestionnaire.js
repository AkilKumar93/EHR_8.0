var chkToggleState = false;

function checkStateWhenAllSymptomsCheckBoxChecked(chkBoxId) {
    var chkList = new Array();
    var chkBox = document.getElementById(chkBoxId);
    var splitter = chkBoxId.split("_");
    var table = document.getElementById("table_" + splitter[1]);

    if (chkToggleState == false) {
        for (i = 0; i < table.rows.length; i++) {
            for (j = 0; j < table.rows[i].cells.length; j++) {
                if (table.rows[i].cells[j].children[0] != null && table.rows[i].cells[j].children[0].id.indexOf(splitter[0]) != -1 && !table.rows[i].cells[j].children[0].id.endsWith("All")) {
                    chkToggleState = true;
                    var nameFind1;

                    if (splitter[0] == "chkYes")
                        nameFind1 = "chkNo";
                    else if (splitter[0] == "chkNo")
                        nameFind1 = "chkYes";

                    chkList.push(table.rows[i].cells[j].children[0]);

                    var chkctrl = document.getElementById(nameFind1 + "_" + splitter[1] + "_All");

                    if (chkctrl.checked)
                        chkctrl.checked = false;
                }
            }
        }

        for (k = 0; k < chkList.length; k++) {
            chkToggleState = true;

            if (chkBox.checked) {
                if (!chkList[k].checked) {
                    var splitName = chkList[k].id.split('_');

                    var nameFind;

                    if (splitName[0] == "chkYes")
                        nameFind = "chkNo";
                    else if (splitName[0] == "chkNo")
                        nameFind = "chkYes";

                    var chkctrl = document.getElementById(nameFind + "_" + splitName[1] + "_" + splitName[2]);

                    if (!chkctrl.checked)
                        chkList[k].checked = true;
                }
            }
            else if (!chkBox.checked) {
                if (chkList[k].checked)
                    chkList[k].checked = false;
            }
        }
    }

    chkToggleState = false;
    btnSaveEnabled();
}

function chkYesNoToggleStateChanged(chkBoxId) {
    btnSaveEnabled();

    var chk = document.getElementById(chkBoxId);
    var splitter = chkBoxId.split("_");
    var table = document.getElementById("table_" + splitter[1]);

    if (chk.checked)
        checkYOrN(chk);
    else {
        chk.checked = false;
        var split = chk.id.split('_');

        var chkCtrl = document.getElementById(split[0] + "_" + split[1]);

        if (chkCtrl != null) {
            if (chkCtrl.checked == true) {
                chkToggleState = true;
                chkCtrl.checked = false;
            }
        }

        chkToggleState = false;

        if (chk.id.indexOf("chkYes_") != -1)
            document.getElementById("chkAllOtherSystemsNormal").checked = false;
    }
}

function checkYOrN(chk) {
    var splitter = chk.id.split('_');
    var table = document.getElementById("table_" + splitter[1]);

    if (chkToggleState == false) {
        for (i = 0; i < table.rows.length; i++) {
            for (j = 0; j < table.rows[i].cells.length; j++) {
                if (table.rows[i].cells[j].children[0] != null && table.rows[i].cells[j].children[0].id.indexOf("All") != -1) {
                    chkToggleState = true;
                    if (table.rows[i].cells[j].children[0].checked)
                        table.rows[i].cells[j].children[0].checked = false;
                }

                if (table.rows[i].cells[j].children[0] != null && table.rows[i].cells[j].children[0].id == chk.id && table.rows[i].cells[j].children[0].id.indexOf(splitter[splitter.length - 1]) != -1) {
                    table.rows[i].cells[j].children[0].checked = true;
                    document.getElementById("table_" + splitter[1]).checked = false;
                }
                else if (table.rows[i].cells[j].children[0] != null && table.rows[i].cells[j].children[0].id.indexOf(splitter[splitter.length - 1]) != -1)
                    table.rows[i].cells[j].children[0].checked = false;
            }
        }
    }

    chkToggleState = false;
}

function chkAllOtherSystemsNormalClick(systemNames) {
    btnSaveEnabled();

    var systemNamesArray = new Array();
    var systemNamesSplitter = systemNames.split('|');

    for (i = 0; i < systemNamesSplitter.length; i++)
        systemNamesArray.push(systemNamesSplitter[i]);

    var chkBox = document.getElementById("chkAllOtherSystemsNormal");

    if (chkBox != null)
        checkStateWhenAllOtherAreNormalIsChecked(chkBox.checked, systemNamesArray);
}

function checkStateWhenAllOtherAreNormalIsChecked(chkState, systemNamesArray) {
    for (k = 0; k < systemNamesArray.length; k++) {
        var table = document.getElementById("table_" + systemNamesArray[k]);

        for (i = 0; i < table.rows.length; i++) {
            for (j = 0; j < table.rows[i].cells.length; j++) {
                if (table.rows[i].cells[j].children[0] == null || table.rows[i].cells[j].children[0].id.indexOf("chk") == -1)
                    continue;

                if (table.rows[i].cells[j].children[0].id.indexOf("chkYes") != -1) {
                    if (table.rows[i].cells[j].children[0].checked)
                        break;
                }

                if (table.rows[i].cells[j].children[0].id.indexOf("chkNo") != -1 && table.rows[i].cells[j].children[0].id.indexOf("All") != -1)
                    table.rows[i].cells[j].children[0].checked = chkState ? true : false;

                if (table.rows[i].cells[j].children[0].id.indexOf("chkNo") != -1 && table.rows[i].cells[j].children[0].id.indexOf("All") == -1)
                    table.rows[i].cells[j].children[0].checked = chkState ? true : false;
            }
        }
    }
}


function btnSaveEnabled() {   
    document.getElementById("btnSave").disabled = false;
    if ($find('btnSave') != undefined) {
        $find('btnSave').set_enabled(true);
    }
    window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable.value = true;
    localStorage.setItem("bSave", "false");
}


function SaveEnabled() {
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
    window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable.value = false;
    localStorage.setItem("bSave", "true");
}

function cancelBack() {
    $find('btnSave').set_enabled(true);
    window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable.value = true;
    localStorage.setItem("bSave", "false");
}



function RadTabStrip2_TabSelecting(sender, args) {
    if (window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable.value == "true" && DisplayErrorMessage('1100000') == false)
        args.set_cancel(true);
    else
        window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable.value = "false";
}




function ReviewQuestionnaire_Load() {
    window.parent.parent.theForm.hdnSaveButtonID.value = "btnSave,RadMultiPage1";
    top.window.document.getElementById('ctl00_Loading').style.display = "none";
     {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
}
function SavedSuccessfully() {
    var splitvalues = window.parent.parent.theForm.hdnTabClick.value.split('$#$');
    var which_tab = splitvalues[0];
    var screen_name;
    if (which_tab.indexOf('btn') > -1) {
        screen_name = 'MoveToButtonsClick';
    }
    else if (which_tab == 'first') {
        screen_name = '';
    }
    else if (which_tab != "first" && which_tab != "CC / HPI" && which_tab != "QUESTIONNAIRE" && which_tab != "PFSH" && which_tab != "ROS" && which_tab != "VITALS" && which_tab != "EXAM" && which_tab != "TEST" && which_tab != "ASSESSMENT" && which_tab != "ORDERS" && which_tab != "eRx" && which_tab != "SERV./PROC. CODES" && which_tab != "PLAN" && which_tab != "SUMMARY")
        screen_name = "QuestionnaireTabClick";
    else
        screen_name = "EncounterTabClick";
    if (splitvalues.length == 3 && splitvalues[2] == "Node")
        screen_name = 'PatientChartTreeViewNodeClick';
    SavedSuccessfully_NowProceed(screen_name);
    DisplayErrorMessage('118501');

    if($find('btnSave')!=null)
        $find('btnSave').set_enabled(false);
     {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
    AutoSaveSuccessful();
}

