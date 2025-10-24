using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    
    public partial class Human_Phi_Disclosure : BusinessBase<ulong>
    {
        #region Declarations
        private ulong _Human_ID = 0;
        private string _Is_Disclose_All_Information = string.Empty;
        private string _Disclosure_Details = string.Empty;
        private string _PHI_Disclosure_Signed_By = string.Empty;
        private DateTime _PHI_Disclosure_Signed_Date_Time = DateTime.MinValue;
        private string _Created_By = string.Empty;
        private string _Modified_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version = 0;
        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Human_ID);
            sb.Append(_Is_Disclose_All_Information);
            sb.Append(_Disclosure_Details);
            sb.Append(_PHI_Disclosure_Signed_By);
            sb.Append(_PHI_Disclosure_Signed_Date_Time);
            sb.Append(_Created_By);
            sb.Append(_Modified_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
            return sb.ToString().GetHashCode();
        }
        #endregion


        #region variable value implementation
        
        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }
        [DataMember]
        public virtual string Is_Disclose_All_Information
        {
            get { return _Is_Disclose_All_Information; }
            set { _Is_Disclose_All_Information = value; }
        }
        [DataMember]
        public virtual string Disclosure_Details
        {
            get { return _Disclosure_Details; }
            set { _Disclosure_Details = value; }
        }
        [DataMember]
        public virtual string PHI_Disclosure_Signed_By
        {
            get { return _PHI_Disclosure_Signed_By; }
            set { _PHI_Disclosure_Signed_By = value; }
        }
        [DataMember]
        public virtual DateTime PHI_Disclosure_Signed_Date_Time
        {
            get { return _PHI_Disclosure_Signed_Date_Time; }
            set { _PHI_Disclosure_Signed_Date_Time = value; }
        }
        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set { _Modified_By = value; }
        }
       
        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set { _Created_Date_And_Time = value; }
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

        #endregion

    }
}
