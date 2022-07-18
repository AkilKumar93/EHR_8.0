using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]    
    public partial class All_Drug : BusinessBase<ulong>
    {
         #region Declarations


        //All_Drug_ID, Drug_Name, Route_Of_Administration, Strength, Physician_Name

        private string _Drug_Name = string.Empty;
        private string _Route_Of_Administration = string.Empty;
        private string _Strength = string.Empty;
        private string _Default_Value = string.Empty;
        
        #endregion

       #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Drug_Name);
            sb.Append(_Route_Of_Administration);
            sb.Append(_Strength);
            sb.Append(_Default_Value);
                     
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties        
        [DataMember]
        public virtual string Drug_Name
        {
            get { return _Drug_Name; }
            set { _Drug_Name = value; }
        }
       
        [DataMember]
        public virtual string Route_Of_Administration
        {
            get { return _Route_Of_Administration; }
            set { _Route_Of_Administration = value; }
        }
        [DataMember]
        public virtual string Strength
        {
            get { return _Strength; }
            set { _Strength = value; }
        }
        [DataMember]
        public virtual string Default_Value
        {
            get { return _Default_Value; }
            set { _Default_Value = value; }
        }
                 
        #endregion
    }
}
