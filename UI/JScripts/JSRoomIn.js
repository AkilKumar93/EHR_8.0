function btnCancelclickRoomIn(sender, args) {
    if ($find('btnOK')._enabled == true) {
        if (DisplayErrorMessage('220019') == true) {
            self.close();
            sender.set_autoPostBack(false);
            return false;
        }
        else { 
            $find("btnOK").set_enabled(true);
            sender.set_autoPostBack(false);
            return true;
        }
    }
    else {
        self.close();
        sender.set_autoPostBack(false);
        return false;
    }
}

function EnableSave() {
    if ($find('btnOK') != null) {
        $find("btnOK").set_enabled(true);
    }
}
function CloseWindow() {
    DisplayErrorMessage('160001');
     {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}
    var oWnd = GetRadWindow();
    oWnd.close(); 
   
}
function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow) oWindow = window.radWindow;
    else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
    return oWindow;
}