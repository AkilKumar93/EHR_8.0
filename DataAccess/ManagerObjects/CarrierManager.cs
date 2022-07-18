using System;
using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;

namespace Acurus.Capella.DataAccess.ManagerObjects
{
    public partial interface ICarrierManager : IManagerBase<Carrier, ulong>
    {
        FillCarrier InsertCarrier(Carrier obj, int pgNumber, int MaxResult, string MACAddress);
         FillCarrier GetCarrierList(int pgNumber, int MaxResult);
         FillCarrier UpdateCarrier(Carrier obj, int pgNumber, int MaxResult, string MACAddress);
         FillCarrier DeleteCarrier(Carrier obj, int pgNumber, int MaxResult, string MACAddress);
         Carrier GetCarrierUsingId(ulong CarrierId);
         IList<Carrier> GetCarrierByName(string CarrierName);
         Carrier GetCarrierUsingCarrierName(string sCarrierName);
         IList<Carrier> GetCarrierByCarrierName(string Carrier_Name);

        }
        public partial class CarrierManager : ManagerBase<Carrier, ulong>, ICarrierManager
    {
        #region Constructors


        public CarrierManager()
            : base()
        {

        }
        public CarrierManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region CRUD

        public FillCarrier InsertCarrier(Carrier obj, int pgNumber, int MaxResult, string MACAddress)
        {
            IList<Carrier> saveList = new List<Carrier>();
            saveList.Add(obj);
            IList<Carrier> CarrierTemp = null;
            SaveUpdateDelete_DBAndXML_WithTransaction(ref saveList, ref CarrierTemp, null, MACAddress, false, false, 0, "");
            return GetCarrierList(pgNumber, MaxResult);
        }

        public FillCarrier UpdateCarrier(Carrier obj, int pgNumber, int MaxResult, string MACAddress)
        {
            IList<Carrier> saveList = null;
            IList<Carrier> updtList = new List<Carrier>();
            updtList.Add(obj);
            SaveUpdateDelete_DBAndXML_WithTransaction(ref saveList, ref updtList, null, MACAddress, false, false, 0, "");
            return GetCarrierList(pgNumber, MaxResult);
        }

        public FillCarrier DeleteCarrier(Carrier obj, int pgNumber, int MaxResult, string MACAddress)
        {
            IList<Carrier> saveList = null;
            IList<Carrier> delList = new List<Carrier>();
            delList.Add(obj);
            IList<Carrier> CarrierTemp = null;
            SaveUpdateDelete_DBAndXML_WithTransaction(ref saveList, ref CarrierTemp, delList, MACAddress, false, false, 0, "");
            return GetCarrierList(pgNumber, MaxResult);
        }


        #endregion

        #region GetMethods

        public FillCarrier GetCarrierList(int pgNumber, int MaxResult)
        {
            FillCarrier objFillCarrier = new FillCarrier();
            ArrayList arrList = new ArrayList();
            Carrier objCarrier = new Carrier();
            IList<Carrier> carrierList = new List<Carrier>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = iMySession.GetNamedQuery("Fill.Carrier.GetCarrierCount");
                arrList = new ArrayList(query.List());
                if (arrList.Count > 0)
                {
                    objFillCarrier.CarrierCount = Convert.ToInt16(arrList[0]);
                }
                pgNumber = pgNumber - 1;
                IQuery query1 = iMySession.GetNamedQuery("Fill.Carrier.GetCarrierList")
                                    .SetInt64(0, pgNumber * MaxResult)
                                    .SetInt64(1, MaxResult);
                arrList = new ArrayList(query1.List());
                if (arrList.Count > 0)
                {
                    foreach (Object[] obj in arrList)
                    {

                        objCarrier = new Carrier();
                        objCarrier.Id = Convert.ToUInt64(obj[0]);
                        objCarrier.Carrier_Name = obj[1].ToString();
                        objCarrier.NAIC_ID = obj[2].ToString();
                        objCarrier.Created_By = obj[3].ToString();
                        objCarrier.Created_Date_And_Time = Convert.ToDateTime(obj[4]);
                        objCarrier.Modified_By = obj[5].ToString();
                        objCarrier.Modified_Date_And_Time = Convert.ToDateTime(obj[6]);
                        objCarrier.Version = Convert.ToInt16(obj[7]);
                        carrierList.Add(objCarrier);

                    }
                }
                objFillCarrier.CarrierList = carrierList;
                IList crit1 = iMySession.CreateCriteria(typeof(Carrier)).SetProjection(Projections.ProjectionList().Add(Projections.Property("Carrier_Name"), "Carrier_Name")).List();
                objFillCarrier.AllCarrierName = crit1;
                iMySession.Close();
            }
            return objFillCarrier;
        }

        public Carrier GetCarrierUsingId(ulong CarrierId)
        {
            Carrier objCarrier = new Carrier();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Carrier)).Add(Expression.Eq("Id", CarrierId));
                if (crit.List<Carrier>().Count != 0)
                    objCarrier = crit.List<Carrier>()[0];
                iMySession.Close();
            }

            return objCarrier;
        }
        public IList<Carrier> GetCarrierByName(string CarrierName)
        {

            ArrayList arrList = new ArrayList();
            Carrier objCarrier = new Carrier();
            IList<Carrier> carrierList = new List<Carrier>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                IQuery query = iMySession.GetNamedQuery("Get.CarrierDetailsForPaymentPosting");
                query.SetString(0, CarrierName + "%");
                arrList = new ArrayList(query.List());


                if (arrList.Count > 0)
                {
                    foreach (Object[] obj in arrList)
                    {

                        objCarrier = new Carrier();
                        objCarrier.Id = Convert.ToUInt64(obj[0]);
                        objCarrier.Carrier_Name = obj[2].ToString();
                        objCarrier.Carrier_Code = obj[1].ToString();
                        carrierList.Add(objCarrier);

                    }
                }
                iMySession.Close();
            }
            return carrierList;
        }

        public Carrier GetCarrierUsingCarrierName(string sCarrierName)
        {
            Carrier objCarrier = new Carrier();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Carrier)).Add(Expression.Eq("Carrier_Name", sCarrierName));
                if (crit.List<Carrier>().Count != 0)
                    objCarrier = crit.List<Carrier>()[0];
                iMySession.Close();
            }
            return objCarrier;
        }
        public IList<Carrier> GetCarrierByCarrierName(string Carrier_Name)
        {
            IList<Carrier> carrierList = new List<Carrier>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = iMySession.CreateCriteria(typeof(Carrier)).Add(Expression.Eq("Carrier_Name", Carrier_Name));
                carrierList= crit.List<Carrier>();
                iMySession.Close();
            }
            return carrierList;
        }

        #endregion


    }
}
