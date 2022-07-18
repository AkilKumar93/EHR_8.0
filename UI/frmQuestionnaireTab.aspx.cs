using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Acurus.Capella.Core.DomainObjects;
using System.Net;
using System.IO;
using Acurus.Capella.Core.DTO;
using System.Collections;
using System.Runtime.Serialization;
using System.Data;
using System.Drawing;
using Acurus.Capella.DataAccess.ManagerObjects;
using System.Text;
using Acurus.Capella.UI;
using Telerik.Web.UI;


namespace Acurus.Capella.UI
{
    public partial class frmQuestionnaireTab : System.Web.UI.Page
    {

        IList<Questionnaire_Lookup> categoryList = null;
        QuestionnaireLookupManager questionMngr = new QuestionnaireLookupManager();
        public RadTab tab1 = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ClientSession.FlushSession(); 
                categoryList = questionMngr.GetHealthQuestionCategoryList(ClientSession.PhysicianUserName);
                ViewState["category"] = categoryList;
                if (categoryList != null)
                {


                    for (int i = 0; i < categoryList.Count; i++)
                    {

                        tab1 = new RadTab();
                        tab1.Text = categoryList[i].Questionnaire_Category;
                        if (i == 0)
                        {
                            if (categoryList[i].Is_Ros_Type == "Y")
                            {
                                RadPageView1.ContentUrl = "frmReviewOfQuestionnaire.aspx?TabName=" + categoryList[i].Questionnaire_Category;
                                RadPageView1.Height = 610;
                            }
                            else
                            {
                                RadPageView1.ContentUrl = "frmHealthQuestionnaire.aspx?TabName=" + categoryList[i].Questionnaire_Category;
                                RadPageView1.Height = 700;
                            }
                            
                        }
                        RadTabStrip2.Tabs.Add(tab1);
                        if (ClientSession.SetSelectedTab.Contains('#') && ClientSession.SetSelectedTab.Contains('*'))
                        {
                            string sChildTab = ClientSession.SetSelectedTab.Split('*')[1].Split('#')[0];
                            if (categoryList[i].Questionnaire_Category.ToUpper() == sChildTab.ToUpper())
                            {
                                tab1.Selected = true;
                                RadTabStrip2.SelectedIndex = tab1.Index;
                            }
                        }
                    }

                }

            }

        }

        protected void RadTabStrip1_TabClick(object sender, RadTabStripEventArgs e)
        {
            ClientSession.FlushSession(); 
            IList<Questionnaire_Lookup> ResultCategory = (IList<Questionnaire_Lookup>)ViewState["category"];
            ClientSession.SetSelectedTab = ClientSession.SetSelectedTab.Split('*')[0] + "*" + e.Tab.Text.ToUpper();
            ResultCategory = ResultCategory.Where(a => a.Questionnaire_Category == e.Tab.Text).ToList<Questionnaire_Lookup>();
            if (ResultCategory.Count > 0)
            {
                if (ResultCategory[0].Is_Ros_Type == "Y")
                {
                    RadPageView1.ContentUrl = "frmReviewOfQuestionnaire.aspx?TabName=" + e.Tab.Text;
                    RadPageView1.Height = 610;
                }
                else
                {
                    RadPageView1.ContentUrl = "frmHealthQuestionnaire.aspx?TabName=" + e.Tab.Text;
                    RadPageView1.Height = 700;
                }

            }

        }
    }
}
