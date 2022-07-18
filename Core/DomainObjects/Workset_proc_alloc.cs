using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]  
    public partial class Workset_proc_alloc:BusinessBase<ulong>
    {
        #region Declarations

        private string _DOOS = string.Empty;
        private string _Batch_Name = string.Empty;
        private string _Process_Name = string.Empty;
        private string _Allocated_To = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private string _Doc_Type = string.Empty;
        private string _Doc_Sub_Type = string.Empty;
        private string _Sub_Batch_Range = string.Empty;
        private string _Doc_Name = string.Empty;
        private int _Version=0;

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_DOOS);
            sb.Append(_Batch_Name);
            sb.Append(_Process_Name);
            sb.Append(_Allocated_To);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Doc_Type);
            sb.Append(_Doc_Sub_Type);
            sb.Append(_Sub_Batch_Range);
            sb.Append(_Doc_Name);
            sb.Append(_Version);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual string DOOS
        {
            get { return _DOOS; }
            set { _DOOS = value; }
        }

        [DataMember]
        public virtual string Batch_Name
        {
            get { return _Batch_Name; }
            set { _Batch_Name = value; }
        }


        [DataMember]
        public virtual string Process_Name
        {
            get { return _Process_Name; }
            set { _Process_Name = value; }
        }

        [DataMember]
        public virtual string Allocated_To
        {
            get { return _Allocated_To; }
            set { _Allocated_To = value; }
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
        public virtual DateTime Modified_Date_And_Time
        {
            get { return _Modified_Date_And_Time; }
            set
            {
                _Modified_Date_And_Time = value;
            }
        }

        [DataMember]
        public virtual string Doc_Type
        {
            get { return _Doc_Type; }
            set { _Doc_Type = value; }
        }

        [DataMember]
        public virtual string Doc_Sub_Type
        {
            get { return _Doc_Sub_Type; }
            set { _Doc_Sub_Type = value; }
        }

        [DataMember]
        public virtual string Sub_Batch_Range
        {
            get { return _Sub_Batch_Range; }
            set { _Sub_Batch_Range = value; }
        }
         [DataMember]
        public virtual string Doc_Name
        {
            get { return _Doc_Name; }
            set { _Doc_Name = value; }
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

        #endregion
    }
}
