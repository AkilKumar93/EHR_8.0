using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface ICorrectedDBEntriesManager : IManagerBase<CorrectedDBEntries, uint>
    {
        void AppendToCorrectedDBEntries(CorrectedDBEntries CorrDBEntry, string MACAddress);
    }



    public partial class CorrectedDBEntriesManager : ManagerBase<CorrectedDBEntries, uint>, ICorrectedDBEntriesManager
    {
        #region Constructors

        public CorrectedDBEntriesManager()
            : base()
        {

        }
        public CorrectedDBEntriesManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Get Methods

        public void AppendToCorrectedDBEntries(CorrectedDBEntries CorrDBEntry, string MACAddress)
        {
            IList<CorrectedDBEntries> CorrDBEntryList =new List<CorrectedDBEntries>();
            IList<CorrectedDBEntries> updateList = null;
            IList<CorrectedDBEntries> deletelist = null;
            ulong HumanId = 0;
            CorrDBEntryList.Add(CorrDBEntry);
            SaveUpdateDelete_DBAndXML_WithTransaction(ref CorrDBEntryList, ref updateList, deletelist, MACAddress, false, false, HumanId, string.Empty);
            //SaveUpdateDeleteWithTransaction(ref CorrDBEntryList, null, null,MACAddress);
        }

        #endregion
    }
}
