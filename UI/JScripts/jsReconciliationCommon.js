

function loadMedReconcile(triggeredBy) {
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
    var sRequestSentLogID = '';
    var DrugName = '';
    var sDrugStartDate = '';
    var sDrugStopDate = '';
    var DrugAllergy = '';
    var sCreatedBy = "";
    var Project_Name = "";

    var DrugNotesList = [];
    var DrugIDList = [];
    var DrugCountList = [];
    var DrugStartDateList = [];
    var DrugStopDateList = [];
    var RouteList = [];
    var FreqList = [];
    var DrugNamelist = [];
    var StrengthList = [];
    var DrugDetailList = [];
    var DrugReqSentLogIDList = [];
    var ResponseSentIDList = [];

    var pfshFrame = $($(top.window.document).find("iframe[id=ctl00_C5POBody_EncounterContainer]")[0].contentDocument).find("iframe[id=iframePFSH]");
    var rows = $($(pfshFrame[0].contentDocument).find("iframe[id=iframeRxHistory]")[0].contentDocument).find("#tRxMed tbody tr.CURRENT");

    for (var i = 0; i < rows.length; i++) {
        if (rows[i].children[23].innerText.trim() == "" && rows[i].children[24].innerText.trim() == "") {
            if (DrugName == "") {
                DrugName += rows[i].children[2].innerText.trim();
                sDrugStartDate += rows[i].children[5].innerText.trim();
                sDrugStopDate += rows[i].children[6].innerText.trim();
                DrugIDList.push(rows[i].children[18].innerText.trim());
                DrugCountList.push(0);
                DrugNotesList.push(rows[i].children[8].innerText.trim());
                DrugStartDateList.push(rows[i].children[5].innerText.trim());
                DrugStopDateList.push(rows[i].children[6].innerText.trim());
                StrengthList.push(rows[i].children[3].innerText.trim());
                RouteList.push(rows[i].children[7].innerText.trim());
                FreqList.push(rows[i].children[4].innerText.trim());
                DrugDetailList.push(rows[i].children[2].innerText.trim() + (rows[i].children[3].innerText.trim() != "" ? " " + rows[i].children[3].innerText.trim() : "") + (rows[i].children[4].innerText.trim() != "" ? " " + rows[i].children[4].innerText.trim() : "") + (rows[i].children[7].innerText.trim() != "" ? " " + rows[i].children[7].innerText.trim() : "") + (rows[i].children[5].innerText.trim() != "" ? " from " + rows[i].children[5].innerText.trim() : "") + (rows[i].children[6].innerText.trim() != "" ? " to " + rows[i].children[6].innerText.trim() : ""));

            }
            else {
                DrugName += '|' + rows[i].children[2].innerText.trim();
                sDrugStartDate += '|' + rows[i].children[5].innerText.trim();
                sDrugStopDate += '|' + rows[i].children[6].innerText.trim();
                DrugIDList.push(rows[i].children[18].innerText.trim());
                DrugCountList.push(0);
                DrugNotesList.push(rows[i].children[8].innerText.trim());
                DrugStartDateList.push(rows[i].children[5].innerText.trim());
                DrugStopDateList.push(rows[i].children[6].innerText.trim());
                StrengthList.push(rows[i].children[3].innerText.trim());
                RouteList.push(rows[i].children[7].innerText.trim());
                FreqList.push(rows[i].children[4].innerText.trim());
                DrugDetailList.push(rows[i].children[2].innerText.trim() + (rows[i].children[3].innerText.trim() != "" ? " " + rows[i].children[3].innerText.trim() : "") + (rows[i].children[4].innerText.trim() != "" ? " " + rows[i].children[4].innerText.trim() : "") + (rows[i].children[7].innerText.trim() != "" ? " " + rows[i].children[7].innerText.trim() : "") + (rows[i].children[5].innerText.trim() != "" ? " from " + rows[i].children[5].innerText.trim() : "") + (rows[i].children[6].innerText.trim() != "" ? " to " + rows[i].children[6].innerText.trim() : ""));
            }

        }
    }

    if (DrugName != "") {
        $.ajax({
            type: "POST",
            url: "frmRxHistory.aspx/RequestSentLog",
            data: JSON.stringify({
                "data": DrugIDList,
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (data) {
                
                var result = $.parseJSON(data.d);
                var ReqSent = $.parseJSON(result).RequestSentList;
                var CreatedBy = $.parseJSON(result).CreatedBY;
                for (var i = 0; i < ReqSent.length; i++) {

                    DrugReqSentLogIDList[DrugIDList.indexOf(ReqSent[i].SourceID.toString())] = ReqSent[i].ReqSentLogID;
                    if (i == ReqSent.length - 1) {
                        sRequestSentLogID += ReqSent[i].ReqSentLogID;
                    }
                    else {
                        sRequestSentLogID += ReqSent[i].ReqSentLogID + '|';
                    }
                }
                if (top.window.document.getElementById("ctl00_hdnProjectName").value != '') {
                    Project_Name = top.window.document.getElementById("ctl00_hdnProjectName").value;
                }
                sCreatedBy = CreatedBy;

                var DrugAllergyList = $.parseJSON(result).DrugAllergyList;

                for (var j = 0; j < DrugAllergyList.length; j++) {
                    if (j == DrugAllergyList.length - 1) {
                        DrugAllergy += DrugAllergyList[j];
                    }
                    else {
                        DrugAllergy += DrugAllergyList[j] + '|';
                    }
                }

              
                    var WSData = JSON.stringify({
                        ProjectName: Project_Name,
                        sRequestSentLogID: sRequestSentLogID,
                        DrugName: DrugName,
                        sDrugStartDate: sDrugStartDate,
                        sDrugStopDate: sDrugStopDate,
                        DrugAllergy: DrugAllergy,
                        sCreatedBy: sCreatedBy,
                        AsOfDate:''
                    });

                    if (top.window.document.getElementById("ctl00_hdnMedReconcileURL").value != '')
                        var surl = top.window.document.getElementById("ctl00_hdnMedReconcileURL").value;

                    var Conflictpresent = false;

                    $.ajax({
                        type: "POST",
                        url: surl,
                        data: WSData,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {

                                sessionStorage.setItem("RowstoAppend", "");
                                var resultList = $.parseJSON(data.d);
                                var Exception = resultList.Exception;
                                if (Exception != undefined) {
                                    { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
                                    alert("USER MESSAGE:\n" + Exception.Message +
                            ". \nCannot process request. Please Login again and retry. If issue persists, Please contact Support.");

                                   // alert("USER MESSAGE:\n" +
                                   // ". Cannot process request. Please Login again and retry. \nEXCEPTION DETAILS: \n" +
                                   //"Message: " + log.Message);
                                }
                                else {
                                    var ReconciledList = $.parseJSON(resultList).ReconciledList;

                                    for (var i = 0; i < ReconciledList.length; i++) {
                                        DrugCountList[DrugReqSentLogIDList.indexOf(ReconciledList[i].ulDrugID)] += 1;
                                        DrugCountList[DrugReqSentLogIDList.indexOf(ReconciledList[i].ulPairDrugID)] += 1;
                                    }

                                    for (var i = 0; i < ReconciledList.length; i++) {
                                        ResponseSentIDList.push(ReconciledList[i].Response_Sent_Log_ID);
                                    }

                                    var count = 0;

                                    var DuplicateList = ReconciledList.filter(function (obj) {
                                        return obj.sConflictType == "DUPLICATE";
                                    });
                                    var InteractionList = ReconciledList.filter(function (obj) {
                                        return obj.sConflictType == "INTERACTION";
                                    });
                                    var AllergyList = ReconciledList.filter(function (obj) {
                                        return obj.sConflictType == "ALLERGY";
                                    });
                                    var DrugList = ReconciledList.filter(function (obj) {
                                        return obj.sConflictType == "NONE";
                                    });
                                    for (var k = 0; k < DrugReqSentLogIDList.length; k++) {
                                        var textareaID = "RxStopNotes" + DrugReqSentLogIDList[k];
                                        var fRow = true;
                                        for (var i = 0; i < DuplicateList.length; i++) {
                                            if (DrugReqSentLogIDList[k] == DuplicateList[i].ulDrugID || DrugReqSentLogIDList[k] == DuplicateList[i].ulPairDrugID) {
                                                if (DrugReqSentLogIDList[k] == DuplicateList[i].ulDrugID) {
                                                    var drug_index = DrugReqSentLogIDList.indexOf(DuplicateList[i].ulDrugID);
                                                    var drugpair_index = DrugReqSentLogIDList.indexOf(DuplicateList[i].ulPairDrugID);
                                                }
                                                else {
                                                    var drug_index = DrugReqSentLogIDList.indexOf(DuplicateList[i].ulPairDrugID);
                                                    var drugpair_index = DrugReqSentLogIDList.indexOf(DuplicateList[i].ulDrugID);
                                                }
                                                if (count % 2 == 0) {
                                                    color = ' style="background-color:#f5f9e0 !important;"';
                                                }
                                                else {
                                                    color = ' style="background-color:white !important;"';
                                                }

                                                if (fRow == true) {
                                                    var tr = '<tr ' + color + ' medhis_ID=' + DrugIDList[k] + ' name=' + DrugReqSentLogIDList[k] + '><td rowspan=' + DrugCountList[k] + '  id="idStop" style="width:5%"><input type="checkbox"  onclick="StopMedication(this);"></span></td><td  rowspan=' + DrugCountList[k] + '  id="idRetain" style="width:5%"><input type="checkbox" onclick="RetainMedication(this);"/></td><td  rowspan=' + DrugCountList[k] + '  id="idDrugName" style="width:10%"><span id="Drug_name">' + DrugDetailList[drug_index] + '</span></td><td  name=' + DrugReqSentLogIDList[drugpair_index] + ' id="idMessage" style="width:30%"><span>' + DuplicateList[i].sConflictMessage + '</span></td><td  rowspan=' + DrugCountList[k] + '  id="idNotes" style="width:20%"><span id="txtNotes">' + DrugNotesList[drug_index] + '</span></td><td  rowspan=' + DrugCountList[k] + '  id="idtextstopDate" style="width:11%"><input type="text" placeholder="yyyy-MMM-dd" class="form-control datecontrol" disabled/></td><td class="txtarea" rowspan=' + DrugCountList[k] + '  id="idstopNote" style="width:20%"><textarea id=' + textareaID + ' class="actcmpt form-control" name="Stop or Retain Notes' + DrugReqSentLogIDList[k] + '" textmode="MultiLine" style="position: static; display: inline-block; font-family: Microsoft Sans Serif; font-size: 9.5pt; resize: none;width:82%" disabled onkeydown="insertTab(this, event);"></textarea> <div class="col-6-btns" style=" float: right !important;margin-top: 16px;margin-left: 0px;margin-right: 0px;"> <a class=" fa fa-plus" style="margin-left: 0px; margin-right: 0px; text-decoration: none; padding: 4px 4px 4px 4px !important; background: #6DABF7; color: #fff; font-size: 12px; border-radius: 2px;" id="pbDropdownNotes" align="centre" font-bold="false" title="Drop down" onclick="callweb(this, \'Stop or Retain Notes\', \'' + textareaID + '\');"></a></div></td></tr> ';
                                                    fRow = false;
                                                }
                                                else {
                                                    var tr = '<tr ' + color + '  medhis_ID=' + DrugIDList[k] + ' name=' + DrugReqSentLogIDList[k] + '><td name=' + DrugReqSentLogIDList[drugpair_index] + '><span>' + DuplicateList[i].sConflictMessage + '</span></td></tr>';
                                                }

                                                sessionStorage.setItem("RowstoAppend", sessionStorage.getItem("RowstoAppend") + tr);

                                                Conflictpresent = true;

                                            }

                                        }
                                        for (var i = 0; i < AllergyList.length; i++) {
                                            if (DrugReqSentLogIDList[k] == AllergyList[i].ulDrugID || DrugReqSentLogIDList[k] == AllergyList[i].ulPairDrugID) {
                                                if (DrugReqSentLogIDList[k] == AllergyList[i].ulDrugID) {
                                                    var drug_index = DrugReqSentLogIDList.indexOf(AllergyList[i].ulDrugID);
                                                    var drugpair_index = DrugReqSentLogIDList.indexOf(AllergyList[i].ulPairDrugID);
                                                }
                                                else {
                                                    var drug_index = DrugReqSentLogIDList.indexOf(AllergyList[i].ulPairDrugID);
                                                    var drugpair_index = DrugReqSentLogIDList.indexOf(AllergyList[i].ulDrugID);
                                                }
                                                if (count % 2 == 0) {
                                                    color = ' style="background-color:#f5f9e0 !important;"';
                                                }
                                                else {
                                                    color = ' style="background-color:white !important;"';
                                                }
                                                if (fRow == true) {
                                                    var tr = '<tr' + color + ' medhis_ID=' + DrugIDList[k] + ' name=' + DrugReqSentLogIDList[k] + '><td rowspan=' + DrugCountList[k] + '  id="idStop" style="width:5%"><input type="checkbox"  onclick="StopMedication(this);"></span></td><td  rowspan=' + DrugCountList[k] + '  id="idRetain" style="width:5%"><input type="checkbox" onclick="RetainMedication(this);"/></td><td  rowspan=' + DrugCountList[k] + '  id="idDrugName" style="width:10%"><span id="Drug_name">' + DrugDetailList[drug_index] + '</span></td><td  name=' + DrugReqSentLogIDList[drugpair_index] + ' id="idMessage" style="width:30%"><span>' + AllergyList[i].sConflictMessage + '</span></td><td  rowspan=' + DrugCountList[k] + '  id="idNotes" style="width:20%"><span id="txtNotes">' + DrugNotesList[drug_index] + '</span></td><td  rowspan=' + DrugCountList[k] + '  id="idtextstopDate" style="width:11%"><input type="text" placeholder="yyyy-MMM-dd" class="form-control datecontrol" disabled/></td><td class="txtarea" rowspan=' + DrugCountList[k] + '  id="idstopNote" style="width:20%"><textarea id=' + textareaID + ' class="actcmpt form-control" name="Stop or Retain Notes' + DrugReqSentLogIDList[k] + '" textmode="MultiLine" style="position: static; display: inline-block; font-family: Microsoft Sans Serif; font-size: 9.5pt; resize: none;width:82%" disabled onkeydown="insertTab(this, event);"></textarea> <div class="col-6-btns" style=" float: right !important;margin-top: 16px;margin-left: 0px;margin-right: 0px;"> <a class=" fa fa-plus" style="margin-left: 0px; margin-right: 0px; text-decoration: none; padding: 4px 4px 4px 4px !important; background: #6DABF7; color: #fff; font-size: 12px; border-radius: 2px;" id="pbDropdownNotes" align="centre" font-bold="false" title="Drop down" onclick="callweb(this,\'Stop or Retain Notes\', \'' + textareaID + '\');"></a></div> </td></tr> ';
                                                    fRow = false;
                                                }
                                                else {
                                                    var tr = '<tr' + color + ' medhis_ID=' + DrugIDList[k] + ' name=' + DrugReqSentLogIDList[k] + '><td><span>' + AllergyList[i].sConflictMessage + '</span></td></tr>';
                                                }

                                                sessionStorage.setItem("RowstoAppend", sessionStorage.getItem("RowstoAppend") + tr);

                                                Conflictpresent = true;

                                            }

                                        }
                                        for (var i = 0; i < InteractionList.length; i++) {
                                            if (DrugReqSentLogIDList[k] == InteractionList[i].ulDrugID || DrugReqSentLogIDList[k] == InteractionList[i].ulPairDrugID) {
                                                if (DrugReqSentLogIDList[k] == InteractionList[i].ulDrugID) {
                                                    var drug_index = DrugReqSentLogIDList.indexOf(InteractionList[i].ulDrugID);
                                                    var drugpair_index = DrugReqSentLogIDList.indexOf(InteractionList[i].ulPairDrugID);
                                                }
                                                else {
                                                    var drug_index = DrugReqSentLogIDList.indexOf(InteractionList[i].ulPairDrugID);
                                                    var drugpair_index = DrugReqSentLogIDList.indexOf(InteractionList[i].ulDrugID);
                                                }
                                                if (count % 2 == 0) {
                                                    color = ' style="background-color:#f5f9e0 !important;"';
                                                }
                                                else {
                                                    color = ' style="background-color:white !important;"';
                                                }
                                                if (fRow == true) {
                                                    var tr = '<tr' + color + ' medhis_ID=' + DrugIDList[k] + ' name=' + DrugReqSentLogIDList[k] + '><td rowspan=' + DrugCountList[k] + '  id="idStop" style="width:5%"><input type="checkbox"  onclick="StopMedication(this);"></span></td><td  rowspan=' + DrugCountList[k] + '  id="idRetain" style="width:5%"><input type="checkbox" onclick="RetainMedication(this);"/></td><td  rowspan=' + DrugCountList[k] + '  id="idDrugName" style="width:10%"><span id="Drug_name">' + DrugDetailList[drug_index] + '</span></td><td  name=' + DrugReqSentLogIDList[drugpair_index] + ' id="idMessage" style="width:30%"><span>' + InteractionList[i].sConflictMessage + '</span></td><td  rowspan=' + DrugCountList[k] + '  id="idNotes" style="width:20%"><span id="txtNotes">' + DrugNotesList[drug_index] + '</span></td><td  rowspan=' + DrugCountList[k] + '  id="idtextstopDate" style="width:11%"><input type="text" placeholder="yyyy-MMM-dd" class="form-control datecontrol" disabled/></td><td class="txtarea" rowspan=' + DrugCountList[k] + '  id="idstopNote" style="width:20%"><textarea id=' + textareaID + ' class="actcmpt form-control" name="Stop or Retain Notes' + DrugReqSentLogIDList[k] + '" textmode="MultiLine" style="position: static; display: inline-block; font-family: Microsoft Sans Serif; font-size: 9.5pt; resize: none;width:82%" disabled onkeydown="insertTab(this, event);"></textarea> <div class="col-6-btns" style=" float: right !important;margin-top: 16px;margin-left: 0px;margin-right: 0px;"> <a class=" fa fa-plus" style="margin-left: 0px; margin-right: 0px; text-decoration: none; padding: 4px 4px 4px 4px !important; background: #6DABF7; color: #fff; font-size: 12px; border-radius: 2px;" id="pbDropdownNotes" align="centre" font-bold="false" title="Drop down" onclick="callweb(this,\'Stop or Retain Notes\', \'' + textareaID + '\');"></a></div></td></tr> ';
                                                    fRow = false;
                                                }
                                                else {
                                                    var tr = '<tr' + color + ' medhis_ID=' + DrugIDList[k] + ' name=' + DrugReqSentLogIDList[k] + '><td name=' + DrugReqSentLogIDList[drugpair_index] + ' id="idMessage"><span>' + InteractionList[i].sConflictMessage + '</span></td></tr>';
                                                }

                                                sessionStorage.setItem("RowstoAppend", sessionStorage.getItem("RowstoAppend") + tr);

                                                Conflictpresent = true;

                                            }

                                        }
                                        if (triggeredBy == "") { //When clicked through Reconcile Button only

                                            for (var j = 0; j < DrugList.length; j++) {
                                                if (DrugReqSentLogIDList[k] == DrugList[j].ulDrugID) {
                                                    var drug_index = DrugReqSentLogIDList.indexOf(DrugList[j].ulDrugID);
                                                    var rowspan = 1;
                                                    if (count % 2 == 0) {
                                                        color = ' style="background-color:#f5f9e0 !important;"';
                                                    }
                                                    else {
                                                        color = ' style="background-color:white !important;"';
                                                    }
                                                    if (DrugList[j].sConflictMessage.trim() == "Free Text Medication")
                                                        var tr = '<tr' + color + '  medhis_ID=' + DrugIDList[k] + ' name=' + DrugReqSentLogIDList[k] + '><td rowspan=' + DrugCountList[k] + '  id="idStop" style="width:5%"></td><td  rowspan=' + DrugCountList[k] + '  id="idRetain" style="width:5%"></td><td  rowspan=' + DrugCountList[k] + '  id="idDrugName" style="width:10%"><img src="Resources/freetxt.png" style="margin-left: -4px;height: 15px;margin-right: 2px;margin-top: -4px;"/><span id="Drug_name">' + DrugDetailList[drug_index] + '</span></td><td  name=' + DrugReqSentLogIDList[drugpair_index] + ' id="idMessage" style="width:30%"><span>' + DrugList[j].sConflictMessage + '</span></td><td  rowspan=' + DrugCountList[k] + '  id="idNotes" style="width:20%"><span id="txtNotes">' + DrugNotesList[drug_index] + '</span></td><td  rowspan=' + DrugCountList[k] + '  id="idtextstopDate" style="width:11%"><input type="text" placeholder="yyyy-MMM-dd" class="form-control datecontrol" disabled/></td><td class="txtarea" rowspan=' + DrugCountList[k] + '  id="idstopNote"><textarea onkeydown="insertTab(this, event);" id=' + textareaID + ' class="actcmpt form-control" name="Stop or Retain Notes' + DrugReqSentLogIDList[k] + '" textmode="MultiLine" style="position: static; display: inline-block; font-family: Microsoft Sans Serif; font-size: 9.5pt; resize: none;width:82%"  disabled onkeydown="insertTab(this, event);"></textarea> <div class="col-6-btns" style=" float: right !important;margin-top: 16px;margin-left: 0px;margin-right: 0px;"> <a class=" fa fa-plus" style="margin-left: 0px; margin-right: 0px; text-decoration: none; padding: 4px 4px 4px 4px !important; background: #6DABF7; color: #fff; font-size: 12px; border-radius: 2px;" id="pbDropdownNotes" align="centre" font-bold="false" title="Drop down" onclick="callweb(this,\'Stop or Retain Notes\', \'' + textareaID + '\');"></a></div></td></tr> ';
                                                    else
                                                        var tr = '<tr' + color + ' medhis_ID=' + DrugIDList[k] + ' name=' + DrugReqSentLogIDList[k] + '><td rowspan=' + DrugCountList[k] + '  id="idStop" style="width:5%"><td  rowspan=' + DrugCountList[k] + '  id="idRetain" style="width:5%"></td><td  rowspan=' + DrugCountList[k] + '  id="idDrugName" style="width:10%"><span id="Drug_name">' + DrugDetailList[drug_index] + '</span></td><td  name=' + DrugReqSentLogIDList[drugpair_index] + ' id="idMessage" style="width:30%"><span>' + DrugList[j].sConflictMessage + '</span></td><td  rowspan=' + DrugCountList[k] + '  id="idNotes" style="width:20%"><span id="txtNotes">' + DrugNotesList[drug_index] + '</span></td><td  rowspan=' + DrugCountList[k] + '  id="idtextstopDate" style="width:11%"><input type="text" placeholder="yyyy-MMM-dd" class="form-control datecontrol" disabled/></td><td class="txtarea"  rowspan=' + DrugCountList[k] + '  id="idstopNote"><textarea id=' + textareaID + ' class="actcmpt form-control" name="Stop or Retain Notes' + DrugReqSentLogIDList[k] + '" textmode="MultiLine" style="position: static; display: inline-block; font-family: Microsoft Sans Serif; font-size: 9.5pt; resize: none;width:82%" disabled></textarea> <div class="col-6-btns" style=" float: right !important;margin-top: 16px;margin-left: 0px;margin-right: 0px;"> <a class=" fa fa-plus" style="margin-left: 0px; margin-right: 0px; text-decoration: none; padding: 4px 4px 4px 4px !important; background: #6DABF7; color: #fff; font-size: 12px; border-radius: 2px;" id="pbDropdownNotes" align="centre" font-bold="false" title="Drop down" onclick="callweb(this, "Stop or Retain Notes", \'' + textareaID + '\');"></a></div> </td></tr> ';


                                                    sessionStorage.setItem("RowstoAppend", sessionStorage.getItem("RowstoAppend") + tr);
                                                }

                                            }
                                        }
                                        else {
                                            break;//perform checking only for last added row.
                                        }
                                        count++;
                                    }
                                    if (triggeredBy != "" && Conflictpresent == true) {
                                        OpenReconciliation('ADD');
                                    }
                                    else {
                                        if (Conflictpresent == true) {
                                            OpenReconciliation('');
                                        }
                                        else if (Conflictpresent == false && triggeredBy == "") {

                                            DisplayErrorMessage('3005');
                                            { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
                                        }

                                        { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
                                    }
                                    RefreshNotification('RxHistory');
                                    InvokeResponseReceivedLog(ResponseSentIDList);
                                }
                          
                        },
                        error: function OnError(xhr) {
                            { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
                            var log = JSON.parse(xhr.responseText);
                            console.log(log);
                            if (xhr.status == 999)
                                window.location = "/frmSessionExpired.aspx";
                            else
                                alert("USER MESSAGE:\n" +
                                    ". Cannot process request. Please Login again and retry. \nEXCEPTION DETAILS: \n" +
                                   "Message: " + log.Message);
                        }
                    });
            },
            error: function OnError(xhr) {
                { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
                var log = JSON.parse(xhr.responseText);
                console.log(log);
                if (xhr.status == 999)
                    window.location = "/frmSessionExpired.aspx";
                else
                    alert("USER MESSAGE:\n" +
                                    ". Cannot process request. Please Login again and retry. \nEXCEPTION DETAILS: \n" +
                                   "Message: " + log.Message);
            }
        });
    }
    else {
        $(top.window.document).find("#btnClose").click();
        DisplayErrorMessage('3004');
        { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
    }
   

}


function WebServiceRequestError(responseText, status, statusText) {
    { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
    var log = JSON.parse(xhr.responseText);
    console.log(log);
    if (xhr.status == 999)
        window.location = "/frmSessionExpired.aspx";
    else
        alert("USER MESSAGE:\n" +
                                    ". Cannot process request. Please Login again and retry. \nEXCEPTION DETAILS: \n" +
                                   "Message: " + log.Message);
}

function InvokeResponseReceivedLog(ResponseSentIDList) {
    $.ajax({
        type: "POST",
        url: "frmRxHistory.aspx/ResponseReceivedLog",
        data: JSON.stringify({
            "data": ResponseSentIDList,
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) { },
        error: function OnError(xhr) {
            { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
            var log = JSON.parse(xhr.responseText);
            console.log(log);
            if (xhr.status == 999)
                window.location = "/frmSessionExpired.aspx";
            else
                alert("USER MESSAGE:\n" +
                                    ". Cannot process request. Please Login again and retry. \nEXCEPTION DETAILS: \n" +
                                   "Message: " + log.Message);
        }
    });
}

function OpenReconciliation(data) {
        $(top.window.document).find('#ProcessModal').modal({ backdrop: 'static', keyboard: false }, 'show');
        var sPath = ""
        sPath = "HtmlMedicalReconciliation.html?version=" + sessionStorage.getItem("ScriptVersion") + "&triggeredBy=" + data;
        $(top.window.document).find("#mdldlg")[0].style.width = "85%";
        $(top.window.document).find("#mdldlg")[0].style.height = "91%";
        $(top.window.document).find("#ProcessFrame")[0].style.height = "108%";
        $(top.window.document).find("#ProcessFrame")[0].style.width = "99%";
        $(top.window.document).find("#ProcessModal")[0].style.height = "";
        $(top.window.document).find("#ProcessModal")[0].style.width = "";
        $(top.window.document).find("#ProcessModal")[0].style.zIndex = "1051";
        $(top.window.document).find('#ProcessFrame')[0].contentDocument.location.href = sPath;
        $(top.window.document).find("#ModalTitle")[0].textContent = "Reconcile Alert";
        { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
       
}

function autoSave() {
    { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
        $(dvdialogMedReconcile).dialog({
            modal: true,
            title: "Capella EHR",
            position: {
                my: 'center',
                at: 'center + 100px'
            },
            buttons: {
                "Yes": function () {
                    $(dvdialogMedReconcile).dialog("close");
                    $("#btnSave").click();
                },
                "No": function () {
                    $(dvdialogMedReconcile).dialog("close");
                    setSaveDisabled();
                    $(top.window.document).find("#btnClose").click();
                    reloadTableRx_History();
                },
                "Cancel": function () {
                    SetSaveEnabled();
                    $(dvdialogMedReconcile).dialog("close");
                }
            }
        });
    }