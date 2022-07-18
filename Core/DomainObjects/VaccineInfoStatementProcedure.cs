using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class VaccineInfoStatementProcedure:BusinessBase<ulong>
    {
         #region Declarations

        private string _CPT=string.Empty;
        private ulong _Vaccine_Info_Statement_ID=0;
        //Janani - Main - 30 Jul 2011 - Start
        private int _Sort_Order = 0;
        //Janani - Main - 30 Jul 2011 - End
        #endregion

        #region Constructors

        public VaccineInfoStatementProcedure() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_CPT);
            sb.Append(_Vaccine_Info_Statement_ID);
            //Janani - Main - 30 Jul 2011 - Start
            sb.Append(_Sort_Order);
            //Janani - Main - 30 Jul 2011 - End
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties
     
        [DataMember]
        public virtual string CPT
        {
            get { return _CPT; }
            set { _CPT = value; }
        }
       
        [DataMember]
        public virtual ulong Vaccine_Info_Statement_ID
        {
            get { return _Vaccine_Info_Statement_ID; }
            set { _Vaccine_Info_Statement_ID = value; }
        }
        //Janani - Main - 30 Jul 2011 - Start
        [DataMember]
        public virtual int Sort_Order
        {
            get { return _Sort_Order; }
            set { _Sort_Order = value; }
        }
        //Janani - Main - 30 Jul 2011 - End
       
        #endregion
    }
}
