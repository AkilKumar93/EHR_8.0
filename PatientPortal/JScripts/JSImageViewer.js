function mouseDown(i) {
    try {
        if (2 == event.button || 3 == event.button) return !1
    } catch (i) {
        if (3 == i.which) return !1
    }
}
function setNotesValue() {
    //  document.getElementById('txtmsghistory').value = document.getElementById('hdnnotes').value.replace("<br />", "\n");
    document.getElementById('txtmsghistory').value = document.getElementById('hdnnotes').value.split('<br />').join("\n");

    var id = $('#hdnPageBox').val();

    $("input[id*='pg_']").removeClass('thumbnailactive');
    $('#pgCompare_' + id).addClass('thumbnailactive');
    return false;
}
function SetFaxValue() {
    //  document.getElementById('txtmsghistory').value = document.getElementById('hdnnotes').value.replace("<br />", "\n");
    var id = $('#hdnPageBox').val();
    $("input[id*='pg_']").removeClass('thumbnailactive');
    $('#pg_' + id).addClass('thumbnailactive');
    return false;
}
function setNotesValueActual() {

    document.getElementById('txtmsghistory').value = document.getElementById('hdnnotes').value.split('<br />').join("\n");
    document.getElementById('PageBoxcom').value = $('#hdnpgno1').val();
    var id = $('#hdnpgno1').val();

    $("input[id*='pgCompare_']").removeClass('thumbnailCompareactive');
    $('#pgCompare_' + id).addClass('thumbnailCompareactive');
    //document.getElementById('txtmsghistory').value = document.getElementById('hdnnotesCompare').value.split('<br />').join("\n");

}
function setNotesValueCompare() {
    //  document.getElementById('txtmsghistory').value = document.getElementById('hdnnotes').value.replace("<br />", "\n");
    var id = $('#PageBox').val();

    $("input[id*='pgact_']").removeClass('thumbnailCompareactiveActual');
    $('#pgact_' + id).addClass('thumbnailCompareactiveActual');

    document.getElementById('txtmsghistorycomp').value = document.getElementById('hdnnotesCompare').value.split('<br />').join("\n");
}
function closepopup() {
    //  $(top.window.document).find("#btnClose").click();

    if (document.getElementById('txtmessage').value != "" || (!document.getElementById('btnsave').disabled)) {
        $("body").append("<div id='dvdialogMenu' style='min-height: 65px !important; width: auto; max-height: none; height: auto; display: none;'>" +
                               "<p style='font-family: Verdana,Arial,sans-serif; font-size: 12.5px;'>There are unsaved changes.Do you want to save them?</p></div>")
        dvdialog = $('#dvdialogMenu');
        myPos = "center center";
        atPos = 'center center';
        event.preventDefault();

        $(dvdialog).dialog({
            modal: true,
            title: "Capella EHR",
            position: {
                my: 'left' + " " + 'center',
                at: 'center' + " " + 'center + 100px'

            },
            buttons: {
                "Yes": function () {
                    $(dvdialog).dialog("close");
                    $(dvdialog).remove();
                    sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();
                    btnsaveClick();

                    return false;
                },
                "No": function () {
                    $(dvdialog).dialog("close");
                    $(dvdialog).remove();
                    $(top.window.document).find("#btnCloseExam").click();
                    return false;
                },
                "Cancel": function () {
                    $(dvdialog).dialog("close");
                    $(dvdialog).remove();
                    return false;
                }
            }
        });
    }
    else {
        $(top.window.document).find("#btnCloseExam").click();
        return false;
    }
}
function enablesave() {
    document.getElementById('btnsave').disabled = false;
}
function closeComparepopup() {

    if (document.getElementById('txtmessage').value != "" || document.getElementById('txtmessagecomp').value != "" || (!document.getElementById('btnsave').disabled)) {
        $("body").append("<div id='dvdialogMenu' style='min-height: 65px !important; width: auto; max-height: none; height: auto; display: none;'>" +
                               "<p style='font-family: Verdana,Arial,sans-serif; font-size: 12.5px;'>There are unsaved changes.Do you want to save them?</p></div>")
        dvdialog = $('#dvdialogMenu');
        myPos = "center center";
        atPos = 'center center';
        event.preventDefault();

        $(dvdialog).dialog({
            modal: true,
            title: "Capella EHR",
            position: {
                my: 'left' + " " + 'center',
                at: 'center' + " " + 'center + 100px'

            },
            buttons: {
                "Yes": function () {
                    $(dvdialog).dialog("close");
                    $(dvdialog).remove();
                    sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();

                    //saveclickCompareautosave();
                    saveclickComparesave();//For Bug ID : 57224
                    return false;
                },
                "No": function () {
                    $(dvdialog).dialog("close");
                    $(dvdialog).remove();
                    $(top.window.document).find("#btnCloseCOmpare").click();
                    return false;
                },
                "Cancel": function () {
                    $(dvdialog).dialog("close");
                    $(dvdialog).remove();
                    return false;
                }
            }
        });
    }
    else {
        $(top.window.document).find("#btnCloseCOmpare").click();
        return false;
    }
}
function StopLoadFromPatChart() {
    jQuery(window.top.parent.parent.parent.parent.parent.parent.document.body).find('#resultLoading .bg').height('100%');
    jQuery(window.top.parent.parent.parent.parent.parent.parent.document.body).find('#resultLoading').fadeOut(300);
    jQuery(window.top.parent.parent.parent.parent.document.body).css('cursor', 'default');
    if (jQuery(window.top.parent.parent.parent.parent.parent.parent.document.body).find('#resultLoading').css('display') == 'block')
        jQuery(window.top.parent.parent.parent.parent.parent.parent.document.body).find('#resultLoading').remove();
    //jQuery('.masterLoad .bg').height('100%');
    //jQuery('.masterLoad').fadeOut(300);
    //jQuery(window.top.parent.parent.parent.parent.document.body).css('cursor', 'default');
}

function ChangePgact(i, t, e, notes, id, j) {
    if (notes != undefined && notes != null && id != undefined && id != null) {
        document.getElementById('hdnnotes').value = notes.replace("<br />", "\n");
        document.getElementById('hdnfileindexid').value = id;
        if (notes != "")
            document.getElementById('txtmsghistory').value = notes.split('<br />').join("\n");

        $.ajax({
            type: "POST",
            url: "frmImageViewer.aspx/RefreshNotes",
            data: JSON.stringify({

                "FileId": document.getElementById('hdnfileindexid').value

            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: function (data) {
                document.getElementById('hdnnotes').value = data.d;
                document.getElementById('txtmsghistory').value = data.d.split('<br />').join("\n");
                document.getElementById('txtmessage').value = "";


            },
            error: function OnError(xhr) {
                StopLoadFromPatChart();
                if (xhr.status == 999)
                    window.location = xhr.statusText;
                else {
                    var log = JSON.parse(xhr.responseText);
                    console.log(log);
                    alert("USER MESSAGE:\n" + xhr.status + "-" + xhr.statusText +
                        ". \nCannot process request. Please Login again and retry. If issue persists, Please contact Support.\n\nEXCEPTION DETAILS: \nException Type" +
                        log.ExceptionType + " \nMessage: " + log.Message);
                }
            }
        });
    }



    if (document.getElementById("_imgBig") != undefined) {
        src1 = "ViewImg.aspx?View=1&FilePath=" + t + "&Pg=" + i + "&Height=" + GetBigSrc("Height") + "&Width=" + GetBigSrc("Width"), SrcBig = "ViewImg.aspx?View=1&FilePath=" + GetBigSrc("FilePath") + "&Pg=" + i + "&Height=1000&Width=1000", SrcRevert = "ViewImg.aspx?View=1&FilePath=" + GetBigSrc("FilePath") + "&Pg=" + i + "&Height=600&Width=600", SrcNavigate = "ViewImg.aspx?View=1&FilePath=" + GetBigSrc("FilePath") + "&Height=600&Width=600", $("#_plcImgsThumbs").find(".thumbnailactive").removeClass("thumbnailactive").addClass("thumbnail"), $("#_plcImgsThumbs").find("#" + e).removeClass("thumbnail").addClass("thumbnailactive");
        document.getElementById("_imgBig").src = src1;
    }
    if (t.toUpperCase().indexOf(".PDF") < 0 && document.getElementById("_imgBigActual") != undefined) {
        Src = "ViewImg.aspx?View=1&FilePath=" + t + "&Pg=" + i + "&Height=" + GetBigSrcActual("Height") + "&Width=" + GetBigSrcActual("Width"), SrcBig = "ViewImg.aspx?View=1&FilePath=" + GetBigSrcActual("FilePath") + "&Pg=" + i + "&Height=1000&Width=1000", SrcRevert = "ViewImg.aspx?View=1&FilePath=" + GetBigSrcActual("FilePath") + "&Pg=" + i + "&Height=600&Width=600", SrcNavigate = "ViewImg.aspx?View=1&FilePath=" + GetBigSrcActual("FilePath") + "&Height=600&Width=600", $("#_plcImgsThumbs").find(".thumbnailCompareactiveActual").removeClass("thumbnailCompareactiveActual").addClass("thumbnail"), $("#_plcImgsThumbs").find("#" + e).removeClass("thumbnail").addClass("thumbnailCompareactiveActual");
        document.getElementById("_imgBigActual").src = Src;
        $('#bigImgPDF').css("display", "none")
        $('#_imgBigActual').css("display", "block")
        document.getElementById("hdnimagesource").value = Src;
        $('#PDFholder').css("display", "none")
        $('#imgholder').css("display", "block")
        document.getElementById("hdnpdf").value = "";
        document.getElementById("hdnpdfnotes").value = "";
        $('#divrotate').css("display", "inline-block");



    }

    if (t.toUpperCase().indexOf(".PDF") >= 0 && document.getElementById("bigImgPDF") != undefined) {
        // Src = "ViewImg.aspx?View=1&FilePath=" + t + "&Pg=" + i + "&Height=" + GetBigSrcActual("Height") + "&Width=" + GetBigSrcActual("Width"), SrcBig = "ViewImg.aspx?View=1&FilePath=" + GetBigSrcActual("FilePath") + "&Pg=" + i + "&Height=1000&Width=1000", SrcRevert = "ViewImg.aspx?View=1&FilePath=" + GetBigSrcActual("FilePath") + "&Pg=" + i + "&Height=600&Width=600", SrcNavigate = "ViewImg.aspx?View=1&FilePath=" + GetBigSrcActual("FilePath") + "&Height=600&Width=600", $("#_plcImgsThumbs").find(".thumbnailCompareactiveActual").removeClass("thumbnailCompareactiveActual").addClass("thumbnail"), $("#_plcImgsThumbs").find("#" + e).removeClass("thumbnail").addClass("thumbnailCompareactiveActual");
        // document.getElementById("bigImgPDF").src = GetBigSrcActual("FilePath");

        $("#_plcImgsThumbs").find(".thumbnailCompareactiveActual").removeClass("thumbnailCompareactiveActual").addClass("thumbnail");
        $("#_plcImgsThumbs").find("#" + e).removeClass("thumbnail").addClass("thumbnailCompareactiveActual");
        $('#bigImgPDF').css("display", "block")
        $('#_imgBigActual').css("display", "none")
        $('#PDFholder').css("display", "block")
        $('#imgholder').css("display", "none")
        document.getElementById("hdnimagesource").value = "";
        document.getElementById("hdnid").value = e;
        document.getElementById("hdnpdf").value = t;
        if ($("#PageBox") != undefined && $("#PageBox").length > 0)
            $("#PageBox")[0].value = j;

        document.getElementById("hdnpgno").value = j;
        document.getElementById("hdnpdfnotes").value = "Y";
        $('#divrotate').css("display", "none");
        document.getElementById("hdnpgno1").value = $("#PageBoxcom")[0].value;
        document.getElementById("hdidcompare").value = $("#PageBoxcom")[0].value
        document.getElementById("btnhidden").click();

        return true;
    }
    if ($("#PageBox") != undefined && $("#PageBox").length > 0)
        $("#PageBox")[0].value = j;

}
function ChangePg(i, t, e, notes, id, j) {
    if (notes != undefined && notes != null && id != undefined && id != null) {
        document.getElementById('hdnnotes').value = notes.replace("<br />", "\n");
        document.getElementById('hdnfileindexid').value = id;
        if (notes != "") {
            document.getElementById('txtmsghistory').value = notes.split('<br />').join("\n");

            $.ajax({
                type: "POST",
                url: "frmImageViewer.aspx/RefreshNotes",

                data: JSON.stringify({

                    "FileId": document.getElementById('hdnfileindexid').value

                }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    document.getElementById('hdnnotes').value = data.d;
                    document.getElementById('txtmsghistory').value = data.d.split('<br />').join("\n");
                    document.getElementById('txtmessage').value = "";

                    if (t.toUpperCase().indexOf(".PDF") < 0) {
                        Src = "ViewImg.aspx?View=1&FilePath=" + t + "&Pg=" + i + "&Height=" + GetBigSrc("Height") + "&Width=" + GetBigSrc("Width"), SrcBig = "ViewImg.aspx?View=1&FilePath=" + GetBigSrc("FilePath") + "&Pg=" + i + "&Height=1000&Width=1000", SrcRevert = "ViewImg.aspx?View=1&FilePath=" + GetBigSrc("FilePath") + "&Pg=" + i + "&Height=600&Width=600", SrcNavigate = "ViewImg.aspx?View=1&FilePath=" + GetBigSrc("FilePath") + "&Height=600&Width=600", $("#_plcImgsThumbs").find(".thumbnailactive").removeClass("thumbnailactive").addClass("thumbnail"), $("#_plcImgsThumbs").find("#" + e).removeClass("thumbnail").addClass("thumbnailactive"), document.getElementById("_imgBig").src = Src

                        $('#bigImgPDF').css("display", "none");
                        $('#_imgBig').css("display", "block");
                        $('#divrotate').css("display", "inline-block");

                        document.getElementById("hdnpdfnotes").value = '';
                        $('#PDFholder').css("display", "none")
                        $('#imgholder').css("display", "block")
                        document.getElementById("hdnpdf").value = "";
                    }

                    if (t.toUpperCase().indexOf(".PDF") >= 0 && document.getElementById("bigImgPDF") != undefined) {
                        // Src = "ViewImg.aspx?View=1&FilePath=" + t + "&Pg=" + i + "&Height=" + GetBigSrcActual("Height") + "&Width=" + GetBigSrcActual("Width"), SrcBig = "ViewImg.aspx?View=1&FilePath=" + GetBigSrcActual("FilePath") + "&Pg=" + i + "&Height=1000&Width=1000", SrcRevert = "ViewImg.aspx?View=1&FilePath=" + GetBigSrcActual("FilePath") + "&Pg=" + i + "&Height=600&Width=600", SrcNavigate = "ViewImg.aspx?View=1&FilePath=" + GetBigSrcActual("FilePath") + "&Height=600&Width=600", $("#_plcImgsThumbs").find(".thumbnailCompareactiveActual").removeClass("thumbnailCompareactiveActual").addClass("thumbnail"), $("#_plcImgsThumbs").find("#" + e).removeClass("thumbnail").addClass("thumbnailCompareactiveActual");
                        // document.getElementById("bigImgPDF").src = GetBigSrcActual("FilePath");
                        $('#divrotate').css("display", "none");
                        $("#_plcImgsThumbs").find(".thumbnailactive").removeClass("thumbnailactive").addClass("thumbnail");
                        $("#_plcImgsThumbs").find("#" + e).removeClass("thumbnail").addClass("thumbnailactive");
                        $('#bigImgPDF').css("display", "block")
                        $('#_imgBig').css("display", "none")
                        $('#PDFholder').css("display", "block")
                        $('#imgholder').css("display", "none")

                        document.getElementById("hdnid").value = e;
                        document.getElementById("hdnpdf").value = t;
                        if ($("#PageBox") != undefined && $("#PageBox").length > 0) {

                            if (j != null && j != undefined) {
                                $("#PageBox")[0].value = j;
                                document.getElementById("hdnPageBox").value = j;
                            }
                            else {
                                if (i != null && i != undefined) {
                                    $("#PageBox")[0].value = i;
                                    document.getElementById("hdnPageBox").value = i;
                                }
                            }
                        }

                        document.getElementById("hdnpdfnotes").value = 'Y';


                        document.getElementById("btnhidden").click();
                        return true;
                    }

                },
                error: function OnError(xhr) {
                    StopLoadFromPatChart();
                    if (xhr.status == 999)
                        window.location = xhr.statusText;
                    else {
                        var log = JSON.parse(xhr.responseText);
                        console.log(log);
                        alert("USER MESSAGE:\n" + xhr.status + "-" + xhr.statusText +
                            ". \nCannot process request. Please Login again and retry. If issue persists, Please contact Support.\n\nEXCEPTION DETAILS: \nException Type" +
                            log.ExceptionType + " \nMessage: " + log.Message);
                    }
                }
            });
        }
    }
    if (t.toUpperCase().indexOf(".PDF") < 0) {
        Src = "ViewImg.aspx?View=1&FilePath=" + t + "&Pg=" + i + "&Height=" + GetBigSrc("Height") + "&Width=" + GetBigSrc("Width"), SrcBig = "ViewImg.aspx?View=1&FilePath=" + GetBigSrc("FilePath") + "&Pg=" + i + "&Height=1000&Width=1000", SrcRevert = "ViewImg.aspx?View=1&FilePath=" + GetBigSrc("FilePath") + "&Pg=" + i + "&Height=600&Width=600", SrcNavigate = "ViewImg.aspx?View=1&FilePath=" + GetBigSrc("FilePath") + "&Height=600&Width=600", $("#_plcImgsThumbs").find(".thumbnailactive").removeClass("thumbnailactive").addClass("thumbnail"), $("#_plcImgsThumbs").find("#" + e).removeClass("thumbnail").addClass("thumbnailactive"), document.getElementById("_imgBig").src = Src

        $('#bigImgPDF').css("display", "none");
        $('#_imgBig').css("display", "block");
        $('#divrotate').css("display", "inline-block");

        document.getElementById("hdnpdfnotes").value = '';
        $('#PDFholder').css("display", "none")
        $('#imgholder').css("display", "block")
        document.getElementById("hdnpdf").value = "";
    }
    if (t.toUpperCase().indexOf(".PDF") >= 0 && document.getElementById("bigImgPDF") != undefined) {
        // Src = "ViewImg.aspx?View=1&FilePath=" + t + "&Pg=" + i + "&Height=" + GetBigSrcActual("Height") + "&Width=" + GetBigSrcActual("Width"), SrcBig = "ViewImg.aspx?View=1&FilePath=" + GetBigSrcActual("FilePath") + "&Pg=" + i + "&Height=1000&Width=1000", SrcRevert = "ViewImg.aspx?View=1&FilePath=" + GetBigSrcActual("FilePath") + "&Pg=" + i + "&Height=600&Width=600", SrcNavigate = "ViewImg.aspx?View=1&FilePath=" + GetBigSrcActual("FilePath") + "&Height=600&Width=600", $("#_plcImgsThumbs").find(".thumbnailCompareactiveActual").removeClass("thumbnailCompareactiveActual").addClass("thumbnail"), $("#_plcImgsThumbs").find("#" + e).removeClass("thumbnail").addClass("thumbnailCompareactiveActual");
        // document.getElementById("bigImgPDF").src = GetBigSrcActual("FilePath");
        $('#divrotate').css("display", "none");
        $("#_plcImgsThumbs").find(".thumbnailactive").removeClass("thumbnailactive").addClass("thumbnail");
        $("#_plcImgsThumbs").find("#" + e).removeClass("thumbnail").addClass("thumbnailactive");
        $('#bigImgPDF').css("display", "block")
        $('#_imgBig').css("display", "none")
        $('#PDFholder').css("display", "block")
        $('#imgholder').css("display", "none")

        document.getElementById("hdnid").value = e;
        document.getElementById("hdnpdf").value = t;
        if ($("#PageBox") != undefined && $("#PageBox").length > 0) {

            if (j != null && j != undefined) {
                $("#PageBox")[0].value = j;
                document.getElementById("hdnPageBox").value = j;
            }
            else {
                if (i != null && i != undefined) {
                    $("#PageBox")[0].value = i;
                    document.getElementById("hdnPageBox").value = i;
                }
            }
        }

        document.getElementById("hdnpdfnotes").value = 'Y';


        document.getElementById("btnhidden").click();
        return true;
    }
    if ($("#PageBox") != undefined && $("#PageBox").length > 0) {

        if (j != null && j != undefined) {
            $("#PageBox")[0].value = j;
        }
        else {
            if (i != null && i != undefined) {
                $("#PageBox")[0].value = i;
            }
        }
    }

}


function ChangePgfax(i, t, e, notes, id, j) {
    if (notes != undefined && notes != null && id != undefined && id != null) {
        document.getElementById('hdnnotes').value = notes.replace("<br />", "\n");
        document.getElementById('hdnfileindexid').value = id;

    }
    if (t.toUpperCase().indexOf(".PDF") < 0) {
        Src = "ViewImg.aspx?View=1&FilePath=" + t + "&Pg=" + i + "&Height=" + GetBigSrc("Height") + "&Width=" + GetBigSrc("Width"), SrcBig = "ViewImg.aspx?View=1&FilePath=" + GetBigSrc("FilePath") + "&Pg=" + i + "&Height=1000&Width=1000", SrcRevert = "ViewImg.aspx?View=1&FilePath=" + GetBigSrc("FilePath") + "&Pg=" + i + "&Height=600&Width=600", SrcNavigate = "ViewImg.aspx?View=1&FilePath=" + GetBigSrc("FilePath") + "&Height=600&Width=600", $("#_plcImgsThumbs").find(".thumbnailactive").removeClass("thumbnailactive").addClass("thumbnail"), $("#_plcImgsThumbs").find("#" + e).removeClass("thumbnail").addClass("thumbnailactive"), document.getElementById("_imgBig").src = Src

        $('#bigImgPDF').css("display", "none");
        $('#_imgBig').css("display", "block");
        $('#divrotate').css("display", "inline-block");

        document.getElementById("hdnpdfnotes").value = '';
        $('#PDFholder').css("display", "none")
        $('#imgholder').css("display", "block")
        document.getElementById("hdnpdf").value = "";
    }
    if (t.toUpperCase().indexOf(".PDF") >= 0 && document.getElementById("bigImgPDF") != undefined) {
        // Src = "ViewImg.aspx?View=1&FilePath=" + t + "&Pg=" + i + "&Height=" + GetBigSrcActual("Height") + "&Width=" + GetBigSrcActual("Width"), SrcBig = "ViewImg.aspx?View=1&FilePath=" + GetBigSrcActual("FilePath") + "&Pg=" + i + "&Height=1000&Width=1000", SrcRevert = "ViewImg.aspx?View=1&FilePath=" + GetBigSrcActual("FilePath") + "&Pg=" + i + "&Height=600&Width=600", SrcNavigate = "ViewImg.aspx?View=1&FilePath=" + GetBigSrcActual("FilePath") + "&Height=600&Width=600", $("#_plcImgsThumbs").find(".thumbnailCompareactiveActual").removeClass("thumbnailCompareactiveActual").addClass("thumbnail"), $("#_plcImgsThumbs").find("#" + e).removeClass("thumbnail").addClass("thumbnailCompareactiveActual");
        // document.getElementById("bigImgPDF").src = GetBigSrcActual("FilePath");
        $('#divrotate').css("display", "none");
        $("#_plcImgsThumbs").find(".thumbnailactive").removeClass("thumbnailactive").addClass("thumbnail");
        $("#_plcImgsThumbs").find("#" + e).removeClass("thumbnail").addClass("thumbnailactive");
        $('#bigImgPDF').css("display", "block")
        $('#_imgBig').css("display", "none")
        $('#PDFholder').css("display", "block")
        $('#imgholder').css("display", "none")

        document.getElementById("hdnid").value = e;
        document.getElementById("hdnpdf").value = t;
        if ($("#PageBox") != undefined && $("#PageBox").length > 0) {

            if (j != null && j != undefined) {
                $("#PageBox")[0].value = j;
                document.getElementById("hdnPageBox").value = j;
            }
            else {
                if (i != null && i != undefined) {
                    $("#PageBox")[0].value = i;
                    document.getElementById("hdnPageBox").value = i;
                }
            }
        }
        debugger;
        //top.window.document.getElementById("btnhiddenfax").click();
        $('#btnhiddenfax').click();
        return true;
    }
    if ($("#PageBox") != undefined && $("#PageBox").length > 0) {

        if (j != null && j != undefined) {
            $("#PageBox")[0].value = j;
        }
        else {
            if (i != null && i != undefined) {
                $("#PageBox")[0].value = i;
            }
        }
    }

}
function pdfchange() {

    $("#_plcImgsThumbs").find(".thumbnailCompareactiveActual").removeClass("thumbnailCompareactiveActual").addClass("thumbnail");
    $("#_plcImgsThumbs").find("#pgact_" + document.getElementById("hdnid").value).removeClass("thumbnail").addClass("thumbnailCompareactiveActual");
    if (document.getElementById("hdidcompare").value != '') {
        $("#_plcImgsThumbsComp").find("#pgCompare_" + document.getElementById("hdidcompare").value).removeClass("thumbnailCompare").addClass("thumbnailCompareactive");

    }
    document.getElementById('txtmsghistory').value = document.getElementById('hdnnotes').value.split('<br />').join("\n");
    document.getElementById('txtmsghistorycomp').value = document.getElementById('hdnnotesCompare').value.split('<br />').join("\n");
    //  document.getElementById('hdnpgno1').value = $('#PageBoxcom').val();
    document.getElementById('PageBoxcom').value = $('#hdnpgno1').val();
    document.getElementById('PageBox').value = $('#hdnpgno').val();


}

function test() {
    var id = $('#PageBox').val();
    $('#pgact_' + id).click();
}

function test1() {
    var id = $('#PageBoxcom').val();
    $('#pgCompare_' + id).click();
}

function pdfchangecompare() {
    $("#_plcImgsThumbsComp").find(".thumbnailCompareactive").removeClass("thumbnailCompareactive").addClass("thumbnailCompare");
    $("#_plcImgsThumbsComp").find("#" + document.getElementById("hdidcompare").value).removeClass("thumbnailCompare").addClass("thumbnailCompareactive");
    document.getElementById('txtmsghistory').value = document.getElementById('hdnnotes').value.split('<br />').join("\n");
    document.getElementById('txtmsghistorycomp').value = document.getElementById('hdnnotesCompare').value.split('<br />').join("\n");
    document.getElementById('PageBox').value = $('#hdnpgno').val();

    // document.getElementById('hdnpgno1').value = $('#PageBoxcom').val();

}

function pdfchangeview() {

    $("#_plcImgsThumbs").find(".thumbnailactive").removeClass("thumbnailactive").addClass("thumbnail");
    $("#_plcImgsThumbs").find("#" + document.getElementById("hdnid").value).removeClass("thumbnail").addClass("thumbnailactive");
    // document.getElementById('txtmsghistory').value = document.getElementById('hdnnotes').value.split('<br />').join("\n");

    //  document.getElementById('hdnpgno1').value = $('#PageBoxcom').val();
    document.getElementById('PageBox').value = $('#hdnPageBox').val();
    return false;

}

function DropDownimagelist_mouse() {
    document.getElementById("hdnpdf").value = "";
    $('#DropDownimagelist').attr('title', $('#DropDownimagelist option:selected').val());
}

function droplistfile_mouse() {
    $('#droplistfile').attr('title', $('#droplistfile option:selected').val());
}
function ChangePgCompare(i, t, e, notes, id, j) {
    if (notes != undefined && notes != null && id != undefined && id != null) {
        document.getElementById('hdnnotesCompare').value = notes.replace("<br />", "\n");
        document.getElementById('hdnfileindexidCompare').value = id;
        document.getElementById('txtmsghistorycomp').value = notes.split('<br />').join("\n");

        $.ajax({
            type: "POST",
            url: "frmImageViewer.aspx/RefreshNotes",
            data: JSON.stringify({

                "FileId": document.getElementById('hdnfileindexidCompare').value

            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: function (data) {
                document.getElementById('hdnnotesCompare').value = data.d;
                document.getElementById('txtmsghistorycomp').value = data.d.split('<br />').join("\n");
                document.getElementById('txtmessagecomp').value = "";


            },
            error: function OnError(xhr) {
                StopLoadFromPatChart();
                if (xhr.status == 999)
                    window.location = xhr.statusText;
                else {
                    var log = JSON.parse(xhr.responseText);
                    console.log(log);
                    alert("USER MESSAGE:\n" + xhr.status + "-" + xhr.statusText +
                        ". \nCannot process request. Please Login again and retry. If issue persists, Please contact Support.\n\nEXCEPTION DETAILS: \nException Type" +
                        log.ExceptionType + " \nMessage: " + log.Message);
                }
            }
        });
    }


    if (t.toUpperCase().indexOf(".PDF") < 0) {
        Src = "ViewImg.aspx?View=1&FilePath=" + t + "&Pg=" + i + "&Height=" + GetBigSrcCompare("Height") + "&Width=" + GetBigSrcCompare("Width"), SrcBig = "ViewImg.aspx?View=1&FilePath=" + GetBigSrcCompare("FilePath") + "&Pg=" + i + "&Height=1000&Width=1000", SrcRevert = "ViewImg.aspx?View=1&FilePath=" + GetBigSrcCompare("FilePath") + "&Pg=" + i + "&Height=600&Width=600", SrcNavigate = "ViewImg.aspx?View=1&FilePath=" + GetBigSrcCompare("FilePath") + "&Height=600&Width=600", $("#_plcImgsThumbsComp").find(".thumbnailCompareactive").removeClass("thumbnailCompareactive").addClass("thumbnailCompare"), $("#_plcImgsThumbsComp").find("#" + e).removeClass("thumbnailCompare").addClass("thumbnailCompareactive")
        document.getElementById("_imgBigCompare").src = Src;
        $('#bigImgPDFCompare').css("display", "none")
        $('#_imgBigCompare').css("display", "block")
        document.getElementById("hdnimagesource1").value = Src;
        $('#PDFholderComp').css("display", "none")
        $('#imgholdercom').css("display", "block")
        document.getElementById("hdnpdfcompare").value = "";
        $('#divrotatecomp').css("display", "inline-block");
    }

    if (t.toUpperCase().indexOf(".PDF") >= 0 && document.getElementById("bigImgPDF") != undefined) {
        // Src = "ViewImg.aspx?View=1&FilePath=" + t + "&Pg=" + i + "&Height=" + GetBigSrcActual("Height") + "&Width=" + GetBigSrcActual("Width"), SrcBig = "ViewImg.aspx?View=1&FilePath=" + GetBigSrcActual("FilePath") + "&Pg=" + i + "&Height=1000&Width=1000", SrcRevert = "ViewImg.aspx?View=1&FilePath=" + GetBigSrcActual("FilePath") + "&Pg=" + i + "&Height=600&Width=600", SrcNavigate = "ViewImg.aspx?View=1&FilePath=" + GetBigSrcActual("FilePath") + "&Height=600&Width=600", $("#_plcImgsThumbs").find(".thumbnailCompareactiveActual").removeClass("thumbnailCompareactiveActual").addClass("thumbnail"), $("#_plcImgsThumbs").find("#" + e).removeClass("thumbnail").addClass("thumbnailCompareactiveActual");
        // document.getElementById("bigImgPDF").src = GetBigSrcActual("FilePath");

        $("#_plcImgsThumbsComp").find(".thumbnailCompareactive").removeClass("thumbnailCompareactive").addClass("thumbnailCompare");
        $("#_plcImgsThumbsComp").find("#" + e).removeClass("thumbnailCompare").addClass("thumbnailCompareactive");
        $('#bigImgPDFCompare').css("display", "block")
        $('#_imgBigCompare').css("display", "none")
        document.getElementById("hdnimagesource1").value = "";
        $('#PDFholderComp').css("display", "block")
        $('#imgholdercom').css("display", "none")
        document.getElementById("hdidcompare").value = e;
        document.getElementById("hdnpdfcompare").value = t;
        $('#divrotatecomp').css("display", "none");
        if ($("#PageBoxcom") != undefined && $("#PageBoxcom").length > 0)

            $("#PageBoxcom")[0].value = j;
        document.getElementById('hdnpgno1').value = j;
        document.getElementById("btnhiddencompare").click();
        return true;
    }




    if ($("#PageBoxcom") != undefined && $("#PageBoxcom").length > 0)
        $("#PageBoxcom")[0].value = j;

}
function btnsaveClick() {
    if (document.getElementById('txtmessage').value == "") {
        sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart();
        alert("Please Enter Message");

        return false;

    }
    else {
        { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
        saveclick();
        return false;
    }
}



function saveclick() {
    $.ajax({
        type: "POST",
        url: "frmImageViewer.aspx/SaveNotes",
        data: JSON.stringify({
            "MessageHistory": document.getElementById('txtmsghistory').value,
            "DateTime": new Date(),
            "FileId": document.getElementById('hdnfileindexid').value,
            "Notes": document.getElementById('txtmessage').value
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (data) {
            document.getElementById('hdnnotes').vaue = data.d;
            //document.getElementById('txtmsghistory').value = data.d.replace("<br />", "\n");;
            document.getElementById('txtmsghistory').value = data.d.split('<br />').join("\n");
            document.getElementById('txtmessage').value = "";
            DisplayErrorMessage('110020');
            document.getElementById('btnsave').disabled = true;
            { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
            return false;
        },
        error: function OnError(xhr) {
            StopLoadFromPatChart();
            if (xhr.status == 999)
                window.location = xhr.statusText;
            else {
                var log = JSON.parse(xhr.responseText);
                console.log(log);
                alert("USER MESSAGE:\n" + xhr.status + "-" + xhr.statusText +
                    ". \nCannot process request. Please Login again and retry. If issue persists, Please contact Support.\n\nEXCEPTION DETAILS: \nException Type" +
                    log.ExceptionType + " \nMessage: " + log.Message);
            }
        }
    });
}
function filechange() {

    if ($('#droplistfile option:selected').val().indexOf('--Select Image to Compare--') > -1) {
        alert('Please select image to compare');
        return false;
    }
    else {
        { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }

        if ($('.thumbnailCompareactiveActual')[0] != undefined && $('.thumbnailCompareactiveActual')[0].children[0] != undefined && $('.thumbnailCompareactiveActual')[0].children[0].dataset.original != undefined)
            document.getElementById('hdnimagesource').value = $('.thumbnailCompareactiveActual')[0].children[0].dataset.original.replace("=100", "=750").replace("=100", "=750");
        else
            document.getElementById('hdnimagesource').value = "";

        document.getElementById('hdnpgno').value = $('#PageBox').val();
        document.getElementById('hdnmsghst').value = $('#txtmsghistory').val();
        document.getElementById('hdnmessage').value = $('#txtmessage').val();

        if ($('.thumbnailCompareactive')[0] != undefined && $('.thumbnailCompareactive')[0].children[0] != undefined && $('.thumbnailCompareactive')[0].children[0].dataset.original != undefined)
            document.getElementById('hdnimagesource1').value = $('.thumbnailCompareactive')[0].children[0].dataset.original.replace("=100", "=750").replace("=100", "=750");
        else
            document.getElementById('hdnimagesource1').value = "";


        //$.ajax({
        //    type: "POST",
        //    url: "frmImageCompare.aspx/dropfilechange",
        //    data: JSON.stringify({
        //        "filetext": $('#droplistfile option:selected').val()

        //    }),
        //    contentType: "application/json; charset=utf-8",
        //    dataType: "json",
        //    async: true,
        //    success: function (data) {
        //        setNotesValueCompare();
        //        { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
        //        return false;
        //    },
        //    error: function OnError(xhr) {
        //        StopLoadFromPatChart();
        //        if (xhr.status == 999)
        //            window.location = xhr.statusText;
        //        else {
        //            var log = JSON.parse(xhr.responseText);
        //            console.log(log);
        //            alert("USER MESSAGE:\n" + xhr.status + "-" + xhr.statusText +
        //                ". \nCannot process request. Please Login again and retry. If issue persists, Please contact Support.\n\nEXCEPTION DETAILS: \nException Type" +
        //                log.ExceptionType + " \nMessage: " + log.Message);
        //        }
        //    }
        //});
        __doPostBack(document.getElementById('<%= droplistfile.ClientID %>'), '');
    }
}
function DropDownimagelistchange() {

    if ($('#DropDownimagelist option:selected').val().indexOf('--Select Image to Compare--') > -1) {
        alert('Please select image to compare');
        return false;
    }
    else {
        { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }

        if ($('.thumbnailCompareactive')[0] != undefined && $('.thumbnailCompareactive')[0].children[0] != undefined && $('.thumbnailCompareactive')[0].children[0].dataset.original != undefined)
            document.getElementById('hdnimagesource1').value = $('.thumbnailCompareactive')[0].children[0].dataset.original.replace("=100", "=750").replace("=100", "=750");
        else
            document.getElementById('hdnimagesource1').value = "";
        document.getElementById('hdnpgno1').value = $('#PageBoxcom').val();
        document.getElementById('hdnmsghst1').value = $('#txtmsghistorycomp').val();
        document.getElementById('hdnmessage1').value = $('#txtmessagecomp').val();


        __doPostBack(document.getElementById('<%= DropDownimagelist.ClientID %>'), '');
    }
}
function btnsaveClickCompare() {
    if (document.getElementById('txtmessage').value == "" && document.getElementById('txtmessagecomp').value == "") {
        sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart();
        alert("Please Enter Message");
        return false;

    }
    else {
        { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
        saveclickComparesave();
        return false;
    }
}

function saveclickComparesave() {
    if (document.getElementById('txtmessage').value != "") {
        $.ajax({
            type: "POST",
            url: "frmImageCompare.aspx/SaveNotes",
            data: JSON.stringify({
                "MessageHistory": document.getElementById('txtmsghistory').value,
                "DateTime": new Date(),
                "FileId": document.getElementById('hdnfileindexid').value,
                "Notes": document.getElementById('txtmessage').value
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: function (data) {
                document.getElementById('hdnnotes').vaue = data.d;
                //document.getElementById('txtmsghistory').value = data.d.replace("<br />", "\n");;
                document.getElementById('txtmsghistory').value = data.d.split('<br />').join("\n");
                document.getElementById('txtmessage').value = "";

            },
            error: function OnError(xhr) {
                StopLoadFromPatChart();
                if (xhr.status == 999)
                    window.location = xhr.statusText;
                else {
                    var log = JSON.parse(xhr.responseText);
                    console.log(log);
                    alert("USER MESSAGE:\n" + xhr.status + "-" + xhr.statusText +
                        ". \nCannot process request. Please Login again and retry. If issue persists, Please contact Support.\n\nEXCEPTION DETAILS: \nException Type" +
                        log.ExceptionType + " \nMessage: " + log.Message);
                }
            }
        });
    }
    if (document.getElementById('txtmessagecomp').value != "") {
        $.ajax({
            type: "POST",
            url: "frmImageCompare.aspx/SaveNotes",
            data: JSON.stringify({
                "MessageHistory": document.getElementById('txtmsghistorycomp').value,
                "DateTime": new Date(),
                "FileId": document.getElementById('hdnfileindexidCompare').value,
                "Notes": document.getElementById('txtmessagecomp').value
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: function (data) {
                document.getElementById('hdnnotesCompare').vaue = data.d;
                //document.getElementById('txtmsghistory').value = data.d.replace("<br />", "\n");;
                document.getElementById('txtmsghistorycomp').value = data.d.split('<br />').join("\n");
                document.getElementById('txtmessagecomp').value = "";

                return false;
            },
            error: function OnError(xhr) {
                StopLoadFromPatChart();
                if (xhr.status == 999)
                    window.location = xhr.statusText;
                else {
                    var log = JSON.parse(xhr.responseText);
                    console.log(log);
                    alert("USER MESSAGE:\n" + xhr.status + "-" + xhr.statusText +
                        ". \nCannot process request. Please Login again and retry. If issue persists, Please contact Support.\n\nEXCEPTION DETAILS: \nException Type" +
                        log.ExceptionType + " \nMessage: " + log.Message);
                }
            }
        });
    }
    document.getElementById('btnsave').disabled = true;
    DisplayErrorMessage('110020');
    { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
    return false;
}
//function print() {
//    var i = document.getElementById("_imgBig"),
//        t = document.createElement("iframe");
//    t.style.display = "none", t.src = i.src, t.id = "PrintNow", document.body.appendChild(t), document.getElementById("PrintNow").contentWindow.print()
//}

//function print() {
//    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
//    var i = document.getElementById("_imgBig");
//    var imgsrc = $("#_plcImgsThumbs").find("img");
//    var Imglink = i.src;

//    var idiv = document.createElement("div");
//    idiv.id = "PrintAll";

//    var iCount = 1, totCount = 0;
//    var imgsource = [];
//    var icnt = 0;
//    if (imgsrc[0].src.indexOf("EXAM") > -1) {
//        var lm = imgsrc[0].src.split("EXAM")[1].split("&")[0].split("_")[3].split('.')[0];

//        for (var k = 0; k < imgsrc.length; k++) {
//            if (k > 0)
//                var imgsrce = imgsrc[0].src.split("EXAM")[1].split("&")[0].replace(imgsrc[0].src.split("EXAM")[1].split("&")[0].split("_")[3], ((lm) < 10 ? '0' + lm : lm) + '.' + imgsource[0].split('.')[1]);
//            else
//                var imgsrce = imgsrc[0].src.split("EXAM")[1].split("&")[0];
//            lm = ++lm;
//            imgsource.push(imgsrce);
//        }
//        var ExamimgSrc = document.getElementById("_imgBig").src.split("EXAM")[1].split("&")[0];
//    }


//    for (i = 1; i <= imgsrc.length; i++) {
//        var sepdiv = document.createElement("div");
//        var divimg = document.createElement("img");
//        divimg.id = "divimg" + i;
//        if (Imglink.indexOf("EXAM") > -1) {
//            var source = Imglink.replace(ExamimgSrc, imgsource[i - 1]);
//        }
//        else {
//            var source = Imglink + "&All=" + i;
//        }
//        $(divimg).attr("src", source).on("load", function (e) {
//            iCount++;
//            if (iCount == imgsrc.length + 1) {
//                window.setTimeout(function () {
//                    document.getElementById("PrintNow").contentWindow.print()
//                    totCount++;
//                    if (totCount == 1) {
//                        { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
//                    }
//                }, 9000);//BugID:41410
//            }

//        });
//        sepdiv.innerHTML = divimg.outerHTML;
//        idiv.innerHTML = idiv.innerHTML + sepdiv.outerHTML;
//    }
//    var t = document.createElement("iframe");
//    t.id = "PrintNow";
//    t.style.display = "none";
//    document.body.appendChild(t);
//    t = document.getElementById("PrintNow");
//    var tdoc = t.contentDocument || t.contentWindow.document;
//    tdoc.body.innerHTML = idiv.outerHTML;
//}
function print() {
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
    var i = document.getElementById("_imgBig");
    var imgsrc = $("#_plcImgsThumbs").find("img");
    var Imglink = i.src;

    var idiv = document.createElement("div");
    idiv.id = "PrintAll";

    var iCount = 1, totCount = 0;
    var imgsource = [];
    var icnt = 0;
    if (imgsrc[0].src.indexOf("EXAM") > -1) {
        var lm = imgsrc[0].src.split("EXAM")[1].split("&")[0].split("_")[3].split('.')[0];

        if (imgsrc[0].src.split("EXAM")[1].split("&")[0].split("_")[3].split('.')[0].indexOf('0') == 0)
            var appendZero = true;
        else
            appendZero = false;

        for (var k = 0; k < imgsrc.length; k++) {
            if (k > 0)
                if (appendZero)
                    var imgsrce = imgsrc[0].src.split("EXAM")[1].split("&")[0].replace(imgsrc[0].src.split("EXAM")[1].split("&")[0].split("_")[3], ((lm) < 10 ? '0' + lm : lm) + '.' + imgsource[0].split('.')[1]);
                else
                    var imgsrce = imgsrc[0].src.split("EXAM")[1].split("&")[0].replace(imgsrc[0].src.split("EXAM")[1].split("&")[0].split("_")[3], lm + '.' + imgsource[0].split('.')[1]);
            else
                var imgsrce = imgsrc[0].src.split("EXAM")[1].split("&")[0];
            lm = ++lm;
            imgsource.push(imgsrce);
        }
        var ExamimgSrc = document.getElementById("_imgBig").src.split("EXAM")[1].split("&")[0];
    }


    for (i = 1; i <= imgsrc.length; i++) {
        var sepdiv = document.createElement("div");
        var divimg = document.createElement("img");
        divimg.id = "divimg" + i;
        if (Imglink.indexOf("EXAM") > -1) {
            var source = Imglink.replace(ExamimgSrc, imgsource[i - 1]);
        }
        else {
            var source = Imglink + "&All=" + i;
        }
        $(divimg).attr("src", source).on("load", function (e) {
            iCount++;
            if (iCount == imgsrc.length + 1) {
                window.setTimeout(function () {
                    document.getElementById("PrintNow").contentWindow.print()
                    totCount++;
                    if (totCount == 1) {
                        { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
                    }
                }, 9000);//BugID:41410
            }

        });
        sepdiv.innerHTML = divimg.outerHTML;
        idiv.innerHTML = idiv.innerHTML + sepdiv.outerHTML;
    }

    var t = document.createElement("iframe");
    t.id = "PrintNow";
    t.style.display = "block";//BugID:53003
    t.style.width = "0px";
    t.style.height = "0px";
    t.style.border = "none";
    document.body.appendChild(t);
    t = document.getElementById("PrintNow");
    var tdoc = t.contentDocument || t.contentWindow.document;
    tdoc.body.innerHTML = idiv.outerHTML;
}

function printActual() {
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
    var i = document.getElementById("_imgBigActual");
    var imgsrc = $("#_plcImgsThumbs").find("img");
    var Imglink = i.src;

    var idiv = document.createElement("div");
    idiv.id = "PrintAll";

    var iCount = 1, totCount = 0;
    var imgsource = [];
    var icnt = 0;
    if (imgsrc[0].src.indexOf("EXAM") > -1) {
        var lm = imgsrc[0].src.split("EXAM")[1].split("&")[0].split("_")[3].split('.')[0];

        if (imgsrc[0].src.split("EXAM")[1].split("&")[0].split("_")[3].split('.')[0].indexOf('0') == 0)
            var appendZero = true;
        else
            appendZero = false;

        for (var k = 0; k < imgsrc.length; k++) {
            if (k > 0)
                if (appendZero)
                    var imgsrce = imgsrc[0].src.split("EXAM")[1].split("&")[0].replace(imgsrc[0].src.split("EXAM")[1].split("&")[0].split("_")[3], ((lm) < 10 ? '0' + lm : lm) + '.' + imgsource[0].split('.')[1]);
                else
                    var imgsrce = imgsrc[0].src.split("EXAM")[1].split("&")[0].replace(imgsrc[0].src.split("EXAM")[1].split("&")[0].split("_")[3], lm + '.' + imgsource[0].split('.')[1]);
            else
                var imgsrce = imgsrc[0].src.split("EXAM")[1].split("&")[0];
            lm = ++lm;
            imgsource.push(imgsrce);
        }
        var ExamimgSrc = document.getElementById("_imgBigActual").src.split("EXAM")[1].split("&")[0];
    }


    for (i = 1; i <= imgsrc.length; i++) {
        var sepdiv = document.createElement("div");
        var divimg = document.createElement("img");
        divimg.id = "divimg" + i;
        if (Imglink.indexOf("EXAM") > -1) {
            var source = Imglink.replace(ExamimgSrc, imgsource[i - 1]);
        }
        else {
            var source = Imglink + "&All=" + i;
        }
        $(divimg).attr("src", source).on("load", function (e) {
            iCount++;
            if (iCount == imgsrc.length + 1) {
                window.setTimeout(function () {
                    document.getElementById("PrintNow").contentWindow.print()
                    totCount++;
                    if (totCount == 1) {
                        { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
                    }
                }, 9000);//BugID:41410
            }

        });
        sepdiv.innerHTML = divimg.outerHTML;
        idiv.innerHTML = idiv.innerHTML + sepdiv.outerHTML;
    }

    var t = document.createElement("iframe");
    t.id = "PrintNow";
    t.style.display = "block";//BugID:53003
    t.style.width = "0px";
    t.style.height = "0px";
    t.style.border = "none";
    document.body.appendChild(t);
    t = document.getElementById("PrintNow");
    var tdoc = t.contentDocument || t.contentWindow.document;
    tdoc.body.innerHTML = idiv.outerHTML;
}

function printCompare() {
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
    var i = document.getElementById("_imgBigCompare");
    var imgsrc = $("#_plcImgsThumbsComp").find("img");
    var Imglink = i.src;

    var idiv = document.createElement("div");
    idiv.id = "PrintAll";

    var iCount = 1, totCount = 0;
    var imgsource = [];
    var icnt = 0;
    if (imgsrc[0].src.indexOf("EXAM") > -1) {
        var lm = imgsrc[0].src.split("EXAM")[1].split("&")[0].split("_")[3].split('.')[0];

        if (imgsrc[0].src.split("EXAM")[1].split("&")[0].split("_")[3].split('.')[0].indexOf('0') == 0)
            var appendZero = true;
        else
            appendZero = false;

        for (var k = 0; k < imgsrc.length; k++) {
            if (k > 0)
                if (appendZero)
                    var imgsrce = imgsrc[0].src.split("EXAM")[1].split("&")[0].replace(imgsrc[0].src.split("EXAM")[1].split("&")[0].split("_")[3], ((lm) < 10 ? '0' + lm : lm) + '.' + imgsource[0].split('.')[1]);
                else
                    var imgsrce = imgsrc[0].src.split("EXAM")[1].split("&")[0].replace(imgsrc[0].src.split("EXAM")[1].split("&")[0].split("_")[3], lm + '.' + imgsource[0].split('.')[1]);
            else
                var imgsrce = imgsrc[0].src.split("EXAM")[1].split("&")[0];
            lm = ++lm;
            imgsource.push(imgsrce);
        }
        var ExamimgSrc = document.getElementById("_imgBigCompare").src.split("EXAM")[1].split("&")[0];
    }


    for (i = 1; i <= imgsrc.length; i++) {
        var sepdiv = document.createElement("div");
        var divimg = document.createElement("img");
        divimg.id = "divimg" + i;
        if (Imglink.indexOf("EXAM") > -1) {
            var source = Imglink.replace(ExamimgSrc, imgsource[i - 1]);
        }
        else {
            var source = Imglink + "&All=" + i;
        }
        $(divimg).attr("src", source).on("load", function (e) {
            iCount++;
            if (iCount == imgsrc.length + 1) {
                window.setTimeout(function () {
                    document.getElementById("PrintNow").contentWindow.print()
                    totCount++;
                    if (totCount == 1) {
                        { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
                    }
                }, 9000);//BugID:41410
            }

        });
        sepdiv.innerHTML = divimg.outerHTML;
        idiv.innerHTML = idiv.innerHTML + sepdiv.outerHTML;
    }

    var t = document.createElement("iframe");
    t.id = "PrintNow";
    t.style.display = "block";//BugID:53003
    t.style.width = "0px";
    t.style.height = "0px";
    t.style.border = "none";
    document.body.appendChild(t);
    t = document.getElementById("PrintNow");
    var tdoc = t.contentDocument || t.contentWindow.document;
    tdoc.body.innerHTML = idiv.outerHTML;
}
function GetBigSrc(t) {
    var e = document.getElementById("_imgBig").src;
    if (e != "") {
        for (gy = e.split("&"), i = 0; i < gy.length; i++)
            if (ft = gy[i].split("="), ft[0] == t) return ft[1]
    }
    else
        return "750";
}

function GetBigSrcActual(t) {

    var e = document.getElementById("_imgBigActual").src;
    if (e != "") {
        for (gy = e.split("&"), i = 0; i < gy.length; i++)
            if (ft = gy[i].split("="), ft[0] == t) return ft[1]
    }
    else
        return "750"
}


function GetBigSrcCompare(t) {
    var e = document.getElementById("_imgBigCompare").src;
    if (e != "") {
        for (gy = e.split("&"), i = 0; i < gy.length; i++)
            if (ft = gy[i].split("="), ft[0] == t) return ft[1]
    }
    else
        return "750"
}
document.oncontextmenu = function () {
    return !1
}, document.onmousedown = mouseDown, $(document).ready(function () {


    $(function () {
        $("img.lazy").lazyload({
            effect: "fadeIn",
            container: $("#_plcImgsThumbs")
        }), $("#_imgBig").css("opacity", "1")
    });
    var i = 0;
    var r = 0;
    jQuery.fn.rotate = function (i) {
        $("#_imgBig").css({
            "-webkit-transform": "rotate(" + i + "deg)"
        })
    },
  
     $("#leftrotate").click(function () {
         i -= 90, $("#leftrotate").rotate(i)
     }), $("#zoomin").click(function () {
         var i = 10,
             t = parseInt($("#_imgBig").width());
         $("#_imgBig").width(t + i + "px");
         var e = parseInt($("#_imgBig").height());
         $("#_imgBig").height(e + i + "px")
     }), $("#zoomout").click(function () {
         var i = 10,
             t = parseInt($("#_imgBig").width());
         $("#_imgBig").width(t - i + "px");
         var e = parseInt($("#_imgBig").height());
         $("#_imgBig").height(e - i + "px")
     }), $("#revert").click(function () {
         $("#_imgBig").css("width", ""), $("#_imgBig").css("height", "");
         $("#_imgBig").css('transform', 'rotate(' + (r += 360) + 'deg)');
     }), $("#rotateright").click(function () {
         i += 90, $("#rotateright").rotate(i)
     }), $("#prev").click(function () {
         var i = $("#PageBox")[0].value;
         i--, i > 0 && ($("#pg_" + i)[0].firstChild.click(), $("#PageBox")[0].value = i)
     }), $("#next").click(function () {
         var i = $("#PageLabel")[0].value,
             t = $("#PageBox")[0].value;
         t++, t <= i.replace("/ ", "") && ($("#pg_" + t)[0].firstChild.click(), $("#PageBox")[0].value = t)
     }),



     jQuery.fn.rotateActual = function (i) {
         $("#_imgBigActual").css({
             "-webkit-transform": "rotate(" + i + "deg)"
         })
     },
     $("#leftrotateActual").click(function () {
         i -= 90, $("#leftrotate").rotateActual(i)
     }), $("#zoominActual").click(function () {
         var i = 10,
             t = parseInt($("#_imgBigActual").width());
         $("#_imgBigActual").width(t + i + "px");
         var e = parseInt($("#_imgBigActual").height());
         $("#_imgBigActual").height(e + i + "px")
     }), $("#zoomoutActual").click(function () {
         var i = 10,
             t = parseInt($("#_imgBigActual").width());
         $("#_imgBigActual").width(t - i + "px");
         var e = parseInt($("#_imgBigActual").height());
         $("#_imgBigActual").height(e - i + "px")
     }), $("#revertActual").click(function () {
         $("#_imgBigActual").css("width", ""), $("#_imgBigActual").css("height", "")
     }), $("#rotaterightActual").click(function () {
         i += 90, $("#rotaterightActual").rotateActual(i)
     }), $("#prevActual").click(function () {
         var i = $("#PageBox")[0].value;
         i--, i > 0 && ($("#pgact_" + i)[0].firstChild.click(), $("#PageBox")[0].value = i)
     }), $("#nextActual").click(function () {
         var i = $("#PageLabel")[0].value,
             t = $("#PageBox")[0].value;
         t++, t <= i.replace("/ ", "") && ($("#pgact_" + t)[0].firstChild.click(), $("#PageBox")[0].value = t)
     }),



     jQuery.fn.rotateCompare = function (i) {
         $("#_imgBigCompare").css({
             "-webkit-transform": "rotate(" + i + "deg)"
         })
     },
    $("#leftrotatecom").click(function () {
        i -= 90, $("#leftrotatecom").rotateCompare(i)
    }), $("#zoomincom").click(function () {
        var i = 10,
            t = parseInt($("#_imgBigCompare").width());
        $("#_imgBigCompare").width(t + i + "px");
        var e = parseInt($("#_imgBigCompare").height());
        $("#_imgBigCompare").height(e + i + "px")
    }), $("#zoomoutcom").click(function () {
        var i = 10,
            t = parseInt($("#_imgBigCompare").width());
        $("#_imgBigCompare").width(t - i + "px");
        var e = parseInt($("#_imgBigCompare").height());
        $("#_imgBigCompare").height(e - i + "px")
    }), $("#revertcom").click(function () {
        $("#_imgBigCompare").css("width", ""), $("#_imgBigCompare").css("height", "")
    }), $("#rotaterightcom").click(function () {
        i += 90, $("#rotaterightcom").rotateCompare(i)
    }), $("#prevcom").click(function () {
        var i = $("#PageBoxcom")[0].value;
        i--, i > 0 && ($("#pgCompare_" + i)[0].firstChild.click(), $("#PageBoxcom")[0].value = i)
    }), $("#nextcom").click(function () {
        var i = $("#PageLabelcom")[0].value,
            t = $("#PageBoxcom")[0].value;
        t++, t <= i.replace("/ ", "") && ($("#pgCompare_" + t)[0].firstChild.click(), $("#PageBoxcom")[0].value = t)
    });
    if ($('#PageBox').val() == '1') {
        $("#_imgBig").css("opacity", "1"), $("#_plcImgsThumbs").find("[id^=pg_]").first().removeClass("thumbnail")
           .addClass("thumbnailactive");
    }

    if ($('#PageBox').val() == '1')
        $("#_imgBigActual").css("opacity", "1"), $("#_plcImgsThumbs").find("[id^=pgact_]").first().removeClass("thumbnail")
           .addClass("thumbnailCompareactiveActual");

    if ($('#PageBoxcom').val() == '1')
        $("#_imgBigCompare").css("opacity", "1"), $("#_plcImgsThumbsComp").find("[id^=pgCompare_]").first().removeClass("thumbnailCompare").addClass("thumbnailCompareactive")
});

function ViewPDF() {
    document.getElementById('PDFholder').style.display = "block";
    document.getElementById('imgControls').style.display = "none";
    document.getElementById('imgholder').style.display = "none";
    document.getElementById('_plcImgsThumbs').style.display = "none";
}
function loadhumandetails() {
    document.getElementById('Lblpatient').innerText = $(window.top.document).find('#ctl00_C5POBody_lblPatientStrip').text();
}

$(document).ready(function () {
    localStorage["Result"] = "";
    if (window.location.href.split('FilePath=')[1] != undefined && window.location.href.split('FilePath=')[1] != "")
        localStorage["Result"] = window.location.href.split('FilePath=')[1];
})

