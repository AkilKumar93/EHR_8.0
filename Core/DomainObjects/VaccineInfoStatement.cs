using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class VaccineInfoStatement:BusinessBase<ulong>
    {
        #region Declarations

        private string _Vaccine_Name=string.Empty;
        private DateTime _VIS_Date=DateTime.MinValue;
        private string _Section=string.Empty;
        private string _File_Name_Path=string.Empty;
        //Janani - Main - 30 Jul 2011 - Start
        private int _Sort_Order = 0;
        private int _CVX = 0;
        //Janani - Main - 30 Jul 2011 - End
        #endregion

        #region Constructors

        public VaccineInfoStatement() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Vaccine_Name);
            sb.Append(_VIS_Date);
            sb.Append(_Section);
            sb.Append(_File_Name_Path);
            //Janani - Main - 30 Jul 2011 - Start
            sb.Append(_Sort_Order);
            //Janani - Main - 30 Jul 2011 - End
            sb.Append(_CVX);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties
     
        [DataMember]
        public virtual string Vaccine_Name
        {
            get { return _Vaccine_Name; }
            set { _Vaccine_Name = value; }
        }
       
       
        [DataMember]
        public virtual DateTime VIS_Date
        {
            get { return _VIS_Date; }
            set { _VIS_Date = value; }
        }
      
        [DataMember]
        public virtual string Section
        {
            get { return _Section; }
            set { _Section = value; }
        }
        [DataMember]
        public virtual string File_Name_Path
        {
            get { return _File_Name_Path; }
            set { _File_Name_Path = value; }
        }
        //Janani - Main - 30 Jul 2011 - Start
        [DataMember]
        public virtual int Sort_Order
        {
            get { return _Sort_Order; }
            set { _Sort_Order = value; }
        }
        //Janani - Main - 30 Jul 2011 - End
        [DataMember]
        public virtual int CVX
        {
            get { return _CVX; }
            set { _CVX = value; }
        }
        #endregion
    }
}
