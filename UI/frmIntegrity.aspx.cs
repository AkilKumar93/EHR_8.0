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
using client;
using System.IO;
using System.Net;

namespace Acurus.Capella.UI
{
    public partial class frmIntegrity : System.Web.UI.Page
    {
        string filename = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void btnHashString_Click(object sender, EventArgs e)
        {
            HashString();
        }
       
        protected void btnHashFile_Click(object sender, EventArgs e)
        {
           
            if (fuImport.PostedFile!=null)
            filename = Path.GetFileName(fuImport.PostedFile.FileName);

            try
            {
                if (filename == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('595001');", true);
                    return;
                }


                string sDirPath = Server.MapPath("Documents/" + Session.SessionID);
                DirectoryInfo ObjSearchDir = new DirectoryInfo(sDirPath);
                if (!ObjSearchDir.Exists)
                    ObjSearchDir.Create();

                fuImport.PostedFile.SaveAs(Server.MapPath("Documents\\" + Session.SessionID + "\\" + filename));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            string filePath = Server.MapPath("Documents\\" + Session.SessionID + "\\" + filename);

            int hashtype = Convert.ToInt32(cboSHA.Value);
            //if(dlg.ShowDialog()==DialogResult.OK)
            CryptoFunctions crypto = new CryptoFunctions();
            //System.IO.FileStream fs = new System.IO.FileStream(dlg.FileName,System.IO.FileMode.Open,System.IO.FileAccess.Read);
            System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            byte[] filebytes = new byte[fs.Length]; ;
            fs.Read(filebytes, 0, (int)fs.Length);

            Byte[] result_Bytes = crypto.HashBytes(filebytes, hashtype); //this returns a byte array of the result hash. 
            //hashtype determines whether md5 or SHA-1

            string result = crypto.DisplayStringForBytes(result_Bytes);
            txtResultOfHash.Value = result;
        }

        private void HashString()
        {
            CryptoFunctions crypto = new CryptoFunctions();
            this.txtResultOfHash.Value = crypto.HashString(txtTextToHash.Value, Convert.ToInt32(cboSHA.Value));

        }

       


    }
}
