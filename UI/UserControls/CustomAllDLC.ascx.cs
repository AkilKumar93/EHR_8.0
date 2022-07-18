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

namespace Acurus.Capella.UI.UserControls
{
    public partial class CustomAllDLC : System.Web.UI.UserControl
    {
        private Unit _textboxheight;
        private Unit _textboxwidth;
        private Unit _listboxheight;
        private string _Value;
        private bool _enable = true;
        private string _listboxposition;
        private string _listboxtopposition;


        private string _DName;
        private string _LName;
        private string _CName;
        private string _PName;

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

        public string LName
        {
            get { return _LName; }
            set { _LName = value; }
        }

        public string CName
        {
            get { return _CName; }
            set { _CName = value; }
        }

        public string PName
        {
            get { return _PName; }
            set { _PName = value; }
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
        public bool Enable
        {
            get { return _enable; }


            set
            {
                _enable = value;
                if (!_enable)
                {
                    txtAllDLC.Enabled = false;
                    //txtDLC.Attributes.Add("disabled", "disabled");
                    //pbDropdown.Attributes.Add("disabled", "disabled");
                    //pbClear.Attributes.Add("disabled", "disabled");
                    pbAllDropdown.Style.Add("background", "#808080");
                    pbAllClear.Style.Add("background", "#808080");
                //    pbCustomPhrases.Style.Add("background", "#808080");
                }
                else
                {
                    txtAllDLC.Enabled = true;
                    //txtDLC.Attributes.Remove("disabled");
                    //pbDropdown.Attributes.Remove("disabled");
                    //pbClear.Attributes.Remove("disabled");

                    pbAllDropdown.Style.Add("background", "#6DABF7");
                    pbAllClear.Style.Add("background", "#6DABF7");
                    //pbCustomPhrases.Style.Add("background", "#6DABF7");
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            pbAllLibrary.Style.Add("background", "#808080");

            if (txtAllDLC.Enabled == true)//pbAllClear.Attributes["UBACClear"] == null && 
                pbAllClear.Attributes.Add("onclick", "return pbClearAll('" + pbAllClear.ClientID.Replace("_pbAllClear", "_txtAllDLC") + "');");
            else
                pbAllClear.Style.Add("background", "#808080");

            //if (Value != null)
            //{
            //    if (txtAllDLC.Enabled == false)
            //    {
            //        pbAllLibrary.Style.Add("background", "#808080");
            //    }
            //    else
            //    {
            //        if (pbAllLibrary.Attributes["UBACLibrary"] == null && ClientSession.UserRole.Trim() != "Coder" && ClientSession.UserCurrentProcess != "MA_PROCESS")// && ClientSession.UserRole!="Medical Assistant" && ClientSession.UserRole!="Office Manager")
            //            pbAllLibrary.Attributes.Add("onclick", "return OpenAddorUpdate('" + Value + "');");
            //        else
            //            pbAllLibrary.Style.Add("background", "#808080");
            //    }
            //}

            if (txtAllDLC.Enabled == true)//pbAllDropdown.Attributes["UBACDrop"] == null && 
                pbAllDropdown.Attributes.Add("onclick", "return pbAllDropDown('" + pbAllDropdown.ClientID + "','" + listAllDLC.ClientID + "','" + Value + "');");
            else
                pbAllDropdown.Style.Add("background", "#808080");

            //if (pbCustomPhrases.Attributes["UBACCustomPhrase"] == null && txtDLC.Enabled == true)
            //{
            //    //pbCustomPhrases.Attributes.Add("onclick", "return pbCustomPhrases('" + pbCustomPhrases.ClientID + "','" + listDLC.ClientID + "','" + Value + "');");
            //}
            //else
            //    pbCustomPhrases.Style.Add("background", "#808080");

            txtAllDLC.Attributes.Add("onkeydown", "insertTab(this,event);");


            if (Value != "")
            {
                txtAllDLC.Height = TextboxHeight;
                txtAllDLC.Width = TextboxWidth;
                listAllDLC.Width = TextboxWidth;
                if (ListboxHeight.Value != 0.0)
                    listAllDLC.Height = ListboxHeight;
                else
                    listAllDLC.Height = TextboxHeight;
            }
            //else
            //{
            //    txtAllDLC.Height = 240;
            //    txtAllDLC.Width = TextboxWidth;
            //    listAllDLC.Width = TextboxWidth;
            //    if (ListboxHeight.Value != 0.0)
            //        listAllDLC.Height = (Unit)150;
            //    else
            //        listAllDLC.Height = (Unit)150;

            //    if (ListboxPosition != "")
            //        listAllDLC.Style["margin-left"] = ListboxPosition;
            //    if (ListboxTopPosition != "")
            //        listAllDLC.Style["margin-top"] = ListboxTopPosition;
            //}
        }
        //public void SetTheUBACorPBACForHistoryControls(Page form)
        //{
        //    EnableOrDisableForHistroy(form, false, ClientSession.UserRole);
        //}

        //public void EnableOrDisableForHistroy(Control form, bool permit, string Role)
        //{
        //    List<Control> availControls = GetControls(form);

        //    foreach (Control c in availControls)
        //    {
        //        if ((Role.Trim() == "Coder" || ClientSession.UserCurrentProcess == "CHECK_OUT" || ClientSession.UserCurrentProcess == "CHECK_OUT_WAIT" || (ClientSession.UserCurrentProcess.Trim() == string.Empty && ClientSession.UserCurrentOwner.Trim() == string.Empty)) && (c is RadTextBox || c is RadComboBox || c is CheckBox || c is CheckBoxList || c is ListBox || c is ListView || c is RadDateTimePicker || c is RadDatePicker || c is RadButton || c is Button || c is Panel))
        //        {
        //            var webControl = c as WebControl;
        //            webControl.Enabled = false;

        //            if (c is HtmlInputCheckBox)
        //            {
        //                var webControlHTML = c as HtmlInputCheckBox;
        //                webControlHTML.Disabled = true;
        //            }
        //            else if (c is HtmlInputButton)
        //            {
        //                var webControlHTMLButton = c as HtmlInputButton;
        //                webControlHTMLButton.Disabled = true;
        //            }
        //            else if (c is HtmlAnchor)
        //            {

        //            }
        //            else if (c is TextBox)
        //            {

        //            }

        //        }
        //        //if (Role.Trim() == "Coder" || ClientSession.UserCurrentProcess == "MA_PROCESS")
        //        //{
        //        //        pbLibrary.Attributes.Remove("onclick");
        //        //}
        //    }
        //}
        //private static List<Control> GetControls(Control form)
        //{
        //    var controlList = new List<Control>();

        //    foreach (Control childControl in form.Controls)
        //    {
        //        controlList.AddRange(GetControls(childControl));
        //        controlList.Add(childControl);
        //    }
        //    return controlList;
        //}

    }
}