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
using System.Text;
using System.IO;

namespace Acurus.Capella.UI
{
    public partial class frmDecryption : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //txtEncryptedLocation
        }

        protected void InvisibleEncryptedLocation_Click1(object sender, EventArgs e)
        {
            string filename = string.Empty;
            if (fuImport.PostedFile != null && fuImport.PostedFile.FileName.Trim() != string.Empty)
            {

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
                txtEncryptedLocation.Value = filename;
                string strToSplit = txtEncryptedLocation.Value;
                string[] split = strToSplit.Split('\\');
                int cnt = split.Length;
                string StrSplitedStr = split[cnt - 1];
                string[] strNewSplit = StrSplitedStr.Split('.');
                // txtEncryptedFile.Value = strNewSplit[0] + "_Encrypt";
                StringBuilder strTargetLocation = new StringBuilder();
                for (int i = 0; i < split.Length; i++)
                {

                    if (i == split.Length - 1)
                    {
                        strTargetLocation.Append(strNewSplit[0] + "_Decrypt");
                    }
                    else
                    {
                        strTargetLocation.Append(split[i] + "\\");
                    }

                }
                txtEncryptedFile.Value = strTargetLocation.ToString();
            }
        }

        protected void InvisibleEncryptedFile_Click1(object sender, EventArgs e)
        {
            string filename = string.Empty;
            if (fulEncryptedFile.PostedFile != null)
            {
                filename = Path.GetFileName(fulEncryptedFile.PostedFile.FileName);

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

                    fulEncryptedFile.PostedFile.SaveAs(Server.MapPath("Documents\\" + Session.SessionID + "\\" + filename));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }


                string filePath = Server.MapPath("Documents\\" + Session.SessionID + "\\" + filename);

                txtEncryptedFile.Value = filePath;
            }
        }

        protected void InvisibleCbo_Click(object sender, EventArgs e)
        {
            cboKeySize.Items.Clear();
            if (cboAlgorithm.Value.Trim() == "AES")
            {
                cboKeySize.Items.Add(new ListItem("256"));
                cboKeySize.Items.Add(new ListItem("192"));
                cboKeySize.Items.Add(new ListItem("128"));
            }
            else if (cboAlgorithm.Value.Trim() == "DES")
            {
                cboKeySize.Items.Add(new ListItem("64"));
            }

        }

        protected void btnDecryptFile_Click(object sender, EventArgs e)
        {
            if (txtEncryptedLocation.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('597001');", true);
                return;
            }

            if (txtEncryptedFile.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('597002');", true);
                return;
            }

            if (txtPassword.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('597003');", true);
                return;

            }
            if (cboAlgorithm.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('597004');", true);
                return;

            }
            if (cboKeySize.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('597005');", true);
                return;

            }
            CryptoFunctions crypto = new CryptoFunctions();

            string saltValue = txtPassword.Value;    // can be any string. Here we re taking same as passphrase
            string hashAlgorithm = "SHA1";             // can be "MD5"
            int passwordIterations = 2;                // can be any number
            string initVector_AES = "@1B2c3D4e5F6g7H8";    // must be 16 bytes for AES. This is not password
            string initVector_DES = "@1B2c3D4"; // must be 8 bytes for DES. This is not password

            if (cboAlgorithm.Value == "AES")
            {
                crypto.DecryptAES(txtEncryptedLocation.Value, txtEncryptedFile.Value, txtPassword.Value,
                       saltValue, hashAlgorithm, passwordIterations, initVector_AES, int.Parse(cboKeySize.Value));

            }
            else if (cboAlgorithm.Value == "DES")
            {
                crypto.DecryptDES(txtEncryptedLocation.Value, txtEncryptedFile.Value, txtPassword.Value,
                        saltValue, hashAlgorithm, passwordIterations, initVector_DES, int.Parse(cboKeySize.Value));

            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "DisplayErrorMessage('597006');", true);
        }
    }
}
