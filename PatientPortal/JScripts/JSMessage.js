  function closeWindow()
     {
     if(document.getElementById("IsLoginOpen").value!="YES")
     {
	self.close();
	}
     }
     function SetIntervalTime(time)
     {
      self.setInterval(function(){closeWindow()},time);
     }
    function GetRadWindow() 
    {
        var oWindow = null;
        if (window.radWindow) oWindow = window.radWindow;
        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
        return oWindow;
    }
  
 function GetUTCTime()
    {
      var now=new Date();
    var utc=(now.getUTCDate()+'/'+ now.getUTCMonth()+1)+'/'+now.getUTCFullYear();utc+=' '+now.getUTCHours()+':'+now.getUTCMinutes()+':'+now.getUTCSeconds();
    document.getElementById("hdnLocalTime").value=utc;
    }
 function RadWindowClosepopup()
 {
     self.close();
 }
function RadWindowClose()
{
    var oWindow = null;
          if (window.radWindow)
               oWindow = window.radWindow;
          else if (window.frameElement.radWindow)
               oWindow = window.frameElement.radWindow;
          if(oWindow!=null)
           oWindow.close();
           return false;
}
//BugID:54514
function loadRcopiaRxCount() {

    $.ajax({
        type: "POST",
        url: "frmRCopiaToolbar.aspx/LoadRCopiaNotification",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessRCopia,
        error: function OnError(xhr) {
            if (xhr.status == 999)
                window.location = "/frmSessionExpired.aspx";
            else {
                var log = JSON.parse(xhr.responseText);
                console.log(log);
                alert("USER MESSAGE:\n" + xhr.status + "-" + xhr.statusText +
                    ". \nCannot process request. Please Login again and retry. If issue persists, Please contact Support.\n\nEXCEPTION DETAILS: \nException Type" +
                    log.ExceptionType + " \nMessage: " + log.Message);
            }
            { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
        }
    });
}
function OnSuccessRCopia(response) {
    var responseValues = response.d.split('#$%');
    var rxValues = "";
    if (responseValues == "") {
        document.getElementById("tsRefill").style.display = "none";
        document.getElementById("tsRx_Pending").style.display = "none";
        document.getElementById("tsRx_Need_Signing").style.display = "none";
    }
    if (responseValues != null) {
        document.getElementById("tsRefill").innerText = responseValues[0];
        document.getElementById("tsRx_Pending").innerText = responseValues[1];
        document.getElementById("tsRx_Need_Signing").innerText = responseValues[2];
        rxValues = document.getElementById("tsRefill").innerText + "$:$" + document.getElementById("tsRx_Pending").innerText + "$:$" + document.getElementById("tsRx_Need_Signing").innerText;
    }
    else {

        document.getElementById("tsRefill").innerText = "Refill : 0";
        document.getElementById("tsRx_Pending").innerText = "Rx_Pending : 0";
        document.getElementById("tsRx_Need_Signing").innerText = "Rx_Need_Signing : 0";
        rxValues = document.getElementById("tsRefill").innerText + "$:$" + document.getElementById("tsRx_Pending").innerText + "$:$" + document.getElementById("tsRx_Need_Signing").innerText;
    }
    sessionStorage.setItem("RxCount", rxValues);
}