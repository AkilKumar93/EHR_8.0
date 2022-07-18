using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class OrdersRequiredForms : BusinessBase<ulong>
    {
        #region Declarations

        private ulong _Order_Id = 0;
        private string _Cpt = String.Empty;
        private string _Cpt_Description= String.Empty;
        private string _Form_Name = String.Empty;
        private string _Form_Required = String.Empty;
        private string _Form_Available = String.Empty;
        private string _Additional_Information = String.Empty;
        
        private int _Version = 0;
        private string _Created_By = String.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = String.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;

        private ulong _Ordering_Provider_Id = 0;

        #endregion

        #region Constructors

        public OrdersRequiredForms() { }

        #endregion
        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Order_Id);
            sb.Append(_Cpt);
            sb.Append(_Form_Name);
            sb.Append(_Form_Required);
            sb.Append(_Form_Available);
            sb.Append(_Additional_Information);
            sb.Append(_Version);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Cpt_Description);
            sb.Append(_Ordering_Provider_Id);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual ulong Order_Id
        {
            get { return _Order_Id; }
            set
            {
                _Order_Id = value;
            }
        }
        [DataMember]
        public virtual string CPT
        {
            get { return _Cpt; }
            set
            {
                _Cpt = value;
            }
        }
        [DataMember]
        public virtual string Form_Name
        {
            get { return _Form_Name; }
            set
            {
                _Form_Name = value;
            }
        }

        [DataMember]
        public virtual string Cpt_Description
        {
            get { return _Cpt_Description; }
            set
            {
                _Cpt_Description = value;
            }
        }

        [DataMember]
        public virtual string Form_Required
        {
            get { return _Form_Required; }
            set
            {
                _Form_Required = value;
            }
        }
        [DataMember]
        public virtual string Form_Available
        {
            get { return _Form_Available; }
            set
            {
                _Form_Available = value;
            }
        }
        [DataMember]
        public virtual string Additional_Information
        {
            get { return _Additional_Information; }
            set
            {
                _Additional_Information = value;
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
        public virtual ulong Ordering_Provider_Id
        {
            get { return _Ordering_Provider_Id; }
            set
            {
                _Ordering_Provider_Id = value;
            }
        }
        #endregion


    }
}
