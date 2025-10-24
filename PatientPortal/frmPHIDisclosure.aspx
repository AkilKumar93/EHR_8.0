<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPHIDisclosure.aspx.cs" Inherits="Acurus.Capella.PatientPortal.frmPHIDisclosure" EnableEventValidation="false" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/font-awesome.css" rel="stylesheet" type="text/css" />
    <link href="CSS/style.css" rel="stylesheet" type="text/css" />
     <link href="~/CSS/CommonStyle.css" rel="Stylesheet" type="text/css" />
    <link href="~/CSS/jquery-ui.css" rel="stylesheet" />
      <link href="~/CSS/bootstrap.min.css" rel="stylesheet" />
    
    
    <style>
        fieldset, legend {
            all: revert;
        }
        .panlstyle > fieldset {
            height: 200px;
        }
        #pnlInformationRestrictionDetails > fieldset {
            height:540px;
        }
        .style2
        {
            width: 400px;
        }
        .style3
        {
            width: 350px
        }
        .style4
        {
            width: 370px;
        }
        .style5
        {
            width: 56px;
        }
         .Displaynone
        {
        	display:none
        }
        .chkspanstyle > label {
    font-family: "Helvetica Neue",Helvetica,Arial,sans-serif !important;
    font-size: 13px !important;
    font-weight: normal;
    color: black !important;
}
        #tblEncounterDetails > tbody > tr > td > span > label {
            font-family: "Helvetica Neue",Helvetica,Arial,sans-serif !important;
            font-size: 13px !important;
            font-weight: normal;
            color: black !important;
        }
    
    </style>
    <title>Request for Restrictions of PHI Use and Disclosure</title>
</head>
<body onload=" { sessionStorage.setItem('StartLoading', 'true'); StartLoadFromPatChart(); }">
     <div id='dvdialogPHIDisclosure' style='min-height: 65px !important; width: auto; max-height: none; height: auto; display: none;'>
        <p style='font-family: Verdana,Arial,sans-serif; font-size: 12.5px;'>There are unsaved changes.Do you want to save them?</p>
    </div>
    <form id="frmPHIDisclosure" runat="server">
        <div>
            <label id="lblSubScreeenPatientStrip" class="pnlBarGroup"></label>
            <asp:Panel ID="pnlInformationRestrictionDetails" GroupingText="Information Restriction Details" runat="server" CssClass="LabelStyleBold">
                <label id="lblMain" class="MandLabelstyle">I hereby request that the Organization restrict the [check one box]:</label><br />
                <asp:RadioButton GroupName ="RadioGroups" Text="Use or Disclosure of All information" runat="server" ID="chkAll" CssClass="chkspanstyle" onclick="CheckedChange(this);EnableSave();" /><br />
                <asp:RadioButton GroupName ="RadioGroups" Text="Use and Disclosure of my protected health information described below:" runat="server" ID="chkSelected" CssClass="chkspanstyle" onclick="CheckedChange(this);EnableSave();" />

                <asp:Panel ID="pnlEncounterDetails" runat="server" GroupingText="Encounter Detials" CssClass="panlstyle">
                    <table style="width: 100%;" id="tblEncounterDetails">
                       <tr>
                            <td class="style3">
                                <asp:CheckBox ID="chkReasonOfVisit" runat="server" Text="Reason Of Visit" CssClass="Editabletxtbox" onclick="EnableSave();"/>
                                <asp:CheckBox ID="chkVitals" runat="server" Text="Vitals" CssClass="Editabletxtbox" onclick="EnableSave();"/>
                            </td>
                            <td class="style2">
                                <asp:CheckBox ID="chkClinicalInstruction" runat="server" Text="Clinical Instruction" CssClass="Editabletxtbox" onclick="EnableSave();"/>
                            </td>
                            <td class="style4">
                                <asp:CheckBox ID="chkImmunization" runat="server" Text="Immunizations" CssClass="Editabletxtbox" onclick="EnableSave();"/>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkMentalStatus" runat="server" Text="Mental Status" CssClass="Editabletxtbox" onclick="EnableSave();"/>

                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                <asp:CheckBox ID="chkCarePlan" runat="server" Text="Care Plan" CssClass="Editabletxtbox" onclick="EnableSave();"/>
                            </td>
                            <td class="style2">
                                <asp:CheckBox ID="chkLaboratoryTest" runat="server" Text="Laboratory Test(s)"  CssClass="Editabletxtbox" onclick="EnableSave();"/>
                                <asp:CheckBox ID="chkSmokingStatus" runat="server" Text="Smoking Status" CssClass="Editabletxtbox" onclick="EnableSave();"/>
                            </td>
                            <td class="style4">
                                <asp:CheckBox ID="chkAllergies" runat="server" Text="Allergy" CssClass="Editabletxtbox" onclick="EnableSave();"/>
                            </td>
                              <td>
                                <asp:CheckBox ID="chkFunctionalStatus" runat="server" Text="Functional Status" CssClass="Editabletxtbox" onclick="EnableSave();"/>

                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                <asp:CheckBox ID="chkProcedures" runat="server" Text="Procedure(s)" CssClass="Editabletxtbox" onclick="EnableSave();"/>
                            </td>
                            <td class="style2">
                                <asp:CheckBox ID="chkLaboratoryResultValues" runat="server" Text="Laboratory Values/Results" CssClass="Editabletxtbox" onclick="EnableSave();"/>
                            </td>
                            <td class="style4">
                                 <asp:CheckBox ID="chkEncounter" runat="server" Text="Encounter" CssClass="Editabletxtbox" onclick="EnableSave();"/>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkGoals" runat="server" Text="Goals" CssClass="Editabletxtbox" onclick="EnableSave();"/>

                            </td>
                        </tr>
                     
                        <tr>
                            <td class="style3">
                               <asp:CheckBox ID="chkChiefComplaints" runat="server" Text="Assessment" CssClass="Editabletxtbox" onclick="EnableSave();"/>
                            </td>
                            <td class="style2">
                                <asp:CheckBox ID="chkMedication" runat="server" Text="Medication" CssClass="Editabletxtbox" onclick="EnableSave();"/>
                            </td>
                            <td class="style4">
                                <asp:CheckBox ID="chkMedicationAdministrative" runat="server" Text="Medications Administered During visit" CssClass="Editabletxtbox" onclick="EnableSave();"/>
                            </td>
                             <td>
                                <asp:CheckBox ID="chkTreatmentPlan" runat="server" Text="Treatment Plan" CssClass="Editabletxtbox" onclick="EnableSave();"/>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                <asp:CheckBox ID="chkProblemList" runat="server" Text="Problem List" CssClass="Editabletxtbox" onclick="EnableSave();"/>
                            </td>
                            <td class="style2">
                                <asp:CheckBox ID="chkReasonforReferral" runat="server" Text="Reason for Referral" CssClass="Editabletxtbox" onclick="EnableSave();"/>
                            
                            </td>
                            <td class="style4">
                                 <asp:CheckBox ID="chkImplant" runat="server" Text="Implants" CssClass="Editabletxtbox" onclick="EnableSave();"/>
                                 <asp:CheckBox ID="chkFutureAppointment" runat="server" CssClass="Displaynone" 
                                    Text="Future Appointment" onclick="EnableSave();" />
                            </td>
                            
                             <td>
                                <asp:CheckBox ID="chkHealthConcern" runat="server" Text="Health Concern" CssClass="Editabletxtbox" onclick="EnableSave();"/>
                            </td>                            
                        </tr>
                          <tr>
                            <td class="style3">
                                <asp:CheckBox ID="chkLabTest" runat="server" Text="Lab Test" CssClass="Editabletxtbox" onclick="EnableSave();"/>
                            </td>
                            <td class="style2">
                                <asp:CheckBox ID="chkLab" runat="server" Text="Laboratory Information" CssClass="Editabletxtbox" onclick="EnableSave();"/>
                            </td>
                        </tr>
                           <tr>
                            <td class="style3">
                                <asp:CheckBox ID="chkDiagnosticTestPending" runat="server" Text="Diagnostics Tests Pending" CssClass="Editabletxtbox" onclick="EnableSave();" />
                            </td>
                            <td class="style2">
                                <asp:CheckBox ID="chkFutureScheduledTest" runat="server" Text="Future Scheduled Tests" CssClass="Editabletxtbox" onclick="EnableSave();"/>
                            </td>
                            <td class="style4">
                                <asp:CheckBox ID="chkPatientAids" runat="server" Text="Patient Decision Aids" CssClass="Editabletxtbox" onclick="EnableSave();" />
                            </td>
                            <td>
                                <asp:CheckBox ID="chkPayer" runat="server" Text="Payer" CssClass="Editabletxtbox" onclick="EnableSave();"/>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                <label id="lblContent" class="spanstyle">I understand that the Organization is not required to agree to my request to restrict the use or disclosure of my protected health information, except where:</label>
            <ul class="spanstyle">
                <li class="spanstyle">
                    The disclosure would be to my health plan (including Medicare and other governmentpayors) in order to assist in the payment process or in the health care operation of eitherMedical Group or the 
                    health plan and (2) the protected health information relates to anitem or service for which the Organization has been paid in full by me or someone (e.g.,a family member or friend) acting on my 
                    behalf; or

                </li>
                <li class="spanstyle">
                    The disclosure involves the release of information to assist family, friends, or othersinvolved in my care or in payment for my care, or notifications to these individuals or topublic authorities
                    regarding my identity or status as a patient.
            </li>
             </ul >
                <p class="spanstyle">
                    If, however, the Organization agrees to a restriction, I understand that it may still use and disclose my protected health information in an emergency situation or as otherwise permitted or required by law.
                    If the Organization agrees to my request to restrict the use and disclosure of my protected health information in the manner described above, I understand that this agreement may be terminated if:
                </p>
                <ul class="spanstyle">
                    <li class="spanstyle">
                        I request, or agree to, the termination in writing
                    </li>
                    <li class="spanstyle">
                        I orally agree to the termination and the oral agreement is documented
                    </li>
                    <li class="spanstyle">
                        The Organization informs me that it is terminating this agreement. In that case, thetermination will be effective for my protected health information created by the Organization after I receive notification of the termination.
                    </li>
                </ul>
            </asp:Panel>
            <table style="width: 100%;margin-top: 5px;">
                <tbody>
           <tr>
            <td style="width: 89%;"><asp:CheckBox ID="chkSign" Text="" runat="server" onclick="EnableSave('N');" />
            <label id="lblSignedText" class="MandLabelstyle"></label></td>
            <td><input type="button" id="btnSave"  class="aspgreenbutton" onclick="return btnSaveClick();"  value="Save"/>
            <input type="button" id="btnClose" class="aspredbutton" style="width:80px;" onclick="return CloseClick();" value="Close"/></td>
               </tr>
                    </tbody>
                 </table>
            
        </div>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server" EnableViewState="false">
           <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
            </Scripts>
    </telerik:RadScriptManager>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
    <script src="JScripts/jquery-2.1.3.js" type="text/javascript"></script>
    <script src="JScripts/JSModalWindow.js?version=<%=ConfigurationManager.AppSettings["VersionConfiguration"].ToString().Replace("Capella - ","") %>" type="text/javascript"></script>
    <script src="JScripts/JSPHIDisclosure.js?version=<%=ConfigurationManager.AppSettings["VersionConfiguration"].ToString().Replace("Capella - ","") %>" type="text/javascript"></script>
    <script src="JScripts/JSErrorMessage.js?version=<%=ConfigurationManager.AppSettings["VersionConfiguration"].ToString().Replace("Capella - ","") %>" type="text/javascript"></script>
    <script src="JScripts/JSAvoidRightClick.js?version=<%=ConfigurationManager.AppSettings["VersionConfiguration"].ToString().Replace("Capella - ","") %>" type="text/javascript"></script>
   <script>
       document.getElementById("lblSubScreeenPatientStrip").innerText = top?.window?.document.getElementById("lblPatientStrip").innerText;
   </script>
            <script>document.write("<script src='JScripts/jquery-ui.min1.10.2.js?version=" + sessionStorage.getItem("ScriptVersion") + "'><\/script>")</script>
            <script src="JScripts/bootstrap.min.js" type="text/javascript"></script>
        </asp:PlaceHolder>
    </form>
</body>
</html>
