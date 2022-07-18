using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{

    [DataContract]
    public partial class Spirometry : BusinessBase<ulong>
    {

        #region Declarations

        private ulong _Patient_ID=0;
        private string _Patient_And_Test_Indormation = String.Empty;
        private string _Test_Results_Information = String.Empty;
        private string _Flow_Volume_Values = String.Empty;
        private string _Volume_Time_Values = String.Empty;
        private string _Notes = String.Empty;
        private string _createdby = String.Empty;
        private System.DateTime _createddatetime;
        private string _modifiedby = String.Empty;
        private System.DateTime _modifieddatetime;
        private int _version=0;
        private ulong _In_House_Procedure_ID=0;
        private string _File_Name = String.Empty;

        #endregion

         #region Constructors

        public Spirometry() { }

        #endregion
        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);

            sb.Append(_Patient_ID);
            sb.Append(_Patient_And_Test_Indormation);
            sb.Append(_Test_Results_Information);
            sb.Append(_Flow_Volume_Values);
            sb.Append(_Volume_Time_Values);
            sb.Append(_Notes);
            sb.Append(_createdby);
            sb.Append(_createddatetime);
            sb.Append(_modifiedby);
            sb.Append(_modifieddatetime);
            sb.Append(_version);
            sb.Append(_In_House_Procedure_ID);
            sb.Append(_File_Name);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual ulong Patient_ID
        {
            get { return _Patient_ID; }
            set
            {
                _Patient_ID = value;
            }
        }

        [DataMember]
        public virtual string Patient_And_Test_Indormation
        {
            get { return _Patient_And_Test_Indormation; }
            set
            {
                _Patient_And_Test_Indormation = value;
            }
        }
        [DataMember]
        public virtual string Test_Results_Information
        {
            get { return _Test_Results_Information; }
            set
            {
                _Test_Results_Information = value;
            }
        }
        [DataMember]
        public virtual string Flow_Volume_Values
        {
            get { return _Flow_Volume_Values; }
            set
            {
                _Flow_Volume_Values = value;
            }
        }
        [DataMember]
        public virtual string Volume_Time_Values
        {
            get { return _Volume_Time_Values; }
            set
            {
                _Volume_Time_Values = value;
            }
        }
        [DataMember]
        public virtual string Notes
        {
            get { return _Notes; }
            set
            {
                _Notes = value;
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
        public virtual ulong In_House_Procedure_ID
        {
            get { return _In_House_Procedure_ID; }
            set
            {
                _In_House_Procedure_ID = value;
            }
        }
        [DataMember]
        public virtual string File_Name
        {
            get { return _File_Name; }
            set
            {
                _File_Name = value;
            }
        }
        #endregion


    }
}
