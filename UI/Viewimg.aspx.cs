using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using Acurus.Capella.UI.Extensions;
using System.Web.Services;

namespace Acurus.Capella.UI
{
    public partial class ViewImg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sGroup_ID_Log = ClientSession.EncounterId.ToString() + "-" + ClientSession.HumanId.ToString() + "-" + ClientSession.PhysicianId.ToString() + "-" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:FFF");
            //UtilityManager.inserttologgingtable(ClientSession.EncounterId.ToString(), ClientSession.HumanId.ToString(), ClientSession.UserName, ClientSession.PhysicianId.ToString(), "ViewImage : Start", DateTime.Now, sGroup_ID_Log,"ViewImg");
            //UtilityManager.inserttologgingtable(ClientSession.EncounterId.ToString(), ClientSession.HumanId.ToString(), ClientSession.UserName, ClientSession.PhysicianId.ToString(), "ViewImg Load : Start", DateTime.Now, sGroup_ID_Log,"ViewImg");
            System.Drawing.Image TheImg = null;
            if (Request.QueryString["IsEnc"] == null)
            {
                if (Request.QueryString["All"] != null)
                {

                    if (File.Exists(Request.QueryString["FilePath"]))
                    {
                        UtilityManager.inserttologgingtable(ClientSession.EncounterId.ToString(), ClientSession.HumanId.ToString(), ClientSession.UserName, ClientSession.PhysicianId.ToString(), "ViewImage : Start", DateTime.Now, sGroup_ID_Log, "ViewImg");
                        UtilityManager.inserttologgingtable(ClientSession.EncounterId.ToString(), ClientSession.HumanId.ToString(), ClientSession.UserName, ClientSession.PhysicianId.ToString(), "ViewImg Load : Start", DateTime.Now, sGroup_ID_Log, "ViewImg");
                        TheImg = new TIF(Request.QueryString["FilePath"]).GetTiffImageThumb(System.Convert.ToInt16(Request.QueryString["All"]), System.Convert.ToInt16(Request.QueryString["Height"]), System.Convert.ToInt16(Request.QueryString["Width"]));
                        UtilityManager.inserttologgingtable(ClientSession.EncounterId.ToString(), ClientSession.HumanId.ToString(), ClientSession.UserName, ClientSession.PhysicianId.ToString(), "ViewImg Load : End", DateTime.Now, sGroup_ID_Log, "ViewImg");
                        UtilityManager.inserttologgingtable(ClientSession.EncounterId.ToString(), ClientSession.HumanId.ToString(), ClientSession.UserName, ClientSession.PhysicianId.ToString(), "ViewImage : End", DateTime.Now, sGroup_ID_Log, "ViewImg");
                    }
                }
                else
                {
                    if (File.Exists(Request.QueryString["FilePath"]))
                    {
                        UtilityManager.inserttologgingtable(ClientSession.EncounterId.ToString(), ClientSession.HumanId.ToString(), ClientSession.UserName, ClientSession.PhysicianId.ToString(), "ViewImage : Start", DateTime.Now, sGroup_ID_Log, "ViewImg");
                        UtilityManager.inserttologgingtable(ClientSession.EncounterId.ToString(), ClientSession.HumanId.ToString(), ClientSession.UserName, ClientSession.PhysicianId.ToString(), "ViewImg Load : Start", DateTime.Now, sGroup_ID_Log, "ViewImg");
                        TheImg = new TIF(Request.QueryString["FilePath"]).GetTiffImageThumb(System.Convert.ToInt16(Request.QueryString["Pg"]), System.Convert.ToInt16(Request.QueryString["Height"]), System.Convert.ToInt16(Request.QueryString["Width"]));
                        UtilityManager.inserttologgingtable(ClientSession.EncounterId.ToString(), ClientSession.HumanId.ToString(), ClientSession.UserName, ClientSession.PhysicianId.ToString(), "ViewImg Load : End", DateTime.Now, sGroup_ID_Log, "ViewImg");
                        UtilityManager.inserttologgingtable(ClientSession.EncounterId.ToString(), ClientSession.HumanId.ToString(), ClientSession.UserName, ClientSession.PhysicianId.ToString(), "ViewImage : End", DateTime.Now, sGroup_ID_Log, "ViewImg");
                    }
                }
            }
            else
            {
                string filePath = (Request.QueryString["FilePath"]).Replace("sin", "\\");
                if (File.Exists(filePath))
                {
                    UtilityManager.inserttologgingtable(ClientSession.EncounterId.ToString(), ClientSession.HumanId.ToString(), ClientSession.UserName, ClientSession.PhysicianId.ToString(), "ViewImage : Start", DateTime.Now, sGroup_ID_Log, "ViewImg");
                    UtilityManager.inserttologgingtable(ClientSession.EncounterId.ToString(), ClientSession.HumanId.ToString(), ClientSession.UserName, ClientSession.PhysicianId.ToString(), "ViewImg Load : Start", DateTime.Now, sGroup_ID_Log, "ViewImg");
                    TheImg = new TIF(filePath).GetTiffImageThumb(System.Convert.ToInt16(Request.QueryString["Pg"]), System.Convert.ToInt16(Request.QueryString["Height"]), System.Convert.ToInt16(Request.QueryString["Width"]));
                    UtilityManager.inserttologgingtable(ClientSession.EncounterId.ToString(), ClientSession.HumanId.ToString(), ClientSession.UserName, ClientSession.PhysicianId.ToString(), "ViewImg Load : End", DateTime.Now, sGroup_ID_Log, "ViewImg");
                    UtilityManager.inserttologgingtable(ClientSession.EncounterId.ToString(), ClientSession.HumanId.ToString(), ClientSession.UserName, ClientSession.PhysicianId.ToString(), "ViewImage : End", DateTime.Now, sGroup_ID_Log, "ViewImg");
                }

            }
            if (TheImg != null)
            {
                switch (Request.QueryString["Rotate"])
                {
                    case "90":
                        TheImg.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);
                        break;
                    case "180":
                        TheImg.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
                        break;
                    case "270":
                        TheImg.RotateFlip(System.Drawing.RotateFlipType.Rotate270FlipNone);
                        break;
                }
                Response.ContentType = "image/png";
                TheImg.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
                TheImg.Dispose();
            }
            // UtilityManager.inserttologgingtable(ClientSession.EncounterId.ToString(), ClientSession.HumanId.ToString(), ClientSession.UserName, ClientSession.PhysicianId.ToString(), "ViewImg Load : End", DateTime.Now, sGroup_ID_Log,"ViewImg");
            // UtilityManager.inserttologgingtable(ClientSession.EncounterId.ToString(), ClientSession.HumanId.ToString(), ClientSession.UserName, ClientSession.PhysicianId.ToString(), "ViewImage : End", DateTime.Now, sGroup_ID_Log,"ViewImg");
        }


    }
}