using System;
using System.Collections;
using System.Net;
using System.Web;
using Microsoft.VisualBasic;
//using Acurus.Capella.LabAgent.questorder;
using System.Web.Services.Protocols;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Acurus.Capella.DataAccess.QuestWebServices;


namespace Acurus.Capella.LabAgent
{
    /// <summary>
    /// Class OrderServiceClient submits DIAGNOSTIC ORDER (HL7 messages) to the MedPlus
    /// Hub platform.
    ///
    /// Upon its construction, this class will exercise the functions relating to the
    /// Orders Service, which includes:
    ///
    /// 1. Validating an order.
    /// 2. Submitting an order.
    /// </summary>
    public class OrdersSample
    {
        int i = 0;
        public OrdersSample(string username, string password, string URL, string sendingApplication, string sendingFaciltiy, string receivingFacility)
        {
            USERNAME = username;
            PASSWORD = password;
            WEB_SERVICE_URL = URL;
            SENDING_APPLICATION = sendingApplication;
            SENDING_FACILITY = sendingFaciltiy;
            RECEIVING_FACILITY = receivingFacility;
        }
        // USERNAME designates the Hub user name used to
        // authenticate to the Hub web service
        public string USERNAME = string.Empty; // "HORI21266test";

        // PASSWORD designates the password associated with
        // the Hub user when authenticating to the web service
        public string PASSWORD = string.Empty; // "31hori21266";   // default password

        // WEB_SERVICE_URL designates the end point used to
        // connect to the Hub's Orders web service
        public string WEB_SERVICE_URL = string.Empty; // "https://cert.hub.care360.com/orders/service";

        // SENDING_APPLICATION designates the application that 
        // is sending the order message to Hub
        public string SENDING_APPLICATION = string.Empty; // "ACUR";

        // SENDING_FACILITY designates the account number provided to you 
        // by Quest for the businessunit you are ordering tests with
        public string SENDING_FACILITY = string.Empty; // "91767810";

        // RECEIVING_FACILITY designates the business unit 
        // within Quest from which the labs are being ordered
        public string RECEIVING_FACILITY = string.Empty; // "MET";

        /// <summary>
        /// The HL7 Order message template
        /// The following "template" is used in constucting the Order.
        /// Replacement fields are:
        /// 0 = sending application (field 3)
        /// 1 = sending facility (field 4) represents the account with Quest Diagnostics
        /// 2 = receiving facility (field 6) The Quest Business Unit for above account
        /// 3 = date time (field 7)
        /// 4 = message control id (field 10) Unique Number identifying this order message
        /// </summary>
        public string ORDER_MESSAGE = string.Empty; //  "MSH|^~\\&|{0}|{1}||{2}|{3:yyyyMMddHHmm}||ORM^O01|{4}|P|2.3\r" +
        //"PID|1|11111|||TEST^WIFE||19451212|M|||||3102222222||||||123456789|\r" +
        //"IN1|1||AUHSC|AETNA|123 ANYSTREET^2^CHICAGO^IL^60305|||A12345||||||||TEST^HUSBAND^|2||123 ANYSTREET^^CHICAGO^IL^60305|||||||||||||||||P123456R|||||||||||T|\r" +
        //"GT1|1||TEST^HUSBAND^||123 ANYSTREET^^CHICAGO^IL^60305|3102222222||19451212|M|\r" +
        //"ORC|NW|{4}||||||||||OTH030^MICHIGAN^JOHN^^^^^UPIN|\r" +
        //"OBR|1|{4}||^^^6399^CBC|||20051223094800|||||||||OTH030^MICHIGAN^JOHN^^^^^UPIN|||||||||||1^^^^^R|\r" +
        //"DG1|1|ICD|0039|SALMONELLA INFECTION NOS|\r";

        public OrdersSample()
        {
            return;
            try
            {
                // calling sendOrder with validateOnly = True will validate the order
                // but not send it to the Hub
                Console.WriteLine("Calling validateOrder...");
                sendOrder(true, false, string.Empty);

                // calling sendOrder with validateOnly = False sends the order to the hub
                Console.WriteLine("Calling sendOrder...");
                sendOrder(false, false, string.Empty);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                StringBuilder logmsg = new StringBuilder();
                logmsg.Append("Error : Orders Sample Exception Date and Time : " + DateTime.Now.ToString() + " - ");
                logmsg.Append("Error Message : " + e.Message.ToString() + " - ");
                if (e.InnerException != null)
                    logmsg.Append(e.InnerException.Message != null ? "InnerException Message : " + e.InnerException.Message.ToString() + " - " : "");
                else
                    logmsg.Append("Error : " + e.ToString() + Environment.NewLine);
                using (TextWriter tx = new StreamWriter(Program.LabAgentLog, true))
                {
                    tx.WriteLine(logmsg);
                }
                //Console.ReadLine();
                //System.Environment.Exit(1);
            }

        }


        public object[] sendOrder(bool ValidateOnly, bool IsABN, string CurrentFilePathAndName)
        {
            Acurus.Capella.DataAccess.QuestWebServices.OrderService webService = null;

            try
            {
                //-------------------------------------------------------
                //STEP 1: CREATE WEB SERVICE REFERENCE
                //-------------------------------------------------------
                webService = new OrderService();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
                StringBuilder logmsg = new StringBuilder();
                logmsg.Append("Error : Send Orders Exception Date and Time : " + DateTime.Now.ToString() + " - ");
                logmsg.Append("Error Message : " + e.Message.ToString() + " - ");
                logmsg.Append("Stack Message : " + e.StackTrace.ToString() + " - ");
                if (e.InnerException != null)
                    logmsg.Append(e.InnerException.Message != null ? "InnerException Message : " + e.InnerException.Message.ToString() + " - " : "");
                else
                    logmsg.Append("Error : " + e.ToString() + Environment.NewLine);
                using (TextWriter tx = new StreamWriter(Program.LabAgentLog, true))
                {
                    tx.WriteLine(logmsg);
                }

                webService = null;
                return new object[1];

                //Console.ReadLine();
                //System.Environment.Exit(1);
            }

            if (!(webService == null))
            {
                OrderResponse response = null;
                Order order = null;

                try
                {
                    //------------------------------------------------------------------
                    //STEP 2: CREATE CREDENTIALS OBJECT CONTAINING USERNAME AND PASSWORD
                    //------------------------------------------------------------------
                    webService.Credentials = new NetworkCredential(USERNAME, PASSWORD);

                    // By default the client will attempt to call the web service without 
                    // sending the credentials. If the server returns a 401 HTTP response, 
                    // the client makes the call again with the credentials. If we set 
                    // PreAuthenticate to True, the client will include the credentials on 
                    // the initial call and eliminate this extra processing.
                    //
                    // This should probably be set in the web service object's constructor,
                    // but has been included here to demonstrate.
                    webService.PreAuthenticate = true;


                    //------------------------------------------------------------------
                    //STEP 3: SET WEB SERVICE URL
                    //------------------------------------------------------------------
                    if (WEB_SERVICE_URL.Length > 0)
                    {
                        webService.Url = WEB_SERVICE_URL;
                    }

                    //------------------------------------------------------------------
                    //STEP 4: GENERATE ORDER OBJECT
                    //------------------------------------------------------------------


                    //--------------------------------------------------------------
                    //STEP 5: SUBMIT ORDER TO THE HUB
                    //--------------------------------------------------------------


                    OrderSupportServiceRequest supportRequest = getWebServiceOrderABN();
                    supportRequest.orderSupportRequests = new string[] { "ABN" };
                    OrderSupportServiceResponse supportResponse = new OrderSupportServiceResponse();
                    supportResponse = webService.getOrderDocuments(supportRequest);
                    //if (supportResponse.status == "SUCCESS")
                    //{
                    //    InserABNCode();
                    //}
                    if (IsABN == false)
                    {
                        order = getWebServiceOrder();
                    }
                    //using (TextWriter tx = new StreamWriter(Program.LabAgentLog, true))
                    //{
                    //    tx.Write("GetOrderDocuments-"+supportResponse.responseCode.ToString()+supportResponse.responseMsg+DateTime.Now.ToString());
                    //}
                    OrderSupportDocument[] objOrderSupportDocument = supportResponse.orderSupportDocuments;

                    if (IsABN)
                    {
                        //remove the whole log from here and move it ordersutilitymanager\resultsutilitymanager
                        //log only failures
                        //tx.write should vary for each method result
                        //add wfobjid everywhere???

                        //OrderSupportServiceRequest supportRequest = getWebServiceOrderABN();
                        //supportRequest.orderSupportRequests = new string[] { "ABN" };
                        //OrderSupportServiceResponse supportResponse = new OrderSupportServiceResponse();
                        //supportResponse = webService.getOrderDocuments(supportRequest);

                        ////using (TextWriter tx = new StreamWriter(Program.LabAgentLog, true))
                        ////{
                        ////    tx.Write("GetOrderDocuments-"+supportResponse.responseCode.ToString()+supportResponse.responseMsg+DateTime.Now.ToString());
                        ////}
                        //OrderSupportDocument[] objOrderSupportDocument = supportResponse.orderSupportDocuments;
                        if (supportResponse.status == "SUCCESS")
                        {
                            object[] obj = new object[2];

                            if (objOrderSupportDocument[0].documentData != null)
                            {
                                obj[0] = objOrderSupportDocument[0].documentType;
                                byte[] barry = objOrderSupportDocument[0].documentData;
                                obj[1] = (object)(Convert.ToBase64String(barry));
                                return obj;
                            }
                            else
                            {

                                obj[0] = objOrderSupportDocument[0].responseMessage;
                                return obj;
                            }
                        }
                        else
                        {
                            return new object[] { objOrderSupportDocument != null ? objOrderSupportDocument[0].requestStatus : null };
                        }
                    }
                    else
                    {
                        if (supportResponse.status == "SUCCESS" && (supportResponse.orderSupportDocuments[0].responseMessage.ToString() == "ABN is required"))
                        {
                            InserABNCode();
                            File.WriteAllText(CurrentFilePathAndName, ORDER_MESSAGE);

                        }

                        response = webService.validateOrder(order);

                        if (response.status == "SUCCESS")
                        {
                            response = new OrderResponse();
                            try
                            {
                                response = webService.submitOrder(order);
                            }
                            catch (Exception e)
                            {
                                StringBuilder logmsg = new StringBuilder();
                                logmsg.Append("Error : Orders Submit Exception Date and Time : " + DateTime.Now.ToString() + " - ");
                                logmsg.Append("Error Message : " + e.Message.ToString() + " - ");
                                if (e.InnerException != null)
                                    logmsg.Append(e.InnerException.Message != null ? "InnerException Message : " + e.InnerException.Message.ToString() + " - " : "");
                                else
                                    logmsg.Append("Error : " + e.ToString() + Environment.NewLine);
                                using (TextWriter tx = new StreamWriter(Program.LabAgentLog, true))
                                {
                                    tx.WriteLine(logmsg);
                                }
                                if (i < 5)
                                {
                                    i++;
                                    sendOrder(true, false, CurrentFilePathAndName);
                                }
                                //Console.ReadLine();
                                //System.Environment.Exit(1);

                            }
                            //retry - do only for server failure - 5 times - You have to log this - try 1 - SUCCESS \ FAILURE. try 2.  - Date & Time
                            //Added By Dhinesh
                            if (response.status == "Error")
                            {
                                return new object[] { "SubmitOrder Error - ", response.responseCode, response.responseMsg };
                                //for (int i = 0; i < 4; i++)
                                //{
                                //    response = new OrderResponse();
                                //    response = webService.submitOrder(order);
                                //}
                            }
                            else
                            {
                                return new object[] { response.status };
                            }
                        }
                        else
                        {
                            return new object[] { "ValidateOrder Error -", response.responseCode, response.responseMsg };
                        }
                    }
                }
                catch (SoapException e)
                {
                    string exceptionMessage = e.Detail.InnerText.Replace("" +
                        (char)10 + "", "" + (char)13 + "" +
                        (char)10 + "");

                    Console.Write(exceptionMessage);

                    //Put our log

                    StringBuilder logmsg = new StringBuilder();
                    logmsg.Append("Error : Orders Submit Soap Exception Date and Time : " + DateTime.Now.ToString() + " - ");
                    logmsg.Append("Error Message : " + e.Message.ToString() + " - ");
                    logmsg.Append("Error Detail : " + exceptionMessage + " - ");

                    if (e.InnerException != null)
                        logmsg.Append(e.InnerException.Message != null ? "InnerException Message : " + e.InnerException.Message.ToString() + " - " : "");
                    else
                        logmsg.Append("Error : " + e.ToString() + Environment.NewLine);
                    using (TextWriter tx = new StreamWriter(Program.LabAgentLog, true))
                    {
                        tx.WriteLine(logmsg);
                    }

                    //Console.ReadLine();
                    //System.Environment.Exit(1);
                    return new object[1];
                }

                if (!(response == null))
                {
                    //------------------------------------------------
                    //STEP 7: EXAMINE RESPONSE FROM THE HUB
                    //------------------------------------------------
                    Console.WriteLine("Status: <{0}>.", response.status);
                    Console.WriteLine("Transaction Id: <{0}>.", response.orderTransactionUid);
                    Console.WriteLine("Message Control Id: <{0}>.", response.messageControlId);
                    Console.WriteLine("Response Message: <{0}>.", response.responseMsg);

                    if (!(response.validationErrors == null))
                    {
                        StringBuilder strlog = new StringBuilder();
                        foreach (string valErr in response.validationErrors)
                        {
                            //Put our log
                            strlog.Append("Error : " + valErr + " - ");
                            Console.WriteLine("Validation Error: <{0}>.", valErr);

                        }
                        StringBuilder logmsg = new StringBuilder();
                        logmsg.Append("Response from the hub -" + strlog.ToString() + "-" + DateTime.Now.ToString() + Environment.NewLine);
                        using (TextWriter tx = new StreamWriter(Program.LabAgentLog, true))
                        {
                            tx.WriteLine(logmsg);
                        }
                    }

                }
                else
                {
                    //Put our log
                    Console.WriteLine("Failed to properly call submitOrder WebService method.");
                    StringBuilder logmsg = new StringBuilder();
                    logmsg.Append("Error : Response from hub - Failed to properly call submitOrder WebService method.-" + DateTime.Now.ToString() + Environment.NewLine);
                    using (TextWriter tx = new StreamWriter(Program.LabAgentLog, true))
                    {
                        tx.WriteLine(logmsg);
                    }
                }


            }
            return new object[1];
        }

        /// <summary>
        /// the getWebServiceOrder function creates a proper Order object that will be submitted
        /// to the Hub
        /// </summary>
        /// <param name="webService"></param>
        private Order getWebServiceOrder()
        {
            Order retval = new Order();

            // Create Order Mesage by passing in facility information
            // String orderMessage = buildOrderMessage(SENDING_APPLICATION, SENDING_FACILITY, RECEIVING_FACILITY);
            //String orderMessage = string.Empty;// buildOrderMessage(SENDING_APPLICATION, SENDING_FACILITY, RECEIVING_FACILITY);

            // Convert String to a Byte array and return in an Order object
            retval.hl7Order = System.Text.Encoding.ASCII.GetBytes(ORDER_MESSAGE);
            return retval;
        }

        public string FormatedHl7File()
        {
            String orderMessage = buildOrderMessage(SENDING_APPLICATION, SENDING_FACILITY, RECEIVING_FACILITY);
            return orderMessage;
        }
        private OrderSupportServiceRequest getWebServiceOrderABN()
        {
            OrderSupportServiceRequest retval = new OrderSupportServiceRequest();

            // Create Order Mesage by passing in facility information
            //String orderMessage = buildOrderMessage(SENDING_APPLICATION, SENDING_FACILITY, RECEIVING_FACILITY);


            // Convert String to a Byte array and return in an Order object
            retval.hl7Order = System.Text.Encoding.ASCII.GetBytes(ORDER_MESSAGE);
            return retval;
        }

        /// <summary>
        /// the buildOrderMessage function replaces values in the ORDER_MESSAGE template to
        /// create a valid HL7 Order message
        /// </summary>
        /// <param name="sendingApplication"></param>
        /// <param name="sendingFacility"></param>
        /// <param name="receivingFacility"></param>
        /// <returns></returns>
        public String buildOrderMessage(
            String sendingApplication,
            String sendingFacility,
            String receivingFacility)
        {
            //'now' is used for 2 purposes here
            //1 to specify the time that the message was created
            //2 to create a unique message control ID and order number
            System.DateTime now = System.DateTime.Now;
            // parameters for replacement in the template
            Object[] msgParams = new Object[7];
            msgParams[0] = sendingApplication;
            msgParams[1] = sendingFacility;
            msgParams[2] = receivingFacility;
            msgParams[3] = now;
            msgParams[4] = now.Ticks;
            String IN1FormateForP = "\rIN1|1|||||||||||||||{0}|||{1}||||||||||||||||||||||||||||{3}|";
            String IN1FormateForC = "\rIN1|1||||||||||||||||||||||||||||||||||||||||||||||{0}|";

            string sResult = string.Format(ORDER_MESSAGE, msgParams);

            sResult = sResult.Replace("ORM|", "ORM^O01|");
            sResult = sResult.Replace("| ", "|");

            string[] Segments = (sResult.Split('\r')).Where(a => !a.StartsWith("IN1")).ToArray<string>();

            string billtype = ((from chr in Segments where chr.StartsWith("MSH") select chr.Substring(chr.Length - 1)).SingleOrDefault());
            if (billtype == "T")
                Segments = sResult.Split('\r');
            //var FormatedString= from a in Segments select a;
            if (billtype == "C")
            {
                Object[] msgParamsC = new Object[1];
                msgParamsC[0] = "C";
                string AppendText = string.Format(IN1FormateForC, msgParamsC);
                for (int j = 0; j < Segments.Count(); j++)
                {
                    if (Segments[j].StartsWith("PID"))
                    {
                        Segments[j] = Segments[j] + AppendText;
                    }
                    else if (Segments[j].StartsWith("MSH"))
                    {
                        Segments[j] = Segments[j].Substring(0, Segments[j].Length - 2);
                    }
                }
            }
            else if (billtype == "P")
            {
                string PIDSegment = Segments.Where(a => a.StartsWith("PID")).SingleOrDefault();
                string[] PIDinnersegments = PIDSegment.Split('|');

                Object[] msgParamsP = new Object[4];
                msgParamsP[0] = PIDinnersegments[5];
                msgParamsP[1] = PIDinnersegments[11];
                msgParamsP[3] = "P";
                string AppendText = string.Format(IN1FormateForP, msgParamsP);
                //To change in the existing Segments list - Append 
                for (int j = 0; j < Segments.Count(); j++)
                {
                    if (Segments[j].StartsWith("PID"))
                    {
                        Segments[j] = Segments[j] + AppendText;
                    }
                    else if (Segments[j].StartsWith("MSH"))
                    {
                        Segments[j] = Segments[j].Substring(0, Segments[j].Length - 2);
                    }
                }

            }
            else if (billtype == "T")
            {

                for (int j = 0; j < Segments.Count(); j++)
                {
                    if (Segments[j].StartsWith("MSH"))
                    {
                        Segments[j] = Segments[j].Substring(0, Segments[j].Length - 2);
                        break;
                    }
                }
            }
            string[] OBR_Correction = Segments;
            sResult = string.Empty;
            foreach (string str in OBR_Correction)
            {
                string innersegmentConcat = str;
                if (str.StartsWith("OBR"))
                {
                    innersegmentConcat = string.Empty;
                    string[] innerSegments = str.Split('|');
                    innerSegments[4] = innerSegments[4].Substring(1);
                    foreach (string strInnerSegment in innerSegments)
                    {
                        innersegmentConcat += "|" + strInnerSegment;

                    }
                    innersegmentConcat = innersegmentConcat.Substring(1);
                }
                sResult += innersegmentConcat + "\r";
            }
            string Temp = string.Empty;
            if (sResult.EndsWith("\r\r"))
                Temp = sResult.Remove(sResult.Length - 1, 1);
            return Temp;

        }
        public void InserABNCode()
        {
            string[] Segments = ORDER_MESSAGE.Split('\r');
            string StrToBeAppended = string.Empty;
            string ORCString = string.Empty;

            foreach (string str in Segments.Reverse())
            {
                if (str.StartsWith("OBR"))
                {
                    StrToBeAppended = str;
                    string[] innerSegments = StrToBeAppended.Split('|');
                    int SequenceNumber = Convert.ToInt16(innerSegments[1]);
                    string OrderCode = (innerSegments[4].Split('^'))[3];
                    string OrderCodeDescription = (innerSegments[4].Split('^'))[4];
                    StrToBeAppended = StrToBeAppended.Replace(OrderCode, "21799");
                    StrToBeAppended = StrToBeAppended.Replace(OrderCodeDescription, "ABN");
                    StrToBeAppended = StrToBeAppended.Replace("OBR|" + SequenceNumber.ToString(), "OBR|" + (SequenceNumber + 1).ToString());



                }
                else if (str.StartsWith("ORC"))
                {
                    ORCString = str;
                    break;
                }
            }
            ORDER_MESSAGE += ORCString + "\r" + StrToBeAppended + "\r";

        }



    }
}
