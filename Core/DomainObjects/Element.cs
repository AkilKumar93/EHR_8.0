using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class Element : BusinessBase<int>
    {

        #region Declarations

        private int _SCN_ID = 0;
        private string _Element_Type = string.Empty;
        private string _Element_Name = string.Empty;
        private int _Target_SCN_ID = 0;
        private string _SCN_Name = string.Empty;
        private string _Display_Text = string.Empty;
        private int _Scn_Controls_Style_ID =0 ;
        private string _Style_Name = string.Empty;
        private string _Font_Family = string.Empty;
        private int _Em_Size=0;
        private string _Color = string.Empty;
        private string _Font_Style = string.Empty;
        #endregion

        #region Constructors

        public Element() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_SCN_ID);
            sb.Append(_Element_Type);
            sb.Append(_Element_Name);
            sb.Append(_Target_SCN_ID);
            sb.Append(_Display_Text );
            sb.Append(_Scn_Controls_Style_ID);
            sb.Append(_Style_Name);
            sb.Append(_Font_Family);
            sb.Append(_Em_Size);
            sb.Append(_Color);
            sb.Append(_Font_Style);//_SCN_Name
            sb.Append(_SCN_Name);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        [DataMember]
        public virtual int SCN_ID
        {
            get { return _SCN_ID; }
            set { _SCN_ID = value; }
        }
        [DataMember]
        public virtual string Element_Type
        {
            get { return _Element_Type; }
            set { _Element_Type = value; }
        }

        [DataMember]
        public virtual string Element_Name
        {
            get { return _Element_Name; }
            set { _Element_Name = value; }
        }
        [DataMember]
        public virtual int  Target_SCN_ID
        {
            get { return _Target_SCN_ID; }
            set { _Target_SCN_ID = value; }
        }

        [DataMember]
        public virtual string SCN_Name
        {
            get { return _SCN_Name; }
            set { _SCN_Name = value; }
        }

        [DataMember]
        public virtual int Scn_Controls_Style_ID
        {
            get { return _Scn_Controls_Style_ID; }
            set { _Scn_Controls_Style_ID = value; }
        }

        [DataMember]
        public virtual string Display_Text
        {
            get { return _Display_Text; }
            set { _Display_Text = value; }
        }

        [DataMember]
        public virtual string Font_Family
        {
            get { return _Font_Family; }
            set { _Font_Family = value; }
        }
        [DataMember]
        public virtual int Em_Size
        {
            get { return _Em_Size; }
            set { _Em_Size = value; }
        }

        [DataMember]
        public virtual string Color
        {
            get { return _Color; }
            set { _Color = value; }
        }
               
        [DataMember]
        public virtual string Font_Style
        {
            get { return _Font_Style; }
            set { _Font_Style = value; }
        }

        [DataMember]
        public virtual string Style_Name
        {
            get { return _Style_Name; }
            set { _Style_Name = value; }
        }

        #endregion



    }
}
