using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class ActivityLog : BusinessBase<ulong>
    {

        #region Declarations
        private ulong _Human_ID = 0;
        private ulong _Encounter_ID = 0;
        private string _Activity_Type = string.Empty;
        private DateTime _Activity_Date_And_Time = DateTime.MinValue;
        private string _Sent_To = string.Empty;
        private string _Subject = string.Empty;
        private string _Message = string.Empty;
        private string _From_Address = string.Empty;
        private string _Role = string.Empty;
        private string _Encrypted_Message = string.Empty;
        private string _Activity_By = string.Empty;
        private string _Fax_Sender_Name = string.Empty;
        private string _Fax_Recipient_Name = string.Empty;
        private string _Fax_Sender_Company = string.Empty;
        private string _Fax_Recipient_Company = string.Empty;
        private string _Fax_Sender_Number = string.Empty;
        private string _Fax_Recipient_Number = string.Empty;
        private string _Fax_File_Path = string.Empty;
        private string _Fax_Status = string.Empty;
        private string _Fax_Recipient_Category = string.Empty;
        private string _Fax_Priority = string.Empty;
        private string _Fax_Cover_Page_Template_Name = string.Empty;
        private string _Error_Description = string.Empty;
        private string _Is_Pdf_Moved = "N";
        private int _Group_ID = 0;
        private string _Fax_Sent_File_Path = string.Empty;
        

        #endregion
        #region Constructors

        public ActivityLog() { }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Human_ID);
            sb.Append(_Encounter_ID);
            sb.Append(_Activity_Type);
            sb.Append(_Activity_Date_And_Time);
            sb.Append(_Sent_To);
            sb.Append(_Subject);
            sb.Append(_Message);
            sb.Append(_From_Address);
            sb.Append(_Role);
            sb.Append(_Encrypted_Message);
            sb.Append(_Activity_By);

            sb.Append(_Fax_Sender_Name);
            sb.Append(_Fax_Recipient_Name);
            sb.Append(_Fax_Sender_Company);
            sb.Append(_Fax_Recipient_Company);
            sb.Append(_Fax_Sender_Number);
            sb.Append(_Fax_Recipient_Number);
            sb.Append(_Fax_File_Path);
            sb.Append(_Fax_Status);
            sb.Append(_Fax_Recipient_Category);
            sb.Append(_Fax_Priority);
            sb.Append(_Fax_Cover_Page_Template_Name);
            sb.Append(_Error_Description);
            sb.Append(_Is_Pdf_Moved);
            sb.Append(_Group_ID);
            sb.Append(_Fax_Sent_File_Path);
            return sb.ToString().GetHashCode();
        }
        #endregion


        #region Properties
        [DataMember]
        public virtual string Activity_By
        {
            get { return _Activity_By; }
            set
            {
                _Activity_By = value;
            }
        }
        [DataMember]
        public virtual string Encrypted_Message
        {
            get { return _Encrypted_Message; }
            set
            {
                _Encrypted_Message = value;
            }
        }
        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set
            {
                _Human_ID = value;
            }
        }
        [DataMember]
        public virtual ulong Encounter_ID
        {
            get { return _Encounter_ID; }
            set
            {
                _Encounter_ID = value;
            }
        }
        [DataMember]
        public virtual string Activity_Type
        {
            get { return _Activity_Type; }
            set
            {
                _Activity_Type = value;
            }
        }
         [DataMember]
        public virtual DateTime Activity_Date_And_Time
        {
            get { return _Activity_Date_And_Time; }
            set
            {
                _Activity_Date_And_Time = value;
            }
        }
        [DataMember]
        public virtual string Sent_To
        {
            get { return _Sent_To; }
            set
            {
                _Sent_To = value;
            }
        }


        [DataMember]
        public virtual string Subject
        {
            get { return _Subject; }
            set
            {
                _Subject = value;
            }
        }

        [DataMember]
        public virtual string Message
        {
            get { return _Message; }
            set
            {
                _Message = value;
            }
        }

        [DataMember]
        public virtual string From_Address
        {
            get { return _From_Address; }
            set
            {
                _From_Address = value;
            }
        }
        [DataMember]
        public virtual string Role
        {
            get { return _Role; }
            set
            {
                _Role = value;
            }
        }
        [DataMember]
        public virtual string Fax_Sender_Name
        {
            get { return _Fax_Sender_Name; }
            set
            {
                _Fax_Sender_Name = value;
            }
        }
        [DataMember]
        public virtual string Fax_Recipient_Name
        {
            get { return _Fax_Recipient_Name; }
            set
            {
                _Fax_Recipient_Name = value;
            }
        }
        [DataMember]
        public virtual string Fax_Sender_Company
        {
            get { return _Fax_Sender_Company; }
            set
            {
                _Fax_Sender_Company = value;
            }
        }
        [DataMember]
        public virtual string Fax_Recipient_Company
        {
            get { return _Fax_Recipient_Company; }
            set
            {
                _Fax_Recipient_Company = value;
            }
        }
        [DataMember]
        public virtual string Fax_Sender_Number
        {
            get { return _Fax_Sender_Number; }
            set
            {
                _Fax_Sender_Number = value;
            }
        }
        [DataMember]
        public virtual string Fax_Recipient_Number
        {
            get { return _Fax_Recipient_Number; }
            set
            {
                _Fax_Recipient_Number = value;
            }
        }
        [DataMember]
        public virtual string Fax_File_Path
        {
            get { return _Fax_File_Path; }
            set
            {
                _Fax_File_Path = value;
            }
        }
        [DataMember]
        public virtual string Fax_Status
        {
            get { return _Fax_Status; }
            set
            {
                _Fax_Status = value;
            }
        }
        [DataMember]
        public virtual string Fax_Priority
        {
            get { return _Fax_Priority; }
            set
            {
                _Fax_Priority = value;
            }
        }
        [DataMember]
        public virtual string Fax_Recipient_Category
        {
            get { return _Fax_Recipient_Category; }
            set
            {
                _Fax_Recipient_Category = value;
            }
        }
        [DataMember]
        public virtual string Fax_Cover_Page_Template_Name
        {
            get { return _Fax_Cover_Page_Template_Name; }
            set
            {
                _Fax_Cover_Page_Template_Name = value;
            }
        }
        [DataMember]
        public virtual string Error_Description
        {
            get { return _Error_Description; }
            set
            {
                _Error_Description = value;
            }
        }
        [DataMember]
        public virtual string Is_Pdf_Moved
        {
            get { return _Is_Pdf_Moved; }
            set
            {
                _Is_Pdf_Moved = value;
            }
        }
        [DataMember]
        public virtual int Group_ID
        {
            get { return _Group_ID; }
            set
            {
                _Group_ID = value;
            }
        }
        [DataMember]
        public virtual string Fax_Sent_File_Path
        {
            get { return _Fax_Sent_File_Path; }
            set
            {
                _Fax_Sent_File_Path = value;
            }
        }
        
        #endregion
    }

}
