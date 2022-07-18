<%@ Page  Async="true" Language="C#" AutoEventWireup="true" CodeBehind="frmFindAllAppointments.aspx.cs"
    Inherits="Acurus.Capella.UI.frmFindAllAppointments" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Find Appointments</title>
    <%--<script src="https://logrocket.acurussolutions.io/LogRocket.js"; crossorigin="anonymous"></script> <script>window.LogRocket && window.LogRocket.init('akido/akido-test', { mergeIframes: true }, { enableVerboseLogging: true });</script>--%>
    <base target="_self" />
    <style type="text/css">
        .style1 {
            width: 117px;
        }

        .style2 {
            width: 312px;
        }

        .style3 {
            width: 594px;
        }

        .displayNone {
            display: none;
        }

        #frmFindAllAppointments {
            width: 855px;
            margin-bottom: 0px;
        }
    </style>
    <%--<link href="CSS/ElementStyles.css" rel="stylesheet" type="text/css" />--%>
      <link href="CSS/CommonStyle.css" rel="stylesheet" type="text/css" />
</head>
<body onload=" {sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}">
    <form id="frmFindAllAppointments" runat="server">
        <telerik:RadWindowManager ID="ModalWindowMngt" runat="server">
            <Windows>
                <telerik:RadWindow ID="ModalWindowAppmnt" runat="server" VisibleOnPageLoad="false"
                    Height="625px" IconUrl="Resources/16_16.ico" Width="1225px">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">
        </asp:ToolkitScriptManager>
        <asp:UpdatePanel ID="updatepanel" runat="server">
            <ContentTemplate>
                <div>
                    <div>
                        <asp:Panel ID="pnlPatientInfo" runat="server" Font-Size="Small" Width="853px">
                            <table style="width: 100%;">
                                <tr>
                                    <td class="style1">&nbsp;
                            <asp:Label ID="lblPatientName" runat="server" Text="Patient Name" EnableViewState="false" CssClass="Editabletxtbox"></asp:Label>
                                    </td>
                                    <td class="style2">&nbsp;
                            <asp:TextBox ID="txtPatientName" runat="server" Width="256px" BackColor="#BFDBFF"
                              ReadOnly="True" CssClass="nonEditabletxtbox"></asp:TextBox>
                                    </td>
                                    <td colspan="4">&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">&nbsp;
                            <asp:Label ID="lblPatientAccNO" runat="server" Text="Patient Account #" EnableViewState="false" CssClass="Editabletxtbox"></asp:Label>
                                    </td>
                                    <td class="style2">&nbsp;
                            <asp:TextBox ID="txtPatientAccountNO" runat="server" Width="256px" BackColor="#BFDBFF"
                               ReadOnly="True" CssClass="nonEditabletxtbox"></asp:TextBox>
                                    </td>
                                    <td colspan="2">&nbsp;
                                    </td>
                                    <td colspan="2">&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">&nbsp;
                            <asp:Label ID="lblPatientDOB" runat="server" Text="Patient DOB" EnableViewState="false" CssClass="Editabletxtbox"></asp:Label>
                                    </td>
                                    <td class="style2">&nbsp;
                            <asp:TextBox ID="txtPatientDOB" runat="server" Width="256px" BackColor="#BFDBFF"
                               ReadOnly="True" CssClass="nonEditabletxtbox"></asp:TextBox>
                                    </td>
                                    <td colspan="4">&nbsp;
                            <asp:Button ID="btnFindPatient" runat="server" Text="Find Patient" OnClientClick="return OpenFindPatinet();"
                                OnClick="btnFindPatient_Click" CssClass="aspbluebutton"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblSearchResult" runat="server" Text="SearchResultFound" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td class="style2">&nbsp;
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkShowOldAppointments" runat="server" AutoPostBack="True" OnCheckedChanged="chkShowOldAppointments_CheckedChanged" onclick="WaitCursor();"
                                            Text="Show Old Appointments" CssClass="Editabletxtbox"/>
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                    <div style="width: 843px">
                        <asp:Panel ID="pnlAppointmentInfo" runat="server" Font-Size="Small" Width="843px"
                            Height="200px">
                            <telerik:RadGrid ID="grdAppointment" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                                GridLines="None"  AllowSorting="true" CssClass="Gridbodystyle"                              AllowMultiRowSelection="false"
                                Width="855px">
                                 <HeaderStyle CssClass="Gridheaderstyle" HorizontalAlign="Center" Font-Bold="True" Width="175px" />
                                <%-- OnSelectedIndexChanged="grdAppointment_SelectedIndexChanged"--%>
                                <ClientSettings AllowKeyboardNavigation="true"> <%--EnablePostBackOnRowClick="true"--%>
                                    <Selecting AllowRowSelect="true" CellSelectionMode="None" />
                                    <KeyboardNavigationSettings EnableKeyboardShortcuts="true" AllowActiveRowCycle="true" />
                                    <ClientEvents OnRowClick="grdAppointment_OnRowClick" />
                                    <Scrolling AllowScroll="True" UseStaticHeaders="true" ScrollHeight="180px" />
                                    <Resizing AllowResizeToFit="true" />
                                </ClientSettings>
                                <MasterTableView AllowAutomaticUpdates="false" ClientDataKeyNames="Appt_ID" >
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="AppointmentDate" FilterControlAltText="Filter AppointmentDate column"
                                            HeaderText="Appointment Date Time" UniqueName="AppointmentDate">
                                            <HeaderStyle HorizontalAlign="Center" Font-Bold="True" Width="50px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="AppointmentTime" FilterControlAltText="Filter AppointmentTime column"
                                            HeaderText="Appointment Time" UniqueName="AppointmentTime" Display="false">
                                            <HeaderStyle  HorizontalAlign="Center" Font-Bold="True" Width="60px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="ProviderName" FilterControlAltText="Filter ProviderName column"
                                            HeaderText="Provider Name" UniqueName="ProviderName" >
                                            <HeaderStyle  HorizontalAlign="Center" Font-Bold="True"  Width="60px"/>
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="FacilityName" FilterControlAltText="Filter FacilityName column"
                                            HeaderText="Facility Name" UniqueName="FacilityName">
                                            <HeaderStyle  HorizontalAlign="Center" Font-Bold="True"  Width="80px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Appt_ID" FilterControlAltText="Filter Appt_ID column"
                                            HeaderText="Appt_ID" UniqueName="Appt_ID" Display="false">
                                            <HeaderStyle HorizontalAlign="Center" Font-Bold="True"  Width="80px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CurrentProcess" FilterControlAltText="Filter CurrentProcess column"
                                            HeaderText="Current Process" UniqueName="CurrentProcess">
                                            <HeaderStyle  HorizontalAlign="Center" Font-Bold="True"  Width="60px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Appt_Provider_Id" FilterControlAltText="Filter Appt_Provider_Id column"
                                            HeaderText="Appt_Provider_Id" UniqueName="Appt_Provider_Id" Display="false">
                                            <HeaderStyle  HorizontalAlign="Center" Font-Bold="True"  Width="80px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Test_Ordered" FilterControlAltText="Filter Test_Ordered column"
                                            HeaderText="Test Ordered" UniqueName="Test_Ordered">
                                            <HeaderStyle  HorizontalAlign="Center" Font-Bold="True"  Width="60px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Rescheduled_Appointment_Date" FilterControlAltText="Filter Rescheduled_Appointment_Date Column"
                                            HeaderText="Rescheduled Appointment Date" UniqueName="Rescheduled_Appointment_Date">
                                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Width="80px" />
                                        </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="Reason_for_Cancelation" FilterControlAltText="Filter Reason_for_Cancelation Column"
                                            HeaderText="Reason for Cancelation" UniqueName="Reason_for_Cancelation">
                                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Width="80px" />
                                        </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="Is_Archieve" FilterControlAltText="Filter Is Archieve"
                                            HeaderText="Is Archieve" UniqueName="Is_Archieve" Display="false">
                                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Width="80px" />
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </asp:Panel>
                    </div>
                    <br />
                    <br />
                    <div>
                        <asp:Panel ID="pnlButtons" runat="server" Font-Size="Small" Width="818px" Height="33px">
                            <table style="width: 100%;">
                                <tr>
                                    <td class="style3">&nbsp;
                                        <asp:LinkButton ID="btnFirst" runat="server" CommandArgument="First" OnCommand="PageChangeEventHandler">First</asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="btnPrevious" runat="server" CommandArgument="Previous"
                                            OnCommand="PageChangeEventHandler">Previous</asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="btnNext" runat="server" CommandArgument="Next" OnCommand="PageChangeEventHandler">Next</asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="btnLast" runat="server" CommandArgument="Last" OnCommand="PageChangeEventHandler">Last</asp:LinkButton>
                                        &nbsp;<asp:Label ID="lblShowing" EnableViewState="false" runat="server" ClientIdMode="Static"></asp:Label>
                                        <asp:Button ID="btnFindPatientRefresh" runat="server" CssClass="displayNone" OnClick="btnFindPatientRefresh_Click"
                                            Text="Button" />
                                    </td>

                                    <td>
                                        <asp:Button ID="btnCancelAppointment" runat="server" Text="Cancel Appointment" style="margin-top: 10px;"
                                            OnClick="btnCancelAppointment_Click" CssClass="aspbluebutton" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnEditAppointment" runat="server" Text="Edit Appointment" OnClientClick="return OpenEditAppointment();" style="margin-top: 9px;"
                                            OnClick="btnEditAppointment_Click" CssClass="aspgreenbutton"/>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="return CloseWindow();" style="margin-top: 9px;margin-right: -35px;"
                                            EnableViewState="false" CssClass="aspredbutton" />
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField ID="hdnSelectedIndex" runat="server" EnableViewState="false" />
                            <asp:HiddenField ID="hdnHumanID" runat="server" EnableViewState="false" />
                            <asp:HiddenField ID="hdnLastPageNo" runat="server" EnableViewState="false" />
                            <asp:HiddenField ID="hdnTotalCount" runat="server" EnableViewState="false" />
                        </asp:Panel>
                    </div>
                </div>
                <asp:Button ID="btnRefresh" runat="server" Style="display: none" OnClick="btnRefresh_Click"
                    Text="Refresh" />
                <br />
                <asp:PlaceHolder ID="PlaceHolder1" runat="server">

                    <script src="JScripts/JSErrorMessage.js?version=<%=ConfigurationManager.AppSettings["VersionConfiguration"].ToString().Replace("Capella - ","") %>"
                        type="text/javascript"></script>

                    <script src="JScripts/JSFindAllAppointments.js?version=<%=ConfigurationManager.AppSettings["VersionConfiguration"].ToString().Replace("Capella - ","") %>"
                        type="text/javascript"></script>

                    <script src="JScripts/JSAvoidRightClick.js?version=<%=ConfigurationManager.AppSettings["VersionConfiguration"].ToString().Replace("Capella - ","") %>"
                        type="text/javascript"></script>

                    <script src="JScripts/jquery-1.7.1.min.js" type="text/javascript"></script>

                </asp:PlaceHolder>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
