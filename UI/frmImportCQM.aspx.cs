using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.IO;
namespace Acurus.Capella.UI
{
    public partial class frmImportCQM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            btnImport.Attributes.Add("onclick", "C2Import();");
            btnImport.Enabled = false;

            
        }
       
        protected void btnImport_Click(object sender, EventArgs e)
        {
            if (UploadImage.UploadedFiles.Count > 0)
            {
                string sSaveFolderPath = System.Configuration.ConfigurationManager.AppSettings["C2FolderPath"].ToString();
                int iFilecount = Directory.GetFiles(sSaveFolderPath, "*.zip", SearchOption.AllDirectories).Length;
                if (iFilecount > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), string.Empty, "importValidation();", true);
                    return;
                }

                foreach (UploadedFile uSaveFile in UploadImage.UploadedFiles)
                {
                    uSaveFile.SaveAs(sSaveFolderPath + "\\" + uSaveFile.FileName);

                }

                string sStatus = UtilityManager.ImportC2ByBatchProcess();
                if (sStatus == "Success")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "C2ImportClose();", true);

                }
            }
            else
            {
                UploadImage.UploadedFiles.Clear();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), string.Empty, "DisplayErrorMessage('7050011');", true);
                return;
            }
        }

        protected void btnFileClear_Click(object sender, EventArgs e)
        {
            UploadImage.UploadedFiles.Clear();
            btnImport.Enabled = false;
        }
    }
}