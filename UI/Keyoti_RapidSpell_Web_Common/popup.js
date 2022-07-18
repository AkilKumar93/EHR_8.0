/*--Keyoti js--*/
//Version 1.5 (RapidSpell Web assembly version 3.4.3 onwards)
//Copyright Keyoti Inc. 2005-2009
//This code is not to be modified, copied or used without a license in any form.

var rsS80=new Array("",
"popup",
"<style></style>",
"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=",
"if (",
"!=null && !",
".closed && ",
".",
") ",
"(spellCheckFinished)",
"undefined",
"<",
"&lt;",
">",
"&gt;",
"<br>",
"function getPageCoords (el) {\n",
" var coords = {x: 0, y: 0};\n var dd='';",
" do {\ndd+=el.tagName+' '+el.offsetLeft+' '+coords.x+'\\r\\n';",
" coords.x += el.offsetLeft;\n",
" coords.y += el.offsetTop;\n",
"dd+='2 '+el.tagName+' '+el.offsetLeft+' '+coords.x+'\\r\\n'; }\n",
" while ((el = el.offsetParent));\n",
" return coords;\n",
"}\n",
"function scrollIntoView(el) {\n",
" var coords = getPageCoords(el);\n",
" window.scrollTo (coords.x, coords.y);\n",
"</span>",
"style",
"text/css",
"<style>",
"</style>",
"script",
"text/javascript",
"string",
"LINK",
"head",
"href",
"rel",
"stylesheet",
"marginwidth",
"marginheight",
"topmargin",
"leftmargin",
"highlight",
"function",
"?",
"&",
"fMessage=addWord&UserDictionaryFile=",
"&word=",
"&GuiLanguage=",
"<\\s*script([^<])*<([ ])*/([ ])*script([ ])*",
"i",
"<\\s*script([^<])*/([ ])*>",
"<\\s*script([^<])*>",
"<\\s*embed([^<])*>",
"(<([^>])*)on(([^ |^=)*([ |=])*=([ |=])*([^ |^>])*(([^>])*>))",
"$1$3",
"(<([^>])*)([ |=])*=([ |=])*([^ |^>])*javascript:([^ |^>])*(([^>])*>)",
"$1$7",
"<PUBLIC([ ])*:([^<])*<([ ])*/PUBLIC([ ])*",
"<PUBLIC([ ])*:([^<])*/([ ])*>",
"<PUBLIC([ ])*:([^<])*>");																																				var rs_s2=window;var rs_s3=document; var iAed=new Array(), cAed=new Array(); var spellCheckFinished=false; var duplicateWord=false; var showXMLTags=true;
																																						 var userDicFile=rsS80[0]; var mode=rsS80[1]; var callBack=rsS80[0]; var currentWordIndex=0; var ignoreWordIndexes=new Array(); var documentTextBoxStyle=rsS80[2]; var hist = new Array();
																																						 var histPtr=0; var addingWord = false; var refreshResetUnload=false; var keyStr = rsS80[3]; function decode64(input) { var output = rsS80[0]; var chr1, chr2, chr3;
																																						 var enc1, enc2, enc3, enc4; var i = 0; do { enc1 = keyStr.indexOf(input.charAt(i++)); enc2 = keyStr.indexOf(input.charAt(i++)); enc3 = keyStr.indexOf(input.charAt(i++));
																																						 enc4 = keyStr.indexOf(input.charAt(i++)); chr1 = (enc1 << 2) | (enc2 >> 4); chr2 = ((enc2 & 15) << 4) | (enc3 >> 2); chr3 = ((enc3 & 3) << 6) | enc4; output = output + String.fromCharCode(chr1);
																																						 if (enc3 != 64) { output = output + String.fromCharCode(chr2); } if (enc4 != 64) { output = output + String.fromCharCode(chr3); } } while (i < input.length); return output;
																																						 } function rsw_callCorrectionNotifyListener(listener, a, b, c){ var f = decode64(listener); openerWindow[f](a, b, c, interfaceObject.tbName) } function rsw_callFinishListener(listener, openerWindow){ eval(rsS80[4]+openerWindow+rsS80[5]+openerWindow+rsS80[6]+openerWindow+rsS80[7]+decode64(listener)+rsS80[8]+openerWindow+rsS80[7]+decode64(listener)+rsS80[9]);
																																						 } function onWordAdded(){ addingWord = false; } function updateHistory(){ if(enableUndo){ var curChecking = -1; if(openerWindow != null && !openerWindow.closed && typeof (openerWindow.currentlyChecking) != rsS80[10]) curChecking = openerWindow.currentlyChecking;
																																						 var fieldDisEl = rs_s3.getElementById(rsw_fieldDisplayTextLabelID); var elHTML = rsS80[0]; if(fieldDisEl)elHTML = fieldDisEl.innerHTML; hist[histPtr] = [cp(ignoreWordIndexes), currentWordIndex, text, cp(badWords), interfaceObject, curChecking, getIndices(badWords), elHTML, cp(iAed), cp(cAed)];
																																						 histPtr++; } } function undoChange(){ activateButtons(); if(histPtr>0){ histPtr--; if(hist[histPtr][4]!=interfaceObject)interfaceObject.setText(text); ignoreWordIndexes = hist[histPtr][0];
																																						 currentWordIndex = hist[histPtr][1]; text = hist[histPtr][2]; badWords = hist[histPtr][3]; interfaceObject = hist[histPtr][4]; var curChecking = hist[histPtr][5];
																																						 if(typeof (openerWindow != null && openerWindow.currentlyChecking) != rsS80[10] && curChecking>-1)openerWindow.currentlyChecking = curChecking; setIndices(badWords, hist[histPtr][6]);
																																						 var elHTML = hist[histPtr][7]; var fieldDisEl = rs_s3.getElementById(rsw_fieldDisplayTextLabelID); if(fieldDisEl) fieldDisEl.innerHTML = elHTML; iAed = hist[histPtr][8];
																																						 cAed = hist[histPtr][9]; hist.length = histPtr+1; if(currentWordIndex<0) undoChange(); else refresh(); } } function cp(ary){ var bry = new Array(); for(var i=0; i<ary.length;
																																						 i++) bry[i] = ary[i]; return bry; } function getIndices(bw){ var a = new Array(); for(var i=0; i<bw.length; i++) a[i] = [bw[i].start, bw[i].end]; return a; } function setIndices(bw, a){ for(var i=0;
																																						 i<bw.length; i++){ bw[i].start=a[i][0]; bw[i].end=a[i][1]; } return a; } function change(){ updateHistory(); if(currentWordIndex<badWords.length){ changeWord(currentWordIndex);
																																						 nextWord(); } } function changeAll() { updateHistory(); if (currentWordIndex < badWords.length) { var currentWord = badWords[currentWordIndex].text; var n=changeWord(currentWordIndex);
																																						 cAed[cAed.length]={text:currentWord, r:n}; for (var i = currentWordIndex + 1; i < badWords.length; i++) { if (!ignoreWordIndexes[i] && badWords[i].text == currentWord) { changeWord(i);
																																						 ignoreWordIndexes[i] = true; } } nextWord(); } } function ignoreCurrent(){ updateHistory(); if(currentWordIndex<badWords.length){ nextWord(); } } function ignoreAll(){ updateHistory();
																																						 if (currentWordIndex < badWords.length) { var currentWord = badWords[currentWordIndex].text; iAed[iAed.length]=currentWord; for (var i = currentWordIndex + 1; i < badWords.length;
																																						 i++) { if (!ignoreWordIndexes[i] && badWords[i].text == currentWord) { ignoreWordIndexes[i] = true; } } nextWord(); } } function changeSuggestions(){ var suggestion=document.forms[0].suggestions.options[document.forms[0].suggestions.selectedIndex].text;
																																						 if(suggestion!=noSuggestionsText){ rs_s3.forms[0].word.value=suggestion; } } function deactivateButtons(){ if(rs_s3.forms[0].changeButton!=null) rs_s3.forms[0].changeButton.disabled=true;
																																						 if(rs_s3.forms[0].changeAllButton!=null) rs_s3.forms[0].changeAllButton.disabled=true; if(rs_s3.forms[0].ignoreButton!=null) rs_s3.forms[0].ignoreButton.disabled=true;
																																						 if(rs_s3.forms[0].ignoreAllButton!=null) rs_s3.forms[0].ignoreAllButton.disabled=true; if(rs_s3.forms[0].addButton!=null) rs_s3.forms[0].addButton.disabled=true; } function activateButtons(){ if(rs_s3.forms[0].undoButton!=null) rs_s3.forms[0].undoButton.disabled=false;
																																						 if(rs_s3.forms[0].changeButton!=null) rs_s3.forms[0].changeButton.disabled=false; if(rs_s3.forms[0].changeAllButton!=null) rs_s3.forms[0].changeAllButton.disabled=false;
																																						 if(rs_s3.forms[0].ignoreButton!=null) rs_s3.forms[0].ignoreButton.disabled=false; if(rs_s3.forms[0].ignoreAllButton!=null) rs_s3.forms[0].ignoreAllButton.disabled=false;
																																						 if(rs_s3.forms[0].addButton!=null) rs_s3.forms[0].addButton.disabled=false; } function nextWord(){ var f=true; while(currentWordIndex++<badWords.length&&ignoreWordIndexes[currentWordIndex]);
																																						 if(currentWordIndex>=badWords.length){ deactivateButtons(); } else { } refresh(); } function textToHtml(t){ if(typeof(rsw_textToHtml)!=rsS80[10]) return rsw_textToHtml(t);
																																						 if(showXMLTags){ var ltexp = new RegExp(rsS80[11]); while(ltexp.test(t)) t = t.replace(ltexp, rsS80[12]); var gtexp = new RegExp(rsS80[13]); while(gtexp.test(t)) t = t.replace(gtexp, rsS80[14]);
																																						 } else { } var newlineexp = new RegExp(newlineRule); while(newlineexp.test(t)) t = t.replace(newlineexp, rsS80[15]); return t; } function refresh() { if (refreshResetUnload) { onunload = windowClosing;
																																						 refreshResetUnload = false; } if(currentWordIndex<badWords.length){ spellCheckFinished=false; var html = rsS80[0]; var script = rsS80[0]; script += rsS80[16]; script += rsS80[17];
																																						 script += rsS80[18]; script += rsS80[19]; script += rsS80[20]; script += rsS80[21]; script += rsS80[22]; script += rsS80[23]; script += rsS80[24]; script += rsS80[25];
																																						 script += rsS80[26]; script += rsS80[27]; script += rsS80[24]; html+=ftr(textToHtml(text.substring(0,badWords[currentWordIndex].start)),scriptFilterLevel); html+='<span id="highlight" class="badWordHighlight">';
																																						 html+=ftr(text.substring(badWords[currentWordIndex].start,badWords[currentWordIndex].end),scriptFilterLevel); html+=rsS80[28]; html+=ftr(textToHtml(text.substring(badWords[currentWordIndex].end,text.length)),scriptFilterLevel);
																																						 var documentTextBoxStyleEl = documentTextPanel.document.createElement(rsS80[29]); documentTextBoxStyleEl.type = rsS80[30]; if (documentTextBoxStyleEl.styleSheet) { documentTextBoxStyleEl.styleSheet.cssText = documentTextBoxStyle.replace(rsS80[31], rsS80[0]).replace(rsS80[32], rsS80[0]);
																																						 } else { documentTextBoxStyleEl.appendChild(documentTextPanel.document.createTextNode(documentTextBoxStyle.replace(rsS80[31], rsS80[0]).replace(rsS80[32], rsS80[0])));
																																						 } var scr = documentTextPanel.document.createElement(rsS80[33]); scr.type = rsS80[34]; if (typeof(scr.text)==rsS80[35]) { scr.text = script; } else { scr.appendChild(documentTextPanel.document.createTextNode(script));
																																						 } var linkElement = documentTextPanel.document.createElement(rsS80[36]); linkElement.type = rsS80[30]; documentTextPanel.document.getElementsByTagName(rsS80[37])[0].appendChild(linkElement);
																																						 linkElement.setAttribute(rsS80[38], cssLinkURL); linkElement.setAttribute(rsS80[39], rsS80[40]); documentTextPanel.document.getElementsByTagName(rsS80[37])[0].appendChild(documentTextBoxStyleEl);
																																						 documentTextPanel.document.getElementsByTagName(rsS80[37])[0].appendChild(scr); documentTextPanel.document.body.innerHTML = html; documentTextPanel.document.body.setAttribute(rsS80[41], 4);
																																						 documentTextPanel.document.body.setAttribute(rsS80[42], 4); documentTextPanel.document.body.setAttribute(rsS80[43], 4); documentTextPanel.document.body.setAttribute(rsS80[44], 4);
																																						 try { if (documentTextPanel.scrollIntoView) documentTextPanel.scrollIntoView(documentTextPanel.document.getElementById(rsS80[45])); } catch (EE) { } rs_s3.forms[0].suggestions.options.length=0;
																																						 var n=badWords[currentWordIndex].suggestions.length; if(n==0){ rs_s3.forms[0].word.value=badWords[currentWordIndex].text; rs_s3.forms[0].suggestions.options[0]=new Option(noSuggestionsText);
																																						 } else if (badWords[currentWordIndex].suggestions[0]==removeDuplicateWordText){ rs_s3.forms[0].suggestions.options[0]=new Option(badWords[currentWordIndex].suggestions[0]);
																																						 rs_s3.forms[0].suggestions.selectedIndex=0; rs_s3.forms[0].word.value=rsS80[0]; duplicateWord=true; } else{ rs_s3.forms[0].word.value=badWords[currentWordIndex].suggestions[0];
																																						 for(var i=0;i<n;i++){ rs_s3.forms[0].suggestions.options[i]=new Option(badWords[currentWordIndex].suggestions[i]); } rs_s3.forms[0].suggestions.selectedIndex=0; duplicateWord=false;
																																						 } rs_s3.forms[0].word.select(); } else{ var html=rsS80[0]; html+=ftr(textToHtml(text),scriptFilterLevel); var documentTextBoxStyleEl = documentTextPanel.document.createElement(rsS80[29]);
																																						 documentTextBoxStyleEl.type = rsS80[30]; if (documentTextBoxStyleEl.styleSheet) { documentTextBoxStyleEl.styleSheet.cssText = documentTextBoxStyle.replace(rsS80[31], rsS80[0]).replace(rsS80[32], rsS80[0]);
																																						 } else { documentTextBoxStyleEl.appendChild(documentTextPanel.document.createTextNode(documentTextBoxStyle.replace(rsS80[31], rsS80[0]).replace(rsS80[32], rsS80[0])));
																																						 } var linkElement = documentTextPanel.document.createElement(rsS80[36]); linkElement.type = rsS80[30]; documentTextPanel.document.getElementsByTagName(rsS80[37])[0].appendChild(linkElement);
																																						 linkElement.setAttribute(rsS80[38], cssLinkURL); linkElement.setAttribute(rsS80[39], rsS80[40]); documentTextPanel.document.getElementsByTagName(rsS80[37])[0].appendChild(documentTextBoxStyleEl);
																																						 documentTextPanel.document.body.innerHTML = html; documentTextPanel.document.body.setAttribute(rsS80[41], 4); documentTextPanel.document.body.setAttribute(rsS80[42], 4);
																																						 documentTextPanel.document.body.setAttribute(rsS80[43], 4); documentTextPanel.document.body.setAttribute(rsS80[44], 4); rs_s3.forms[0].word.value=rsS80[0]; rs_s3.forms[0].suggestions.options.length=0;
																																						 rs_s3.forms[0].suggestions.options[0]=new Option(noSuggestionsText); if(badWords.length>0){ finishedMessageJS(); } else { noErrorsMessageJS(); } spellCheckFinished = true;
																																						 duplicateWord = false; finish(); } if(typeof(onRefreshed)==rsS80[46])onRefreshed(); } function changeWord(index, replacement){ if(replacement) replacement=replacement;
																																						 else replacement=document.forms[0].word.value; changeNotifyCode(index); var newText=rsS80[0]; if(duplicateWord && rs_s3.forms[0].word.value==rsS80[0]){ badWords[index].start--;
																																						 } newText+=text.substring(0,badWords[index].start); newText+=replacement; newText+=text.substring(badWords[index].end,text.length); moveWordOffsets(replacement.length - (badWords[index].end - badWords[index].start), index + 1);
																																						 text=newText; return replacement; } function moveWordOffsets(delta,start){ for(i=start;i<badWords.length;i++){ badWords[i].start+=delta; badWords[i].end+=delta; } } function addCurrent(){ addingWord = true;
																																						 var currentWord = badWords[currentWordIndex].text; if(rs_s3.forms[0].addButton){ rs_s3.forms[0].addButton.value=addingText; rs_s3.forms[0].addButton.disabled=true;
																																						 } addWordFrame.location.href=document.location.href + (rs_s3.location.href.indexOf(rsS80[47])>-1?rsS80[48]:rsS80[47]) +rsS80[49] + escape(userDicFile) + rsS80[50] + badWords[currentWordIndex].e + rsS80[51]+guiLanguage+rsS80[0];
																																						 ignoreAll(); } function ftr(tt, level){ switch(level){ case 1: return fsb( tt ); break; case 2: return feh( tt ); break; case 3: return ftr(ftr(tt,2),1); break; case 4: return fu( tt );
																																						 break; case 5: return ftr(ftr(tt,4),1); break; case 6: return ftr(ftr(tt,4),2); break; case 7: return ftr(ftr(tt,6),1); break; case 8: return fb(tt); break; case 9: return ftr(ftr(tt,8),1);
																																						 break; case 10: return ftr(ftr(tt,8),2); break; case 11: return ftr(ftr(tt,10),1); break; case 12: return ftr(ftr(tt,8),4); break; case 13: return ftr(ftr(tt,12),1);
																																						 break; case 14: return ftr(ftr(tt,12),2); break; case 15: return fsb( feh( fu( fb(tt) ) ) ); break; default: return tt; break; } } function fsb(tt){ var exp = new RegExp(rsS80[52] + rsS80[13], rsS80[53]);
																																						 while(exp.test(tt)) tt = tt.replace(exp, rsS80[0]); var exp = new RegExp(rsS80[54], rsS80[53]); while(exp.test(tt)) tt = tt.replace(exp, rsS80[0]); var exp = new RegExp(rsS80[55], rsS80[53]);
																																						 while(exp.test(tt)) tt = tt.replace(exp, rsS80[0]); var exp = new RegExp(rsS80[56], rsS80[53]); while(exp.test(tt)) tt = tt.replace(exp, rsS80[0]); return tt; } function feh(tt){ var exp = new RegExp(rsS80[57], rsS80[53]);
																																						 while(exp.test(tt)) tt = tt.replace(exp, rsS80[58]); return tt; } function fu(tt){ var exp = new RegExp(rsS80[59], rsS80[53]); while(exp.test(tt)) tt = tt.replace(exp, rsS80[60]);
																																						 return tt; } function fb(tt){ var exp = new RegExp(rsS80[61]+rsS80[13], rsS80[53]); while(exp.test(tt)) tt = tt.replace(exp, rsS80[0]); var exp = new RegExp(rsS80[62], rsS80[53]);
																																						 while(exp.test(tt)) tt = tt.replace(exp, rsS80[0]); var exp = new RegExp(rsS80[63], rsS80[53]); while(exp.test(tt)) tt = tt.replace(exp, rsS80[0]); return tt } if( typeof(Sys)!=rsS80[10] && typeof(Sys.Application)!=rsS80[10]) Sys.Application.notifyScriptLoaded();
																																						 //-------------------------
