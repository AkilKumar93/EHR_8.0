using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;
using System.Collections;
using Acurus.Capella.Core.DTO;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IPreventiveScreenLookupManager : IManagerBase<PreventiveScreenLookup, ulong>
    {
        IList<PreventiveScreenDTO> GetPreventiveScreenFromLocal(string PreventiveValue,string PatientSex);
    }
    public partial class PreventiveScreenLookupManager : ManagerBase<PreventiveScreenLookup, ulong>, IPreventiveScreenLookupManager
    {
         #region Constructors

        public PreventiveScreenLookupManager()
            : base()
        {

        }
        public PreventiveScreenLookupManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region IPreventiveScreenLookupManager Members

        public IList<PreventiveScreenDTO> GetPreventiveScreenFromLocal(string PreventiveValue, string PatientSex)
        {
            //ISession iMySession = NHibernateSessionManager.Instance.CreateISession();
            ArrayList ary = null;
            IList<PreventiveScreenDTO> PreventiveLst = new List<PreventiveScreenDTO>();
            PreventiveScreenDTO PreDto = null;
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = iMySession.GetNamedQuery("Fill.PreventiveScreen.Local").SetString(0, PreventiveValue);
                ary = new ArrayList(query.List());
                for (int i = 0; i < ary.Count; i++)
                {
                    object[] ob = (object[])ary[i];
                    PreDto = new PreventiveScreenDTO();
                    PreDto.Preventive_Screen_ID = Convert.ToUInt64(ob[0]);
                    PreDto.Preventive_Service = Convert.ToString(ob[1]);
                    PreDto.Preventive_Service_Value = Convert.ToString(ob[2]);
                    PreDto.Options = Convert.ToString(ob[3]);
                    PreDto.Status = Convert.ToString(ob[4]);
                    PreDto.Preventive_Screening_Notes = Convert.ToString(ob[5]);
                    PreDto.Created_By = Convert.ToString(ob[6]);
                    PreDto.Created_Date_And_Time = Convert.ToDateTime(ob[7]);
                    PreDto.Preventive_Screen_Lookup_ID = Convert.ToUInt64(ob[8]);
                    PreDto.Version = Convert.ToInt32(ob[9]);
                    PreDto.Depending_Value = Convert.ToString(ob[10]);
                    PreDto.Description = Convert.ToString(ob[11]);
                    PreventiveLst.Add(PreDto);
                }
                if (PatientSex.ToUpper() == "FEMALE")
                    PreventiveLst = (from prelst in PreventiveLst where prelst.Depending_Value.ToUpper() == "ALL" || prelst.Depending_Value.ToUpper() == "FEMALE" select prelst).ToList<PreventiveScreenDTO>();
                else
                    PreventiveLst = (from prelst in PreventiveLst where prelst.Depending_Value.ToUpper() == "ALL" select prelst).ToList<PreventiveScreenDTO>();
                iMySession.Close();
                return PreventiveLst;
            }
        }

        #endregion
    }
}
