function pageLoad() {
    $("#dtpFromDate").datetimepicker({ closeOnDateSelect: true, format: 'd-M-Y h:i A' });
    $("#dtpToDate").datetimepicker({ closeOnDateSelect: true, format: 'd-M-Y' });
}
$(function () {
    $("#dtpFromDate").datepicker();
    $("#dtpToDate").datepicker();
});

function CheckedChange() {
    var Chk = document.getElementById("chkDateRange");
    if (Chk.checked == true) {

        var FromDate = document.getElementById('dtpFromDate');
        var ToDate = document.getElementById('dtpToDate');
        var Currentdate = new Date();
        var sval = Currentdate.dateFormat("d-M-y");
        document.getElementById('dtpFromDate').disabled = false;
        document.getElementById('dtpToDate').disabled = false;

        var month_names = ["Jan", "Feb", "Mar",
                  "Apr", "May", "Jun",
                  "Jul", "Aug", "Sep",
                  "Oct", "Nov", "Dec"];
        var todaydate = new Date();
        var day = todaydate.getDate();
        var month = todaydate.getMonth();
        var year = todaydate.getFullYear();
        if (day.toString().length == 1)
            day = "0" + day;
        var datestring = day + "-" + month_names[month] + "-" + year;

        document.getElementById("dtpFromDate").value = datestring;
        document.getElementById("dtpToDate").value = datestring;
    }
    else {

        var FromDate = document.getElementById('dtpFromDate').value;
        var ToDate = document.getElementById('dtpToDate').value;
        document.getElementById('dtpFromDate').value = "";
        document.getElementById('dtpToDate').value = "";
        document.getElementById('dtpFromDate').disabled = true;
        document.getElementById('dtpToDate').disabled = true;
    }
}



function ValidationGenerate(sender,args)
{
       var ProviderName= document.getElementById("cboProviderName").value;
       if(ProviderName=='')
       {
            DisplayErrorMessage('103002');
            sender.set_autoPostBack(false);
            
       }
        var Chk=document.getElementById("chkDateRange");
        if(Chk.checked==true)
        {
             var  Currentdate =new Date();
             var sval= Currentdate.format("dd-MMM-yyyy");
             var FromDate= $find("dtpFromDate");
             var ToDate=$find("dtpToDate");
             var dtFrom = FromDate.get_dateInput().get_selectedDate().format("dd-MMM-yyyy");
             var dtTo = ToDate.get_dateInput().get_selectedDate().format("dd-MMM-yyyy");
             
             if(dtFrom=="01-jan-0001")
             {
               DisplayErrorMessage('103003')
               sender.set_autoPostBack(false);
               return;
               
             }
             if(dtTo=="01-jan-0001")
             {
               DisplayErrorMessage('103004')
               sender.set_autoPostBack(false);
               return;
             }
              if(dtFrom=="01-jan-0001" && dtTo!="01-jan-0001")
             {
               DisplayErrorMessage('103003')
               sender.set_autoPostBack(false);
               return;
             }
             if(dtTo=="01-jan-0001" && dtFrom!="01-jan-0001")
             {
               DisplayErrorMessage('103004')
               sender.set_autoPostBack(false);
              return;
             }
             if(dtTo<dtFrom)
             {
                DisplayErrorMessage('103005')
                sender.set_autoPostBack(false);
               return;
             }
             if(dtFrom>sval)
             {
                DisplayErrorMessage('103008')
                sender.set_autoPostBack(false);
                return;
             }
             if(dtTo>sval)
             {
                DisplayErrorMessage('103009')
                sender.set_autoPostBack(false);
                return;
             }
             FromDate.set_enabled(true);
             ToDate.set_enabled(true);
            sender.set_autoPostBack(true); 
            
        }
        else
        {
             var FromDate= $find("dtpFromDate");
             var ToDate=$find("dtpToDate");
             FromDate.set_enabled(false);
             ToDate.set_enabled(false);
            sender.set_autoPostBack(true);
        }
        
      
}
function Clear(sender,args)
{
     { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
    var IsClearAll=DisplayErrorMessage('200005');
	if(IsClearAll!=true)
	{
	    StopLoadFromPatChart()
        sender.set_autoPostBack(false);
        return;
    }
    else
	{	    
	    var FromDate = document.getElementById('dtpFromDate').value;
	    var ToDate = document.getElementById('dtpToDate').value;
	    document.getElementById('dtpFromDate').value = "";
	    document.getElementById('dtpToDate').value = "";

    }
}
function Load(sender,args)
 {
 GetUTCTime();
 { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
 }

  function GetUTCTime()
    {
      var now=new Date();
       var utc=(now.getUTCMonth()+1)+'/'+ now.getUTCDate()+'/'+now.getUTCFullYear();utc+=' '+now.getUTCHours()+':'+now.getUTCMinutes()+':'+now.getUTCSeconds();
    document.getElementById("hdnLocalTime").value=utc;
 
    }

function dateInput_OnKeyDown(sender,e)
{
e=e||window.event;
if(e.keyCode==8||e.keyCode==46)
e.preventDefault();
}

function DashBoardLoad()
{
    { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }

    $("span[mand=Yes]").addClass('MandLabelstyle');
    $("span[mand=Yes]").each(function () {
        $(this).html($(this).html().replace("*", "<span class='manredforstar'>*</span>"));
    });
    $("[id*=pbDropdown]").addClass('pbDropdownBackground');
}
function chkShowActiveloading() {
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
}


function getMonth(Month) {
    var month = new Array();
    switch (Month) {
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
        case Month:
            x = 55;
            break;
    }
    return x;
}

function formatDate() {
    var d = new Date(),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;

    return [year, month, day].join('');
}

function format(inputDate) {
    var date = new Date(inputDate);
    if (!isNaN(date.getTime())) {
        return date.getMonth() + 1 + '/' + date.getDate() + '/' + date.getFullYear();
    }
}

function DateFormat(dtDate) {
    var date = dtDate.split("-");
    var months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
    for (var j = 0; j < months.length; j++) {
        if (date[1] == months[j]) {
            date[1] = months.indexOf(months[j]) + 1;
        }
    }
    if (date[1] < 10) {
        date[1] = '0' + date[1];
    }
    var formattedDate = date[2] + date[1] + date[0];
    return formattedDate;
}

function startTime() {
    var today = new Date();
    var h = today.getHours();
    if (h < 10)
        h = h + 10;

    var m = today.getMinutes();
    if (m < 10)
        m = m + 10;

    var s = today.getSeconds();
    if (s < 10)
        s = s + 10;
    return h.toString() + m.toString() + s.toString();
}

$(document).ready(function () {
    $("#dtpFromDate").datetimepicker({ timepicker: false, format: 'd-M-Y' });
    $("#dtpToDate").datetimepicker({ timepicker: false, format: 'd-M-Y' });
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
})