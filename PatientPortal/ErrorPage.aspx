<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="Acurus.Capella.PatientPortal.ErrorPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Error</title>

    <style type="text/css">
        .* {
            font-size: small;
            font-family: Microsoft Sans Serif;
            top: 0px;
            left: 0px;
            -webkit-box-sizing: border-box; /* Safari/Chrome, other WebKit */
            -moz-box-sizing: border-box; /* Firefox, other Gecko */
            margin: 0px;
            padding: 0px;
        }
    </style>
    <link href="CSS/bootstrap.min.css" rel="stylesheet" />
    <script src="JScripts/jquery-1.11.3.min.js" type="text/javascript"></script>
</head>

<body onload="myFunction()">
    <form id="form1" runat="server">
        <div>
            <p>
                Error:
            <br />
                <asp:Label ID="friendlyErrorMsg" runat="server" Text="Label" Style="color: red"></asp:Label>
            </p>
            <asp:Panel ID="detailedErrorPanel" runat="server" Visible="false">
                <%--<p>
                Detailed Error:
                <br />
                <asp:Label ID="errorDetailedMsg" runat="server" Font-Bold="true" Font-Size="Large" /><br />
            </p>
            <p>
                Error Handler:
                <br />
                <asp:Label ID="errorHandler" runat="server" Font-Bold="true" Font-Size="Large" /><br />
            </p>--%>
                <p>
                    Detailed Error Message:
                <br />
                    <asp:Label ID="innerMessage" runat="server" /><br />
                </p>
                <pre style="border: none;">
                  <asp:Label ID="innerTrace" runat="server" Visible="False" />
            </pre>
                <%--<p>
                Date and Time:
                <br />
                <asp:Label ID="dateandTime" runat="server" Font-Bold="true" Font-Size="Large" /><br />
            </p>--%>
            </asp:Panel>
            <div style="width: 100%; align-items: center;">
                <table>
                    <tr style="width: 100%;">
                        <td style="width: 40%;"></td>
                        <td style="width: 10%;">
                             <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary" OnClick="btnLogin_Click"
                    Text="Click here to Login" Visible="false"/>
                        </td>
                        <td style="width: 40%;"></td>
                    </tr>
                </table>
               
            </div>
        </div>
    </form>

    <script type="text/javascript">
        function myFunction() {
            jQuery(top.window.parent.parent.parent.parent.parent.parent.document.body).find('#resultLoading .bg').height('100%');
            jQuery(top.window.parent.parent.parent.parent.parent.parent.document.body).find('#resultLoading').fadeOut(300);
            jQuery(top.window.parent.parent.parent.parent.document.body).css('cursor', 'default');
            if (jQuery(top.window.parent.parent.parent.parent.parent.parent.document.body).find('#resultLoading').css('display') == 'block')
                jQuery(top.window.parent.parent.parent.parent.parent.parent.document.body).find('#resultLoading').remove();
        }
    </script>
</body>
</html>
