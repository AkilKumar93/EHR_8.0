using System;
using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using NHibernate;
using NHibernate.Criterion;
using System.Linq;

namespace Acurus.Capella.DataAccess.ManagerObjects
{

    public partial interface IRcopia_Prescription_ListManager : IManagerBase<Rcopia_Prescription_List, ulong>
    {
        void InsertOrUpdatePrescription_List(IList<Rcopia_Prescription_List> ilstRcopia_Prescription, string sUserName, string MACAddress, DateTime dtClientDate);
    }
    public partial class Rcopia_Prescription_ListManager : ManagerBase<Rcopia_Prescription_List, ulong>, IRcopia_Prescription_ListManager
    {

        #region Constructors

        public Rcopia_Prescription_ListManager()
            : base()
        {

        }
        public Rcopia_Prescription_ListManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion

        #region Methods

        //public void InsertOrUpdatePrescription_List(IList<Rcopia_Prescription_List> ilstRcopia_Prescription, string sUserName, string MACAddress, DateTime dtClientDate)
        //{
        //    if (ilstRcopia_Prescription.Count > 0)
        //    {
        //        IList<Rcopia_Prescription_List> Rcopia_PrescriptionUpdateList = new List<Rcopia_Prescription_List>();
        //        IList<Rcopia_Prescription_List> ilstRcopia_Prescription_List = new List<Rcopia_Prescription_List>();
        //        for (int i = 0; i < ilstRcopia_Prescription.Count; i++)
        //        {
        //            if (ilstRcopia_Prescription[i].Human_ID != 0)
        //            {
        //                Rcopia_Prescription_List objPrescription = GetRcopiaPrescriptionRecords(ilstRcopia_Prescription[i].Id);
        //                if (objPrescription == null)
        //                {
        //                    ilstRcopia_Prescription[i].Created_By = sUserName;
        //                    //ilstRcopia_Prescription[i].Created_Date_And_Time = DateTime.Now;
        //                    ilstRcopia_Prescription[i].Created_Date_And_Time = dtClientDate;
        //                    ilstRcopia_Prescription_List.Add(ilstRcopia_Prescription[i]);
        //                }
        //                else
        //                {
        //                    objPrescription.Modified_By = sUserName;
        //                    //objPrescription.Modified_Date_And_time = DateTime.Now;
        //                    objPrescription.Modified_Date_And_time = dtClientDate;
        //                    Rcopia_Prescription_List objUpdatePrescription = UpdatePrescriptionObject(objPrescription, ilstRcopia_Prescription[i]);
        //                    Rcopia_PrescriptionUpdateList.Add(objUpdatePrescription);
        //                }
        //            }
        //        }
        //        ulong EncounterORHumanId = 0;
        //        if (ilstRcopia_Prescription_List.Count > 0)
        //            EncounterORHumanId = ilstRcopia_Prescription_List[0].Human_ID;
        //        else
        //            EncounterORHumanId = Rcopia_PrescriptionUpdateList[0].Human_ID;
        //        SaveUpdateDelete_DBAndXML_WithTransaction(ref ilstRcopia_Prescription_List, ref Rcopia_PrescriptionUpdateList, null, MACAddress, true, true, EncounterORHumanId, string.Empty);

        //        //SaveUpdateDeleteWithTransaction(ref ilstRcopia_Prescription_List, Rcopia_PrescriptionUpdateList, null, MACAddress);
        //        //GenerateXml XMLObj = new GenerateXml();
        //        //if (ilstRcopia_Prescription_List.Count > 0)
        //        //{
        //        //    for (int i = 0; i < ilstRcopia_Prescription_List.Count; i++)
        //        //    {
        //        //        ulong uHuman_id = ilstRcopia_Prescription_List[i].Human_ID;
        //        //        List<object> lstObj = new List<object>();
        //        //        lstObj.Add(ilstRcopia_Prescription_List[i]);
        //        //        lstObj = lstObj.Cast<object>().ToList();
        //        //        XMLObj.GenerateXmlSaveStatic(lstObj, uHuman_id, string.Empty);
        //        //    }
        //        //}
        //        //if (Rcopia_PrescriptionUpdateList.Count > 0)
        //        //{
        //        //    for (int i = 0; i < Rcopia_PrescriptionUpdateList.Count; i++)
        //        //    {
        //        //        ulong uHuman_id = Rcopia_PrescriptionUpdateList[i].Human_ID;
        //        //        List<object> lstObj = new List<object>();
        //        //        lstObj.Add(Rcopia_PrescriptionUpdateList[i]);
        //        //        lstObj = lstObj.Cast<object>().ToList();
        //        //        XMLObj.GenerateXmlUpdate(lstObj, uHuman_id, string.Empty);
        //        //    }
        //        //}
        //    }
        //}

        public void InsertOrUpdatePrescription_List(IList<Rcopia_Prescription_List> ilstRcopia_Prescription, string sUserName, string MACAddress, DateTime dtClientDate)
        {
            if (ilstRcopia_Prescription.Count > 0)
            {
                IList<Rcopia_Prescription_List> Rcopia_PrescriptionUpdateList = new List<Rcopia_Prescription_List>();
                IList<Rcopia_Prescription_List> ilstRcopia_Prescription_List = new List<Rcopia_Prescription_List>();

                List<ulong> RcopiaID = ilstRcopia_Prescription.Select(x => x.Id).ToList<ulong>();

                IList<Rcopia_Prescription_List> lstPrescription = GetRcopiaPrescriptionRecords(RcopiaID);

                Rcopia_Prescription_List objPrescription = null;

                for (int i = 0; i < ilstRcopia_Prescription.Count; i++)
                {
                    if (ilstRcopia_Prescription[i].Human_ID != 0)
                    {
                        //Rcopia_Prescription_List objPrescription = GetRcopiaPrescriptionRecords(ilstRcopia_Prescription[i].Id);
                        IList<Rcopia_Prescription_List> presc = (from m in lstPrescription where m.Id == ilstRcopia_Prescription[i].Id select m).ToList<Rcopia_Prescription_List>();
                        if (presc != null && presc.Count > 0)
                            objPrescription = (Rcopia_Prescription_List)presc[0];
                        else
                            objPrescription = null;

                        if (objPrescription == null)
                        {
                            ilstRcopia_Prescription[i].Created_By = sUserName;
                            //ilstRcopia_Prescription[i].Created_Date_And_Time = DateTime.Now;
                            ilstRcopia_Prescription[i].Created_Date_And_Time = dtClientDate;
                            ilstRcopia_Prescription_List.Add(ilstRcopia_Prescription[i]);
                        }
                        else
                        {
                            objPrescription.Modified_By = sUserName;
                            //objPrescription.Modified_Date_And_time = DateTime.Now;
                            objPrescription.Modified_Date_And_time = dtClientDate;
                            Rcopia_Prescription_List objUpdatePrescription = UpdatePrescriptionObject(objPrescription, ilstRcopia_Prescription[i]);
                            Rcopia_PrescriptionUpdateList.Add(objUpdatePrescription);
                        }
                    }
                }
                ulong EncounterORHumanId = 0;
                if (ilstRcopia_Prescription_List.Count > 0)
                    EncounterORHumanId = ilstRcopia_Prescription_List[0].Human_ID;
                else if (Rcopia_PrescriptionUpdateList.Count>0)
                    EncounterORHumanId = Rcopia_PrescriptionUpdateList[0].Human_ID;
                if (EncounterORHumanId !=0)
                    SaveUpdateDelete_DBAndXML_WithTransaction(ref ilstRcopia_Prescription_List, ref Rcopia_PrescriptionUpdateList, null, MACAddress, true, true, EncounterORHumanId, string.Empty);

            }
        }




        public IList<Rcopia_Prescription_List> GetRcopiaPrescriptionRecords(IList<ulong> ulRcopia_ID)
        {
            IList<Rcopia_Prescription_List> objPrescription = new List<Rcopia_Prescription_List>();
            //ISession mySession = NHibernateSessionManager.Instance.CreateISession();
            using (ISession mySession = NHibernateSessionManager.Instance.CreateISession())
            {
                ICriteria crit = mySession.CreateCriteria(typeof(Rcopia_Prescription_List)).Add(Expression.In("Id", ulRcopia_ID.ToArray()));
                if (crit.List<Rcopia_Prescription_List>().Count > 0)
                {
                    objPrescription = crit.List<Rcopia_Prescription_List>();
                }
                mySession.Close();
            }
            return objPrescription;
        }

        public Rcopia_Prescription_List UpdatePrescriptionObject(Rcopia_Prescription_List objPrescription, Rcopia_Prescription_List UpdatePrescriptionObj)
        {
            objPrescription.Action = UpdatePrescriptionObj.Action;
            objPrescription.Brand_Name = UpdatePrescriptionObj.Brand_Name;
            objPrescription.Comments = UpdatePrescriptionObj.Comments;
            objPrescription.Dose = UpdatePrescriptionObj.Dose;
            objPrescription.Dose_Other = UpdatePrescriptionObj.Dose_Other;
            objPrescription.Dose_Timing = UpdatePrescriptionObj.Dose_Timing;
            objPrescription.Dose_Unit = UpdatePrescriptionObj.Dose_Unit;
            objPrescription.Drug = UpdatePrescriptionObj.Drug;
            objPrescription.Duration = UpdatePrescriptionObj.Duration;
            objPrescription.First_DataBank_Med_ID = UpdatePrescriptionObj.First_DataBank_Med_ID;
            objPrescription.Form = UpdatePrescriptionObj.Form;
            objPrescription.Generic_Name = UpdatePrescriptionObj.Generic_Name;
            objPrescription.Height = UpdatePrescriptionObj.Height;
            objPrescription.Intended_Use = UpdatePrescriptionObj.Intended_Use;
            objPrescription.Last_Modified_By = UpdatePrescriptionObj.Last_Modified_By;
            objPrescription.Last_Modified_Date = UpdatePrescriptionObj.Last_Modified_Date;
            objPrescription.NDC_ID = UpdatePrescriptionObj.NDC_ID;
            objPrescription.Other_Notes = UpdatePrescriptionObj.Other_Notes;
            objPrescription.Patient_Notes = UpdatePrescriptionObj.Patient_Notes;
            objPrescription.Quantity = UpdatePrescriptionObj.Quantity;
            objPrescription.Quantity_Unit = UpdatePrescriptionObj.Quantity_Unit;
            objPrescription.Refills = UpdatePrescriptionObj.Refills;
            objPrescription.Route = UpdatePrescriptionObj.Route;
            objPrescription.Signed_Date = UpdatePrescriptionObj.Signed_Date;
            objPrescription.Created_Date_And_Time = UpdatePrescriptionObj.Created_Date_And_Time;
            objPrescription.Stop_Date = UpdatePrescriptionObj.Stop_Date;
            objPrescription.Completed_Date = UpdatePrescriptionObj.Completed_Date;
            objPrescription.Strength = UpdatePrescriptionObj.Strength;
            objPrescription.Substitution_Permitted = UpdatePrescriptionObj.Substitution_Permitted;
            objPrescription.Weight = UpdatePrescriptionObj.Weight;
            objPrescription.Brand_Type = UpdatePrescriptionObj.Brand_Type;
            objPrescription.Prescription_Order = UpdatePrescriptionObj.Prescription_Order;
            objPrescription.ICD_Code = UpdatePrescriptionObj.ICD_Code;
            objPrescription.ICD_Code_Description = UpdatePrescriptionObj.ICD_Code_Description;
            objPrescription.Deleted = UpdatePrescriptionObj.Deleted;

            return objPrescription;
        }


        #endregion
    }
}
