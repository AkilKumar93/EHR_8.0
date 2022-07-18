using System;
using System.IO;
using iTextSharp.text.pdf;
using FAXCOMLib;
using FAXCOMEXLib;

namespace  Acurus.Capella.UI
{
   /// <summary>
    /// Parses a PDF file and extracts the text from it.
    /// </summary>
    public class PDFParser
    {
        /// BT = Beginning of a text object operator 
        /// ET = End of a text object operator
        /// Td move to the start of next line
        ///  5 Ts = superscript
        /// -5 Ts = subscript

        #region Fields

        #region _numberOfCharsToKeep
        /// <summary>
        /// The number of characters to keep, when extracting text.
        /// </summary>
        private static int _numberOfCharsToKeep = 15;
        #endregion

        #endregion

        #region ExtractText
        /// <summary>
        /// Extracts a text from a PDF file.
        /// </summary>
        /// <param name="inFileName">the full path to the pdf file.</param>
        /// <param name="outFileName">the output file name.</param>
        /// <returns>the extracted text</returns>
        public bool ExtractText(string inFileName, string outFileName)
        {
            StreamWriter outFile = null;
            try
            {
                // Create a reader for the given PDF file
                PdfReader reader = new PdfReader(inFileName);
                //outFile = File.CreateText(outFileName);
                outFile = new StreamWriter(outFileName, false, System.Text.Encoding.UTF8);

                Console.Write("Processing: ");

                int totalLen = 68;
                float charUnit = ((float)totalLen) / (float)reader.NumberOfPages;
                int totalWritten = 0;
                float curUnit = 0;

                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    outFile.Write(ExtractTextFromPDFBytes(reader.GetPageContent(page)) + " ");

                    // Write the progress.
                    if (charUnit >= 1.0f)
                    {
                        for (int i = 0; i < (int)charUnit; i++)
                        {
                            Console.Write("#");
                            totalWritten++;
                        }
                    }
                    else
                    {
                        curUnit += charUnit;
                        if (curUnit >= 1.0f)
                        {
                            for (int i = 0; i < (int)curUnit; i++)
                            {
                                Console.Write("#");
                                totalWritten++;
                            }
                            curUnit = 0;
                        }

                    }
                }

                if (totalWritten < totalLen)
                {
                    for (int i = 0; i < (totalLen - totalWritten); i++)
                    {
                        Console.Write("#");
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (outFile != null) outFile.Close();
            }
        }
        #endregion

        #region PCPname_Fax
        /// <summary>
        /// Extracts a text from a PDF file.
        /// </summary>
        /// <param name="inFileName">the full path to the pdf file.</param>
        /// <param name="outFileName">the output file name.</param>
        /// <returns>the extracted text</returns>
        public bool PCPname_Fax(string inFileName, out string sFax, out string sPCP, out string sHumanID, out string sPatientname)
        {
            //StreamWriter outFile = null;
            try
            {
                // Create a reader for the given PDF file
                PdfReader reader = new PdfReader(inFileName);
                //outFile = File.CreateText(outFileName);
                //outFile = new StreamWriter(outFileName, false, System.Text.Encoding.UTF8);

                Console.Write("Processing: ");

                int totalLen = 68;
                float charUnit = ((float)totalLen) / (float)reader.NumberOfPages;
                //int totalWritten = 0;
                //float curUnit = 0;

                //for (int page = 1; page <= reader.NumberOfPages; page++)
                //{
                int page = 1;
                string strPage = ExtractTextFromPDFBytes(reader.GetPageContent(page));
                sFax = strPage.Substring(strPage.IndexOf("Fax Number: ") + 12, 14);
                sFax = sFax.Replace("(", "");
                sFax = sFax.Replace(")", "");
                sFax = sFax.Replace(" ", "");
                sFax = sFax.Replace("-", "");
                sPatientname = strPage.Substring(strPage.IndexOf("Patient Name: ") + 13, strPage.IndexOf(" nSex,") - (strPage.IndexOf("Patient Name: ") + 13));
                sPCP = strPage.Substring(strPage.IndexOf("PCP:  ") + 6, strPage.IndexOf(" Provider Name: ") - (strPage.IndexOf("PCP:  ") + 6));
                sHumanID = strPage.Substring(strPage.IndexOf("Account #: ") + 11, strPage.IndexOf("nMember ID:") - (strPage.IndexOf("Account #: ") + 11));
                return true;
            }
            catch
            {
                sFax = "";
                sPCP = "";
                sHumanID = "";
                sPatientname = "";
                return false;
            }
            finally
            {
                //if (outFile != null) outFile.Close();
            }
        }
        #endregion

        #region ExtractTextFromPDFBytes
        /// <summary>
        /// This method processes an uncompressed Adobe (text) object 
        /// and extracts text.
        /// </summary>
        /// <param name="input">uncompressed</param>
        /// <returns></returns>
        private string ExtractTextFromPDFBytes(byte[] input)
        {
            if (input == null || input.Length == 0) return "";
           // int x;
            string resultString = "";
            try
            {


                // Flag showing if we are we currently inside a text object
                bool inTextObject = false;

                // Flag showing if the next character is literal 
                // e.g. '\\' to get a '\' character or '\(' to get '('
                bool nextLiteral = false;

                // () Bracket nesting level. Text appears inside ()
                int bracketDepth = 0;

                // Keep previous chars to get extract numbers etc.:
                char[] previousCharacters = new char[_numberOfCharsToKeep];
                for (int j = 0; j < _numberOfCharsToKeep; j++) previousCharacters[j] = ' ';


                for (int i = 0; i < input.Length; i++)
                {
                    //if (resultString == "\n\r\n\r\n\r   \n\r\n\r\n\r   \n\r\n\r\n\r   \n\r\n\r Patient Name: CONDIT,BARBARA  J  nSex, Date of Birth, Age: FEMALE, 20-Jun-1936, 75Yr(s)nAccount #: 1365nMember ID: 01000460400PCP:  SUDATHI  JEEREDDI Provider Name: Dr Kajal  Gupta M.DnHP: INTERVALLEY SENIOR PLANnEncounter Date: 22-Jun-2011 09:34:49 AMnPurpose of Visit: Wellness VisitnFax Number: (909) 447-8593 Digitally Signed By: Dr Kajal  Gupta M.D at 22-Jun-2011 04:09 PMPage 1 Subjective  CONDIT, BARBARA J is a 75 yrs old FEMALE patient presented for Wellness Visit Past Medical History Condition Years/Onset Year Condition Years/Onset Year Hyperlipidemia 21 Years Hypertension 17 Years Arthropathy Unspecified - NO - HADARTHRITIS IN KNEES BUT PTSTATES AFTER KNEEREPLACEMENTS IT HASN'T")
                    //{
                    //    x = i;
                    //}
                    //x = i;
                    char c = (char)input[i];

                    if (inTextObject)
                    {
                        // Position the text
                        if (bracketDepth == 0)
                        {
                            if (CheckToken(new string[] { "TD", "Td" }, previousCharacters))
                            {
                                resultString += "\n\r";
                            }
                            else
                            {
                                if (CheckToken(new string[] { "'", "T*", "\"" }, previousCharacters))
                                {
                                    resultString += "\n";
                                }
                                else
                                {
                                    if (CheckToken(new string[] { "Tj" }, previousCharacters))
                                    {
                                        resultString += " ";
                                    }
                                }
                            }
                        }

                        // End of a text object, also go to a new line.
                        if (bracketDepth == 0 &&
                            CheckToken(new string[] { "ET" }, previousCharacters))
                        {

                            inTextObject = false;
                            resultString += " ";
                        }
                        else
                        {
                            // Start outputting text
                            if ((c == '(') && (bracketDepth == 0) && (!nextLiteral))
                            {
                                bracketDepth = 1;
                            }
                            else
                            {
                                // Stop outputting text
                                if ((c == ')') && (bracketDepth == 1) && (!nextLiteral))
                                {
                                    bracketDepth = 0;
                                }
                                else
                                {
                                    // Just a normal text character:
                                    if (bracketDepth == 1)
                                    {
                                        // Only print out next character no matter what. 
                                        // Do not interpret.
                                        if (c == '\\' && !nextLiteral)
                                        {
                                            nextLiteral = true;
                                        }
                                        else
                                        {
                                            if (((c >= ' ') && (c <= '~')) ||
                                                ((c >= 128) && (c < 255)))
                                            {
                                                resultString += c.ToString();
                                            }

                                            nextLiteral = false;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Store the recent characters for 
                    // when we have to go back for a checking
                    for (int j = 0; j < _numberOfCharsToKeep - 1; j++)
                    {
                        previousCharacters[j] = previousCharacters[j + 1];
                    }
                    previousCharacters[_numberOfCharsToKeep - 1] = c;

                    // Start of a text object
                    if (!inTextObject && CheckToken(new string[] { "BT" }, previousCharacters))
                    {
                        inTextObject = true;
                    }
                }
                return resultString;
            }
            catch
            {
                //return "";
                //if (x!=0)
                return resultString;
            }
        }
        #endregion

        #region CheckToken
        /// <summary>
        /// Check if a certain 2 character token just came along (e.g. BT)
        /// </summary>
        /// <param name="search">the searched token</param>
        /// <param name="recent">the recent character array</param>
        /// <returns></returns>
        private bool CheckToken(string[] tokens, char[] recent)
        {
            foreach (string token in tokens)
            {
                if ((recent[_numberOfCharsToKeep - 3] == token[0]) &&
                    (recent[_numberOfCharsToKeep - 2] == token[1]) &&
                    ((recent[_numberOfCharsToKeep - 1] == ' ') ||
                    (recent[_numberOfCharsToKeep - 1] == 0x0d) ||
                    (recent[_numberOfCharsToKeep - 1] == 0x0a)) &&
                    ((recent[_numberOfCharsToKeep - 4] == ' ') ||
                    (recent[_numberOfCharsToKeep - 4] == 0x0d) ||
                    (recent[_numberOfCharsToKeep - 4] == 0x0a))
                    )
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
