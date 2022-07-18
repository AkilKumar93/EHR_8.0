using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections;
using System.Linq;
namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public interface ISurgicalHistoryMasterManager : IManagerBase<SurgicalHistoryMaster, uint>
    {
        SurgicalHistoryDTO LoadSurgicalHistory(ulong HumanId, int PageNumber, int MaxResultSet, ulong EncounterId, bool Is_Load);
        SurgicalHistoryDTO SurgicalSaveUpdateDelete(IList<SurgicalHistoryMaster> SurgicalLst, IList<SurgicalHistoryMaster> InsertList, IList<SurgicalHistoryMaster> UpdateList, IList<SurgicalHistoryMaster> DeleteList, ulong HumanId, string macAddress);
    }

    public partial class SurgicalHistoryMasterManager : ManagerBase<SurgicalHistoryMaster, uint>, ISurgicalHistoryMasterManager
    {
        #region Constructors
        public SurgicalHistoryMasterManager(): base()
        {

        }
        public SurgicalHistoryMasterManager(INHibernateSession session): base(session)
        {

        }
        #endregion


        #region Get Methods

        public SurgicalHistoryDTO LoadSurgicalHistory(ulong HumanId, int PageNumber, int MaxResultSet, ulong EncounterId, bool Is_Load)
        {
            IList<SurgicalHistoryMaster> getSurgicalList = new List<SurgicalHistoryMaster>();
            SurgicalHistoryDTO SurgicalDTOObject = new SurgicalHistoryDTO();
            IList<SurgicalHistoryMaster> CommonSurgeryList = new List<SurgicalHistoryMaster>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = iMySession.GetNamedQuery("Get.Surgical.History.Portal.And.Encounter.Details");
                query.SetParameter(0, HumanId);
                IList<SurgicalHistoryMaster> lstSurg = new List<SurgicalHistoryMaster>();
                ArrayList resultList = new ArrayList(query.List());
                Dictionary<ulong, DateTime> dictEnc = new Dictionary<ulong, DateTime>();
                foreach (object objResult in resultList)
                {
                    SurgicalHistoryMaster objSurg = new SurgicalHistoryMaster();
                    object[] lstObj = (object[])objResult;
                    objSurg.Id = Convert.ToUInt32(lstObj[0]);
                    objSurg.Human_ID = Convert.ToUInt32(lstObj[1]);
                    objSurg.Surgery_Name = Convert.ToString(lstObj[2]);
                    objSurg.Date_Of_Surgery = Convert.ToString(lstObj[3]);
                    objSurg.Description = Convert.ToString(lstObj[4]);
                    objSurg.Is_Present = Convert.ToString(lstObj[5]);
                    objSurg.Created_By = Convert.ToString(lstObj[6]);
                    objSurg.Created_Date_And_Time = Convert.ToDateTime(lstObj[7].ToString());
                    objSurg.Modified_By = Convert.ToString(lstObj[8]);
                    objSurg.Modified_Date_And_Time = Convert.ToDateTime(lstObj[9]);
                    objSurg.Version = Convert.ToInt32(lstObj[10]);
                    if (!dictEnc.ContainsKey(Convert.ToUInt32(lstObj[12])))
                        dictEnc.Add(Convert.ToUInt32(lstObj[12]), Convert.ToDateTime(lstObj[13]));
                    lstSurg.Add(objSurg);
                }
                lstSurg = lstSurg.GroupBy(x => x.Id).Select(x => x.First()).ToList<SurgicalHistoryMaster>();
                bool IsPrevious = false;

               // if (lstSurg.Count > 0)
                    //CommonSurgeryList = (from obj in lstSurg where obj.Encounter_Id == EncounterId select obj).ToList<SurgicalHistoryMaster>();
                //else
                    CommonSurgeryList = new List<SurgicalHistoryMaster>();
                if (CommonSurgeryList.Count > 0)
                    IsPrevious = true;
                else
                {
                    DateTime curr_DOS = DateTime.MinValue;
                    if (dictEnc.Count != 0)
                        curr_DOS = Convert.ToDateTime(dictEnc[EncounterId]);
                    foreach (KeyValuePair<ulong, DateTime> entry in dictEnc)
                    {
                        if (DateTime.Compare(Convert.ToDateTime(entry.Value), curr_DOS) < 0)
                        {
                            if (lstSurg.Count > 0)
                            {
                               // CommonSurgeryList = (from obj in lstSurg where obj.Encounter_Id == Convert.ToUInt32(entry.Key) select obj).ToList<SurgicalHistoryPortal>();
                                IsPrevious = true;
                                break;
                            }

                        }
                    }
                   // if (!IsPrevious && Is_Load)
                    //{
                       // CommonSurgeryList = lstSurg.Where(a => a.Human_ID == HumanId && a.Encounter_Id == 0).ToList<SurgicalHistoryPortal>();
                    //}
                }
                SurgicalDTOObject.SurgicalCount = CommonSurgeryList.Count;
                IList<SurgicalHistoryMaster> tempSurgicalList = new List<SurgicalHistoryMaster>();
                if (CommonSurgeryList != null && CommonSurgeryList.Count > 0)
                {
                    tempSurgicalList = CommonSurgeryList.Skip((PageNumber - 1) * MaxResultSet).Take(MaxResultSet).ToList();
                }
                SurgicalDTOObject.SurgicalMasterList = tempSurgicalList;

                ICriteria criteria = iMySession.CreateCriteria(typeof(Human)).Add(Expression.Eq("Id", HumanId));
                SurgicalDTOObject.PatientDOB = criteria.List<Human>()[0].Birth_Date;
                iMySession.Close();
            }
            return SurgicalDTOObject;


        }

        public SurgicalHistoryDTO SurgicalSaveUpdateDelete(IList<SurgicalHistoryMaster> SurgicalLst, IList<SurgicalHistoryMaster> InsertList, IList<SurgicalHistoryMaster> UpdateList, IList<SurgicalHistoryMaster> DeleteList, ulong HumanId, string macAddress)
        {
            SaveUpdateDelete_DBAndXML_WithTransaction(ref InsertList, ref UpdateList, null, macAddress, true, true, HumanId, string.Empty);
            return null;
        }

        #endregion
    }
}
