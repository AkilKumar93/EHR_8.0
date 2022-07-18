<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomAllDLC.ascx.cs"
    Inherits="Acurus.Capella.UI.UserControls.CustomAllDLC" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />    
<div>
    <table style="width: 100%">
        <tr>
            <td>
                <asp:TextBox ID="txtAllDLC" runat="server" TextMode="MultiLine" Style="position: static;
                    font-family: Microsoft Sans Serif; font-size: 8.5pt; resize: none;" MaxLength="32767"
                    nospell="true" oncopy="return false" onpaste="return false" oncut="return false" />
            </td>
            <td>
                <div class="col-6-btn margintop5px">
                    <a runat="server" id="pbAllDropdown" align="centre" font-bold="false" title="Drop Down">
                        <i class="fa fa-plus"></i></a>
                </div>
            </td>
            <td>
                <div class="col-6-btn margintop5px">
                    <a runat="server" id="pbAllLibrary" align="centre" font-bold="false" title="Library">
                        <i class="fa fa-database  margin2"></i></a>
                </div>
            </td>
            <td >
                <div class="col-6-btn margintop5px">
                    <a runat="server" id="pbAllClear" align="centre" font-bold="false" title="Clear"><i
                        class="fa fa-times "></i></a>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadListBox ID="listAllDLC" runat="server" Style="display: none; position: absolute;"
                    Font-Bold="false" OnClientSelectedIndexChanged="listAllDLC_SelectedIndexChanged">
                    <ButtonSettings TransferButtons="All"></ButtonSettings>
                </telerik:RadListBox>
            </td>
            <td colspan="3">
            </td>
        </tr>
        <telerik:RadWindowManager ID="WindowMngr" runat="server">
            <Windows>
                <telerik:RadWindow ID="MessageWindow" runat="server" Behaviors="Close" Title="Plan">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </table>
</div>
<%--<table style="width: 27%; height: 20px;">
    <tr>
        <td>
            <asp:TextBox ID="txtAllDLC" runat="server" TextMode="MultiLine" Style="position: static;
                font-family: Microsoft Sans Serif; font-size: 8.5pt; resize: none;" MaxLength="32767"
                nospell="true" oncopy="return false" onpaste="return false" oncut="return false" />
        </td>
        <td>
            <div class="col-6-btn margintop5px">
                <a runat="server" id="pbAllDropdown" align="centre" font-bold="false" title="Drop Down">
                    <i class="fa fa-plus"></i></a>
            </div>
        </td>
        <td>
            <div class="col-6-btn margintop5px">
                <a runat="server" id="pbAllLibrary" align="centre" font-bold="false" title="Library">
                    <i class="fa fa-database margin2"></i></a>
            </div>
        </td>
        <td>
            <div class="col-6-btn margintop5px">
                <a runat="server" id="pbAllClear" align="centre" font-bold="false" title="Clear"><i
                    class="fa fa-times "></i></a>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <telerik:RadListBox ID="listAllDLC" runat="server" Style="display: none; position: absolute;"
                Font-Bold="false" OnClientSelectedIndexChanged="listAllDLC_SelectedIndexChanged">
                <ButtonSettings TransferButtons="All"></ButtonSettings>
            </telerik:RadListBox>
        </td>
    </tr>
    <telerik:RadWindowManager ID="WindowMngr" runat="server">
        <Windows>
            <telerik:RadWindow ID="MessageWindow" runat="server" Behaviors="Close" Title="Plan">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
</table>--%>
<asp:PlaceHolder ID="PlaceHolder1" runat="server">
<link href="CSS/style.css" rel="stylesheet" type="text/css" />
<%--<link href="CSS/font-awesome.css" rel="stylesheet" type="text/css" />--%>

<script src="JScripts/JSModalWindow.js?version=<%=ConfigurationManager.AppSettings["VersionConfiguration"].ToString().Replace("Capella - ","") %>" type="text/javascript"></script>

<script src="JScripts/jsCustomDLCAll.js?version=<%=ConfigurationManager.AppSettings["VersionConfiguration"].ToString().Replace("Capella - ","") %>" type="text/javascript"></script>
</asp:PlaceHolder>
