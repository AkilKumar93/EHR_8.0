      function GetRadWindow()
        {
                    var oWindow = null;
                    if (window.radWindow)
                        oWindow = window.radWindow;
                    else if (window.frameElement.radWindow)
                        oWindow = window.frameElement.radWindow;
                    return oWindow;
        }
    
    function Close(typebtn)
    {
    
   
            var oArg = new Object();
            oArg.result = typebtn.value;
            var oWnd = GetRadWindow();
            if (oArg.result)
            {
                 oWnd.close(oArg.result);
            }
     
    }
 