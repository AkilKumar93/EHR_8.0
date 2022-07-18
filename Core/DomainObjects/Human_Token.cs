using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class Human_Token : BusinessBase<ulong>
    {
        #region Declarations
        private ulong _Human_ID = 0;
        private string _Token = string.Empty;
        private string _Result = string.Empty;
        private string _Patient_Status = string.Empty;
        private string _Account_Status = string.Empty;
        private string _Human_Type = string.Empty;
        private string _Legal_Org = string.Empty;
        private ulong _Primary_Carrier_ID = 0;
        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);

            sb.Append(_Human_ID);
            sb.Append(_Token);
            sb.Append(_Result);
            sb.Append(_Patient_Status);
            sb.Append(_Account_Status);
            sb.Append(_Human_Type);
            sb.Append(_Legal_Org);
            sb.Append(_Primary_Carrier_ID);
            return sb.ToString().GetHashCode();
        }
        #endregion


        # region Properties
        [DataMember]
        public virtual ulong Human_ID
        {
            get { return _Human_ID; }
            set { _Human_ID = value; }
        }
        [DataMember]
        public virtual string Token
        {
            get { return _Token; }
            set { _Token = value; }
        }
        [DataMember]
        public virtual string Result
        {
            get { return _Result; }
            set { _Result = value; }
        }
        [DataMember]
        public virtual string Patient_Status
        {
            get { return _Patient_Status; }
            set { _Patient_Status = value; }
        }
        [DataMember]
        public virtual string Account_Status
        {
            get { return _Account_Status; }
            set { _Account_Status = value; }
        }
        [DataMember]
        public virtual string Human_Type
        {
            get { return _Human_Type; }
            set { _Human_Type = value; }
        }
        [DataMember]
        public virtual string Legal_Org
        {
            get { return _Legal_Org; }
            set { _Legal_Org = value; }
        }
        [DataMember]
        public virtual ulong Primary_Carrier_ID
        {
            get { return _Primary_Carrier_ID; }
            set { _Primary_Carrier_ID = value; }
        }
        #endregion
    }
}
