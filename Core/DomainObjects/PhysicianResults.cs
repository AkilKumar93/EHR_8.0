using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class PhysicianResults : BusinessBase<ulong>
    {
        #region Declarations
        private ulong _Physician_ID = 0;
        private string _Acurus_Result_Code = string.Empty;
        private string _Acurus_Result_Description = string.Empty;
        private int _Sort_Order = 0;
        private string _Legal_Org = string.Empty;
        #endregion 
     
         #region Constructors

        public PhysicianResults() { }

        #endregion

         public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Physician_ID);
            sb.Append(_Acurus_Result_Code);
            sb.Append(_Acurus_Result_Description);
            sb.Append(_Sort_Order);
            sb.Append(_Legal_Org);
            return sb.ToString().GetHashCode();
        }
         #region Properties
         [DataMember]
         public virtual ulong Physician_ID
         {
             get { return _Physician_ID; }
             set { _Physician_ID = value; }
         }
     
         [DataMember]
         public virtual string Acurus_Result_Code
         {
             get { return _Acurus_Result_Code; }
             set { _Acurus_Result_Code = value; }

         }
         [DataMember]
         public virtual string Acurus_Result_Description
         {
             get { return _Acurus_Result_Description; }
             set { _Acurus_Result_Description = value; }
         }
         [DataMember]
         public virtual int  Sort_Order
         {
             get { return _Sort_Order; }
             set { _Sort_Order = value; }
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
