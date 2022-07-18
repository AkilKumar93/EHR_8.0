var id;

function PhrasesCellSelected(sender, args) {

    var index = args._itemIndexHierarchical;
    var grid = $find(args._id.substring(0, args._id.indexOf('_ctl00')));
    var MasterTable = grid.get_masterTableView();
    var txtbox;
    var allTextBoxes = document.getElementsByTagName('textarea');
    for (var iLoop = 0; iLoop < allTextBoxes.length; iLoop++) {
        if (allTextBoxes[iLoop].id == args._id.split('-')[1]) {
            txtbox = allTextBoxes[iLoop];
        }
    }
    var row = MasterTable.get_dataItems()[index];
    id = MasterTable.getCellByColumnUniqueName(row, "Phrases");
    if (id.innerHTML == "Click Here To Add New Phrase") {
        OpenAddorEditUserDefinedPhraes('0' + ',' + args._id.substring(0, args._id.indexOf('_ctl00')).split('-')[2] + "," + args._id.substring(0, args._id.indexOf('_ctl00')).split('-')[6] + "," + "false");


    }
    else {
        if (txtbox.textContent == '' && txtbox.textContent.indexOf(id.innerHTML) == -1) {
            txtbox.textContent += id.innerHTML;
            args.get_gridDataItem().get_element().style.color = "rgb(128, 128, 128)";
            if (txtbox.textContent.indexOf('??') != -1) {
                txtbox.textContent.selectText(txtbox.textContent.indexOf('??'), txtbox.textContent.indexOf('??') + 2);
            }
            document.getElementById(args._id.substring(0, args._id.indexOf('_ctl00')).split('-')[3]).value = txtbox;
        }
        else if (args.get_gridDataItem().get_element().style.color != "rgb(128, 128, 128)" && MasterTable.getCellByColumnUniqueName(row, "color").innerHTML != "grey") {
            txtbox.textContent = txtbox.textContent + ", " + id.innerHTML;
            document.getElementById(args._id.substring(0, args._id.indexOf('_ctl00')).split('-')[3]).value = txtbox.textContent + "," + id.innerHTML;
            args.get_gridDataItem().get_element().style.color = "rgb(128, 128, 128)";
            if (txtbox.textContent.indexOf('??') != -1) {
                $find(args._id.split('-')[1]).selectText(txtbox.textContent.indexOf('??'), txtbox.textContent.indexOf('??') + 2);
            }
        }
    }
}



function OpenAddorEditUserDefinedPhraes(Phrases_ID) {
    var obj = new Array();
    obj.push("phrasesID=" + Phrases_ID.split(',')[0]);
    obj.push("FieldName=" + Phrases_ID.split(',')[1]);
    Result = openModal("frmAddorEditUserDefinedPhrases.aspx", 260, 370, obj, "MessageWindow");
    var resultwindow = $find("MessageWindow");
    resultwindow.add_close(OnClientClosePhrases);
    document.getElementById(Phrases_ID.split(',')[2]).value = "true";

}

function CellValueSelected(value) {
    if (DisplayErrorMessage('180016') == true) {
        document.getElementById(value.split(',')[1]).value = value.split(',')[0];
        document.getElementById(value.split(',')[2]).value = "true";
    }
    else {
        document.getElementById(value.split(',')[1]).value = "";
        document.getElementById(value.split(',')[2]).value = "false";
    }
}
function clickPhrases(Id) {


}
function OnClientClosePhrases(oWindow, args) {
    window.document.forms[0].submit();

}
  