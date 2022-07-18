using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;


namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class FlowSheetTemplate : BusinessBase<ulong>
    {
          #region Declarations

        private ulong _Physician_ID=0;
        private string _Template_Name=string.Empty;
        private string _createdby=string.Empty;
        private DateTime _createddateandtime;
        private string _modifiedby= string.Empty;
        private DateTime _modifieddateandtime;
        private int _version = 0;
        private string _Unit = string.Empty;
        private string _Acurus_Result_Code = string.Empty;
        private string _Acurus_Result_Description = string.Empty;
        private int _Sort_Order = 0;


        #endregion

        #region Constructors

        public FlowSheetTemplate() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Physician_ID);
            sb.Append(_Template_Name);
            sb.Append(_createdby=string.Empty);
            sb.Append(_createddateandtime);
            sb.Append(_modifieddateandtime);
            sb.Append(_version);
            sb.Append(_Unit); 
            sb.Append(_Acurus_Result_Code);
            sb.Append(_Acurus_Result_Description);
            sb.Append(_Sort_Order);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

     
        [DataMember]
        public virtual string Template_Name
        {
            get { return _Template_Name; }
            set
            {
                _Template_Name = value;
            }
        }
        [DataMember]
        public virtual ulong Physician_ID
        {
            get { return _Physician_ID; }
            set
            {
                _Physician_ID = value;
            }
        } 
        [DataMember]
        public virtual string Created_By
        {
            get { return _createdby; }
            set
            {
                _createdby = value;
            }
        }
        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _createddateandtime; }
            set
            {
                _createddateandtime = value;
            }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _modifiedby; }
            set
            {
                _modifiedby = value;
            }
        }
        [DataMember]
        public virtual DateTime Modified_Date_And_Time
        {
            get { return _modifieddateandtime; }
            set
            {
                _modifieddateandtime = value;
            }
        }
        [DataMember]
        public virtual int Version
        {
            get
            {
                return _version;
            }
            set
            {
                _version = value;
            }
        }
        [DataMember]
        public virtual string Unit
        {
            get
            {
                return _Unit;
            }
            set
            {
                _Unit = value;
            }
        }
        [DataMember]
        public virtual string Acurus_Result_Code
        {
            get { return _Acurus_Result_Code; }
            set
            {
                _Acurus_Result_Code = value;
            }
        }
        [DataMember]
        public virtual string Acurus_Result_Description
        {
            get
            {
                return _Acurus_Result_Description;
            }
            set
            {
                _Acurus_Result_Description = value;
            }
        }
        [DataMember]
        public virtual int Sort_Order
        {
            get
            {
                return _Sort_Order;
            }
            set
            {
                _Sort_Order = value;
            }
        }
        #endregion
    }
}
