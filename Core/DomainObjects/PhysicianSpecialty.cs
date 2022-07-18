using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class PhysicianSpecialty : BusinessBase<ulong>
    {
        #region Declarations

        //private ulong _Carrier_ID;
        //private string _Is_Provider_PCP = string.Empty;
        //private string _Doc_Sub_Type = string.Empty;
        //private string _Specialty_Name = string.Empty;

        private ulong _Physician_ID = 0;
        private string _Specialty = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version = 0;
        private int _Sort_Order = 0;
        private string _Is_Active = string.Empty;
        private string _Legal_Org = string.Empty;

        #endregion

        #region Constructors

        public PhysicianSpecialty() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //sb.Append(this.GetType().FullName);
            //sb.Append(_Carrier_ID);
            //sb.Append(_Is_Provider_PCP);
            //sb.Append(_Doc_Sub_Type);
            //sb.Append(_Specialty_Name);
            sb.Append(_Physician_ID);
            sb.Append(_Specialty);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            sb.Append(_Sort_Order);
            sb.Append(_Is_Active);
            sb.Append(_Legal_Org);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties
        //[DataMember]
        //public virtual ulong Carrier_ID
        //{
        //    get { return _Carrier_ID; }
        //    set { _Carrier_ID = value; }
        //}
        //[DataMember]
        //public virtual string Is_Provider_PCP
        //{
        //    get { return _Is_Provider_PCP; }
        //    set { Is_Provider_PCP = value; }
        //}
        //[DataMember]
        //public virtual string Doc_Sub_Type
        //{
        //    get { return _Doc_Sub_Type; }
        //    set { _Doc_Sub_Type = value; }
        //}
        //[DataMember]
        //public virtual string Specialty_Name
        //{
        //    get { return _Specialty_Name; }
        //    set { _Specialty_Name = value; }
        //}

        [DataMember]
        public virtual ulong Physician_ID
        {
            get { return _Physician_ID; }
            set { _Physician_ID = value; }
        }
        [DataMember]
        public virtual string Specialty
        {
            get { return _Specialty; }
            set { _Specialty = value; }
        }
        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }
        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set { _Created_Date_And_Time = value; }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set { _Modified_By = value; }
        }
        [DataMember]
        public virtual DateTime Modified_Date_And_Time
        {
            get { return _Modified_Date_And_Time; }
            set { _Modified_Date_And_Time = value; }
        }
        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }
        [DataMember]
        public virtual int Sort_Order
        {
            get { return _Sort_Order; }
            set { _Sort_Order = value; }
        }
        [DataMember]
        public virtual string Is_Active
        {
            get { return _Is_Active; }
            set { _Is_Active = value; }
        }
        [DataMember]
        public virtual string Legal_Org
        {
            get { return _Legal_Org; }
            set { _Legal_Org = value; }
        }
        #endregion
    }
}
