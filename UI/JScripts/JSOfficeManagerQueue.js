function ClearAll()
{
    var IsClearAll=DisplayErrorMessage('200005');
	if(IsClearAll==true)
	{
	    document.getElementById('btnHdnClearall').click();
	    return true;
    }
    else
    {
	    return false;
    }
 
}

function LoadCursor()
{
    document.getElementById("divLoading").style.display="block";
}

function GetObjects()
{
    { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
}
function WindowClose()
{
    var oWindow = null;
          if (window.radWindow)
               oWindow = window.radWindow;
          else if (window.frameElement.radWindow)
               oWindow = window.frameElement.radWindow;
          if(oWindow!=null)
           oWindow.close();
}

function cboObjectType_SelectedIndexChanged(sender,args)
{
	var SelectItem=$find("cboObjectType")._text;
    if(SelectItem!=null &&SelectItem!=" ")
    {
        { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}
        return true;
    }
    else
    {
        return false;
    }
}

function CloseObjects()
{
        document.getElementById("divLoading").style.display="none";
}
   