<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomDateTimePicker.ascx.cs"
    Inherits="Acurus.Capella.UI.UserControls.CustomDateTimePicker" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<table style="width: auto; height: auto; display: inline-block; vertical-align: middle;">
    <tr>
        <td>
            <telerik:RadComboBox ID="cboYear" runat="server" Height="250px" Width="60px" AutoPostBack="true"
                OnClientDropDownOpening="cboYear_DropDownOpening" OnClientSelectedIndexChanged="cboYear_SelectedIndexChanged">
            </telerik:RadComboBox>
        </td>
        <td>
            <telerik:RadComboBox ID="cboMonth" runat="server" Width="60px" Height="250px" AutoPostBack="true"
                OnClientDropDownOpening="cboMonth_DropDownOpening" OnClientSelectedIndexChanged="cboMonth_SelectedIndexChanged">
            </telerik:RadComboBox>
        </td>
        <td>
            <telerik:RadComboBox ID="cboDate" runat="server" Height="250px" Width="60px" AutoPostBack="true"
                OnClientSelectedIndexChanged="cboDate_SelectedIndexChanged" OnClientDropDownOpening="OnClientDropDownOpening">
            </telerik:RadComboBox>
        </td>
        <td>
            <asp:ImageButton ID="RadButton1" runat="server" ImageUrl="~/Resources/calenda2.bmp"
                Width="18px" />
        </td>
        <asp:HiddenField ID="hdnVisibe" runat="server" />
    </tr>
    <tr>
        <td colspan="5">
            <telerik:RadCalendar ID="clbCalendar" AutoPostBack="false" runat="server" ShowRowHeaders="false"
                Style="position: absolute; display: none; z-index: 4500;" ShowColumnHeaders="true"
                Width="200px" EnableShadows="true" ShowOtherMonthsDays="true" UseColumnHeadersAsSelectors ="false" RangeMinDate="1/1/1900 12:00:00 AM">
                
                <DayOverStyle CssClass="rcHover"></DayOverStyle>
                <FastNavigationStyle CssClass="RadCalendarMonthView RadCalendarMonthView_Default">
                </FastNavigationStyle>
                <DisabledDayStyle CssClass="rcDisabled"></DisabledDayStyle>
                <WeekendDayStyle CssClass="rcWeekend"></WeekendDayStyle>
                <ViewSelectorStyle CssClass="rcViewSel"></ViewSelectorStyle>
                <ClientEvents OnDateClick="clbCalendar_OnDateClick" />
                <SelectedDayStyle CssClass="rcSelected"></SelectedDayStyle>
                <FooterTemplate>
                    <asp:Button runat="server" ID="Button1" type="button" Text="Today" OnLoad="Button1_Load" />
                    <asp:Label ID="Label1" runat="server" OnLoad="Label1_Load" Text="Today"></asp:Label>
                </FooterTemplate>
                <CalendarTableStyle CssClass="rcMainTable"></CalendarTableStyle>
                <OtherMonthDayStyle CssClass="rcOtherMonth"></OtherMonthDayStyle>
                <OutOfRangeDayStyle CssClass="rcOutOfRange"></OutOfRangeDayStyle>
            </telerik:RadCalendar>
        </td>
    </tr>
</table>
<asp:PlaceHolder ID="PlaceHolder1" runat="server">
<script src="JScripts/JSCustomDateTimePicker.js?version=<%=ConfigurationManager.AppSettings["VersionConfiguration"].ToString().Replace("Capella - ","") %>" type="text/javascript"></script>
</asp:PlaceHolder>
