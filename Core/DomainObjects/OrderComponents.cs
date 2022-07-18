using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
      [DataContract]
    public partial class OrderComponents : BusinessBase<ulong>
    {
        #region Declarations
          private string _Order_Code_Name = string.Empty;
          private string _Specimen_Type = string.Empty;
          private string _Temperature = string.Empty;
          private string _Order_Code = string.Empty;
          
        #endregion

          #region Constructors

          public OrderComponents() { }

        #endregion
          public override int GetHashCode()
          {
              System.Text.StringBuilder sb = new System.Text.StringBuilder();
              sb.Append(this.GetType().FullName);
              sb.Append(_Order_Code_Name);
              sb.Append(_Specimen_Type);
              sb.Append(_Temperature);
              sb.Append(_Order_Code);
              return sb.ToString().GetHashCode();
          }
          [DataMember]
          public virtual string Order_Code_Name
          {
              get { return _Order_Code_Name; }
              set { _Order_Code_Name = value; }
          }
          [DataMember]
          public virtual string Specimen_Type
          {
              get { return _Specimen_Type; }
              set { _Specimen_Type = value; }
          }
          [DataMember]
          public virtual string Temperature
          {
              get { return _Temperature; }
              set { _Temperature = value; }
          }
          [DataMember]
          public virtual string Order_Code
          {
              get { return _Order_Code; }
              set { _Order_Code = value; }
          }


    }
}
