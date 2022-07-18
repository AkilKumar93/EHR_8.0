using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IPhysicianPatientManager : IManagerBase<PhysicianPatient, ulong>
    {
        FillOtherHistory LoadPhysicianPatient(int PageNumber, int MaxResultSet, ulong humanId, ulong Encounter_Id, bool Is_Load);
        void SavePhysicianPatient(IList<PhysicianPatient> SavePhysicianPatient, IList<PhysicianPatient> ilistPrevious, ulong humanId, string macAddress);
        void UpdatePhysicianPatient(IList<PhysicianPatient> UpdatePhysicianPatient, IList<PhysicianPatient> SavePhysicianPat, ulong humanId, string macAddress, ulong Encounter_Id);
        void DeletePhysicianPatient(IList<PhysicianPatient> ilistPhySpecDelteList, IList<PhysicianPatient> SavePhyPat, ulong humanId, string macAddress, ulong Encounter_Id);
    }

    public partial class PhysicianPatientManager : ManagerBase<PhysicianPatient, ulong>, IPhysicianPatientManager
    {
        #region Constructors


        public PhysicianPatientManager()
            : base()
        {

        }
        public PhysicianPatientManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        public FillOtherHistory LoadPhysicianPatient(int PageNumber, int MaxResultSet, ulong humanId, ulong Encounter_Id, bool Is_Load)
        {       
            IList<PhysicianPatient> phyPatList = new List<PhysicianPatient>();
            EncounterManager encMngr = new EncounterManager();
            FillOtherHistory FillOtherHistoryObj = new FillOtherHistory();
            ArrayList arrList = new ArrayList();
            bool Is_PreviousEnc = false;
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = mySession.GetNamedQuery("Get.all.GetPhysicianPatientByHumanID");
                PageNumber = PageNumber - 1;
                query.SetParameter(0, humanId);
                query.SetParameter(1, Encounter_Id);
                query.SetParameter(2, PageNumber * MaxResultSet);
                query.SetParameter(3, MaxResultSet);
                arrList = (ArrayList)query.List();
                //if (arrList != null)
                //{
                if (arrList != null && arrList.Count > 0)
                {
                    phyPatList = LoadValues(arrList);
                }
                else
                {
                    IList<Encounter> EncLst = new List<Encounter>();
                    EncLst = encMngr.GetEncounterUsingHumanID(humanId);

                    if (EncLst.Count > 0 && Is_Load)
                    {
                        foreach (Encounter item in EncLst)
                        {
                            if (Encounter_Id >= item.Id)
                            {
                                query.SetParameter(0, humanId);
                                query.SetParameter(1, item.Id);
                                query.SetParameter(2, PageNumber * MaxResultSet);
                                query.SetParameter(3, MaxResultSet);
                                arrList = (ArrayList)query.List();

                                if (arrList != null && arrList.Count > 0)
                                {
                                    Is_PreviousEnc = true;
                                    phyPatList = LoadValues(arrList);
                                    break;
                                }
                            }
                        }
                    }

                    if (!Is_PreviousEnc && Is_Load)
                    {
                        query.SetParameter(0, humanId);
                        query.SetParameter(1, Convert.ToInt32(0));
                        query.SetParameter(2, PageNumber * MaxResultSet);
                        query.SetParameter(3, MaxResultSet);
                        arrList = (ArrayList)query.List();

                        if (arrList != null && arrList.Count > 0)
                            phyPatList = LoadValues(arrList);
                    }
                }
                //}
                FillOtherHistoryObj.PhysicianPatientList = phyPatList;               
                ICriteria criteria = null;
                criteria = mySession.CreateCriteria(typeof(AdvanceDirective)).Add(Expression.Eq("Human_ID", humanId)).Add(Expression.Eq("Encounter_Id", Encounter_Id));
                FillOtherHistoryObj.Advance_Directive = criteria.List<AdvanceDirective>();
                bool IsAdvancedPrevious = false;
                if (FillOtherHistoryObj.Advance_Directive.Count == 0)
                {
                    IList<Encounter> EncLst = new List<Encounter>();
                    EncLst = encMngr.GetEncounterUsingHumanID(humanId);

                    if (EncLst.Count > 0)
                    {
                        foreach (Encounter item in EncLst)
                        {
                            if (Encounter_Id > item.Id)
                            {
                                criteria = mySession.CreateCriteria(typeof(AdvanceDirective)).Add(Expression.Eq("Human_ID", humanId)).Add(Expression.Eq("Encounter_Id", item.Id));
                                FillOtherHistoryObj.Advance_Directive = criteria.List<AdvanceDirective>();

                                if (FillOtherHistoryObj.Advance_Directive.Count > 0)
                                {
                                    IsAdvancedPrevious = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (!IsAdvancedPrevious)
                    {
                        criteria = mySession.CreateCriteria(typeof(AdvanceDirective)).Add(Expression.Eq("Human_ID", humanId)).Add(Expression.Eq("Encounter_Id", Convert.ToUInt64(0)));
                        FillOtherHistoryObj.Advance_Directive = criteria.List<AdvanceDirective>();
                    }
                }
                mySession.Close();
            }
            return FillOtherHistoryObj;
        }

        public void SavePhysicianPatient(IList<PhysicianPatient> InsertList, IList<PhysicianPatient> UpdateList, ulong humanId, string macAddress)
        {
            IList<PhysicianPatientMaster> _insertMasterList = new List<PhysicianPatientMaster>();
            IList<PhysicianPatientMaster> _updateMasterList = new List<PhysicianPatientMaster>();
            IList<PhysicianPatientMaster> _deleteMasterList = new List<PhysicianPatientMaster>();
            if (InsertList.Count > 0)
                for (int i = 0; i < InsertList.Count; i++)
                {
                    PhysicianPatientMaster objMaster = new PhysicianPatientMaster();

                    if (InsertList[i].Physician_Patient_Master_ID != 0)
                    {
                        ICriteria crit = Session.GetISession().CreateCriteria(typeof(PhysicianPatientMaster)).Add(Expression.Eq("Id", InsertList[i].Physician_Patient_Master_ID));
                        if (crit.List().Count != 0)
                        {
                            objMaster = crit.List<PhysicianPatientMaster>()[0];
                            objMaster.Physician_Name = InsertList[i].Physician_Name;
                            objMaster.Is_Deleted = "N";
                            objMaster.Human_ID = InsertList[i].Human_ID;
                            objMaster.Phone_No = InsertList[i].Phone_No;
                            objMaster.Relationship = InsertList[i].Relationship;
                            objMaster.Version = InsertList[i].Version;
                            objMaster.Modified_By = InsertList[i].Created_By;
                            objMaster.Modified_Date_And_Time = InsertList[i].Created_Date_And_Time;
                            _updateMasterList.Add(objMaster);
                        }
                    }
                    else
                    {
                        objMaster.Physician_Name = InsertList[i].Physician_Name;
                        objMaster.Is_Deleted = "N";
                        objMaster.Human_ID = InsertList[i].Human_ID;
                        objMaster.Phone_No = InsertList[i].Phone_No;
                        objMaster.Relationship = InsertList[i].Relationship;
                        objMaster.Version = InsertList[i].Version;
                        objMaster.Created_By = InsertList[i].Created_By;
                        objMaster.Created_Date_And_Time = InsertList[i].Created_Date_And_Time;
                        _insertMasterList.Add(objMaster);
                    }

                }

            

            if (_insertMasterList.Count > 0)
            {
                PhysicianPatientMasterManager masterManager = new PhysicianPatientMasterManager();
                masterManager.SavePhysicianPatientMaster(_insertMasterList, _updateMasterList,humanId,string.Empty);
            }
            else if (_updateMasterList.Count > 0)
            {
                PhysicianPatientMasterManager masterManager = new PhysicianPatientMasterManager();
                masterManager.UpdatePhysicianPatientMaster(_updateMasterList, null, humanId,string.Empty);
            }

            for (int i = 0; i < _insertMasterList.Count; i++)
            {
                for (int j = 0; j < InsertList.Count; j++)
                {
                    if (InsertList[j].Physician_Patient_Master_ID == 0)
                    {
                        InsertList[j].Physician_Patient_Master_ID = _insertMasterList[i].Id;
                        break;
                    }
                }
            }

            SaveUpdateDelete_DBAndXML_WithTransaction(ref InsertList, ref UpdateList, null, macAddress, true, true, humanId, string.Empty);
            

        }

        public void UpdatePhysicianPatient(IList<PhysicianPatient> UpdateList, IList<PhysicianPatient> SavePhysicianPat, ulong humanId, string macAddress, ulong Encounter_Id)
        {
            IList<PhysicianPatientMaster> _updateMasterList = new List<PhysicianPatientMaster>();
           
            if (UpdateList.Count > 0)
                for (int i = 0; i < UpdateList.Count; i++)
                {
                    PhysicianPatientMaster objMaster = new PhysicianPatientMaster();
                    ICriteria crit = Session.GetISession().CreateCriteria(typeof(PhysicianPatientMaster)).Add(Expression.Eq("Id", UpdateList[i].Physician_Patient_Master_ID));
                    if (crit.List().Count != 0)
                    {
                        objMaster = crit.List<PhysicianPatientMaster>()[0];
                        objMaster.Physician_Name = UpdateList[i].Physician_Name;
                        objMaster.Phone_No = UpdateList[i].Phone_No;
                        objMaster.Modified_By = UpdateList[i].Modified_By;
                        objMaster.Modified_Date_And_Time = UpdateList[i].Modified_Date_And_Time;
                        objMaster.Relationship = UpdateList[i].Relationship;
                        //objMaster.Version = UpdateList[i].Version;
                        _updateMasterList.Add(objMaster);
                    }
                }

            if (_updateMasterList.Count > 0)
            {
                PhysicianPatientMasterManager masterManager = new PhysicianPatientMasterManager();
                masterManager.UpdatePhysicianPatientMaster(_updateMasterList,null, humanId, string.Empty);
            }

            using (ISession iMySession = session.GetISession())
            {
                iMySession.Close();
            }

            SaveUpdateDelete_DBAndXML_WithTransaction(ref SavePhysicianPat, ref UpdateList, null, macAddress, true, true, humanId, string.Empty);
            
        }

        public void DeletePhysicianPatient(IList<PhysicianPatient> DeleteList, IList<PhysicianPatient> SavePhyPat, ulong humanId, string macAddress, ulong Encounter_Id)
        {
            IList<PhysicianPatient> PhyPatTemp = null;
            IList<PhysicianPatientMaster> _updateMasterList = new List<PhysicianPatientMaster>();
            if (DeleteList.Count > 0)
                for (int i = 0; i < DeleteList.Count; i++)
                {
                    PhysicianPatientMaster objMaster = new PhysicianPatientMaster();
                    ICriteria crit = Session.GetISession().CreateCriteria(typeof(PhysicianPatientMaster)).Add(Expression.Eq("Id", DeleteList[i].Physician_Patient_Master_ID));
                    if (crit.List().Count != 0)
                    {
                        objMaster = crit.List<PhysicianPatientMaster>()[0];
                        objMaster.Physician_Name = DeleteList[i].Physician_Name;
                        objMaster.Is_Deleted = "Y";
                        objMaster.Human_ID = DeleteList[i].Human_ID;
                        objMaster.Created_By = DeleteList[i].Modified_By;
                        objMaster.Created_Date_And_Time = DeleteList[i].Modified_Date_And_Time;
                        objMaster.Phone_No = DeleteList[i].Phone_No;
                        objMaster.Relationship = DeleteList[i].Relationship;
                        objMaster.Version = DeleteList[i].Version;
                        _updateMasterList.Add(objMaster);
                    }
                }

            if (_updateMasterList.Count > 0)
            {
                PhysicianPatientMasterManager masterManager = new PhysicianPatientMasterManager();
                masterManager.UpdatePhysicianPatientMaster(_updateMasterList,null , humanId, string.Empty);
            }

            using (ISession iMySession = session.GetISession())
            {
                iMySession.Close();
            }

            SaveUpdateDelete_DBAndXML_WithTransaction(ref SavePhyPat, ref PhyPatTemp, DeleteList, macAddress, true, true, humanId, string.Empty);
          
        }


        public IList<PhysicianPatient> LoadValues(ArrayList arrList)
        {

            IList<PhysicianPatient> lst = new List<PhysicianPatient>();

            foreach (object[] obj in arrList)
            {
                PhysicianPatient a = new PhysicianPatient();
                if (obj.Count() > 0)
                {
                    a.Id = Convert.ToUInt64(obj[0]);
                    a.Physician_Name = obj[1].ToString();
                    a.Human_ID = Convert.ToUInt64(obj[2]);
                    a.Relationship = obj[3].ToString();
                    a.Phone_No = obj[4].ToString();
                    a.Created_By = obj[5].ToString();
                    a.Created_Date_And_Time = Convert.ToDateTime(obj[6]);
                    a.Modified_By = obj[7].ToString();
                    a.Modified_Date_And_Time = Convert.ToDateTime(obj[8]);
                    a.Version = Convert.ToInt32(obj[9]);
                    a.Encounter_Id = Convert.ToUInt64(obj[10]);
                    lst.Add(a);
                }
            }

            return lst;
        }      
    }
}
