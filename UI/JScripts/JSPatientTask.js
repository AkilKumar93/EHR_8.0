

function btnFindPatient_Clicked(sender,args)
	{
	 var obj=new Array();
	 var result = openModal("frmFindPatient.aspx", 251, 1200, obj);
         if(result.HumanId != null)
         {
         document.getElementById("txtAccount").value=result.HumanId;
         return true;   
         }
	}
function CloseReplyPatientTask()
{
   self.close(); 
}
//function OpenphoneEncounter()
//{
//    var obj=new Array();
//    var result=openModal("frmPhoneEncounter.aspx",850,1125,obj);
//}