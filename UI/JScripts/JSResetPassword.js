function Ok_ClientClick(sender, args)
{
    GetUTCTime();
    var cboUserNameValue = document.getElementById("cboUserName");
    if (cboUserNameValue.value == '') {
            DisplayErrorMessage('40002');
            sender.set_autoPostBack(false);
            return false;
    }
    sender.set_autoPostBack(true);
}

function Close_ClientClick()
{
    self.close();
}
function GetUTCTime() {
    var dt = new Date();
    var now = new Date();
    var utc = (now.getUTCMonth() + 1) + '/' + ("0" + now.getUTCDate()).slice(-2) + '/' + now.getUTCFullYear();
    var minutes;
    var seconds;
    if (now.getUTCMinutes() < 10) {
        minutes = '0' + now.getUTCMinutes();
    }
    else {
        minutes = now.getUTCMinutes();
    }
    if (now.getUTCSeconds() < 10) {
        seconds = '0' + now.getUTCSeconds();
    }
    else {
        seconds = now.getUTCSeconds();

    }
    utc += ' ' + now.getUTCHours() + ':' + minutes + ':' + seconds;
    document.getElementById("hdnLocalTime").value = utc;
}