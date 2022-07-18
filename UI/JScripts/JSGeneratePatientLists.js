 function chkAgeCheckBoxChecked(chkBoxId)
{
    var chkAge = document.getElementById(chkBoxId);    
    
    if (chkAge.checked)
    {
        document.getElementById("chkAgeRange").checked = false;
        $find("txtAgeRangeFrom").disable();
        $find("txtAgeRangeFrom").clear();
        $find("txtAgeRangeTo").disable();
        $find("txtAgeRangeTo").clear();
        $find("cboAge").enable(); 
        $find("txtAgeLevel").enable();                       
    }
    else
    {        
        $find("cboAge").clearSelection();
        $find("cboAge").disable();
        $find("txtAgeLevel").disable();
        $find("txtAgeLevel").clear();
    }
}

function chkAgeRangeCheckBoxChecked(chkBoxId)
{
    var chkAgeRange = document.getElementById(chkBoxId);    
    
    if (chkAgeRange.checked)
    {
        document.getElementById("chkAge").checked = false;
        $find("txtAgeRangeFrom").enable();
        $find("txtAgeRangeTo").enable();
        $find("cboAge").disable();
        $find("cboAge").clearSelection();                                 
        $find("txtAgeLevel").disable();
        $find("txtAgeLevel").clear();
    }
    else
    {
        $find("txtAgeRangeFrom").disable();
        $find("txtAgeRangeFrom").clear();  
        $find("txtAgeRangeTo").disable();
        $find("txtAgeRangeTo").clear();            
    }
}

function chkGenderCheckBoxChecked(chkBoxId)
{
    var chkGender = document.getElementById(chkBoxId);    
    
    if (chkGender.checked)
        $find("cboGender").enable(); 
    else
    {
        document.getElementById("chkGender").checked = false;
          $find("cboGender").clearSelection();
        $find("cboGender").disable();

    }
}

function pbClearmedication_click()
{
    $find("txtMedication").clear();
}

function pbClearmedicationAllergy_click()
{
    $find("txtMedicationAllergy").clear();
}

function pbClearproblemlist_click()
{
    $find("txtProblemList").clear();
}

function pbFindProblemList_Click()
{
    var Result = openModal("frmMedicationManager.aspx?SearchType=ProblemList" ,680,1145,null,'MessageWindow');    
    var windowName = $find('MessageWindow');
    windowName.add_close(OnClientCloseProblemList);    
}

function OnClientCloseProblemList(oWindow, args) 
{
    var result = args.get_argument();

    if(result != null)  
    {  
        if(  document.getElementById("txtProblemList").value != "")
        {
          document.getElementById("txtProblemList").value += result.finalProbList;
        }
        else{
           document.getElementById("txtProblemList").value = result.finalProbList;
        }
        document.getElementById("probListText").value = result.finalProbList;
        if(  document.getElementById("iProblemList").value !="")
        {
          document.getElementById("iProblemList").value += result.iProblemList;
        }
        else{
            document.getElementById("iProblemList").value = result.iProblemList;
        }
        document.getElementById("frequentProblemlist").value = result.ilistproblem;
    }
        var windowName = $find('MessageWindow');
       windowName.remove_close(OnClientCloseProblemList);    
}

function pbFindMedication_Click()
{
 
    var Result = openModal("frmMedicationManager.aspx?SearchType=GenerateListMedication" ,632,632,null,'MessageWindow');    
    var windowName = $find('MessageWindow');
     windowName.remove_close(OnClientCloseMedicationAllergyList);
    windowName.add_close(OnClientCloseMedicationList);   
}

function OnClientCloseMedicationList(oWindow, args) 
{
    var result = args.get_argument();
    var txtbox=document.getElementById("txtMedication").value;
    var length = txtbox.length;
    var lastChar = txtbox.substring(length-1,length);
    if(result != null)  
    {  
   
        var temp = result.medList.split(';');
        var res = '';     
          if(temp.length >2)
        {
         if(  document.getElementById("txtMedication").value != "")
         {
                  if(lastChar == ",")
                  {
                     document.getElementById("txtMedication").value += temp;
                  }
                  else{
                         document.getElementById("txtMedication").value  += ',';
                         document.getElementById("txtMedication").value += temp;
                    }
          }
          else{
           document.getElementById("txtMedication").value = temp;
          }
         
          }
          else
          {
                if(  document.getElementById("txtMedication").value != "")
                 {
                     if(lastChar == ",")
                      {
                         document.getElementById("txtMedication").value  += temp[0];
                      }
                    else{
                       document.getElementById("txtMedication").value  += ',';
                       document.getElementById("txtMedication").value  += temp[0];
                       }
                 }
              else{
                 document.getElementById("txtMedication").value = temp[0];
                 }
                
          }   
         if(document.getElementById("searchedMedications").value !="")
          {
           document.getElementById("searchedMedications").value += result.medList;
          }
          else{
            document.getElementById("searchedMedications").value = result.medList;
          }
        }
          var windowName = $find('MessageWindow');
          windowName.remove_close(OnClientCloseMedicationList);  
         
}

function pbFindMedicationAllergy_Click()
{

    var Result = openModal("frmMedicationManager.aspx?SearchType=MedicationAllergy" ,632,632,null,'MessageWindow');    
    var windowName = $find('MessageWindow');
    windowName.remove_close(OnClientCloseMedicationList);
    windowName.remove_close(OnClientCloseProblemList);
    windowName.add_close(OnClientCloseMedicationAllergyList);   
}

function OnClientCloseMedicationAllergyList(oWindow, args) 
{
    var result = args.get_argument();
    var txtbox=document.getElementById("txtMedicationAllergy").value;
    var length = txtbox.length;
    var lastChar = txtbox.substring(length-1,length);
     if(result != null)  
    {  
        var temp = result.medallrgyList.split(';');
        var res = '';    
        if(temp.length >2)
        {
       
         if(  document.getElementById("txtMedicationAllergy").value != "")
         {
                  if(lastChar == ",")
                  {
                     document.getElementById("txtMedicationAllergy").value += temp;
                  }
                  else{
                         document.getElementById("txtMedicationAllergy").value  += ',';
                         document.getElementById("txtMedicationAllergy").value += temp;
                    }
          }
          else{
           document.getElementById("txtMedicationAllergy").value = temp;
          }
          }
          else
          {
           
            if(  document.getElementById("txtMedicationAllergy").value != "")
           {
               if(lastChar == ",")
                  {
                    document.getElementById("txtMedicationAllergy").value  += temp[0];
                  }
                  else{
                       document.getElementById("txtMedicationAllergy").value  += ',';
                       document.getElementById("txtMedicationAllergy").value  += temp[0];
                     }
            }
          else{
                 document.getElementById("txtMedicationAllergy").value = temp[0];
              }
           
          } 
          if(document.getElementById("hdnMedAllergy").value !="")
          {
           document.getElementById("hdnMedAllergy").value += result.medallrgyList;
          }
          else{
            document.getElementById("hdnMedAllergy").value = result.medallrgyList;
          }
          
        }
         var windowName = $find('MessageWindow');
    windowName.remove_close(OnClientCloseMedicationAllergyList);  
      
}

function btnGenerateReport_ClientClicked(sender,args)
{

    var now=new Date();
     var utcnew = now.toUTCString();
    document.getElementById("hdnLocalTime").value=utcnew;
     document.getElementById("divLoading").style.display="block";

}

function btnClearAll_ClientClicked(sender,args)
{
     document.getElementById("divLoading").style.display="block";
     
    if(DisplayErrorMessage('7030012') == true)
        document.getElementById("isClearAll").value = true;
    else
        document.getElementById("isClearAll").value = false;    
}

function openform() {
    var childWindow = $find('MessageWindow1');
    var obj = new Array();
    obj.push("SI=" + document.getElementById('hdnFilePath').value);
    obj.push("Location=" + "DYNAMIC");
    setTimeout(function () {
        $find('MessageWindow1').BrowserWindow.openModal('frmPrintPDF.aspx', 800, 750, obj, 'MessageWindow1');
    }, 0);

}

function StopLoadFromPatChart() {

    $("span[mand=Yes]").addClass('MandLabelstyle');
    $("span[mand=Yes]").each(function () {
        $(this).html($(this).html().replace("*", "<span class='manredforstar'>*</span>"));
    });
    $("[id*=pbDropdown]").addClass('pbDropdownBackground');
}