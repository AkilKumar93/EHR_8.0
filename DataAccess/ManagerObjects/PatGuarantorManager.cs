using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;
using System.Collections;
using System.Data;
using Acurus.Capella.Core.DTO;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IPatGuarantorManager : IManagerBase<PatGuarantor, ulong>
    {        
        PatGuarantor UpdatePatGuarantor(PatGuarantor objBatchHumanMap);
        IList<PatGuarantor> GetPatGuarantorDetails(int HumanID, int Guarantor_Human_ID);
        PatGuarantor getPatHumanDetailsByID(int PatguarantorID);
    }
    public partial class PatGuarantorManager : ManagerBase<PatGuarantor, ulong>, IPatGuarantorManager
    {
        #region Constructors

        public PatGuarantorManager()
            : base()
        {
        }

        public PatGuarantorManager(INHibernateSession session)
            : base(session)
        {
        }

        #endregion        
        public PatGuarantor UpdatePatGuarantor(PatGuarantor objBatchHumanMap)
        {
            IList<PatGuarantor> PatGuarantorList = new List<PatGuarantor>();
            IList<PatGuarantor> PatGuarantortadd = null;

            PatGuarantorList.Add(objBatchHumanMap);

            if ((PatGuarantorList != null))
            {
                ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
                ICriteria criteriaPatGuarantor = iMySession.CreateCriteria(typeof(PatGuarantor)).Add(Expression.Eq("Human_ID", PatGuarantorList[0].Human_ID)).Add(Expression.Eq("Guarantor_Human_ID", PatGuarantorList[0].Guarantor_Human_ID));
                PatGuarantorList = criteriaPatGuarantor.List<PatGuarantor>();
                iMySession.Close();
                if (PatGuarantorList.Count > 0)
                {
                    PatGuarantorList[0].Active = objBatchHumanMap.Active;
                    SaveUpdateDelete_DBAndXML_WithTransaction(ref PatGuarantortadd, ref PatGuarantorList, null, string.Empty, false, false, 0, "");
                    if (PatGuarantorList != null && PatGuarantorList.Count > 0)
                    {
                        HumanManager HumanMngr = new HumanManager();
                        IList<Human> HumanList = HumanMngr.GetPatientDetailsUsingPatientInformattion(Convert.ToUInt64(PatGuarantorList[0].Human_ID));
                        IList<Human> GuarantorHumanList = HumanMngr.GetPatientDetailsUsingPatientInformattion(Convert.ToUInt64(PatGuarantorList[0].Guarantor_Human_ID));
                        if (HumanList != null && HumanList.Count > 0)
                        {
                            Human ObjHuman = HumanList[0];
                            if (GuarantorHumanList != null && GuarantorHumanList.Count > 0)
                            {
                                Human objGuaHuman = GuarantorHumanList[0];
                                ObjHuman.Guarantor_Birth_Date = objGuaHuman.Birth_Date;
                                ObjHuman.Guarantor_CellPhone_Number = objGuaHuman.Cell_Phone_Number;
                                ObjHuman.Guarantor_City = objGuaHuman.City;
                                ObjHuman.Guarantor_First_Name = objGuaHuman.First_Name;
                                ObjHuman.Guarantor_Home_Phone_Number = objGuaHuman.Home_Phone_No;
                                ObjHuman.Guarantor_Last_Name = objGuaHuman.Last_Name;
                                ObjHuman.Guarantor_MI = objGuaHuman.MI;
                                ObjHuman.Guarantor_Relationship = PatGuarantorList[0].Relationship;
                                ObjHuman.Guarantor_Relationship_No = PatGuarantorList[0].Relationship_No;
                                ObjHuman.Guarantor_Sex = objGuaHuman.Sex;
                                ObjHuman.Guarantor_State = objGuaHuman.State;
                                ObjHuman.Guarantor_Street_Address1 = ObjHuman.Street_Address1;
                                ObjHuman.Guarantor_Street_Address2 = ObjHuman.Street_Address2;
                                ObjHuman.Guarantor_Zip_Code = ObjHuman.ZipCode;
                                if (PatGuarantorList[0].Relationship.ToUpper() == "SELF")
                                {

                                    ObjHuman.Guarantor_Is_Patient = "Y";
                                }
                                else
                                {
                                    ObjHuman.Guarantor_Is_Patient = "N";
                                }
                                if (objBatchHumanMap.Created_By == "gurantor")
                                {
                                    ObjHuman.Created_By = objBatchHumanMap.Created_By;
                                }
                                HumanMngr.UpdateToHuman(ObjHuman, string.Empty);
                            }
                        }
                    }
                    ISession iMySession1 = NHibernateSessionManager.Instance.CreateISession();
                    ICriteria PatGuarantorPrevious = iMySession1.CreateCriteria(typeof(PatGuarantor)).Add(Expression.Eq("Human_ID", PatGuarantorList[0].Human_ID)).AddOrder(Order.Desc("Id"));
                    IList<PatGuarantor> PatGuarantorOldList = PatGuarantorPrevious.List<PatGuarantor>();
                    iMySession1.Close();
                    for (int i = 0; i < PatGuarantorOldList.Count; i++)
                    {
                        if (PatGuarantorOldList[i].Active.ToUpper() == "YES" && PatGuarantorOldList[i].Id != PatGuarantorList[0].Id)
                        {
                            PatGuarantorOldList[i].To_Date = PatGuarantorList[0].Created_Date_And_Time;
                            PatGuarantorOldList[i].Active = "NO";
                            SaveUpdateDelete_DBAndXML_WithTransaction(ref PatGuarantortadd, ref PatGuarantorOldList, null, string.Empty, false, false, 0, "");
                        }
                    }
                }
                // SaveUpdateDeleteWithTransaction(ref PatGuarantortadd, PatGuarantorList, null, string.Empty);
            }
            //iMySession.Close();
            return objBatchHumanMap;
        }        
        public int SaveBatchWithoutTransaction(IList<PatGuarantor> ListToInsert, ISession MySession, string MACAddress)
        {
            MySession = session.GetISession();            
            int iResult = 0;
            IList<PatGuarantor> AddList = null;
            GenerateXml ObjXML = null;
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                if ((ListToInsert != null))
                {
                    ICriteria criteriaPatGuarantor = mySession.CreateCriteria(typeof(PatGuarantor)).Add(Expression.Eq("Human_ID", ListToInsert[0].Human_ID)).Add(Expression.Eq("Guarantor_Human_ID", ListToInsert[0].Guarantor_Human_ID));
                    IList<PatGuarantor> PatGuarantorList = criteriaPatGuarantor.List<PatGuarantor>();
                    if (PatGuarantorList.Count > 0)
                    {
                        ICriteria PatGuarantorPrevious = mySession.CreateCriteria(typeof(PatGuarantor)).Add(Expression.Eq("Human_ID", ListToInsert[0].Human_ID)).AddOrder(Order.Desc("Id"));
                        IList<PatGuarantor> PatGuarantorOldList = PatGuarantorPrevious.List<PatGuarantor>();
                        IList<PatGuarantor> PatGuarantorNewList = new List<PatGuarantor>();
                        iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref AddList, ref ListToInsert, null, MySession, MACAddress, false, false, 0, "", ref ObjXML);

                        if (iResult == 0)
                        {
                            for (int i = 0; i < PatGuarantorOldList.Count; i++)
                            {
                                if (PatGuarantorOldList[i].Active.ToUpper() == "YES" && PatGuarantorOldList[i].Id != ListToInsert[0].Id)
                                {
                                    PatGuarantorOldList[i].To_Date = ListToInsert[0].Created_Date_And_Time;
                                    PatGuarantorOldList[i].Active = "NO";
                                    //CAP-1751 - In Testing & Production - Demographics screen getting crashed
                                    PatGuarantorNewList.Add(PatGuarantorOldList[i]);
                                }
                            }
                            //CAP-1751 - In Testing & Production - Demographics screen getting crashed
                            SaveUpdateDelete_DBAndXML_WithoutTransaction(ref AddList, ref PatGuarantorNewList, null, MySession, MACAddress, false, false, 0, "", ref ObjXML);
                        }

                    }
                    else
                    {
                        IList<PatGuarantor> PatGuarTemp = null;
                        ICriteria PatGuarantorPrevious = mySession.CreateCriteria(typeof(PatGuarantor)).Add(Expression.Eq("Human_ID", ListToInsert[0].Human_ID)).AddOrder(Order.Desc("Id"));
                        IList<PatGuarantor> PatGuarantorOldList = PatGuarantorPrevious.List<PatGuarantor>();
                        iResult = SaveUpdateDelete_DBAndXML_WithoutTransaction(ref ListToInsert, ref PatGuarTemp, null, MySession, MACAddress, false, false, 0, "", ref ObjXML);
                        if (iResult == 0)
                        {
                            if (PatGuarantorOldList.Count > 0 && ListToInsert.Count > 0)
                            {
                                for (int i = 0; i < PatGuarantorOldList.Count; i++)
                                {
                                    if (PatGuarantorOldList[i].Active.ToUpper() == "YES")
                                    {
                                        PatGuarantorOldList[i].To_Date = ListToInsert[0].Created_Date_And_Time;
                                        PatGuarantorOldList[i].Active = "NO";
                                        SaveUpdateDelete_DBAndXML_WithoutTransaction(ref AddList, ref PatGuarantorOldList, null, MySession, MACAddress, false, false, 0, "", ref ObjXML);
                                    }
                                }
                            }
                        }
                    }
                }
                mySession.Close();
            }
            return iResult;
        }
        public IList<PatGuarantor> GetPatGuarantorDetails(int HumanID, int Guarantor_Human_ID)
        {
            IList<PatGuarantor> PatGuarantorList= new List<PatGuarantor>();
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteriaPatGuarantor = mySession.CreateCriteria(typeof(PatGuarantor)).Add(Expression.Eq("Human_ID", HumanID)).Add(Expression.Eq("Guarantor_Human_ID", Guarantor_Human_ID));
                PatGuarantorList = criteriaPatGuarantor.List<PatGuarantor>();
                mySession.Close();
            }
            return PatGuarantorList;
        }
        public DataSet GetHumanPatGuarantorDetails(int HumanID)
        {

            ArrayList arylstGuarantor;           
            DataTable dtblGuarantor = new DataTable();
            dtblGuarantor.Columns.Add("GuarantorID", typeof(string));
            dtblGuarantor.Columns.Add("GuarantorName", typeof(string));
            dtblGuarantor.Columns.Add("GuarantorDOB", typeof(string));
            dtblGuarantor.Columns.Add("HomePhone#", typeof(string));
            dtblGuarantor.Columns.Add("WorkPhone#", typeof(string));
            dtblGuarantor.Columns.Add("Cell Phone#", typeof(string));
            dtblGuarantor.Columns.Add("RelationToPatient", typeof(string));
            dtblGuarantor.Columns.Add("FromDate", typeof(string));
            dtblGuarantor.Columns.Add("ToDate", typeof(string));
            dtblGuarantor.Columns.Add("Active", typeof(string));
            dtblGuarantor.Columns.Add("ID", typeof(string));

            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = mySession.GetNamedQuery("GetPatGuarantorDetails");
                query.SetString(0, HumanID.ToString());
                query.SetString(1, HumanID.ToString());
                arylstGuarantor = new ArrayList(query.List());
                mySession.Close();
            }
            if (arylstGuarantor != null)
            {
                for (int h = 0; h < arylstGuarantor.Count; h++)
                {

                    object[] objlst = (object[])arylstGuarantor[h];
                    DataRow dr = dtblGuarantor.NewRow();
                    if (objlst.Length > 0)
                    {
                        for (int k = 0; k < objlst.Length; k++)
                        {

                            try
                            {
                                if (k == 7 || k == 8)
                                {
                                    if (objlst[k].ToString() != "0001-01-01")
                                    {
                                        dr[k] = objlst[k].ToString();
                                    }
                                    else
                                    {
                                        dr[k] = string.Empty;
                                    }
                                }
                                else
                                {
                                    dr[k] = objlst[k].ToString();
                                }
                            }
                            catch
                            {
                               // string hl;
                            }

                        }
                        dtblGuarantor.Rows.Add(dr);
                    }
                }
            }


            DataSet dsPatGuarantor = new DataSet();
            dsPatGuarantor.Tables.Add(dtblGuarantor);
            return dsPatGuarantor;
        }
        public PatGuarantor getPatHumanDetailsByID(int PatguarantorID)
        {
            IList<PatGuarantor> PatGuarantorList =new List<PatGuarantor>();

            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteriaPatGuarantor = mySession.CreateCriteria(typeof(PatGuarantor)).Add(Expression.Eq("Id", PatguarantorID));
                PatGuarantorList = criteriaPatGuarantor.List<PatGuarantor>();
                mySession.Close();
            }
            return PatGuarantorList[0];
        }
        public int SaveBatchWithTransaction(IList<PatGuarantor> ListToInsert, ISession MySession, string MACAddress)
        {
           
            int iResult = 0;
            IList<PatGuarantor> AddList = null;
           // PatGuarantor objpatGuarantor;
            using (MySession = NHibernateSessionManager.Instance.CreateISession())
            {
                if ((ListToInsert != null))
                {
                    ICriteria criteriaPatGuarantor = MySession.CreateCriteria(typeof(PatGuarantor)).Add(Expression.Eq("Human_ID", ListToInsert[0].Human_ID)).Add(Expression.Eq("Guarantor_Human_ID", ListToInsert[0].Guarantor_Human_ID));
                    IList<PatGuarantor> PatGuarantorList = criteriaPatGuarantor.List<PatGuarantor>();
                    if (PatGuarantorList.Count > 0)
                    {
                        ICriteria PatGuarantorPrevious = MySession.CreateCriteria(typeof(PatGuarantor)).Add(Expression.Eq("Human_ID", ListToInsert[0].Human_ID)).AddOrder(Order.Desc("Id"));
                        IList<PatGuarantor> PatGuarantorOldList = PatGuarantorPrevious.List<PatGuarantor>();
                        SaveUpdateDelete_DBAndXML_WithTransaction(ref AddList, ref ListToInsert, null, MACAddress, false, false, 0, "");
                        if (ListToInsert != null && ListToInsert.Count > 0)
                        {
                            HumanManager HumanMngr = new HumanManager();
                            IList<Human> HumanList = HumanMngr.GetPatientDetailsUsingPatientInformattion(Convert.ToUInt64(ListToInsert[0].Human_ID));
                            IList<Human> GuarantorHumanList = HumanMngr.GetPatientDetailsUsingPatientInformattion(Convert.ToUInt64(ListToInsert[0].Guarantor_Human_ID));
                            if (HumanList != null && HumanList.Count > 0)
                            {
                                Human ObjHuman = HumanList[0];
                                if (GuarantorHumanList != null && GuarantorHumanList.Count > 0)
                                {
                                    Human objGuaHuman = GuarantorHumanList[0];
                                    ObjHuman.Guarantor_Birth_Date = objGuaHuman.Birth_Date;
                                    ObjHuman.Guarantor_CellPhone_Number = objGuaHuman.Cell_Phone_Number;
                                    ObjHuman.Guarantor_City = objGuaHuman.City;
                                    ObjHuman.Guarantor_First_Name = objGuaHuman.First_Name;
                                    ObjHuman.Guarantor_Home_Phone_Number = objGuaHuman.Home_Phone_No;
                                    ObjHuman.Guarantor_Last_Name = objGuaHuman.Last_Name;
                                    ObjHuman.Guarantor_MI = objGuaHuman.MI;
                                    ObjHuman.Guarantor_Relationship = ListToInsert[0].Relationship;
                                    ObjHuman.Guarantor_Relationship_No = ListToInsert[0].Relationship_No;
                                    ObjHuman.Guarantor_Sex = objGuaHuman.Sex;
                                    ObjHuman.Guarantor_State = objGuaHuman.State;
                                    ObjHuman.Guarantor_Street_Address1 = ObjHuman.Street_Address1;
                                    ObjHuman.Guarantor_Street_Address2 = ObjHuman.Street_Address2;
                                    ObjHuman.Guarantor_Zip_Code = ObjHuman.ZipCode;
                                    if (ListToInsert[0].Relationship.ToUpper() == "SELF")
                                    {

                                        ObjHuman.Guarantor_Is_Patient = "Y";
                                    }
                                    else
                                    {
                                        ObjHuman.Guarantor_Is_Patient = "N";
                                    }
                                    HumanMngr.UpdateToHuman(ObjHuman, string.Empty);
                                }
                            }

                        }

                        for (int i = 0; i < PatGuarantorOldList.Count; i++)
                        {
                            if (PatGuarantorOldList[i].Active.ToUpper() == "YES" && PatGuarantorOldList[i].Id != ListToInsert[0].Id)
                            {
                                PatGuarantorOldList[i].To_Date = ListToInsert[0].Created_Date_And_Time;
                                PatGuarantorOldList[i].Active = "NO";
                                SaveUpdateDelete_DBAndXML_WithTransaction(ref AddList, ref PatGuarantorOldList, null, MACAddress, false, false, 0, "");

                            }
                        }



                    }
                    else
                    {
                        ICriteria PatGuarantorPrevious = MySession.CreateCriteria(typeof(PatGuarantor)).Add(Expression.Eq("Human_ID", ListToInsert[0].Human_ID)).AddOrder(Order.Desc("Id"));
                        IList<PatGuarantor> PatGuarantorOldList = PatGuarantorPrevious.List<PatGuarantor>();
                        IList<PatGuarantor> PatGuarTemp = null;
                        SaveUpdateDelete_DBAndXML_WithTransaction(ref ListToInsert, ref PatGuarTemp, null, MACAddress, false, false, 0, "");

                        if (ListToInsert != null && ListToInsert.Count > 0)
                        {
                            HumanManager HumanMngr = new HumanManager();
                            IList<Human> HumanList = HumanMngr.GetPatientDetailsUsingPatientInformattion(Convert.ToUInt64(ListToInsert[0].Human_ID));
                            IList<Human> GuarantorHumanList = HumanMngr.GetPatientDetailsUsingPatientInformattion(Convert.ToUInt64(ListToInsert[0].Guarantor_Human_ID));
                            if (HumanList != null && HumanList.Count > 0)
                            {
                                Human ObjHuman = HumanList[0];
                                if (GuarantorHumanList != null && GuarantorHumanList.Count > 0)
                                {
                                    Human objGuaHuman = GuarantorHumanList[0];
                                    ObjHuman.Guarantor_Birth_Date = objGuaHuman.Birth_Date;
                                    ObjHuman.Guarantor_CellPhone_Number = objGuaHuman.Cell_Phone_Number;
                                    ObjHuman.Guarantor_City = objGuaHuman.City;
                                    ObjHuman.Guarantor_First_Name = objGuaHuman.First_Name;
                                    ObjHuman.Guarantor_Home_Phone_Number = objGuaHuman.Home_Phone_No;
                                    ObjHuman.Guarantor_Last_Name = objGuaHuman.Last_Name;
                                    ObjHuman.Guarantor_MI = objGuaHuman.MI;
                                    ObjHuman.Guarantor_Relationship = ListToInsert[0].Relationship;
                                    ObjHuman.Guarantor_Relationship_No = ListToInsert[0].Relationship_No;
                                    ObjHuman.Guarantor_Sex = objGuaHuman.Sex;
                                    ObjHuman.Guarantor_State = objGuaHuman.State;
                                    ObjHuman.Guarantor_Street_Address1 = ObjHuman.Street_Address1;
                                    ObjHuman.Guarantor_Street_Address2 = ObjHuman.Street_Address2;
                                    ObjHuman.Guarantor_Zip_Code = ObjHuman.ZipCode;
                                    if (ListToInsert[0].Relationship.ToUpper() == "SELF")
                                    {

                                        ObjHuman.Guarantor_Is_Patient = "Y";
                                    }
                                    else
                                    {
                                        ObjHuman.Guarantor_Is_Patient = "N";
                                    }
                                    HumanMngr.UpdateToHuman(ObjHuman, string.Empty);
                                }
                            }
                        }
                        if (PatGuarantorOldList.Count > 0 && ListToInsert.Count > 0)
                        {
                            for (int i = 0; i < PatGuarantorOldList.Count; i++)
                            {
                                if (PatGuarantorOldList[i].Active.ToUpper() == "YES")
                                {
                                    PatGuarantorOldList[i].To_Date = ListToInsert[0].Created_Date_And_Time;
                                    PatGuarantorOldList[i].Active = "NO";
                                    SaveUpdateDelete_DBAndXML_WithTransaction(ref AddList, ref PatGuarantorOldList, null, MACAddress, false, false, 0, "");

                                }

                            }
                        }
                    }
                }
                MySession.Close();
            }
            return iResult;
        }
    }
}
