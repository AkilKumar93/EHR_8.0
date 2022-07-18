using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    public partial class Scan : BusinessBase<int>
    {
         #region Declarations

        private string _Scanned_File_Path=string.Empty;
        private string _Scanned_File_Name=string.Empty;
        private DateTime _Scanned_Date=DateTime.MinValue;
        private string _Facility_Name = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.Now;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time=DateTime.MinValue;
        private int _Version=0;
        private int _no_of_pages=0;
        private string _scan_type = string.Empty;
        private ulong _scan_ID=0;
        private int _close_type=0;

        

        #endregion

        #region Constructors

        public Scan() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(_scan_ID);
            sb.Append(this.GetType().FullName);
            sb.Append(_Scanned_File_Path);
            sb.Append(_Scanned_Date);
            sb.Append(_Facility_Name);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_no_of_pages);
            sb.Append(_Scanned_File_Name);
            sb.Append(_scan_type);
            sb.Append(_Version);
            sb.Append(_close_type);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual ulong Scan_ID
        {
            get { return _scan_ID; }
            set { _scan_ID = value; }
        }


        [DataMember]
        public virtual string Scanned_File_Path
        {
            get { return _Scanned_File_Path; }
            set { _Scanned_File_Path = value; }
        }


        [DataMember]
        public virtual string Scan_Type
        {
            get { return _scan_type; }
            set { _scan_type = value; }
        }



        [DataMember]
        public virtual string Scanned_File_Name
        {
            get { return _Scanned_File_Name; }
            set { _Scanned_File_Name = value; }
        }

        [DataMember]
        public virtual DateTime Scanned_Date
        {
            get { return _Scanned_Date; }
            set { _Scanned_Date = value; }
        }
        [DataMember]
        public virtual string Facility_Name
        {
            get { return _Facility_Name; }
            set { _Facility_Name = value; }
        }
        
        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }
        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set { _Created_Date_And_Time = value; }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set { _Modified_By = value; }
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

        [DataMember]
        public virtual int No_of_Pages
        {
            get { return _no_of_pages; }
            set { _no_of_pages = value; }
        }


        [DataMember]
        public virtual int Close_Type
        {
            get { return _close_type ; }
            set { _close_type = value; }
        }

        #endregion
    }
}
