using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Acurus.Capella.DataAccess.ManagerObjects;
using Acurus.Capella.Core.DTO;
using Acurus.Capella.Core.DomainObjects;
using System.Collections.Generic;

namespace Acurus.Capella.UI
{
    public partial class frmCarrierLibrary : System.Web.UI.Page
    {
        int TotalCount = 0;
        int PageIndex = 1;
        protected int pageIndex = 1;
        protected int pageCount = 0;
        Double myPageNumber;
        int iMyLastPageNo;
        CarrierManager CarrierMngr = new CarrierManager();
        int MaxResultPerPage = 25;
        int PageNumber = 1;
        ulong UpdtCarrierID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ClientSession.FlushSession();
                btnFirst.Enabled = false;
                btnNext.Enabled = false;
                btnLast.Enabled = false;
                btnPrevious.Enabled = false;
                FillCarrier objFillCarrierDTO = new FillCarrier();
                objFillCarrierDTO = CarrierMngr.GetCarrierList(PageNumber, 25);
                FillCarrierGrid(objFillCarrierDTO.CarrierList);
                TotalCount = objFillCarrierDTO.CarrierCount;
                hdnTotalCount.Value = TotalCount.ToString();
                pageCount = Convert.ToInt32(GetTotalNoofDBRecords());
                Session["PageCount"] = pageCount;
                RefreshPageButtons();
                //btnSave.Enabled = false;
            }
        }
        public void FillCarrierGrid(IList<Carrier> list)
        {
            if (grdCarrierLibrary.Rows.Count > 0)
                grdCarrierLibrary.DataSource = null;
            grdCarrierLibrary.DataBind();

            if (list != null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Carrier ID", typeof(string));
                dt.Columns.Add("Carrier Name", typeof(string));
                dt.Columns.Add("NAIC ID", typeof(string));
                foreach (Carrier obj in list)
                {
                    DataRow dr = dt.NewRow();

                    dr["Carrier ID"] = obj.Id.ToString();
                    dr["Carrier Name"] = obj.Carrier_Name;
                    dr["NAIC ID"] = obj.NAIC_ID.ToString();
                    dt.Rows.Add(dr);
                }
                grdCarrierLibrary.DataSource = dt;
                grdCarrierLibrary.DataBind();
            }

        }
        protected void PageChangeEventHandler(object sender, CommandEventArgs e)
        {


            switch (e.CommandArgument.ToString())
            {

                case "First":

                    Session["PageNumber"] = 1;

                    break;


                case "Previous":

                    if (Convert.ToInt32(Session["PageNumber"]) > 1)
                    {
                        PageNumber = Convert.ToInt32(Session["PageNumber"]) - 1;
                        Session["PageNumber"] = PageNumber;
                    }

                    break;
                case "Next":
                    if (btnFirst.Enabled == false && btnPrevious.Enabled == false)
                    {
                        Session["PageNumber"] = 1;
                    }
                    if (Convert.ToInt32(Session["PageNumber"]) < Convert.ToInt32(hdnLastPageNo.Value))
                    {
                        PageNumber = Convert.ToInt32(Session["PageNumber"]) + 1;
                        Session["PageNumber"] = PageNumber;
                    }

                    break;

                case "Last":

                    PageNumber = Convert.ToInt32(hdnLastPageNo.Value);
                    break;





            }
            Session["PageNumber"] = PageNumber;

            Fill();

            RefreshPageButtons();




        }
        private void RefreshPageButtons()
        {

            int iStartPageNo = 0;
            int iEndPageNo = 0;
            if (hdnLastPageNo.Value != string.Empty)
            {

                if (Convert.ToInt32(hdnLastPageNo.Value) == 0)
                {
                    iStartPageNo = 0;
                }
                else
                {
                    iStartPageNo = ((PageNumber - 1) * MaxResultPerPage) + 1;
                }
            }

            iEndPageNo = (PageNumber * MaxResultPerPage);
            // lblShowing.Text = "Showing " + iStartPageNo.ToString() + " - " + (iEndPageNo).ToString() + " of " + TotalNoofDBRecords.ToString();
            lblShowing.Text = "Showing " + iStartPageNo.ToString() + " - " + (iEndPageNo).ToString() + " of " + TotalCount.ToString();
            if (iEndPageNo == 0)
            {
                btnFirst.Enabled = false;
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
                btnLast.Enabled = false;
                return;
            }
            else
            {
                // lblShowing.Show();
            }

            if (PageNumber == 1)
            {
                btnFirst.Enabled = false;
                btnPrevious.Enabled = false;
            }
            else
            {
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
            }
            if (iEndPageNo >= Convert.ToInt32(hdnTotalCount.Value))
            {
                iEndPageNo = Convert.ToInt32(hdnTotalCount.Value);

                if (iStartPageNo == 0 && iEndPageNo != 0)
                {
                    iStartPageNo = 1;
                }
                lblShowing.Text = "Showing " + iStartPageNo.ToString() + " - " + (iEndPageNo).ToString() + " of " + TotalCount.ToString();
                // lblShowing.Text = "Showing " + iStartPageNo.ToString() + " - " + (iEndPageNo).ToString() + " of " + TotalNoofDBRecords.ToString();
                btnLast.Enabled = false;
                btnNext.Enabled = false;
            }
            else
            {
                btnLast.Enabled = true;
                btnNext.Enabled = true;
            }
        }
        public double GetTotalNoofDBRecords()
        {


            if (TotalCount != 0)
            {
                myPageNumber = (double)(TotalCount) / (double)(MaxResultPerPage);
                iMyLastPageNo = Convert.ToInt32(Math.Ceiling(myPageNumber));
                //Session["iMyLastPageNo"] = iMyLastPageNo;
                hdnLastPageNo.Value = iMyLastPageNo.ToString();
            }
            LinkButtonLoad();
            return myPageNumber;
        }
        private void LinkButtonLoad()
        {
            int iStartPageNo = 0;
            int iEndPageNo = 0;

            if (TotalCount == 0)
            {
                iStartPageNo = 0;
            }
            else
            {
                if (hdnLastPageNo.Value != string.Empty)
                {
                    iStartPageNo = ((Convert.ToInt32(hdnLastPageNo.Value) - 1) * MaxResultPerPage) + 1;
                }
            }
            iEndPageNo = ((PageNumber) * MaxResultPerPage);


            if (hdnLastPageNo.Value != string.Empty)
            {
                iEndPageNo = ((Convert.ToInt32(hdnLastPageNo.Value)) * MaxResultPerPage);
            }

            if (iEndPageNo == 0)
            {
                btnFirst.Enabled = false;
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
                btnLast.Enabled = false;
                return;
            }
            else
            {

            }

            if (PageNumber == 1)
            {
                btnFirst.Enabled = false;
                btnPrevious.Enabled = false;
            }
            else
            {
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
            }
            if (iEndPageNo >= TotalCount)
            {
                iEndPageNo = TotalCount;

                if (iStartPageNo == 0 && iEndPageNo != 0)
                {
                    iStartPageNo = 1;
                }


                btnLast.Enabled = false;
                btnNext.Enabled = false;
            }
            else
            {
                btnLast.Enabled = true;
                btnNext.Enabled = true;
            }
        }
        public void Fill()
        {
            FillCarrier objFillCarrierDTO = new FillCarrier();
            objFillCarrierDTO = CarrierMngr.GetCarrierList(PageNumber, 25);
            FillCarrierGrid(objFillCarrierDTO.CarrierList);
            TotalCount = objFillCarrierDTO.CarrierCount;
            hdnTotalCount.Value = TotalCount.ToString();


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //btnSave.Enabled = false;

            FillCarrier objFillCarrierDTO = null; ;

            if (txtCarrierName.Text.Trim() == string.Empty)
            {
                //ApplicationObject.erroHandler.DisplayErrorMessage("640003", "Carrier Library", this.Page);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Keys", "alert('Please enter the Carrier Name');", true);
                txtCarrierName.Focus();
                //btnSave.Enabled = true;
                return;
            }
            objFillCarrierDTO = CarrierMngr.GetCarrierList(PageNumber, 25);
            if (objFillCarrierDTO.AllCarrierName != null && btnSave.Text != "Update")
            {
                if (objFillCarrierDTO.AllCarrierName.Contains(txtCarrierName.Text.Trim().ToUpper()) || objFillCarrierDTO.AllCarrierName.Contains(txtCarrierName.Text.Trim()))
                {
                    //ApplicationObject.erroHandler.DisplayErrorMessage("640007", "Carrier Library", this.Page);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Keys", "alert('Entered Carrier name is already available in DB.');", true);
                    txtCarrierName.Focus();
                    //btnSave.Enabled = true;
                    return;
                }
            }

            if (btnSave.Text == "Save")
            {
                Carrier objCarrier = new Carrier();
                objCarrier.Carrier_Name = txtCarrierName.Text.Trim();
                objCarrier.NAIC_ID = txtNAICID.Text.Trim();
                objCarrier.Created_By = ClientSession.UserName;
                if (hdnLocalTime.Value != string.Empty)
                {
                    objCarrier.Created_Date_And_Time = Convert.ToDateTime(hdnLocalTime.Value);
                }

                objFillCarrierDTO = CarrierMngr.InsertCarrier(objCarrier, PageNumber, 25, string.Empty);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Key", "alert('Saved Successfully');", true);
                // ApplicationObject.erroHandler.DisplayErrorMessage("640001", "Carrier Library", this.Page);
            }
            else
            {
                ulong UpdateCarrierID = 0;
                if (hdnUpdateCarrierID.Value != string.Empty)
                {
                    UpdateCarrierID = Convert.ToUInt64(hdnUpdateCarrierID.Value);
                }
                var updtobj = from obj in objFillCarrierDTO.CarrierList where obj.Id == UpdateCarrierID select obj;
                IList<Carrier> updtCarrList = updtobj.ToList<Carrier>();
                if (updtCarrList.Count > 0)
                {
                    Carrier objCarrier = updtCarrList[0];
                    objCarrier.Carrier_Name = txtCarrierName.Text.Trim();
                    objCarrier.NAIC_ID = txtNAICID.Text.Trim();
                    objCarrier.Modified_By = ClientSession.UserName;
                    if (hdnLocalTime.Value != string.Empty)
                    {
                        objCarrier.Modified_Date_And_Time = Convert.ToDateTime(hdnLocalTime.Value);
                    }
                    objFillCarrierDTO = CarrierMngr.UpdateCarrier(objCarrier, PageNumber, 25, string.Empty);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Key", "alert('Saved Successfully');", true);
                    //  ApplicationObject.erroHandler.DisplayErrorMessage("640002", "Carrier Library", this.Page);
                }
            }

            FillCarrierGrid(objFillCarrierDTO.CarrierList);
            ClearText();

        }
        public void ClearText()
        {
            txtCarrierName.Text = string.Empty;
            txtCarrierID.Text = string.Empty;
            txtNAICID.Text = string.Empty;
            btnSave.Text = "Save";
            btnClearAll.Text = "Clear All";
            lblShowing.Text = string.Empty;
            btnFirst.Enabled = false;
            btnLast.Enabled = false;
            btnNext.Enabled = false;
            btnPrevious.Enabled = false;
            //btnSave.Enabled = false;
        }

        protected void grdCarrierLibrary_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditC")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int Rowindex = row.RowIndex;
                //int Rowindex = Convert.ToInt32(e.CommandArgument);
                ulong CarrierID = Convert.ToUInt64(grdCarrierLibrary.Rows[Rowindex].Cells[2].Text);
                Carrier objCarrier = CarrierMngr.GetCarrierUsingId(CarrierID);

                txtCarrierID.Text = objCarrier.Id.ToString();
                txtCarrierName.Text = objCarrier.Carrier_Name;
                txtNAICID.Text = objCarrier.NAIC_ID;
                UpdtCarrierID = CarrierID;
                hdnUpdateCarrierID.Value = CarrierID.ToString();
                btnSave.Text = "Update";
                btnClearAll.Text = "Cancel";
                //btnSave.Enabled = true;
            }
            else if (e.CommandName == "DeleteRow")
            {
               
                FillCarrier objFillCarrierDTO;
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int Rowindex = row.RowIndex;
                ulong CarrierID = Convert.ToUInt64(grdCarrierLibrary.Rows[Rowindex].Cells[2].Text);
                ulong delId = Convert.ToUInt64(grdCarrierLibrary.Rows[Rowindex].Cells[2].Text);
                Carrier objCarrier = CarrierMngr.GetCarrierUsingId(CarrierID);
                if (objCarrier != null)
                {
                    if (objCarrier.Id == delId)
                    {
                        Carrier objResult = objCarrier;
                        //objResult.Modified_By = ClientSession.UserName;
                        //objResult.Modified_Date_And_Time = Convert.ToDateTime(hdnLocalTime.Value);
                        //objResult.Modified_Date_And_Time = UtilityManager.ConvertToUniversal();
                        objFillCarrierDTO = CarrierMngr.DeleteCarrier(objResult, PageNumber, 25, string.Empty);
                        FillCarrierGrid(objFillCarrierDTO.CarrierList);
                        ClearText();
                    }
                }


            }
        }

        protected void btnClearAll_Click(object sender, EventArgs e)
        {
            if (txtCarrierID.Text.Trim() != string.Empty || txtCarrierName.Text.Trim() != string.Empty || txtNAICID.Text.Trim() != string.Empty)
            {
                ArrayList errList = new ArrayList();
                errList.Add(btnClearAll.Text.Replace("&", string.Empty));
                //ApplicationObject.erroHandler.DisplayErrorMessage("640006", "Carrier Library", errList, this.Page);
                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Key", "alert('Do you want to Clear all without saving?');", true);
                ClearText();
            }
            else
                ClearText();
        }

        protected void txtCarrierName_TextChanged(object sender, EventArgs e)
        {
            if (txtCarrierName.Text != string.Empty)
            {
                //btnSave.Enabled = false;

            }
            else
            {
                //btnSave.Enabled = false;
            }

        }

        protected void grdCarrierLibrary_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}
