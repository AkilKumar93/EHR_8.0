function btnSave_Clicked(sender, args) {
    var dt = new Date();
    var now = new Date();
    var then = now.getDay() + '-' + (now.getMonth() + 1) + '-' + now.getFullYear(); then += ' ' + now.getHours() + ':' + now.getMinutes() + ':' + now.getSeconds();
    var utc = (now.getUTCMonth() + 1) + '/' + now.getUTCDate() + '/' + now.getUTCFullYear();
    utc += ' ' + now.getUTCHours() + ':' + now.getUTCMinutes() + ':' + now.getUTCSeconds();
    document.getElementById('hdnLocalDate').value = utc;
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
}

function btnProblemMerge_Clicked(sender, args) {
    var dt = new Date();
    var now = new Date();
    var then = now.getDay() + '-' + (now.getMonth() + 1) + '-' + now.getFullYear(); then += ' ' + now.getHours() + ':' + now.getMinutes() + ':' + now.getSeconds();
    var utc = (now.getUTCMonth() + 1) + '/' + now.getUTCDate() + '/' + now.getUTCFullYear();
    utc += ' ' + now.getUTCHours() + ':' + now.getUTCMinutes() + ':' + now.getUTCSeconds();
    document.getElementById('hdnLocalDate').value = utc;
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }

}

function ShowLoading() {
    document.getElementById('divLoading').style.display = "block";
}


function btnClose_Clicked(sender, args) {
    var win = GetRadWindow();
    if (win != null && win != undefined)
        win.close();
    if (sender != undefined)
        sender.set_autoPostBack(false);
}

function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow) oWindow = window.radWindow;
    else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
    return oWindow;
}

function btnMedicationMerge_Clicked(sender, args) {
    var dt = new Date();
    var now = new Date();
    var then = now.getDay() + '-' + (now.getMonth() + 1) + '-' + now.getFullYear(); then += ' ' + now.getHours() + ':' + now.getMinutes() + ':' + now.getSeconds();
    var utc = (now.getUTCMonth() + 1) + '/' + now.getUTCDate() + '/' + now.getUTCFullYear();
    utc += ' ' + now.getUTCHours() + ':' + now.getUTCMinutes() + ':' + now.getUTCSeconds();
    document.getElementById('hdnLocalDate').value = utc;
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
}

function btnAllergyMerge_Clicked(sender, args) {
    var dt = new Date();
    var now = new Date();
    var then = now.getDay() + '-' + (now.getMonth() + 1) + '-' + now.getFullYear(); then += ' ' + now.getHours() + ':' + now.getMinutes() + ':' + now.getSeconds();
    var utc = (now.getUTCMonth() + 1) + '/' + now.getUTCDate() + '/' + now.getUTCFullYear();
    utc += ' ' + now.getUTCHours() + ':' + now.getUTCMinutes() + ':' + now.getUTCSeconds();
    document.getElementById('hdnLocalDate').value = utc;
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
}

function SetSummaryBar(ProbLstText, AllergyText, MedText, SummaryToolTip) {
    var dox = window.parent.window.parent.window.parent.window.document;
    //ProbList
    var lblPrbLstText = dox.all.ctl00_C5POBody_lblProblemList;
    lblPrbLstText.innerHTML = ProbLstText;
    var pnl = dox.all.ctl00_C5POBody_pnlProblemList;
    pnl.innerHTML = ProbLstText;
    var regex = /<BR\s*[\/]?>/gi;
    pnl.title = lblPrbLstText.innerText;
    var problmlist = ProbLstText;
    problmlist = problmlist.replace(regex, "n");
    //Allergy
    var lblAllergyText = dox.all.ctl00_C5POBody_lblAllergies;
    lblAllergyText.innerHTML = AllergyText;
    var pnlAllergy = dox.all.ctl00_C5POBody_pnlAllergies;
    pnlAllergy.innerHTML = AllergyText;
    var regex = /<BR\s*[\/]?>/gi;
    pnlAllergy.title = lblAllergyText.innerText;
    var allergylist = lblAllergyText.innerText.replace(regex, "n");
    allergylist = allergylist.replace(regex, "n");
    //Medication
    var lblMedText = dox.getElementById("ctl00_C5POBody_lblMedication :");
    var lblMedText = dox.all.ctl00_C5POBody_lblMedication;
    lblMedText.innerHTML = MedText;
    var pnlMed = dox.all.ctl00_C5POBody_pnlMedication;
    pnlMed.innerHTML = MedText;
    var regex = /<BR\s*[\/]?>/gi;
    pnlMed.title = lblMedText.innerText;
    var medlist = lblMedText.innerText;
    medlist = medlist.replace(regex, "n");

    top.window.document.getElementById("ctl00_C5POBody_imgOverAllSummary").title = "";
    top.window.document.getElementById("ctl00_C5POBody_imgOverAllSummary").title = allergylist + "\n";
    top.window.document.getElementById("ctl00_C5POBody_imgOverAllSummary").title += dox.all.ctl00_C5POBody_lblCheifComplaints.title + "\n";
    top.window.document.getElementById("ctl00_C5POBody_imgOverAllSummary").title += problmlist + "\n";
    top.window.document.getElementById("ctl00_C5POBody_imgOverAllSummary").title += dox.all.ctl00_C5POBody_lblVitals.title + "\n";
    top.window.document.getElementById("ctl00_C5POBody_imgOverAllSummary").title += medlist;
}