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

namespace Acurus.Capella.UI
{
    public partial class PageNavigator : System.Web.UI.UserControl
    {
        public event EventHandler First;
        //public event EventHandler Next;
        //public event EventHandler Previous;
        //public event EventHandler Last;
        public int PageNumber
        {
            get
            {
                return (int?)ViewState["_PageNumber"]??1;
            }
            set
            {
                ViewState["_PageNumber"] = value;
                EnableMaster();
            }
        }
        public int iMyLastPageNo
        {
            get
            {
                return (int?)ViewState["_iMyLastPageNo"] ?? 0;
            }
            set
            {
                ViewState["_iMyLastPageNo"] = value;
            }
        }
        public double myPageNumber
        {
            get
            {
                if (ViewState["_myPageNumber"] == null)
                {
                    return 0;
                }
                else
                {
                    return (double)ViewState["_myPageNumber"];
                }
            }
            set
            {
                ViewState["_myPageNumber"] =value;
            }
        }
        
        public void Reset()
        {
            TotalNoofDBRecords = 0;
            myPageNumber = 0;
            iMyLastPageNo = 0;
            PageNumber = 1;
        }
        public int TotalNoofDBRecords
        {
            get
            {
                return (int?)ViewState["_TotalNoofDBRecords"] ?? 0;
            }
            set
            {
                ViewState["_TotalNoofDBRecords"] = value;
                if (TotalNoofDBRecords != 0)
                {
                    myPageNumber = (double)(TotalNoofDBRecords) / (double)(MaxResultPerPage);
                    iMyLastPageNo = Convert.ToInt32(Math.Ceiling(myPageNumber));
                }
                EnableMaster();
            }
        }
        public int MaxResultPerPage
        {
            get
            {
                //return (int?)ViewState["_MaxResultPerPage"] ?? 0;
                return 25;
                //return (int?)ViewState["_MaxResultPerPage"] ?? 0;
            }
            set
            {

                ViewState["_MaxResultPerPage"] = value;
            }
        }

        void EnableMaster()
        {
            int iStartPageNo;
            int iEndPageNo;

            if (TotalNoofDBRecords == 0)
            {
                iStartPageNo = 0;
            }
            else
            {
                iStartPageNo = ((PageNumber - 1) *MaxResultPerPage) + 1;
            }
            
            iEndPageNo = ((PageNumber) * MaxResultPerPage) ;
                lblShowing.Text = "Showing " + iStartPageNo.ToString() + " - " + (iEndPageNo).ToString() + " of " + TotalNoofDBRecords.ToString();

            if (iEndPageNo == 0)
            {
                lbtnFirst.Enabled = false;
                lbtnPrevious.Enabled = false;
                lbtnNext.Enabled = false;
                lbtnLast.Enabled = false;
                return;
            }
            else
            {
                lblShowing.Visible = true;
            }

            if (PageNumber == 1)
            {
                lbtnFirst.Enabled = false;
                lbtnPrevious.Enabled = false;
            }
            else
            {
                lbtnFirst.Enabled = true;
                lbtnPrevious.Enabled = true;
            }
            if (iEndPageNo >= TotalNoofDBRecords )
            {
                iEndPageNo = TotalNoofDBRecords;

                if (iStartPageNo == 0 && iEndPageNo!=0)
                {
                    iStartPageNo = 1;
                }

                 lblShowing.Text = "Showing " + iStartPageNo.ToString() + " - " + (iEndPageNo).ToString() + " of " + TotalNoofDBRecords.ToString();
                 lbtnLast.Enabled = false;
                 lbtnNext.Enabled = false;
            }
            else
            {
                lbtnLast.Enabled = true;
                lbtnNext.Enabled = true;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void OnFirstClick(EventArgs e)
        {
            if (e != null)
            {
                First(this, e);
            }
        }
        protected void lbtnFirst_Click(object sender, EventArgs e)
        {
            PageNumber = 1;
            OnFirstClick(e);
        }

        protected void lbtnNext_Click(object sender, EventArgs e)
        {
            if (PageNumber < iMyLastPageNo)
            {
                PageNumber = PageNumber + 1;
            }
            OnFirstClick(e);
        }

        protected void lbtnPrevious_Click(object sender, EventArgs e)
        {
            if (PageNumber > 1)
            {
                PageNumber = PageNumber - 1;
            }
            OnFirstClick(e);
        }

        protected void lbtnLast_Click(object sender, EventArgs e)
        {
            PageNumber = iMyLastPageNo;
            OnFirstClick(e);
        }
    }
}