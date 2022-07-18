using System;
using NHibernate;

namespace Acurus.Capella.DataAccess
{
    public interface INHibernateSession : IDisposable
    {
        #region  Methods

        void CommitChanges();
        void Close();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void IncrementRefCount();
        void DecrementRefCount();
        ISession GetISession();

        #endregion

        #region Properties

        bool HasOpenTransaction { get; }
        bool IsOpen { get; }
        bool AutoCloseSession { get; set; }

        #endregion
    }

    public class NHibernateSession : INHibernateSession
    {
        #region Declarations

        protected ITransaction transaction = null;
        protected ISession iSession = null;
        private bool _autoCloseSession = true;
        private bool _isDisposed = false;
        private int _refCount = 0;

        #endregion

        #region Constructor & Destructor

        public NHibernateSession()
        { }

        ~NHibernateSession()
        {
            Dispose(true);
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(false);
        }

        private void Dispose(bool finalizing)
        {
            if (!_isDisposed)
            {
                Close();

                if (!finalizing)
                    GC.SuppressFinalize(this);

                _isDisposed = true;
            }
        }

        #endregion

        #region Methods

        int ReCommitCount = 0;

        public void CommitChanges()
        {
            if (HasOpenTransaction)
                CommitTransaction();
            else
                iSession.Flush();
        }

        public void Close()
        {
            if (iSession == null)
                return;

            if (HasOpenTransaction)
                RollbackTransaction();

            if (iSession.IsOpen)
                iSession.Close();
            iSession.Dispose();
            iSession = null;
        }

        public void BeginTransaction()
        {
            transaction = GetISession().BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (transaction == null)
                return;

            try
            {
                iSession.Flush();
                transaction.Commit();
                transaction.Dispose();
                transaction = null;
            }
            catch (NHibernate.Exceptions.GenericADOException ex)
            {
                MySql.Data.MySqlClient.MySqlException excep = (MySql.Data.MySqlClient.MySqlException)ex.InnerException;

                if (excep.Number == 1213)
                {
                    if (ReCommitCount <= 5)
                    {
                        CommitTransaction();
                        ReCommitCount = ReCommitCount + 1;
                    }
                    else
                    {
                        RollbackTransaction();
                        throw;
                    }
                }
            }
            catch (HibernateException)
            {
                RollbackTransaction();
                throw;
            }
        }

        public void RollbackTransaction()
        {
            if (transaction == null)
                return;

            transaction.Rollback();
            transaction.Dispose();
            transaction = null;
        }

        public void IncrementRefCount()
        {
            _refCount++;
        }

        public void DecrementRefCount()
        {
            _refCount--;
            if (_refCount == 0 && AutoCloseSession)
                Close();
        }

        public ISession GetISession()
        {
            if (iSession == null || !iSession.IsOpen)
                iSession = NHibernateSessionManager.Instance.CreateISession();
            return iSession;
        }

        #endregion

        #region Properties

        public bool HasOpenTransaction
        {
            get { return (transaction != null); }
        }

        public bool IsOpen
        {
            get { return (iSession != null && iSession.IsOpen); }
        }

        public bool AutoCloseSession
        {
            get { return _autoCloseSession; }
            set
            {
                _autoCloseSession = value;
                if (_refCount == 0 && _autoCloseSession)
                    Close();
            }
        }

        #endregion
    }
}
