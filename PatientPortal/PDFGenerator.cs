using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Acurus.Capella.Core.DTO;
using Acurus.Capella.DataAccess.ManagerObjects;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.PatientPortal
{
    
    class PDFGenerator
    {
        static iTextSharp.text.Font BoldRightSide = iTextSharp.text.FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
        static iTextSharp.text.Font ResultContentHeader = iTextSharp.text.FontFactory.GetFont("Courier New",8.25f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE);
        static iTextSharp.text.Font ResultContentText = iTextSharp.text.FontFactory.GetFont("Courier New", 8.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
        static iTextSharp.text.Font ResultContentTextItalic = iTextSharp.text.FontFactory.GetFont("Courier New", 8.25f, iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.BLACK);
        static iTextSharp.text.Font ResultContentMainHeader = iTextSharp.text.FontFactory.GetFont("Courier New",9f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
        public string GenerateRequestionForLabcorp(ulong ResultMasterID,string filepath)
        {
            LabcorpSettingsManager labSettingsMngr = new LabcorpSettingsManager();
            IList<LabSettings> ilstlabSettings = labSettingsMngr.GetLabcorpSettings();

            IList<StaticLookup> fieldlist = new List<StaticLookup>();
            StaticLookupManager objStaticLookupManager = new StaticLookupManager();
            fieldlist = objStaticLookupManager.getStaticLookupByFieldName("LAB RESULT ABNORMAL FLAG");
                ResultMasterManager objResultMasterManager = new ResultMasterManager();

                FillResultDTO objFillResultDTO = new FillResultDTO();
                Stream strm = null;
                var serializer = new NetDataContractSerializer();
                strm = objResultMasterManager.GetResultByResultMasterID(ResultMasterID);
                object ol = (object)serializer.ReadObject(strm);
                objFillResultDTO = ol as FillResultDTO;

               

                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 15, 15, 10, 10);
               
                string targetfilepath = filepath + objFillResultDTO.ResultMasterList[0].PID_Patient_Last_Name + "_" + objFillResultDTO.ResultMasterList[0].PID_Patient_First_Name + "_" + objFillResultDTO.ResultMasterList[0].PID_Patient_Middle_Name + "_" + SetDateTimeToControl(objFillResultDTO.ResultMasterList[0].PID_Patient_Date_Of_Birth, "Date").Replace(' ', '_') + "_" + objFillResultDTO.ResultMasterList[0].PID_Patient_Gender + "_" + objFillResultDTO.ResultMasterList[0].Id + ".pdf";
                PdfWriter wr = PdfWriter.GetInstance(doc, new FileStream(targetfilepath, FileMode.Create));
                
                iTextSharp.text.Rectangle pageSize = doc.PageSize;
                doc.Open();

                //Layout
            
                PdfPTable table = new PdfPTable(new float[] { 12.5f, 12.5f, 12.5f, 12.5f, 12.5f, 12.5f });
                table.WidthPercentage = 100;
                PdfPCell cell = new PdfPCell();
                Phrase par = new Phrase("PATIENT ORDER DETAILS", ResultContentMainHeader);
                cell.Colspan = 8;
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthRight = 0;
                cell.BorderColorLeft = BaseColor.BLACK;
            
                cell.AddElement(par);



                table.AddCell(cell);

                cell = new PdfPCell();
                par = new Phrase("Specimen #:", ResultContentHeader);
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0.1f;
                cell.AddElement(par);


                //cell.BorderWidth = Rectangle.NO_BORDER;

                table.AddCell(cell);

                cell = new PdfPCell();
               // par = new Phrase(objFillResultDTO.ResultMasterList[0].PID_Lab_Assigned_Patient_ID, ResultContentText);
                //par = new Phrase("", ResultContentText);
                par = new Phrase(objFillResultDTO.ResultMasterList[0].PID_Lab_Assigned_Patient_ID.Split('^')[0], ResultContentText);
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0.1f;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                cell.AddElement(par);
                table.AddCell(cell);

                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                par = new Phrase("Control #:", ResultContentHeader);
                cell.AddElement(par);
                table.AddCell(cell);


                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0.1f;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                par = new Phrase(objFillResultDTO.ResultOBRList[0].OBR_Specimen_ID, ResultContentText);
                cell.AddElement(par);
                table.AddCell(cell);

                //cell = new PdfPCell();
                //cell.Border = Rectangle.RECTANGLE;
                //cell.BorderWidth = 0.1f;
                //par = new Phrase("Total Volume", ResultContentHeader);
                //cell.AddElement(par);
                //table.AddCell(cell);

                //string sTotalVolume = string.Empty;
                //if (objFillResultDTO.ResultOBRList[0].OBR_Specimen_Collection_Volume != string.Empty)
                //{
                //    sTotalVolume = objFillResultDTO.ResultOBRList[0].OBR_Specimen_Collection_Volume + "ml";
                //}
                //cell = new PdfPCell();
                //cell.Border = Rectangle.RECTANGLE;
                //cell.BorderWidth = 0.1f;
                //par = new Phrase(sTotalVolume, ResultContentText);
                //cell.AddElement(par);
                //table.AddCell(cell);


                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;                
                par = new Phrase("Lab Name:", ResultContentHeader);
                cell.AddElement(par);
                table.AddCell(cell);


                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0.1f;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                var lab = from l in ilstlabSettings where l.Receiving_Facility == objFillResultDTO.ResultMasterList[0].MSH_Sending_Facility select l;
                if (lab.ToList<LabSettings>().Count > 0)
                {
                    par = new Phrase(lab.ToList<LabSettings>()[0].Lab_Name, ResultContentText);                  
                }
                else
                {                  
                    if (objFillResultDTO.ResultZPSList.Count > 0)
                    {
                        par = new Phrase(objFillResultDTO.ResultZPSList.Select(a => a.ZPS_Facility_Name).ToList<string>()[0], ResultContentText);
                    }
                    else
                    {
                        par = new Phrase("", ResultContentText);
                    }                   
                }
                cell.AddElement(par);
                table.AddCell(cell);

                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0.1f;
                par = new Phrase("Collection Date And Time:", ResultContentHeader);
                cell.AddElement(par);
                table.AddCell(cell);

                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0.1f;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                par = new Phrase(SetDateTimeToControl(objFillResultDTO.ResultOBRList[0].OBR_Specimen_Collection_Date_And_Time, "DateAndTime"), ResultContentText);
                cell.AddElement(par);
                table.AddCell(cell);

                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                par = new Phrase("Date Entered:", ResultContentHeader);
                cell.AddElement(par);
                table.AddCell(cell);



                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0.1f;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                par = new Phrase(SetDateTimeToControl(objFillResultDTO.ResultOBRList[0].OBR_Date_And_Time_Specimen_Receipt_In_lab, "DateAndTime"), ResultContentText);
                cell.AddElement(par);
                table.AddCell(cell);

                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                par = new Phrase("Date And Time Of The Report:", ResultContentHeader);
                cell.AddElement(par);
                table.AddCell(cell);

                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0.1f;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                par = new Phrase(SetDateTimeToControl(objFillResultDTO.ResultMasterList[0].MSH_Date_And_Time_Of_Message, "DateAndTime"), ResultContentText);
                cell.AddElement(par);
                table.AddCell(cell);



                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0.1f;
                par = new Phrase("Provider Name:", ResultContentHeader);
                cell.AddElement(par);
                table.AddCell(cell);


                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0.1f;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                par = new Phrase(objFillResultDTO.ResultORCList[0].ORC_Ordering_Provider_Last_Name + " " + objFillResultDTO.ResultORCList[0].ORC_Ordering_Provider_First_Initial + " " + objFillResultDTO.ResultORCList[0].ORC_Ordering_Provider_Middle_Initial, ResultContentText);
                cell.AddElement(par);
                table.AddCell(cell);

                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                par = new Phrase("Provider NPI:", ResultContentHeader);
                cell.AddElement(par);
                table.AddCell(cell);

                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0.1f;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                par = new Phrase(objFillResultDTO.ResultORCList[0].ORC_Ordering_Provider_ID, ResultContentText);
                cell.AddElement(par);
                table.AddCell(cell);
                
                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                par = new Phrase("Fasting:", ResultContentHeader);
                cell.AddElement(par);
                table.AddCell(cell);


                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0.1f;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                par = new Phrase(objFillResultDTO.ResultMasterList[0].PID_Fasting, ResultContentText);
                cell.AddElement(par);
                table.AddCell(cell);

                //cell = new PdfPCell();
                //cell.Border = Rectangle.RECTANGLE;
                //cell.BorderWidth = 0.1f;
                //par = new Phrase("Electronice Mode", ResultContentHeader);
                //cell.AddElement(par);
                //table.AddCell(cell);


                //cell = new PdfPCell();
                //cell.Border = Rectangle.RECTANGLE;
                //cell.BorderWidth = 0.1f;
                //par = new Phrase(objFillResultDTO.ResultMasterList[0].Is_Electronic_Mode, ResultContentText);
                //cell.AddElement(par);
                //table.AddCell(cell);


                //cell = new PdfPCell();
                //cell.Border = Rectangle.RECTANGLE;
                //cell.BorderWidth = 0.1f;
                //par = new Phrase("Provider ID", ResultContentHeader);
                //cell.AddElement(par);
                //table.AddCell(cell);

                //cell = new PdfPCell();
                //cell.Border = Rectangle.RECTANGLE;
                //cell.BorderWidth = 0.1f;
                //PhysicianManager objPhysicianManager = new PhysicianManager();
                //IList<PhysicianLibrary> temp = objPhysicianManager.GetPhysicianByNPI(objFillResultDTO.ResultORCList[0].ORC_Ordering_Provider_ID.Trim());
                //if (temp != null && temp.Count > 0)
                //    par = new Phrase(temp[0].Id.ToString(), ResultContentText);
                //cell.AddElement(par);
                //table.AddCell(cell);


                //cell = new PdfPCell();
                //cell.Border = Rectangle.RECTANGLE;
                //cell.BorderWidth = 0.1f;
                //par = new Phrase("", ResultContentHeader);
                //cell.AddElement(par);
                //table.AddCell(cell);

                //cell = new PdfPCell();
                //cell.Border = Rectangle.RECTANGLE;
                //cell.BorderWidth = 0.1f;
                //par = new Phrase("", ResultContentText);
                //cell.AddElement(par);
                //table.AddCell(cell);


                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0.1f;
                par = new Phrase("Patient ID:", ResultContentHeader);
                cell.AddElement(par);
                table.AddCell(cell);

                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0.1f;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                //par = new Phrase(objFillResultDTO.ResultMasterList[0].Matching_Patient_Id.ToString(), ResultContentText);
                par = new Phrase(objFillResultDTO.ResultMasterList[0].PID_External_Patient_ID.ToString(), ResultContentText);
                cell.AddElement(par);
                table.AddCell(cell);

                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                par = new Phrase("Patient Name:", ResultContentHeader);
                cell.AddElement(par);
                table.AddCell(cell);

                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0.1f;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                par = new Phrase(objFillResultDTO.ResultMasterList[0].PID_Patient_Last_Name + "  " + objFillResultDTO.ResultMasterList[0].PID_Patient_First_Name + "  " + objFillResultDTO.ResultMasterList[0].PID_Patient_Middle_Name, ResultContentText);
                cell.AddElement(par);
                table.AddCell(cell);


                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                par = new Phrase("Patient DOB:", ResultContentHeader);
                cell.AddElement(par);
                table.AddCell(cell);

                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0.1f;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                par = new Phrase(SetDateTimeToControl(objFillResultDTO.ResultMasterList[0].PID_Patient_Date_Of_Birth, "Date"), ResultContentText);
                cell.AddElement(par);
                table.AddCell(cell);

                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0.1f;
                par = new Phrase("Patient Sex:", ResultContentHeader);
                cell.AddElement(par);
                table.AddCell(cell);


                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0.1f;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                par = new Phrase(objFillResultDTO.ResultMasterList[0].PID_Patient_Gender, ResultContentText);
                cell.AddElement(par);
                table.AddCell(cell);


                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                par = new Phrase("Patient Address:", ResultContentHeader);
                cell.AddElement(par);
                table.AddCell(cell);

                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0.1f;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                cell.Colspan = 3;
                par = new Phrase(objFillResultDTO.ResultMasterList[0].PID_Patient_Address1 + " "
                    + objFillResultDTO.ResultMasterList[0].PID_Patient_Address2+" "
                    + objFillResultDTO.ResultMasterList[0].PID_Patient_City +" "
                    + objFillResultDTO.ResultMasterList[0].PID_Patient_State+" "
                    + objFillResultDTO.ResultMasterList[0].PID_Patient_Zip, ResultContentText);
                cell.AddElement(par);
                table.AddCell(cell);


                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0.1f;
                par = new Phrase("Test Ordered:", ResultContentHeader);
                cell.AddElement(par);
                table.AddCell(cell);


                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0.1f;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;

                string sTestOrdered = string.Empty;
                for (int i = 0; i < objFillResultDTO.ResultOBRList.Count; i++)
                {
                    if (sTestOrdered.Contains(objFillResultDTO.ResultOBRList[i].OBR_Observation_Battery_Text) == false)
                    {
                        if (sTestOrdered.Trim() == string.Empty)
                        {
                            sTestOrdered = objFillResultDTO.ResultOBRList[i].OBR_Observation_Battery_Identifier + " - " + objFillResultDTO.ResultOBRList[i].OBR_Observation_Battery_Text;
                        }
                        else
                        {
                            sTestOrdered += "; " + objFillResultDTO.ResultOBRList[i].OBR_Observation_Battery_Identifier + " - " + objFillResultDTO.ResultOBRList[i].OBR_Observation_Battery_Text;
                        }
                    }
                }
                cell.Colspan = 7;
                par = new Phrase(sTestOrdered, ResultContentText);
                cell.AddElement(par);
                table.AddCell(cell);

                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0.1f;
                par = new Phrase("General Comments:", ResultContentHeader);
                cell.AddElement(par);
                table.AddCell(cell);


                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0.1f;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                par = new Phrase("", ResultContentText);
                cell.Colspan = 5;
                cell.AddElement(par);
                table.AddCell(cell);

                cell = new PdfPCell();
                par = new Phrase("Patient Identifier:", ResultContentHeader);
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0.1f;
                cell.AddElement(par);


                //cell.BorderWidth = Rectangle.NO_BORDER;

                table.AddCell(cell);

                cell = new PdfPCell();
                par = new Phrase(objFillResultDTO.ResultMasterList[0].PID_Lab_Assigned_Patient_ID.Split('^')[0], ResultContentText);
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0.1f;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                cell.AddElement(par);
                table.AddCell(cell);

                cell = new PdfPCell();
                par = new Phrase("Test Report Date:", ResultContentHeader);
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0.1f;
                cell.AddElement(par);


                //cell.BorderWidth = Rectangle.NO_BORDER;

                table.AddCell(cell);

                cell = new PdfPCell();
               // par = new Phrase(objFillResultDTO.ResultMasterList[0].PID_Lab_Assigned_Patient_ID.Split('^')[0], ResultContentText);
                par = new Phrase(SetDateTimeToControl(objFillResultDTO.ResultOBRList[0].OBR_Date_And_Time_Observation_Reported, "DateAndTime"), ResultContentText);
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0.1f;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                cell.AddElement(par);
                table.AddCell(cell);
            
          
                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0.1f;
                par = new Phrase("", ResultContentHeader);
                cell.AddElement(par);
                table.AddCell(cell);


                cell = new PdfPCell();
                cell.Border = Rectangle.RECTANGLE;
                cell.BorderColorTop = BaseColor.BLACK;
                cell.BorderWidthTop = 0;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.BorderWidthBottom = 0.1f;
                cell.BorderColorRight = BaseColor.BLACK;
                cell.BorderWidthRight = 0.1f;
                cell.BorderColorLeft = BaseColor.BLACK;
                cell.BorderWidthLeft = 0;
                par = new Phrase("", ResultContentText);
                cell.AddElement(par);
                table.AddCell(cell);

            //    cell = new PdfPCell();
            //    cell.Border = Rectangle.RECTANGLE;
            //    cell.BorderColorTop = BaseColor.BLACK;
            //    cell.BorderWidthTop = 0;
            //    cell.BorderColorBottom = BaseColor.BLACK;
            //    cell.BorderWidthBottom = 0.1f;
            //    cell.BorderColorRight = BaseColor.BLACK;
            //    cell.BorderWidthRight = 0;
            //    cell.BorderColorLeft = BaseColor.BLACK;
            //    cell.BorderWidthLeft = 0.1f;
            //    par = new Phrase("Test Report Date:", ResultContentHeader);
            //    cell.AddElement(par);
            //    table.AddCell(cell);


            //    cell = new PdfPCell();
            //    cell.Border = Rectangle.RECTANGLE;
            //    cell.BorderColorTop = BaseColor.BLACK;
            //    cell.BorderWidthTop = 0;
            //    cell.BorderColorBottom = BaseColor.BLACK;
            //    cell.BorderWidthBottom = 0.1f;
            //    cell.BorderColorRight = BaseColor.BLACK;
            //    cell.BorderWidthRight = 0.1f;
            //    cell.BorderColorLeft = BaseColor.BLACK;
            //    cell.BorderWidthLeft = 0;
            //   // par = new Phrase(objFillResultDTO.ResultMasterList[0].PID_Patient_Gender, ResultContentText);
            //    par = new Phrase(SetDateTimeToControl(objFillResultDTO.ResultOBRList[0].OBR_Date_And_Time_Observation_Reported, "DateAndTime"), ResultContentText);
      
            //cell.AddElement(par);
            //    table.AddCell(cell);
                doc.Add(table);


            //Endsarava


                //test ordered and genral notes


                {

                    //PdfPTable tblInnerContent = new PdfPTable(new float[] { 50f, 20f, 10f, 10f, 25f, 5f,40f,40f,40f });
                    PdfPTable tblInnerContent = new PdfPTable(new float[] { 25f,25f,25f,25f,14f,10f,20f,30f});
                    tblInnerContent.WidthPercentage = 100;
                    PdfPCell tc = new PdfPCell();
                    tc.Border = Rectangle.NO_BORDER;
                    //sarava
                    //par = new Phrase("TEST", ResultContentHeader);
                    par = new Phrase("OBSERVATION", ResultContentHeader);

                    tc.AddElement(par);
                    tblInnerContent.AddCell(tc);

                    tc = new PdfPCell();
                    tc.Border = Rectangle.NO_BORDER;
                    par = new Phrase("RESULT", ResultContentHeader);
                    tc.AddElement(par);
                    tblInnerContent.AddCell(tc);


                    tc = new PdfPCell();
                    tc.Border = Rectangle.NO_BORDER;
                    par = new Phrase("FLAG", ResultContentHeader);
                    tc.AddElement(par);
                    tblInnerContent.AddCell(tc);



                    tc = new PdfPCell();
                    tc.Border = Rectangle.NO_BORDER;
                    par = new Phrase("UOM", ResultContentHeader);
                    tc.AddElement(par);
                    tblInnerContent.AddCell(tc);


                    tc = new PdfPCell();
                    tc.Border = Rectangle.NO_BORDER;
                    par = new Phrase("REFERENCE INTERVAL", ResultContentHeader);
                    tc.AddElement(par);
                    tblInnerContent.AddCell(tc);

                    //tc = new PdfPCell();
                    //tc.Border = Rectangle.NO_BORDER;
                    //par = new Phrase("Lab", ResultContentHeader);
                    //tc.AddElement(par);
                    //tblInnerContent.AddCell(tc);

                    //sarava
                    tc = new PdfPCell();
                    tc.Border = Rectangle.NO_BORDER;
                    par = new Phrase("ABNORMAL FLAG", ResultContentHeader);
                    tc.AddElement(par);
                    tblInnerContent.AddCell(tc);

                    tc = new PdfPCell();
                    tc.Border = Rectangle.NO_BORDER;
                    par = new Phrase("STATUS", ResultContentHeader);
                    tc.AddElement(par);
                    tblInnerContent.AddCell(tc);

                    tc = new PdfPCell();
                    tc.Border = Rectangle.NO_BORDER;
                    par = new Phrase("DATETIME OBSERVATION", ResultContentHeader);
                    tc.AddElement(par);
                    tblInnerContent.AddCell(tc);



                    tc = new PdfPCell();
                    tc.Border = Rectangle.NO_BORDER;
                    par = new Phrase("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", ResultContentText);
                    tc.Colspan = 8;
                    tc.AddElement(par);
                    tblInnerContent.AddCell(tc);


                    for (int i = 0; i < objFillResultDTO.ResultOBRList.Count; i++)
                    {
                        if (objFillResultDTO.ResultOBRList[i].OBR_Observation_Battery_Text.Contains("PDF"))
                        {
                            continue;
                        }
                        tc = new PdfPCell();
                        tc.Border = Rectangle.NO_BORDER;
                        par = new Phrase(objFillResultDTO.ResultOBRList[i].OBR_Observation_Battery_Text, ResultContentHeader);
                        tc.Colspan = 8;
                        tc.AddElement(par);
                        tblInnerContent.AddCell(tc);


                        IList<ResultOBX> resultObx = (from result in objFillResultDTO.ResultOBXList
                                                      where result.Result_Master_ID == objFillResultDTO.ResultOBRList[i].Result_Master_ID && result.Result_OBR_ID == objFillResultDTO.ResultOBRList[i].Id
                                                      select result).ToList<ResultOBX>();
                        if (resultObx.Count > 0)
                        {
                            for (int j = 0; j < resultObx.Count; j++)
                            {
                                if (resultObx[j].OBX_Observation_Result_Status.ToUpper() != "X")
                                {

                                    tc = new PdfPCell();
                                    tc.Border = Rectangle.NO_BORDER;
                                    par = new Phrase(resultObx[j].OBX_Observation_Text != string.Empty ? resultObx[j].OBX_Observation_Text : resultObx[j].OBX_Loinc_Observation_Text, ResultContentText);
                                    tc.AddElement(par);
                                    tblInnerContent.AddCell(tc);


                                    tc = new PdfPCell();
                                    tc.Border = Rectangle.NO_BORDER;
                                  
                                    //string sObxObservationValue;
                                    //if (!resultObx[j].OBX_Observation_Value.Contains('^'))
                                    //{
                                    //    sObxObservationValue = resultObx[j].OBX_Observation_Value;
                                    //}
                                    //else
                                    //{
                                    //    sObxObservationValue = resultObx[j].OBX_Observation_Value.Split('^')[1];
                                    //}
                                    string sObxObservationValue;
                                    if (resultObx[j].OBX_Observation_Value.StartsWith("<^") || resultObx[j].OBX_Observation_Value.StartsWith(">^"))
                                    {
                                        sObxObservationValue = resultObx[j].OBX_Observation_Value.Replace("^", "");
                                    }
                                    else
                                    {
                                        if (!resultObx[j].OBX_Observation_Value.Contains('^'))
                                        {
                                            sObxObservationValue = resultObx[j].OBX_Observation_Value;
                                        }
                                        else
                                        {
                                            sObxObservationValue = resultObx[j].OBX_Observation_Value.Split('^')[1];
                                        }
                                    }

                                    //par = new Phrase(resultObx[j].OBX_Observation_Value, ResultContentText);
                                    par = new Phrase(sObxObservationValue, ResultContentText);
                                    tc.AddElement(par);
                                    tblInnerContent.AddCell(tc);

                                    tc = new PdfPCell();
                                    tc.Border = Rectangle.NO_BORDER;

                                    string sDescription = string.Empty;
                                    var field = (from lookup in fieldlist
                                                 where lookup.Value.ToUpper() == resultObx[j].OBX_Abnormal_Flag.ToUpper()
                                                 select lookup);
                                    if (field.Count() != 0)
                                    {
                                        foreach (var values in field)
                                        {
                                            sDescription = values.Description;
                                        }
                                    }

                                    par = new Phrase(sDescription, ResultContentText);
                                    tc.AddElement(par);
                                    tblInnerContent.AddCell(tc);


                                    tc = new PdfPCell();
                                    tc.Border = Rectangle.NO_BORDER;
                                    string sObxUnits;
                                    if (!resultObx[j].OBX_Units.Contains('^'))
                                    {
                                        sObxUnits = resultObx[j].OBX_Units;
                                    }
                                    else
                                    {
                                        sObxUnits = resultObx[j].OBX_Units.Split('^')[0];
                                    }
                                    //par = new Phrase(resultObx[j].OBX_Units, ResultContentText);
                                    par = new Phrase(sObxUnits, ResultContentText);
                                    tc.AddElement(par);
                                    tblInnerContent.AddCell(tc);


                                    tc = new PdfPCell();
                                    tc.Border = Rectangle.NO_BORDER;
                                    par = new Phrase(resultObx[j].OBX_Reference_Range, ResultContentText);
                                    tc.AddElement(par);
                                    tblInnerContent.AddCell(tc);


                                    //tc = new PdfPCell();
                                    //tc.Border = Rectangle.NO_BORDER;
                                    //par = new Phrase(resultObx[j].OBX_Producer_ID, ResultContentText);
                                    //tc.AddElement(par);
                                    //tblInnerContent.AddCell(tc);

                                    //SARVA
                                    tc = new PdfPCell();
                                    tc.Border = Rectangle.NO_BORDER;
                                    par = new Phrase(resultObx[j].OBX_Abnormal_Flag, ResultContentText);
                                    tc.AddElement(par);
                                    tblInnerContent.AddCell(tc);

                                    tc = new PdfPCell();
                                    tc.Border = Rectangle.NO_BORDER;
                                    par = new Phrase(resultObx[j].OBX_Observation_Result_Status, ResultContentText);
                                    tc.AddElement(par);
                                    tblInnerContent.AddCell(tc);

                                    tc = new PdfPCell();
                                    tc.Border = Rectangle.NO_BORDER;
                                    par = new Phrase(SetDateTimeToControl(resultObx[j].OBX_Date_And_Time_Of_Observation, "DateAndTime"), ResultContentText);
                                    tc.AddElement(par);
                                    tblInnerContent.AddCell(tc);
                                    //ENDSARAVA


                                    IList<ResultNTE> resultNte = (from res in objFillResultDTO.ResultNTEList
                                                                  where res.Result_Master_ID == resultObx[j].Result_Master_ID && res.Result_OBX_ID == resultObx[j].Id && res.Comment_Type.ToUpper() == "ASR COMMENTS" && res.Result_OBR_ID == resultObx[j].Result_OBR_ID
                                                                  select res).ToList<ResultNTE>();
                                    if (resultNte.Count > 0)
                                    {

                                        tc = new PdfPCell();
                                        tc.Border = Rectangle.NO_BORDER;


                                        string text = string.Empty;
                                        for (int k = 0; k < resultNte.Count; k++)
                                        {
                                            if (text == string.Empty)
                                            {
                                                text = resultNte[k].NTE_Comment_Text;
                                            }
                                            else
                                            {
                                                text += Environment.NewLine + resultNte[k].NTE_Comment_Text;
                                            }
                                        }
                                        par = new Phrase(text, ResultContentTextItalic);
                                        tc.Colspan = 8;
                                        tc.AddElement(par);
                                        tblInnerContent.AddCell(tc);

                                    }
                                }
                            }
                        }

                    }

                    IList<ResultNTE> resultAllergy = (from res in objFillResultDTO.ResultNTEList
                                                      where res.Result_OBX_ID == 0 && res.Comment_Type.ToUpper() == "ALLERGY COMMENTS" && res.Result_OBR_ID == 0
                                                      select res).ToList<ResultNTE>();
                    if (resultAllergy.Count > 0)
                    {
                        for (int k = 0; k < resultAllergy.Count; k++)
                        {
                            tc = new PdfPCell();
                            tc.Border = Rectangle.NO_BORDER;
                            tc.Colspan = 8;
                            par = new Phrase(resultAllergy[k].NTE_Comment_Text, ResultContentTextItalic);
                            tc.AddElement(par);
                            tblInnerContent.AddCell(tc);
                        }
                    }
                    tc = new PdfPCell();
                    tc.Border = Rectangle.NO_BORDER;
                    tc.Colspan = 8;
                    par = new Phrase("", ResultContentTextItalic);
                    tc.AddElement(par);
                    tblInnerContent.AddCell(tc);

                    tc = new PdfPCell();
                    tc.Border = Rectangle.NO_BORDER;
                    par = new Phrase("", ResultContentText);
                    tc.Colspan = 8;
                    tc.AddElement(par);
                    tblInnerContent.AddCell(tc);


                    tc = new PdfPCell();
                    tc.Border = Rectangle.NO_BORDER;
                    par = new Phrase("", ResultContentText);
                    tc.Colspan = 8;
                    tc.AddElement(par);
                    tblInnerContent.AddCell(tc);

                    tc = new PdfPCell();
                    tc.Border = Rectangle.NO_BORDER;
                    par = new Phrase("", ResultContentText);
                    tc.Colspan = 8;
                    tc.AddElement(par);
                    tblInnerContent.AddCell(tc);


                    if (objFillResultDTO.ResultZPSList.Count > 0)
                    {
                        tc = new PdfPCell();
                        tc.Border = Rectangle.NO_BORDER;
                        tc.Colspan = 8;
                        par = new Phrase("Performing Lab Information:", ResultContentHeader);
                        tc.AddElement(par);
                        tblInnerContent.AddCell(tc);
                    }
                    doc.Add(tblInnerContent);
                    if (objFillResultDTO.ResultZPSList.Count > 0)
                    {
                        PdfPTable zpsTable = new PdfPTable(new float[] { 20f, 20f, 20f, 20f, 20f });
                        for (int h = 0; h < objFillResultDTO.ResultZPSList.Count; h++)
                        {
                            tc = new PdfPCell();
                            tc.Border = Rectangle.NO_BORDER;
                            par = new Phrase(objFillResultDTO.ResultZPSList[h].ZPS_Facility_Mnemonic, ResultContentText);
                            tc.AddElement(par);
                            zpsTable.AddCell(tc);

                            tc = new PdfPCell();
                            tc.Border = Rectangle.NO_BORDER;
                            par = new Phrase(objFillResultDTO.ResultZPSList[h].ZPS_Facility_Name, ResultContentText);
                            tc.AddElement(par);
                            zpsTable.AddCell(tc);

                            tc = new PdfPCell();
                            tc.Border = Rectangle.NO_BORDER;
                            par = new Phrase(objFillResultDTO.ResultZPSList[h].ZPS_Facility_Director_Last_Name + " " + objFillResultDTO.ResultZPSList[h].ZPS_Facility_Director_First_Name + " " + objFillResultDTO.ResultZPSList[h].ZPS_Facility_Director_Middle_Initial + " " + objFillResultDTO.ResultZPSList[h].ZPS_Facility_Director_Prefix + " " + objFillResultDTO.ResultZPSList[h].ZPS_Facility_Director_Suffix + " " + objFillResultDTO.ResultZPSList[h].ZPS_Facility_Director_Title, ResultContentText);
                            tc.AddElement(par);
                            zpsTable.AddCell(tc);


                            tc = new PdfPCell();
                            tc.Border = Rectangle.NO_BORDER;
                            par = new Phrase(objFillResultDTO.ResultZPSList[h].ZPS_Facility_Address + " " + objFillResultDTO.ResultZPSList[h].ZPS_Facility_City + " " + objFillResultDTO.ResultZPSList[h].ZPS_Facility_State + " " + objFillResultDTO.ResultZPSList[h].ZPS_Facility_Zip, ResultContentText);
                            tc.AddElement(par);
                            zpsTable.AddCell(tc);

                            tc = new PdfPCell();
                            tc.Border = Rectangle.NO_BORDER;
                            par = new Phrase(objFillResultDTO.ResultZPSList[h].ZPS_Facility_Phone_Number, ResultContentText);
                            tc.AddElement(par);
                            zpsTable.AddCell(tc);
                        }
                        tc = new PdfPCell();
                        tc.Border = Rectangle.NO_BORDER;
                        par = new Phrase("", ResultContentText);
                        tc.Colspan = 8;
                        tc.AddElement(par);
                        zpsTable.AddCell(tc);

                        tc = new PdfPCell();
                        tc.Border = Rectangle.NO_BORDER;
                        par = new Phrase("", ResultContentText);
                        tc.Colspan = 8;
                        tc.AddElement(par);
                        zpsTable.AddCell(tc);

                        doc.Add(zpsTable);

                        doc.Add(new Paragraph("   "));
                    }
                    if (objFillResultDTO.ResultOBRList.Count > 0)
                    {
                        IList<ResultOBX> resultObx = (from result in objFillResultDTO.ResultOBXList
                                                      where result.Result_Master_ID == objFillResultDTO.ResultOBRList[0].Result_Master_ID && result.Result_OBR_ID == objFillResultDTO.ResultOBRList[0].Id
                                                      select result).Distinct().OrderBy(aa => aa.OBX_Performing_Organization_Address).ToList<ResultOBX>();
                        //sarava
                        if (resultObx.Count > 0)
                        {
                           // for (int j = 0; j < resultObx.Count; j++)
                           
                            for (int j = 0; j < 1; j++)
                            {
                                if (!resultObx[j].OBX_Performing_Organization_Name.Equals("") && !resultObx[j].OBX_Performing_Organization_Address.Equals(""))
                                {
                                    if (resultObx[j].OBX_Observation_Result_Status.ToUpper() != "X")
                                    {
                                        PdfPTable TableAddress = new PdfPTable(new float[] { 20f, 20f });


                                        tc = new PdfPCell();


                                        //  tc.Border = Rectangle.NO_BORDER;
                                        tc.Border = Rectangle.RECTANGLE;
                                        tc.BorderColorTop = BaseColor.BLACK;
                                        tc.BorderWidthTop = 0.1f;
                                        tc.BorderColorBottom = BaseColor.BLACK;
                                        tc.BorderWidthBottom = 0.1f;
                                        tc.BorderColorRight = BaseColor.BLACK;
                                        tc.BorderWidthRight = 0.1f;
                                        tc.BorderColorLeft = BaseColor.BLACK;
                                        tc.BorderWidthLeft = 0.1f;
                                        par = new Phrase("ORGANIZATION", ResultContentHeader);
                                        tc.AddElement(par);
                                        TableAddress.AddCell(tc);

                                        tc = new PdfPCell();
                                        tc.Border = Rectangle.RECTANGLE;
                                        tc.BorderColorTop = BaseColor.BLACK;
                                        tc.BorderWidthTop = 0.1f;
                                        tc.BorderColorBottom = BaseColor.BLACK;
                                        tc.BorderWidthBottom = 0.1f;
                                        tc.BorderColorRight = BaseColor.BLACK;
                                        tc.BorderWidthRight = 0.1f;
                                        tc.BorderColorLeft = BaseColor.BLACK;
                                        tc.BorderWidthLeft = 0;
                                        par = new Phrase(resultObx[j].OBX_Performing_Organization_Name.Split('^')[0], ResultContentText);
                                        tc.AddElement(par);
                                        TableAddress.AddCell(tc);

                                        tc = new PdfPCell();
                                        tc.Border = Rectangle.RECTANGLE;
                                        tc.BorderColorTop = BaseColor.BLACK;
                                        tc.BorderWidthTop = 0;
                                        tc.BorderColorBottom = BaseColor.BLACK;
                                        tc.BorderWidthBottom = 0.1f;
                                        tc.BorderColorRight = BaseColor.BLACK;
                                        tc.BorderWidthRight = 0.1f;
                                        tc.BorderColorLeft = BaseColor.BLACK;
                                        tc.BorderWidthLeft = 0.1f;
                                        par = new Phrase("ORGANIZATION ADDRESS", ResultContentHeader);
                                        tc.AddElement(par);
                                        TableAddress.AddCell(tc);

                                        tc = new PdfPCell();
                                        tc.Border = Rectangle.RECTANGLE;
                                        tc.BorderColorTop = BaseColor.BLACK;
                                        tc.BorderWidthTop = 0;
                                        tc.BorderColorBottom = BaseColor.BLACK;
                                        tc.BorderWidthBottom = 0.1f;
                                        tc.BorderColorRight = BaseColor.BLACK;
                                        tc.BorderWidthRight = 0.1f;
                                        tc.BorderColorLeft = BaseColor.BLACK;
                                        tc.BorderWidthLeft = 0;
                                        par = new Phrase();
                                        tc.AddElement(par);
                                        TableAddress.AddCell(tc);

                                        tc = new PdfPCell();
                                        tc.Border = Rectangle.RECTANGLE;
                                        tc.BorderColorTop = BaseColor.BLACK;
                                        tc.BorderWidthTop = 0;
                                        tc.BorderColorBottom = BaseColor.BLACK;
                                        tc.BorderWidthBottom = 0.1f;
                                        tc.BorderColorRight = BaseColor.BLACK;
                                        tc.BorderWidthRight = 0.1f;
                                        tc.BorderColorLeft = BaseColor.BLACK;
                                        tc.BorderWidthLeft = 0.1f;
                                        par = new Phrase("STREET ADDRESS", ResultContentHeader);
                                        tc.AddElement(par);
                                        TableAddress.AddCell(tc);

                                        tc = new PdfPCell();
                                        tc.Border = Rectangle.RECTANGLE;
                                        tc.BorderColorTop = BaseColor.BLACK;
                                        tc.BorderWidthTop = 0;
                                        tc.BorderColorBottom = BaseColor.BLACK;
                                        tc.BorderWidthBottom = 0.1f;
                                        tc.BorderColorRight = BaseColor.BLACK;
                                        tc.BorderWidthRight = 0.1f;
                                        tc.BorderColorLeft = BaseColor.BLACK;
                                        tc.BorderWidthLeft = 0;
                                        par = new Phrase(resultObx[j].OBX_Performing_Organization_Address.Split('^')[0], ResultContentText);
                                        tc.AddElement(par);
                                        TableAddress.AddCell(tc);

                                        tc = new PdfPCell();
                                        tc.Border = Rectangle.RECTANGLE;
                                        tc.BorderColorTop = BaseColor.BLACK;
                                        tc.BorderWidthTop = 0;
                                        tc.BorderColorBottom = BaseColor.BLACK;
                                        tc.BorderWidthBottom = 0.1f;
                                        tc.BorderColorRight = BaseColor.BLACK;
                                        tc.BorderWidthRight = 0.1f;
                                        tc.BorderColorLeft = BaseColor.BLACK;
                                        tc.BorderWidthLeft = 0.1f;
                                        par = new Phrase("OTHER DESIGNATION", ResultContentHeader);
                                        tc.AddElement(par);
                                        TableAddress.AddCell(tc);

                                        tc = new PdfPCell();
                                        tc.Border = Rectangle.RECTANGLE;
                                        tc.BorderColorTop = BaseColor.BLACK;
                                        tc.BorderWidthTop = 0;
                                        tc.BorderColorBottom = BaseColor.BLACK;
                                        tc.BorderWidthBottom = 0.1f;
                                        tc.BorderColorRight = BaseColor.BLACK;
                                        tc.BorderWidthRight = 0.1f;
                                        tc.BorderColorLeft = BaseColor.BLACK;
                                        tc.BorderWidthLeft = 0;
                                        par = new Phrase();
                                        tc.AddElement(par);
                                        TableAddress.AddCell(tc);


                                        tc = new PdfPCell();
                                        tc.Border = Rectangle.RECTANGLE;
                                        tc.BorderColorTop = BaseColor.BLACK;
                                        tc.BorderWidthTop = 0;
                                        tc.BorderColorBottom = BaseColor.BLACK;
                                        tc.BorderWidthBottom = 0.1f;
                                        tc.BorderColorRight = BaseColor.BLACK;
                                        tc.BorderWidthRight = 0.1f;
                                        tc.BorderColorLeft = BaseColor.BLACK;
                                        tc.BorderWidthLeft = 0.1f;
                                        par = new Phrase("CITY", ResultContentHeader);
                                        tc.AddElement(par);
                                        TableAddress.AddCell(tc);

                                        tc = new PdfPCell();
                                        tc.Border = Rectangle.RECTANGLE;
                                        tc.BorderColorTop = BaseColor.BLACK;
                                        tc.BorderWidthTop = 0;
                                        tc.BorderColorBottom = BaseColor.BLACK;
                                        tc.BorderWidthBottom = 0.1f;
                                        tc.BorderColorRight = BaseColor.BLACK;
                                        tc.BorderWidthRight = 0.1f;
                                        tc.BorderColorLeft = BaseColor.BLACK;
                                        tc.BorderWidthLeft = 0;
                                        if (resultObx[j].OBX_Performing_Organization_Address.Split('^').Count() > 2)
                                        {
                                            par = new Phrase(resultObx[j].OBX_Performing_Organization_Address.Split('^')[2], ResultContentText);
                                        }
                                        else
                                        {
                                            par = new Phrase("", ResultContentText);
                                        }
                                        tc.AddElement(par);
                                        TableAddress.AddCell(tc);

                                        tc = new PdfPCell();
                                        tc.Border = Rectangle.RECTANGLE;
                                        tc.BorderColorTop = BaseColor.BLACK;
                                        tc.BorderWidthTop = 0;
                                        tc.BorderColorBottom = BaseColor.BLACK;
                                        tc.BorderWidthBottom = 0.1f;
                                        tc.BorderColorRight = BaseColor.BLACK;
                                        tc.BorderWidthRight = 0.1f;
                                        tc.BorderColorLeft = BaseColor.BLACK;
                                        tc.BorderWidthLeft = 0.1f;
                                        par = new Phrase("STATE", ResultContentHeader);
                                        tc.AddElement(par);
                                        TableAddress.AddCell(tc);

                                        tc = new PdfPCell();
                                        tc.Border = Rectangle.RECTANGLE;
                                        tc.BorderColorTop = BaseColor.BLACK;
                                        tc.BorderWidthTop = 0;
                                        tc.BorderColorBottom = BaseColor.BLACK;
                                        tc.BorderWidthBottom = 0.1f;
                                        tc.BorderColorRight = BaseColor.BLACK;
                                        tc.BorderWidthRight = 0.1f;
                                        tc.BorderColorLeft = BaseColor.BLACK;
                                        tc.BorderWidthLeft = 0;
                                        if (resultObx[j].OBX_Performing_Organization_Address.Split('^').Count() > 3)
                                        {
                                            par = new Phrase(resultObx[j].OBX_Performing_Organization_Address.Split('^')[3], ResultContentText);
                                        }
                                        else
                                        {
                                            par = new Phrase("", ResultContentText);
                                        }
                                        tc.AddElement(par);
                                        TableAddress.AddCell(tc);

                                        tc = new PdfPCell();
                                        tc.Border = Rectangle.RECTANGLE;
                                        tc.BorderColorTop = BaseColor.BLACK;
                                        tc.BorderWidthTop = 0;
                                        tc.BorderColorBottom = BaseColor.BLACK;
                                        tc.BorderWidthBottom = 0.1f;
                                        tc.BorderColorRight = BaseColor.BLACK;
                                        tc.BorderWidthRight = 0.1f;
                                        tc.BorderColorLeft = BaseColor.BLACK;
                                        tc.BorderWidthLeft = 0.1f;
                                        par = new Phrase("ZIP CODE", ResultContentHeader);
                                        tc.AddElement(par);
                                        TableAddress.AddCell(tc);

                                        tc = new PdfPCell();
                                        tc.Border = Rectangle.RECTANGLE;
                                        tc.BorderColorTop = BaseColor.BLACK;
                                        tc.BorderWidthTop = 0;
                                        tc.BorderColorBottom = BaseColor.BLACK;
                                        tc.BorderWidthBottom = 0.1f;
                                        tc.BorderColorRight = BaseColor.BLACK;
                                        tc.BorderWidthRight = 0.1f;
                                        tc.BorderColorLeft = BaseColor.BLACK;
                                        tc.BorderWidthLeft = 0;
                                        if (resultObx[j].OBX_Performing_Organization_Address.Split('^').Count() > 4)
                                        {
                                            par = new Phrase(resultObx[j].OBX_Performing_Organization_Address.Split('^')[4], ResultContentText);
                                        }
                                        else
                                        {
                                            par = new Phrase("", ResultContentText);
                                        }
                                        tc.AddElement(par);
                                        TableAddress.AddCell(tc);

                                        tc = new PdfPCell();
                                        tc.Border = Rectangle.RECTANGLE;
                                        tc.BorderColorTop = BaseColor.BLACK;
                                        tc.BorderWidthTop = 0;
                                        tc.BorderColorBottom = BaseColor.BLACK;
                                        tc.BorderWidthBottom = 0.1f;
                                        tc.BorderColorRight = BaseColor.BLACK;
                                        tc.BorderWidthRight = 0.1f;
                                        tc.BorderColorLeft = BaseColor.BLACK;
                                        tc.BorderWidthLeft = 0.1f;
                                        par = new Phrase("COUNTRY", ResultContentHeader);
                                        tc.AddElement(par);
                                        TableAddress.AddCell(tc);

                                        tc = new PdfPCell();
                                        tc.Border = Rectangle.RECTANGLE;
                                        tc.BorderColorTop = BaseColor.BLACK;
                                        tc.BorderWidthTop = 0;
                                        tc.BorderColorBottom = BaseColor.BLACK;
                                        tc.BorderWidthBottom = 0.1f;
                                        tc.BorderColorRight = BaseColor.BLACK;
                                        tc.BorderWidthRight = 0.1f;
                                        tc.BorderColorLeft = BaseColor.BLACK;
                                        tc.BorderWidthLeft = 0;
                                        if (resultObx[j].OBX_Performing_Organization_Address.Split('^').Count() > 5)
                                        {
                                            par = new Phrase(resultObx[j].OBX_Performing_Organization_Address.Split('^')[5], ResultContentText);
                                        }
                                        else
                                        {
                                            par = new Phrase("", ResultContentText);
                                        }
                                        tc.AddElement(par);
                                        TableAddress.AddCell(tc);

                                        tc = new PdfPCell();
                                        tc.Border = Rectangle.RECTANGLE;
                                        tc.BorderColorTop = BaseColor.BLACK;
                                        tc.BorderWidthTop = 0;
                                        tc.BorderColorBottom = BaseColor.BLACK;
                                        tc.BorderWidthBottom = 0.1f;
                                        tc.BorderColorRight = BaseColor.BLACK;
                                        tc.BorderWidthRight = 0.1f;
                                        tc.BorderColorLeft = BaseColor.BLACK;
                                        tc.BorderWidthLeft = 0.1f;
                                        par = new Phrase("COUNTRY/PARISH CODE", ResultContentHeader);
                                        tc.AddElement(par);
                                        TableAddress.AddCell(tc);

                                        tc = new PdfPCell();
                                        tc.Border = Rectangle.RECTANGLE;
                                        tc.BorderColorTop = BaseColor.BLACK;
                                        tc.BorderWidthTop = 0;
                                        tc.BorderColorBottom = BaseColor.BLACK;
                                        tc.BorderWidthBottom = 0.1f;
                                        tc.BorderColorRight = BaseColor.BLACK;
                                        tc.BorderWidthRight = 0.1f;
                                        tc.BorderColorLeft = BaseColor.BLACK;
                                        tc.BorderWidthLeft = 0;
                                        if (resultObx[j].OBX_Performing_Organization_Address.Split('^').Count() > 8)
                                        {
                                            par = new Phrase(resultObx[j].OBX_Performing_Organization_Address.Split('^')[8], ResultContentText);
                                        }

                                        else
                                        {
                                            par = new Phrase("", ResultContentText);
                                        }
                                        tc.AddElement(par);
                                        TableAddress.AddCell(tc);

                                        tc = new PdfPCell();
                                        tc.Border = Rectangle.NO_BORDER;
                                        par = new Phrase("", ResultContentText);
                                        tc.AddElement(par);
                                        TableAddress.AddCell(tc);

                                        tc = new PdfPCell();
                                        tc.Border = Rectangle.NO_BORDER;
                                        par = new Phrase("", ResultContentText);
                                        tc.AddElement(par);
                                        TableAddress.AddCell(tc);
                                        doc.Add(TableAddress);
                                        doc.Add(new Paragraph("   "));
                                    }
                                }
                            }
                        }
                    }
                    
                    if (objFillResultDTO.ResultSPMList.Count > 0)
                    {
                        IList<ResultSPM> resultSPM = (from result in objFillResultDTO.ResultSPMList
                                                      where result.Result_Master_ID == objFillResultDTO.ResultSPMList[0].Result_Master_ID
                                                      select result).OrderBy(aa => aa.SPM_Specimen_Type).ToList<ResultSPM>();
                        PdfPTable TableAddress = new PdfPTable(new float[] { 20f, 20f });


                        tc = new PdfPCell();
                        tc.Border = Rectangle.RECTANGLE;
                        tc.BorderColorTop = BaseColor.BLACK;
                        tc.BorderWidthTop = 0.1f;
                        tc.BorderColorBottom = BaseColor.BLACK;
                        tc.BorderWidthBottom = 0.1f;
                        tc.BorderColorRight = BaseColor.BLACK;
                        tc.BorderWidthRight = 0.1f;
                        tc.BorderColorLeft = BaseColor.BLACK;
                        tc.BorderWidthLeft = 0.1f;
                        par = new Phrase("SECIMEN TYPE", ResultContentHeader);
                        tc.AddElement(par);
                        TableAddress.AddCell(tc);

                        tc = new PdfPCell();
                        tc.Border = Rectangle.RECTANGLE;
                        tc.BorderColorTop = BaseColor.BLACK;
                        tc.BorderWidthTop = 0.1f;
                        tc.BorderColorBottom = BaseColor.BLACK;
                        tc.BorderWidthBottom = 0.1f;
                        tc.BorderColorRight = BaseColor.BLACK;
                        tc.BorderWidthRight = 0.1f;
                        tc.BorderColorLeft = BaseColor.BLACK;
                        tc.BorderWidthLeft = 0;
                        if (resultSPM[0].SPM_Specimen_Type.Split('^').Count() > 1)
                        {
                            par = new Phrase(resultSPM[0].SPM_Specimen_Type.Split('^')[1], ResultContentText);
                        }
                        else
                        {
                            par = new Phrase("", ResultContentText);
                        }
                        tc.AddElement(par);
                        TableAddress.AddCell(tc);

                        tc = new PdfPCell();
                        tc.Border = Rectangle.RECTANGLE;
                        tc.BorderColorTop = BaseColor.BLACK;
                        tc.BorderWidthTop = 0;
                        tc.BorderColorBottom = BaseColor.BLACK;
                        tc.BorderWidthBottom = 0.1f;
                        tc.BorderColorRight = BaseColor.BLACK;
                        tc.BorderWidthRight = 0.1f;
                        tc.BorderColorLeft = BaseColor.BLACK;
                        tc.BorderWidthLeft = 0.1f;
                        par = new Phrase("SPECIMEN COLLECTION DATE/TIME-START", ResultContentHeader);
                        tc.AddElement(par);
                        TableAddress.AddCell(tc);

                        tc = new PdfPCell();
                        tc.Border = Rectangle.RECTANGLE;
                        tc.BorderColorTop = BaseColor.BLACK;
                        tc.BorderWidthTop = 0;
                        tc.BorderColorBottom = BaseColor.BLACK;
                        tc.BorderWidthBottom = 0.1f;
                        tc.BorderColorRight = BaseColor.BLACK;
                        tc.BorderWidthRight = 0.1f;
                        tc.BorderColorLeft = BaseColor.BLACK;
                        tc.BorderWidthLeft = 0;
                        par = new Phrase(SetDateTimeToControl(resultSPM[0].SPM_Specimen_Collection_Date_And_Time, "DateAndTime"), ResultContentText);
                        tc.AddElement(par);
                        TableAddress.AddCell(tc);

                        tc = new PdfPCell();
                        tc.Border = Rectangle.RECTANGLE;
                        tc.BorderColorTop = BaseColor.BLACK;
                        tc.BorderWidthTop = 0;
                        tc.BorderColorBottom = BaseColor.BLACK;
                        tc.BorderWidthBottom = 0.1f;
                        tc.BorderColorRight = BaseColor.BLACK;
                        tc.BorderWidthRight = 0.1f;
                        tc.BorderColorLeft = BaseColor.BLACK;
                        tc.BorderWidthLeft = 0.1f;
                        par = new Phrase("SPECIMEN COLLECTION DATE/TIME-END", ResultContentHeader);
                        tc.AddElement(par);
                        TableAddress.AddCell(tc);

                        tc = new PdfPCell();
                        tc.Border = Rectangle.RECTANGLE;
                        tc.BorderColorTop = BaseColor.BLACK;
                        tc.BorderWidthTop = 0;
                        tc.BorderColorBottom = BaseColor.BLACK;
                        tc.BorderWidthBottom = 0.1f;
                        tc.BorderColorRight = BaseColor.BLACK;
                        tc.BorderWidthRight = 0.1f;
                        tc.BorderColorLeft = BaseColor.BLACK;
                        tc.BorderWidthLeft = 0;
                        par = new Phrase(SetDateTimeToControl(resultSPM[0].SPM_Specimen_Expiration_Date_And_Time, "DateAndTime"), ResultContentText);
                        tc.AddElement(par);
                        TableAddress.AddCell(tc);

                        tc = new PdfPCell();
                        tc.Border = Rectangle.RECTANGLE;
                        tc.BorderColorTop = BaseColor.BLACK;
                        tc.BorderWidthTop = 0;
                        tc.BorderColorBottom = BaseColor.BLACK;
                        tc.BorderWidthBottom = 0.1f;
                        tc.BorderColorRight = BaseColor.BLACK;
                        tc.BorderWidthRight = 0.1f;
                        tc.BorderColorLeft = BaseColor.BLACK;
                        tc.BorderWidthLeft = 0.1f;
                        par = new Phrase("SPECIMEN REJECT REASON", ResultContentHeader);
                        tc.AddElement(par);
                        TableAddress.AddCell(tc);

                        tc = new PdfPCell();
                        tc.Border = Rectangle.RECTANGLE;
                        tc.BorderColorTop = BaseColor.BLACK;
                        tc.BorderWidthTop = 0;
                        tc.BorderColorBottom = BaseColor.BLACK;
                        tc.BorderWidthBottom = 0.1f;
                        tc.BorderColorRight = BaseColor.BLACK;
                        tc.BorderWidthRight = 0.1f;
                        tc.BorderColorLeft = BaseColor.BLACK;
                        tc.BorderWidthLeft = 0;
                        par = new Phrase(resultSPM[0].SPM_Specimen_Reject, ResultContentText);
                        tc.AddElement(par);
                        TableAddress.AddCell(tc);


                        tc = new PdfPCell();
                        tc.Border = Rectangle.RECTANGLE;
                        tc.BorderColorTop = BaseColor.BLACK;
                        tc.BorderWidthTop = 0;
                        tc.BorderColorBottom = BaseColor.BLACK;
                        tc.BorderWidthBottom = 0.1f;
                        tc.BorderColorRight = BaseColor.BLACK;
                        tc.BorderWidthRight = 0.1f;
                        tc.BorderColorLeft = BaseColor.BLACK;
                        tc.BorderWidthLeft = 0.1f;
                        par = new Phrase("SPECIMEN QUALITY", ResultContentHeader);
                        tc.AddElement(par);
                        TableAddress.AddCell(tc);

                        tc = new PdfPCell();
                        tc.Border = Rectangle.RECTANGLE;
                        tc.BorderColorTop = BaseColor.BLACK;
                        tc.BorderWidthTop = 0;
                        tc.BorderColorBottom = BaseColor.BLACK;
                        tc.BorderWidthBottom = 0.1f;
                        tc.BorderColorRight = BaseColor.BLACK;
                        tc.BorderWidthRight = 0.1f;
                        tc.BorderColorLeft = BaseColor.BLACK;
                        tc.BorderWidthLeft = 0;
                        par = new Phrase(resultSPM[0].SPM_Specimen_Quality, ResultContentText);
                        tc.AddElement(par);
                        TableAddress.AddCell(tc);

                        tc = new PdfPCell();
                        tc.Border = Rectangle.RECTANGLE;
                        tc.BorderColorTop = BaseColor.BLACK;
                        tc.BorderWidthTop = 0;
                        tc.BorderColorBottom = BaseColor.BLACK;
                        tc.BorderWidthBottom = 0.1f;
                        tc.BorderColorRight = BaseColor.BLACK;
                        tc.BorderWidthRight = 0.1f;
                        tc.BorderColorLeft = BaseColor.BLACK;
                        tc.BorderWidthLeft = 0.1f;
                        par = new Phrase("SPECIMEN APPROPRIATENESS", ResultContentHeader);
                        tc.AddElement(par);
                        TableAddress.AddCell(tc);

                        tc = new PdfPCell();
                        tc.Border = Rectangle.RECTANGLE;
                        tc.BorderColorTop = BaseColor.BLACK;
                        tc.BorderWidthTop = 0;
                        tc.BorderColorBottom = BaseColor.BLACK;
                        tc.BorderWidthBottom = 0.1f;
                        tc.BorderColorRight = BaseColor.BLACK;
                        tc.BorderWidthRight = 0.1f;
                        tc.BorderColorLeft = BaseColor.BLACK;
                        tc.BorderWidthLeft = 0;
                        par = new Phrase(resultSPM[0].SPM_Specimen_Appropriateness, ResultContentText);
                        tc.AddElement(par);
                        TableAddress.AddCell(tc);

                        tc = new PdfPCell();
                        tc.Border = Rectangle.RECTANGLE;
                        tc.BorderColorTop = BaseColor.BLACK;
                        tc.BorderWidthTop = 0;
                        tc.BorderColorBottom = BaseColor.BLACK;
                        tc.BorderWidthBottom = 0.1f;
                        tc.BorderColorRight = BaseColor.BLACK;
                        tc.BorderWidthRight = 0.1f;
                        tc.BorderColorLeft = BaseColor.BLACK;
                        tc.BorderWidthLeft = 0.1f;
                        par = new Phrase("SPECIMEN CONDITION", ResultContentHeader);
                        tc.AddElement(par);
                        TableAddress.AddCell(tc);

                        tc = new PdfPCell();
                        tc.Border = Rectangle.RECTANGLE;
                        tc.BorderColorTop = BaseColor.BLACK;
                        tc.BorderWidthTop = 0;
                        tc.BorderColorBottom = BaseColor.BLACK;
                        tc.BorderWidthBottom = 0.1f;
                        tc.BorderColorRight = BaseColor.BLACK;
                        tc.BorderWidthRight = 0.1f;
                        tc.BorderColorLeft = BaseColor.BLACK;
                        tc.BorderWidthLeft = 0;                       
                        par = new Phrase(resultSPM[0].SPM_Specimen_Condition.Split('^')[0], ResultContentText);                        
                        cell.Colspan = 7;
                        tc.AddElement(par);
                        TableAddress.AddCell(tc);

                        doc.Add(TableAddress);
                    }

                    //endsara

                }
                doc.Close();
                return targetfilepath;
           
           
        }
        public void GenerateRequestionForLabcorp()
        {

           
           // GenerateRequestionForLabcorp(16343);


           

        }
        public string SetDateTimeToControl(string segVal, string sFormate)
        {
            string segmentValue = segVal;
            string year = string.Empty;
            string month = string.Empty;
            string date = string.Empty;
            string hour = "00";
            string min = "00";
            string retString = string.Empty;
            if (segmentValue != string.Empty)
            {
                year = segmentValue.Substring(0, 4);
                month = segmentValue.Substring(4, 2);
                date = segmentValue.Substring(6, 2);
                if (segmentValue.Length > 8)
                {
                    hour = segmentValue.Substring(8, 2);
                    min = segmentValue.Substring(10, 2);
                }
                DateTime dt = new DateTime();
                dt = Convert.ToDateTime(year + "-" + month + "-" + date + " " + hour + ":" + min + ":00");
                /*For textbox containing date and time.*/
                if (sFormate.Contains("DateAndTime") == true)
                {
                    retString = dt.ToString("dd-MMM-yyyy hh:mm:ss tt");
                }
                /*For textbox containing only date.*/
                else
                {
                    retString = dt.ToString("dd-MMM-yyyy");
                }
            }
            return retString;
        }
    }

}
