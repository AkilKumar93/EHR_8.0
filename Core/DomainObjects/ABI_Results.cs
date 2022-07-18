using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class ABI_Results : BusinessBase<int>
    {
        #region Declarations
       
        private string _abi_field_name = String.Empty;
        private string _abi_field_value = String.Empty;
        private ulong _patientid=0;
        private string _createdby = String.Empty;
        private System.DateTime _createddatetime=DateTime.MinValue ;
        private string _modifiedby = String.Empty;
        private System.DateTime _modifieddatetime = DateTime.MinValue;
        private int _version=0;
        private string _notes = String.Empty;
        private ulong _in_house_procedure_id=0;
        private string _file_name = String.Empty;
        private ulong _order_id = 0;
        #endregion

        #region Constructors

        public ABI_Results() { }

        #endregion


        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_abi_field_name);
            sb.Append(_abi_field_value);
            sb.Append(_patientid);
            sb.Append(_createdby);
            sb.Append(_createddatetime);
            sb.Append(_modifiedby);
            sb.Append(_modifieddatetime);
            sb.Append(_version);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual string ABI_File_Type
        {
            get { return _abi_field_name; }
            set
            {
                _abi_field_name = value;
            }
        }
        [DataMember]
        public virtual string ABI_Field_Value_OR_File_Path
        {
            get { return _abi_field_value; }
            set
            {
                _abi_field_value = value;
            }
        }
        [DataMember]
        public virtual ulong Patient_ID
        {
            get { return _patientid; }
            set
            {
                _patientid = value;
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
        public virtual string Modified_By
        {
            get { return _modifiedby; }
            set
            {
                _modifiedby = value;
            }
        }
        [DataMember]
        public virtual System.DateTime Created_Date_And_Time
        {
            get { return _createddatetime; }
            set
            {
                _createddatetime = value;
            }
        }
        [DataMember]
        public virtual System.DateTime Modified_Date_And_Time
        {
            get { return _modifieddatetime; }
            set
            {
                _modifieddatetime = value;
            }
        }

        [DataMember]
        public virtual int Version
        {
            get { return _version; }
            set
            {
                _version = value;
            }
        }
        [DataMember]
        public virtual string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
            }
        }
        

              [DataMember]
        public virtual ulong In_House_Procedure_ID
        {
            get { return _in_house_procedure_id; }
            set
            {
                _in_house_procedure_id = value;
            }
        }

              [DataMember]
              public virtual string File_Name
              {
                  get { return _file_name; }
                  set
                  {
                      _file_name = value;
                  }
              }



              [DataMember]
              public virtual ulong Order_ID
              {
                  get { return _order_id ; }
                  set
                  {
                      _order_id = value;
                  }
              }
        #endregion
    }
}
