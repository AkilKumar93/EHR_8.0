using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    //Acurus_Result_Code, Acurus_Result_Description, Lab_ID, Lab_Result_Code, Lab_Result_Description, CPT_Code, Units, Range, Gender
    public partial class AcurusResultsMapping : BusinessBase<string>
    {
        #region Declarations

        private string _Acurus_Result_Code = string.Empty;
        private string _Acurus_Result_Description = string.Empty;
        //private string _Order_Code = string.Empty;
        //private string _Order_Code_Description = string.Empty;
        private ulong _Lab_ID = 0;
        private string _Lab_Result_Code = string.Empty;
        private string _Lab_Result_Description = string.Empty;
        //private string _CPT_Code = string.Empty;
        private int _Sort_Order = 0;
        #endregion


        #region Constructors

        public AcurusResultsMapping() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(this.GetType().FullName);
            sb.Append(_Acurus_Result_Code);
            sb.Append(_Acurus_Result_Description);
            //sb.Append(_Order_Code);
            //sb.Append(_Order_Code_Description);
            sb.Append(_Lab_ID);
            sb.Append(_Lab_Result_Code);
            sb.Append(_Lab_Result_Description);
            //sb.Append(_CPT_Code);
            sb.Append(_Sort_Order);
            return sb.ToString().GetHashCode();
        }

        #endregion



        #region Properties

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
        public virtual ulong Lab_ID
        {
            get { return _Lab_ID; }
            set { _Lab_ID = value; }
        }
        //[DataMember]
        //public virtual string Order_Code
        //{
        //    get { return _Order_Code; }
        //    set { _Order_Code = value; }
        //}

        //[DataMember]
        //public virtual string Order_Code_Description
        //{
        //    get { return _Order_Code_Description; }
        //    set { _Order_Code_Description = value; }
        //}

        [DataMember]
        public virtual string Lab_Result_Code
        {
            get { return _Lab_Result_Code; }
            set { _Lab_Result_Code = value; }
        }

        [DataMember]
        public virtual string Lab_Result_Description
        {
            get { return _Lab_Result_Description; }
            set { _Lab_Result_Description = value; }
        }

        //[DataMember]
        //public virtual string CPT_Code
        //{
        //    get { return _CPT_Code; }
        //    set { _CPT_Code = value; }
        //}
        [DataMember]
        public virtual int Sort_Order
        {
            get { return _Sort_Order; }
            set { _Sort_Order = value; }
        }

        #endregion
    }

}
