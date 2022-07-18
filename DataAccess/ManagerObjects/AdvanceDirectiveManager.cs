using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IAdvanceDirectiveManager : IManagerBase<AdvanceDirective, ulong>
    {
        void SaveAdvanceDirective( AdvanceDirective AdvanceDirectiveObj, ulong humanId, string macAddress);
        void UpdateAdvanceDirective(AdvanceDirective AdvanceDirectiveObj, ulong humanId, string macAddress);
    }

    public partial class AdvanceDirectiveManager : ManagerBase<AdvanceDirective, ulong>, IAdvanceDirectiveManager
    {
        public AdvanceDirectiveManager()
            : base()
        {

        }
        public AdvanceDirectiveManager
            (INHibernateSession session)
            : base(session)
        {

        }

        public void SaveAdvanceDirective(AdvanceDirective AdvanceDirectiveObj, ulong humanId, string macAddress)
        {
            IList<AdvanceDirective> InsertList = new List<AdvanceDirective>();
            InsertList.Add(AdvanceDirectiveObj);
            IList<AdvanceDirective> _temp = null;
            IList<AdvanceDirectiveMaster> _insertMasterList = new List<AdvanceDirectiveMaster>();
            IList<AdvanceDirectiveMaster> _updateMasterList = new List<AdvanceDirectiveMaster>();


            if (InsertList.Count > 0)
                for (int i = 0; i < InsertList.Count; i++)
                {
                    AdvanceDirectiveMaster objMaster = new AdvanceDirectiveMaster();

                    if (InsertList[i].Advance_Directive_Master_ID != 0)
                    {
                        ICriteria crit = Session.GetISession().CreateCriteria(typeof(AdvanceDirectiveMaster)).Add(Expression.Eq("Id", InsertList[i].Advance_Directive_Master_ID));
                        if (crit.List().Count != 0)
                        {
                            objMaster = crit.List<AdvanceDirectiveMaster>()[0];
                            objMaster.Comments = InsertList[i].Comments;
                            objMaster.Human_ID = InsertList[i].Human_ID;
                            objMaster.Status = InsertList[i].Status;
                            objMaster.Version = InsertList[i].Version;
                            objMaster.Modified_By = InsertList[i].Created_By;
                            objMaster.Modified_Date_And_Time = InsertList[i].Created_Date_And_Time;
                            _updateMasterList.Add(objMaster);
                        }
                    }
                    else
                    {
                        objMaster.Comments = InsertList[i].Comments;
                        objMaster.Status = InsertList[i].Status;
                        objMaster.Human_ID = InsertList[i].Human_ID;
                        objMaster.Version = InsertList[i].Version;
                        objMaster.Created_By = InsertList[i].Created_By;
                        objMaster.Created_Date_And_Time = InsertList[i].Created_Date_And_Time;
                        _insertMasterList.Add(objMaster);
                    }

                }


            if(_insertMasterList.Count>0)
            {
            AdvanceDirectiveMasterManager masterManager = new AdvanceDirectiveMasterManager();
            masterManager.SaveAdvanceDirectiveMaster(_insertMasterList[0], humanId, string.Empty);
            }
            else if (_updateMasterList.Count > 0)
            {
                AdvanceDirectiveMasterManager masterManager = new AdvanceDirectiveMasterManager();
                masterManager.UpdateAdvanceDirectiveMaster(_updateMasterList[0], humanId, string.Empty);
            }


            for (int i = 0; i < _insertMasterList.Count; i++)
            {
                for (int j = 0; j < InsertList.Count; j++)
                {
                    if (InsertList[j].Advance_Directive_Master_ID == 0)
                    {
                        InsertList[j].Advance_Directive_Master_ID = _insertMasterList[i].Id;
                        break;
                    }
                }
            }

            SaveUpdateDelete_DBAndXML_WithTransaction(ref InsertList, ref _temp, null, macAddress, true, true, humanId, string.Empty);

        }

        public void UpdateAdvanceDirective(AdvanceDirective AdvanceDirectiveObj, ulong humanId, string macAddress)
        {
            IList<AdvanceDirective> AdvanceDirectiveListInsert = new List<AdvanceDirective>();
            IList<AdvanceDirective> UpdateList = null;
            IList<AdvanceDirectiveMaster> _updateMasterList = new List<AdvanceDirectiveMaster>();

            string sStatus = string.Empty;
            string sComments = string.Empty;
            string sModifiedBy = string.Empty;
            DateTime dtModifiedDateTime = DateTime.MinValue;

            if (AdvanceDirectiveObj != null)
            {
                UpdateList = new List<AdvanceDirective>();
                sStatus = AdvanceDirectiveObj.Status;
                sModifiedBy = AdvanceDirectiveObj.Modified_By;
                dtModifiedDateTime = AdvanceDirectiveObj.Modified_Date_And_Time;
                sComments = AdvanceDirectiveObj.Comments;

                UpdateList.Add(AdvanceDirectiveObj);
            }

            

            if (UpdateList.Count > 0)
                for (int i = 0; i < UpdateList.Count; i++)
                {
                    AdvanceDirectiveMaster objMaster = new AdvanceDirectiveMaster();
                    ICriteria crit = Session.GetISession().CreateCriteria(typeof(AdvanceDirectiveMaster)).Add(Expression.Eq("Id", UpdateList[i].Advance_Directive_Master_ID));
                    if (crit.List().Count != 0)
                    {
                        objMaster = crit.List<AdvanceDirectiveMaster>()[0];
                        //objMaster.Status = UpdateList[i].Status;
                        //objMaster.Human_ID = UpdateList[i].Human_ID;
                        //objMaster.Modified_By = UpdateList[i].Modified_By;
                        //objMaster.Modified_Date_And_Time = UpdateList[i].Modified_Date_And_Time;
                        //objMaster.Comments = UpdateList[i].Comments;

                        objMaster.Status = sStatus;
                        objMaster.Modified_By = sModifiedBy;
                        objMaster.Modified_Date_And_Time = dtModifiedDateTime;
                        objMaster.Comments = sComments;
                        //objMaster.Version = UpdateList[i].Version;
                        _updateMasterList.Add(objMaster);
                    }
                }

            if (_updateMasterList.Count > 0)
            {
                AdvanceDirectiveMasterManager masterManager = new AdvanceDirectiveMasterManager();
                masterManager.UpdateAdvanceDirectiveMaster(_updateMasterList[0], humanId, string.Empty);
            }

            using (ISession iMySession = session.GetISession())
            {
                iMySession.Close();
            }

            SaveUpdateDelete_DBAndXML_WithTransaction(ref AdvanceDirectiveListInsert, ref UpdateList, null, macAddress, true, true, humanId, string.Empty);

        }
    }
}
   
