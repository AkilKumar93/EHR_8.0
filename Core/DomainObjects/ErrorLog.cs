using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class ErrorLog : BusinessBase<ulong>
    {
        private string _File_Name = string.Empty;
        private ulong _Result_Master_ID= 0;
        private ulong _Lab_ID =0;
        private string _Reason_Code= string.Empty;
        private string _Reason_Description= string.Empty;
        private string _Created_By = string.Empty;
        private string _Patient_First_Name= string.Empty;
        private string _Patient_Last_Name = string.Empty;
        private string _Patient_MI_Name = string.Empty;
        private string _Patient_Gender= string.Empty;
        private DateTime _Patient_DOB= new DateTime();
        private DateTime _Created_Date_And_Time;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time;
        private int _Version = 0;
        private string _Is_Deleted = string.Empty;
        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_File_Name);
            sb.Append(_Result_Master_ID);
            sb.Append(_Lab_ID);
            sb.Append(_Reason_Code);
            sb.Append(_Reason_Description);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            sb.Append(_Is_Deleted);
            return sb.ToString().GetHashCode();
        }
        #endregion
        
            [DataMember]
        public virtual string File_Name
        {
            get { return _File_Name; }
            set
            {
                _File_Name = value;
            }
        }
        [DataMember]
        public virtual ulong Result_Master_ID
        {
            get { return _Result_Master_ID; }
            set
            {
                _Result_Master_ID = value;
            }
        }
        [DataMember]
        public virtual ulong Lab_ID
        {
            get { return _Lab_ID; }
            set
            {
                _Lab_ID = value;
            }
        }
        [DataMember]
        public virtual string Reason_Description
        {
            get { return _Reason_Description; }
            set
            {
                _Reason_Description = value;
            }
        }
        [DataMember]
        public virtual string Patient_First_Name
        {
            get { return _Patient_First_Name; }
            set
            {
                _Patient_First_Name = value;
            }
        }
        [DataMember]
        public virtual string Patient_Last_Name
        {
            get { return _Patient_Last_Name; }
            set
            {
                _Patient_Last_Name = value;
            }
        }
        [DataMember]
        public virtual string Patient_MI_Name
        {
            get { return _Patient_MI_Name; }
            set
            {
                _Patient_MI_Name = value;
            }
        }
         [DataMember]
        public virtual DateTime Patient_DOB
        {
            get { return _Patient_DOB; }
            set
            {
                _Patient_DOB = value;
            }
        }
         [DataMember]
         public virtual string Patient_Gender
         {
             get { return _Patient_Gender; }
             set
             {
                 _Patient_Gender = value;
             }
         }
        [DataMember]
         public virtual string Reason_Code
        {
            get { return _Reason_Code; }
            set
            {
                _Reason_Code = value;
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
            set { _Version = value; }
        }

        [DataMember]
        public virtual string Is_Deleted
        {
            get { return _Is_Deleted; }
            set { _Is_Deleted = value; }
        }
    }
}
