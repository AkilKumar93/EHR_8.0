using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Acurus.Capella.Core.DTOJson
{
    public class DynamicScreenList
    {
        public DynamicScreenList()
        {
            DynamicScreen = new List<Dynamic_Screen>();
        }
        public List<Dynamic_Screen> DynamicScreen { get; set; }
    }
    public class Dynamic_Screen
    {
        public string Dynamic_Screen_ID { get; set; }
        public string Screen_ID { get; set; }
        public string Master_Vitals_ID { get; set; }
        public string Control_Name { get; set; }
        public string Control_Type { get; set; }
        public string Display_Text { get; set; }
        public string LookUp_Field { get; set; }
        public string Table_Name { get; set; }
        public string Column_Name { get; set; }
        public string Mandatory { get; set; }
        public string Minimum_Value { get; set; }
        public string Maximum_Value { get; set; }
        public string Column_Span { get; set; }
        public string Is_Editable { get; set; }
        public string LookUp_Method { get; set; }
        public string Utility_Method { get; set; }
        public string Parent_Control_ID { get; set; }
        public string Maximum_Length { get; set; }
        public string Allow_Decimal { get; set; }
        public string Sort_Order { get; set; }
        public string Control_Content_Type { get; set; }
        public string Loinc_Identifier { get; set; }
        public string Acurus_Result_Code { get; set; }
        public string Acurus_Result_Description { get; set; }
        public string Is_Flow_Sheet_Required { get; set; }
        public string Control_Name_Thin_Client { get; set; }
        public string Column_Span_Thin_Client { get; set; }
        public string LookUp_Method_Thin_Client { get; set; }
        public string Snomed_Code { get; set; }
        public string Is_Macra_Field { get; set; }
    }

    

}
