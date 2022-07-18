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
            oArg.Physician_ID = args;
            var oWnd = GetRadWindow();
            if (oArg.Physician_ID)
            {
                 oWnd.close(oArg);
            }
            else 
            {
                 alert("Please Click any one item");
            }
     }
   
 
	function btnOption1_Clicked(sender,args)
	{
	
	var value=document.getElementById('hdnButton1').value;
	returnToParent(value)
	
	}

	function btnOption2_Clicked(sender,args)
	{
	var value=document.getElementById('hdnButton2').value;
	returnToParent(value)
	}


	function btnCancel_Clicked(sender,args)
	{
	var value=document.getElementById('hdnButton3').value;
	returnToParent(value)
	}

