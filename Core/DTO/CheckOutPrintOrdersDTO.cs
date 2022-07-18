using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Acurus.Capella.Core.DomainObjects;

namespace Acurus.Capella.Core.DTO
{
    
    [DataContract]
   public partial class CheckOutPrintOrdersDTO
    {
         #region Declarations
       ImmunizationDTO _ImmunizationDTO;
       OrdersDTO _Order_Details_Dto_Lab_Order_List;
       OrdersDTO _Order_Details_Dto_Image_Order_List;
       ReferralOrderDTO _Referral_Order_Dto;
       InHouseProcedureDTO _Inhouse_procedureDto;
       #endregion

          #region Constructor
       public CheckOutPrintOrdersDTO()
        {
            _ImmunizationDTO = new ImmunizationDTO();
            _Order_Details_Dto_Lab_Order_List = new OrdersDTO();
            _Order_Details_Dto_Image_Order_List = new OrdersDTO();
            _Referral_Order_Dto = new ReferralOrderDTO();
            _Inhouse_procedureDto = new InHouseProcedureDTO(); 
        }
          #endregion

        #region Properties

        [DataMember]
        public virtual ImmunizationDTO ImmunizationDTOobj
        {
            get { return _ImmunizationDTO; }
            set { _ImmunizationDTO = value; }
        }

        [DataMember]
        public virtual OrdersDTO Order_Details_Dto_Lab_Order_List
        {
            get { return _Order_Details_Dto_Lab_Order_List; }
            set { _Order_Details_Dto_Lab_Order_List = value; }
        }
        [DataMember]
        public virtual OrdersDTO Order_Details_Dto_Image_Order_List
        {
            get { return _Order_Details_Dto_Image_Order_List; }
            set { _Order_Details_Dto_Image_Order_List = value; }
        }
    
        [DataMember]
        public virtual ReferralOrderDTO Referral_Order_Dto
        {
            get { return _Referral_Order_Dto; }
            set { _Referral_Order_Dto = value; }
        }
        [DataMember]
        public virtual InHouseProcedureDTO Inhouse_procedureDto
        {
            get { return _Inhouse_procedureDto; }
            set { _Inhouse_procedureDto = value; }
        }
        #endregion
    }
}
