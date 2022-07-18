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
using Acurus.Capella.Core.DomainObjects;
using Telerik.Web.UI;
using System.Collections.Generic;

namespace Acurus.Capella.PatientPortal.UserControls
{
    public partial class CustomDLCNew : System.Web.UI.UserControl
    {
        private Unit _textboxheight;
        private Unit _textboxwidth;
        private Unit _listboxheight;
        private string _Value;
        private bool _enable = true;
        private string _listboxposition;
        private string _listboxtopposition;
        private string _listboxstyleposition;
        private string _TextControlID;

        private string _DName;

        public Unit TextboxHeight
        {
            get { return _textboxheight; }
            set { _textboxheight = value; }
        }
        public Unit TextboxWidth
        {
            get { return _textboxwidth; }
            set { _textboxwidth = value; }
        }

        public Unit ListboxHeight
        {
            get { return _listboxheight; }
            set { _listboxheight = value; }
        }
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        public string DName
        {
            get { return _DName; }
            set { _DName = value; }
        }


        public string ListboxPosition
        {
            get { return _listboxposition; }
            set { _listboxposition = value; }
        }

        public string ListboxTopPosition
        {
            get { return _listboxtopposition; }
            set { _listboxtopposition = value; }
        }

        public string ListboxStylePosition
        {
            get { return _listboxstyleposition; }
            set { _listboxstyleposition = value; }

        }

        public string TextControlID
        {
            get { return _TextControlID; }
            set { _TextControlID = value; }

        }
        public bool Enable
        {
            get { return _enable; }


            set
            {
                _enable = value;
                if (!_enable)
                {
                    txtDLC.Enabled = false;
                    pbDropdown.Style.Add("background", "#808080");

                }
                else
                {
                    txtDLC.Enabled = true;
                    listDLC.Enabled = true;
                    pbDropdown.Style.Add("background", "#6DABF7");

                }
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            listDLC.Attributes.Add("onclick", "licstboxclick('" + listDLC.ClientID + "')");

            if (pbDropdown.Attributes["UBACDrop"] == null && txtDLC.Enabled == true)
            {
                if (TextControlID != null)
                    pbDropdown.Attributes.Add("onclick", "return pbDropDown('" + pbDropdown.ClientID + "','" + listDLC.ClientID + "','" + Value + "','" + TextControlID + "');");
                else

                    pbDropdown.Attributes.Add("onclick", "return pbDropDown('" + pbDropdown.ClientID + "','" + listDLC.ClientID + "','" + Value + "','');");
            }

            else
                pbDropdown.Style.Add("background", "#808080");
            if (ClientSession.UserCurrentProcess == "MA_REVIEW" && !IsPostBack)
            {
                txtDLC.Enabled = false;
            }


            txtDLC.Attributes.Add("onkeydown", "insertTab(this,event);");
            txtDLC.Attributes.Add("DLCValue", Value);
            txtDLC.Attributes.Add("UserRole", ClientSession.UserRole);
            if (Value == "REASON FOR REFERRALS" || Value == "SERVICE REQUESTED" || Value == "SPECIAL NEEDS" || Value == "OTHER COMMENTS")
            {
                txtDLC.Height = TextboxHeight;
                txtDLC.Width = TextboxWidth;
                listDLC.Width = TextboxWidth;
                if (ListboxHeight.Value != 0.0)
                    listDLC.Height = Convert.ToInt32(ListboxHeight.Value) + Convert.ToInt32(25);
                else
                    listDLC.Height = Convert.ToInt32(TextboxHeight.Value) + Convert.ToInt32(25);


                if (ListboxPosition != "")
                    listDLC.Style["margin-left"] = ListboxPosition;
                if (ListboxTopPosition != "")
                    listDLC.Style["margin-top"] = ListboxTopPosition;
                if (ListboxStylePosition == "" || ListboxStylePosition == null)
                    listDLC.Style["position"] = "absolute";
                else
                    listDLC.Style["position"] = ListboxStylePosition;
            }
            else if (Value != "HPI_NOTES")
            // if (true)
            {
                txtDLC.Height = TextboxHeight;
                txtDLC.Width = TextboxWidth;
                listDLC.Width = TextboxWidth;
                if (ListboxHeight.Value != 0.0)
                    listDLC.Height = ListboxHeight;
                else
                    listDLC.Height = TextboxHeight;


                if (ListboxPosition != "")
                    listDLC.Style["margin-left"] = ListboxPosition;
                if (ListboxTopPosition != "")
                    listDLC.Style["margin-top"] = ListboxTopPosition;
                if (ListboxStylePosition == "" || ListboxStylePosition == null)
                    listDLC.Style["position"] = "absolute";
                else
                    listDLC.Style["position"] = ListboxStylePosition;
            }
            else
            {
                txtDLC.Height = 300; //200;
                txtDLC.Width = TextboxWidth;
                listDLC.Width = TextboxWidth;
                if (ListboxHeight.Value != 0.0)
                    listDLC.Height = (Unit)130;
                else
                    listDLC.Height = (Unit)130;




                if (ListboxPosition != "")
                    listDLC.Style["margin-left"] = ListboxPosition;
                if (ListboxTopPosition != "")
                    listDLC.Style["margin-top"] = ListboxTopPosition;
                if (ListboxStylePosition == "" || ListboxStylePosition == null)
                    listDLC.Style["position"] = "absolute";
                else
                    listDLC.Style["position"] = ListboxStylePosition;
            }
        }

        public void SetTheUBACorPBACForHistoryControls(Page form)
        {
            EnableOrDisableForHistroy(form, false, ClientSession.UserRole);
        }

        public void EnableOrDisableForHistroy(Control form, bool permit, string Role)
        {
            List<Control> availControls = GetControls(form);

            foreach (Control c in availControls)
            {
                if ((Role.Trim() == "Coder" || ClientSession.UserCurrentProcess == "CHECK_OUT" || ClientSession.UserCurrentProcess == "CHECK_OUT_WAIT" || (ClientSession.UserCurrentProcess.Trim() == string.Empty && ClientSession.UserCurrentOwner.Trim() == string.Empty)) && (c is RadTextBox || c is RadComboBox || c is CheckBox || c is CheckBoxList || c is ListBox || c is ListView || c is RadDateTimePicker || c is RadDatePicker || c is RadButton || c is Button || c is Panel))
                {
                    var webControl = c as WebControl;
                    webControl.Enabled = false;

                    if (c is HtmlInputCheckBox)
                    {
                        var webControlHTML = c as HtmlInputCheckBox;
                        webControlHTML.Disabled = true;
                    }
                    else if (c is HtmlInputButton)
                    {
                        var webControlHTMLButton = c as HtmlInputButton;
                        webControlHTMLButton.Disabled = true;
                    }
                    else if (c is HtmlAnchor)
                    {

                    }
                    else if (c is TextBox)
                    {

                    }

                }
                //if (Role.Trim() == "Coder" || ClientSession.UserCurrentProcess == "MA_PROCESS")
                //{
                //        pbLibrary.Attributes.Remove("onclick");
                //}
            }
        }
        private static List<Control> GetControls(Control form)
        {
            var controlList = new List<Control>();

            foreach (Control childControl in form.Controls)
            {
                controlList.AddRange(GetControls(childControl));
                controlList.Add(childControl);
            }
            return controlList;
        }





    }
}