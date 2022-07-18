function showTime() { var dt = new Date(); var now = new Date(); var then = now.getDay() + '-' + (now.getMonth() + 1) + '-' + now.getFullYear(); then += ' ' + now.getHours() + ':' + now.getMinutes() + ':' + now.getSeconds(); var utc = (now.getUTCMonth() + 1) + '/' + now.getUTCDate() + '/' + now.getUTCFullYear(); utc += ' ' + now.getUTCHours() + ':' + now.getUTCMinutes() + ':' + now.getUTCSeconds(); document.getElementById("hdnLocalTime").value = utc; document.getElementById("hdnSaveFlag").value = false; }
function AutoSave(btn)
{
    document.getElementById("btnAdd").disabled = false; document.getElementById("hdnSaveFlag").value = true; showTime1();
}

function RefreshddlEVType(ddlEVType) {
    if ($("#ddlEVType option:selected").val() == "VOICE") {
        TextBoxColorChange("txtCallReference", true);
        TextBoxColorChange("txtCallRepresentative", true);
    }
    else if ($("#ddlEVType option:selected").val() == "WEB") {
        TextBoxColorChange("txtCallReference", false);
        TextBoxColorChange("txtCallRepresentative", false);
    }
    else {
        TextBoxColorChange("txtCallReference", false);
        TextBoxColorChange("txtCallRepresentative", false);
    }
    return;
}

function TextBoxColorChange(txtbox, bToNormal) {
    if (bToNormal == false) {
        document.getElementById(txtbox).readOnly = true;
        document.getElementById(txtbox).style.backgroundColor = "#BFDBFF";


    }
    else {
        document.getElementById(txtbox).readOnly = false;
        document.getElementById(txtbox).style.backgroundColor = "white";


    }
}


function CloseWindow() {
    if (document.getElementById("hdnSaveFlag").value == "true") {
        if (document.getElementById(GetClientId("hdnMessageType")).value == "") {
            DisplayErrorMessage('350009');
            return false;
        }
        else if (document.getElementById(GetClientId("hdnMessageType")).value == "Yes") {
            document.getElementById('btnAdd').click();
            document.getElementById('btnAdd').disabled = false;
            return false;
        }
        else if (document.getElementById(GetClientId("hdnMessageType")).value == "No") {
            document.getElementById(GetClientId("hdnMessageType")).value = "";
            self.close();
        }
        else if (document.getElementById(GetClientId("hdnMessageType")).value == "Cancel") {
            document.getElementById(GetClientId("hdnMessageType")).value = "";
            return false;
        }
    }
    else {
        returnToParent(null);
    }

}
function SaveClose() {

    DisplayErrorMessage('350006');
    var Result = new Object();
    Result.IsEVSaved = "TRUE";
    if (window.opener) { window.opener.returnValue = Result; } window.returnValue = Result; returnToParent(Result);
    self.close();
}
function showTime1() {

    var dt = new Date(); var now = new Date(); var then = now.getDay() + '-' + (now.getMonth() + 1) + '-' + now.getFullYear(); then += ' ' + now.getHours() + ':' + now.getMinutes() + ':' + now.getSeconds(); var utc = (now.getUTCMonth() + 1) + '/' + now.getUTCDate() + '/' + now.getUTCFullYear(); utc += ' ' + now.getUTCHours() + ':' + now.getUTCMinutes() + ':' + now.getUTCSeconds(); document.getElementById("hdnLocalTime").value = utc; document.getElementById("hdnSaveFlag").value = true;
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    document.getElementById("btnAdd").disabled = false; document.getElementById("hdnSaveFlag").value = true; showTime1();
    return true;
}
function DateValidattion(dateToValidate) {
    var splitdate = $find(dateToValidate)._value;
    var dt1 = new Date();
    var dd = new Date();
    var month = new Array();
    switch (splitdate.split('-')[1]) {
        case "Jan":
            x = 0;
            break;
        case "Feb":
            x = 1;
            break;
        case "Mar":
            x = 2;
            break;
        case "Apr":
            x = 3;
            break;
        case "May":
            x = 4;
            break;
        case "Jun":
            x = 5;
            break;
        case "Jul":
            x = 6;
            break;
        case "Aug":
            x = 7;
            break;
        case "Sep":
            x = 8;
            break;
        case "Oct":
            x = 9;
            break;
        case "Nov":
            x = 10;
            break;
        case "Dec":
            x = 11;
            break;
        case splitdate.split('-')[1]:
            return false;
            break;

    }


    dd.setFullYear(splitdate.split('-')[2], x, splitdate.split('-')[0]);
    if (isNaN(dd)) {
        return false;
    }
    if (splitdate.split('-')[0] > 31) {
        return false;
    }
}
function ValidateSAve() {

    var now = new Date(); var then = now.getDay() + '-' + (now.getMonth() + 1) + '-' + now.getFullYear(); then += ' ' + now.getHours() + ':' + now.getMinutes() + ':' + now.getSeconds(); var utc = (now.getUTCMonth() + 1) + '/' + now.getUTCDate() + '/' + now.getUTCFullYear(); utc += ' ' + now.getUTCHours() + ':' + now.getUTCMinutes() + ':' + now.getUTCSeconds(); document.getElementById("hdnLocalTime").value = utc;
    if (document.getElementById("dtpEffectiveStartDate").value.length == 0) {


        DisplayErrorMessage('350007');
        return false;
    }

    if (DateValidattion("dtpEffectiveStartDate") == false) {


        DisplayErrorMessage('350010');
        return false;
    }
    if (document.getElementById("dtpTerminationDate").value.length != 0) {
        if (document.getElementById("dtpTerminationDate").value != "__-___-____") {
            if (DateValidattion("dtpTerminationDate") == false) {


                DisplayErrorMessage('350011');
                return false;
            }
        }
    }
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
    return true
}

function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow) oWindow = window.radWindow;
    else if (window.frameElement != null && window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
    return oWindow;
}


function returnToParent(args) {
    var oArg = new Object();
    oArg.result = args;
    var oWnd = GetRadWindow();
    if (oWnd != null) {
        if (oArg.result) {
            oWnd.close(oArg.result);
        }
        else {

            oWnd.close(oArg.result);
        }
    }
    else {
        self.close();
    }
}

function AllowAmount(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46) {
        return false
    }
    if (document.getElementById(evt.id).value.indexOf('.') != -1 && charCode == 46)
        return false;
    document.getElementById("btnAdd").disabled = false; document.getElementById("hdnSaveFlag").value = true; showTime1();
    if (document.getElementById(evt.id).value == '' && charCode == 46) {
        return false;
    }
    return true;
}

function EVDateValidation(sender, args) {
    var EnteredDateLength = parseInt(args._newValue.replace("-", "").replace("-", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").length);
    if (EnteredDateLength != 9 && EnteredDateLength > 0) {
        alert("Please Enter the Date Fully.")
        sender.clear();
        document.getElementById(sender._clientID).focus();
        return false;
    }
    
    if (EnteredDateLength == 9) {
        validatedate(document.getElementById(sender._clientID).value, document.getElementById(sender._clientID));
        DOBValidation(document.getElementById(sender._clientID).value, document.getElementById(sender._clientID));
    }
    AutoSave(sender);
}
function validatedate(inputText, ControlId) {
    var FormatDDMMMYYYY = /(\d+)-([^.]+)-(\d+)/;
    if (inputText.match(FormatDDMMMYYYY)) {
        var DateMonthYear = inputText.split('-');
        lopera2 = DateMonthYear.length;
        var DateInput = parseInt(DateMonthYear[0]);
        var Year = parseInt(DateMonthYear[2]);
        var Month = "";
        var ListofDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
        var ListofMonth = ['JAN', 'FEB', 'MAR', 'APR', 'MAY', 'JUN', 'JUL', 'AUG', 'SEP', 'OCT', 'NOV', 'DEC'];
        if (ListofMonth.indexOf(DateMonthYear[1].toUpperCase()) != -1) {

            Month = ListofMonth.indexOf(DateMonthYear[1].toUpperCase()) + 1;

            if (Month == 1 || Month > 2) {
                if (DateInput > ListofDays[Month - 1]) {
                    alert('Invalid date.');
                    $find(ControlId.id).clear();
                    $find(ControlId.id).focus(true);
                    return false;
                }
            }


            if (Month == 2) {
                var lyear = false;
                if ((!(Year % 4) && Year % 100) || !(Year % 400)) {
                    lyear = true;
                }
                if ((lyear == false) && (DateInput >= 29)) {
                    alert('Invalid date.');
                    $find(ControlId.id).clear();
                    $find(ControlId.id).focus(true);
                    return false;
                }
                if ((lyear == true) && (DateInput > 29)) {
                    alert('Invalid date.');
                    $find(ControlId.id).clear();
                    $find(ControlId.id).focus(true);
                    return false;
                }
            }

            var CurrentDate = new Date();
            var CurrentYear = CurrentDate.getFullYear();
            if (Year > CurrentYear) {
                if( ControlId.name.replace("dtp", "").toUpperCase() != "TerminationDate".toUpperCase())
                    {
                    alert(ControlId.name.replace("dtp","")+" cannot be future date. Please Enter the Valid Year.");
                $find(ControlId.id).clear();
                $find(ControlId.id).focus(true);
                return false;
            }
            }
        }

        else {
            alert('Invalid date.');
            $find(ControlId.id).clear();
            $find(ControlId.id).focus(true);
            return false;
        }
    }
}
function parseMyDate(s) {
    var m = ['jan', 'feb', 'mar', 'apr', 'may', 'jun', 'jul', 'aug', 'sep', 'oct', 'nov', 'dec'];
    var match = s.match(/(\d+)-([^.]+)-(\d+)/);
    var date = match[1];
    var monthText = match[2];
    var year = match[3];
    var month = m.indexOf(monthText.toLowerCase());
    return new Date(year, month, date);
}
function DOBValidation(inputText, ControlId) {
    var DOB = parseMyDate($("[id*='hdnDOB']").val());
    var INPUTDate = parseMyDate(inputText);
    if (DOB > INPUTDate) {
        alert(ControlId.name.replace("dtp", "") + " cannot be lesserthan DOB.");
        ControlId.focus(true);
        return false;
    }
}


function CallMe(sender, args) {
    var inputText = sender._validationText;
    var FormatDDMMMYYYY = /(\d+)-([^.]+)-(\d+)/;

    if (inputText.match(FormatDDMMMYYYY)) {
        var DateMonthYear = inputText.split('-');
        if (DateMonthYear[0].length < 4) {
            alert('Invalid date format!,eg.(DD-MM-YYYY)');
            $find(GetClientId(sender._clientID)).clear();
            $find(GetClientId(sender._clientID)).focus(true);
            return false;
        }

        if (DateMonthYear[1].length < 3) {
            alert('Invalid date format!,eg.(DD-MM-YYYY)');
            $find(GetClientId(sender._clientID)).clear();
            $find(GetClientId(sender._clientID)).focus(true);
            return false;
        }
        if (DateMonthYear[2].length < 2) {
            alert('Invalid date format!,eg.(DD-MM-YYYY)');
            $find(GetClientId(sender._clientID)).clear();
            $find(GetClientId(sender._clientID)).focus(true);
            return false;
        }

        lopera2 = DateMonthYear.length;
        var DateInput = parseInt(DateMonthYear[2]);
        var Year = parseInt(DateMonthYear[0]);
        var Month = "";
        var ListofDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
        var ListofMonth = ['JAN', 'FEB', 'MAR', 'APR', 'MAY', 'JUN', 'JUL', 'AUG', 'SEP', 'OCT', 'NOV', 'DEC'];
        if (ListofMonth.indexOf(DateMonthYear[1].toUpperCase()) != -1) {
            Month = ListofMonth.indexOf(DateMonthYear[1].toUpperCase()) + 1;
            if (Month == 1 || Month > 2) {
                if (DateInput > ListofDays[Month - 1]) {
                    alert('Invalid date format!,eg.(DD-MM-YYYY)');
                    $find(GetClientId(sender._clientID)).clear();
                    $find(GetClientId(sender._clientID)).focus(true);
                    return false;
                }
            }

            if (Month == 2) {
                var lyear = false;
                if ((!(Year % 4) && Year % 100) || !(Year % 400)) {
                    lyear = true;
                }
                if ((lyear == false) && (DateInput >= 29)) {
                    alert('Invalid date format!,eg.(DD-MM-YYYY)');
                    $find(GetClientId(sender._clientID)).clear();
                    $find(GetClientId(sender._clientID)).focus(true);
                    return false;
                }
                if ((lyear == true) && (DateInput > 29)) {
                    alert('Invalid date format!,eg.(DD-MM-YYYY)');
                    $find(GetClientId(sender._clientID)).clear();
                    $find(GetClientId(sender._clientID)).focus(true);
                    return false;
                }
            }

            var CurrentDate = new Date();
            var CurrentYear = CurrentDate.getFullYear();
            Month = ListofMonth.indexOf(DateMonthYear[1].toUpperCase());
            if (Year > CurrentYear) {
                alert("Cannot be future date. Please Enter a Valid Date.");
                $find(GetClientId(sender._clientID)).clear();
                $find(GetClientId(sender._clientID)).focus(true);
                return false;
            }
            else if (Year == CurrentYear && Month > CurrentDate.getMonth()) {
                alert("Cannot be future date. Please Enter a Valid Date.");
                $find(GetClientId(sender._clientID)).clear();
                $find(GetClientId(sender._clientID)).focus(true);
                return false;
            }
            else if (Year == CurrentYear && Month == CurrentDate.getMonth() && DateInput > CurrentDate.getDate()) {
                alert("Cannot be future date. Please Enter a Valid Date.");
                $find(GetClientId(sender._clientID)).clear();
                $find(GetClientId(sender._clientID)).focus(true);
                return false;
            }
        }
        else {
            alert('Invalid date format!,eg.(DD-MM-YYYY)');
            $find(GetClientId(sender._clientID)).clear();
            $find(GetClientId(sender._clientID)).focus(true);
            return false;
        }
    }
    else {

        if (inputText.split('-')[0].length == 0 && (inputText.split('-')[1].length != 0 || inputText.split('-')[0].length != 0)) {
            alert('Invalid date format!,eg.(DD-MM-YYYY)');
            $find(GetClientId(sender._clientID)).clear();
            $find(GetClientId(sender._clientID)).focus(true);
            return false;
        }
        else if (inputText.split('-')[2].length == 1) {
            alert('Invalid date format!,eg.(DD-MM-YYYY)');
            $find(GetClientId(sender._clientID)).clear();
            $find(GetClientId(sender._clientID)).focus(true);
            return false;
        }
        else if (inputText.split('-')[1].length == 0 && inputText.split('-')[0].length == 0) {
            alert('Invalid date format!,eg.(DD-MM-YYYY)');
            $find(GetClientId(sender._clientID)).clear();
            $find(GetClientId(sender._clientID)).focus(true);
            return false;
        }
        else if (inputText.split('-')[2].length != 0 && (inputText.split('-')[1].length == 0 || inputText.split('-')[0].length == 0)) {
            alert('Invalid date format!,eg.(DD-MM-YYYY)');
            $find(GetClientId(sender._clientID)).clear();
            $find(GetClientId(sender._clientID)).focus(true);
            return false;
        }
        else if (inputText.split('-')[1].length != 0 && inputText.split('-')[0].length != 0) {
            var DateMonthYear = inputText.split('-');
            if (DateMonthYear[0].length < 4) {
                alert('Invalid date format!,eg.(DD-MM-YYYY)');
                $find(GetClientId(sender._clientID)).clear();
                $find(GetClientId(sender._clientID)).focus(true);
                return false;
            }

            if (DateMonthYear[1].length < 3) {
                alert('Invalid date format!,eg.(DD-MM-YYYY)');
                $find(GetClientId(sender._clientID)).clear();
                $find(GetClientId(sender._clientID)).focus(true);
                return false;
            }

            var DateMonthYear = inputText.split('-');
            lopera2 = DateMonthYear.length;
            var Year = parseInt(DateMonthYear[0]);
            var Month = "";
            var ListofDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
            var ListofMonth = ['JAN', 'FEB', 'MAR', 'APR', 'MAY', 'JUN', 'JUL', 'AUG', 'SEP', 'OCT', 'NOV', 'DEC'];
            if (ListofMonth.indexOf(DateMonthYear[1].toUpperCase()) != -1) {

                var CurrentDate = new Date();
                var CurrentYear = CurrentDate.getFullYear();
                Month = ListofMonth.indexOf(DateMonthYear[1].toUpperCase());
                if (Year > CurrentYear) {
                    alert("Cannot be future date. Please Enter a Valid Date.");
                    $find(GetClientId(sender._clientID)).clear();
                    $find(GetClientId(sender._clientID)).focus(true);
                    return false;
                }
                else if (Year == CurrentYear && Month > CurrentDate.getMonth()) {
                    alert("Cannot be future date. Please Enter a Valid Date.");
                    $find(GetClientId(sender._clientID)).clear();
                    $find(GetClientId(sender._clientID)).focus(true);
                    return false;
                }

            }
            else {
                alert('Invalid date format!,eg.(DD-MM-YYYY)');
                $find(GetClientId(sender._clientID)).clear();
                $find(GetClientId(sender._clientID)).focus(true);
                return false;
            }
        }
        else if (inputText.split('-')[0].length != 0) {
            var DateMonthYear = inputText.split('-');
            if (DateMonthYear[0].length < 4) {
                alert('Invalid date format!,eg.(DD-MM-YYYY)');
                $find(GetClientId(sender._clientID)).clear();
                $find(GetClientId(sender._clientID)).focus(true);
                return false;
            }

            var DateMonthYear = inputText.split('-');
            var Year = parseInt(DateMonthYear[0]);
            var CurrentDate = new Date();
            var CurrentYear = CurrentDate.getFullYear();
            if (Year > CurrentYear) {
                alert("Cannot be future date. Please Enter a Valid Date.");
                $find(GetClientId(sender._clientID)).clear();
                $find(GetClientId(sender._clientID)).focus(true);
                return false;
            }
        }
    }
    document.getElementById("btnAdd").disabled = false;
}
function UploadImage_FileUploading() {
    document.getElementById(GetClientId("btnAdd")).disabled = false;
}

function QPCDateValidation(sender, args) {
    var EnteredDateLength = parseInt(args._newValue.replace("-", "").replace("-", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").replace("_", "").length);
    if (EnteredDateLength != 9 && EnteredDateLength > 0) {
        alert("Please Enter the Date Fully.")
        sender.clear();
        document.getElementById(sender._clientID).focus();
        return false;
    }
    if (EnteredDateLength == 9) {


        validatedate(document.getElementById(sender._clientID).value, document.getElementById(sender._clientID));
        if (sender._clientID != "dtpCheckDate") {
            DOBValidationWithTwo(document.getElementById(sender._clientID).value, document.getElementById(GetClientId('dtpPatientDOB')), sender);
        }
        if (sender._clientID == "dtpEffectiveStartDate") {
            validatetermdate();
        }
        if (sender._clientID == "dtpPatientDOB") {
            AutoSave(sender);
        }

    }


}
function validatetermdate() {
    if (document.getElementById('dtpEffectiveStartDate').value != "__-___-____" && document.getElementById('dtpTerminationDate').value != "__-___-____") {
        var startdate = parseMyDate(document.getElementById('dtpEffectiveStartDate').value);
        var termdate = parseMyDate(document.getElementById('dtpTerminationDate').value);

        if (startdate > termdate) {
            DisplayErrorMessage('380005');
        }
    }
}
function loadAuthafterEV() {
    if (localStorage.getItem("Authdata") != null) {

        var obj = JSON.parse(localStorage.getItem("Authdata"))
        bindauthtable(obj.AuthDetails, obj.IsAuth);
    }
}