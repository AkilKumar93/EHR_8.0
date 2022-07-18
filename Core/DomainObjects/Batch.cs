using System;
using System.Runtime.Serialization;


namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class Batch : BusinessBase<ulong>
    {
        #region Declarations

        private string _DOOS = string.Empty;
        private string _Batch_Name = string.Empty;
        private string _Doc_Type = string.Empty;
        private string _Doc_Sub_Type = string.Empty;
        private string _Scan_File_Path_Name = string.Empty;
        private string _Scan_File_Name = string.Empty;
        private int _Num_Imgs_Exp = 0;
        private int _Num_Images_Rcvd = 0;
        private int _Demos_Enc_PPLine_Rcvd = 0;
        private int _Num_of_Checks_Exp = 0;
        private int _Num_of_Checks_Rcvd = 0;
        private decimal _Batch_Total_Exp = 0;
        private decimal _Batch_Total_Rcvd = 0;
        private DateTime _Date_of_Deposit = DateTime.MinValue;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version = 0;
        private string _Facility_Name = string.Empty;
        private DateTime _Scan_File_Recvd_Date = DateTime.MinValue;
        private string _Misc_File_Path_Name = string.Empty;
        private string _Misc_File_Name = string.Empty;
        private int _Num_Encounters_Exp = 0;
        private DateTime _DOS = DateTime.MinValue;
        private string _Input_Mode = string.Empty;
        private int _Rend_Prov_ID = 0;
        //private string _Issues = string.Empty;
        //private string _Feedback = string.Empty;
        private int _Comments_Message_ID = 0;
        private int _Client_Response_Message_ID = 0;
        private int _Total_No_Of_Demos = 0;
        private ulong _Scan_ID = 0;


        #endregion

        #region Constructors

        public Batch() { }

        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Batch_Name);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            sb.Append(_Doc_Type);
            sb.Append(_Doc_Sub_Type);
            sb.Append(_DOOS);
            sb.Append(_Facility_Name);
            sb.Append(_Scan_File_Path_Name);
            sb.Append(_Scan_File_Name);
            sb.Append(_Scan_File_Recvd_Date);
            sb.Append(_Misc_File_Path_Name);
            sb.Append(_Misc_File_Name);
            sb.Append(_Num_Imgs_Exp);
            sb.Append(_Num_Images_Rcvd);
            sb.Append(_Demos_Enc_PPLine_Rcvd);
            sb.Append(_Num_Encounters_Exp);
            sb.Append(_Num_of_Checks_Exp);
            sb.Append(_Num_of_Checks_Rcvd);
            sb.Append(_Batch_Total_Exp);
            sb.Append(_Batch_Total_Rcvd);
            sb.Append(_Date_of_Deposit);
            sb.Append(_Rend_Prov_ID);
            sb.Append(_Comments_Message_ID);
            sb.Append(_Client_Response_Message_ID);
            sb.Append(_Scan_ID);
            sb.Append(_Total_No_Of_Demos);

            return sb.ToString().GetHashCode();
        }
        #endregion

        #region Properties
        [DataMember]
        public virtual string Batch_Name
        {
            get { return _Batch_Name; }
            set
            {
                _Batch_Name = value;
            }
        }
        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set
            {
                _Created_By = value;
            }
        }
        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set
            {
                _Created_Date_And_Time = value;
            }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set
            {
                _Modified_By = value;
            }
        }
        [DataMember]
        public virtual DateTime Modified_Date_And_Time
        {
            get { return _Modified_Date_And_Time; }
            set
            {
                _Modified_Date_And_Time = value;
            }
        }
        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set
            {
                _Version = value;
            }
        }
        [DataMember]
        public virtual string DOOS
        {
            get { return _DOOS; }
            set
            {
                _DOOS = value;
            }
        }
        [DataMember]
        public virtual string Doc_Type
        {
            get { return _Doc_Type; }
            set
            {
                _Doc_Type = value;
            }
        }
        [DataMember]
        public virtual string Doc_Sub_Type
        {
            get { return _Doc_Sub_Type; }
            set
            {
                _Doc_Sub_Type = value;
            }
        }
        [DataMember]
        public virtual string Facility_Name
        {
            get { return _Facility_Name; }
            set
            {
                _Facility_Name = value;
            }
        }
        [DataMember]
        public virtual string Scan_File_Path_Name
        {
            get { return _Scan_File_Path_Name; }
            set
            {
                _Scan_File_Path_Name = value;
            }
        }
        [DataMember]
        public virtual string Scan_File_Name
        {
            get { return _Scan_File_Name; }
            set
            {
                _Scan_File_Name = value;
            }
        }
        [DataMember]
        public virtual DateTime Scan_File_Recvd_Date
        {
            get { return _Scan_File_Recvd_Date; }
            set
            {
                _Scan_File_Recvd_Date = value;
            }
        }
        [DataMember]
        public virtual string Misc_File_Path_Name
        {
            get { return _Misc_File_Path_Name; }
            set
            {
                _Misc_File_Path_Name = value;
            }
        }
        [DataMember]
        public virtual string Misc_File_Name
        {
            get { return _Misc_File_Name; }
            set
            {
                _Misc_File_Name = value;
            }
        }
        [DataMember]
        public virtual int Num_Imgs_Exp
        {
            get { return _Num_Imgs_Exp; }
            set
            {
                _Num_Imgs_Exp = value;
            }
        }
        [DataMember]
        public virtual int Num_Images_Rcvd
        {
            get { return _Num_Images_Rcvd; }
            set
            {
                _Num_Images_Rcvd = value;
            }
        }
        [DataMember]
        public virtual int Demos_Enc_PPLine_Rcvd
        {
            get { return _Demos_Enc_PPLine_Rcvd; }
            set
            {
                _Demos_Enc_PPLine_Rcvd = value;
            }
        }


        [DataMember]
        public virtual int Num_Encounters_Exp
        {
            get { return _Num_Encounters_Exp; }
            set
            {
                _Num_Encounters_Exp = value;
            }
        }
        [DataMember]
        public virtual int Num_of_Checks_Exp
        {
            get { return _Num_of_Checks_Exp; }
            set
            {
                _Num_of_Checks_Exp = value;
            }
        }
        [DataMember]
        public virtual int Num_of_Checks_Rcvd
        {
            get { return _Num_of_Checks_Rcvd; }
            set
            {
                _Num_of_Checks_Rcvd = value;
            }
        }
        [DataMember]
        public virtual decimal Batch_Total_Exp
        {
            get { return _Batch_Total_Exp; }
            set
            {
                _Batch_Total_Exp = value;
            }
        }
        [DataMember]
        public virtual decimal Batch_Total_Rcvd
        {
            get { return _Batch_Total_Rcvd; }
            set
            {
                _Batch_Total_Rcvd = value;
            }
        }
        [DataMember]
        public virtual DateTime Date_of_Deposit
        {
            get { return _Date_of_Deposit; }
            set
            {
                _Date_of_Deposit = value;
            }
        }

        [DataMember]
        public virtual DateTime DOS
        {
            get { return _DOS; }
            set
            {
                _DOS = value;
            }
        }


        [DataMember]
        public virtual string Input_Mode
        {
            get { return _Input_Mode; }
            set
            {
                _Input_Mode = value;
            }
        }
        [DataMember]
        public virtual int Rend_Prov_ID
        {
            get { return _Rend_Prov_ID; }
            set
            {
                _Rend_Prov_ID = value;
            }
        }
        [DataMember]
        public virtual int Comments_Message_ID
        {
            get { return _Comments_Message_ID; }
            set
            {
                _Comments_Message_ID = value;
            }
        }
        [DataMember]
        public virtual int Client_Response_Message_ID
        {
            get { return _Client_Response_Message_ID; }
            set
            {
                _Client_Response_Message_ID = value;
            }
        }
        //[DataMember]
        //public virtual string Issues
        //{
        //    get { return _Issues; }
        //    set
        //    {
        //        _Issues = value;
        //    }
        //}

        //[DataMember]
        //public virtual string Feedback
        //{
        //    get { return _Feedback; }
        //    set
        //    {
        //        _Feedback = value;
        //    }
        //}
        [DataMember]
        public virtual int Total_No_Of_Demos
        {
            get { return _Total_No_Of_Demos; }
            set
            {
                _Total_No_Of_Demos = value;
            }
        }
        [DataMember]
        public virtual ulong Scan_ID
        {
            get { return _Scan_ID; }
            set
            {
                _Scan_ID = value;
            }
        }
        #endregion
    }
}
