using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class Eligibility_Verification : BusinessBase<ulong>
    {
        #region Declarations

        //Payer_Name
        private string _sInsurance_Plan_Name = string.Empty;
        private string _sPayer_Name = string.Empty;
        private string _sPolicy_Holder_ID = string.Empty;
        private string _sGroupNumber = string.Empty;
        private double _dPCP_Copay = 0;
        private double _dSPC_Copay = 0;
        private double _dDeductible_For_Plan = 0;
        private double _dDeductible_Met_So_Far = 0;
        private double _dCoinsurance = 0;
        private DateTime _dtEffective_Date = DateTime.MinValue;
        private DateTime _dtTermination_Date = DateTime.MinValue;
        private ulong _iHuman_ID = 0;
        private string _sDemo_Note = string.Empty;
        private string _sCall_Ref_Number = string.Empty;
        private string _sCall_Rep_Name = string.Empty;
        private string _sEligibility_Verified_By = string.Empty;
        private DateTime _dtEligibility_Verified_Date = DateTime.MinValue;
        private string _sCreated_By = string.Empty;
        private string _sModified_By = string.Empty;
        private string _sEligibility_Type = string.Empty;
        private string _sHyperlink = string.Empty;
        private ulong _iInsurance_Plan_ID = 0;
        private int _iVersion = 0;
        private string _sComments = string.Empty;
        private string _sEligibility_Status = string.Empty;
        private int _File_Management_Index_ID = 0;
        //add
        private string _sGroup_Number = string.Empty;
        private DateTime _dtCreated_Date_And_Time = DateTime.MinValue;
        private DateTime _dtModified_Date_And_Time = DateTime.MinValue;
        private string _sEligibility_Check_Mode = string.Empty;
        private string _sResponse_Message = string.Empty;
        private string _sResponse_File_Location = string.Empty;
        private string _sInsurance_Type = string.Empty;
        private string _sRequested_By = string.Empty;
        private DateTime _sResponse_Received_On = DateTime.MinValue;
        private DateTime _dtRequested_For_From_Date = DateTime.MinValue;
        private DateTime _dtRequested_For_To_Date = DateTime.MinValue;
        private string _sService_Type_Code = string.Empty;
        private string _sService_Type = string.Empty;
        private string _sTRN02TraceNumber1 = string.Empty;

        // add new columns for CheckIn

        private string _sPlan_Type = string.Empty;
        private string _sPlan_Number = string.Empty;
        private string _sSubscriber_ID = string.Empty;
        private string _sOrganization = string.Empty;
        private string _sSubscriber_Name = string.Empty;
        private string _sPCP_Name = string.Empty;
        private string _sPCP_NPI = string.Empty;
        private string _sRelationship_to_Subscriber = string.Empty;
        private DateTime _dtPCP_Effective_Date = DateTime.MinValue;
        private string _sGroup_Name = string.Empty;
        private string _sIPA_Name = string.Empty;

        private double _sPCP_Office_Visit_InNet_Copay = 0;
        private double _sPCP_Office_Visit_OutNet_Copay = 0;
        private double _sPCP_Office_Visit_InNet_CoIns = 0;
        private double _sPCP_Office_Visit_OutNet_CoIns = 0;

        private double _sSpecialty_Office_Visit_InNet_Copay = 0;
        private double _sSpecialty_Office_Visit_OutNet_Copay = 0;
        private double _sSpecialty_Office_Visit_InNet_CoIns = 0;
        private double _sSpecialty_Office_Visit_OutNet_CoIns = 0;


        private double _sInj_Medication_InNet_Copay = 0;
        private double _sInj_Medication_OutNet_Copay = 0;
        private double _sInj_Medication_InNet_CoIns = 0;
        private double _sInj_Medication_OutNet_CoIns = 0;


        private double _sUrgent_Care_InNet_Copay = 0;
        private double _sUrgent_Care_OutNet_Copay = 0;
        private double _sUrgent_Care_InNet_CoIns = 0;
        private double _sUrgent_Care_OutNet_CoIns = 0;

        private string _sPCP_InNetwork_Copay_Message = string.Empty;
        private string _sPCP_OutNetwork_Copay_Message = string.Empty;

        private double _sInd_per_plan_InNet_Deductible = 0;
        private double _sInd_per_plan_OutNet_Deductible = 0;
        private double _sInd_per_plan_InNet_Out_of_Pocket = 0;
        private double _sInd_per_plan_OutNet_Out_of_Pocket = 0;

        private double _sInd_met_InNet_Deductible = 0;
        private double _sInd_met_OutNet_Deductible = 0;
        private double _sInd_met_InNet_Out_of_Pocket = 0;
        private double _sInd_met_OutNet_Out_of_Pocket = 0;

        private double _sFamily_per_plan_InNet_Deductible = 0;
        private double _sFamily_per_plan_OutNet_Deductible = 0;
        private double _sFamily_per_plan_InNet_Out_of_Pocket = 0;
        private double _sFamily_per_plan_OutNet_Out_of_Pocket = 0;

        private double _sFamily_met_InNet_Deductible = 0;
        private double _sFamily_met_OutNet_Deductible = 0;
        private double _sFamily_met_InNet_Out_of_Pocket = 0;
        private double _sFamily_met_OutNet_Out_of_Pocket = 0;

        private string _sDeductible_InNetwork_Message = string.Empty;
        private string _sDeductible_OutNetwork_Message = string.Empty;

        private ulong _iBatch_ID = 0;



        #endregion

        #region Constructors

        public Eligibility_Verification() { }

        #endregion

        #region HashCode override method Value

        public override int GetHashCode()
        {


            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_sInsurance_Plan_Name);
            sb.Append(_sPayer_Name);
            sb.Append(_sPolicy_Holder_ID);
            sb.Append(_sGroup_Number);
            sb.Append(_dPCP_Copay);
            sb.Append(_dSPC_Copay);
            sb.Append(_dDeductible_For_Plan);
            sb.Append(_dDeductible_Met_So_Far);
            sb.Append(_dCoinsurance);
            sb.Append(_dtEffective_Date);
            sb.Append(_dtTermination_Date);
            sb.Append(_iHuman_ID);
            sb.Append(_sDemo_Note);
            sb.Append(_sCall_Ref_Number);
            sb.Append(_sCall_Rep_Name);
            sb.Append(_sEligibility_Verified_By);
            sb.Append(_dtEligibility_Verified_Date);
            sb.Append(_sCreated_By);
            sb.Append(_sModified_By);
            sb.Append(_sEligibility_Type);
            sb.Append(_sHyperlink);
            sb.Append(_iInsurance_Plan_ID);
            sb.Append(_iVersion);
            sb.Append(_sComments);
            sb.Append(_sEligibility_Status);
            sb.Append(_File_Management_Index_ID);
            //add
            sb.Append(_dtCreated_Date_And_Time);
            sb.Append(_dtModified_Date_And_Time);
            sb.Append(_sEligibility_Check_Mode);
            sb.Append(_sResponse_Message);
            sb.Append(_sResponse_File_Location);
            sb.Append(_sInsurance_Type);
            sb.Append(_sRequested_By);
            sb.Append(_sResponse_Received_On);
            sb.Append(_dtRequested_For_From_Date);
            sb.Append(_dtRequested_For_To_Date);
            sb.Append(_sService_Type_Code);
            sb.Append(_sService_Type);
            sb.Append(_sTRN02TraceNumber1);

            // add new columns for CheckIn

            sb.Append(_sPlan_Type);
            sb.Append(_sPlan_Number);
            sb.Append(_sSubscriber_ID);
            sb.Append(_sOrganization);
            sb.Append(_sSubscriber_Name);
            sb.Append(_sPCP_Name);
            sb.Append(_sPCP_NPI);
            sb.Append(_sRelationship_to_Subscriber);
            sb.Append(_dtPCP_Effective_Date);
            sb.Append(_sGroup_Name);
            sb.Append(_sIPA_Name);
            sb.Append(_sPCP_Office_Visit_InNet_Copay);
            sb.Append(_sPCP_Office_Visit_OutNet_Copay);
            sb.Append(_sPCP_Office_Visit_InNet_CoIns);
            sb.Append(_sPCP_Office_Visit_OutNet_CoIns);
            sb.Append(_sSpecialty_Office_Visit_InNet_Copay);
            sb.Append(_sSpecialty_Office_Visit_OutNet_Copay);
            sb.Append(_sSpecialty_Office_Visit_InNet_CoIns);
            sb.Append(_sSpecialty_Office_Visit_OutNet_CoIns);
            sb.Append(_sInj_Medication_InNet_Copay);
            sb.Append(_sInj_Medication_OutNet_Copay);
            sb.Append(_sInj_Medication_InNet_CoIns);
            sb.Append(_sInj_Medication_OutNet_CoIns);
            sb.Append(_sUrgent_Care_InNet_Copay);
            sb.Append(_sUrgent_Care_OutNet_Copay);
            sb.Append(_sUrgent_Care_InNet_CoIns);
            sb.Append(_sUrgent_Care_OutNet_CoIns);
            sb.Append(_sPCP_InNetwork_Copay_Message);
            sb.Append(_sPCP_OutNetwork_Copay_Message);
            sb.Append(_sInd_per_plan_InNet_Deductible);
            sb.Append(_sInd_per_plan_OutNet_Deductible);
            sb.Append(_sInd_per_plan_InNet_Out_of_Pocket);
            sb.Append(_sInd_per_plan_OutNet_Out_of_Pocket);
            sb.Append(_sInd_met_InNet_Deductible);
            sb.Append(_sInd_met_OutNet_Deductible);
            sb.Append(_sInd_met_InNet_Out_of_Pocket);
            sb.Append(_sInd_met_OutNet_Out_of_Pocket);
            sb.Append(_sFamily_per_plan_InNet_Deductible);
            sb.Append(_sFamily_per_plan_OutNet_Deductible);
            sb.Append(_sFamily_per_plan_InNet_Out_of_Pocket);
            sb.Append(_sFamily_per_plan_OutNet_Out_of_Pocket);
            sb.Append(_sFamily_met_InNet_Deductible);
            sb.Append(_sFamily_met_OutNet_Deductible);
            sb.Append(_sFamily_met_InNet_Out_of_Pocket);
            sb.Append(_sFamily_met_OutNet_Out_of_Pocket);
            sb.Append(_sDeductible_InNetwork_Message);
            sb.Append(_sDeductible_OutNetwork_Message);
            sb.Append(_iBatch_ID);


            return sb.ToString().GetHashCode();
        }

        #endregion

        # region getset properties

        [DataMember]
        public virtual string Insurance_Plan_Name
        {
            get { return _sInsurance_Plan_Name; }
            set { _sInsurance_Plan_Name = value; }
        }

        [DataMember]
        public virtual string Payer_Name
        {
            get { return _sPayer_Name; }
            set { _sPayer_Name = value; }
        }

        [DataMember]
        public virtual string Policy_Holder_ID
        {
            get { return _sPolicy_Holder_ID; }
            set { _sPolicy_Holder_ID = value; }
        }
        [DataMember]
        public virtual string Group_Number
        {
            get { return _sGroup_Number; }
            set { _sGroup_Number = value; }
        }
        [DataMember]
        public virtual double PCP_Copay
        {
            get { return _dPCP_Copay; }
            set { _dPCP_Copay = value; }
        }
        [DataMember]
        public virtual double SPC_Copay
        {
            get { return _dSPC_Copay; }
            set { _dSPC_Copay = value; }
        }
        [DataMember]
        public virtual double Deductible_For_Plan
        {
            get { return _dDeductible_For_Plan; }
            set { _dDeductible_For_Plan = value; }
        }
        [DataMember]
        public virtual double Deductible_Met_So_Far
        {
            get { return _dDeductible_Met_So_Far; }
            set { _dDeductible_Met_So_Far = value; }
        }
        [DataMember]
        public virtual double Coinsurance
        {
            get { return _dCoinsurance; }
            set { _dCoinsurance = value; }
        }
        [DataMember]
        public virtual DateTime Effective_Date
        {
            get { return _dtEffective_Date; }
            set { _dtEffective_Date = value; }
        }
        [DataMember]
        public virtual DateTime Termination_Date
        {
            get { return _dtTermination_Date; }
            set { _dtTermination_Date = value; }
        }
        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _iHuman_ID; }
            set { _iHuman_ID = value; }
        }
        [DataMember]
        public virtual string Demo_Note
        {
            get { return _sDemo_Note; }
            set { _sDemo_Note = value; }
        }
        [DataMember]
        public virtual string Call_Ref_Number
        {
            get { return _sCall_Ref_Number; }
            set { _sCall_Ref_Number = value; }
        }
        [DataMember]
        public virtual string Call_Rep_Name
        {
            get { return _sCall_Rep_Name; }
            set { _sCall_Rep_Name = value; }
        }
        [DataMember]
        public virtual string Eligibility_Verified_By
        {
            get { return _sEligibility_Verified_By; }
            set { _sEligibility_Verified_By = value; }
        }
        [DataMember]
        public virtual DateTime Eligibility_Verified_Date
        {
            get { return _dtEligibility_Verified_Date; }
            set { _dtEligibility_Verified_Date = value; }
        }
        [DataMember]
        public virtual string Created_By
        {
            get { return _sCreated_By; }
            set { _sCreated_By = value; }
        }

        [DataMember]
        public virtual string Modified_By
        {
            get { return _sModified_By; }
            set { _sModified_By = value; }
        }

        [DataMember]
        public virtual string Eligibility_Type
        {
            get { return _sEligibility_Type; }
            set { _sEligibility_Type = value; }
        }
        [DataMember]
        public virtual string Hyperlink
        {
            get { return _sHyperlink; }
            set { _sHyperlink = value; }
        }
        [DataMember]
        public virtual ulong Insurance_Plan_ID
        {
            get { return _iInsurance_Plan_ID; }
            set { _iInsurance_Plan_ID = value; }
        }
        [DataMember]
        public virtual int Version
        {
            get { return _iVersion; }
            set { _iVersion = value; }
        }

        [DataMember]
        public virtual string Comments
        {
            get { return _sComments; }
            set { _sComments = value; }
        }

        [DataMember]
        public virtual string Eligibility_Status
        {
            get { return _sEligibility_Status; }
            set { _sEligibility_Status = value; }
        }
        [DataMember]
        public virtual int File_Management_Index_ID
        {
            get { return _File_Management_Index_ID; }
            set { _File_Management_Index_ID = value; }
        }
        //added

        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _dtCreated_Date_And_Time; }
            set { _dtCreated_Date_And_Time = value; }
        }
        [DataMember]
        public virtual DateTime Modified_Date_And_Time
        {
            get { return _dtModified_Date_And_Time; }
            set { _dtModified_Date_And_Time = value; }
        }
        [DataMember]
        public virtual string Eligibility_Check_Mode
        {
            get { return _sEligibility_Check_Mode; }
            set { _sEligibility_Check_Mode = value; }
        }
        [DataMember]
        public virtual string Response_Message
        {
            get { return _sResponse_Message; }
            set { _sResponse_Message = value; }
        }
        [DataMember]
        public virtual string Response_File_Location
        {
            get { return _sResponse_File_Location; }
            set { _sResponse_File_Location = value; }
        }
        [DataMember]
        public virtual string Insurance_Type
        {
            get { return _sInsurance_Type; }
            set { _sInsurance_Type = value; }
        }
        [DataMember]
        public virtual string Requested_By
        {
            get { return _sRequested_By; }
            set { _sRequested_By = value; }
        }
        [DataMember]
        public virtual DateTime Response_Received_On
        {
            get { return _sResponse_Received_On; }
            set { _sResponse_Received_On = value; }
        }
        [DataMember]
        public virtual DateTime Requested_For_From_Date
        {
            get { return _dtRequested_For_From_Date; }
            set { _dtRequested_For_From_Date = value; }
        }
        [DataMember]
        public virtual DateTime Requested_For_To_Date
        {
            get { return _dtRequested_For_To_Date; }
            set { _dtRequested_For_To_Date = value; }
        }
        [DataMember]
        public virtual string Service_Type_Code
        {
            get { return _sService_Type_Code; }
            set { _sService_Type_Code = value; }
        }
        [DataMember]
        public virtual string Service_Type
        {
            get { return _sService_Type; }
            set { _sService_Type = value; }
        }
        [DataMember]
        public virtual string TRN02TraceNumber1
        {
            get { return _sTRN02TraceNumber1; }
            set { _sTRN02TraceNumber1 = value; }
        }


        //add new columns for CheckIn

        [DataMember]
        public virtual string Plan_Type
        {
            get { return _sPlan_Type; }
            set { _sPlan_Type = value; }
        }
        [DataMember]
        public virtual string Plan_Number
        {
            get { return _sPlan_Number; }
            set { _sPlan_Number = value; }
        }
        [DataMember]
        public virtual string Subscriber_ID
        {
            get { return _sSubscriber_ID; }
            set { _sSubscriber_ID = value; }
        }
        [DataMember]
        public virtual string Organization
        {
            get { return _sOrganization; }
            set { _sOrganization = value; }
        }
        [DataMember]
        public virtual string Subscriber_Name
        {
            get { return _sSubscriber_Name; }
            set { _sSubscriber_Name = value; }
        }
        [DataMember]
        public virtual string PCP_Name
        {
            get { return _sPCP_Name; }
            set { _sPCP_Name = value; }
        }
        [DataMember]
        public virtual string PCP_NPI
        {
            get { return _sPCP_NPI; }
            set { _sPCP_NPI = value; }
        }
        [DataMember]
        public virtual string Relationship_to_Subscriber
        {
            get { return _sRelationship_to_Subscriber; }
            set { _sRelationship_to_Subscriber = value; }
        }
        [DataMember]
        public virtual DateTime PCP_Effective_Date
        {
            get { return _dtPCP_Effective_Date; }
            set { _dtPCP_Effective_Date = value; }
        }
        [DataMember]
        public virtual string Group_Name
        {
            get { return _sGroup_Name; }
            set { _sGroup_Name = value; }
        }
        [DataMember]
        public virtual string IPA_Name
        {
            get { return _sIPA_Name; }
            set { _sIPA_Name = value; }
        }
        [DataMember]
        public virtual double PCP_Office_Visit_InNet_Copay
        {
            get { return _sPCP_Office_Visit_InNet_Copay; }
            set { _sPCP_Office_Visit_InNet_Copay = value; }
        }
        [DataMember]
        public virtual double PCP_Office_Visit_OutNet_Copay
        {
            get { return _sPCP_Office_Visit_OutNet_Copay; }
            set { _sPCP_Office_Visit_OutNet_Copay = value; }
        }
        [DataMember]
        public virtual double PCP_Office_Visit_InNet_CoIns
        {
            get { return _sPCP_Office_Visit_InNet_CoIns; }
            set { _sPCP_Office_Visit_InNet_CoIns = value; }
        }
        [DataMember]
        public virtual double PCP_Office_Visit_OutNet_CoIns
        {
            get { return _sPCP_Office_Visit_OutNet_CoIns; }
            set { _sPCP_Office_Visit_OutNet_CoIns = value; }
        }
        [DataMember]
        public virtual double Specialty_Office_Visit_InNet_Copay
        {
            get { return _sSpecialty_Office_Visit_InNet_Copay; }
            set { _sSpecialty_Office_Visit_InNet_Copay = value; }
        }
        [DataMember]
        public virtual double Specialty_Office_Visit_OutNet_Copay
        {
            get { return _sSpecialty_Office_Visit_OutNet_Copay; }
            set { _sSpecialty_Office_Visit_OutNet_Copay = value; }
        }
        [DataMember]
        public virtual double Specialty_Office_Visit_InNet_CoIns
        {
            get { return _sSpecialty_Office_Visit_InNet_CoIns; }
            set { _sSpecialty_Office_Visit_InNet_CoIns = value; }
        }
        [DataMember]
        public virtual double Specialty_Office_Visit_OutNet_CoIns
        {
            get { return _sSpecialty_Office_Visit_OutNet_CoIns; }
            set { _sSpecialty_Office_Visit_OutNet_CoIns = value; }
        }
        [DataMember]
        public virtual double Inj_Medication_InNet_Copay
        {
            get { return _sInj_Medication_InNet_Copay; }
            set { _sInj_Medication_InNet_Copay = value; }
        }
        [DataMember]
        public virtual double Inj_Medication_OutNet_Copay
        {
            get { return _sInj_Medication_OutNet_Copay; }
            set { _sInj_Medication_OutNet_Copay = value; }
        }
        [DataMember]
        public virtual double Inj_Medication_InNet_CoIns
        {
            get { return _sInj_Medication_InNet_CoIns; }
            set { _sInj_Medication_InNet_CoIns = value; }
        }
        [DataMember]
        public virtual double Inj_Medication_OutNet_CoIns
        {
            get { return _sInj_Medication_OutNet_CoIns; }
            set { _sInj_Medication_OutNet_CoIns = value; }
        }
        [DataMember]
        public virtual double Urgent_Care_InNet_Copay
        {
            get { return _sUrgent_Care_InNet_Copay; }
            set { _sUrgent_Care_InNet_Copay = value; }
        }
        [DataMember]
        public virtual double Urgent_Care_OutNet_Copay
        {
            get { return _sUrgent_Care_OutNet_Copay; }
            set { _sUrgent_Care_OutNet_Copay = value; }
        }
        [DataMember]
        public virtual double Urgent_Care_InNet_CoIns
        {
            get { return _sUrgent_Care_InNet_CoIns; }
            set { _sUrgent_Care_InNet_CoIns = value; }
        }
        [DataMember]
        public virtual double Urgent_Care_OutNet_CoIns
        {
            get { return _sUrgent_Care_OutNet_CoIns; }
            set { _sUrgent_Care_OutNet_CoIns = value; }
        }
        [DataMember]
        public virtual string PCP_InNetwork_Copay_Message
        {
            get { return _sPCP_InNetwork_Copay_Message; }
            set { _sPCP_InNetwork_Copay_Message = value; }
        }
        [DataMember]
        public virtual string PCP_OutNetwork_Copay_Message
        {
            get { return _sPCP_OutNetwork_Copay_Message; }
            set { _sPCP_OutNetwork_Copay_Message = value; }
        }
        [DataMember]
        public virtual double Ind_per_plan_InNet_Deductible
        {
            get { return _sInd_per_plan_InNet_Deductible; }
            set { _sInd_per_plan_InNet_Deductible = value; }
        }
        [DataMember]
        public virtual double Ind_per_plan_OutNet_Deductible
        {
            get { return _sInd_per_plan_OutNet_Deductible; }
            set { _sInd_per_plan_OutNet_Deductible = value; }
        }
        [DataMember]
        public virtual double Ind_per_plan_InNet_Out_of_Pocket
        {
            get { return _sInd_per_plan_InNet_Out_of_Pocket; }
            set { _sInd_per_plan_InNet_Out_of_Pocket = value; }
        }
        [DataMember]
        public virtual double Ind_per_plan_OutNet_Out_of_Pocket
        {
            get { return _sInd_per_plan_OutNet_Out_of_Pocket; }
            set { _sInd_per_plan_OutNet_Out_of_Pocket = value; }
        }
        [DataMember]
        public virtual double Ind_met_InNet_Deductible
        {
            get { return _sInd_met_InNet_Deductible; }
            set { _sInd_met_InNet_Deductible = value; }
        }
        [DataMember]
        public virtual double Ind_met_OutNet_Deductible
        {
            get { return _sInd_met_OutNet_Deductible; }
            set { _sInd_met_OutNet_Deductible = value; }
        }
        [DataMember]
        public virtual double Ind_met_InNet_Out_of_Pocket
        {
            get { return _sInd_met_InNet_Out_of_Pocket; }
            set { _sInd_met_InNet_Out_of_Pocket = value; }
        }
        [DataMember]
        public virtual double Ind_met_OutNet_Out_of_Pocket
        {
            get { return _sInd_met_OutNet_Out_of_Pocket; }
            set { _sInd_met_OutNet_Out_of_Pocket = value; }
        }
        [DataMember]
        public virtual double Family_per_plan_InNet_Deductible
        {
            get { return _sFamily_per_plan_InNet_Deductible; }
            set { _sFamily_per_plan_InNet_Deductible = value; }
        }
        [DataMember]
        public virtual double Family_per_plan_OutNet_Deductible
        {
            get { return _sFamily_per_plan_OutNet_Deductible; }
            set { _sFamily_per_plan_OutNet_Deductible = value; }
        }
        [DataMember]
        public virtual double Family_per_plan_InNet_Out_of_Pocket
        {
            get { return _sFamily_per_plan_InNet_Out_of_Pocket; }
            set { _sFamily_per_plan_InNet_Out_of_Pocket = value; }
        }
        [DataMember]
        public virtual double Family_per_plan_OutNet_Out_of_Pocket
        {
            get { return _sFamily_per_plan_OutNet_Out_of_Pocket; }
            set { _sFamily_per_plan_OutNet_Out_of_Pocket = value; }
        }
        [DataMember]
        public virtual double Family_met_InNet_Deductible
        {
            get { return _sFamily_met_InNet_Deductible; }
            set { _sFamily_met_InNet_Deductible = value; }
        }
        [DataMember]
        public virtual double Family_met_OutNet_Deductible
        {
            get { return _sFamily_met_OutNet_Deductible; }
            set { _sFamily_met_OutNet_Deductible = value; }
        }
        [DataMember]
        public virtual double Family_met_InNet_Out_of_Pocket
        {
            get { return _sFamily_met_InNet_Out_of_Pocket; }
            set { _sFamily_met_InNet_Out_of_Pocket = value; }
        }

        [DataMember]
        public virtual double Family_met_OutNet_Out_of_Pocket
        {
            get { return _sFamily_met_OutNet_Out_of_Pocket; }
            set { _sFamily_met_OutNet_Out_of_Pocket = value; }
        }


        [DataMember]
        public virtual string Deductible_InNetwork_Message
        {
            get { return _sDeductible_InNetwork_Message; }
            set { _sDeductible_InNetwork_Message = value; }
        }
        [DataMember]
        public virtual string Deductible_OutNetwork_Message
        {
            get { return _sDeductible_OutNetwork_Message; }
            set { _sDeductible_OutNetwork_Message = value; }
        }
        [DataMember]
        public virtual ulong Batch_ID
        {
            get { return _iBatch_ID; }
            set { _iBatch_ID = value; }
        }

        #endregion

    }
}
