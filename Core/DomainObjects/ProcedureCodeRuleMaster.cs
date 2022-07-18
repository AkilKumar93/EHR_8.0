using System;
using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
  public partial class ProcedureCodeRuleMaster:BusinessBase<ulong>
  {
      #region Declaration

        private string _XML_Type = string.Empty;
        private string _XML_Query = string.Empty;
      private string _Procedure_Code = string.Empty;
      //private int _Group_Number = 0;
      private string _Rule_Name = string.Empty;
      private string _DOS_Year = string.Empty;
      //private string _Is_Result_Expected = string.Empty;
      private string _Procedure_Code_Description = string.Empty;
      private int _Sort_Order = 0;
      //private string _Is_Group = string.Empty;
      //private string _Sub_Rule_Name = string.Empty;
      //private string _From_Date = string.Empty;
      //private string _To_Date = string.Empty;
      //private string _Is_Active = string.Empty;
      //private string _Parent_Rule_ID = string.Empty;
      //private string _Additional_Rule = string.Empty;
      private string _Domain_Object = string.Empty;

      #endregion 

      #region Constructors
      public ProcedureCodeRuleMaster() { }
      #endregion

      #region Methods

      public override int GetHashCode()
      {
          System.Text.StringBuilder sb = new System.Text.StringBuilder();
          sb.Append(this.GetType().FullName);
          sb.Append(_XML_Type);
          sb.Append(_XML_Query);
          sb.Append(_Procedure_Code);
          //sb.Append(_Group_Number);
          sb.Append(_Rule_Name);
          sb.Append(_DOS_Year);
          //sb.Append(_Is_Result_Expected);
          sb.Append(_Procedure_Code_Description);
          sb.Append(_Sort_Order);
          //sb.Append(_Is_Group);
          //sb.Append(_Sub_Rule_Name);
          //sb.Append(_From_Date);
          //sb.Append(_To_Date);
          //sb.Append(_Is_Active);
          //sb.Append(_Parent_Rule_ID);
          //sb.Append(_Additional_Rule);
          sb.Append(_Domain_Object);
          return sb.ToString().GetHashCode();
      }

      #endregion

      #region Properties

      [DataMember]
      public virtual string Domain_Object
      {
          get { return _Domain_Object; }
          set { _Domain_Object = value; }
      }
      [DataMember]
      public virtual string XML_Type
      {
          get { return _XML_Type; }
          set { _XML_Type = value; }
      }
      [DataMember]
      public virtual string XML_Query
      {
          get { return _XML_Query; }
          set { _XML_Query = value; }
      }
      //[DataMember]
      //public virtual string WhereCriteria
      //{
      //    get { return _Where_Criteria; }
      //    set { _Where_Criteria = value; }
      //}
      [DataMember]
      public virtual string Procedure_Code
      {
          get { return _Procedure_Code; }
          set { _Procedure_Code = value; }
      }
      //[DataMember]
      //public virtual int Group_Number
      //{
      //    get { return _Group_Number; }
      //    set { _Group_Number = value; }
      //}


      [DataMember]
      public virtual string Rule_Name
      {
          get { return _Rule_Name; }
          set { _Rule_Name = value; }
      }


      [DataMember]
      public virtual string DOS_Year
      {
          get { return _DOS_Year; }
          set { _DOS_Year = value; }
      }

      //[DataMember]
      //public virtual string Is_Result_Expected
      //{
      //    get { return _Is_Result_Expected; }
      //    set { _Is_Result_Expected = value; }
      //}

      [DataMember]
      public virtual string Procedure_Code_Description
      {
          get { return _Procedure_Code_Description; }
          set { _Procedure_Code_Description = value; }
      }

      [DataMember]
      public virtual int Sort_Order
      {
          get { return _Sort_Order; }
          set { _Sort_Order = value; }
      }


      //[DataMember]
      //public virtual string Is_Group
      //{
      //    get { return _Is_Group; }
      //    set { _Is_Group = value; }
      //}

      //[DataMember]
      //public virtual string Sub_Rule_Name
      //{
      //    get { return _Sub_Rule_Name; }
      //    set { _Sub_Rule_Name = value; }
      //}
      //[DataMember]
      //public virtual string From_Date
      //{
      //    get { return _From_Date; }
      //    set
      //    {
      //        _From_Date = value;
      //    }
      //}
      //[DataMember]
      //public virtual string To_Date
      //{
      //    get { return _To_Date; }
      //    set
      //    {
      //        _To_Date = value;
      //    }
      //}
      
      //[DataMember]
      //public virtual string Is_Active
      //{
      //    get { return _Is_Active; }
      //    set
      //    {
      //        _Is_Active = value;
      //    }
      //}
      //[DataMember]
      //public virtual string Parent_Rule_ID
      //{
      //    get { return _Parent_Rule_ID; }
      //    set
      //    {
      //        _Parent_Rule_ID = value;
      //    }
      //}
      //[DataMember]
      //public virtual string Additional_Rule
      //{
      //    get { return _Additional_Rule; }
      //    set
      //    {
      //        _Additional_Rule = value;
      //    }
      //}
      #endregion

  }
}
