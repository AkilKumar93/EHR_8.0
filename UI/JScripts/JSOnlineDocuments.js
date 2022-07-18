function mouseDown(e) {
    try {
        if (2 == event.button || 3 == event.button) return !1
    } catch (e) {
        if (3 == e.which) return !1
    }
}

function enableDates() {
    $("#dtpScannedDate").datetimepicker({
        closeOnDateSelect: !0,
        timepicker: !1,
        format: "d-M-Y",
        onShow: function (e) {
            this.setOptions({
                minDate: "2000/01/01",
                maxDate: 0

            })
        }
    });
    
}

function restrictkeypress() {
    e.preventDefault()
}

function GetRadWindow() {
    var e = null;
    return window.radWindow ? e = window.radWindow : window.frameElement.radWindow && (e = window.frameElement.radWindow), e
}

function choosefiles(e, t, n) {
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
    $('#bigImagePDF').hide();
    $('#imgholder').show();
    document.getElementById('zoomin').style.display = "block";
    document.getElementById('zoomout').style.display = "block";
    document.getElementById('prev').style.display = "block";
    if (document.getElementById('PageBox') != null)
        document.getElementById('PageBox').style.display = "block";
    if (document.getElementById('PageLabel') != null)
        document.getElementById('PageLabel').style.display = "block";
    document.getElementById('next').style.display = "block";
    document.getElementById('leftrotate').style.display = "block";
    document.getElementById('rightrotate').style.display = "block";
    $("#_imgBig").load(function () {
        sessionStorage.setItem('StartLoading', 'false');
        StopLoadFromPatChart();
    });
    var i = $("#totalPages"),
        o = $("#currentPage");
    o.val("1"), i.val(n), $("#fileThumbs").find("*").css({
        "background-color": "#ffffff"
    }), $("#fileThumbs").find("#" + e).css({
        "background-color": "#bfdbff"
    }), $("#hdnFiles").val(t);
    var a = t.replace("\\", "sin");
    $("#_imgBig").attr("src", "ViewImg.aspx?FilePath=" + a + "&View=1&&Pg=1&Height=650&Width=550&IsEnc=Y"), $("#prev").unbind("click"), $("#prev").click(function () {
        var e = o.val();
        e--, e > 0 && ($("#_imgBig").attr("src", "ViewImg.aspx?FilePath=" + a + "&View=1&&Pg=" + e + "&Height=650&Width=550&IsEnc=Y"), o.val(e))
    }), $("#next").unbind("click"), $("#next").click(function () {
        var e = o.val();
        return e++, e <= i.val() ? ($("#_imgBig").attr("src", "ViewImg.aspx?FilePath=" + a + "&View=1&&Pg=" + e + "&Height=650&Width=550&IsEnc=Y"), o.val(e), !1) : void 0
    });
}

function choosePDFfiles(e, t, n, f) {
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
    $('#imgholder').hide();
    $('#bigImagePDF').show();
    $("#bigImagePDF").load(function () {
        sessionStorage.setItem('StartLoading', 'false');
        StopLoadFromPatChart();
    });
    var i = $("#totalPages"),
        o = $("#currentPage");
    o.val("1"), i.val(n), $("#fileThumbs").find("*").css({
        "background-color": "#ffffff"
    }), $("#fileThumbs").find("#" + e).css({
        "background-color": "#bfdbff"
    }), $("#hdnFiles").val(f);
    var a = t.replace("\\", "sin");
    document.getElementById('bigImagePDF').src = t;
    document.getElementById('zoomin').style.display = "none";
    document.getElementById('zoomout').style.display = "none";
    document.getElementById('prev').style.display = "none";
    if (document.getElementById('PageBox') != null)
        document.getElementById('PageBox').style.display = "none";
    if (document.getElementById('PageLabel') != null)
        document.getElementById('PageLabel').style.display = "none";
    document.getElementById('next').style.display = "none";
    document.getElementById('leftrotate').style.display = "none";
    document.getElementById('rightrotate').style.display = "none";
}

function clickUpload() {
    $("#btnUpload").click();
}



function ShowLoading() {
    document.getElementById("divLoading").style.display = "block"
}

function findDocuments() {
    ShowLoading()
}

function getLocalTime() {
    var e = new Date,
        t = new Array("Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"),
        n = e.getDate(),
        i = t[e.getMonth()],
        o = e.getFullYear(),
        e = n + "-" + i.toString() + "-" + o;
    return e
}

function redirectbySeparateWindow() {
    StartLoadOnUploadFile();
    var e = $("#hdnFiles").val(),
            t = $("#dtpScannedDate").val(),
            n = getCookie("Tz"),
            i = "frmIndexing.aspx?FileName=" + e + "&Date=" + t + "&CurrentZone=" + n + "&HumanId=";
    setTimeout(function () {
        var e = GetRadWindow(),
            t = e.BrowserWindow.radopen(i, "ctl00_RadWindow1");
        SetRadWindowProperties(t, 720, 1235), t.add_close(function (e, t) {
            e.setUrl("about:blank"), $("#btnFindDocuments").click()
        })
    }, 0)
}

function SetRadWindowProperties(e, t, n) {
    e.SetModal(!0), e.set_visibleStatusbar(!1), e.setSize(n, t), e.set_keepInScreenBounds(!0), e.set_centerIfModal(!0), e.center(), e.set_behaviors(4), e.set_iconUrl("Resources/16_16.ico")
}

function getCookie(e) {
    for (var t = e + "=", n = document.cookie.split(";"), i = 0; i < n.length; i++) {
        for (var o = n[i];
            " " == o.charAt(0) ;) o = o.substring(1);
        if (0 == o.indexOf(t)) return o.substring(t.length, o.length)
    }
    return ""
}
document.oncontextmenu = function () {
    return !1
}, document.onmousedown = mouseDown, $(document).ready(function () {
    enableDates(), "" == $("#dtpScannedDate").val() && $("#dtpScannedDate").datetimepicker({
        value: getLocalTime()
    });
    var e = 0;
    jQuery.fn.rotate = function (e) {
        $("#_imgBig").css({
            "-webkit-transform": "rotate(" + e + "deg)"
        })
    }, $("#leftrotate").click(function () {
        e -= 90, $("#leftrotate").rotate(e)
    }), $("#rightrotate").click(function () {
        e += 90, $("#rightrotate").rotate(e)
    }), $("#zoomin").click(function () {
        var e = 10,
            t = parseInt($("#_imgBig").width());
        $("#_imgBig").width(t + e + "px");
        var n = parseInt($("#_imgBig").height());
        $("#_imgBig").height(n + e + "px")
    }), $("#zoomout").click(function () {
        var e = 10,
            t = parseInt($("#_imgBig").width());
        $("#_imgBig").width(t - e + "px");
        var n = parseInt($("#_imgBig").height());
        $("#_imgBig").height(n - e + "px")
    })
});


function ResetScanDate() {
    $("#dtpScannedDate").datetimepicker({
        value: getLocalTime()
    });

    document.getElementById("totalPages").value = "";
    document.getElementById("currentPage").value = "";
}

function StopLoadOnUploadFile() {
    sessionStorage.setItem('StartLoading', 'false');
    StopLoadFromPatChart();
}
function StartLoadOnUploadFile() {
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }

}

function changeDocumentsType() {   //bug id:62088
   ShowLoading(),document.getElementById("btnSaveOnline").disabled = !1
}

function clickClearAll() {
    $("#btnClearAll").click();
}


function btnsaveclientclick() {
    var path = document.getElementById('hdnfilepath').value;
    var n = $("#cboDocumentSubType :selected").text();
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
    var t = $("#cboDocumentType :selected").text();
    if ("" == t) { { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); } alert("Please select Document Type"); return false; }
    else if ("" == n) { { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); } alert("Please select Sub Document Type"); return false; }
    else if (path.trim() == "") {
        { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
        alert("Please Select Files to upload");
        return false;

    }
    if (($("#cboDocumentType :selected").text().toUpperCase() == "LEGAL DOCUMENTS") && ($("#cboDocumentSubType option:selected").text().toUpperCase() == "ADVANCE DIRECTIVE" || $("#cboDocumentSubType option:selected").text().toUpperCase() == "BIRTH PLAN")) {

        if (path.toUpperCase().indexOf("PDF") > -1) {
            var obj = new Array();
            var screen = "PatientPortalOnlineDoumnets";
            obj.push("Path=" + path);
            obj.push("Document=" + t);
            obj.push("DocumentSubType=" + n);
            obj.push("DocumentDate=" +  $("#dtpScannedDate").val());
            var dateonclient = new Date;
            var Tz = (dateonclient.getTimezoneOffset());
            document.cookie = "Tz=" + Tz;
            var result = openModal("frmGenerateLink.aspx", 200, 500, obj, "ctl00_ModalWindow");
            { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }

            return false;
        }

        else {
            alert("Selected Subdocument type allows only PDF files.");
            { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
            return false;
        }
    }

    else {
        return true;
    }


}