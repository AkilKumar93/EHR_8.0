using System;
using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Data;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IAuthorizationManager : IManagerBase<Authorization, ulong>
    {
        IList<Authorization> GetAuthDataUsingHumanID(ulong ulHumanId, DateTime dtValidTodate);
        IList<Authorization> GetAuthDataUsingHumanIDForShowAll(ulong ulHumanId);
        IList<Authorization> SaveUpdateDeleteAuthorization(IList<Authorization> SaveAuthorization, IList<Authorization> UpdateAuthorization, IList<Authorization> DeleteAuthorization, ulong ulHumanId, ulong ulEncounterID, bool bIsShowall);
        //Old Code
        IList<Authorization> GetAuthDetailsUsingHumanID(ulong ulHumanId);
        //InsPlanDTO GetInsurancePlanByHumanID(ulong ulHumanID, string PcpId);
        //InsPlanDTO GetPolicyHolderIDAndPCPName(ulong ulHumanID);
        ulong AppendToAuthorization(IList<Authorization> iListAuth, IList<AuthorizationEncounter> iListAuthEnc, IList<AuthorizationICD> iListAuthICD, IList<AuthorizationProcedure> iListAuthProcedure, IList<PatientNotes> ilistPatientNotes, string MacAddress);
        Stream FindAuthDetails(string sInsPlanID, string sPCPID, string sRefToPhyID, string sAccNo, string sAuthNo, string sRefFacility, string InsPlanID, string RefToPhyID, string PCPID);
        AuthorizationDTO GetAuthDetailsUsingAuthID(ulong ulAuthID);
        IList<Authorization> GetAuthDetailsUsingRendProvAndHumanID(ulong iRendProvID, ulong ulHumanId);
        IList<Authorization> GetAuthDetailsByAuthNo(string sAuthNo, ulong ulHumanID);
        IList<Authorization> Addlst(IList<Authorization> Addlst);
        ArrayList GetAuthDetailsCountByDate(string ProviderID, string ApptDate, string HumanID);
        IList<Authorization> UpdateIsActive(IList<Authorization> Updatelst, string MacAddress);
        IList<Authorization> GetAuthorizationRecords(UInt64 AuthId);
        Stream FindAuthDetailsForShowAll(string sInsPlanID, string sPCPID, string sRefToPhyID, string sAccNo, string sAuthNo, string sRefFacility, string InsPlanID, string RefToPhyID, string PCPID);
        ulong UpdateAuthorization(IList<Authorization> iListAuth, IList<AuthorizationEncounter> iListAuthEnc, IList<AuthorizationICD> iListAuthICD, IList<AuthorizationProcedure> iListAuthProcedure, IList<PatientNotes> ilistPatientNotes, string MacAddress);
        string GetPCPName(ulong PatInsId);
        IList<Authorization> GetAuthDetailsByAcnoandDate(string ProviderName, string ApptDate, string AccNo);
        IList<Authorization> GetAuthDetailsByAppDate(string ApptDate, string AccNo);
    }

    public partial class AuthorizationManager : ManagerBase<Authorization, ulong>, IAuthorizationManager
    {
        #region Constructors

        public AuthorizationManager()
            : base()
        {

        }
        public AuthorizationManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        public IList<Authorization> GetAuthDataUsingHumanIDForShowAll(ulong ulHumanId)
        {
            IList<Authorization> ilstAuthorization = new List<Authorization>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(Authorization)).Add(Expression.Eq("Human_ID", ulHumanId)).AddOrder(Order.Desc("Created_Date_And_Time"));//.Add(Expression.Eq("Status", "Valid"))
                ilstAuthorization = criteria.List<Authorization>();
                iMySession.Close();
            }
            return ilstAuthorization;
        }

        public IList<Authorization> GetAuthDataUsingHumanID(ulong ulHumanId, DateTime dtValidTodate)
        {
            IList<Authorization> ilstAuthorization = new List<Authorization>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sqlquery = iMySession.CreateSQLQuery("SELECT e.* FROM authorization e where e.Human_ID=" + ulHumanId + " and Valid_To_Date >='" + dtValidTodate.Date.ToString("yyyy-MM-dd") + "';").AddEntity("e", typeof(Authorization));
                ilstAuthorization = sqlquery.List<Authorization>();
                iMySession.Close();
            }
            return ilstAuthorization;
        }

        public IList<Authorization> SaveUpdateDeleteAuthorization(IList<Authorization> SaveAuthorization, IList<Authorization> UpdateAuthorization, IList<Authorization> DeleteAuthorization, ulong ulHumanId, ulong ulEncounterID, bool bIsShowall)
        {
            IList<Authorization> ilstAuthorization = new List<Authorization>();
            SaveUpdateDelete_DBAndXML_WithTransaction(ref SaveAuthorization, ref UpdateAuthorization, DeleteAuthorization, string.Empty, false, false, 0, string.Empty);
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                //ICriteria criteria = null;
                //criteria = iMySession.CreateCriteria(typeof(Authorization)).Add(Expression.Eq("Human_ID", ulHumanId)).AddOrder(Order.Desc("Created_Date_And_Time"));
                //ilstAuthorization = criteria.List<Authorization>();
                AuthorizationManager objAuth = new AuthorizationManager();
                if (bIsShowall != true)
                {
                    ilstAuthorization = objAuth.GetAuthDataUsingHumanID(ulHumanId, DateTime.Now);
                }
                else
                {
                    ilstAuthorization = objAuth.GetAuthDataUsingHumanIDForShowAll(ulHumanId);
                }

                if (DeleteAuthorization != null && DeleteAuthorization.Count > 0)
                {
                    IList<object> query1 = new List<object>();
                    query1 = iMySession.CreateSQLQuery("delete from authorization_procedure  where Authorization_ID='" + DeleteAuthorization[0].Id + "'").List<object>();
                    // query1 = iMySession.CreateSQLQuery("Update authorization_procedure set Is_Delete='Y',Modified_By='" + DeleteAuthorization[0].Modified_By + "',Modified_Date_And_Time='" + DeleteAuthorization[0].Modified_Date_And_Time.ToString("yyyy-MM-dd hh:mm:ss") + "' where Authorization_ID='" + DeleteAuthorization[0].Authorization_No + "'").List<object>();

                    // IList<object> query2 = new List<object>();
                    // query1 = iMySession.CreateSQLQuery("delete from authorization_encounter where Authorization_ID='" + DeleteAuthorization[0].Id + "'").List<object>();
                    //// query2 = iMySession.CreateSQLQuery("Update authorization_encounter set Is_Delete='Y',Modified_By='" + DeleteAuthorization[0].Modified_By + "',Modified_Date_And_Time='" + DeleteAuthorization[0].Modified_Date_And_Time.ToString("yyyy-MM-dd hh:mm:ss") + "' where Authorization_ID='" + DeleteAuthorization[0].Authorization_No + "'").List<object>();
                }
                iMySession.Close();
            }


            //ISQLQuery sqlquery = session.GetISession().CreateSQLQuery("select * from authorization where Human_Id=" + ulHumanId + " and status='valid';").AddEntity(typeof(Authorization));
            //    ilstAuthorization = sqlquery.List<Authorization>();
            return ilstAuthorization;
        }


        //Old Code
        public IList<Authorization> GetAuthDetailsUsingHumanID(ulong ulHumanId)
        {
            IList<Authorization> ilstAuthorization = new List<Authorization>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria = iMySession.CreateCriteria(typeof(Authorization)).Add(Expression.Eq("Human_ID", ulHumanId)).Add(Expression.Eq("Is_Active", "Y"));
                ilstAuthorization = criteria.List<Authorization>();
                iMySession.Close();
            }
            return ilstAuthorization;
        }

        //public InsPlanDTO GetInsurancePlanByHumanID(ulong ulHumanID, string PcpId)
        //{
        //    InsPlanDTO objPlan = new InsPlanDTO();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        IQuery query = iMySession.GetNamedQuery("GetPrimaryInsurance");



        //        query.SetString(1, ulHumanID.ToString());
        //        query.SetString(0, PcpId);
        //        ArrayList arry = new ArrayList();
        //        arry = new ArrayList(query.List());
        //        if (arry != null && arry.Count > 0)
        //        {
        //            foreach (object[] obj in arry)
        //            {
        //                objPlan = new InsPlanDTO();
        //                if (obj[2] != null)
        //                {
        //                    objPlan.InsPlan = obj[2].ToString();
        //                }
        //                if (obj[3] != null)
        //                {
        //                    objPlan.PolicyHolderID = obj[3].ToString();
        //                }
        //                if (obj[0] != null)
        //                {
        //                    objPlan.PCPName = obj[0].ToString();
        //                }
        //                if (obj[1] != null)
        //                {
        //                    objPlan.InsPlanID = Convert.ToUInt32(obj[1].ToString());
        //                }
        //                if (obj[4] != null)
        //                {
        //                    objPlan.PCPID = Convert.ToUInt32(obj[4].ToString());
        //                }




        //            }
        //        }
        //        iMySession.Close();
        //    }
        //    //}

        //    return objPlan;
        //}

        //public InsPlanDTO GetPolicyHolderIDAndPCPName(ulong ulHumanID)
        //{
        //    InsPlanDTO InsDTO = new InsPlanDTO();
        //    using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
        //    {
        //        IQuery sql = iMySession.GetNamedQuery("GetPolicyHolderIDAndPCPName");
        //        sql.SetString(0, Convert.ToString(ulHumanID));

        //        ArrayList arlist = new ArrayList(sql.List());
        //        if (arlist != null && arlist.Count > 0)
        //        {
        //            foreach (object[] obj in arlist)
        //            {
        //                if (obj[2] != null)
        //                {
        //                    InsDTO.PolicyHolderID = obj[2].ToString();
        //                }
        //                if (obj[3] != null)
        //                {
        //                    InsDTO.PCPName = obj[3].ToString();
        //                }
        //                InsDTO.InsPlanID = Convert.ToUInt32(obj[1]);
        //                InsDTO.PCPID = Convert.ToUInt32(obj[4]);
        //            }
        //        }
        //        iMySession.Close();
        //    }
        //    return InsDTO;
        //}
        public string GetPCPName(ulong PatInsId)
        {
            string PcpName = null;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery sql = iMySession.GetNamedQuery("GetPCP");
                sql.SetString(0, Convert.ToString(PatInsId));

                ArrayList arlist = new ArrayList(sql.List());
                if (arlist != null && arlist.Count > 0)
                {
                    if (arlist[0] != null)
                    {
                        PcpName = arlist[0].ToString();
                    }

                }
                iMySession.Close();
            }

            return PcpName;
        }

        int iTryCount = 0;
        public ulong AppendToAuthorization(IList<Authorization> iListAuth, IList<AuthorizationEncounter> iListAuthEnc, IList<AuthorizationICD> iListAuthICD, IList<AuthorizationProcedure> iListAuthProcedure, IList<PatientNotes> ilistPatientNotes, string MacAddress)
        {
            ISession MySession = Session.GetISession();
            ITransaction trans = null;
            trans = MySession.BeginTransaction();
            bool bResult = false;
            //ulong ReturnID = 0;
            int iResult = 0;
        TryAgain:
            try
            {
                //IList<CallLog> iListCallLog = new List<CallLog>();
                //iListCallLog.Add(objCallLog);
                //iResult = SaveUpdateDeleteWithoutTransaction(ref iListAuth, null, null, MySession, MacAddress);
                if (iResult == 2)
                {
                    if (iTryCount < 5)
                    {
                        iTryCount++;
                        goto TryAgain;
                    }
                    else
                    {
                        trans.Rollback();
                        //MySession.Close();
                        throw new Exception("Deadlock is occured. Transaction failed");
                    }
                }
                else if (iResult == 1)
                {
                    trans.Rollback();
                    //MySession.Close();
                    throw new Exception("Exception is occured. Transaction failed");
                }
                if (iListAuthEnc.Count > 0)
                {
                    for (int m = 0; m < iListAuthEnc.Count; m++)
                    {
                        iListAuthEnc[m].Authorization_ID = iListAuth[0].Id;
                    }
                    AuthorizationEncounterManager AuthEncMngr = new AuthorizationEncounterManager();
                    //IList<AuthorizationEncounter> ilstAuthEnc = null;
                    //iResult = AuthEncMngr.SaveUpdateDeleteWithoutTransaction(ref ilstAuthEnc, iListAuthEnc, null, MySession, MacAddress);
                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {
                            trans.Rollback();
                            //MySession.Close();
                            throw new Exception("Deadlock is occured. Transaction failed");
                        }
                    }
                    else if (iResult == 1)
                    {
                        trans.Rollback();
                        //MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");
                    }
                }
                if (iListAuthICD.Count > 0)
                {
                    for (int m = 0; m < iListAuthICD.Count; m++)
                    {
                        iListAuthICD[m].Authorization_ID = iListAuth[0].Id;
                    }
                    AuthorizationICDManager AuthICDMngtr = new AuthorizationICDManager();
                   // IList<AuthorizationICD> ilstAuthICd = null;
                    //iResult = AuthICDMngtr.SaveUpdateDeleteWithoutTransaction(ref ilstAuthICd, iListAuthICD, null, MySession, MacAddress);
                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {
                            trans.Rollback();
                            //MySession.Close();
                            throw new Exception("Deadlock is occured. Transaction failed");
                        }
                    }
                    else if (iResult == 1)
                    {
                        trans.Rollback();
                        //MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");
                    }
                }
                if (iListAuthProcedure.Count > 0)
                {
                    for (int m = 0; m < iListAuthProcedure.Count; m++)
                    {
                        iListAuthProcedure[m].Authorization_ID = iListAuth[0].Id;
                    }
                    AuthorizationProcedureManager AuthProcMngr = new AuthorizationProcedureManager();
                    //IList<AuthorizationProcedure> ilstAuthProc = null;
                    //iResult = AuthProcMngr.SaveUpdateDeleteWithoutTransaction(ref ilstAuthProc, iListAuthProcedure, null, MySession, MacAddress);
                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {
                            trans.Rollback();
                            //MySession.Close();
                            throw new Exception("Deadlock is occured. Transaction failed");
                        }
                    }
                    else if (iResult == 1)
                    {
                        trans.Rollback();
                        //MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");
                    }
                }
                if (ilistPatientNotes.Count > 0)
                {
                    ilistPatientNotes[0].SourceID = Convert.ToInt16(iListAuth[0].Id);
                    PatientNotesManager objPatientNotesMngr = new PatientNotesManager();
                    //iResult = objPatientNotesMngr.SaveUpdateDeleteWithoutTransaction(ref ilistPatientNotes, null, null, MySession, MacAddress);
                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {
                            trans.Rollback();
                            //MySession.Close();
                            throw new Exception("Deadlock is occured. Transaction failed");
                        }
                    }
                    else if (iResult == 1)
                    {
                        trans.Rollback();
                        //MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");
                    }
                }
                if ((ilistPatientNotes.Count > 0) && (ilistPatientNotes != null))
                {

                    //iListAuth[0].Authorization_Notes = ilistPatientNotes[0].Id.ToString();
                    //IList<Authorization> ilist = null;
                    //iResult = SaveUpdateDeleteWithoutTransaction(ref ilist, iListAuth, null, MySession, MacAddress);
                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {
                            trans.Rollback();
                            //MySession.Close();
                            throw new Exception("Deadlock is occured. Transaction failed");
                        }
                    }
                    else if (iResult == 1)
                    {
                        trans.Rollback();
                        //MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");
                    }
                }
                MySession.Flush();
                trans.Commit();
            }
            catch (NHibernate.Exceptions.GenericADOException ex)
            {
                trans.Rollback();
                // MySession.Close();
                //CAP-1942
                throw new Exception(ex.Message,ex);
            }
            catch (Exception e)
            {
                trans.Rollback();
                //MySession.Close();
                //CAP-1942
                throw new Exception(e.Message, e);
            }
            finally
            {
                MySession.Close();
            }
            return iListAuth[0].Id;
        }

        public Stream FindAuthDetails(string sInsPlanID, string sPCPID, string sRefToPhyID, string sAccNo, string sAuthNo, string sRefFacility, string InsPlanID, string RefToPhyID, string PCPID)
        {
            var stream = new MemoryStream();
            var serializer = new NetDataContractSerializer();
            ArrayList ary = null;
            ArrayList ary2 = null;
            IQuery query1 = null;
            IQuery query2 = null;
            int count = 0;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                query1 = iMySession.GetNamedQuery("Find.Authorization.Details");

                query1.SetString(0, sInsPlanID.ToString() + "%");
                query1.SetString(1, sPCPID.ToString() + "%");
                query1.SetString(2, sRefToPhyID.ToString() + "%");
                query1.SetString(3, sAccNo.ToString());
                query1.SetString(4, sAuthNo + "%");
                query1.SetString(5, sRefFacility + "%");
                query1.SetString(6, sInsPlanID.ToString() + "%");
                query1.SetString(7, sRefToPhyID.ToString() + "%");
                query1.SetString(8, sPCPID.ToString() + "%");

                ary = new ArrayList(query1.List());
                string sProcedure = string.Empty;
                DataSet ds = new DataSet();
                DataRow dr = null;
                //DataRow Proceduredr = null;
                DataTable dt = new DataTable();
                DataTable Proceduredt = new DataTable();
                string sICD = string.Empty;
                if (ary.Count != 0)
                {
                    Proceduredt.Columns.Add("AuthID", typeof(string));
                    Proceduredt.Columns.Add("AccountNo", typeof(string));
                    Proceduredt.Columns.Add("PatientName", typeof(string));
                    Proceduredt.Columns.Add("DOB", typeof(string));
                    Proceduredt.Columns.Add("AuthNo", typeof(string));
                    //dt.Columns.Add("FromDate", typeof(string));
                    //dt.Columns.Add("ToDate", typeof(string));
                    Proceduredt.Columns.Add("EffectiveDate", typeof(string));
                    Proceduredt.Columns.Add("CPT", typeof(string));
                    Proceduredt.Columns.Add("InsPlanName", typeof(string));
                    Proceduredt.Columns.Add("PCPName", typeof(string));
                    Proceduredt.Columns.Add("ReferredToPhysician", typeof(string));
                    Proceduredt.Columns.Add("ReferredToSpecialty", typeof(string));
                    Proceduredt.Columns.Add("ReferredToFacility", typeof(string));
                    Proceduredt.Columns.Add("Diagnosis", typeof(string));
                    Proceduredt.Columns.Add("VisitsApproved", typeof(string));
                    Proceduredt.Columns.Add("VisitsRemaining", typeof(string));
                    Proceduredt.Columns.Add("Is_Active", typeof(string));

                    AuthorizationICDManager AuthICDMngr = new AuthorizationICDManager();
                    IList<AuthorizationICD> AuthICDList = new List<AuthorizationICD>();
                    AuthorizationICD AuthICDRecord = new AuthorizationICD();

                    for (int i = 0; i < ary.Count; i++)
                    {
                        object[] obj = (object[])ary[i];

                        dr = Proceduredt.NewRow();

                        object[] objproc = (object[])ary[i];
                        if (objproc[11] != null && objproc[11].ToString() != "")
                        {
                            query2 = iMySession.GetNamedQuery("Get.ProcedureDetails");
                            query2.SetString(0, objproc[11].ToString());
                            sProcedure = "";
                            ary2 = new ArrayList(query2.List());
                            if (ary2.Count != 0)
                            {
                                for (int iNumber = 0; iNumber < ary2.Count; iNumber++)
                                {
                                    object[] Procobj = (object[])ary2[iNumber];
                                    //Proceduredr = dt.NewRow();
                                    if (Procobj[2].ToString() != "")
                                    {
                                        if (sProcedure == "")
                                        {
                                            sProcedure = "(" + Procobj[1].ToString() + " " + "-" + Procobj[0].ToString() + ")" + "    " + "   " + "  " + "(" + Procobj[2].ToString() + " " + "-" + Procobj[3].ToString() + ")";
                                        }
                                        else
                                        {
                                            sProcedure = sProcedure + "(" + Procobj[1].ToString() + " " + "-" + Procobj[0].ToString() + ")" + "    " + "   " + "  " + "(" + Procobj[2].ToString() + " " + "-" + Procobj[3].ToString() + ")";
                                        }
                                        //dt.Rows.Add(Proceduredr);
                                    }
                                    else
                                    {
                                        if (sProcedure == "")
                                        {
                                            sProcedure = "(" + Procobj[1].ToString() + " " + "-" + Procobj[0].ToString();
                                        }
                                        else
                                        {
                                            sProcedure = sProcedure + "(" + Procobj[1].ToString() + " " + "-" + Procobj[0].ToString();
                                        }
                                    }

                                }
                            }

                        }
                        dr["CPT"] = sProcedure;
                        dr["AuthID"] = Convert.ToUInt32(obj[11]);
                        dr["AccountNo"] = Convert.ToUInt32(obj[0]);
                        dr["PatientName"] = obj[1].ToString();
                        dr["DOB"] = obj[2].ToString();
                        dr["AuthNo"] = obj[3].ToString();
                        //dr["FromDate"] = (obj[4]).ToString("DD-MM-YYYY");
                        //dr["ToDate"] = obj[5].ToString();
                        dr["EffectiveDate"] = ((Convert.ToDateTime(obj[4])).ToString("dd-MMM-yyyy")) + " " + "-" + " " + (obj[5]).ToString();

                        if (obj[14] != null && obj[14].ToString() != "")
                        {
                            dr["InsPlanName"] = obj[14].ToString();
                        }
                        if (obj[15] != null && obj[15].ToString() != "")
                        {
                            dr["PCPName"] = obj[15].ToString();
                        }
                        else
                        {
                            dr["PCPName"] = "";
                        }
                        if (obj[16] != null && obj[16].ToString() != "")
                        {
                            dr["ReferredToPhysician"] = obj[16].ToString();
                        }
                        if (obj[6] != null && obj[6].ToString() != "")
                        {
                            dr["ReferredToSpecialty"] = obj[6].ToString();
                        }
                        if (obj[7] != null && obj[7].ToString() != "")
                        {
                            dr["ReferredToFacility"] = obj[7].ToString();
                        }

                        AuthICDList = AuthICDMngr.GetAuthICDDetailsUsingAuthID(Convert.ToUInt32(obj[11]));
                        sICD = "";
                        if (AuthICDList.Count > 0)
                        {
                            for (int j = 0; j < AuthICDList.Count; j++)
                            {
                                AuthICDRecord = AuthICDList[j];
                                if (sICD == "")
                                {
                                    sICD = AuthICDRecord.ICD;
                                }
                                else
                                {
                                    sICD = sICD + "," + AuthICDRecord.ICD;
                                }
                            }
                        }

                        dr["Diagnosis"] = sICD;
                        dr["VisitsApproved"] = obj[8].ToString();
                        dr["VisitsRemaining"] = obj[9].ToString();
                        dr["Is_Active"] = obj[10].ToString();
                        Proceduredt.Rows.Add(dr);


                    }
                }

                ds.Tables.Add(Proceduredt);

                Hashtable hsResult = new Hashtable();
                hsResult.Add("AuthList", Proceduredt);

                hsResult.Add("TotalCount", ary.Count);

                serializer.WriteObject(stream, hsResult);
                stream.Seek(0L, SeekOrigin.Begin);
                iMySession.Close();
            }
            return stream;

        }

        public Stream FindAuthDetailsForShowAll(string sInsPlanID, string sPCPID, string sRefToPhyID, string sAccNo, string sAuthNo, string sRefFacility, string InsPlanID, string RefToPhyID, string PCPID)
        {
            var stream = new MemoryStream();
            var serializer = new NetDataContractSerializer();
            ArrayList ary = null;
            ArrayList ary2 = null;
            IQuery query1 = null;
            IQuery query2 = null;
            //int count = 0;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                query1 = iMySession.GetNamedQuery("Find.Authorization.DetailsForShowAll");

                query1.SetString(0, sInsPlanID.ToString() + "%");
                query1.SetString(1, sPCPID.ToString() + "%");
                query1.SetString(2, sRefToPhyID.ToString() + "%");
                query1.SetString(3, sAccNo.ToString());
                query1.SetString(4, sAuthNo + "%");
                query1.SetString(5, sRefFacility + "%");
                query1.SetString(6, sInsPlanID.ToString() + "%");
                query1.SetString(7, sRefToPhyID.ToString() + "%");
                query1.SetString(8, sPCPID.ToString() + "%");

                ary = new ArrayList(query1.List());

                DataSet ds = new DataSet();
                DataRow dr = null;
                //DataRow Proceduredr = null;
                DataTable dt = new DataTable();
                DataTable Proceduredt = new DataTable();

                if (ary.Count != 0)
                {
                    Proceduredt.Columns.Add("AuthID", typeof(string));
                    Proceduredt.Columns.Add("AccountNo", typeof(string));
                    Proceduredt.Columns.Add("PatientName", typeof(string));
                    Proceduredt.Columns.Add("DOB", typeof(string));
                    Proceduredt.Columns.Add("AuthNo", typeof(string));
                    //dt.Columns.Add("FromDate", typeof(string));
                    //dt.Columns.Add("ToDate", typeof(string));
                    Proceduredt.Columns.Add("EffectiveDate", typeof(string));
                    Proceduredt.Columns.Add("CPT", typeof(string));
                    Proceduredt.Columns.Add("InsPlanName", typeof(string));
                    Proceduredt.Columns.Add("PCPName", typeof(string));
                    Proceduredt.Columns.Add("ReferredToPhysician", typeof(string));
                    Proceduredt.Columns.Add("ReferredToSpecialty", typeof(string));
                    Proceduredt.Columns.Add("ReferredToFacility", typeof(string));
                    Proceduredt.Columns.Add("Diagnosis", typeof(string));
                    Proceduredt.Columns.Add("VisitsApproved", typeof(string));
                    Proceduredt.Columns.Add("VisitsRemaining", typeof(string));
                    Proceduredt.Columns.Add("Is_Active", typeof(string));

                    AuthorizationICDManager AuthICDMngr = new AuthorizationICDManager();
                    IList<AuthorizationICD> AuthICDList = new List<AuthorizationICD>();
                    AuthorizationICD AuthICDRecord = new AuthorizationICD();

                    string sICD = string.Empty;

                    for (int i = 0; i < ary.Count; i++)
                    {
                        object[] obj = (object[])ary[i];

                        dr = Proceduredt.NewRow();

                        object[] objproc = (object[])ary[i];
                        if (objproc[11] != null && objproc[11].ToString() != "")
                        {
                            query2 = iMySession.GetNamedQuery("Get.ProcedureDetails");
                            query2.SetString(0, objproc[11].ToString());


                            ary2 = new ArrayList(query2.List());
                            if (ary2.Count != 0)
                            {
                                object[] Procobj = (object[])ary2[0];
                                //Proceduredr = dt.NewRow();
                                dr["CPT"] = "(" + Procobj[1].ToString() + " " + "-" + Procobj[0].ToString() + ")" + "    " + "   " + "  " + "(" + Procobj[2].ToString() + " " + "-" + Procobj[3].ToString() + ")";
                                //dt.Rows.Add(Proceduredr);

                            }

                        }

                        dr["AuthID"] = Convert.ToUInt32(obj[11]);
                        dr["AccountNo"] = Convert.ToUInt32(obj[0]);
                        dr["PatientName"] = obj[1].ToString();
                        dr["DOB"] = obj[2].ToString();
                        dr["AuthNo"] = obj[3].ToString();
                        //dr["FromDate"] = obj[4].ToString();
                        //dr["ToDate"] = obj[5].ToString();
                        dr["EffectiveDate"] = obj[4].ToString() + " " + "-" + " " + obj[5].ToString();
                        if (obj[14] != null && obj[14].ToString() != "")
                        {
                            dr["InsPlanName"] = obj[14].ToString();
                        }
                        if (obj[15] != null && obj[15].ToString() != "")
                        {
                            dr["PCPName"] = obj[15].ToString();
                        }
                        else
                        {
                            dr["PCPName"] = "";
                        }
                        if (obj[16] != null && obj[16].ToString() != "")
                        {
                            dr["ReferredToPhysician"] = obj[16].ToString();
                        }
                        if (obj[6] != null && obj[6].ToString() != "")
                        {
                            dr["ReferredToSpecialty"] = obj[6].ToString();
                        }
                        if (obj[7] != null && obj[7].ToString() != "")
                        {
                            dr["ReferredToFacility"] = obj[7].ToString();
                        }

                        sICD = "";
                        AuthICDList = AuthICDMngr.GetAuthICDDetailsUsingAuthID(Convert.ToUInt32(obj[11]));
                        if (AuthICDList.Count > 0)
                        {
                            for (int j = 0; j < AuthICDList.Count; j++)
                            {
                                AuthICDRecord = AuthICDList[j];
                                if (sICD == "")
                                {
                                    sICD = AuthICDRecord.ICD;
                                }
                                else
                                {
                                    sICD = sICD + "," + AuthICDRecord.ICD;
                                }
                            }
                        }

                        dr["Diagnosis"] = sICD;
                        dr["VisitsApproved"] = obj[8].ToString();
                        dr["VisitsRemaining"] = obj[9].ToString();
                        dr["Is_Active"] = obj[10].ToString();
                        Proceduredt.Rows.Add(dr);


                    }
                }

                ds.Tables.Add(Proceduredt);

                Hashtable hsResult = new Hashtable();
                hsResult.Add("AuthList", Proceduredt);

                hsResult.Add("TotalCount", ary.Count);

                serializer.WriteObject(stream, hsResult);
                stream.Seek(0L, SeekOrigin.Begin);
                iMySession.Close();
            }
            return stream;

        }

        public AuthorizationDTO GetAuthDetailsUsingAuthID(ulong ulAuthID)
        {
            IList<Authorization> AuthList = new List<Authorization>();
            IList<AuthorizationEncounter> AuthEncList = new List<AuthorizationEncounter>();
            IList<AuthorizationICD> AuthICDList = new List<AuthorizationICD>();
            IList<AuthorizationProcedure> AuthProcList = new List<AuthorizationProcedure>();
            AuthorizationDTO AuthDTO = new AuthorizationDTO();
            Authorization AuthRecord = new Authorization();
            AuthorizationICDManager AuthICDMngr = new AuthorizationICDManager();
            AuthorizationProcedureManager AuthProcMngr = new AuthorizationProcedureManager();
            AuthorizationEncounterManager AuthEncMngr = new AuthorizationEncounterManager();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria;

                criteria = iMySession.CreateCriteria(typeof(Authorization)).Add(Expression.Eq("Id", ulAuthID));
                AuthList = criteria.List<Authorization>();

                if (AuthList.Count > 0)
                {
                    AuthRecord = AuthList[0];

                    AuthDTO.ilstAuthorization = AuthList;

                    AuthEncList = AuthEncMngr.GetAuthdetailsByAuthID(AuthRecord.Id);
                    AuthDTO.ilstAuthorizationEncounter = AuthEncList;

                    AuthICDList = AuthICDMngr.GetAuthICDDetailsUsingAuthID(AuthRecord.Id);
                    AuthDTO.ilstAuthorizationICD = AuthICDList;

                    AuthProcList = AuthProcMngr.GetAuthProcDetailsUsingAuthID(AuthRecord.Id);
                    AuthDTO.ilstAuthorizationProcedure = AuthProcList;
                }
                iMySession.Close();
            }

            return AuthDTO;
        }

        public AuthorizationDTO GetAuthorizationAppointmentDetails(ulong ulEncounterID, ulong ulAuthID, ulong ulEncounID)
        {
            AuthorizationDTO AuthDTO = new AuthorizationDTO();
            ArrayList ary = null;
            IQuery query1 = null;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                query1 = iMySession.GetNamedQuery("Find.Authorization.Appointment");

                query1.SetString(0, ulEncounterID.ToString());

                query1.SetString(1, ulAuthID.ToString());
                query1.SetString(2, ulEncounID.ToString());



                ary = new ArrayList(query1.List());

                AuthDTO.AuthApptTotalCount = ary.Count;

                if (ary.Count > 0)
                {
                    for (int i = 0; i < ary.Count; i++)
                    {
                        object[] obj = (object[])ary[i];
                        AuthDTO.EncounterDate.Add(Convert.ToDateTime(obj[0]));
                        //AuthDTO.Human_ID.Add(Convert.ToUInt32(obj[1]));
                        //AuthDTO.PatientName.Add(obj[2].ToString());
                        //AuthDTO.PatientDOB.Add(Convert.ToDateTime(obj[3]));
                        AuthDTO.PhysicianName.Add(obj[1].ToString());
                        AuthDTO.FacilityName.Add(obj[2].ToString());
                        //AuthDTO.CurrProcess.Add(obj[6].ToString());
                    }
                }
                iMySession.Close();
            }

            return AuthDTO;
        }

        public IList<Authorization> GetAuthDetailsUsingRendProvAndHumanID(ulong iRendProvID, ulong ulHumanId)
        {
            IList<Authorization> AuthList = new List<Authorization>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria;

                criteria = iMySession.CreateCriteria(typeof(Authorization)).Add(Expression.Eq("Referred_To_Provider_ID", iRendProvID)).Add(Expression.Eq("Human_ID", ulHumanId)).Add(Expression.Eq("Is_Active", "Y"));
                AuthList = criteria.List<Authorization>();
                iMySession.Close();
            }
            return AuthList;
        }

        public IList<Authorization> GetAuthDetailsByAuthNo(string sAuthNo, ulong ulHumanID)
        {
            IList<Authorization> AuthList = new List<Authorization>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria;

                criteria = iMySession.CreateCriteria(typeof(Authorization)).Add(Expression.Eq("Auth_No", sAuthNo)).Add(Expression.Eq("Human_ID", ulHumanID)).Add(Expression.Eq("Is_Active", "Y"));
                AuthList = criteria.List<Authorization>();
                iMySession.Close();
            }

            return AuthList;
        }
        public IList<Authorization> Addlst(IList<Authorization> Addlst)
        {
            IList<Authorization> SaveList = new List<Authorization>();
            Authorization objAuthorization = null;

            for (int i = 0; i < Addlst.Count; i++)
            {

                objAuthorization = new Authorization();

                //objAuthorization.Human_ID = Addlst[i].Human_ID;
                //objAuthorization.Referred_To_Provider_ID = Addlst[i].Referred_To_Provider_ID;
                //objAuthorization.Referred_To_Facility = Addlst[i].Referred_To_Facility;
                //objAuthorization.Referred_To_Specialty = Addlst[i].Referred_To_Specialty;
                //objAuthorization.PCP_ID = Addlst[i].PCP_ID;
                //objAuthorization.Insurance_Plan_ID = Addlst[i].Insurance_Plan_ID;
                //objAuthorization.Auth_No = Addlst[i].Auth_No;
                //objAuthorization.From_Date = Addlst[i].From_Date;
                //objAuthorization.To_Date = Addlst[i].To_Date;
                //objAuthorization.Number_Of_Visits_Requested = Addlst[i].Number_Of_Visits_Requested;
                //objAuthorization.Number_Of_Visits_Approved = Addlst[i].Number_Of_Visits_Approved;
                //objAuthorization.Number_Of_Visits_Used = Addlst[i].Number_Of_Visits_Used;
                //objAuthorization.Authorization_Notes = Addlst[i].Authorization_Notes;
                //objAuthorization.Request_Date = Addlst[i].Request_Date;
                //objAuthorization.Authorization_Status = Addlst[i].Authorization_Status;
                //objAuthorization.Created_By = Addlst[i].Created_By;
                //objAuthorization.Created_Date_And_Time = Addlst[i].Created_Date_And_Time;


                SaveList.Add(objAuthorization);


            }
            ISession MySession = Session.GetISession();

            //SaveUpdateDeleteWithoutTransaction(ref SaveList, null, null, MySession, string.Empty);
            return SaveList;

        }

        public IList<Authorization> GetAuthorizationRecords(UInt64 AuthId)
        {
            IList<Authorization> AuthList = new List<Authorization>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria;

                criteria = iMySession.CreateCriteria(typeof(Authorization)).Add(Expression.Eq("Id", AuthId));
                AuthList = criteria.List<Authorization>();
                iMySession.Close();
            }

            return AuthList;
        }



        public IList<Authorization> UpdateIsActive(IList<Authorization> Updatelst, string MacAddress)
        {
            IList<Authorization> List = new List<Authorization>();
            //SaveUpdateDeleteWithTransaction(ref List, Updatelst, null, MacAddress);
            return Updatelst;
        }
        public ulong UpdateAuthorization(IList<Authorization> iListAuth, IList<AuthorizationEncounter> iListAuthEnc, IList<AuthorizationICD> iListAuthICD, IList<AuthorizationProcedure> iListAuthProcedure, IList<PatientNotes> ilistPatientNotes, string MacAddress)
        {
            ISession MySession = Session.GetISession();
            ITransaction trans = null;
            trans = MySession.BeginTransaction();
            bool bResult = false;
            //ulong ReturnID = 0;
            int iResult = 0;
        TryAgain:
            try
            {
                IList<Authorization> iList = new List<Authorization>();
                //iListCallLog.Add(objCallLog);
                //iResult = SaveUpdateDeleteWithoutTransaction(ref iList, iListAuth, null, MySession, MacAddress);
                if (iResult == 2)
                {
                    if (iTryCount < 5)
                    {
                        iTryCount++;
                        goto TryAgain;
                    }
                    else
                    {
                        trans.Rollback();
                        //MySession.Close();
                        throw new Exception("Deadlock is occured. Transaction failed");
                    }
                }
                else if (iResult == 1)
                {
                    trans.Rollback();
                    //MySession.Close();
                    throw new Exception("Exception is occured. Transaction failed");
                }
                if (iListAuthEnc.Count > 0)
                {
                    for (int m = 0; m < iListAuthEnc.Count; m++)
                    {
                        iListAuthEnc[m].Authorization_ID = iListAuth[0].Id;
                    }
                    AuthorizationEncounterManager AuthEncMngr = new AuthorizationEncounterManager();
                    IList<AuthorizationEncounter> ilstAuthEnc = null;
                    //iResult = AuthEncMngr.SaveUpdateDeleteWithoutTransaction(ref ilstAuthEnc, iListAuthEnc, null, MySession, MacAddress);
                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {
                            trans.Rollback();
                            //MySession.Close();
                            throw new Exception("Deadlock is occured. Transaction failed");
                        }
                    }
                    else if (iResult == 1)
                    {
                        trans.Rollback();
                        //MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");
                    }
                }
                if (iListAuthICD.Count > 0)
                {
                    for (int m = 0; m < iListAuthICD.Count; m++)
                    {
                        iListAuthICD[m].Authorization_ID = iListAuth[0].Id;
                    }
                    AuthorizationICDManager AuthICDMngtr = new AuthorizationICDManager();
                    //IList<AuthorizationICD> ilstAuthICd = null;
                    //iResult = AuthICDMngtr.SaveUpdateDeleteWithoutTransaction(ref ilstAuthICd, iListAuthICD, null, MySession, MacAddress);
                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {
                            trans.Rollback();
                            //MySession.Close();
                            throw new Exception("Deadlock is occured. Transaction failed");
                        }
                    }
                    else if (iResult == 1)
                    {
                        trans.Rollback();
                        //MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");
                    }
                }
                if (iListAuthProcedure.Count > 0)
                {
                    for (int m = 0; m < iListAuthProcedure.Count; m++)
                    {
                        iListAuthProcedure[m].Authorization_ID = iListAuth[0].Id;
                    }
                    AuthorizationProcedureManager AuthProcMngr = new AuthorizationProcedureManager();
                    //IList<AuthorizationProcedure> ilstAuthProc = null;
                    //iResult = AuthProcMngr.SaveUpdateDeleteWithoutTransaction(ref ilstAuthProc, iListAuthProcedure, null, MySession, MacAddress);
                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {
                            trans.Rollback();
                            //MySession.Close();
                            throw new Exception("Deadlock is occured. Transaction failed");
                        }
                    }
                    else if (iResult == 1)
                    {
                        trans.Rollback();
                        //MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");
                    }
                }
                if (iListAuth.Count > 0)
                {
                    PatientNotesManager objPatientNotesMngr = new PatientNotesManager();
                    //IList<PatientNotes> ilist = null;
                    //ilistPatientNotes[0].Id = Convert.ToUInt64(iListAuth[0].Authorization_Notes);
                    //iResult = objPatientNotesMngr.SaveUpdateDeleteWithoutTransaction(ref ilist, ilistPatientNotes, null, MySession, MacAddress);
                    if (iResult == 2)
                    {
                        if (iTryCount < 5)
                        {
                            iTryCount++;
                            goto TryAgain;
                        }
                        else
                        {
                            trans.Rollback();
                            //MySession.Close();
                            throw new Exception("Deadlock is occured. Transaction failed");
                        }
                    }
                    else if (iResult == 1)
                    {
                        trans.Rollback();
                        //MySession.Close();
                        throw new Exception("Exception is occured. Transaction failed");
                    }
                }
                MySession.Flush();
                trans.Commit();
            }
            catch (NHibernate.Exceptions.GenericADOException ex)
            {
                trans.Rollback();
                // MySession.Close();
                //CAP-1942
                throw new Exception(ex.Message, ex);
            }
            catch (Exception e)
            {
                trans.Rollback();
                //MySession.Close();
                //CAP-1942
                throw new Exception(e.Message, e);
            }
            finally
            {
                MySession.Close();
            }
            return iListAuth[0].Id;
        }
        //public void UpdateIsActive(IList<Authorization> Updatelst, string MacAddress)
        //{
        //    ISession MySession = Session.GetISession();
        //    ITransaction trans = null;
        //    trans = MySession.BeginTransaction();
        //    bool bResult = false;
        //    ulong ReturnID = 0;
        //    int iResult = 0;
        //TryAgain:
        //    try
        //    {
        //        //IList<CallLog> iListCallLog = new List<CallLog>();
        //        //iListCallLog.Add(objCallLog);
        //        IList<Authorization> PatientDummy = new List<Authorization>();
        //        iResult = SaveUpdateDeleteWithoutTransaction(ref PatientDummy, Updatelst, null, MySession, MacAddress);
        //        if (iResult == 2)
        //        {
        //            if (iTryCount < 5)
        //            {
        //                iTryCount++;
        //                goto TryAgain;
        //            }
        //            else
        //            {
        //                trans.Rollback();
        //                //MySession.Close();
        //                throw new Exception("Deadlock is occured. Transaction failed");
        //            }
        //        }
        //        else if (iResult == 1)
        //        {
        //            trans.Rollback();
        //            //MySession.Close();
        //            throw new Exception("Exception is occured. Transaction failed");
        //        }

        //        MySession.Flush();
        //        trans.Commit();
        //    }
        //    catch (NHibernate.Exceptions.GenericADOException ex)
        //    {
        //        trans.Rollback();
        //        // MySession.Close();
        //        throw new Exception(ex.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        trans.Rollback();
        //        //MySession.Close();
        //        throw new Exception(e.Message);
        //    }
        //    finally
        //    {
        //        MySession.Close();
        //    }
        //    // return iListAuth[0].Id;
        //}
        public IList<Authorization> GetAuthDetailsByAcnoandDate(string ProviderID, string ApptDate, string HumanID)
        {
            IList<Authorization> AuthList = new List<Authorization>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria;
                criteria = iMySession.CreateCriteria(typeof(Authorization)).Add(Expression.Eq("Referred_To_Provider_ID", ProviderID)).Add(Expression.Eq("Appointment_Date", ApptDate)).Add(Expression.Eq("Human_ID", HumanID));
                AuthList = criteria.List<Authorization>();
                iMySession.Close();
            }
            return AuthList;
        }
        public ArrayList GetAuthDetailsCountByDate(string ProviderID, string ApptDate, string HumanID)
        {
            ArrayList AuthCountList = new ArrayList();
            Authorization AuthList = new Authorization();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery AuthQuery = iMySession.GetNamedQuery("Check.Authorization.ByAppDate");
                AuthQuery.SetString(0, ProviderID);
                AuthQuery.SetString(1, ApptDate);
                AuthQuery.SetString(2, HumanID);
                AuthCountList = new ArrayList(AuthQuery.List());
                iMySession.Close();
            }
            return AuthCountList;
        }


        public ArrayList GetAuthorizationProcedureforHuman(string HumanID, string ApptDate)
        {
            ArrayList AuthCountList = new ArrayList();
            Authorization AuthList = new Authorization();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery AuthQuery = iMySession.GetNamedQuery("Get.AuthorizationCPT.ByAppDateHuman");
                AuthQuery.SetString(0, HumanID);
                AuthQuery.SetString(1, ApptDate);
                AuthQuery.SetString(2, ApptDate);
                AuthCountList = new ArrayList(AuthQuery.List());
                iMySession.Close();
            }
            return AuthCountList;
        }

        public ArrayList GetAuthorizationProcedureforencounter(List<ulong> AuthID)
        {
            ArrayList AuthCountList = new ArrayList();
            Authorization AuthList = new Authorization();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery AuthQuery = iMySession.GetNamedQuery("Get.AuthorizationCPT.ByEncounter");
                AuthQuery.SetParameterList("ProcID", AuthID);

                AuthCountList = new ArrayList(AuthQuery.List());
                iMySession.Close();
            }
            return AuthCountList;
        }
        public IList<Authorization> GetAuthDetailsByAppDate(string ApptDate, string HumanID)
        {
            IList<Authorization> AuthList = new List<Authorization>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria criteria;
                criteria = iMySession.CreateCriteria(typeof(Authorization)).Add(Expression.Eq("Appointment_Date", ApptDate)).Add(Expression.Eq("Human_ID", HumanID));
                AuthList = criteria.List<Authorization>();
                iMySession.Close();
            }
            return AuthList;
        }

    }
}


