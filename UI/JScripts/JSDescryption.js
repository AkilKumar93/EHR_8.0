function btnClose_Clicked(sender,args)
{
    GetRadWindow().close();
}

function GetRadWindow() 
{
    var oWindow = null;
    if (window.radWindow) oWindow = window.radWindow;
    else if (window.frameElement!=null&&window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
    return oWindow;
}

function EncryptedLocation()
{
document.getElementById("InvisibleEncryptedLocation").click();
}

function EncryptedFile()
{
document.getElementById("InvisibleEncryptedFile").click();
}

function changeTest()
{
document.getElementById("InvisibleCbo").click();
}