using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using Acurus.Capella.PatientPortal.Extensions;
using System.Web.Services;

namespace Acurus.Capella.PatientPortal
{
    public partial class Viewimg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Drawing.Image TheImg = null;
            if (Request.QueryString["IsEnc"] == null)
            {
                if (Request.QueryString["All"] != null)
                {
                    if (File.Exists(Request.QueryString["FilePath"]))
                        TheImg = new TIF(Request.QueryString["FilePath"]).GetTiffImageThumb(System.Convert.ToInt16(Request.QueryString["All"]), System.Convert.ToInt16(Request.QueryString["Height"]), System.Convert.ToInt16(Request.QueryString["Width"]));
                }
                else
                {
                    if (File.Exists(Request.QueryString["FilePath"]))
                        TheImg = new TIF(Request.QueryString["FilePath"]).GetTiffImageThumb(System.Convert.ToInt16(Request.QueryString["Pg"]), System.Convert.ToInt16(Request.QueryString["Height"]), System.Convert.ToInt16(Request.QueryString["Width"]));
                }
            }
            else
            {
                string filePath = (Request.QueryString["FilePath"]).Replace("sin", "\\");
                if (File.Exists(filePath))
                    TheImg = new TIF(filePath).GetTiffImageThumb(System.Convert.ToInt16(Request.QueryString["Pg"]), System.Convert.ToInt16(Request.QueryString["Height"]), System.Convert.ToInt16(Request.QueryString["Width"]));

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

        }


    }
}