function GetRadWindow() 
    {
        var oWindow = null;
        if (window.radWindow) oWindow = window.radWindow;
        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
        return oWindow;
    }
    
    
    function returnToParent(args)
     {
            var oArg = new Object();
            oArg.result = args;
            var oWnd = GetRadWindow();
            if (oArg.result)
            {
                 oWnd.close(oArg.result);
            }
            else 
            {
                oWnd.close(oArg.result);
            }
     }
    
