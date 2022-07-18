using System.Runtime.Serialization;
using System;

namespace Acurus.Capella.Core.DomainObjects
{
      [Serializable]
      [DataContract]
     public partial class ProcessMaster : BusinessBase<ulong>  
    {
        #region Declarations
          private string _Process_Name=string.Empty;
          private string _Process_Type = string.Empty;
          private string _User_Id_Expression = string.Empty;
          private string _Process_Color = string.Empty;
          private string _Scn_Name = string.Empty;
          private string _Tag_Name = string.Empty;
          private string _User_Previlage = string.Empty;
          private string _Wait_Process = string.Empty;
          private string _Is_Encounter_Process = string.Empty;
          private string _Is_Hold_Process = string.Empty;
          private string _Equivalant_Allocation_Process = string.Empty;
          private string _Is_Back_Push_Allowed = string.Empty;
          private string _Is_General_Q_Process = string.Empty;
          private string _Is_Addendum_Allowed = string.Empty;
          private string _Is_Deleted_Process = string.Empty;
        #endregion

        #region Constructors

        public ProcessMaster() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
          System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Process_Name);
            sb.Append(_Process_Type);
            sb.Append(_User_Id_Expression);
            sb.Append(_Process_Color);
            sb.Append(_Scn_Name);
            sb.Append(User_Previlage);
            sb.Append(_Wait_Process);
            sb.Append(_Is_Encounter_Process);
            sb.Append(_Tag_Name);
            sb.Append(_Is_Back_Push_Allowed);
            sb.Append(_Is_General_Q_Process);
            sb.Append(_Is_Addendum_Allowed);
            sb.Append(_Is_Deleted_Process);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

       
          [DataMember]
        public virtual string Process_Name
        {
            get { return _Process_Name; }
            set { _Process_Name = value; }
        }
          [DataMember]
        public virtual string Process_Type
        {
            get { return _Process_Type; }
            set { _Process_Type = value; }
        }
          [DataMember]
        public virtual string User_Id_Expression
        {
            get { return _User_Id_Expression; }
            set { _User_Id_Expression = value; }
        }
          [DataMember]
          public virtual string Process_Color
          {
              get { return _Process_Color; }
              set { _Process_Color = value; }
          }
          [DataMember]
          public virtual string Scn_Name
          {
              get { return _Scn_Name; }
              set { _Scn_Name = value; }
          }
          [DataMember]
          public virtual string Tag_Name
          {
              get { return _Tag_Name; }
              set { _Tag_Name = value; }
          }
          [DataMember]
          public virtual string User_Previlage
          {
              get { return _User_Previlage; }
              set { _User_Previlage = value; }
          }

          [DataMember]
          public virtual string Wait_Process
          {
              get { return _Wait_Process; }
              set { _Wait_Process = value; }
          }

          [DataMember]
          public virtual string Is_Encounter_Process
          {
              get { return _Is_Encounter_Process; }
              set { _Is_Encounter_Process = value; }

          }
          [DataMember]
          public virtual string Is_Hold_Process
          {
              get { return _Is_Hold_Process; }
              set { _Is_Hold_Process = value; }

          }
          [DataMember]
          public virtual string Equivalant_Allocation_Process
          {
              get { return _Equivalant_Allocation_Process; }
              set { _Equivalant_Allocation_Process = value; }

          }
          [DataMember]
          public virtual string Is_Back_Push_Allowed
          {
              get { return _Is_Back_Push_Allowed; }
              set { _Is_Back_Push_Allowed = value; }

          }
          [DataMember]
          public virtual string Is_General_Q_Process
          {
              get { return _Is_General_Q_Process; }
              set { _Is_General_Q_Process = value; }

          }

          [DataMember]
          public virtual string Is_Addendum_Allowed
          {
              get { return _Is_Addendum_Allowed; }
              set { _Is_Addendum_Allowed = value; }

          }
          [DataMember]
          public virtual string Is_Deleted_Process
          {
              get { return _Is_Deleted_Process; }
              set { _Is_Deleted_Process = value; }

          }
        #endregion
    }
}
