var intx;
function clearall() {
    if (DisplayErrorMessage('1180002') == true) {
        var textboxes = document.getElementsByTagName("textarea");
        var InputElements = document.getElementsByTagName("input");
        var comboboxes = document.getElementsByTagName("select");

        for (var i = 0; i < textboxes.length; i++) {
            if (textboxes[i].id.indexOf("txtDLC") > -1) {
                textboxes[i].value = "";
                var ID = textboxes[i].id;
                if (document.getElementById(ID.replace("txt", "list")) != null) {
                    if (document.getElementById(ID.replace("txt", "list")).style.visibility == "") {
                        document.getElementById(ID.replace("txt", "list")).style.display = "none";
                        var plusbtn = document.getElementById(ID.replace("txtDLC", "pbDropdown"));
                        if (plusbtn.innerHTML.indexOf("minus") != -1 || plusbtn.innerHTML == "-") {
                            if (plusbtn.childNodes[0] != undefined && plusbtn.childNodes[0].className != null)
                                plusbtn.childNodes[0].className = "fa fa-plus margin2";
                            else if (plusbtn.childNodes[0] != undefined && plusbtn.childNodes[0].nextSibling.className != null)
                                plusbtn.childNodes[0].nextSibling.className = "fa fa-plus margin2";
                        }
                    }
                }
            }
        }
        for (var i = 0; i < InputElements.length; i++) {
            if (InputElements[i].id.indexOf("txtScore") > -1) {
                InputElements[i].value = "";
            }
        }
        for (var i = 0; i < comboboxes.length; i++) {
            if (comboboxes[i].id.indexOf("cbo") > -1) {
                comboboxes[i].options[0].selected = true;
                comboboxes[i].options[comboboxes[i].selectedIndex].selected = false;
            }
        }
        EnableSave();
    }
}


function textboxLeave(ctrlID) {
    var ID = document.getElementById(ctrlID).value;
    var ID1 = document.getElementById(ctrlID.replace("txt", "lbl")).innerText;

    if (ID > ID1.replace("/", "")) {
        DisplayErrorMessage('240008');
        $find(ctrlID).focus();
        document.getElementById('divLoading').style.display = "none";
        return false;
    }
}

function Enable_OR_Disable(id) {

    var button2 = $find("btnSave");

    if (button2.get_enabled())
        document.getElementById("Hidden1").value = "True";
    else
        document.getElementById("Hidden1").value = "";

    intx = document.getElementById("divTest").scrollTop;



    if (document.getElementById(id.substring(0, id.indexOf("_pbDropdown")) + "_pbDropdown").src.split('/')[4] == "minus_new.gif") {

        document.getElementById(id.split(',')[0]).src = "Resources/plus_new.gif";
        var id = $find(id.replace("_pbDropdown,", "_"));
        id._element.style.display = "none";

        return false;
    }

}


function EnableSave() {
    $find('btnSave').set_enabled(true);
    window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable.value = true;
    localStorage.setItem("bSave", "false");
}

function SetDivPosition() {

    var ctrl = document.getElementsByTagName('INPUT');
    for (var i = 0; i < ctrl.length; i++) {
        if (ctrl[i].id.indexOf('cbo') == 0) {
            $find(ctrl[i].id.replace("_Input", "").replace("_ClientState", "")).hideDropDown();
        }
    }


    if (intx != undefined) {
        document.getElementById("divTest").scrollTop = intx;
        intx = undefined;
    }

}


function saveEnabled() {
    var now = new Date();
    var then = now.getDay() + '-' + (now.getMonth() + 1) + '-' + now.getFullYear(); then += ' ' + now.getHours() + ':' + now.getMinutes() + ':' + now.getSeconds();
    var utc = (now.getUTCMonth() + 1) + '/' + now.getUTCDate() + '/' + now.getUTCFullYear(); utc += ' ' + now.getUTCHours() + ':' + now.getUTCMinutes() + ':' + now.getUTCSeconds();
    document.getElementById(GetClientId("hdnLocalTime")).value = utc;
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
    DisplayErrorMessage('1180001');
     {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
    if ($find('btnSave') != null)
        $find('btnSave').set_enabled(false);
    AutoSaveSuccessful();
}


