using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface ILabcorpSettingsManager:IManagerBase<LabSettings,int>
    {
        IList<LabSettings> GetLabcorpSettings();
    }
    public partial class LabcorpSettingsManager : ManagerBase<LabSettings, int>,ILabcorpSettingsManager
    {
        #region Constructors

        public LabcorpSettingsManager()
            : base()
        {

        }
        public LabcorpSettingsManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Methods

        public IList<LabSettings> GetLabcorpSettings()
        {
            
            return GetAll();
        }

        #endregion

    }
}
