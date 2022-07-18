<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomDLC.ascx.cs" Inherits="Acurus.Capella.PatientPortal.UserControls.CustomDLC" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    .modal
    {
        position: fixed;
        top: 0;
        left: 0;
        background-color: White;
        z-index: 99;
        opacity: 0.8;
        filter: alpha(opacity=80);
        -moz-opacity: 0.8;
        min-height: 100%;
        width: 100%;
    }
</style>
<table style="width: 27%; height: 20px;">
    <tr>
        <td rowspan="3">
            <telerik:RadTextBox ID="txtDLC" runat="server" TextMode="MultiLine" Style="position: static"
                MaxLength="32767" nospell="true" oncopy="return false" onpaste="return false"
                oncut="return false" Height="200px" Width="300px">
            </telerik:RadTextBox>
        </td>
        <td valign="top">
            <asp:Button ID="pbDropdown" runat="server" Text="+" OnClick="pbDropdown_Click1" />
            <%-- <asp:ImageButton ID="pbDropdown" ImageUrl="~/Resources/plus_new.gif" runat="server"
                Width="20px" OnClick="pbDropdown_Click" ToolTip="DropDown" />--%>
        </td>
        <td valign="top">
            <asp:Button ID="pbLibrary" runat="server" Text="L" />
            <%--  <asp:ImageButton ID="pbLibrary" ImageUrl="~/Resources/Database Inactive.jpg" runat="server"
                Width="20px" Style="margin-left: 0px; position: static;" />--%>
        </td>
        <td valign="top">
            <asp:Button ID="pbClear" runat="server" Text="X" />
            <%--<asp:ImageButton ID="pbClear" ImageUrl="~/Resources/close_small_pressed.png" runat="server"
                Width="20px" ToolTip="Clear" />--%>
        </td>
    </tr>
</table>
<div id="divLoading" class="modal" runat="server" style="text-align: center; display: none">
    <asp:Panel ID="Panel3" runat="server">
        <br />
        <br />
        <br />
        <br />
        <center>
            <asp:Label ID="Label4" Text="" runat="server"></asp:Label></center>
        <br />
        <img src="../Resources/wait.ico" title="" alt="Loading..." />
        <br />
    </asp:Panel>
</div>
<telerik:RadWindowManager ID="WindowMngr" runat="server">
    <windows>
        <telerik:RadWindow ID="MessageWindow" runat="server" Behaviors="Close" Title="Plan">
        </telerik:RadWindow>
    </windows>
</telerik:RadWindowManager>
<asp:HiddenField ID="Status" runat="server" />
<asp:HiddenField ID="checkPlus" runat="server" />
<asp:HiddenField ID="hdnTextBoxValue" runat="server" />
<asp:HiddenField ID="HdnHpiValue" runat="server" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server">
<script src="JScripts/JSCustomDLC.js?version=<%=ConfigurationManager.AppSettings["VersionConfiguration"].ToString().Replace("Capella - ","") %>" type="text/javascript"></script>

<script src="JScripts/JSModalWindow.js?version=<%=ConfigurationManager.AppSettings["VersionConfiguration"].ToString().Replace("Capella - ","") %>" type="text/javascript"></script>
</asp:PlaceHolder>
