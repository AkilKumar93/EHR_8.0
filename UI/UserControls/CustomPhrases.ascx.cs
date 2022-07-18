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
using Telerik.Web.UI;
using Acurus.Capella.Core.DTO;
using Acurus.Capella.Core.DomainObjects;
using System.Collections.Generic;
using Acurus.Capella.DataAccess.ManagerObjects;
using System.Drawing;

namespace Acurus.Capella.UI.UserControls
{
    public partial class CustomPhrases : System.Web.UI.UserControl
    {
        #region Declarations
        private string _FieldName;
        private TextBox _txtBox;
        private int _gridheight;
        private bool _enable = true;
        private PlaceHolder _placeholder;
        //IList<TemplatePhrases> objTemplatePhrases;
       // TemplatePhrasesManager tempMngr = new TemplatePhrasesManager();
        DataRow dr;
        RadGrid grdPhrases;
        #endregion

        #region Properties
        public TextBox MyTextBox
        {
            get { return _txtBox; }
            set { _txtBox = value; }
        }
        public PlaceHolder MyPlaceHolder
        {
            get { return _placeholder; }
            set { _placeholder = value; }
        }
        public string MyFieldName
        {
            get { return _FieldName; }
            set { _FieldName = value; }
        }
        public int MyGridHeight
        {
            get { return _gridheight; }
            set { _gridheight = value; }
        }


        public bool Enable
        {
            get { return _enable; }


            set
            {
                _enable = value;
                if (!_enable)
                {
                    pbCustomPhrases.Style.Add("background", "#808080");
                    pbCustomPhrases.Disabled = true;
                }
                else
                {
                    pbCustomPhrases.Style.Add("background", "#6DABF7");
                }
            }
        }
        #endregion


        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                MyPlaceHolder.Visible = false;
                hdnPlaceHolder.Value = MyPlaceHolder.Visible.ToString().ToLower();
            }
            else
            {
                if (hdnPlaceHolder.Value == "true")
                {
                    CreateControls();
                }
                //else if (hdnRefreshPhrase.Value == "true")
                //{
                //    DeletePhrases();
                //    hdnRefreshPhrase.Value = "false";
                //    CreateControls();
                //}
                //else if (hdnSave.Value == "true")
                //{
                //    CreateControls();
                //    hdnSave.Value = "false";
                //}
            }
            if (Enable == true)
                pbCustomPhrases.ServerClick += new EventHandler(pbCustomPhrases_ServerClick);
            this.PreRender += new EventHandler(Page_PreRenderComplete);
        }
        protected void pbCustomPhrases_ServerClick(object sender, EventArgs e)
        {
            MyPlaceHolder.Visible = (hdnPlaceHolder.Value == "true") ? true : false;
            if (MyPlaceHolder.Visible == true)
            {
                MyPlaceHolder.Visible = false;
                hdnPlaceHolder.Value = MyPlaceHolder.Visible.ToString().ToLower();
                hdnValue.Value = "";
            }
            else
            {
                MyPlaceHolder.Visible = true;
                hdnPlaceHolder.Value = MyPlaceHolder.Visible.ToString().ToLower();
                hdnValue.Value = "";
            }
            if (hdnPlaceHolder.Value == "true")//hdnValue.Value != "true")
            {
                CreateControls();
            }
        }
        protected void InvisibleButton_Click(object sender, EventArgs e)
        {
            SettingWhiteImage();
        }
        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            //if (ViewState["TemplatePhrases"] != null)
            //{
            //    IList<TemplatePhrases> PassList = (IList<TemplatePhrases>)ViewState["TemplatePhrases"];
            //    fillgrid(PassList);
            //}
        }
        void grdPhrases_ItemCommand(object sender, GridCommandEventArgs e)
        {
           // IList<TemplatePhrases> tempList = tempList = tempMngr.GetPhrasesName(Convert.ToInt32(ClientSession.TemplateId), MyFieldName, ClientSession.PhysicianUserName);
            //SettingWhiteImage();
            //if (e.CommandName == "EditRows")
            //{
            //    // ImageButton imnBtn = (ImageButton)e.CommandSource;
            //    //if (imnBtn.ImageUrl == "~/Resources/White.png")
            //    if ((grdPhrases.Items[e.Item.ItemIndex]["UserName"].Text == "ZZZZZ") || (grdPhrases.Items[e.Item.ItemIndex]["Phrases"].Text == "Click Here To Add New Phrase"))
            //    {
            //        return;
            //    }
            //    //string Phrases_ID = grdPhrases.Items[e.Item.ItemIndex]["Id"].Text;
            //}
            //if (e.CommandName == "DeleteRows")
            //{
            //    //ImageButton imnBtn = (ImageButton)e.CommandSource;
            //    //if (imnBtn.ImageUrl == "~/Resources/White.png")
            //    if ((grdPhrases.Items[e.Item.ItemIndex]["UserName"].Text == "ZZZZZ") || (grdPhrases.Items[e.Item.ItemIndex]["Phrases"].Text == "Click Here To Add New Phrase"))
            //    {
            //        return;
            //    }
            //    else
            //    {
            //        if (hdnDelImmuniztionId.Value != "")
            //        {
            //            tempList.Clear();
            //            tempList = DeletePhrases();
            //            ViewState["TemplatePhrases"] = tempList;
            //        }
            //    }
            //}
        }
        #endregion

        #region Methods
        //public IList<TemplatePhrases> DeletePhrases()
        //{
        //    IList<TemplatePhrases> DeleteList = (IList<TemplatePhrases>)ViewState["TemplatePhrases"];
        //    IList<TemplatePhrases> templatephrases = (from I in DeleteList where I.Id == Convert.ToInt64(hdnDelImmuniztionId.Value) select I).ToList<TemplatePhrases>();
        //    templatephrases[0].Modified_By = ClientSession.UserName;
        //    templatephrases[0].Modified_Date_And_Time = UtilityManager.ConvertToUniversal(DateTime.Now);
        //    IList<TemplatePhrases> returnList = tempMngr.DeleteIntoTemplatePhrases(templatephrases, string.Empty);
        //    return returnList;
        //}
        void CreateControls()
        {
            //if (ClientSession.TemplateId == 0)
            //{
            //    MyPlaceHolder.Visible = false;
            //    hdnPlaceHolder.Value = MyPlaceHolder.Visible.ToString().ToLower();
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), string.Empty, "alert('Please select a Template');", true);
            //    return;
            //}
            // MyTextBox.Attributes.Add("onkeydown", "insertTab(this,event);");
            grdPhrases = new RadGrid();
            grdPhrases.Visible = true;
            grdPhrases.ID = "grdPhrases-" + MyTextBox.ClientID + "-" + MyFieldName + "-" + hdnValue.ClientID + "-" + InvisibleButton.ClientID + "-" + hdnRefreshPhrase.ClientID + "-" + hdnSave.ClientID;
            grdPhrases.Width = MyTextBox.Width;
            if (MyGridHeight == 0)
            {
                grdPhrases.Height = MyTextBox.Height;
            }
            else
            {
                grdPhrases.Height = MyGridHeight;
            }
            grdPhrases.Style["position"] = "absolute";
            grdPhrases.PageSize = 5;
            grdPhrases.AutoGenerateColumns = false;
            grdPhrases.Skin = "Vista";
            grdPhrases.ClientSettings.Selecting.CellSelectionMode = GridCellSelectionMode.SingleCell;
            grdPhrases.ClientSettings.Scrolling.AllowScroll = true;
            //grdPhrases.MasterTableView.ShowHeader = false;
            //grdPhrases.MasterTableView.ExpandCollapseColumn.Display = false;
            grdPhrases.ItemCommand += new GridCommandEventHandler(grdPhrases_ItemCommand);
            grdPhrases.ClientSettings.ClientEvents.OnCellSelected = "PhrasesCellSelected";
            if (ClientSession.UserRole == "Physician Assistant" || ClientSession.UserRole == "Physician")
            {
                GridButtonColumn imgEdit = new GridButtonColumn();
                imgEdit.HeaderStyle.Font.Bold = true;
                imgEdit.ButtonType = GridButtonColumnType.ImageButton;
                imgEdit.HeaderStyle.Width = 10;
                imgEdit.DataTextField = "EditRows";
                imgEdit.HeaderText = "Edit";
                imgEdit.UniqueName = "EditRows";
                imgEdit.ImageUrl = "~/Resources/edit.gif";
                imgEdit.CommandName = "EditRows";
                imgEdit.FilterControlAltText = "Filter EditRows column";
                //grdPhrases.MasterTableView.Columns.Add(imgEdit);
                grdPhrases.Columns.Add(imgEdit);

                GridButtonColumn imgDel = new GridButtonColumn();
                imgDel.HeaderStyle.Font.Bold = true;
                imgDel.ButtonType = GridButtonColumnType.ImageButton;
                imgDel.HeaderStyle.Width = 10;
                imgDel.DataTextField = "DeleteRows";
                imgDel.HeaderText = "Del";
                imgDel.UniqueName = "DeleteRows";
                imgDel.ImageUrl = "~/Resources/close_small_pressed.png";
                imgDel.CommandName = "DeleteRows";
                imgDel.FilterControlAltText = "Filter DeleteRows column";
                //grdPhrases.MasterTableView.Columns.Add(imgDel);
                grdPhrases.Columns.Add(imgDel);
            }
            GridBoundColumn boundPhrases = new GridBoundColumn();
            boundPhrases.HeaderStyle.Font.Bold = true;
            //boundPhrases.HeaderStyle.Font.Bold = true;
            boundPhrases.DataField = "Phrases";
            boundPhrases.HeaderText = "Phrases";
            boundPhrases.UniqueName = "Phrases";
            //grdPhrases.MasterTableView.Columns.Add(boundPhrases);
            grdPhrases.Columns.Add(boundPhrases);

            GridBoundColumn boundPhrases2 = new GridBoundColumn();
            boundPhrases2.HeaderStyle.Font.Bold = true;
            //boundPhrases2.HeaderStyle.Font.Bold = true;
            boundPhrases2.DataField = "UserName";
            boundPhrases2.HeaderText = "UserName";
            boundPhrases2.UniqueName = "UserName";
            boundPhrases2.Display = false;
            //grdPhrases.MasterTableView.Columns.Add(boundPhrases2);
            grdPhrases.Columns.Add(boundPhrases2);

            GridBoundColumn boundPhrases1 = new GridBoundColumn();
            boundPhrases1.HeaderStyle.Font.Bold = true;
            //boundPhrases1.HeaderStyle.Font.Bold = true;
            boundPhrases1.DataField = "Id";
            boundPhrases1.HeaderText = "Id";
            boundPhrases1.UniqueName = "Id";
            boundPhrases1.Display = false;
            //grdPhrases.MasterTableView.Columns.Add(boundPhrases1);
            grdPhrases.Columns.Add(boundPhrases1);

            GridBoundColumn boundPhrases3 = new GridBoundColumn();
            boundPhrases3.HeaderStyle.Font.Bold = true;
            //boundPhrases3.HeaderStyle.Font.Bold = true;
            boundPhrases3.DataField = "color";
            boundPhrases3.HeaderText = "color";
            boundPhrases3.UniqueName = "color";
            boundPhrases3.Display = false;
            //grdPhrases.MasterTableView.Columns.Add(boundPhrases3);
            grdPhrases.Columns.Add(boundPhrases3);

           //// objTemplatePhrases = tempMngr.GetPhrasesName(Convert.ToInt32(ClientSession.TemplateId), MyFieldName, ClientSession.PhysicianUserName);
           // ViewState["TemplatePhrases"] = objTemplatePhrases;

            MyPlaceHolder.Controls.Add(grdPhrases);
            //fillgrid(objTemplatePhrases);
        }
        //public void fillgrid(IList<TemplatePhrases> objTemplatePhrases)
        //{
        //    grdPhrases.DataSource = null;
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Phrases", typeof(string));
        //    dt.Columns.Add("UserName", typeof(string));
        //    dt.Columns.Add("Id", typeof(string));
        //    dt.Columns.Add("color", typeof(string));
        //    if (ClientSession.UserRole == "Physician Assistant" || ClientSession.UserRole == "Physician")
        //    {
        //        dr = dt.NewRow();
        //        dr["Phrases"] = "Click Here To Add New Phrase";
        //        dt.Rows.Add(dr);
        //    }
        //    for (int i = 0; i < objTemplatePhrases.Count; i++)
        //    {
        //        if (objTemplatePhrases[i].Phrases.ToUpper() != "ALL")
        //        {
        //            dr = dt.NewRow();
        //            dr["Phrases"] = objTemplatePhrases[i].Phrases;
        //            dr["UserName"] = objTemplatePhrases[i].User_Name;
        //            dr["Id"] = objTemplatePhrases[i].Id.ToString();
        //            dr["color"] = "";
        //            dt.Rows.Add(dr);
        //        }
        //    }
        //    grdPhrases.DataSource = dt;
        //    grdPhrases.DataBind();
        //    bool btrue = true;
        //    foreach (GridDataItem item in grdPhrases.Items)
        //    {
        //        string strTemplateName = item["UserName"].Text;
        //        if (btrue == true)
        //        {
        //            if (ClientSession.UserRole == "Physician Assistant" || ClientSession.UserRole == "Physician")
        //            {
        //                TableCell selectCell = item["EditRows"];
        //                ImageButton gd = (ImageButton)selectCell.Controls[0];
        //                gd.ImageUrl = "~/Resources/White.png";
        //                TableCell selectCell1 = item["DeleteRows"];
        //                ImageButton gdDel = (ImageButton)selectCell1.Controls[0];
        //                gdDel.ImageUrl = "~/Resources/White.png";
        //            }
        //            btrue = false;
        //        }
        //        else if (strTemplateName == "ZZZZZ")
        //        {
        //            if (ClientSession.UserRole == "Physician Assistant" || ClientSession.UserRole == "Physician")
        //            {
        //                TableCell selectCell = item["EditRows"];
        //                ImageButton gd = (ImageButton)selectCell.Controls[0];
        //                gd.Attributes.Add("src", "Resources/White.png");
        //                gd.ImageUrl = "~/Resources/White.png";
        //                TableCell selectCell1 = item["DeleteRows"];
        //                ImageButton gdDel = (ImageButton)selectCell1.Controls[0];
        //                gdDel.ImageUrl = "~/Resources/White.png";
        //            }
        //            TableCell selectCell4 = item["Phrases"];
        //            selectCell4.Style["color"] = "Blue";
        //        }
        //        else
        //        {
        //            TableCell selectCell5 = item["Id"];

        //            if (ClientSession.UserRole == "Physician Assistant" || ClientSession.UserRole == "Physician")
        //            {
        //                TableCell selectCell = item["EditRows"];
        //                ImageButton gd = (ImageButton)selectCell.Controls[0];
        //                gd.Attributes.Add("onclick", "OpenAddorEditUserDefinedPhraes('" + selectCell5.Text + "," + MyFieldName + "," + hdnSave.ClientID + "," + "true" + "'); return false;");
        //                //gd.ImageUrl = "~/Resources/edit.gif";
        //                TableCell selectCellDel = item["DeleteRows"];
        //                ImageButton gdDel = (ImageButton)selectCellDel.Controls[0];
        //                gdDel.Attributes.Add("onclick", "CellValueSelected('" + selectCell5.Text + "," + hdnDelImmuniztionId.ClientID + "," + hdnRefreshPhrase.ClientID + "')");
        //                //gdDel.ImageUrl = "~/Resources/close_small_pressed.png";
        //            }

        //            if (hdnValue.Value.Contains(item["Phrases"].Text))
        //            {
        //                TableCell selectCell4 = item["Phrases"];
        //                selectCell4.Style["color"] = "grey";
        //                hdnRefreshPhrase.Value = "true";

        //                TableCell selectCellcolor = item["color"];
        //                selectCellcolor.Text = "grey";
        //            }
        //            else
        //            {
        //                TableCell selectCell4 = item["Phrases"];
        //                selectCell4.Style["color"] = "";
        //                hdnRefreshPhrase.Value = "false";

        //                TableCell selectCellcolor = item["color"];
        //                selectCellcolor.Text = "black";
        //            }
        //        }
        //    }
        //}
        void SettingWhiteImage()
        {
            for (int ItemIndex = 0; ItemIndex < grdPhrases.Items.Count; ItemIndex++)
            {
                if ((grdPhrases.Items[ItemIndex]["UserName"].Text == "ZZZZZ") || (grdPhrases.Items[ItemIndex]["Phrases"].Text == "Click Here To Add New Phrase"))
                {
                    ((ImageButton)grdPhrases.Items[ItemIndex]["EditRows"].Controls[0]).ImageUrl = "~/Resources/White.png";
                    ((ImageButton)grdPhrases.Items[ItemIndex]["DeleteRows"].Controls[0]).ImageUrl = "~/Resources/White.png";
                    if (grdPhrases.Items[ItemIndex]["UserName"].Text == "ZZZZZ")
                    {
                        grdPhrases.Items[ItemIndex]["Phrases"].ForeColor = Color.Blue;
                    }
                }
            }
        }
        #endregion
    }
}