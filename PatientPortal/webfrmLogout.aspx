<%@ Page  Async="true" Language="C#" AutoEventWireup="true" CodeBehind="webfrmLogout.aspx.cs" Inherits="PatientPortal.webfrmLogout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
 window.history.forward(1);
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"> 
</asp:ScriptManager> 
<asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick"> 
</asp:Timer>

    </div>
    </form>
</body>
</html>
