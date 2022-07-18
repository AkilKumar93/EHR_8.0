using System;
using System.Collections;
using System.Collections.Generic;
using Acurus.Capella.Core.DomainObjects;
using NHibernate;
namespace Acurus.Capella.DataAccess.ManagerObjects
{

    public partial interface IElementManager : IManagerBase<Element, int>
    {
        IList<Element> GetAllElement(string username);
        IList<Element> GetDynamicControlStyle();
    }

    public partial class ElementManager : ManagerBase<Element, int>, IElementManager
    {

        #region Constructors

        public ElementManager()
            : base()
        {

        }
        public ElementManager
            (INHibernateSession session)
            : base(session)
        {

        }
        #endregion


        #region Get Methods

        public IList<Element> GetAllElement(string username)
        {

            IList<Element> list = new List<Element>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {

                IQuery query1 = iMySession.GetNamedQuery("Element.GetAllElementUsingUserName");
                ArrayList listArray = new ArrayList(query1.List());
                Element element;
                if (listArray.Count > 0)
                {

                    foreach (object[] obj in listArray)
                    {
                        element = new Element();
                        element.Element_Name = obj[0].ToString();
                        element.SCN_ID = Convert.ToInt32(obj[1].ToString());
                        element.Element_Type = obj[2].ToString();
                        element.Target_SCN_ID = Convert.ToInt32(obj[3].ToString());
                        element.SCN_Name = obj[4].ToString();
                        list.Add(element);
                    }

                }
                iMySession.Close();
            }
            return list;
        }

        public IList<Element> GetDynamicControlStyle()
        {

            IList<Element> list = new List<Element>();
            using (ISession iMySession = NHibernateSessionManager.Instance.CreateISession())
            {

                IQuery query1 = iMySession.GetNamedQuery("DCCS.GetDynamicControlStyleDetails");

                ArrayList listArray = new ArrayList(query1.List());
                Element element;
                if (listArray.Count > 0)
                {
                    foreach (object[] obj in listArray)
                    {
                        element = new Element();
                        element.Element_Name = obj[0].ToString();
                        element.SCN_ID = Convert.ToInt32(obj[1].ToString());
                        element.Element_Type = obj[2].ToString();
                        element.Target_SCN_ID = Convert.ToInt32(obj[3].ToString());
                        element.SCN_Name = obj[4].ToString();
                        if (obj[10] != null)
                        {

                            element.Display_Text = obj[10].ToString();
                        }
                        if (obj[5] != null)
                        {
                            element.Style_Name = obj[5].ToString();
                        }
                        if (obj[6] != null)
                        {
                            element.Font_Family = obj[6].ToString();
                        }
                        if (obj[7] != null)
                        {
                            element.Em_Size = Convert.ToInt32(obj[7].ToString());
                        }
                        if (obj[8] != null)
                        {
                            element.Color = obj[8].ToString();
                        }
                        if (obj[9] != null)
                        {
                            element.Font_Style = obj[9].ToString();
                        }
                        list.Add(element);
                    }
                }
                iMySession.Close();
            }
            return list;
        }

        #endregion


    }
}
