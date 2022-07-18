function OnCustomDTPClick(ID)
{
var objDTP=ID.split(',')[0];
var cboYear=ID.split(',')[1];
var cboMonth=ID.split(',')[2];
var cboDay=ID.split(',')[3];
var Month="";

 var todaysDate = new Date();
 if($find(cboMonth)._element.value=="Jan")
 {
 Month=1;
 }
 if($find(cboMonth)._element.value=="Feb")
 {
  Month=2;
 }
 if($find(cboMonth)._element.value=="Mar")
 {
  Month=3;
 }
 if($find(cboMonth)._element.value=="Apr")
 {
  Month=4;
 }
 if($find(cboMonth)._element.value=="May")
 {
  Month=5;
 }
 if($find(cboMonth)._element.value=="Jun")
 {
  Month=6;
 }
 if($find(cboMonth)._element.value=="Jul")
 {
  Month=7;
 }
 if($find(cboMonth)._element.value=="Aug")
 {
  Month=8;
 }
 if($find(cboMonth)._element.value=="Sep")
 {
  Month=9;
 }
  if($find(cboMonth)._element.value=="Oct")
 {
  Month=10;
 }
  if($find(cboMonth)._element.value=="Nov")
 {
  Month=11;
 }
  if($find(cboMonth)._element.value=="Dec")
 {
  Month=12;
 }
 
  var selectedDate;
 if($find(cboYear)._element.value!="" &&Month!=""&&$find(cboDay)._element.value!="")
 {
 
 var seldates = $find(objDTP).get_selectedDates(); 
 for(k=0;k<seldates.length;k++)
 {
 $find(objDTP).unselectDate(seldates[k]);
 }
 
  selectedDate = [$find(cboYear)._element.value, Month, $find(cboDay)._element.value];
 $find(objDTP).selectDate(selectedDate, true);
 $find(objDTP).FocusedDate=selectedDate;
 $find(objDTP).set_focusedDate(selectedDate);
 var tdDate=[todaysDate.getFullYear(), todaysDate.getMonth() + 1, todaysDate.getDate()];
  $find(objDTP).unselectDate(tdDate);
 }
 


var AllDiv= document.getElementsByTagName("div");
for(var i=0;i<AllDiv.length;i++)
{
	if(AllDiv[i].id!=objDTP && AllDiv[i].id.indexOf("clbCalendar")>0)
	{
	  var temp=$find(AllDiv[i].id.replace("_wrapper",""));
	  if(temp!=null&&temp._element.id!=objDTP)
	  {
		temp._element.style.display="none";
		}
	}
}
if($find(objDTP)._element.style.display=="none")
{
$find(objDTP)._element.style.display="block";
}
else
{
$find(objDTP)._element.style.display="none";
}
return false;
}

function clbCalendar_OnDateClick(sender,args)
{

var seldates = $find(sender._element.id).get_selectedDates(); 
 for(k=0;k<seldates.length;k++)
 {
 $find(sender._element.id).unselectDate(seldates[k]);
 }
var obj = document.getElementsByTagName('INPUT');
var GetCalenderName = $find(sender._clientStateFieldID.replace('_ClientState',''))
var GetComboName=GetCalenderName._clientStateFieldID.split('_')[0];
var FullDate=args.get_renderDay().get_date();
var Year=FullDate[0]
var Month=FullDate[1];
var Date=FullDate[2];
for(var i=0;i<obj.length;i++)
{
if(obj[i].name.indexOf('cboYear')!=-1)
{
if(obj[i].name.indexOf(GetComboName)!=-1)
{

$find(GetComboName+'_'+'cboYear').set_text(Year.toString());

}
}
else if(obj[i].name.indexOf('cboDate')!=-1 )
{
if(obj[i].name.indexOf(GetComboName)!=-1)
{

$find(GetComboName+'_'+'cboDate').set_text(Date.toString());
}
}
else if(obj[i].name.indexOf('cboMonth')!=-1 )
{
if(obj[i].name.indexOf(GetComboName)!=-1)
{
var cboMonth=$find(GetComboName+'_'+'cboMonth');
if(Month==1)
{
  Month="Jan";
}
else if(Month==2)
{
 Month="Feb";
}
else if(Month==3)
{
   Month="Mar";
}
else if(Month==4)
{
  Month="Apr";
}
else if(Month==5)
{
 Month="May";
}
else if(Month==6)
{
  Month="Jun";
}
else if(Month==7)
{
   Month="Jul";
}
else if(Month==8)
{
  Month="Aug";
}
else if(Month==9)
{
 Month="Sep";
}
else if(Month==10)
{
 Month="Oct";
}
else if(Month==11)
{
 Month="Nov";
}
else if(Month==12)
{
 Month="Dec";
}

$find(GetComboName+'_'+'cboMonth').set_text(Month.toString());

}
}

}

$find(sender._element.id)._element.style.display="none"
}

var TMonth;
var TYear;
function OnClientDropDownOpening(sender, eventArgs)
{
var combo = $find(sender._element.id.replace("cboDate","cboMonth"));
var comboYear=$find(sender._element.id.replace("cboDate","cboYear"));

if(combo._text==""&&comboYear._text=="")
{
$find(sender._element.id).clearItems();
return false;
}
else if(combo._text!=""&&comboYear._text=="")
{
$find(sender._element.id).clearItems();
return false;
}
else if(combo._text==""&&comboYear._text!="")
{
$find(sender._element.id).clearItems();
return false;
}
else
{
$find(sender._element.id).clearItems();

var iMaxDate = 0;
var ResultMonth=0;
var iMonth = combo._text; 
if(iMonth=="Jan")
{
ResultMonth=1;
}
else if(iMonth=="Feb")
{
ResultMonth=2;
}
else if(iMonth=="Mar")
{
ResultMonth=3;
}
else if(iMonth=="Apr")
{
ResultMonth=4;
}
else if(iMonth=="May")
{
ResultMonth=5;
}
else if(iMonth=="Jun")
{
ResultMonth=6;
}
else if(iMonth=="Jul")
{
ResultMonth=7;
}
else if(iMonth=="Aug")
{
ResultMonth=8;
}
else if(iMonth=="Sep")
{
ResultMonth=9;
}
else if(iMonth=="Oct")
{
ResultMonth=10;
}
else if(iMonth=="Nov")
{
ResultMonth=11;
}
else if(iMonth=="Dec")
{
ResultMonth=12;
}

var iDate= GetDaysInMonth(ResultMonth, comboYear._text);


var combo = $find(sender._element.id);
    
    
     var comboItem = new Telerik.Web.UI.RadComboBoxItem();
    comboItem.set_text("");
    combo.trackChanges();
    combo.get_items().add(comboItem);
    combo.commitChanges();  
    for(i=1;i<=iDate;i++)
    {
    var comboItem = new Telerik.Web.UI.RadComboBoxItem();
    comboItem.set_text(i.toString());
    combo.trackChanges();
    combo.get_items().add(comboItem);
    combo.commitChanges(); 
    } 
}
}

function GetDaysInMonth(month, year)
{
if (month == 0 || year == 0)
            {
                return 0;
            }
            
             if (1 == month || 3 == month || 5 == month || 7 == month || 8 == month ||
            10 == month || 12 == month)
            {
                return 31;
            }
            
            else if (2 == month)
            {
                if (0 == (year % 4))
                {
                    if (0 == (year % 400))
                    {
                        return 29;
                    }
                    else if (0 == (year % 100))
                    {
                        return 28;
                    }
                    return 29;
                }
                return 28;
            }
            
            return 30;

}



	
	
function cboYear_SelectedIndexChanged(sender,args)
{
	var comboBox=$find(sender._element.id);
	var input = comboBox.get_inputDomElement();
    input.focus();
	if($find(sender._element.id.replace("cboYear","cboDate"))._element.value!="")
  {
  var combo = $find(sender._element.id.replace("cboYear","cboDate"));
 combo._text="";
 $find(sender._element.id)._element.value="";
 combo.clearSelection();
  }

}
	
function cboMonth_SelectedIndexChanged(sender,args)
	{
	  if($find(sender._element.id.replace("cboYear","cboDate"))._element.value!="")
  {
  var combo = $find(sender._element.id.replace("cboMonth","cboDate"));
 combo._text="";
 $find(sender._element.id)._element.value="";
 combo.clearSelection();
  }
	}	

	
	
	
	
	
	function cboDate_SelectedIndexChanged(sender,args)
	{
		var d=new Date();
var month=new Array();
month[0]="Jan";
month[1]="Feb";
month[2]="Mar";
month[3]="Apr";
month[4]="May";
month[5]="Jun";
month[6]="Jul";
month[7]="Aug";
month[8]="Sep";
month[9]="Oct";
month[10]="Nov";
month[11]="Dec";
var n = month[d.getMonth()]; 
if($find(sender._element.id.replace("cboDate","cboYear"))._element.value==d.getFullYear()&&$find(sender._element.id.replace("cboDate","cboMonth"))._element.value!=""&&$find(sender._element.id.replace("cboDate","cboMonth"))._element.value == n)
{
 if (args._item._text > d.getDate())
 {
 var combo = $find(sender._element.id);
 combo._text="";
 $find(sender._element.id)._element.value="";
 combo.clearSelection();
 }

}
	}
	
	
	
	
	
	function cboYear_DropDownOpening(sender,args)
	{
	var combo = $find(sender._element.id);
    var d=new Date();
     if(combo.get_items().get_count()==0)
     {
     var comboItem = new Telerik.Web.UI.RadComboBoxItem();
    comboItem.set_text("");
    combo.trackChanges();
    combo.get_items().add(comboItem);
    combo.commitChanges();  
   
    for(i=d.getFullYear();i>=1900;i--)
    {
    var comboItem = new Telerik.Web.UI.RadComboBoxItem();
    comboItem.set_text(i.toString());
    combo.trackChanges();
    combo.get_items().add(comboItem);
    combo.commitChanges(); 
    } 
    }
    
	}
	
	
	function cboMonth_DropDownOpening(sender,args)
	{
	var month=new Array();
month[0]="Jan";
month[1]="Feb";
month[2]="Mar";
month[3]="Apr";
month[4]="May";
month[5]="Jun";
month[6]="Jul";
month[7]="Aug";
month[8]="Sep";
month[9]="Oct";
month[10]="Nov";
month[11]="Dec";

var comboDay=$find(sender._element.id.replace("cboMonth","cboDate"));
 comboDay.set_text("");
var combo = $find(sender._element.id);
   if(combo.get_items().get_count()==0)
   { 
     var comboItem = new Telerik.Web.UI.RadComboBoxItem();
    comboItem.set_text("");
    combo.trackChanges();
    combo.get_items().add(comboItem);
    combo.commitChanges();  
for(var j=0;j<month.length;j++)
{
    var comboItem = new Telerik.Web.UI.RadComboBoxItem();
    comboItem.set_text(month[j]);
    combo.trackChanges();
    combo.get_items().add(comboItem);
    combo.commitChanges(); 
}
}
}	
	 function doStuff(ID) {
            var calendar = $find(ID);
            var todaysDate = new Date();
            
            var RDate=todaysDate.format("dd-MMM-yyyy");
            $find(calendar._element.id.replace("clbCalendar","cboYear")).set_text(RDate.split("-")[2]);
           $find(calendar._element.id.replace("clbCalendar","cboMonth")).set_text(RDate.split("-")[1]);
            
            $find(calendar._element.id.replace("clbCalendar","cboDate")).set_text(RDate.split("-")[0]);
            
            return false;
        }