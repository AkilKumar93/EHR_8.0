using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using System.Data;
using System.Collections;

namespace Acurus.Capella.DataAccess.ManagerObjects
{

    public partial interface IPlanCPTFormRequiredManager : IManagerBase<PlanCPTFormRequired, ulong>
    {
        IList<PlanCPTFormRequired> GetRequiredFormsBasedOnCptAndInsurance(ulong InsuranceId, string[] CPTs);
        //Added By Muthu on 12-Feb-2013
        DataSet DtblCMGAncillaryDocumentationReport(DateTime From_Date, DateTime To_Date, string sFacilityName);
    }

    public partial class PlanCPTFormRequiredManager : ManagerBase<PlanCPTFormRequired, ulong>, IPlanCPTFormRequiredManager
    {
        #region Constructors


            public PlanCPTFormRequiredManager()
                : base()
            {

            }
            public PlanCPTFormRequiredManager
                (INHibernateSession session)
                : base(session)
            {

            }
            #endregion

        public IList<PlanCPTFormRequired> GetRequiredFormsBasedOnCptAndInsurance(ulong InsuranceId,string[] CPTs)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession(); 
            IList<PlanCPTFormRequired> resultset=new List<PlanCPTFormRequired>();
            string Cptsqueryparameter = string.Empty;
            foreach (string str in CPTs)
            {
                if (Cptsqueryparameter.Trim() == string.Empty)
                    Cptsqueryparameter = "'"+str+"'";
                else
                    Cptsqueryparameter +=",'"+ str+"'";
            }
            if (Cptsqueryparameter.Trim() == string.Empty)
            {
                Cptsqueryparameter="\'\'";
            }
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ISQLQuery sq = iMySession.CreateSQLQuery("SELECT * FROM plan_cpt_form_required WHERE (Insurance_Plan_ID=" + InsuranceId + " OR Insurance_Plan_ID=\"9999\") AND Procedure_Code in (" + Cptsqueryparameter + ");").AddEntity(typeof(PlanCPTFormRequired));
                resultset = sq.List<PlanCPTFormRequired>();
                iMySession.Close();
            }
            return resultset;

        }
       
        //Added By Muthu on 12-Feb-2013
        public DataSet DtblCMGAncillaryDocumentationReport(DateTime From_Date, DateTime To_Date,string sFacilityName)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            DataSet CMGAncillaryDocumentationReport = new DataSet();
            DataTable DtblCMGAncillaryDocumentationReport = new DataTable();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query2 = iMySession.GetNamedQuery("Fill.GetCMGAncillaryReport.ColumnHeadings");
                query2.List<object[]>().ToList().ForEach(a =>
                {
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (i == 2 || i == 5)
                            DtblCMGAncillaryDocumentationReport.Columns.Add(a[i].ToString(), typeof(System.DateTime));
                        else
                            DtblCMGAncillaryDocumentationReport.Columns.Add(a[i].ToString(), typeof(System.String));
                    }
                });
                IQuery query1 = iMySession.GetNamedQuery("Reports.CMGAncillaryDocumentationReport");
                query1.SetString(0, From_Date.ToString("yyyy-MM-dd hh:mm"));
                query1.SetString(1, To_Date.ToString("yyyy-MM-dd hh:mm"));
                query1.List<object[]>().ToList().ForEach(a =>
                {
                    DataRow dr = DtblCMGAncillaryDocumentationReport.NewRow();
                    for (int k = 0; k < a.Length; k++)
                    {
                        try
                        {
                            dr[k] = a[k].ToString();
                        }
                        catch
                        {
                            //string s;
                        }
                    }
                    DtblCMGAncillaryDocumentationReport.Rows.Add(dr);
                });
               
                CMGAncillaryDocumentationReport.Tables.Add(DtblCMGAncillaryDocumentationReport);
                iMySession.Close();
            }
            return CMGAncillaryDocumentationReport;


        }



    }
}
