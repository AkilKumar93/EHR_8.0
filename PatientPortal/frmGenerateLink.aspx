<%@ Page  Async="true" Language="C#" AutoEventWireup="true" CodeBehind="frmGenerateLink.aspx.cs" Inherits="Acurus.Capella.PatientPortal.frmGenerateLink" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Generate Link</title>
</head>
    <script src="JScripts/jquery-2.1.3.js" type="text/javascript"></script>
         <script src="JScripts/bootstrap.min.js" type="text/javascript"></script>
<link href="CSS/CommonStyle.css" rel="stylesheet" />
    <script>
        function Validate() {
            var password = document.getElementById("txtsetpassword").value;
             
            var confirmPassword = document.getElementById("txtvrypasswrd").value;
            if (password == "" ) {
                alert("Please Enter Password");
                return false;
            }
            else if (confirmPassword == "") {
                alert("Please Enter Verify Password");
                return false;
            }
            else if (password != confirmPassword) {
                alert("Passwords do not match.");
                return false;
            }
           
                { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
                return true;
           
           
        }
        function disablebtnGenerate() {
            debugger;
            if ($(top.window.document).find("#btngeneratelink")[0]!=undefined)
            $(top.window.document).find("#btngeneratelink")[0].disabled = true;
            unloadwaitcursor();
        }
        function unloadwaitcursor() {
           
            { sessionStorage.setItem('StartLoading', 'false'); }
            jQuery(window.top.parent.parent.parent.parent.parent.parent.document.body).find('#resultLoading .bg').height('100%');
            jQuery(window.top.parent.parent.parent.parent.parent.parent.document.body).find('#resultLoading').fadeOut(300);
            jQuery(window.top.parent.parent.parent.parent.document.body).css('cursor', 'default');
            if (jQuery(window.top.parent.parent.parent.parent.parent.parent.document.body).find('#resultLoading').css('display') == 'block')
                jQuery(window.top.parent.parent.parent.parent.parent.parent.document.body).find('#resultLoading').remove();
        }
        function LoadGenerateLink()
        {
            $("span[mand=Yes]").addClass('MandLabelstyle');

            $("span[mand=Yes]").each(function () {
                $(this).html($(this).html().replace("*", "<span class='manredforstar'>*</span>"));
            });
        }

        </script>
<body onload="LoadGenerateLink();">
    <form id="form1" runat="server" >
    <div>
     
       <table>

           <tr class="Editabletxtbox">
               <td>
 <asp:Label ID="lblsetpswd" runat="server"   Text="Set Password*" mand="Yes"></asp:Label>
               </td>
               <td>
  <asp:TextBox ID="txtsetpassword" Type="password"   runat="server"    TextMode="Password"  MaxLength="45" Width="350" autocomplete="off" ></asp:TextBox>
               </td>
           </tr>
           <tr class="Editabletxtbox">
               <td>
  <asp:Label ID="lblverifypwd" runat="server"  Text="Verify Password*" mand="Yes"></asp:Label>
               </td>
               <td>
<asp:TextBox ID="txtvrypasswrd"  runat="server"    TextMode="Password"  Width="350" autocomplete="off" ></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
               </td>
               <td>
                   <div style="padding-left:75%">
<asp:Button ID="btngenerate" runat="server" Text="Generate" OnClientClick="return Validate()" OnClick="btngenerate_Click" CssClass="aspbluebutton" />
                       </div>
               </td>
           </tr>
           <tr>
               <td>
                   <asp:Label ID="lbllink" runat="server"  Text="Link" CssClass="Editabletxtbox" ></asp:Label>

                   </td>
               <td>
                   <asp:TextBox ID="txtlink"  runat="server" Width="350" Enabled="false" CssClass="nonEditabletxtbox" ></asp:TextBox>
               </td>
           </tr>
       </table>
    <asp:HiddenField ID="hdnNo" runat="server" />
    </div>
    </form>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        
        <script src="JScripts/JSErrorMessage.js?version=<%=ConfigurationManager.AppSettings["VersionConfiguration"].ToString().Replace("Capella-","") %>" type="text/javascript"></script>
       
     
    </asp:PlaceHolder>
</body>
</html>
