using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Acurus.Capella.Core.DTO
{
    [DataContract]
    public partial class MyQueueCountDTO
    {
        private int _Scan_Count = 0;
        private int _My_Scan_Count = 0;
        private int _Task_Count = 0;
        private int _My_Task_Count = 0;
        private int _Order_Count = 0;
        private int _My_Order_Count = 0;
        private int _Presc_Count = 0;
        private int _My_Presc_Count = 0;
        private int _Amendmnt_Count = 0;
        private int _My_Amendmnt_Count = 0;
        private int _Dict_Count = 0;
        private int _My_Dict_Count = 0;
        private int _Diag_Order_Count = 0;
        private int _My_Diag_Order_Count = 0;
        private int _Immun_Order_Count = 0;
        private int _My_Immun_Order_Count = 0;
        private int _Inter_Order_Count = 0;
        private int _My_inter_Order_Count = 0;
        private int _Refer_Order_Count = 0;
        private int _My_Refer_Order_Count = 0;
        private int _My_DiagRslt_Order_Count = 0;
       
        IList<MyQ> _Queue ;

       #region Constructors

        public MyQueueCountDTO() 
        {
            _Queue = new List<MyQ>();
        }

        #endregion
        #region Properties

        [DataMember]
        public virtual IList<MyQ> Queue
        {
            get { return _Queue; }
            set
            {
                _Queue = value;
            }
        }

        [DataMember]
        public virtual int Scan_Count
        {
            get { return _Scan_Count; }
            set { _Scan_Count = value; }
        }

        [DataMember]
        public virtual int My_Scan_Count
        {
            get { return _My_Scan_Count; }
            set { _My_Scan_Count = value; }
        }

        [DataMember]
        public virtual int Task_Count
        {
            get { return _Task_Count; }
            set { _Task_Count = value; }
        }

        [DataMember]
        public virtual int My_Task_Count
        {
            get { return _My_Task_Count; }
            set { _My_Task_Count = value; }
        }

        [DataMember]
        public virtual int Order_Count
        {
            get { return _Order_Count; }
            set { _Order_Count = value; }
        }

        [DataMember]
        public virtual int My_Order_Count
        {
            get { return _My_Order_Count; }
            set { _My_Order_Count = value; }
        }

        [DataMember]
        public virtual int Presc_Count
        {
            get { return _Presc_Count; }
            set { _Presc_Count = value; }
        }

        [DataMember]
        public virtual int My_Presc_Count
        {
            get { return _My_Presc_Count; }
            set { _My_Presc_Count = value; }
        }

        [DataMember]
        public virtual int Amendmnt_Count
        {
            get { return _Amendmnt_Count; }
            set { _Amendmnt_Count = value; }
        }

        [DataMember]
        public virtual int My_Amendmnt_Count
        {
            get { return _My_Amendmnt_Count; }
            set { _My_Amendmnt_Count = value; }
        }

        [DataMember]
        public virtual int Dict_Count
        {
            get { return _Dict_Count; }
            set { _Dict_Count = value; }
        }

        [DataMember]
        public virtual int My_Dict_Count
        {
            get { return _My_Dict_Count; }
            set { _My_Dict_Count = value; }
        }

        [DataMember]
        public virtual int Diag_Order_Count
        {
            get { return _Diag_Order_Count; }
            set { _Diag_Order_Count = value; }
        }

        [DataMember]
        public virtual int My_Diag_Order_Count
        {
            get { return _My_Diag_Order_Count; }
            set { _My_Diag_Order_Count = value; }
        }
        [DataMember]
        public virtual int Immun_Order_Count
        {
            get { return _Immun_Order_Count; }
            set { _Immun_Order_Count = value; }
        }

        [DataMember]
        public virtual int My_Immun_Order_Count
        {
            get { return _My_Immun_Order_Count; }
            set { _My_Immun_Order_Count = value; }
        }
        [DataMember]
        public virtual int Inter_Order_Count
        {
            get { return _Inter_Order_Count; }
            set { _Inter_Order_Count = value; }
        }

        [DataMember]
        public virtual int My_inter_Order_Count
        {
            get { return _My_inter_Order_Count; }
            set { _My_inter_Order_Count = value; }
        }
        [DataMember]
        public virtual int Refer_Order_Count
        {
            get { return _Refer_Order_Count; }
            set { _Refer_Order_Count = value; }
        }

        [DataMember]
        public virtual int My_Refer_Order_Count
        {
            get { return _My_Refer_Order_Count; }
            set { _My_Refer_Order_Count = value; }
        }
           [DataMember]
        public virtual int My_DiagRslt_Order_Count
        {
            get { return _My_DiagRslt_Order_Count; }
            set { _My_DiagRslt_Order_Count = value; }
        }
      
        #endregion
    }
}
 