/*--Keyoti js--*/
/*<![CDATA[*/
//Version 1.4 (RapidSpell Web assembly version 3.5 onwards)
//Copyright Keyoti Inc. 2005-2013
//This code is not to be modified, copied or used without a license in any form.

var rsS58=new Array("Microsoft Internet Explorer",
"MSIE ([0-9]{1,}[\.0-9]{0,})",
"rsTCInt",
"undefined",
"IgnoreXML",
"True",
"popUpCheckSpelling",
"('rsTCInt",
"')",
"g",
"&#34;",
"&",
"&amp;",
"Error: element ",
" does not exist, check TextComponentName.",
"",
"Sorry, a textbox with ID=",
" couldn't be found - please check the TextComponentID or TextComponentName property.",
"_IF",
"&lt;",
"&gt;",
"TEXTAREA",
"INPUT",
" EDITABLE",
"\r\n",
" ",
"contentEditable",
"true",
"designMode",
"on",
"IFRAME",
" --has contentWindow.document",
"*");																																				var rs_s2=window;var rs_s3=document; var rsw_launcher_script_loaded = true; var rsw_suppressWarnings=false; function rsw_getInternetExplorerVersion() { var rv = -1;
																																						 if (navigator.appName == rsS58[0]) { var ua = navigator.userAgent; var re = new RegExp(rsS58[1]); if (re.exec(ua) != null) rv = parseFloat(RegExp.$1); } return rv;
																																						 } function SpellCheckLauncher(clientID){ this.clientID = clientID; this.OnSpellButtonClicked = OnSpellButtonClicked; this.config; this.hasRunFieldID; this.getParameterValue = getParameterValue;
																																						 this.setParameterValue = setParameterValue; this.tbInterface = null; function getParameterValue(param){ for(var pp=0; pp<this.config.keys.length; pp++){ if(this.config.keys[pp]==param) return this.config.values[pp];
																																						 } } function setParameterValue(param, value){ for(var pp=0; pp<this.config.keys.length; pp++){ if(this.config.keys[pp]==param) this.config.values[pp] = value; } } function OnSpellButtonClicked(){ this.tbInterface = eval(rsS58[2]+this.clientID);
																																						 if(this.tbInterface!=null && typeof(this.tbInterface.findContainer)!=rsS58[3]){ this.textBoxID = this.tbInterface.findContainer().id; if (!this.tbInterface.targetIsPlain){ this.setParameterValue(rsS58[4], rsS58[5]);
																																						 } } eval(rsS58[6]+this.clientID+rsS58[7]+this.clientID+rsS58[8]); } } function RS_writeDoc(toWindow, isSafari){ toWindow.document.open(); toWindow.document.write(spellBoot);
																																						 toWindow.document.close(); if(isSafari) toWindow.document.forms[0].submit(); } function escQuotes(text){ var rx = new RegExp("\"", rsS58[9]); return text.replace(rx,rsS58[10]);
																																						 } function escEntities(text){ var rx = new RegExp(rsS58[11], rsS58[9]); return text.replace(rx,rsS58[12]); } function RSStandardInterface(tbElementName){ this.tbName = tbElementName;
																																						 this.getText = getText; this.setText = setText; function getText(){ if(!document.getElementById(this.tbName) && !rsw_suppressWarnings) { alert(rsS58[13]+this.tbName+rsS58[14]);
																																						 return rsS58[15]; } else return rs_s3.getElementById(this.tbName).value; } function setText(text) { if(rs_s3.getElementById(this.tbName)) rs_s3.getElementById(this.tbName).value = text;
																																						 if(typeof(rsw_tbs)!=rsS58[3]){ for(var i=0; i<rsw_tbs.length; i++){ if(rsw_tbs[i].shadowTB.id==this.tbName){ if(rsw_tbs[i].updateIframe){rsw_tbs[i].updateIframe();
																																						rsw_tbs[i].focus();} } } } } } function RSAutomaticInterface(tbElementName){ this.tbName = tbElementName;this.getText = getText;this.setText = setText; this.identifyTarget = identifyTarget;
																																						 this.target=null; this.targetContainer = null; this.searchedForTarget = false; this.targetIsPlain = true; this.showNoFindError = showNoFindError; this.finder = null;
																																						 this.findContainer = findContainer; function findContainer(){ this.identifyTarget(); return this.targetContainer; } function showNoFindError(){ alert(rsS58[16]+this.tbName+rsS58[17]);
																																						 } function identifyTarget(){ if(!this.searchedForTarget){ this.searchedForTarget = true; if(this.finder == null) this.finder = new RSW_EditableElementFinder(); var plain = this.finder.findPlainTargetElement(this.tbName);
																																						 var richs = this.finder.findRichTargetElements(); if(plain==null && (richs==null || richs.length==0) && !rsw_suppressWarnings) showNoFindError(); else{ if(richs==null || richs.length==0){ this.targetIsPlain = true;
																																						 this.target = plain; this.targetContainer = plain; } else { if(plain==null && richs.length==1){ this.targetIsPlain = false; this.target = this.finder.obtainElementWithInnerHTML(richs[0][0]);
																																						 this.targetContainer = richs[0][1]; } else { for (var rp = 0; rp < richs.length; rp ++){ if(typeof(richs[rp][1].id)!=rsS58[3] && richs[rp][1].id.indexOf(this.tbName)>-1){ if(plain!=null && richs[rp][1].id == plain.id+rsS58[18]){ this.targetIsPlain = true;
																																						 this.target = plain; this.targetContainer = plain; break; } else { this.targetIsPlain = false; this.target = this.finder.obtainElementWithInnerHTML(richs[rp][0]);
																																						 this.targetContainer = richs[rp][1]; break; } } } if(this.target==null){ this.target = plain; this.targetIsPlain = true; this.targetContainer = plain; } } } } } } function getText(){ this.identifyTarget();
																																						 if( this.targetIsPlain ) return this.target.value; else return this.target.innerHTML; } function setText(text){ this.identifyTarget(); if (this.targetIsPlain) { var ver = rsw_getInternetExplorerVersion();
																																						 if (ver > 0 && ver < 9) text = text.replace(/</g, rsS58[19]).replace(/>/g, rsS58[20]); this.target.value = text; } else this.target.innerHTML = text; if(typeof(rsw_tbs)!=rsS58[3]){ for(var i=0;
																																						 i<rsw_tbs.length; i++){ if(rsw_tbs[i].shadowTB.id==this.tbName){ if(rsw_tbs[i].updateIframe){rsw_tbs[i].updateIframe();rsw_tbs[i].focus();} } } } } } function RSW_EditableElementFinder(){ this.findPlainTargetElement = findPlainTargetElement;
																																						 this.findRichTargetElements = findRichTargetElements; this.obtainElementWithInnerHTML = obtainElementWithInnerHTML; this.findEditableElements = findEditableElements;
																																						 this.elementIsEditable = elementIsEditable; this.getEditableContentDocument = getEditableContentDocument; function findPlainTargetElement(elementID){ var rsw_elected = rs_s3.getElementById(elementID);
																																						 if(rsw_elected!=null && rsw_elected.tagName && (rsw_elected.tagName.toUpperCase()==rsS58[21] || rsw_elected.tagName.toUpperCase()==rsS58[22])){ return rsw_elected;
																																						 } else return null; } function findRichTargetElements(debugTextBox){ var editables = new Array(); this.findEditableElements(document, editables, window,rsS58[15], debugTextBox);
																																						 return editables; } function obtainElementWithInnerHTML(editable){ if(typeof(editable.innerHTML)!=rsS58[3]) return editable; else if(typeof(editable.documentElement)!=rsS58[3]) return editable.documentElement;
																																						 return null; } function findEditableElements(node, editables, parent, debugInset, debugTextBox){ var children = node.childNodes; var editableElement; if(debugTextBox) debugTextBox.value += debugInset + node.tagName;
																																						 if( (editableElement=this.elementIsEditable(node))!=null || (editableElement=this.getEditableContentDocument(node, debugTextBox))!=null ){ if(debugTextBox) debugTextBox.value += rsS58[23];
																																						 editables[editables.length] = editableElement; } if(debugTextBox) debugTextBox.value += rsS58[24]; for (var i = 0; i < children.length; i++) { this.findEditableElements(children[i], editables, node, debugInset+rsS58[25], debugTextBox);
																																						 } } function elementIsEditable(element){ if ( ( typeof(element.getAttribute)!=rsS58[3] && ( element.getAttribute(rsS58[26])==rsS58[27] || element.getAttribute(rsS58[28])==rsS58[29] ) ) || ( (element.contentEditable && element.contentEditable==true) || (element.designMode && element.designMode.toLowerCase()==rsS58[29]) ) ) return [element, element];
																																						 else return null; } function getEditableContentDocument(element, debugTextBox){ if(element.tagName && element.tagName==rsS58[30]){ var kids = new Array(); if(element.contentWindow && element.contentWindow.document){ if(debugTextBox) debugTextBox.value += rsS58[31];
																																						 this.findEditableElements(element.contentWindow.document, kids, element, rsS58[32], debugTextBox); if(kids.length>0){ var editable = kids[0][0]; if(typeof(editable.body)!=rsS58[3]) editable = editable.body;
																																						 return [editable, element]; } } } return null; } } if( typeof(Sys)!=rsS58[3] && typeof(Sys.Application)!=rsS58[3]) Sys.Application.notifyScriptLoaded(); 
