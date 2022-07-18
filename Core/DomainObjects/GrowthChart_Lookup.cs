using System.Runtime.Serialization;

namespace Acurus.Capella.Core.DomainObjects
{
    [DataContract]
    public partial class GrowthChart_Lookup : BusinessBase<ulong>
    {
            #region Declarations

        private string _Gender = string.Empty;
        private string _Category = string.Empty;
        private string _X_Axis_Unit = string.Empty;
        private decimal _X_Axis_Value = 0;
        private string _Y_Axis_Unit = string.Empty;
        private decimal _Percentile_3=0;
        private decimal _Percentile_5=0;
        private decimal _Percentile_10=0;
        private decimal _Percentile_25=0;
        private decimal _Percentile_50=0;
        private decimal _Percentile_75=0;
        private decimal _Percentile_85=0;
        private decimal _Percentile_90=0;
        private decimal _Percentile_95=0;
        private decimal _Percentile_97=0;
        private int _X_Axis_Start = 0;
        private int _X_Axis_End = 0;
        private int _X_Axis_Interval = 0;
        private int _Y_Axis_Start = 0;
        private int _Y_Axis_End = 0;
        private int _Y_Axis_Interval = 0; 
        #endregion

        #region Constructors

        public GrowthChart_Lookup() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(_Gender);
            sb.Append(_Category);
            sb.Append(_X_Axis_Unit);
            sb.Append(_X_Axis_Value);
            sb.Append(_Y_Axis_Unit);
            sb.Append(_Percentile_3);
            sb.Append(_Percentile_5);
            sb.Append(_Percentile_10);
            sb.Append(_Percentile_25);
            sb.Append(_Percentile_50);
            sb.Append(_Percentile_75);
            sb.Append(_Percentile_85);
            sb.Append(_Percentile_90);
            sb.Append(_Percentile_95);
            sb.Append(_Percentile_97);
            sb.Append(_X_Axis_Start);
            sb.Append(_X_Axis_End);
            sb.Append(_X_Axis_Interval);
            sb.Append(_Y_Axis_Start);
            sb.Append(_Y_Axis_End);
            sb.Append(_Y_Axis_Interval);
            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties
        [DataMember]
        public virtual string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }

        }
        [DataMember]
        public virtual string Category
        {
            get { return _Category; }
            set { _Category = value; }

        }
        [DataMember]
        public virtual string X_Axis_Unit
        {
            get { return _X_Axis_Unit; }
            set { _X_Axis_Unit = value; }

        }
        [DataMember]
        public virtual decimal X_Axis_Value
        {
            get { return _X_Axis_Value; }
            set { _X_Axis_Value = value; }
        }
        [DataMember]
        public virtual string Y_Axis_Unit
        {
            get { return _Y_Axis_Unit; }
            set { _Y_Axis_Unit = value; }
        }
        [DataMember]
        public virtual decimal Percentile_3
        {
            get { return _Percentile_3; }
            set { _Percentile_3 = value; }

        }
        [DataMember]
        public virtual decimal Percentile_5
        {
            get { return _Percentile_5; }
            set { _Percentile_5 = value; }
        }

        [DataMember]
        public virtual decimal Percentile_10
        {
            get { return _Percentile_10; }
            set { _Percentile_10 = value; }
        }

        [DataMember]
        public virtual decimal Percentile_25
        {
            get { return _Percentile_25; }
            set { _Percentile_25 = value; }
        }

        [DataMember]
        public virtual decimal Percentile_50
        {
            get { return _Percentile_50; }
            set { _Percentile_50 = value; }
        }

        [DataMember]
        public virtual decimal Percentile_75
        {
            get { return _Percentile_75; }
            set { _Percentile_75 = value; }
        }

        [DataMember]
        public virtual decimal Percentile_85
        {
            get { return _Percentile_85; }
            set { _Percentile_85 = value; }
        }

        [DataMember]
        public virtual decimal Percentile_90
        {
            get { return _Percentile_90; }
            set { _Percentile_90 = value; }
        }

        [DataMember]
        public virtual decimal Percentile_95
        {
            get { return _Percentile_95; }
            set { _Percentile_95 = value; }
        }

        [DataMember]
        public virtual decimal Percentile_97
        {
            get { return _Percentile_97; }
            set { _Percentile_97 = value; }
        }

        [DataMember]
        public virtual int X_Axis_Start
        {
            get { return _X_Axis_Start; }
            set { _X_Axis_Start = value; }
        }
        [DataMember]
        public virtual int X_Axis_End
        {
            get { return _X_Axis_End; }
            set { _X_Axis_End = value; }
        }
        [DataMember]
        public virtual int X_Axis_Interval
        {
            get { return _X_Axis_Interval; }
            set { _X_Axis_Interval = value; }
        }
        [DataMember]
        public virtual int Y_Axis_Start
        {
            get { return _Y_Axis_Start; }
            set { _Y_Axis_Start = value; }
        }
        [DataMember]
        public virtual int Y_Axis_End
        {
            get { return _Y_Axis_End; }
            set { _Y_Axis_End = value; }
        }
        [DataMember]
        public virtual int Y_Axis_Interval
        {
            get { return _Y_Axis_Interval; }
            set { _Y_Axis_Interval = value; }
        }

        #endregion
    }
}
