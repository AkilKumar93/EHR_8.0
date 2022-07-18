using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable]
    [DataContract]
    public partial class ModifierLibrary:BusinessBase<ulong>
    {
         #region Declarations
        private string _Modifier_Code = string.Empty;
        private string _Modifier_Code_Description = string.Empty;
        private string _Short_Description = string.Empty;
        private int _Sort_Order = 0;
        private string _Modifier_Impact = string.Empty;
        private string _Is_Active = string.Empty;
        private string _From_Date = string.Empty;
        private string _To_Date = string.Empty;
        private string _Created_By = string.Empty;
        private DateTime _Created_Date_And_Time = DateTime.MinValue;
        private string _Modified_By = string.Empty;
        private DateTime _Modified_Date_And_Time = DateTime.MinValue;
        private int _Version = 0;

        
        #endregion

          #region Constructors

        public ModifierLibrary() { }

        #endregion

        #region HashCode Value

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Modifier_Code);
            sb.Append(_Modifier_Code_Description);
            sb.Append(_Short_Description);
            sb.Append(_Sort_Order);
            sb.Append(_Modifier_Impact);
            sb.Append(_Is_Active);
            sb.Append(_From_Date);
            sb.Append(_To_Date);
            sb.Append(_Created_By);
            sb.Append(_Created_Date_And_Time);
            sb.Append(_Modified_By);
            sb.Append(_Modified_Date_And_Time);
            sb.Append(_Version);
           
            
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region Properties
        [DataMember]
        public virtual string Modifier_Code
        {
            get { return _Modifier_Code; }
            set
            {
                _Modifier_Code = value;
            }
        }
        [DataMember]
        public virtual string Modifier_Code_Description
        {
            get { return _Modifier_Code_Description; }
            set
            {
                _Modifier_Code_Description = value;
            }
        }

        [DataMember]
        public virtual string Short_Description
        {
            get { return _Short_Description; }
            set
            {
                _Short_Description = value;
            }
        }
       

        [DataMember]
        public virtual int Sort_Order
        {
            get { return _Sort_Order; }
            set
            {
                _Sort_Order = value;
            }
        }
        [DataMember]
        public virtual string Modifier_Impact
        {
            get { return _Modifier_Impact; }
            set
            {
                _Modifier_Impact = value;
            }
        }
        [DataMember]
        public virtual string Is_Active
        {
            get { return _Is_Active; }
            set
            {
                _Is_Active = value;
            }
        }
        [DataMember]
        public virtual string From_Date
        {
            get { return _From_Date; }
            set
            {
                _From_Date = value;
            }
        }
        [DataMember]
        public virtual string To_Date
        {
            get { return _To_Date; }
            set
            {
                _To_Date = value;
            }
        }
        [DataMember]
        public virtual string Created_By
        {
            get { return _Created_By; }
            set
            {
                _Created_By = value;
            }
        }
        [DataMember]
        public virtual DateTime Created_Date_And_Time
        {
            get { return _Created_Date_And_Time; }
            set
            {
                _Created_Date_And_Time = value;
            }
        }
        [DataMember]
        public virtual string Modified_By
        {
            get { return _Modified_By; }
            set
            {
                _Modified_By = value;
            }
        }
        [DataMember]
        public virtual DateTime Modified_Date_And_Time
        {
            get { return _Modified_Date_And_Time; }
            set
            {
                _Modified_Date_And_Time = value;
            }
        }

        [DataMember]
        public virtual int Version
        {
            get { return _Version; }
            set
            {
                _Version = value;
            }
        }
        #endregion

    
    }
}
