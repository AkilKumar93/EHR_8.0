using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Acurus.Capella.DataAccess.ManagerObjects;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.Core.DTO;
using System.Web.UI;
using Telerik.Web.UI;
using System.Web.SessionState;


namespace Acurus.Capella.UI
{
    public partial class Questions
    {
        #region Declarations

        public static int inc = 0;
        public static int assocICDinc = 0;

        #endregion

        #region Methods
        public void DisplayQuestions(Page page, string parent_ID, ref Boolean FormCancelled_ByUser, ref IList<QuestionsDTO> Selected_ICDs, QuestionsDTO selectedQuestion, ref string SourceTable, string QueryHierarchy)
        {


            string sPageName = page.AppRelativeVirtualPath;



            string sMutuallyExclusive = string.Empty;

            AllICD_9Manager objAllICDMgr = new AllICD_9Manager();

            IList<QuestionsDTO> QuestionList = null;

            if (selectedQuestion.ICD_9 != string.Empty)
            {
                if (selectedQuestion.Leaf_Node.Contains('/'))
                {
                    string[] sarr = selectedQuestion.Leaf_Node.Split('/');
                    if (sarr[0].ToString().ToUpper() == "Y")
                        SourceTable = "ASSOCIATEDPRIMARYICD";
                    else
                        SourceTable = "ALLICD";
                }
                else
                {
                    if (selectedQuestion.Leaf_Node.ToUpper() == "Y")
                        SourceTable = "ASSOCIATEDPRIMARYICD";
                    else
                        SourceTable = "ALLICD";
                }
            }

            QuestionList = objAllICDMgr.GetQuestionMasterRecord(parent_ID, ref sMutuallyExclusive, ref SourceTable);

            IList<string> selectedICDSkip = new List<string>();
            if (QuestionList.Count() > 0 && sMutuallyExclusive.ToString().ToUpper() == "N")
            {

                if (page.Session["Selected_ICDs"] != null)
                    selectedICDSkip = (IList<string>)page.Session["Selected_ICDs"];
                selectedICDSkip.Add(selectedQuestion.ICD_9 + "-" + selectedQuestion.Diagnosis_Description + "|" + selectedQuestion.Leaf_Node);
                page.Session["Selected_ICDs"] = selectedICDSkip;

                IDictionary<string, IList<string>> associatedGroupDictionairy = new Dictionary<string, IList<string>>();

                if (page.Session["associatedGroupDictionairy"] != null)
                    associatedGroupDictionairy = (IDictionary<string, IList<string>>)page.Session["associatedGroupDictionairy"];

                if (associatedGroupDictionairy.Count > 0 && associatedGroupDictionairy.ContainsKey(selectedICDSkip[assocICDinc].Split('-')[0]))
                    associatedGroupDictionairy[selectedICDSkip[assocICDinc].Split('-')[0]].Add(selectedQuestion.ICD_9);


            }

            if (QuestionList.Count == 0)
            {
                //frmAssessment.bNextClick = true;
                IList<string> ListString = new List<String>();
                IList<QuestionsDTO> reDto = new List<QuestionsDTO>();
                bool bfals = false;
                if (selectedQuestion.Leaf_Node == null)
                {
                    IList<QuestionsDTO> ResultDtoForICD = (IList<QuestionsDTO>)page.Session["QuestionDToList"];
                    if (ResultDtoForICD.Count > 0)
                    {
                        page.Session["MutualExclusive"] = null;
                        page.Session["QuestionDToList"] = ResultDtoForICD.Remove(ResultDtoForICD[0]);
                        DisplayQuestionsList(page, ListString, ref bfals, ref reDto, (IList<QuestionsDTO>)page.Session["QuestionDToList"], ref ListString, ListString);
                    }
                    else
                    {
                       // frmAssessment.form_Cancelled = false;
                        return;
                    }
                }

                if (selectedQuestion.Leaf_Node.ToUpper() == "Y")
                {
                    IDictionary<string, IList<string>> associatedGroupDictionairy = new Dictionary<string, IList<string>>();

                    if (page.Session["associatedGroupDictionairy"] != null)
                        associatedGroupDictionairy = (IDictionary<string, IList<string>>)page.Session["associatedGroupDictionairy"];

                    Selected_ICDs.Add(selectedQuestion);

                    IList<string> selectedICD = (IList<string>)page.Session["Selected_ICDs"];

                    foreach (var item in Selected_ICDs)
                    {
                        if (page.Session["MoreThantwo"] != null)
                            assocICDinc = 0;
                        /* Commanded By Manimaran for bug id 24129 on 1-11-2014
                         if (!selectedICD.Any(s => s.Split('-')[0] == item.ICD_9))
                         {
                             selectedICD.Add(item.ICD_9 + "-" + item.Diagnosis_Description + "|" + item.Leaf_Node);

                             if (associatedGroupDictionairy.ContainsKey(selectedICD[assocICDinc].Split('-')[0]))
                                 associatedGroupDictionairy[selectedICD[assocICDinc].Split('-')[0]].Add(item.ICD_9);                         
                         }*/
                        if (!selectedICD.Any(s => s.Split('-')[0] == item.ICD_9))
                        {

                            selectedICD.Add(item.ICD_9 + "-" + item.Diagnosis_Description + "|" + item.Leaf_Node);

                            if (associatedGroupDictionairy.Count > 0 && associatedGroupDictionairy.ContainsKey(selectedICD[assocICDinc].Split('-')[0]))
                                associatedGroupDictionairy[selectedICD[assocICDinc].Split('-')[0]].Add(item.ICD_9);

                            selectedICD.Add(item.ICD_9 + "-" + item.Diagnosis_Description + "|" + item.Leaf_Node);

                        }
                        if (associatedGroupDictionairy.Count > 0 && associatedGroupDictionairy.ContainsKey(selectedICD[assocICDinc].Split('-')[0]))
                            associatedGroupDictionairy[selectedICD[assocICDinc].Split('-')[0]].Add(item.ICD_9);
                    }

                    page.Session["Selected_ICDs"] = selectedICD;

                    assocICDinc++;
                }
                IList<QuestionsDTO> ResultDtoForICD1 = (IList<QuestionsDTO>)page.Session["QuestionDToList"];
                if (page.Session["MoreThantwo"] != null)
                {
                    if (page.Session["MoreThantwo"].ToString() == "true")
                    {
                       // frmAssessment.form_Cancelled = false;
                        return;
                    }
                }
                if (page.Session["QuestionDToList"] != null)
                {
                    if (ResultDtoForICD1.Count > 0)
                    {
                        if (page.Session["ContinueList"] == null || ((IList<QuestionsDTO>)page.Session["ContinueList"]).Count == 1)
                        {
                            page.Session["MutualExclusive"] = null;
                            page.Session["BackClose"] = "true";
                            // }
                            page.Session["ContinueList"] = null;
                            ResultDtoForICD1.Remove(ResultDtoForICD1[0]);
                            page.Session["QuestionDToList"] = ResultDtoForICD1;
                            if (ResultDtoForICD1.Count > 0)
                                DisplayQuestionsList(page, ListString, ref bfals, ref reDto, (IList<QuestionsDTO>)page.Session["QuestionDToList"], ref ListString, ListString);
                            else
                            {
                               // frmAssessment.form_Cancelled = false;
                                return;
                            }
                        }
                        else
                        {
                           // frmAssessment.form_Cancelled = false;
                            return;
                        }

                    }

                    else
                    {
                       // frmAssessment.form_Cancelled = false;
                        return;
                    }
                }
                else
                {
                   // frmAssessment.form_Cancelled = false;
                    return;

                }
            }
            //frmAssessment.form_Cancelled = true;
            for (int i = 0; i < QuestionList.Count; i++)
            {
                sMutuallyExclusive = QuestionList[i].Mutually_Exclusive;
                if (selectedQuestion.Prefix != string.Empty)
                    QuestionList[i].Prefix = selectedQuestion.Prefix;
            }

            string sQuestionList = string.Empty;
            foreach (var item in QuestionList)
                sQuestionList += item.ICD_9 + "$" + item.Prefix + "$" + item.Diagnosis_Description + "$" + item.Leaf_Node + "|";

            string sSelectedQuestion = string.Empty;
            if (!string.IsNullOrEmpty(selectedQuestion.ICD_9))
            {
                if (selectedQuestion.Prefix == "")
                    sSelectedQuestion = selectedQuestion.ICD_9 + "$" + selectedQuestion.Diagnosis_Description + "$" + selectedQuestion.Leaf_Node;
                else
                    sSelectedQuestion = selectedQuestion.ICD_9 + "$" + selectedQuestion.Prefix + " " + selectedQuestion.Diagnosis_Description + "$" + selectedQuestion.Leaf_Node;

            }

            string sSelected_ICDs = string.Empty;
            foreach (var item in Selected_ICDs)
                sSelected_ICDs += item.ICD_9 + "$" + item.Prefix + "$" + item.Diagnosis_Description + "$" + item.Leaf_Node + "|";


            if (sMutuallyExclusive == "Y")
            {
                inc++;
                //ScriptManager.RegisterStartupScript(page, page.GetType(), "openMutuallyExclusive" + inc.ToString(), "window.showModalDialog('frmMutuallyExclusive.aspx?key=" + "openMutuallyExclusive" + inc.ToString() + "&QuestionList=" + sQuestionList + "&selectedQuestion=" + sSelectedQuestion + "&queryHierarchy=" + QueryHierarchy + "&selected_ICDs=" + sSelected_ICDs + "','','dialogHeight: 375px; dialogWidth: 805px');", true);
                //ScriptManager.RegisterStartupScript(page, page.GetType(), "openMutuallyExclusive", "openMutuallyExclusive('" + inc + "','" + sQuestionList + "','" + sSelectedQuestion + "','" + QueryHierarchy + "','" + sSelected_ICDs + "');", true);
                if (inc == 1)
                {
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "openMutuallyExclusive", "openMutuallyExclusive('" + inc + "','" + sQuestionList + "','" + sSelectedQuestion + "','" + QueryHierarchy + "','" + sSelected_ICDs + "','" + sPageName + "');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "openMutuallyExclusiveforQuestion", "openMutuallyExclusiveforQuestion('" + inc + "','" + sQuestionList + "','" + sSelectedQuestion + "','" + QueryHierarchy + "','" + sSelected_ICDs + "','" + sPageName + "');", true);
                }
            }
            else if (sMutuallyExclusive == "N")
            {
                inc++;
                //ScriptManager.RegisterStartupScript(page, page.GetType(), "openMultiSelect" + inc.ToString(), "window.showModalDialog('frmMultiSelect.aspx?key=" + "openMutuallyExclusive" + inc.ToString() + "&QuestionList=" + sQuestionList + "&selectedQuestion=" + sSelectedQuestion + "&queryHierarchy=" + QueryHierarchy + "&selected_ICDs=" + sSelected_ICDs + "','','dialogHeight: 375px; dialogWidth: 805px')", true);
                // ScriptManager.RegisterStartupScript(page, page.GetType(), "openMultiSelect", "openMultiSelect('" + inc + "','" + sQuestionList + "','" + sSelectedQuestion + "','" + QueryHierarchy + "','" + sSelected_ICDs + "');", true);

                if (inc == 1)
                {
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "openMultiSelect", "openMultiSelect('" + inc + "','" + sQuestionList + "','" + sSelectedQuestion + "','" + QueryHierarchy + "','" + sSelected_ICDs + "','" + sPageName + "');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "openMultiSelectQuestion", "openMultiSelectQuestion('" + inc + "','" + sQuestionList + "','" + sSelectedQuestion + "','" + QueryHierarchy + "','" + sSelected_ICDs + "','" + sPageName + "');", true);
                }
            }
        }


        public void DisplayQuestionsList(Page page, IList<string> parent_ID, ref Boolean FormCancelled_ByUser, ref IList<QuestionsDTO> Selected_ICDs, IList<QuestionsDTO> selectedQuestion, ref IList<string> SourceTable, IList<string> QueryHierarchy)
        {
            page.Session["lblQueryString"] = null;
            for (int i = 0; i < selectedQuestion.Count; i++)
            {
                //  = selectedQuestion.;
                string sPageName = page.AppRelativeVirtualPath;



                string sMutuallyExclusive = string.Empty;

                AllICD_9Manager objAllICDMgr = new AllICD_9Manager();

                IList<QuestionsDTO> QuestionList = null;
                string ResultTable = "";
                if (selectedQuestion[i].ICD_9 != string.Empty)
                {
                    if (selectedQuestion[i].Leaf_Node.Contains('/'))
                    {
                        string[] sarr = selectedQuestion[i].Leaf_Node.Split('/');
                        if (sarr[0].ToString().ToUpper() == "Y")
                            ResultTable = "ASSOCIATEDPRIMARYICD";
                        else
                            ResultTable = "ALLICD";
                    }
                    else
                    {
                        if (selectedQuestion[i].Leaf_Node.ToUpper() == "Y")
                            ResultTable = "ASSOCIATEDPRIMARYICD";
                        else
                            ResultTable = "ALLICD";
                    }
                }

                QuestionList = objAllICDMgr.GetQuestionMasterRecord(selectedQuestion[i].ICD_9, ref sMutuallyExclusive, ref ResultTable);
                //if (selectedQuestion[i].Leaf_Node.ToUpper() == "Y")
                //{
                //    IDictionary<string, IList<string>> associatedGroupDictionairy = new Dictionary<string, IList<string>>();

                //    if (page.Session["associatedGroupDictionairy"] != null)
                //        associatedGroupDictionairy = (IDictionary<string, IList<string>>)page.Session["associatedGroupDictionairy"];

                //    //Selected_ICDs.Add(selectedQuestion[i]);

                //    IList<string> selectedICD = (IList<string>)page.Session["Selected_ICDs"];

                //    foreach (var item in Selected_ICDs)
                //    {
                //        //    /* Commanded By Manimaran for bug id 24129 on 1-11-2014
                //        //     if (!selectedICD.Any(s => s.Split('-')[0] == item.ICD_9))
                //        //     {
                //        //         selectedICD.Add(item.ICD_9 + "-" + item.Diagnosis_Description + "|" + item.Leaf_Node);

                //        //         if (associatedGroupDictionairy.ContainsKey(selectedICD[assocICDinc].Split('-')[0]))
                //        //             associatedGroupDictionairy[selectedICD[assocICDinc].Split('-')[0]].Add(item.ICD_9);                         
                //        //     }*/
                //        if (!selectedICD.Any(s => s.Split('-')[0] == item.ICD_9))
                //        {

                //            selectedICD.Add(item.ICD_9 + "-" + item.Diagnosis_Description + "|" + item.Leaf_Node);

                //            if (associatedGroupDictionairy.Count > 0 && associatedGroupDictionairy.ContainsKey(selectedICD[assocICDinc].Split('-')[0]))
                //                associatedGroupDictionairy[selectedICD[assocICDinc].Split('-')[0]].Add(item.ICD_9);

                //            selectedICD.Add(item.ICD_9 + "-" + item.Diagnosis_Description + "|" + item.Leaf_Node);

                //        }
                //        if (associatedGroupDictionairy.Count > 0 && associatedGroupDictionairy.ContainsKey(selectedICD[assocICDinc].Split('-')[0]))
                //            associatedGroupDictionairy[selectedICD[assocICDinc].Split('-')[0]].Add(item.ICD_9);
                //    }

                //    page.Session["Selected_ICDs"] = selectedICD;

                //    assocICDinc++;
                //}

                for (int k = 0; k < QuestionList.Count; k++)
                {
                    sMutuallyExclusive = QuestionList[k].Mutually_Exclusive;
                    if (selectedQuestion[i].Prefix != string.Empty)
                        QuestionList[k].Prefix = selectedQuestion[i].Prefix;
                }

                string sQuestionList = string.Empty;
                foreach (var item in QuestionList)
                    sQuestionList += item.ICD_9 + "$" + item.Prefix + "$" + item.Diagnosis_Description + "$" + item.Leaf_Node + "|";

                string sSelectedQuestion = string.Empty;
                if (!string.IsNullOrEmpty(selectedQuestion[i].ICD_9))
                    sSelectedQuestion = selectedQuestion[i].ICD_9 + "$" + selectedQuestion[i].Diagnosis_Description + "$" + selectedQuestion[i].Leaf_Node;

                string sSelected_ICDs = string.Empty;
                foreach (var item in Selected_ICDs)
                    sSelected_ICDs += item.ICD_9 + "$" + item.Prefix + "$" + item.Diagnosis_Description + "$" + item.Leaf_Node + "|";

                page.Session["QuestionDToList"] = selectedQuestion;
                //if (sMutuallyExclusive == "")
                //    frmAssessment.form_Cancelled = false;
                if (page.AppRelativeVirtualPath != "~/frmManageProblemList.aspx")
                {
                    if (inc == 0)
                    {
                        if (page.Session["Selected_ICDs"] != null)
                        {
                            IList<string> selectedICD = new List<string>();
                            //page.Session["Selected_ICDs"] = selectedICD;
                            selectedICD = (IList<string>)page.Session["Selected_ICDs"];
                            selectedICD = (from p in selectedICD where (p.ToString().Split('|')[1] != "N") select p).ToList<string>();
                            // if (selectedICD.Count > 0)
                            // page.Session["Selected_ICDs"] = new List<string>();
                        }


                    }
                }
                if (inc == 0)
                {
                    IDictionary<string, IList<string>> associatedGroupDictionairy = new Dictionary<string, IList<string>>();
                    if (page.Session["associatedGroupDictionairy"] != null)
                        page.Session["associatedGroupDictionairy"] = new Dictionary<string, IList<string>>();
                    IList<string> ilstParentICD = new List<string>();
                    if (page.Session["Parent_ICD"] != null)
                        page.Session["Parent_ICD"] = new List<string>();
                }
                if (sMutuallyExclusive == "Y")
                {
                    inc++;
                    //ScriptManager.RegisterStartupScript(page, page.GetType(), "openMutuallyExclusive" + inc.ToString(), "window.showModalDialog('frmMutuallyExclusive.aspx?key=" + "openMutuallyExclusive" + inc.ToString() + "&QuestionList=" + sQuestionList + "&selectedQuestion=" + sSelectedQuestion + "&queryHierarchy=" + QueryHierarchy + "&selected_ICDs=" + sSelected_ICDs + "','','dialogHeight: 375px; dialogWidth: 805px');", true);
                    //ScriptManager.RegisterStartupScript(page, page.GetType(), "openMutuallyExclusive", "openMutuallyExclusive('" + inc + "','" + sQuestionList + "','" + sSelectedQuestion + "','" + QueryHierarchy + "','" + sSelected_ICDs + "');", true);
                    if (inc == 1)
                    {
                        ScriptManager.RegisterStartupScript(page, page.GetType(), "openMutuallyExclusive", "openMutuallyExclusive('" + inc + "','" + sQuestionList + "','" + sSelectedQuestion + "','" + QueryHierarchy + "','" + sSelected_ICDs + "','" + sPageName + "');", true);
                        return;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(page, page.GetType(), "openMutuallyExclusiveforQuestion", "openMutuallyExclusiveforQuestion('" + inc + "','" + sQuestionList + "','" + sSelectedQuestion + "','" + QueryHierarchy + "','" + sSelected_ICDs + "','" + sPageName + "');", true);
                        return;
                    }
                }
                else if (sMutuallyExclusive == "N")
                {
                    inc++;
                    //ScriptManager.RegisterStartupScript(page, page.GetType(), "openMultiSelect" + inc.ToString(), "window.showModalDialog('frmMultiSelect.aspx?key=" + "openMutuallyExclusive" + inc.ToString() + "&QuestionList=" + sQuestionList + "&selectedQuestion=" + sSelectedQuestion + "&queryHierarchy=" + QueryHierarchy + "&selected_ICDs=" + sSelected_ICDs + "','','dialogHeight: 375px; dialogWidth: 805px')", true);
                    // ScriptManager.RegisterStartupScript(page, page.GetType(), "openMultiSelect", "openMultiSelect('" + inc + "','" + sQuestionList + "','" + sSelectedQuestion + "','" + QueryHierarchy + "','" + sSelected_ICDs + "');", true);

                    if (inc == 1)
                    {
                        ScriptManager.RegisterStartupScript(page, page.GetType(), "openMultiSelect", "openMultiSelect('" + inc + "','" + sQuestionList + "','" + sSelectedQuestion + "','" + QueryHierarchy + "','" + sSelected_ICDs + "','" + sPageName + "');", true);
                        return;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(page, page.GetType(), "openMultiSelectQuestion", "openMultiSelectQuestion('" + inc + "','" + sQuestionList + "','" + sSelectedQuestion + "','" + QueryHierarchy + "','" + sSelected_ICDs + "','" + sPageName + "');", true);
                        return;
                    }
                }

            }

        }

        //Added for Bug ID : 33864 & 33865
        public void DisplayQuestionsnew(Page page, string parent_ID, ref Boolean FormCancelled_ByUser, ref IList<QuestionsDTO> Selected_ICDs, QuestionsDTO selectedQuestion, ref string SourceTable, string QueryHierarchy, int icount)
        {


            string sPageName = page.AppRelativeVirtualPath;



            string sMutuallyExclusive = string.Empty;

            AllICD_9Manager objAllICDMgr = new AllICD_9Manager();

            IList<QuestionsDTO> QuestionList = null;

            if (selectedQuestion.ICD_9 != string.Empty)
            {
                if (selectedQuestion.Leaf_Node.Contains('/'))
                {
                    string[] sarr = selectedQuestion.Leaf_Node.Split('/');
                    if (sarr[0].ToString().ToUpper() == "Y")
                        SourceTable = "ASSOCIATEDPRIMARYICD";
                    else
                        SourceTable = "ALLICD";
                }
                else
                {
                    if (selectedQuestion.Leaf_Node.ToUpper() == "Y")
                        SourceTable = "ASSOCIATEDPRIMARYICD";
                    else
                        SourceTable = "ALLICD";
                }
            }

            QuestionList = objAllICDMgr.GetQuestionMasterRecord(parent_ID, ref sMutuallyExclusive, ref SourceTable);

            IList<string> selectedICDSkip = new List<string>();
            if (QuestionList.Count() > 0 && sMutuallyExclusive.ToString().ToUpper() == "N")
            {

                if (page.Session["Selected_ICDs"] != null)
                    selectedICDSkip = (IList<string>)page.Session["Selected_ICDs"];
                selectedICDSkip.Add(selectedQuestion.ICD_9 + "-" + selectedQuestion.Diagnosis_Description + "|" + selectedQuestion.Leaf_Node);
                page.Session["Selected_ICDs"] = selectedICDSkip;

                IDictionary<string, IList<string>> associatedGroupDictionairy = new Dictionary<string, IList<string>>();

                if (page.Session["associatedGroupDictionairy"] != null)
                    associatedGroupDictionairy = (IDictionary<string, IList<string>>)page.Session["associatedGroupDictionairy"];

                if (associatedGroupDictionairy.Count > 0 && associatedGroupDictionairy.ContainsKey(selectedICDSkip[assocICDinc].Split('-')[0]))
                    associatedGroupDictionairy[selectedICDSkip[assocICDinc].Split('-')[0]].Add(selectedQuestion.ICD_9);


            }

            if (QuestionList.Count == 0)
            {
               // frmAssessment.bNextClick = true;
                IList<string> ListString = new List<String>();
                IList<QuestionsDTO> reDto = new List<QuestionsDTO>();
                bool bfals = false;
                if (selectedQuestion.Leaf_Node == null)
                {
                    IList<QuestionsDTO> ResultDtoForICD = (IList<QuestionsDTO>)page.Session["QuestionDToList"];
                    if (ResultDtoForICD.Count > 0)
                    {
                        page.Session["MutualExclusive"] = null;
                        page.Session["QuestionDToList"] = ResultDtoForICD.Remove(ResultDtoForICD[0]);
                        DisplayQuestionsList(page, ListString, ref bfals, ref reDto, (IList<QuestionsDTO>)page.Session["QuestionDToList"], ref ListString, ListString);
                    }
                    else
                    {
                      //  frmAssessment.form_Cancelled = false;
                        return;
                    }
                }

                if (selectedQuestion.Leaf_Node.ToUpper() == "Y")
                {
                    IDictionary<string, IList<string>> associatedGroupDictionairy = new Dictionary<string, IList<string>>();

                    if (page.Session["associatedGroupDictionairy"] != null)
                        associatedGroupDictionairy = (IDictionary<string, IList<string>>)page.Session["associatedGroupDictionairy"];

                    Selected_ICDs.Add(selectedQuestion);

                    IList<string> selectedICD = (IList<string>)page.Session["Selected_ICDs"];

                    foreach (var item in Selected_ICDs)
                    {
                        if (page.Session["MoreThantwo"] != null)
                            assocICDinc = 0;
                        /* Commanded By Manimaran for bug id 24129 on 1-11-2014
                         if (!selectedICD.Any(s => s.Split('-')[0] == item.ICD_9))
                         {
                             selectedICD.Add(item.ICD_9 + "-" + item.Diagnosis_Description + "|" + item.Leaf_Node);

                             if (associatedGroupDictionairy.ContainsKey(selectedICD[assocICDinc].Split('-')[0]))
                                 associatedGroupDictionairy[selectedICD[assocICDinc].Split('-')[0]].Add(item.ICD_9);                         
                         }*/
                        if (!selectedICD.Any(s => s.Split('-')[0] == item.ICD_9))
                        {

                            selectedICD.Add(item.ICD_9 + "-" + item.Diagnosis_Description + "|" + item.Leaf_Node);

                            if (associatedGroupDictionairy.Count > 0 && associatedGroupDictionairy.ContainsKey(selectedICD[assocICDinc].Split('-')[0]))
                                associatedGroupDictionairy[selectedICD[assocICDinc].Split('-')[0]].Add(item.ICD_9);

                            selectedICD.Add(item.ICD_9 + "-" + item.Diagnosis_Description + "|" + item.Leaf_Node);

                        }
                        if (associatedGroupDictionairy.Count > 0 && associatedGroupDictionairy.ContainsKey(selectedICD[assocICDinc].Split('-')[0]))
                            associatedGroupDictionairy[selectedICD[assocICDinc].Split('-')[0]].Add(item.ICD_9);
                    }

                    page.Session["Selected_ICDs"] = selectedICD;

                    assocICDinc++;
                }
                IList<QuestionsDTO> ResultDtoForICD1 = (IList<QuestionsDTO>)page.Session["QuestionDToList"];
                if (page.Session["MoreThantwo"] != null)
                {
                    if (page.Session["MoreThantwo"].ToString() == "true")
                    {
                        if(icount>0)
                        {
                           // frmAssessment.SkipClickFlag = true;
                            return;
                        }
                        else if(icount==0)
                        {
                           // frmAssessment.SkipClickFlag = false;
                           // frmAssessment.form_Cancelled = false;
                            return;
                        }
                      //  frmAssessment.form_Cancelled = false;
                        return;
                    }
                }
                if (icount == 0)
                {
                   // frmAssessment.SkipClickFlag = false;
                   // frmAssessment.form_Cancelled = false;
                    return;
                }
                if (page.Session["QuestionDToList"] != null)
                {
                    if (ResultDtoForICD1.Count > 0)
                    {
                        if (page.Session["ContinueList"] == null || ((IList<QuestionsDTO>)page.Session["ContinueList"]).Count == 1)
                        {
                            page.Session["MutualExclusive"] = null;
                            page.Session["BackClose"] = "true";
                            // }
                            page.Session["ContinueList"] = null;
                            ResultDtoForICD1.Remove(ResultDtoForICD1[0]);
                            page.Session["QuestionDToList"] = ResultDtoForICD1;
                            if (ResultDtoForICD1.Count > 0)
                                DisplayQuestionsList(page, ListString, ref bfals, ref reDto, (IList<QuestionsDTO>)page.Session["QuestionDToList"], ref ListString, ListString);
                            else
                            {
                               // frmAssessment.form_Cancelled = false;
                                return;
                            }
                        }
                        else
                        {
                           // frmAssessment.form_Cancelled = false;
                            return;
                        }

                    }

                    else
                    {
                      //  frmAssessment.form_Cancelled = false;
                        return;
                    }
                }
                else
                {
                   // frmAssessment.form_Cancelled = false;
                    return;

                }
            }
           // frmAssessment.form_Cancelled = true;
            for (int i = 0; i < QuestionList.Count; i++)
            {
                sMutuallyExclusive = QuestionList[i].Mutually_Exclusive;
                if (selectedQuestion.Prefix != string.Empty)
                    QuestionList[i].Prefix = selectedQuestion.Prefix;
            }

            string sQuestionList = string.Empty;
            foreach (var item in QuestionList)
                sQuestionList += item.ICD_9 + "$" + item.Prefix + "$" + item.Diagnosis_Description + "$" + item.Leaf_Node + "|";

            string sSelectedQuestion = string.Empty;
            if (!string.IsNullOrEmpty(selectedQuestion.ICD_9))
            {
                if (selectedQuestion.Prefix == "")
                    sSelectedQuestion = selectedQuestion.ICD_9 + "$" + selectedQuestion.Diagnosis_Description + "$" + selectedQuestion.Leaf_Node;
                else
                    sSelectedQuestion = selectedQuestion.ICD_9 + "$" + selectedQuestion.Prefix + " " + selectedQuestion.Diagnosis_Description + "$" + selectedQuestion.Leaf_Node;

            }

            string sSelected_ICDs = string.Empty;
            foreach (var item in Selected_ICDs)
                sSelected_ICDs += item.ICD_9 + "$" + item.Prefix + "$" + item.Diagnosis_Description + "$" + item.Leaf_Node + "|";


            if (sMutuallyExclusive == "Y")
            {
                inc++;
                //ScriptManager.RegisterStartupScript(page, page.GetType(), "openMutuallyExclusive" + inc.ToString(), "window.showModalDialog('frmMutuallyExclusive.aspx?key=" + "openMutuallyExclusive" + inc.ToString() + "&QuestionList=" + sQuestionList + "&selectedQuestion=" + sSelectedQuestion + "&queryHierarchy=" + QueryHierarchy + "&selected_ICDs=" + sSelected_ICDs + "','','dialogHeight: 375px; dialogWidth: 805px');", true);
                //ScriptManager.RegisterStartupScript(page, page.GetType(), "openMutuallyExclusive", "openMutuallyExclusive('" + inc + "','" + sQuestionList + "','" + sSelectedQuestion + "','" + QueryHierarchy + "','" + sSelected_ICDs + "');", true);
                if (inc == 1)
                {
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "openMutuallyExclusive", "openMutuallyExclusive('" + inc + "','" + sQuestionList + "','" + sSelectedQuestion + "','" + QueryHierarchy + "','" + sSelected_ICDs + "','" + sPageName + "');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "openMutuallyExclusiveforQuestion", "openMutuallyExclusiveforQuestion('" + inc + "','" + sQuestionList + "','" + sSelectedQuestion + "','" + QueryHierarchy + "','" + sSelected_ICDs + "','" + sPageName + "');", true);
                }
            }
            else if (sMutuallyExclusive == "N")
            {
                inc++;
                //ScriptManager.RegisterStartupScript(page, page.GetType(), "openMultiSelect" + inc.ToString(), "window.showModalDialog('frmMultiSelect.aspx?key=" + "openMutuallyExclusive" + inc.ToString() + "&QuestionList=" + sQuestionList + "&selectedQuestion=" + sSelectedQuestion + "&queryHierarchy=" + QueryHierarchy + "&selected_ICDs=" + sSelected_ICDs + "','','dialogHeight: 375px; dialogWidth: 805px')", true);
                // ScriptManager.RegisterStartupScript(page, page.GetType(), "openMultiSelect", "openMultiSelect('" + inc + "','" + sQuestionList + "','" + sSelectedQuestion + "','" + QueryHierarchy + "','" + sSelected_ICDs + "');", true);

                if (inc == 1)
                {
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "openMultiSelect", "openMultiSelect('" + inc + "','" + sQuestionList + "','" + sSelectedQuestion + "','" + QueryHierarchy + "','" + sSelected_ICDs + "','" + sPageName + "');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "openMultiSelectQuestion", "openMultiSelectQuestion('" + inc + "','" + sQuestionList + "','" + sSelectedQuestion + "','" + QueryHierarchy + "','" + sSelected_ICDs + "','" + sPageName + "');", true);
                }
            }
        }
        //Added for Bug ID : 33864 & 33865

        #endregion
    }
}
