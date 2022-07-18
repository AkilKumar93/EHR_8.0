using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DTO;
using NHibernate;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
     public partial class ObjectBillingManager
    {
         public IList<MyQBilling> resultmyqList = new List<MyQBilling>();
         public IList<MyQBilling> FillMyObjects(string FacName, string[] ObjType, string ProcessType, string UserName, Boolean bShowAll, int DefaultNoofDays)
         {
             ArrayList FavoriteList = null;
             IQuery query1 = null;
             MyQBilling myq = new MyQBilling();
             ISession Mysession = NHibernateSessionManager.Instance.CreateISession();
             try
             {         
              
                 //var fill1 = from f in fillMyQList where (f.ObjTypeList == "ENCOUNTER" || f.ObjTypeList == "DOCUMENTATION" || f.ObjTypeList == "DOCUMENT REVIEW" || f.ObjTypeList == "CHECK OUT" || f.ObjTypeList == "PHONE ENCOUNTER") orderby f.ObjSysId select f.ObjSysId;//|| f.ObjTypeList=="E-PRESCRIBE"
                 //var fill2 = from f in fillMyQList where (f.ObjTypeList == "ENCOUNTER" || f.ObjTypeList == "DOCUMENTATION" || f.ObjTypeList == "DOCUMENT REVIEW" || f.ObjTypeList == "CHECK OUT" || f.ObjTypeList == "PHONE ENCOUNTER") orderby f.ObjSysId select f;
                 //templist = fill1.ToArray<ulong>();
                 //tempMyqlist = fill2.ToList<FillMyQ>();
                 //if (templist.Count() != 0)
                 //{
                 //    query1 = Mysession.GetNamedQuery("FillMyEncounterObjectDetails");
                 //    query1.SetParameterList("List", templist);
                 //    FavoriteList = new ArrayList(query1.List());
                 //    FillDTO(FavoriteList, tempMyqlist);
                 //}

                 //fill1 = from f in fillMyQList where (f.ObjTypeList == "TASK") orderby f.ObjSysId select f.ObjSysId;
                 //fill2 = from f in fillMyQList where (f.ObjTypeList == "TASK") orderby f.ObjSysId select f;
                 //templist = fill1.ToArray<ulong>();
                 //tempMyqlist = fill2.ToList<FillMyQ>();
                 //if (templist.Count() != 0)
                 //{
                 //    query1 = Mysession.GetNamedQuery("FillMyTaskObjectDetails");
                 //    query1.SetParameterList("List", templist);
                 //    FavoriteList = new ArrayList(query1.List());
                 //    FillDTO(FavoriteList, tempMyqlist);
                 //}

                 //fill1 = from f in fillMyQList where ((f.ObjTypeList == "DIAGNOSTIC ORDER" || f.ObjTypeList == "IMAGE ORDER")) orderby f.ObjSysId select f.ObjSysId;
                 //fill2 = from f in fillMyQList where ((f.ObjTypeList == "DIAGNOSTIC ORDER" || f.ObjTypeList == "IMAGE ORDER")) orderby f.ObjSysId select f;
                 //templist = fill1.ToArray<ulong>();
                 //tempMyqlist = fill2.ToList<FillMyQ>();
                 //if (templist.Count() != 0)
                 //{
                 //    query1 = Mysession.GetNamedQuery("FillMyOrderObjectDetails");
                 //    query1.SetParameterList("List", templist);
                 //    FavoriteList = new ArrayList(query1.List());
                 //    FillDTO(FavoriteList, tempMyqlist);
                 //}

                 //fill1 = from f in fillMyQList where (f.ObjTypeList == "SCAN") orderby f.ObjSysId select f.ObjSysId;
                 //fill2 = from f in fillMyQList where (f.ObjTypeList == "SCAN") orderby f.ObjSysId select f;
                 //templist = fill1.ToArray<ulong>();
                 //tempMyqlist = fill2.ToList<FillMyQ>();
                 //if (templist.Count() != 0)
                 //{
                 //    query1 = Mysession.GetNamedQuery("FillMyScanObjectDetails");
                 //    query1.SetParameterList("List", templist);
                 //    FavoriteList = new ArrayList(query1.List());
                 //    FillDTO(FavoriteList, tempMyqlist);
                 //}

                 //added by srividhya
                 if (ObjType.Contains("WORKSET"))
                 {
                     string[] myObjType = new string[1];
                     myObjType[0] = "WORKSET";
                     if (FacName == "ALL")
                     {
                         query1 = Mysession.GetNamedQuery("FillMyWorksetObjectDetails.WithoutFacility");
                     }
                     else
                     {
                         query1 = Mysession.GetNamedQuery("FillMyWorksetObjectDetails.WithFacility");
                         query1.SetString(2, FacName);
                     }
                     query1.SetString(0, UserName);
                     if (ProcessType == "UNASSIGNED")
                     {
                         query1.SetString(1, "UNKNOWN");
                     }
                     else
                     {
                         query1.SetString(1, UserName);
                     }
                     query1.SetParameterList("ObjList", myObjType);
                     FavoriteList = new ArrayList(query1.List());
                     FillDTO(FavoriteList, myObjType);
                 }
                 if (ObjType.Contains("EXCEPTION"))
                 {
                     string[] myObjType = new string[1];
                     myObjType[0] = "EXCEPTION";
                     if (FacName == "ALL")
                     {
                         query1 = Mysession.GetNamedQuery("FillMyExceptionObjectDetails.WithoutFacility");
                     }
                     else
                     {
                         query1 = Mysession.GetNamedQuery("FillMyExceptionObjectDetails.WithFacility");
                         query1.SetString(2, FacName);
                     }
                     query1.SetString(0, UserName);
                     if (ProcessType == "UNASSIGNED")
                     {
                         query1.SetString(1, "UNKNOWN");
                     }
                     else
                     {
                         query1.SetString(1, UserName);
                     }
                     query1.SetParameterList("ObjList", myObjType);
                     FavoriteList = new ArrayList(query1.List());
                     FillDTO(FavoriteList, myObjType);
                 }
                 if (ObjType.Contains("CALL"))
                 {
                     string[] myObjType = new string[1];
                     myObjType[0] = "CALL";
                     if (FacName == "ALL")
                     {
                         query1 = Mysession.GetNamedQuery("FillMyCallObjectDetails.WithoutFacility");
                     }
                     else
                     {
                         query1 = Mysession.GetNamedQuery("FillMyCallObjectDetails.WithFacility");
                         query1.SetString(2, FacName);
                     }
                     query1.SetString(0, UserName);
                     if (ProcessType == "UNASSIGNED")
                     {
                         query1.SetString(1, "UNKNOWN");
                     }
                     else
                     {
                         query1.SetString(1, UserName);
                     }
                     query1.SetParameterList("ObjList", myObjType);
                     FavoriteList = new ArrayList(query1.List());
                     FillDTO(FavoriteList, myObjType);
                 }
                 if (ObjType.Contains("QC_ERROR"))
                 {
                     string[] myObjType = new string[1];
                     myObjType[0] = "QC_ERROR";
                     if (FacName == "ALL")
                     {
                         query1 = Mysession.GetNamedQuery("FillMyQCERRORObjectDetails.WithoutFacility");
                     }
                     else
                     {
                         query1 = Mysession.GetNamedQuery("FillMyQCERRORObjectDetails.WithFacility");
                         query1.SetString(2, FacName);
                     }
                     query1.SetString(0, UserName);
                     if (ProcessType == "UNASSIGNED")
                     {
                         query1.SetString(1, "UNKNOWN");
                     }
                     else
                     {
                         query1.SetString(1, UserName);
                     }
                     query1.SetParameterList("ObjList", myObjType);
                     FavoriteList = new ArrayList(query1.List());
                     FillDTO(FavoriteList, myObjType);
                 }

                 //fill1 = from f in fillMyQList where (f.ObjTypeList == "WORKSET") orderby f.ObjSysId select f.ObjSysId;
                 //fill2 = from f in fillMyQList where (f.ObjTypeList == "WORKSET") orderby f.ObjSysId select f;
                 //templist = fill1.ToArray<ulong>();
                 //tempMyqlist = fill2.ToList<FillMyQ>();
                 //if (templist.Count() != 0)
                 //{
                 //    query1 = Mysession.GetNamedQuery("FillMyBillingDetails.Workset");
                 //    query1.SetParameterList("List", templist);
                 //    FavoriteList = new ArrayList(query1.List());
                 //    FillDTO(FavoriteList, tempMyqlist);
                 //}

                 //fill1 = from f in fillMyQList where (f.ObjTypeList == "CALL") orderby f.ObjSysId select f.ObjSysId;
                 //fill2 = from f in fillMyQList where (f.ObjTypeList == "CALL") orderby f.ObjSysId select f;
                 //templist = fill1.ToArray<ulong>();
                 //tempMyqlist = fill2.ToList<FillMyQ>();
                 //if (templist.Count() != 0)
                 //{
                 //    query1 = Mysession.GetNamedQuery("FillMyBillingDetails.Call");
                 //    query1.SetParameterList("List", templist);
                 //    FavoriteList = new ArrayList(query1.List());
                 //    FillDTO(FavoriteList, tempMyqlist);
                 //}

                 //fill1 = from f in fillMyQList where (f.ObjTypeList == "QC_ERROR") orderby f.ObjSysId select f.ObjSysId;
                 //fill2 = from f in fillMyQList where (f.ObjTypeList == "QC_ERROR") orderby f.ObjSysId select f;
                 //templist = fill1.ToArray<ulong>();
                 //tempMyqlist = fill2.ToList<FillMyQ>();
                 //if (templist.Count() != 0)
                 //{
                 //    query1 = Mysession.GetNamedQuery("FillMyBillingDetails.Qc.Error");
                 //    query1.SetParameterList("List", templist);
                 //    FavoriteList = new ArrayList(query1.List());
                 //    FillDTO(FavoriteList, tempMyqlist);
                 //}

                 //fill1 = from f in fillMyQList where (f.ObjTypeList == "EXCEPTION") orderby f.ObjSysId select f.ObjSysId;
                 //fill2 = from f in fillMyQList where (f.ObjTypeList == "EXCEPTION") orderby f.ObjSysId select f;
                 //templist = fill1.ToArray<ulong>();
                 //tempMyqlist = fill2.ToList<FillMyQ>();
                 //if (templist.Count() != 0)
                 //{
                 //    query1 = Mysession.GetNamedQuery("FillMyBillingDetails.Exception");
                 //    query1.SetParameterList("List", templist);
                 //    FavoriteList = new ArrayList(query1.List());
                 //    FillDTO(FavoriteList, tempMyqlist);
                 //}

                 //fill1 = from f in fillMyQList where (f.ObjTypeList == "RESCAN") orderby f.ObjSysId select f.ObjSysId;
                 //fill2 = from f in fillMyQList where (f.ObjTypeList == "RESCAN") orderby f.ObjSysId select f;
                 //templist = fill1.ToArray<ulong>();
                 //tempMyqlist = fill2.ToList<FillMyQ>();
                 //if (templist.Count() != 0)
                 //{
                 //    query1 = Mysession.GetNamedQuery("FillMyReScanObjectDetails");
                 //    query1.SetParameterList("List", templist);
                 //    FavoriteList = new ArrayList(query1.List());
                 //    FillDTO(FavoriteList, tempMyqlist);
                 //}

                 //fill1 = from f in fillMyQList where (f.ObjTypeList == "INTERNAL ORDER") orderby f.ObjSysId select f.ObjSysId;
                 //fill2 = from f in fillMyQList where (f.ObjTypeList == "INTERNAL ORDER") orderby f.ObjSysId select f;
                 //templist = fill1.ToArray<ulong>();
                 //tempMyqlist = fill2.ToList<FillMyQ>();
                 //if (templist.Count() != 0)
                 //{
                 //    query1 = Mysession.GetNamedQuery("FillMyInternalOrderObjectDetails");
                 //    query1.SetParameterList("List", templist);
                 //    FavoriteList = new ArrayList(query1.List());
                 //    FillDTO(FavoriteList, tempMyqlist);
                 //}

                 //fill1 = from f in fillMyQList where (f.ObjTypeList == "IMMUNIZATION ORDER") orderby f.ObjSysId select f.ObjSysId;
                 //fill2 = from f in fillMyQList where (f.ObjTypeList == "IMMUNIZATION ORDER") orderby f.ObjSysId select f;
                 //templist = fill1.ToArray<ulong>();
                 //tempMyqlist = fill2.ToList<FillMyQ>();
                 //if (templist.Count() != 0)
                 //{
                 //    query1 = Mysession.GetNamedQuery("FillMyImmunizationOrderObjectDetails");
                 //    query1.SetParameterList("List", templist);
                 //    FavoriteList = new ArrayList(query1.List());
                 //    FillDTO(FavoriteList, tempMyqlist);
                 //}

                 //fill1 = from f in fillMyQList where (f.ObjTypeList == "INTERNAL DIAGNOSTIC ORDER" || f.ObjTypeList == "INTERNAL IMAGE ORDER") orderby f.ObjSysId select f.ObjSysId;
                 //fill2 = from f in fillMyQList where (f.ObjTypeList == "INTERNAL DIAGNOSTIC ORDER" || f.ObjTypeList == "INTERNAL IMAGE ORDER") orderby f.ObjSysId select f;
                 //templist = fill1.ToArray<ulong>();
                 //tempMyqlist = fill2.ToList<FillMyQ>();
                 //if (templist.Count() != 0)
                 //{
                 //    query1 = Mysession.GetNamedQuery("FillMyInternalLabImageOrderObjectDetails");
                 //    query1.SetParameterList("List", templist);
                 //    FavoriteList = new ArrayList(query1.List());
                 //    FillDTO(FavoriteList, tempMyqlist);
                 //}
                 //fill1 = from f in fillMyQList where (f.ObjTypeList == "E-PRESCRIBE" || f.ObjTypeList == "E-PRESCRIBE") orderby f.ObjSysId select f.ObjSysId;
                 //fill2 = from f in fillMyQList where (f.ObjTypeList == "E-PRESCRIBE" || f.ObjTypeList == "E-PRESCRIBE") orderby f.ObjSysId select f;
                 //templist = fill1.ToArray<ulong>();
                 //tempMyqlist = fill2.ToList<FillMyQ>();
                 //if (templist.Count() != 0)
                 //{
                 //    query1 = Mysession.GetNamedQuery("FillMyE-PrescriptionObjectDetails");
                 //    query1.SetParameterList("List", templist);
                 //    FavoriteList = new ArrayList(query1.List());
                 //    FillDTO(FavoriteList, tempMyqlist);
                 //}
             }
             finally
             {
                 Mysession.Close();
             }

             return resultmyqList;
         }

         private void FillDTO(ArrayList FavoriteList, string[] ObjType)
         {
             for (int i = 0; i < FavoriteList.Count; i++)
             {
                 object[] oj = (object[])FavoriteList[i];

                 MyQBilling myq = new MyQBilling();
                 
                 if (ObjType.Contains("WORKSET"))
                 {
                     myq.Wf_Object_Id = Convert.ToUInt64(oj[0]);
                     myq.Obj_Type = Convert.ToString(oj[1]);
                     myq.Obj_Sub_Type = Convert.ToString(oj[2]);
                     myq.Current_Process = Convert.ToString(oj[3]);
                     myq.DOOS = Convert.ToString(oj[4]);
                     myq.Batch_Name = Convert.ToString(oj[5]);
                     myq.Sub_Batch_Range = Convert.ToString(oj[6]);
                     myq.Doc_Type = Convert.ToString(oj[7]);
                     myq.Doc_Sub_Type = Convert.ToString(oj[8]);
                     myq.Demos_Enc_PPLine_Rcvd = Convert.ToInt32(oj[9]);
                     myq.Parent_Obj_Type = Convert.ToString(oj[10]);
                     myq.Obj_System_Id = Convert.ToUInt64(oj[11]);
                     myq.Rend_Prov_Id = Convert.ToInt32(oj[12]);
                     myq.Scan_File_Path_Name = Convert.ToString(oj[13]);
                 }
                 else if (ObjType.Contains("CALL"))
                 {
                     myq.Wf_Object_Id = Convert.ToUInt64(oj[0]);
                     myq.Obj_Type = Convert.ToString(oj[1]);
                     myq.Obj_Sub_Type = Convert.ToString(oj[2]);
                     myq.Current_Process = Convert.ToString(oj[3]);
                     myq.DOOS = Convert.ToString(oj[4]);
                     myq.Batch_Name = Convert.ToString(oj[5]);
                     myq.Sub_Batch_Range = Convert.ToString(oj[6]);
                     myq.Doc_Type = Convert.ToString(oj[7]);
                     myq.Doc_Sub_Type = Convert.ToString(oj[8]);
                     myq.Demos_Enc_PPLine_Rcvd = Convert.ToInt32(oj[9]);
                     myq.Parent_Obj_Type = Convert.ToString(oj[10]);
                     myq.Obj_System_Id = Convert.ToUInt64(oj[11]);
                     myq.Insurance_Name = Convert.ToString(oj[12]);
                     myq.Page_Number = Convert.ToInt32(oj[13]);
                 }
                 else if (ObjType.Contains("QC_ERROR"))
                 {
                     myq.Wf_Object_Id = Convert.ToUInt64(oj[0]);
                     myq.Obj_Type = Convert.ToString(oj[1]);
                     myq.Obj_Sub_Type = Convert.ToString(oj[2]);
                     myq.Current_Process = Convert.ToString(oj[3]);
                     myq.DOOS = Convert.ToString(oj[4]);
                     myq.Batch_Name = Convert.ToString(oj[5]);
                     myq.Sub_Batch_Range = Convert.ToString(oj[6]);
                     myq.Doc_Type = Convert.ToString(oj[7]);
                     myq.Doc_Sub_Type = Convert.ToString(oj[8]);
                     myq.Demos_Enc_PPLine_Rcvd = Convert.ToInt32(oj[9]);
                     myq.Parent_Obj_Type = Convert.ToString(oj[10]);
                     myq.Obj_System_Id = Convert.ToUInt64(oj[11]);
                 }
                 else if (ObjType.Contains("EXCEPTION"))
                 {
                     myq.Wf_Object_Id = Convert.ToUInt64(oj[0]);
                     myq.Obj_Type = Convert.ToString(oj[1]);
                     myq.Obj_Sub_Type = Convert.ToString(oj[2]);
                     myq.Current_Process = Convert.ToString(oj[3]);
                     myq.DOOS = Convert.ToString(oj[4]);
                     myq.Batch_Name = Convert.ToString(oj[5]);
                     myq.Sub_Batch_Range = Convert.ToString(oj[6]);
                     myq.Doc_Type = Convert.ToString(oj[7]);
                     myq.Doc_Sub_Type = Convert.ToString(oj[8]);
                     myq.Demos_Enc_PPLine_Rcvd = Convert.ToInt32(oj[9]);
                     myq.Parent_Obj_Type = Convert.ToString(oj[10]);
                     myq.Obj_System_Id = Convert.ToUInt64(oj[11]);
                     //===========
                     myq.Account_Number = Convert.ToUInt64(oj[12]);
                     myq.Patient_Name = Convert.ToString(oj[13]);
                     myq.DOS = Convert.ToString(oj[14]);
                     myq.Procedure_Code = Convert.ToString(oj[15]);
                     myq.Billed_Charge = Convert.ToDecimal(oj[16]);
                     myq.Insurance_Name = Convert.ToString(oj[17]);
                     myq.Doc_Name = Convert.ToString(oj[18]);
                     myq.Facility_Name = Convert.ToString(oj[19]);
                     //============
                 }                 
                 resultmyqList.Add(myq);
             }
         }         
    }
}
