<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomPhrases.ascx.cs"
    Inherits="Acurus.Capella.UI.UserControls.CustomPhrases" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<style type="text/css">
    .displayNone
    {
        display: none;
    }
</style>
<%--<asp:ImageButton ID="pbCustomPhrases" ImageUrl="~/Resources/Letter-P-blue-icon_16.png"
    runat="server" ToolTip="Phrase" Width="20px" OnClick="pbCustomPhrases_Click" />--%>
<div class="col-6-btn margintop5px">
<%-- To Make Phrase icon visible for select screens like before, 
just remove 'Visibility: hidden' property from below line - For BugID:30521 - Pujhitha --%>
    <a runat="server" id="pbCustomPhrases" align="centre" font-bold="false" style="display: none; visibility:hidden;
        height: 12px;" title="Choose Custom Phrases"><span class="margin2 fs12 ">P</span></a>
</div>
<asp:HiddenField ID="hdnValue" runat="server" Value="" />
<asp:HiddenField ID="hdnDelImmuniztionId" runat="server" />
<asp:HiddenField ID="hdnRefreshPhrase" runat="server" />
<asp:HiddenField ID="hdnSave" runat="server" />
<asp:HiddenField ID="hdnPlaceHolder" runat="server" />
<asp:Button ID="InvisibleButton" runat="server" CssClass="displayNone" OnClick="InvisibleButton_Click" />
<%--<asp:Button ID="HiddenBtn" runat="server" CssClass="displayNone" OnClick="HiddenBtn_Click" />--%>
<asp:PlaceHolder ID="PlaceHolder1" runat="server">
<link href="CSS/style.css" rel="stylesheet" type="text/css" />
<link href="CSS/font-awesome.css" rel="stylesheet" type="text/css" />
<script src="JScripts/JSCustomPhrases.js?version=<%=ConfigurationManager.AppSettings["VersionConfiguration"].ToString().Replace("Capella - ","") %>" type="text/javascript"></script>
<script src="JScripts/JSModalWindow.js?version=<%=ConfigurationManager.AppSettings["VersionConfiguration"].ToString().Replace("Capella - ","") %>" type="text/javascript"></script>
<script src="JScripts/JSErrorMessage.js?version=<%=ConfigurationManager.AppSettings["VersionConfiguration"].ToString().Replace("Capella - ","") %>" type="text/javascript"></script>
</asp:PlaceHolder>