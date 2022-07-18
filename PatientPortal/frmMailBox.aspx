<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="frmMailBox.aspx.cs" Inherits="Acurus.Capella.PatientPortal.frmMailBox" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mail Box</title>
    <style type="text/css">
        .style1 {
            height: 35px;
        }

        .style2 {
            height: 35px;
            width: 138px;
        }

        .style3 {
            height: 35px;
            width: 192px;
        }
    </style>
    <link href="CSS/CommonStyle.css" rel="stylesheet" type="text/css" />
</head>
<body onload=" {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}">
    <form id="form1" style="font-family: Microsoft Sans Serif; font-size: 8.5pt; position: static;"
        runat="server">
        <div style="height: 392px;  width: 850px">
            <table style="width: 100%; height: 386px;">
                <tr>
                    <td class="style2">
                        <asp:RadioButton ID="rdbtnInbox" GroupName="MailBox" Text="Inbox" AutoPostBack="true"
                            runat="server" class="Editabletxtbox" OnCheckedChanged="rdbtnInbox_CheckedChanged" />
                    </td>
                    <td class="style3">
                        <asp:RadioButton ID="rdbtnSentitems" Text="Sent items" GroupName="MailBox" runat="server"
                            AutoPostBack="true" class="Editabletxtbox" OnCheckedChanged="rdbtnSentitems_CheckedChanged" />
                    </td>
                    <td class="style1">
                        <asp:RadioButton ID="rdbtnCompose" Text="Compose" GroupName="MailBox" runat="server"
                            AutoPostBack="true" class="Editabletxtbox" OnCheckedChanged="rdbtnCompose_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">&nbsp;
                    <asp:Panel ID="pnlMailBox" runat="server" Height="500px"
                        Style="margin-top: 0px;">
                        <telerik:RadGrid ID="grdMailBox" GridLines="Both" runat="server" class="Editabletxtbox" AutoGenerateColumns="False"
                            CellSpacing="0" CssClass="Gridbodystyle" ClientSettings-ClientEvents-OnRowDblClick="OnRowDblClick"
                             OnItemCommand="grdMailBox_ItemCommand" Height="462px" >
                            <FilterMenu EnableImageSprites="False">
                            </FilterMenu>
                            <HeaderStyle Font-Bold="true" CssClass="Gridheaderstyle" />
                            <ClientSettings>
                                <Scrolling AllowScroll="True" UseStaticHeaders="true" />
                                <Selecting AllowRowSelect="true" />
                                <%-- <ClientEvents OnRowDblClick="OnRowDblClick" OnColumnHidden="#e1e3e4" OnRowClick="OnRowClick" />--%>
                            </ClientSettings>

                            <MasterTableView>
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="From" ItemStyle-CssClass="Editabletxtbox" FilterControlAltText="Filter From column"
                                        HeaderText="From" UniqueName="From" HeaderStyle-Width="200px" ItemStyle-Width="200px">
                                        <%--<HeaderStyle Width="200px"  />
                                        <ItemStyle Width="230px" />--%>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Subject" ItemStyle-CssClass="Editabletxtbox" FilterControlAltText="Filter Subject column"
                                        HeaderText="Subject" UniqueName="Subject" HeaderStyle-Width="300px" ItemStyle-Width="300px">
                                        <%--<HeaderStyle Width="250px"  />
                                        <ItemStyle Width="300px" />--%>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Date" ItemStyle-CssClass="Editabletxtbox" FilterControlAltText="Filter Date column"
                                        HeaderText="Date" UniqueName="Date">
                                        <HeaderStyle Width="150px" />
                                        <ItemStyle Width="70px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ToAddress" FilterControlAltText="Filter ToAddress column" ItemStyle-CssClass="Editabletxtbox"
                                        HeaderText="ToAddress" Display="false" UniqueName="ToAddress">
                                        <HeaderStyle Width="150px" />
                                        <ItemStyle Width="150px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Body" FilterControlAltText="Filter Body column" ItemStyle-CssClass="Editabletxtbox"
                                        HeaderText="Body" Display="false" UniqueName="Body">
                                        <HeaderStyle Width="150px" />
                                        <ItemStyle Width="150px" />
                                    </telerik:GridBoundColumn>

                                 

                                    <telerik:GridBoundColumn DataField="Body" FilterControlAltText="Filter Body column" ItemStyle-CssClass="Editabletxtbox"
                                        HeaderText="Body" Display="false" UniqueName="Body">
                                        <HeaderStyle Width="150px" />
                                        <ItemStyle Width="150px" />
                                    </telerik:GridBoundColumn>
                                      <%-- <telerik:GridButtonColumn UniqueName="ButtonColumn" ButtonType="ImageButton"  ImageUrl="~/Resources/Down.bmp" HeaderText="Download Attachment"
                                        CommandName="Download" >
                                        <HeaderStyle Width="150px" />
                                        <ItemStyle Width="70px" />
                                    </telerik:GridButtonColumn>--%>
                                    <telerik:GridBoundColumn DataField="DateTime" ItemStyle-CssClass="Editabletxtbox" FilterControlAltText="Filter DateTime column"
                                        HeaderText="DateTime" Display="false" UniqueName="DateTime">
                                        <HeaderStyle Width="150px" />
                                        <ItemStyle Width="150px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Filename" ItemStyle-CssClass="Editabletxtbox" FilterControlAltText="Filter DateTime column"
                                        HeaderText="Filename" Display="false" UniqueName="Filename">
                                        <HeaderStyle Width="150px" />
                                        <ItemStyle Width="150px" />
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                    </EditColumn>
                                </EditFormSettings>
                            </MasterTableView><AlternatingItemStyle BorderStyle="None" />
                        </telerik:RadGrid>
                        <iframe id="ifrmCompose" runat="server" src="" visible="false" frameborder="0"></iframe>
                    </asp:Panel>
                    </td>
                </tr>
              <%--  <tr>
                    <td></td>
                    <td></td>
                    <td align="right">&nbsp;
                  <telerik:RadButton ID="btnCancel" ButtonType="LinkButton" runat="server" Text="Cancel" CssClass="redbutton" AutoPostBack="false"
                      Width="75px" />
                    </td>
                </tr>--%>
            </table>
            <telerik:RadWindowManager EnableViewState="false" ID="WindowMngr" runat="server">
                <Windows>
                    <telerik:RadWindow ID="MessageWindo" IconUrl="~/Resources/16_16.ico" Height="380px"
                        Width="650px" VisibleStatusbar="false" Behaviors="Close" Title="Message Detail"
                        Style="display: none; position: absolute; text-align: left;" Overlay="true" Modal="true"
                        runat="server">
                        <ContentTemplate>
                        </ContentTemplate>
                    </telerik:RadWindow>
                </Windows>
            </telerik:RadWindowManager>
            <telerik:RadScriptManager ID="RadScriptManager1" EnableViewState="false" runat="server" ScriptMode="Release" LoadScriptsBeforeUI="true" EnablePageMethods="true">
            </telerik:RadScriptManager>
        </div>
        <asp:Button ID="btnMessageType" runat="server" Text="Button" Style="display: none" OnClientClick="return btnCancel_Clicked();" />
        <asp:HiddenField ID="hdnToEnableSave" runat="server" />
        <asp:HiddenField ID="hdnMessageType" runat="server" Value="" />
        <asp:HiddenField ID="hdnPatientID" runat="server" EnableViewState="false" />
        <asp:HiddenField ID="hdnEmailID" runat="server" EnableViewState="false" />
        <asp:HiddenField ID="hdnEncounterID" runat="server" EnableViewState="false" />
        <asp:HiddenField ID="hdnRole" runat="server" EnableViewState="false" />
        <asp:HiddenField ID="hdnInboxCnt" runat="server" EnableViewState="false" />
        <%--BugID:48547--%>
        <asp:HiddenField ID="hdnIsPatientPortal" runat="server" EnableViewState="false" />
        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
            <script src="JScripts/jquery-2.1.3.js" type="text/javascript"></script>
            <script src="JScripts/JSMailBox.js?version=<%=ConfigurationManager.AppSettings["VersionConfiguration"].ToString().Replace("Capella - ","") %>" type="text/javascript"></script>
            <script src="JScripts/JSErrorMessage.js?version=<%=ConfigurationManager.AppSettings["VersionConfiguration"].ToString().Replace("Capella - ","") %>" type="text/javascript"></script>
            <script src="JScripts/JSModalWindow.js?version=<%=ConfigurationManager.AppSettings["VersionConfiguration"].ToString().Replace("Capella - ","") %>" type="text/javascript"></script>

            <script src="JScripts/JSAvoidRightClick.js?version=<%=ConfigurationManager.AppSettings["VersionConfiguration"].ToString().Replace("Capella - ","") %>" type="text/javascript"></script>
        </asp:PlaceHolder>
    </form>
    <p>
        &nbsp;
    </p>
</body>
</html>
