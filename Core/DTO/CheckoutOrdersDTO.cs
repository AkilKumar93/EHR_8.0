using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    [Serializable]
    [DataContract]
   public partial class CheckoutOrdersDTO
   {
       #region Declarations
       private ulong _Order_ID = 0;
       private string _Order_Type = string.Empty;
       private string _labName = string.Empty;
       private string _labLocName = string.Empty;
       private string _Procedure_Code = string.Empty;
       private string _Procedure_Code_Description = string.Empty;
       private string _Authorization_Required = string.Empty;
       private DateTime _Modified_Date_And_Time=DateTime.MinValue;
       private string _To_Physician_Name = string.Empty;
       private string _Reason_For_Referral = string.Empty;
       private string _Specimen_In_House = string.Empty;
       private ulong _specimen_ID = 0;
       private string _specimen = string.Empty;
       private string _To_Facility_Name = string.Empty;


       #endregion

       #region Constructor

       public CheckoutOrdersDTO()
       {
                
       }

       #endregion

       #region Properties

       [DataMember]
       public virtual ulong Order_ID
       {
           get { return _Order_ID; }
           set { _Order_ID = value; }
       }
       [DataMember]
       public virtual string Order_Type
       {
           get { return _Order_Type; }
           set { _Order_Type = value; }
       }
       [DataMember]
       public virtual string labName
       {
           get { return _labName; }
           set { _labName = value; }
       }
       [DataMember]
       public virtual string labLocName
       {
           get { return _labLocName; }
           set { _labLocName = value; }
       }
       [DataMember]
       public virtual string Procedure_Code
       {
           get { return _Procedure_Code; }
           set { _Procedure_Code = value; }
       }
       [DataMember]
       public virtual string Procedure_Code_Description
       {
           get { return _Procedure_Code_Description; }
           set { _Procedure_Code_Description = value; }
       }
       [DataMember]
       public virtual string Authorization_Required
       {
           get { return _Authorization_Required; }
           set { _Authorization_Required = value; }
       }

       [DataMember]
       public virtual DateTime Modified_Date_And_Time
       {
           get { return _Modified_Date_And_Time; }
           set { _Modified_Date_And_Time = value; }
       }
       [DataMember]
       public virtual string To_Physician_Name
       {
           get { return _To_Physician_Name; }
           set { _To_Physician_Name = value; }
       }
       [DataMember]
       public virtual string Reason_For_Referral
       {
           get { return _Reason_For_Referral; }
           set { _Reason_For_Referral = value; }
       }
       [DataMember]
       public virtual string Specimen_In_House
       {
           get { return _Specimen_In_House; }
           set { _Specimen_In_House = value; }
       }
       [DataMember]
       public virtual ulong specimen_ID
       {
           get { return _specimen_ID; }
           set { _specimen_ID = value; }
       }
       [DataMember]
       public virtual string specimen
       {
           get { return _specimen; }
           set { _specimen = value; }
       }
       [DataMember]
       public virtual string To_Facility_Name
       {
           get { return _To_Facility_Name; }
           set { _To_Facility_Name = value; }
       }
        #endregion
    }

}