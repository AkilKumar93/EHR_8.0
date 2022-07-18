using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;


namespace Acurus.Capella.Core.DTO
{

    [Serializable]
    public partial class Scan_IndexDTO
    {

        #region Declarations
        private IList<scan_index> _PastMedicalList= null;
        //private int _ScanCount= 0;
        private Scan _scannedDetails;


        //private string _physician_Name = string.Empty;
        
        private string _sLastName = string.Empty;
        private string _sFirstName = string.Empty;
        private string _sMI = string.Empty;
        private string _sSex = string.Empty;
        //private string _Human_Type = "REGULAR";
        private DateTime _dtBirthDate = DateTime.MinValue;
        
        

        #endregion

        #region Constructor

        public Scan_IndexDTO()
        {
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual IList<scan_index> ScanIndexList
        {
            get { return _PastMedicalList; }
            set { _PastMedicalList = value; }
        }
        //[DataMember]
        //public virtual int ScanCount
        //{
        //    get { return _ScanCount; }
        //    set { _ScanCount = value; }
        //}
        //[DataMember]
        //public virtual string Physician_Name
        //{
        //    get { return _physician_Name; }
        //    set { _physician_Name = value; }
        //}

      [DataMember]
       public virtual string Last_Name
       {
           get { return _sLastName; }
           set { _sLastName = value; }
       }
       [DataMember]
       public virtual string First_Name
       {
           get { return _sFirstName; }
           set { _sFirstName = value; }
       }
       [DataMember]
       public virtual string MI
       {
           get { return _sMI; }
           set { _sMI = value; }
       }
       [DataMember]
       public virtual DateTime Birth_Date
       {
           get { return _dtBirthDate; }
           set { _dtBirthDate = value; }
       }

       [DataMember]
       public virtual string Sex
       {
           get { return _sSex; }
           set { _sSex = value; }
       }
       //[DataMember]
       //public virtual string Human_Type
       //{
       //    get { return _Human_Type; }
       //    set { _Human_Type = value; }
       //}

       [DataMember]
       public virtual Scan ScanDetails
       {
           get { return _scannedDetails; }
           set { _scannedDetails = value; }
       }
        #endregion
    }
}

