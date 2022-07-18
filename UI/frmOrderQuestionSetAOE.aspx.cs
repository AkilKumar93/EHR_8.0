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
using System.Collections.Generic;
using Telerik.Web.UI;
using Acurus.Capella.DataAccess.ManagerObjects;
using System.Drawing;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.UI
{
    public partial class frmOrderQuestionSetAOE : System.Web.UI.Page
    {
        AOELookUpManager objAOELookUpManager = new AOELookUpManager();
        OrdersManager objOrdersManager = new OrdersManager();
        OrdersQuestionSetAOEManager objAOEMngr = new OrdersQuestionSetAOEManager();
        IList<OrdersQuestionSetAOE> ilstAOE = new List<OrdersQuestionSetAOE>();
        IList<Orders> ilstOrders = new List<Orders>();
        IList<AOELookUp> ilstAOELookUp = new List<AOELookUp>();
        Dictionary<IList<string>,string> val = new Dictionary<IList<string>,string>();


        protected void Page_Load(object sender, EventArgs e)
        {
                if (Request["OrderSubmitID"] != null)
                {
                    ilstAOE = objAOEMngr.GetAOEList(Convert.ToUInt32(Request["OrderSubmitID"]));
                    ilstOrders = objOrdersManager.GetOrderId(Convert.ToUInt32(Request["OrderSubmitID"]));

                    FillOrdersQuestionsetAOE(ilstAOE, ilstOrders);
                }
                btnOK.Enabled = false;
                btnClearAll.Enabled = false;
        }

        public void FillOrdersQuestionsetAOE(IList<OrdersQuestionSetAOE> ilstAOE,IList<Orders> ilstOrders)
        {
            ilstAOELookUp = objAOELookUpManager.GetAOELookUpList();

            Table tbMain = new Table();
            TableCell tcMain = null;
            TableRow trMain = null;
            for (int i = 0; i < ilstOrders.Count; i++)
            {
                IList<string> ilstA = new List<string>();
                Table tbHeader = new Table();
                TableCell tcHeader = new TableCell();
                TableRow trHeader = new TableRow();
                Label lblHeader = new Label();
                lblHeader.ID = "lbl" + ilstOrders[i].Lab_Procedure;
                lblHeader.Text = ilstOrders[i].Lab_Procedure + "-" + ilstOrders[i].Lab_Procedure_Description;
                lblHeader.Width = 500;
                lblHeader.BorderWidth = 1;
                lblHeader.BorderColor = System.Drawing.Color.Black;
                lblHeader.ForeColor = System.Drawing.Color.Black;
                lblHeader.Font.Bold = true;
                lblHeader.BackColor = System.Drawing.Color.FromName("#BFDBFF");
                tcHeader.Controls.Add(lblHeader);
                trHeader.Controls.Add(tcHeader);
                tbHeader.Controls.Add(trHeader);
                tcMain = new TableCell();
                trMain = new TableRow();
                tcMain.Controls.Add(tbHeader);
                trMain.Controls.Add(tcMain);
                tbMain.Controls.Add(trMain);
                IList<AOELookUp> ilstFillAOE = ilstAOELookUp.Where(a => a.Order_Code == ilstOrders[i].Lab_Procedure).OrderBy(a => a.AOE_Question).ToList<AOELookUp>();
                IList<OrdersQuestionSetAOE> ilstFillAOE1 = ilstAOE.Where(a => a.Order_Code == ilstOrders[i].Lab_Procedure).ToList<OrdersQuestionSetAOE>();
                TableCell tcControls = null;
                TableRow trControls = null;
                Table tbControls = new Table();
                
                for (int j = 0; j < ilstFillAOE.Count; j++)
                {
                    
                    tcControls = new TableCell();

                    trControls = new TableRow(); 
                    
                    Label lbl = new Label();
                    RadTextBox txtbox = new RadTextBox();
                    int c = 0;
                    string sID = string.Empty;
                    for (int k = 0; k < ilstFillAOE1.Count; k++)
                    {
                        if (ilstFillAOE[j].AOE_Question == ilstFillAOE1[k].AOE_Question)
                        {
                            sID = string.Empty;
                            sID = ilstOrders[i].Lab_Procedure + ilstFillAOE[j].AOE_Question;
                            if (sID.Contains('#'))
                               sID= sID.Replace("#", "");
                            if (sID.Contains(':'))
                                sID=sID.Replace(":", "");
                            lbl.ID = "lbl" + sID; 
                            lbl.ID = "lbl" + ilstOrders[i].Lab_Procedure + ilstFillAOE1[k].AOE_Question;
                            lbl.Text = ilstFillAOE1[k].AOE_Question;
                            txtbox.ID = "txt" + ilstOrders[i].Lab_Procedure + ilstFillAOE1[k].AOE_Question;
                            txtbox.Text = ilstFillAOE1[k].AOE_Value;
                            txtbox.ClientEvents.OnKeyPress = "txtbox_OnKeyPress";
                            ilstA.Add(ilstFillAOE1[k].AOE_Question);
                            val.Add(new List<string>() { lbl.ID, txtbox.ID }, ilstOrders[i].Lab_Procedure);

                        }
                        c = k;
                    }
                    if (lbl.ID != "lbl" + ilstOrders[i].Lab_Procedure + ilstFillAOE[j].AOE_Question && c == ilstFillAOE1.Count - 1 || ilstFillAOE1.Count == 0)
                    {
                        sID = string.Empty;
                        sID = ilstOrders[i].Lab_Procedure + ilstFillAOE[j].AOE_Question;
                        if (sID.Contains('#'))
                           sID= sID.Replace("#", "");
                        if (sID.Contains(':'))
                           sID= sID.Replace(":", "");
                        lbl.ID = "lbl" + sID; 
                        lbl.Text = ilstFillAOE[j].AOE_Question;
                        txtbox.ID = "txt" + sID;
                        txtbox.ClientEvents.OnKeyPress = "txtbox_OnKeyPress";
                        txtbox.Text = string.Empty;
                        val.Add(new List<string>() { lbl.ID, txtbox.ID }, ilstOrders[i].Lab_Procedure);
                    }


                    lbl.Width = 200;
                    lbl.Height = 20;
                    tcControls.ColumnSpan = 2;
                    tcControls.Controls.Add(lbl);
                    trControls.Controls.Add(tcControls);

                    tcControls = new TableCell();

                    txtbox.Width = 300;
                    txtbox.Height = 20;

                    tcControls.Controls.Add(txtbox);
                    trControls.Controls.Add(tcControls);
                    tbControls.Controls.Add(trControls);
                }
                if (ilstA.Count != ilstFillAOE1.Count)
                {

                    foreach (string st in ilstA)
                    {

                        IList<OrdersQuestionSetAOE> ilstNew = ilstFillAOE1.Where(a => a.AOE_Question == st).ToList<OrdersQuestionSetAOE>();
                        if (ilstNew.Count > 0)
                            ilstFillAOE1.RemoveAt(ilstFillAOE1.IndexOf(ilstNew[0]));
                    }

                    for (int q = 0; q < ilstFillAOE1.Count; q++)
                    {
                        Label lbl = new Label();
                        RadTextBox txtbox = new RadTextBox();
                        trControls = new TableRow();

                        tcControls = new TableCell();
                        string sIDAOE=ilstOrders[i].Lab_Procedure + ilstFillAOE1[q].Order_Code + ilstFillAOE1[q].AOE_Question;
                        if(sIDAOE.Contains('#'))
                           sIDAOE= sIDAOE.Replace("#","");
                        if (sIDAOE.Contains(':'))
                            sIDAOE= sIDAOE.Replace(":","");
                        lbl.ID = "lbl" + sIDAOE;
                        lbl.Text = ilstFillAOE1[q].AOE_Question;
                        txtbox.ID = "txt" + sIDAOE;
                        txtbox.ClientEvents.OnKeyPress = "txtbox_OnKeyPress";
                        txtbox.Text = ilstFillAOE1[q].AOE_Value;
                        txtbox.AutoPostBack = true;
                        val.Add(new List<string>() { lbl.ID, txtbox.ID }, ilstOrders[i].Lab_Procedure);

                        tcControls.ColumnSpan = 2;
                        tcControls.Controls.Add(lbl);
                        trControls.Controls.Add(tcControls);

                        tcControls = new TableCell();
                        lbl.Width = 200;
                        lbl.Height = 20;
                        txtbox.Width = 300;
                        txtbox.Height = 20;
                        tcControls.Controls.Add(txtbox);
                        trControls.Controls.Add(tcControls);
                        tbControls.Controls.Add(trControls);
                    }
                }
                
                tcMain = new TableCell();
                trMain = new TableRow();
                tcMain.Controls.Add(tbControls);
                trMain.Controls.Add(tcMain);
                tbMain.Controls.Add(trMain);

            }
            Panel1.Controls.Add(tbMain);
        }

        void txtbox_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = true;
            btnClearAll.Enabled = true;
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            IList<OrdersQuestionSetAOE> ilstSaveAOE = new List<OrdersQuestionSetAOE>();
            foreach (KeyValuePair<IList<string>, string> de in val)
            {
                Label lb = new Label();
                lb.Text = de.Value;
                IList<string> IdValue = de.Key;
                OrdersQuestionSetAOE objAOE = new OrdersQuestionSetAOE();
                objAOE.Encounter_ID = ClientSession.EncounterId;
                objAOE.Human_ID = ClientSession.HumanId;
                objAOE.Physician_ID = ClientSession.PhysicianId;
                objAOE.Orders_ID =0;
                objAOE.AOE_Question = ((Label)Page.FindControl(IdValue[0])).Text;
                objAOE.AOE_Value = ((RadTextBox)Page.FindControl(IdValue[1])).Text;
                objAOE.Created_By = ClientSession.UserName;
                objAOE.Created_Date_And_Time = DateTime.Now;
                objAOE.Modified_By = "";
                objAOE.Modified_Date_And_Time = DateTime.MinValue;
                objAOE.Order_Code = de.Value;
                objAOE.AOE_Identifier = "";
                if (objAOE.AOE_Value != string.Empty)
                    ilstSaveAOE.Add(objAOE);
            }
            if (ilstSaveAOE.Count == 0)
            {
                return;
            }
            else
            {
                ilstSaveAOE = objAOEMngr.SaveList(Convert.ToUInt32(Request["OrderSubmitID"]), ilstSaveAOE);
                ScriptManager.RegisterStartupScript(this, this.Page.GetType(), string.Empty, "DisplayErrorMessage('230101');", true);
            }
        }

        protected void btnClearAll_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<IList<string>, string> de in val)
            {
                IList<string> IdValue = de.Key;
                ((RadTextBox)Page.FindControl(IdValue[1])).Text="";
            }
        }
        //void txtbox_TextChanged(object sender, EventArgs e)
        //{
        //    btnOK.Enabled = true;
        //    btnClearAll.Enabled = true;
        //}

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        }

        protected void btnClearAllAOE_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<IList<string>, string> de in val)
            {
                IList<string> IdValue = de.Key;
                ((RadTextBox)Page.FindControl(IdValue[1])).Text = "";
            }
        }
    }
}
