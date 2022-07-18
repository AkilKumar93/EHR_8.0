using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Acurus.Capella.Core.DomainObjects
{
   [Serializable]
   [DataContract]
   public partial class VaccineManufacturerCodes:BusinessBase<ulong>
    {
       #region Declarations

        private string _Manufacturer_Name = string.Empty;
        private string _MVX_Code = string.Empty;
        private string _Status = string.Empty;
        private string _Notes = string.Empty;
        private DateTime _Last_Updated_Date= DateTime.MinValue;
        //Janani - Main - 30 Jul 2011 - Start
        private int _Sort_Order = 0;
        //Janani - Main - 30 Jul 2011 - End

        #endregion

        #region Constructors

        public VaccineManufacturerCodes() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Manufacturer_Name);
            sb.Append(_MVX_Code);
            sb.Append(_Status);
            sb.Append(_Last_Updated_Date);
            //Janani - Main - 30 Jul 2011 - Start
            sb.Append(_Sort_Order);
            //Janani - Main - 30 Jul 2011 - End
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

     
        
        [DataMember]
        public virtual string Manufacturer_Name
        {
            get { return _Manufacturer_Name; }
            set
            {
                _Manufacturer_Name = value;
            }
        }
        [DataMember]
        public virtual string MVX_Code
        {
            get { return _MVX_Code; }
            set
            {
                _MVX_Code = value;
            }
        }
        [DataMember]
        public virtual string Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
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
        public virtual DateTime Last_Updated_Date
        {
            get { return _Last_Updated_Date; }
            set
            {
                _Last_Updated_Date = value;
            }
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
