<%@ Page  Async="true" Language="C#" AutoEventWireup="True" CodeBehind="frmViewResult.aspx.cs" EnableEventValidation="false"
    Inherits="Acurus.Capella.PatientPortal.frmViewResult" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/CustomDLCNew.ascx" TagName="DLC" TagPrefix="DLC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Result</title>
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <base target="_self" />
    <script type="text/javascript" id="telerikClientEvents1">

        function txtProviderNotes_OnKeyPress(sender, args) {
            //	var bSave =  $find('btnSave');
            document.getElementById(GetClientId("hdnSave")).value = "true";
            if (window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable != undefined)
                window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable.value = "true";
            document.getElementById(GetClientId("btnSave")).disabled = false;
        }

        function txtMedicalAssistantNotes_OnKeyPress(sender, args) {
            //	var bSave =  $find('btnSave');
            document.getElementById(GetClientId("hdnSave")).value = "true";
            if (window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable != undefined)
                window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable.value = "true";
            document.getElementById(GetClientId("btnSave")).disabled = false;
        }

        //Modified By Suvarnni for YesNoCancel

        function btnSave_ClientClick(sender, args) {
            { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
        }

        function AutosaveDisable(IsEnable) {
            if (window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable != null && window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable != undefined) {
                window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable.value = IsEnable;
            }
        }
        function EnableSave() {
            document.getElementById(GetClientId("btnSave")).disabled = false;
        }
        function txtProviderNotes_OnValueChanged(sender, args) {
            document.getElementById('btnSave').enabled = true;
        }

        function txtMedicalAssistantNotes_OnValueChanged(sender, args) {
            document.getElementById('btnSave').enabled = true;
        }
        function EnableSave() {
            document.getElementById('btnSave').enabled = true;
        }
        function btnMoveToMa_ClientClicked(sender, args) {
            //{ sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
            StartLoadingImage(); //BugID:41027 -- move to next result
        }
        function btnMoveToNextProcess_ClientClicked(sender, args) {
            //{ sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
            StartLoadingImage();//BugID:41027 -- move to next result
        }
        function tabView_TabSelected(sender, args) {
            sender.set_enabled(false);
            { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }
        }
        function SaveViewResults() {
            { sessionStorage.setItem('StartLoading', 'false'); StopLoadFromPatChart(); }
            AutosaveDisable('false');
            DisplayErrorMessage('115009');
        }
        function btnClose_Clicked(sender, args) {
            if (Result != undefined) {
                if (false == Result.closed) {

                    Result.close();
                }
            }
            if (document.getElementById('hdnTab').value == "true") {
                if (document.getElementById("hdnMessageType").value == "") {
                    DisplayErrorMessage('1105001');
                }
                else if (document.getElementById("hdnMessageType").value == "Yes") {
                    //__doPostBack('btnSave', "true");
                    document.getElementById("btnSave").click();
                    DisplayErrorMessage('115009');
                    window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable.value == "false";
                    document.getElementById(GetClientId("hdnMessageType")).value = "";
                    $(top.window.document).find('#btnCloseViewResult')[0].click();
                    self.close();
                }
                else if (document.getElementById("hdnMessageType").value == "No") {
                    document.getElementById("hdnMessageType").value = "";
                    $(top.window.document).find('#btnCloseViewResult')[0].click();
                    self.close();
                }
                else if (document.getElementById("hdnMessageType").value == "Cancel") {
                    document.getElementById("hdnMessageType").value = "";
                }
            }
            if (document.getElementById('btnSave') != null) {
                if (document.getElementById('btnSave').disabled == false) {
                    if (document.getElementById("hdnMessageType").value == "") {
                        DisplayErrorMessage('1105001');
                    }
                    else if (document.getElementById("hdnMessageType").value == "Yes") {
                        //__doPostBack('btnSave', "true");
                        document.getElementById("btnSave").click();
                        DisplayErrorMessage('115009');
                        document.getElementById('btnSave').disabled = "true";
                        document.getElementById(GetClientId("hdnMessageType")).value = "";
                        $(top.window.document).find('#btnCloseViewResult')[0].click();
                        self.close();
                    }
                    else if (document.getElementById("hdnMessageType").value == "No") {
                        document.getElementById("hdnMessageType").value = "";
                        $(top.window.document).find('#btnCloseViewResult')[0].click();
                        self.close();
                    }
                    else if (document.getElementById("hdnMessageType").value == "Cancel") {
                        document.getElementById("hdnMessageType").value = "";
                    }
                }
                else {
                    //self.close();
                    var win = GetRadWindow();
                    if (win != null) {
                        win.close();
                    }
                    else {
                        $(top.window.document).find('#btnCloseViewResult')[0].click();
                    }
                }
            }
            else if (document.getElementById('btnSave') == null) {
                var win = GetRadWindow();
                if (win != null) {
                    win.close();
                }
                else {
                    $(top.window.document).find('#btnCloseViewResult')[0].click();
                }
            }
            else {
                //self.close();
                var win = GetRadWindow();
                if (win != null) {
                    win.close();
                }
                else {
                    $(top.window.document).find('#btnCloseViewResult')[0].click();
                }
            }
        }
    </script>
    <style type="text/css">
        .style1 {
            height: 12px;
        }

        .elements {
            height: 10px;
            font-size: small;
        }

        .DisplayNone {
            display: none;
        }

        .modal {
            position: fixed;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            z-index: 1050;
            display: none;
            overflow: hidden;
            -webkit-overflow-scrolling: touch;
            outline: 0;
        }

            .modal.fade .modal-dialog {
                -webkit-transition: -webkit-transform .3s ease-out;
                -o-transition: -o-transform .3s ease-out;
                transition: transform .3s ease-out;
                -webkit-transform: translate(0, -25%);
                -ms-transform: translate(0, -25%);
                -o-transform: translate(0, -25%);
                transform: translate(0, -25%);
            }

            .modal.in .modal-dialog {
                -webkit-transform: translate(0, 0);
                -ms-transform: translate(0, 0);
                -o-transform: translate(0, 0);
                transform: translate(0, 0);
            }

        .modal-open .modal {
            overflow-x: hidden;
            overflow-y: auto;
        }

        .modal-dialog {
            position: relative;
            width: auto;
            margin: 10px;
        }

        .modal-content {
            position: relative;
            background-color: #fff;
            -webkit-background-clip: padding-box;
            background-clip: padding-box;
            border: 1px solid #999;
            border: 1px solid rgba(0, 0, 0, .2);
            border-radius: 6px;
            outline: 0;
            -webkit-box-shadow: 0 3px 9px rgba(0, 0, 0, .5);
            box-shadow: 0 3px 9px rgba(0, 0, 0, .5);
        }

        .modal-backdrop {
            position: fixed;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            z-index: 1040;
            background-color: #000;
        }

            .modal-backdrop.fade {
                filter: alpha(opacity=0);
                opacity: 0;
            }

            .modal-backdrop.in {
                filter: alpha(opacity=50);
                opacity: .5;
            }

        .modal-header {
            padding: 15px;
            border-bottom: 1px solid #e5e5e5;
        }

            .modal-header .close {
                margin-top: -2px;
            }

        .modal-title {
            margin: 0;
            line-height: 1.42857143;
        }

        .modal-body {
            position: relative;
            padding: 15px;
        }

        .modal-footer {
            padding: 15px;
            text-align: right;
            border-top: 1px solid #e5e5e5;
        }

            .modal-footer .btn + .btn {
                margin-bottom: 0;
                margin-left: 5px;
            }

            .modal-footer .btn-group .btn + .btn {
                margin-left: -1px;
            }

            .modal-footer .btn-block + .btn-block {
                margin-left: 0;
            }

        .modal-scrollbar-measure {
            position: absolute;
            top: -9999px;
            width: 50px;
            height: 50px;
            overflow: scroll;
        }

        @media (min-width: 768px) {
            .modal-dialog {
                width: 600px;
                margin: 30px auto;
            }

            .modal-content {
                -webkit-box-shadow: 0 5px 15px rgba(0, 0, 0, .5);
                box-shadow: 0 5px 15px rgba(0, 0, 0, .5);
            }

            .modal-sm {
                width: 300px;
            }
        }

        @media (min-width: 992px) {
            .modal-lg {
                width: 900px;
            }
        }

        .modal-header:before,
        .modal-header:after,
        .modal-footer:before,
        .modal-footer:after {
            display: table;
            content: " ";
        }

        .modal-header:after,
        .modal-footer:after {
            clear: both;
        }

        .close {
            float: right;
            font-size: 21px;
            font-weight: bold;
            line-height: 1;
            color: #000;
            text-shadow: 0 1px 0 #fff;
            filter: alpha(opacity=20);
            opacity: .2;
        }

            .close:hover,
            .close:focus {
                color: #000;
                text-decoration: none;
                cursor: pointer;
                filter: alpha(opacity=50);
                opacity: .5;
            }

        button.close {
            -webkit-appearance: none;
            padding: 0;
            cursor: pointer;
            background: transparent;
            border: 0;
        }

        .rtsUL, .rtsScroll {
            width: 935px !important;
        }
    </style>

    <link href="CSS/style.css" rel="stylesheet" type="text/css" />
    <link href="CSS/font-awesome.css" rel="stylesheet" type="text/css" />
      <link href="CSS/CommonStyle.css" rel="stylesheet" type="text/css" />
</head>
<body onload="{sessionStorage.setItem('StartLoading', 'false');StopLoadFromPatChart();}">
    <form id="frmViewResult" runat="server" style="background-color: White;">
        <telerik:RadWindowManager ID="Resulst" runat="server" EnableViewState="false">
            <Windows>
                <telerik:RadWindow ID="MessageWindow" runat="server" VisibleOnPageLoad="false" Modal="true"
                    Behaviors="Close" IconUrl="Resources/16_16.ico" EnableViewState="false">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
            <table id="tblView" runat="server" style="width: 100%; height: 100%;">
                <tr  id="trPatInfo" runat="server">
                    <td width="100%" colspan="2">
                        <input type="text" runat="server" readonly="readonly" style="width: 100%; border: 1px solid black;" id="txtPatientInformation" class="nonEditabletxtbox" />
                    </td>
                </tr>
                <tr style="background-color: #BFDBFF;">
                    <td width="100%" colspan="2">
                        <input type="text" runat="server" readonly="readonly" style="width: 100%; border: 1px solid black;" id="txtFileInformation"  class="nonEditabletxtbox"/>
                    </td>
                </tr>
                <tr id="test">
                    <td id="c1" style="width: 20%;" valign="top" runat="server">
                        <asp:Panel ID="pnlTree" runat="server" Width="100%" BorderStyle="Solid"
                            BorderWidth="1px">
                            <table id="tblTree" runat="server" style="width: 100%;">
                                <tr>
                                    <td colspan="2" height="3%">
                                        <asp:Label ID="lblDocumentType" runat="server" Text="Document Type" Width="100%" CssClass="spanstyle"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" height="5%"><%-- Added ClientSelectedIndexChanged for Document Type--%>
                                        <telerik:RadComboBox ID="cboDocumentType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboDocumentType_SelectedIndexChanged" onchange="{ sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}"
                                            Width="100%">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr style="display: none;">
                                    <%-- BUGID:43099 --%>
                                    <td colspan="2" height="3%">
                                        <asp:Label ID="lblDocumentSubType" runat="server" Text="Document Sub Type" Width="100%" CssClass="spanstyle"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <%-- BUGID:43099 --%>
                                    <td height="12%" valign="top" width="90%">
                                        <telerik:RadTextBox ID="txtDocumentSubType" runat="server" Height="100%" ReadOnly="False"
                                            TextMode="MultiLine" Width="100%" Visible="false">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td height="12%" width="10%">
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="pbPlus" runat="server" class="button" ImageUrl="~/Resources/plus_new.gif"
                                                        OnClick="pbPlus_Click" ToolTip="Select Document Subtype" Visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="pbClear" runat="server" class="button" ImageUrl="~/Resources/close_small_pressed.png"
                                                        OnClientClick="Clear();" ToolTip="Clear All" Visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="pbFilter" runat="server" class="button" ImageUrl="~/Resources/Filter.bmp"
                                                        OnClick="pbFilter_Click" ToolTip="Filter" Visible="false" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" height="62%" valign="top" width="20%">
                                        <telerik:RadTreeView ID="tvViewIndex" runat="server" Height="548px" OnNodeClick="tvViewIndex_NodeClick1"
                                            Width="100%" OnClientNodeClicked="btnSave_ClientClick" CssClass="spanstyle">
                                        </telerik:RadTreeView>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                    <td id="c2" style="width: 80%;" valign="top">

                        <telerik:RadTabStrip ID="tabView" runat="server" MultiPageID="RadMultiPage1" OnClientTabSelecting="tabView_TabSelected"
                            OnTabClick="tabView_TabClick" ScrollChildren="True" SelectedIndex="0" Width="100%">
                            <%--BugID:47602 Added ClientTabSelected event to Start Loading symbol --%>
                        </telerik:RadTabStrip>
                        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" Width="100%">
                            <telerik:RadPageView ID="PageViewScan" runat="server" Height="580px">
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="PageViewResultFiles" runat="server" Height="580px">
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="PageViewResult" runat="server" Height="580px">
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="PageViewABIResults" runat="server" Height="580px">
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="PageViewSpirometryResults" runat="server" Height="580px">
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="PageViewMessageLog" runat="server" Height="580px">
                            </telerik:RadPageView>
                        </telerik:RadMultiPage>

                    </td>
                </tr>
                <tr style="height: 15%;">
                    <td width="100%" colspan="2" valign="top">
                        <asp:Panel ID="pnlTextbox" runat="server">
                            <table style="width: 100%; height: 117px;">
                                <tr>
                                    <td height="65%" width="15%">
                                        <asp:Label ID="lblProviderNotes" runat="server" Text="Provider Notes" Width="100%" CssClass="spanstyle"></asp:Label>
                                    </td>
                                    <td height="65%" width="35%">
                                        <DLC:DLC ID="DLC" runat="server" TextboxHeight="55px" TextboxWidth="400px" Value="PROVIDER NOTES" />
                                    </td>
                                    <td width="3%"></td>
                                    <td height="65%" width="15%">
                                        <asp:Label ID="lblMedicalAssistantNotes" runat="server" Text="Medical Asst Notes" Width="100%" CssClass="spanstyle"></asp:Label>
                                    </td>
                                    <td height="65%" width="32%">
                                         <telerik:RadTextBox ID="txtMedicalAssistantNotes" runat="server" DisabledStyle-CssClass="nonEditabletxtbox" EnabledStyle-CssClass="Editabletxtbox" Height="50px" TextMode="MultiLine" Width="100%">
                                             <%--BugID:46406--%>
                                             <DisabledStyle ForeColor="Black" Resize="None" />
                                             <InvalidStyle Resize="None" />
                                             <HoveredStyle Resize="None" />
                                             <ReadOnlyStyle Resize="None" />
                                             <EmptyMessageStyle Resize="None" />
                                             <ClientEvents OnKeyPress="txtMedicalAssistantNotes_OnKeyPress" />
                                             <FocusedStyle Resize="None" />
                                             <EnabledStyle Resize="None" />
                                         </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="35%" width="15%">
                                        <asp:Label ID="Label2" runat="server" Text="Provider Notes History"
                                            Width="100%" CssClass="spanstyle"></asp:Label>
                                    </td>
                                    <td height="35%" width="35%">
                                        <asp:TextBox ID="txtProvNoteshistory" runat="server" ReadOnly="true" style="background-color:#BFDBFF;width:440px;height:55px;resize: none;" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                      <td width="3%"></td>
                                    <td height="35%" width="15%">
                                        <asp:Label ID="Label3" runat="server" Text="Medical Asst Notes History"
                                            Width="100%" CssClass="spanstyle"></asp:Label>
                                    </td>
                                    <td height="35%" width="32%">
                                        <asp:TextBox TextMode="MultiLine"  id="txtMedNoteshistory"  runat="server" style="width:98.6%;height:50px;resize: none;" ReadOnly="true" CssClass="nonEditabletxtbox" ></asp:TextBox> 
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25%" width="10%">
                                        <asp:Label ID="Label1" runat="server" Text="Move To MA" CssClass="spanstyle"></asp:Label>
                                    </td>
                                    <td height="25%" width="35%">
                                        <telerik:RadComboBox ID="cboMoveToMA" Width="350px" Height="150px"
                                            runat="server" />
                                        <asp:CheckBox ID="chkShowAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkShowAll_CheckedChanged" onchange="{ sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart();}" Text="Show All" />
                                        </td>
                                      <td width="3%"></td>
                                    <td colspan="2">
                                        <asp:Button ID="btnFindAppointments" runat="server" OnClientClick="return OpenFindAllAppointments();"
                                            Text="Find All Appointments" Visible="false" Width="160px" CssClass="aspresizedbluebutton" />
                                        <asp:Button ID="btnpatientChart1" runat="server" OnClientClick="return btnpatientChart_Click();" Text="OpenPatientChart"
                                            Width="150px" Visible="false" CssClass="aspresizedbluebutton" />
                                        <asp:Button ID="btnePrescribe"
                                            runat="server" OnClientClick="return btnePrescribe_Click();" Text="ePrescribe" Width="100px" Visible="false" CssClass="aspresizedbluebutton"/>
                                        <asp:Button ID="btnEfax"
                                            runat="server"  Text="Send Fax" Visible="false" OnClientClick="funEFax();" Width="70px" CssClass="aspresizedbluebutton"/>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
              <tr style="height: 5%;">
                    <td colspan="2" width="100%">
                        <asp:Panel ID="pnlButton" runat="server">
                            <table style="width: 100%;">
                                <tr>
                                    <td width="3%">
                                        <telerik:RadButton ID="btnPrintEducatnMaterial" runat="server" Height="32px" Image-ImageUrl="~/Resources/images_info.jpg" Image-IsBackgroundImage="true" OnClick="btnPrintEducatnMaterial_Click" Visible="false" Width="32px" >
                                            <Image EnableImageButton="True" ImageUrl="~/Resources/images_info.jpg" />
                                            <%--BugID:48550 --%>
                                        </telerik:RadButton>
                                    </td>
                                    <td width="50%">
                                        <asp:CheckBox ID="chkPhyName" runat="server" onclick="EnableSave();" Width="100%" CssClass="Editabletxtbox" />
                                    </td>
                                     <td width="5%">
                                        <asp:Button ID="btnSave" runat="server" visible="false" OnClick="btnSave_Click" Text="Save" Width="100%"    CssClass="aspresizedgreenbutton"/>
                                    </td>
                                    <td width="10%">
                                        <telerik:RadButton ID="btnMoveToMa" AutoPostBack="false" runat="server" OnClick="btnMoveToMa_Click" OnClientClicked="btnMoveToMa_ClientClicked" Text="Save & Move To MA" Width="100%" Font-Size="13px" ButtonType="LinkButton" CssClass="bluebutton teleriknormalbuttonstyle"   >
                                        </telerik:RadButton>
                                    </td>
                                    <td width="2%"></td>
                                    <td width="15%">
                                        <telerik:RadButton ID="btnMoveToNextProcess" AutoPostBack="false" runat="server" OnClick="btnMoveToNextProcess_Click" OnClientClicked="btnMoveToNextProcess_ClientClicked" Text="Save & Move To Next Process" Width="100%" Font-Size="13px" ButtonType="LinkButton" CssClass="bluebutton teleriknormalbuttonstyle">
                                        </telerik:RadButton>
                                    </td>
                                    <%--<td width="15%">
                                        <telerik:RadButton ID="btnMovetoNextOrder" runat="server" OnClientClicked="ViewNextResult" Text="Reviewed and Move to Next Result" AutoPostBack="false" Width="100%">
                                        </telerik:RadButton>
                                    </td>--%>
                                   <td width="2%"></td>
                                    <td width="5%">
                                        <telerik:RadButton ID="btnClose" runat="server" OnClientClicked="btnClose_Clicked" Text="Close" Width="100%" Font-Size="13px" ButtonType="LinkButton" CssClass="redbutton teleriknormalbuttonstyle">
                                        </telerik:RadButton>
                                    </td>
                                    <td width="2%"></td>
                                    <td>
                                        <telerik:RadButton ID="btnPrint" runat="server" OnClick="btnPrint_Click" Text="Print" Width="100%" Visible="false" ButtonType="LinkButton" CssClass="greenbutton teleriknormalbuttonstyle">
                                        </telerik:RadButton>
                                    </td>
                                    <!--For Bug Id 56084-->
                                    
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hdnSave" runat="server" />
            <asp:HiddenField ID="hdnSelectedItem" runat="server" EnableViewState="false" />
            <asp:HiddenField ID="hdnMessageType" runat="server" />
            <asp:HiddenField ID="hdnEnableYesNo" runat="server" />
            <asp:HiddenField ID="hdnTab" runat="server" />
            <asp:HiddenField ID="hdnpath" runat="server" />
            <asp:HiddenField ID="hdnfileindexid" runat="server" />
            <asp:HiddenField ID="hdnFaxpath" runat="server" EnableViewState="false" />
            <asp:Button ID="btnMessageType" runat="server" Text="Button" Style="display: none"
                OnClientClick="btnClose_Clicked();" />
        </telerik:RadAjaxPanel>
    </form>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <script src="JScripts/jquery-2.1.3.js" type="text/javascript"></script>
        <script type="text/javascript">jQuery.noConflict();</script>
        <script src="JScripts/JSErrorMessage.js?version=<%=ConfigurationManager.AppSettings["VersionConfiguration"].ToString().Replace("Capella-","") %>" type="text/javascript"></script>
        <script src="JScripts/JSResult.js?version=<%=ConfigurationManager.AppSettings["VersionConfiguration"].ToString().Replace("Capella - ","") %>"
            type="text/javascript"></script>
        <script src="JScripts/JSViewResult.js?version=<%=ConfigurationManager.AppSettings["VersionConfiguration"].ToString().Replace("Capella - ","") %>"
            type="text/javascript"></script>
        <script src="JScripts/JSCustomDLC.js?version=<%=ConfigurationManager.AppSettings["VersionConfiguration"].ToString().Replace("Capella - ","") %>" type="text/javascript"></script>
        <script src="JScripts/JSAvoidRightClick.js?version=<%=ConfigurationManager.AppSettings["VersionConfiguration"].ToString().Replace("Capella - ","") %>"
            type="text/javascript"></script>
        <%-- <script src="JScripts/jquery-1.11.3.min.js" type="text/javascript"></script>--%>
        <script src="JScripts/bootstrap.min.js" type="text/javascript"></script>
    </asp:PlaceHolder>
</body>
</html>
