function tbOrders_TabSelecting(sender,args)
{

  if(window.parent.theForm.hdnTabClick != undefined && window.parent.theForm.hdnTabClick != null)
      var TabClick = window.parent.theForm.hdnTabClick;
  else
      var TabClick = window.parent.parent.theForm.ctl00_C5POBody_hdnTabClick;

  if (window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable != undefined && window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable != null)
      var hdnIsSaveEnable = window.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable;
  else
      var hdnIsSaveEnable = window.parent.parent.parent.parent.theForm.ctl00_C5POBody_hdnIsSaveEnable; 
        if (TabClick.value == "first") {
            if (hdnIsSaveEnable.value == "true") {
                TabClick.value = args._tab._element.textContent + "$#$";
                args.set_cancel(true);
                DisplayErrorMessage('1100000', 'OrdersTabClick');
                return;
            }
        }
        else {
            var splitvalue = TabClick.value.split('$#$');
            var clicked_tab = splitvalue[0];
            var switchcase = splitvalue[1];
            if (switchcase == "second,true") {
                if (window.parent.theForm.hdnSaveButtonID != undefined && window.parent.theForm.hdnSaveButtonID != null)
                    var hdnSaveButtonID = window.parent.theForm.hdnSaveButtonID;
                else
                    var hdnSaveButtonID = window.parent.parent.theForm.ctl00_C5POBody_hdnSaveButtonID;
                var IDs = hdnSaveButtonID.value.split(',');

                var childControlsofChildContainer = $find(IDs[1]).get_selectedPageView().get_element().getElementsByTagName("iframe")[0].contentWindow.$telerik.radControls;
                for (var count = (childControlsofChildContainer.length - 1); count >= 0; count--) {
                    if (childControlsofChildContainer[count]._element.id == IDs[0]) {
                        var save_button = childControlsofChildContainer[count];
                        if (save_button != undefined || save_button != null) {
                            args.set_cancel(true);
                            TabClick.value = clicked_tab + "$#$third";
                            save_button.click();
                            return;
                        }
                        break;
                    }
                }

            }
            else if (switchcase == "second,false") {
                hdnIsSaveEnable.value = "false";
            }
            else if (switchcase == "second,cancel") {
                args.set_cancel(true);
            }
            TabClick.value = "first";
        }
}
 