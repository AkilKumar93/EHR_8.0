using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [Serializable()]
    public partial class BodyImageAnnotations : BusinessBase<ulong>
    {
        #region Declarations
        private ulong _Encounter_ID = 0;
        private string _Template_Name = string.Empty;
        private string _Annotation_Type = string.Empty;
        private string _Annotation_Data = string.Empty;
        #endregion

        #region Constructors

        public BodyImageAnnotations() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Encounter_ID);
            sb.Append(_Template_Name);
            sb.Append(_Annotation_Type);
            sb.Append(_Annotation_Data);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual ulong Encounter_ID
        {
            get { return _Encounter_ID; }
            set { _Encounter_ID = value; }
        }

        [DataMember]
        public virtual string Template_Name
        {
            get { return _Template_Name; }
            set { _Template_Name = value; }
        }

        [DataMember]
        public virtual string Annotation_Type
        {
            get { return _Annotation_Type; }
            set { _Annotation_Type = value; }
        }

        [DataMember]
        public virtual string Annotation_Data
        {
            get { return _Annotation_Data; }
            set { _Annotation_Data = value; }
        }

        #endregion
    }
}
