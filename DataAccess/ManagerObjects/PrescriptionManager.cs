using System;
using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface IPrescriptionManager : IManagerBase<Prescription, int>
    {
        ulong SavePrescription(IList<Prescription> addList, IList<Prescription> updateList, IList<Prescription> deleteList, string macAddress,WFObject WFObj);
    }
    public partial class PrescriptionManager : ManagerBase<Prescription, int>, IPrescriptionManager
    {
        
        #region Constructors

        public PrescriptionManager()
            : base()
        {

        }
        public PrescriptionManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion
        public ulong SavePrescription(IList<Prescription> addList, IList<Prescription> updateList, IList<Prescription> deleteList, string macAddress, WFObject WFObj)
        {
            //SaveUpdateDeleteWithTransaction(ref addList, updateList, deleteList, macAddress);
            SaveUpdateDelete_DBAndXML_WithTransaction(ref addList, ref updateList, deleteList, macAddress, false, false, 0, string.Empty);
            ulong ulPresID = 0;
            ulPresID =Convert.ToUInt32(addList[0].Id);
            WFObjectManager wfObjectMngr = new WFObjectManager();
            WFObj.Obj_System_Id = Convert.ToUInt32(ulPresID);
            wfObjectMngr.InsertToRCopiaWorkFlowObject(WFObj, 1, string.Empty);//WFObEncRecordj
            return ulPresID;
        }

       
    }
}
