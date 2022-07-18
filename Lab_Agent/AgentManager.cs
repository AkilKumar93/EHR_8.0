using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Windows.Forms;

namespace Acurus.Capella.LabAgent
{
    public class AgentManager
    {
        public Boolean GetPrinterStatus()
        {

            Boolean bResult = false;
            // Select Printers from WMI Object Collections
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
            string printerName = "";
            bool IsDymo = false;
            foreach (ManagementObject objprinter in searcher.Get())
            {
                printerName = objprinter["Name"].ToString().ToLower();
                if (printerName.ToUpper().Contains("DYMO"))
                {
                    IsDymo = true;
                    Console.WriteLine("Printer = " + objprinter["Name"]);
                    if (objprinter["WorkOffline"].ToString().ToLower().Equals("true"))
                    {
                        // printer is offline by user
                        //MessageBox.Show("Your " + "Printer " + objprinter["Name"] + " is not connected.");
                    }
                    else
                    {
                        bResult = true;
                        break;
                        // printer is not offline
                        //MessageBox.Show("Your " + "Printer = " + objprinter["Name"] + " is connected.");
                    }
                }

            }
            if (!IsDymo)
            {
                // MessageBox.Show("DYMO Label Printer is not connected.");
            }
            return bResult;
        }
        public void PrintQuestLabel(string sPrintText)
        {

            //The dlls present in the following location are added in the reference
            Dymo.DymoAddInClass add = new Dymo.DymoAddInClass();
            add.StartPrintJob();
            add.Open(Application.StartupPath + "\\Final.label"); //Change it to app directory
            Dymo.DymoLabelsClass lbl = new Dymo.DymoLabelsClass();
            lbl.SetField("TEXT", System.Environment.NewLine + System.Environment.NewLine + System.Environment.NewLine + System.Environment.NewLine + System.Environment.NewLine + System.Environment.NewLine + sPrintText);
            string s = lbl.GetText("TEXT");
            add.Print(1, true);
            add.EndPrintJob();

        }
    }
}
