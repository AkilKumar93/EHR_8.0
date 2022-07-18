using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class AssessmentVitalsLookup : BusinessBase<ulong>
    {
        #region Declarations

        private string _Field_Name = string.Empty;
        private string _Entity_Name = string.Empty;
        private string _Description = string.Empty;
        private string _Value = string.Empty;
        private string _ICD = string.Empty;
        //Latha - Main - 28 Jul 2011 - Start
        private int _Sort_Order = 0;
        //Latha - Main - 28 Jul 2011 - End

        private string _ICD_10 = string.Empty;
        private string _ICD_10_Description = string.Empty;
        private string _Hirarrchy = string.Empty;
        private string _Is_Current_Encounter = string.Empty;
        private string _Is_Mutually_Exclusive = string.Empty;
        private string _Is_Macra_Field = string.Empty;

        #endregion

        #region Constructors

        public AssessmentVitalsLookup() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Field_Name);
            sb.Append(_Entity_Name);
            sb.Append(_Description);
            sb.Append(_Value);
            sb.Append(_ICD);

            //Latha - Main - 28 Jul 2011 - Start
            sb.Append(_Sort_Order);
            //Latha - Main - 28 Jul 2011 - End
            sb.Append(_ICD_10);
            sb.Append(_ICD_10_Description);
            sb.Append(_Hirarrchy);
            sb.Append(_Is_Current_Encounter);
            sb.Append(_Is_Mutually_Exclusive);
            sb.Append(_Is_Macra_Field);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual string Field_Name
        {
            get { return _Field_Name; }
            set { _Field_Name = value; }
        }
        [DataMember]
        public virtual string Entity_Name
        {
            get { return _Entity_Name; }
            set { _Entity_Name = value; }
        }
        [DataMember]
        public virtual string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        [DataMember]
        public virtual string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        [DataMember]
        public virtual string ICD
        {
            get { return _ICD; }
            set { _ICD = value; }

        }
        //Latha - Main - 28 Jul 2011 - Start
        [DataMember]
        public virtual int Sort_Order
        {
            get { return _Sort_Order; }
            set { _Sort_Order = value; }
        }
        //Latha - Main - 28 Jul 2011 - End

        [DataMember]
        public virtual string ICD_10
        {
            get { return _ICD_10; }
            set { _ICD_10 = value; }

        }
        [DataMember]
        public virtual string ICD_10_Description
        {
            get { return _ICD_10_Description; }
            set { _ICD_10_Description = value; }

        }
        [DataMember]
        public virtual string Hirarrchy
        {
            get { return _Hirarrchy; }
            set { _Hirarrchy = value; }

        }
        [DataMember]
        public virtual string Is_Current_Encounter
        {
            get { return _Is_Current_Encounter; }
            set { _Is_Current_Encounter = value; }

        }
        [DataMember]
        public virtual string Is_Mutually_Exclusive
        {
            get { return _Is_Mutually_Exclusive; }
            set { _Is_Mutually_Exclusive = value; }

        }
        [DataMember]
        public virtual string Is_Macra_Field
        {
            get { return _Is_Macra_Field; }
            set { _Is_Macra_Field = value; }

        }
        #endregion
    }
}

