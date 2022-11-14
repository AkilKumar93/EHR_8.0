<?xml version="1.0" encoding="UTF-8"?>
<!--
  Title: CDA XSL StyleSheet
  Original Filename: cda.xsl 
  Version: 3.0
  Revision History: 08/12/08 Jingdong Li updated
  Revision History: 12/11/09 KH updated 
  Revision History:  03/30/10 Jingdong Li updated.
  Revision History:  08/25/10 Jingdong Li updated
  Revision History:  09/17/10 Jingdong Li updated
  Revision History:  01/05/11 Jingdong Li updated
  Specification: ANSI/HL7 CDAR2  
  The current version and documentation are available at http://www.lantanagroup.com/resources/tools/. 
  We welcome feedback and contributions to tools@lantanagroup.com
  The stylesheet is the cumulative work of several developers; the most significant prior milestones were the foundation work from HL7 
  Germany and Finland (Tyylitiedosto) and HL7 US (Calvin Beebe), and the presentation approach from Tony Schaller, medshare GmbH provided at IHIC 2009. 
-->
<!-- LICENSE INFORMATION
  Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at  http://www.apache.org/licenses/LICENSE-2.0 
-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:n1="urn:hl7-org:v3" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
   <xsl:output method="html" indent="yes" version="4.01" encoding="ISO-8859-1" doctype-system="http://www.w3.org/TR/html4/strict.dtd" doctype-public="-//W3C//DTD HTML 4.01//EN"/>
   <!-- global variable title -->
   <xsl:variable name="title">
      <xsl:choose>
         <xsl:when test="string-length(/n1:ClinicalDocument/n1:title)  &gt;= 1">
            <xsl:value-of select="/n1:ClinicalDocument/n1:title"/>
         </xsl:when>
         <xsl:when test="/n1:ClinicalDocument/n1:code/@displayName">
            <xsl:value-of select="/n1:ClinicalDocument/n1:code/@displayName"/>
         </xsl:when>
         <xsl:otherwise>
            <xsl:text>Clinical Document</xsl:text>
         </xsl:otherwise>
      </xsl:choose>
   </xsl:variable>
   <!-- Main -->
   <xsl:template match="/">
      <xsl:apply-templates select="n1:ClinicalDocument"/>
   </xsl:template>
   <!-- produce browser rendered, human readable clinical document -->
   <xsl:template match="n1:ClinicalDocument">
      <html>
         <head>
            <xsl:comment> Do NOT edit this HTML directly: it was generated via an XSLT transformation from a CDA Release 2 XML document. </xsl:comment>
            <title>
               <xsl:value-of select="$title"/>
            </title>
            <xsl:call-template name="addCSS"/>
         </head>
         <body>
            <h1 class="h1center">
               <xsl:value-of select="$title"/>
            </h1>
            <!-- START display top portion of clinical document --> 
            <xsl:call-template name="recordTarget"/>
            <xsl:call-template name="documentGeneral"/>
            <xsl:call-template name="documentationOf"/>
            <xsl:call-template name="author"/>
            <xsl:call-template name="componentof"/>
            <xsl:call-template name="participant"/>
            <xsl:call-template name="dataEnterer"/>
            <xsl:call-template name="authenticator"/>
            <xsl:call-template name="informant"/>
            <xsl:call-template name="informationRecipient"/>
            <xsl:call-template name="legalAuthenticator"/>
            <xsl:call-template name="custodian"/>
            <xsl:call-template name="languageCode"/>
            <!-- END display top portion of clinical document -->
            <!-- produce table of contents -->
            <xsl:if test="not(//n1:nonXMLBody)">
               <xsl:if test="count(/n1:ClinicalDocument/n1:component/n1:structuredBody/n1:component[n1:section]) &gt; 1">
                  <xsl:call-template name="make-tableofcontents"/>
               </xsl:if>
            </xsl:if>
            <hr align="left" color="teal" size="2" width="80%"/>
            <!-- produce human readable document content -->
            <xsl:apply-templates select="n1:component/n1:structuredBody|n1:component/n1:nonXMLBody"/>
            <br/>
            <br/>
         </body>
      </html>
   </xsl:template>
   <!-- generate table of contents -->
   <xsl:template name="make-tableofcontents">
      <h2>
         <a name="toc">Table of Contents</a>
      </h2>
      <ul>
         <xsl:for-each select="n1:component/n1:structuredBody/n1:component/n1:section/n1:title">
            <li>
               <a href="#{generate-id(.)}">
                  <xsl:value-of select="."/>
               </a>
            </li>
         </xsl:for-each>
      </ul>
   </xsl:template>
   <!-- header elements -->
   <xsl:template name="documentGeneral">
      <table class="header_table">
         <tbody>
            <tr>
               <td width="20%" bgcolor="#3399ff">
                  <span class="td_label">
                     <xsl:text>Document Id</xsl:text>
                  </span>
               </td>
               <td width="80%">
                  <xsl:call-template name="show-id">
                     <xsl:with-param name="id" select="n1:id"/>
                  </xsl:call-template>
               </td>
            </tr>
            <tr>
               <td width="20%" bgcolor="#3399ff">
                  <span class="td_label">
                     <xsl:text>Document Created:</xsl:text>
                  </span>
               </td>
               <td width="80%">
                  <xsl:call-template name="show-time">
                     <xsl:with-param name="datetime" select="n1:effectiveTime"/>
                  </xsl:call-template>
               </td>
            </tr>
         </tbody>
      </table>
   </xsl:template>
   <!-- confidentiality -->
   <xsl:template name="confidentiality">
      <table class="header_table">
         <tbody>
            <td width="20%" bgcolor="#3399ff">
               <xsl:text>Confidentiality</xsl:text>
            </td>
            <td width="80%">
               <xsl:choose>
                  <xsl:when test="n1:confidentialityCode/@code  = &apos;N&apos;">
                     <xsl:text>Normal</xsl:text>
                  </xsl:when>
                  <xsl:when test="n1:confidentialityCode/@code  = &apos;R&apos;">
                     <xsl:text>Restricted</xsl:text>
                  </xsl:when>
                  <xsl:when test="n1:confidentialityCode/@code  = &apos;V&apos;">
                     <xsl:text>Very restricted</xsl:text>
                  </xsl:when>
               </xsl:choose>
               <xsl:if test="n1:confidentialityCode/n1:originalText">
                  <xsl:text> </xsl:text>
                  <xsl:value-of select="n1:confidentialityCode/n1:originalText"/>
               </xsl:if>
            </td>
         </tbody>
      </table>
   </xsl:template>
  <!-- Preferred Lanugage -->
  <xsl:template name="languageCode">
    <table class="header_table">
      <tbody>
        <td width="20%" bgcolor="#3399ff">
          <span class="td_label">
            <xsl:text>Preferred Language</xsl:text>
          </span>
        </td>
        <td width="80%">
          <!--<xsl:text>English</xsl:text>-->
		<xsl:choose>
            <xsl:when test="n1:languageCode/@code  = &apos;en-US&apos;">
              <xsl:text>English</xsl:text>
            </xsl:when>
            <xsl:when test="n1:languageCode/@code  = &apos;Spanish&apos;">
              <xsl:text>Spanish</xsl:text>
            </xsl:when>
            <xsl:when test="n1:languageCode/@code  = &apos;es-US&apos;">
              <xsl:text>Spanish</xsl:text>
            </xsl:when>
            <!--xsl:when test="n1:languageCode/@code  = &apos;en&apos;">
              <xsl:text>English</xsl:text>
            </xsl:when>
            <xsl:when test="n1:languageCode/@code  = &apos;English&apos;">
              <xsl:text>English</xsl:text>
            </xsl:when-->
            <xsl:when test="n1:languageCode/@code  = &apos;spa&apos;">
              <xsl:text>Spanish</xsl:text>
            </xsl:when>
            <xsl:when test="n1:languageCode/@code  = &apos;eng&apos;">
              <xsl:text>English</xsl:text>
            </xsl:when>
            <xsl:when test="n1:languageCode/@code  = &apos;ara&apos;">
              <xsl:text>Arabic</xsl:text>
            </xsl:when>
            <xsl:when test="n1:languageCode/@code  = &apos;arm(B), hye(T)&apos;">
              <xsl:text>Armenian</xsl:text>
            </xsl:when>
            <xsl:when test="n1:languageCode/@code  = &apos;chi(B), zho(T)&apos;">
              <xsl:text>Chinese languages</xsl:text>
            </xsl:when>
            <xsl:when test="n1:languageCode/@code  = &apos;fre(B), fra(T)&apos;">
              <xsl:text>French</xsl:text>
            </xsl:when>
            <xsl:when test="n1:languageCode/@code  = &apos;cpf&apos;">
              <xsl:text>French Creole</xsl:text>
            </xsl:when>
            <xsl:when test="n1:languageCode/@code  = &apos;ger(B), deu(T)&apos;">
              <xsl:text>German</xsl:text>
            </xsl:when>
            <xsl:when test="n1:languageCode/@code  = &apos;gre(B), ell(T)&apos;">
              <xsl:text>Greek</xsl:text>
            </xsl:when>
            <xsl:when test="n1:languageCode/@code  = &apos;guj&apos;">
              <xsl:text>Gujarati</xsl:text>
            </xsl:when>
            <xsl:when test="n1:languageCode/@code  = &apos;hin&apos;">
              <xsl:text>Hindi</xsl:text>
            </xsl:when>
            <xsl:when test="n1:languageCode/@code  = &apos;ita&apos;">
              <xsl:text>Italian</xsl:text>
            </xsl:when>
            <xsl:when test="n1:languageCode/@code  = &apos;jpn&apos;">
              <xsl:text>Japanese</xsl:text>
            </xsl:when>
            <xsl:when test="n1:languageCode/@code  = &apos;kor&apos;">
              <xsl:text>Korean</xsl:text>
            </xsl:when>
            <xsl:when test="n1:languageCode/@code  = &apos;per(B), fas(T)&apos;">
              <xsl:text>Persian</xsl:text>
            </xsl:when>
            <xsl:when test="n1:languageCode/@code  = &apos;pol&apos;">
              <xsl:text>Polish</xsl:text>
            </xsl:when>
            <xsl:when test="n1:languageCode/@code  = &apos;por&apos;">
              <xsl:text>Portuguese</xsl:text>
            </xsl:when>
            <xsl:when test="n1:languageCode/@code  = &apos;rus&apos;">
              <xsl:text>Russian</xsl:text>
            </xsl:when>
            <xsl:when test="n1:languageCode/@code  = &apos;tgl&apos;">
              <xsl:text>Tagalog</xsl:text>
            </xsl:when>
            <xsl:when test="n1:languageCode/@code  = &apos;urd&apos;">
              <xsl:text>Urdu</xsl:text>
            </xsl:when>
            <xsl:when test="n1:languageCode/@code  = &apos;vie&apos;">
              <xsl:text>Vietnamese</xsl:text>
            </xsl:when>	
			<xsl:when test="n1:languageCode/@code  = &apos;NA&apos;"><xsl:text>Declined to specify</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ab&apos;"><xsl:text>Abkhazian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ace&apos;"><xsl:text>Achinese</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ach&apos;"><xsl:text>Acoli</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ada&apos;"><xsl:text>Adangme</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ady&apos;"><xsl:text>Adygei</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ady&apos;"><xsl:text>Adyghe</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;aa&apos;"><xsl:text>Afar</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;afh&apos;"><xsl:text>Afrihili</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;af&apos;"><xsl:text>Afrikaans</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;afa&apos;"><xsl:text>Afro-Asiatic languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ain&apos;"><xsl:text>Ainu</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ak&apos;"><xsl:text>Akan</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;akk&apos;"><xsl:text>Akkadian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sq&apos;"><xsl:text>Albanian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;gsw&apos;"><xsl:text>Alemannic</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ale&apos;"><xsl:text>Aleut</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;alg&apos;"><xsl:text>Algonquian languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;gsw&apos;"><xsl:text>Alsatian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;tut&apos;"><xsl:text>Altaic languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;am&apos;"><xsl:text>Amharic</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;anp&apos;"><xsl:text>Angika</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;apa&apos;"><xsl:text>Apache languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ar&apos;"><xsl:text>Arabic</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;an&apos;"><xsl:text>Aragonese</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;arp&apos;"><xsl:text>Arapaho</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;arw&apos;"><xsl:text>Arawak</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;hy&apos;"><xsl:text>Armenian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;rup&apos;"><xsl:text>Aromanian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;art&apos;"><xsl:text>Artificial languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;rup&apos;"><xsl:text>Arumanian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;as&apos;"><xsl:text>Assamese</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ast&apos;"><xsl:text>Asturian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ast&apos;"><xsl:text>Asturleonese</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ath&apos;"><xsl:text>Athapascan languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;aus&apos;"><xsl:text>Australian languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;map&apos;"><xsl:text>Austronesian languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;av&apos;"><xsl:text>Avaric</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ae&apos;"><xsl:text>Avestan</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;awa&apos;"><xsl:text>Awadhi</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ay&apos;"><xsl:text>Aymara</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;az&apos;"><xsl:text>Azerbaijani</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ast&apos;"><xsl:text>Bable</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ban&apos;"><xsl:text>Balinese</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;bat&apos;"><xsl:text>Baltic languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;bal&apos;"><xsl:text>Baluchi</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;bm&apos;"><xsl:text>Bambara</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;bai&apos;"><xsl:text>Bamileke languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;bad&apos;"><xsl:text>Banda languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;bnt&apos;"><xsl:text>Bantu languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;bas&apos;"><xsl:text>Basa</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ba&apos;"><xsl:text>Bashkir</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;eu&apos;"><xsl:text>Basque</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;btk&apos;"><xsl:text>Batak languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;bej&apos;"><xsl:text>Bedawiyet</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;bej&apos;"><xsl:text>Beja</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;be&apos;"><xsl:text>Belarusian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;bem&apos;"><xsl:text>Bemba</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;bn&apos;"><xsl:text>Bengali</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ber&apos;"><xsl:text>Berber languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;bho&apos;"><xsl:text>Bhojpuri</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;bh&apos;"><xsl:text>Bihari languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;bik&apos;"><xsl:text>Bikol</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;byn&apos;"><xsl:text>Bilin</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;bin&apos;"><xsl:text>Bini</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;bi&apos;"><xsl:text>Bislama</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;byn&apos;"><xsl:text>Blin</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;zbl&apos;"><xsl:text>Bliss</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;zbl&apos;"><xsl:text>Blissymbolics</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;zbl&apos;"><xsl:text>Blissymbols</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nob&apos;"><xsl:text>Bokm&#x00E5;l, Norwegian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;bs&apos;"><xsl:text>Bosnian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;bra&apos;"><xsl:text>Braj</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;br&apos;"><xsl:text>Breton</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;bug&apos;"><xsl:text>Buginese</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;bg&apos;"><xsl:text>Bulgarian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;bua&apos;"><xsl:text>Buriat</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;my&apos;"><xsl:text>Burmese</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;cad&apos;"><xsl:text>Caddo</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;es&apos;"><xsl:text>Castilian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ca&apos;"><xsl:text>Catalan</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;cau&apos;"><xsl:text>Caucasian languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ceb&apos;"><xsl:text>Cebuano</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;cel&apos;"><xsl:text>Celtic languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;cai&apos;"><xsl:text>Central American Indian languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;km&apos;"><xsl:text>Central Khmer</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;chg&apos;"><xsl:text>Chagatai</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;cmc&apos;"><xsl:text>Chamic languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ch&apos;"><xsl:text>Chamorro</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ce&apos;"><xsl:text>Chechen</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;chr&apos;"><xsl:text>Cherokee</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ny&apos;"><xsl:text>Chewa</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;chy&apos;"><xsl:text>Cheyenne</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;chb&apos;"><xsl:text>Chibcha</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ny&apos;"><xsl:text>Chichewa</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;zh&apos;"><xsl:text>Chinese</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;chn&apos;"><xsl:text>Chinook jargon</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;chp&apos;"><xsl:text>Chipewyan</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;cho&apos;"><xsl:text>Choctaw</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;za&apos;"><xsl:text>Chuang</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;cu&apos;"><xsl:text>Church Slavic</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;cu&apos;"><xsl:text>Church Slavonic</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;chk&apos;"><xsl:text>Chuukese</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;cv&apos;"><xsl:text>Chuvash</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nwc&apos;"><xsl:text>Classical Nepal Bhasa</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nwc&apos;"><xsl:text>Classical Newari</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;syc&apos;"><xsl:text>Classical Syriac</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;rar&apos;"><xsl:text>Cook Islands Maori</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;cop&apos;"><xsl:text>Coptic</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kw&apos;"><xsl:text>Cornish</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;co&apos;"><xsl:text>Corsican</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;cr&apos;"><xsl:text>Cree</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mus&apos;"><xsl:text>Creek</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;crp&apos;"><xsl:text>Creoles and pidgins</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;cpe&apos;"><xsl:text>Creoles and pidgins, English based</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;cpf&apos;"><xsl:text>Creoles and pidgins, French-based</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;cpp&apos;"><xsl:text>Creoles and pidgins, Portuguese-based</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;crh&apos;"><xsl:text>Crimean Tatar</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;crh&apos;"><xsl:text>Crimean Turkish</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;hr&apos;"><xsl:text>Croatian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;cus&apos;"><xsl:text>Cushitic languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;cs&apos;"><xsl:text>Czech</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;dak&apos;"><xsl:text>Dakota</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;da&apos;"><xsl:text>Danish</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;dar&apos;"><xsl:text>Dargwa</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;del&apos;"><xsl:text>Delaware</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;chp&apos;"><xsl:text>Dene Suline</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;dv&apos;"><xsl:text>Dhivehi</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;zza&apos;"><xsl:text>Dimili</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;zza&apos;"><xsl:text>Dimli</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;din&apos;"><xsl:text>Dinka</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;dv&apos;"><xsl:text>Divehi</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;doi&apos;"><xsl:text>Dogri</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;dgr&apos;"><xsl:text>Dogrib</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;dra&apos;"><xsl:text>Dravidian languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;dua&apos;"><xsl:text>Duala</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nl&apos;"><xsl:text>Dutch</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;dum&apos;"><xsl:text>Dutch, Middle (ca.1050-1350)</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;dyu&apos;"><xsl:text>Dyula</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;dz&apos;"><xsl:text>Dzongkha</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;frs&apos;"><xsl:text>Eastern Frisian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;bin&apos;"><xsl:text>Edo</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;efi&apos;"><xsl:text>Efik</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;egy&apos;"><xsl:text>Egyptian (Ancient)</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;eka&apos;"><xsl:text>Ekajuk</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;elx&apos;"><xsl:text>Elamite</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;en&apos;"><xsl:text>English</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;enm&apos;"><xsl:text>English, Middle (1100-1500)</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ang&apos;"><xsl:text>English, Old (ca.450-1100)</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;myv&apos;"><xsl:text>Erzya</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;eo&apos;"><xsl:text>Esperanto</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;et&apos;"><xsl:text>Estonian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ee&apos;"><xsl:text>Ewe</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ewo&apos;"><xsl:text>Ewondo</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;fan&apos;"><xsl:text>Fang</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;fat&apos;"><xsl:text>Fanti</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;fo&apos;"><xsl:text>Faroese</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;fj&apos;"><xsl:text>Fijian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;fil&apos;"><xsl:text>Filipino</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;fi&apos;"><xsl:text>Finnish</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;fiu&apos;"><xsl:text>Finno-Ugrian languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nl&apos;"><xsl:text>Flemish</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;fon&apos;"><xsl:text>Fon</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;fr&apos;"><xsl:text>French</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;frm&apos;"><xsl:text>French, Middle (ca.1400-1600)</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;fro&apos;"><xsl:text>French, Old (842-ca.1400)</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;fur&apos;"><xsl:text>Friulian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ff&apos;"><xsl:text>Fulah</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;gaa&apos;"><xsl:text>Ga</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;gd&apos;"><xsl:text>Gaelic</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;car&apos;"><xsl:text>Galibi Carib</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;gl&apos;"><xsl:text>Galician</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;lg&apos;"><xsl:text>Ganda</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;gay&apos;"><xsl:text>Gayo</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;gba&apos;"><xsl:text>Gbaya</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;gez&apos;"><xsl:text>Geez</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ka&apos;"><xsl:text>Georgian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;de&apos;"><xsl:text>German</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nds&apos;"><xsl:text>German, Low</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;gmh&apos;"><xsl:text>German, Middle High (ca.1050-1500)</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;goh&apos;"><xsl:text>German, Old High (ca.750-1050)</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;gem&apos;"><xsl:text>Germanic languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ki&apos;"><xsl:text>Gikuyu</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;gil&apos;"><xsl:text>Gilbertese</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;gon&apos;"><xsl:text>Gondi</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;gor&apos;"><xsl:text>Gorontalo</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;got&apos;"><xsl:text>Gothic</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;grb&apos;"><xsl:text>Grebo</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;grc&apos;"><xsl:text>Greek, Ancient (to 1453)</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;el&apos;"><xsl:text>Greek, Modern (1453-)</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kl&apos;"><xsl:text>Greenlandic</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;gn&apos;"><xsl:text>Guarani</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;gu&apos;"><xsl:text>Gujarati</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;gwi&apos;"><xsl:text>Gwich&apos;in</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;hai&apos;"><xsl:text>Haida</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ht&apos;"><xsl:text>Haitian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ht&apos;"><xsl:text>Haitian Creole</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ha&apos;"><xsl:text>Hausa</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;haw&apos;"><xsl:text>Hawaiian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;he&apos;"><xsl:text>Hebrew</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;hz&apos;"><xsl:text>Herero</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;hil&apos;"><xsl:text>Hiligaynon</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;him&apos;"><xsl:text>Himachali languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;hi&apos;"><xsl:text>Hindi</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ho&apos;"><xsl:text>Hiri Motu</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;hit&apos;"><xsl:text>Hittite</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;hmn&apos;"><xsl:text>Hmong</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;hu&apos;"><xsl:text>Hungarian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;hup&apos;"><xsl:text>Hupa</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;iba&apos;"><xsl:text>Iban</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;is&apos;"><xsl:text>Icelandic</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;io&apos;"><xsl:text>Ido</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ig&apos;"><xsl:text>Igbo</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ijo&apos;"><xsl:text>Ijo languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ilo&apos;"><xsl:text>Iloko</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;arc&apos;"><xsl:text>Imperial Aramaic (700-300 BCE)</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;smn&apos;"><xsl:text>Inari Sami</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;inc&apos;"><xsl:text>Indic languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ine&apos;"><xsl:text>Indo-European languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;id&apos;"><xsl:text>Indonesian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;inh&apos;"><xsl:text>Ingush</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ia&apos;"><xsl:text>Interlingua (International Auxiliary Language Association)</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ie&apos;"><xsl:text>Interlingue</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;iu&apos;"><xsl:text>Inuktitut</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ik&apos;"><xsl:text>Inupiaq</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ira&apos;"><xsl:text>Iranian languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ga&apos;"><xsl:text>Irish</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mga&apos;"><xsl:text>Irish, Middle (900-1200)</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sga&apos;"><xsl:text>Irish, Old (to 900)</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;iro&apos;"><xsl:text>Iroquoian languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;it&apos;"><xsl:text>Italian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ja&apos;"><xsl:text>Japanese</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;jv&apos;"><xsl:text>Javanese</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kac&apos;"><xsl:text>Jingpho</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;jrb&apos;"><xsl:text>Judeo-Arabic</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;jpr&apos;"><xsl:text>Judeo-Persian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kbd&apos;"><xsl:text>Kabardian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kab&apos;"><xsl:text>Kabyle</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kac&apos;"><xsl:text>Kachin</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kl&apos;"><xsl:text>Kalaallisut</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;xal&apos;"><xsl:text>Kalmyk</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kam&apos;"><xsl:text>Kamba</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kn&apos;"><xsl:text>Kannada</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kr&apos;"><xsl:text>Kanuri</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;pam&apos;"><xsl:text>Kapampangan</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kaa&apos;"><xsl:text>Kara-Kalpak</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;krc&apos;"><xsl:text>Karachay-Balkar</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;krl&apos;"><xsl:text>Karelian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kar&apos;"><xsl:text>Karen languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ks&apos;"><xsl:text>Kashmiri</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;csb&apos;"><xsl:text>Kashubian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kaw&apos;"><xsl:text>Kawi</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kk&apos;"><xsl:text>Kazakh</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kha&apos;"><xsl:text>Khasi</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;khi&apos;"><xsl:text>Khoisan languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kho&apos;"><xsl:text>Khotanese</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ki&apos;"><xsl:text>Kikuyu</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kmb&apos;"><xsl:text>Kimbundu</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;rw&apos;"><xsl:text>Kinyarwanda</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;zza&apos;"><xsl:text>Kirdki</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ky&apos;"><xsl:text>Kirghiz</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;zza&apos;"><xsl:text>Kirmanjki</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;tlh&apos;"><xsl:text>Klingon</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kv&apos;"><xsl:text>Komi</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kg&apos;"><xsl:text>Kongo</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kok&apos;"><xsl:text>Konkani</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ko&apos;"><xsl:text>Korean</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kos&apos;"><xsl:text>Kosraean</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kpe&apos;"><xsl:text>Kpelle</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kro&apos;"><xsl:text>Kru languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kj&apos;"><xsl:text>Kuanyama</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kum&apos;"><xsl:text>Kumyk</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ku&apos;"><xsl:text>Kurdish</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kru&apos;"><xsl:text>Kurukh</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kut&apos;"><xsl:text>Kutenai</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kj&apos;"><xsl:text>Kwanyama</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ky&apos;"><xsl:text>Kyrgyz</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;lad&apos;"><xsl:text>Ladino</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;lah&apos;"><xsl:text>Lahnda</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;lam&apos;"><xsl:text>Lamba</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;day&apos;"><xsl:text>Land Dayak languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;lo&apos;"><xsl:text>Lao</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;la&apos;"><xsl:text>Latin</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;lv&apos;"><xsl:text>Latvian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ast&apos;"><xsl:text>Leonese</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;lb&apos;"><xsl:text>Letzeburgesch</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;lez&apos;"><xsl:text>Lezghian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;li&apos;"><xsl:text>Limburgan</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;li&apos;"><xsl:text>Limburger</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;li&apos;"><xsl:text>Limburgish</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ln&apos;"><xsl:text>Lingala</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;lt&apos;"><xsl:text>Lithuanian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;jbo&apos;"><xsl:text>Lojban</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nds&apos;"><xsl:text>Low German</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nds&apos;"><xsl:text>Low Saxon</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;dsb&apos;"><xsl:text>Lower Sorbian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;loz&apos;"><xsl:text>Lozi</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;lu&apos;"><xsl:text>Luba-Katanga</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;lua&apos;"><xsl:text>Luba-Lulua</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;lui&apos;"><xsl:text>Luiseno</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;smj&apos;"><xsl:text>Lule Sami</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;lun&apos;"><xsl:text>Lunda</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;luo&apos;"><xsl:text>Luo (Kenya and Tanzania)</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;lus&apos;"><xsl:text>Lushai</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;lb&apos;"><xsl:text>Luxembourgish</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;rup&apos;"><xsl:text>Macedo-Romanian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mk&apos;"><xsl:text>Macedonian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mad&apos;"><xsl:text>Madurese</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mag&apos;"><xsl:text>Magahi</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mai&apos;"><xsl:text>Maithili</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mak&apos;"><xsl:text>Makasar</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mg&apos;"><xsl:text>Malagasy</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ms&apos;"><xsl:text>Malay</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ml&apos;"><xsl:text>Malayalam</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;dv&apos;"><xsl:text>Maldivian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mt&apos;"><xsl:text>Maltese</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mnc&apos;"><xsl:text>Manchu</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mdr&apos;"><xsl:text>Mandar</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;man&apos;"><xsl:text>Mandingo</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mni&apos;"><xsl:text>Manipuri</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mno&apos;"><xsl:text>Manobo languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;gv&apos;"><xsl:text>Manx</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mi&apos;"><xsl:text>Maori</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;arn&apos;"><xsl:text>Mapuche</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;arn&apos;"><xsl:text>Mapudungun</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mr&apos;"><xsl:text>Marathi</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;chm&apos;"><xsl:text>Mari</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mh&apos;"><xsl:text>Marshallese</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mwr&apos;"><xsl:text>Marwari</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mas&apos;"><xsl:text>Masai</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;myn&apos;"><xsl:text>Mayan languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;men&apos;"><xsl:text>Mende</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mic&apos;"><xsl:text>Mi&apos;kmaq</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mic&apos;"><xsl:text>Micmac</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;min&apos;"><xsl:text>Minangkabau</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mwl&apos;"><xsl:text>Mirandese</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;moh&apos;"><xsl:text>Mohawk</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mdf&apos;"><xsl:text>Moksha</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ro&apos;"><xsl:text>Moldavian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ro&apos;"><xsl:text>Moldovan</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mkh&apos;"><xsl:text>Mon-Khmer languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;hmn&apos;"><xsl:text>Mong</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;lol&apos;"><xsl:text>Mongo</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mn&apos;"><xsl:text>Mongolian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mos&apos;"><xsl:text>Mossi</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mul&apos;"><xsl:text>Multiple languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mun&apos;"><xsl:text>Munda languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nqo&apos;"><xsl:text>N&apos;Ko</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nah&apos;"><xsl:text>Nahuatl languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;na&apos;"><xsl:text>Nauru</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nv&apos;"><xsl:text>Navaho</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nv&apos;"><xsl:text>Navajo</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nd&apos;"><xsl:text>Ndebele, North</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nr&apos;"><xsl:text>Ndebele, South</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ng&apos;"><xsl:text>Ndonga</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nap&apos;"><xsl:text>Neapolitan</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;new&apos;"><xsl:text>Nepal Bhasa</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ne&apos;"><xsl:text>Nepali</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;new&apos;"><xsl:text>Newari</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nia&apos;"><xsl:text>Nias</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nic&apos;"><xsl:text>Niger-Kordofanian languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ssa&apos;"><xsl:text>Nilo-Saharan languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;niu&apos;"><xsl:text>Niuean</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;zxx&apos;"><xsl:text>No linguistic content</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nog&apos;"><xsl:text>Nogai</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;non&apos;"><xsl:text>Norse, Old</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nai&apos;"><xsl:text>North American Indian languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nd&apos;"><xsl:text>North Ndebele</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;frr&apos;"><xsl:text>Northern Frisian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;se&apos;"><xsl:text>Northern Sami</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nso&apos;"><xsl:text>Northern Sotho</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;no&apos;"><xsl:text>Norwegian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nob&apos;"><xsl:text>Norwegian Bokm&#x00E5;l</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nn&apos;"><xsl:text>Norwegian Nynorsk</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;zxx&apos;"><xsl:text>Not applicable</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nub&apos;"><xsl:text>Nubian languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ii&apos;"><xsl:text>Nuosu</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nym&apos;"><xsl:text>Nyamwezi</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ny&apos;"><xsl:text>Nyanja</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nyn&apos;"><xsl:text>Nyankole</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nn&apos;"><xsl:text>Nynorsk, Norwegian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nyo&apos;"><xsl:text>Nyoro</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nzi&apos;"><xsl:text>Nzima</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ie&apos;"><xsl:text>Occidental</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;oc&apos;"><xsl:text>Occitan (post 1500)</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;pro&apos;"><xsl:text>Occitan, Old (to 1500)</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;arc&apos;"><xsl:text>Official Aramaic (700-300 BCE)</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;xal&apos;"><xsl:text>Oirat</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;oj&apos;"><xsl:text>Ojibwa</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;cu&apos;"><xsl:text>Old Bulgarian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;cu&apos;"><xsl:text>Old Church Slavonic</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nwc&apos;"><xsl:text>Old Newari</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;cu&apos;"><xsl:text>Old Slavonic</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;or&apos;"><xsl:text>Oriya</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;om&apos;"><xsl:text>Oromo</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;osa&apos;"><xsl:text>Osage</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;os&apos;"><xsl:text>Ossetian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;os&apos;"><xsl:text>Ossetic</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;oto&apos;"><xsl:text>Otomian languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;pal&apos;"><xsl:text>Pahlavi</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;pau&apos;"><xsl:text>Palauan</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;pi&apos;"><xsl:text>Pali</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;pam&apos;"><xsl:text>Pampanga</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;pag&apos;"><xsl:text>Pangasinan</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;pa&apos;"><xsl:text>Panjabi</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;pap&apos;"><xsl:text>Papiamento</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;paa&apos;"><xsl:text>Papuan languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ps&apos;"><xsl:text>Pashto</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nso&apos;"><xsl:text>Pedi</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;fa&apos;"><xsl:text>Persian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;peo&apos;"><xsl:text>Persian, Old (ca.600-400 B.C.)</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;phi&apos;"><xsl:text>Philippine languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;phn&apos;"><xsl:text>Phoenician</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;fil&apos;"><xsl:text>Pilipino</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;pon&apos;"><xsl:text>Pohnpeian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;pl&apos;"><xsl:text>Polish</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;pt&apos;"><xsl:text>Portuguese</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;pra&apos;"><xsl:text>Prakrit languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;pro&apos;"><xsl:text>Proven&#x00E7;al, Old (to 1500)</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;pa&apos;"><xsl:text>Punjabi</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ps&apos;"><xsl:text>Pushto</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;qu&apos;"><xsl:text>Quechua</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;raj&apos;"><xsl:text>Rajasthani</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;rap&apos;"><xsl:text>Rapanui</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;rar&apos;"><xsl:text>Rarotongan</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;qaa-qtz&apos;"><xsl:text>Reserved for local use</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;roa&apos;"><xsl:text>Romance languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ro&apos;"><xsl:text>Romanian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;rm&apos;"><xsl:text>Romansh</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;rom&apos;"><xsl:text>Romany</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;rn&apos;"><xsl:text>Rundi</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ru&apos;"><xsl:text>Russian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;kho&apos;"><xsl:text>Sakan</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sal&apos;"><xsl:text>Salishan languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sam&apos;"><xsl:text>Samaritan Aramaic</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;smi&apos;"><xsl:text>Sami languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sm&apos;"><xsl:text>Samoan</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sad&apos;"><xsl:text>Sandawe</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sg&apos;"><xsl:text>Sango</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sa&apos;"><xsl:text>Sanskrit</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sat&apos;"><xsl:text>Santali</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sc&apos;"><xsl:text>Sardinian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sas&apos;"><xsl:text>Sasak</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nds&apos;"><xsl:text>Saxon, Low</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sco&apos;"><xsl:text>Scots</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;gd&apos;"><xsl:text>Scottish Gaelic</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sel&apos;"><xsl:text>Selkup</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sem&apos;"><xsl:text>Semitic languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nso&apos;"><xsl:text>Sepedi</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sr&apos;"><xsl:text>Serbian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;srr&apos;"><xsl:text>Serer</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;shn&apos;"><xsl:text>Shan</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sn&apos;"><xsl:text>Shona</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ii&apos;"><xsl:text>Sichuan Yi</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;scn&apos;"><xsl:text>Sicilian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sid&apos;"><xsl:text>Sidamo</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sgn&apos;"><xsl:text>Sign Languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;bla&apos;"><xsl:text>Siksika</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sd&apos;"><xsl:text>Sindhi</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;si&apos;"><xsl:text>Sinhala</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;si&apos;"><xsl:text>Sinhalese</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sit&apos;"><xsl:text>Sino-Tibetan languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sio&apos;"><xsl:text>Siouan languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sms&apos;"><xsl:text>Skolt Sami</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;den&apos;"><xsl:text>Slave (Athapascan)</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sla&apos;"><xsl:text>Slavic languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sk&apos;"><xsl:text>Slovak</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sl&apos;"><xsl:text>Slovenian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sog&apos;"><xsl:text>Sogdian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;so&apos;"><xsl:text>Somali</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;son&apos;"><xsl:text>Songhai languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;snk&apos;"><xsl:text>Soninke</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;wen&apos;"><xsl:text>Sorbian languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;NA&apos;"><xsl:text>Sotho, Northern</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;st&apos;"><xsl:text>Sotho, Southern</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sai&apos;"><xsl:text>South American Indian languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;nr&apos;"><xsl:text>South Ndebele</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;alt&apos;"><xsl:text>Southern Altai</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sma&apos;"><xsl:text>Southern Sami</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;es&apos;"><xsl:text>Spanish</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;srn&apos;"><xsl:text>Sranan Tongo</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;zgh&apos;"><xsl:text>Standard Moroccan Tamazight</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;suk&apos;"><xsl:text>Sukuma</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sux&apos;"><xsl:text>Sumerian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;su&apos;"><xsl:text>Sundanese</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sus&apos;"><xsl:text>Susu</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sw&apos;"><xsl:text>Swahili</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ss&apos;"><xsl:text>Swati</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sv&apos;"><xsl:text>Swedish</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;gsw&apos;"><xsl:text>Swiss German</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;syr&apos;"><xsl:text>Syriac</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;tl&apos;"><xsl:text>Tagalog</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ty&apos;"><xsl:text>Tahitian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;tai&apos;"><xsl:text>Tai languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;tg&apos;"><xsl:text>Tajik</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;tmh&apos;"><xsl:text>Tamashek</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ta&apos;"><xsl:text>Tamil</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;tt&apos;"><xsl:text>Tatar</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;te&apos;"><xsl:text>Telugu</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ter&apos;"><xsl:text>Tereno</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;tet&apos;"><xsl:text>Tetum</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;th&apos;"><xsl:text>Thai</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;bo&apos;"><xsl:text>Tibetan</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;tig&apos;"><xsl:text>Tigre</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ti&apos;"><xsl:text>Tigrinya</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;tem&apos;"><xsl:text>Timne</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;tiv&apos;"><xsl:text>Tiv</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;tlh&apos;"><xsl:text>tlhIngan-Hol</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;tli&apos;"><xsl:text>Tlingit</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;tpi&apos;"><xsl:text>Tok Pisin</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;tkl&apos;"><xsl:text>Tokelau</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;tog&apos;"><xsl:text>Tonga (Nyasa)</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;to&apos;"><xsl:text>Tonga (Tonga Islands)</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;tsi&apos;"><xsl:text>Tsimshian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ts&apos;"><xsl:text>Tsonga</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;tn&apos;"><xsl:text>Tswana</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;tum&apos;"><xsl:text>Tumbuka</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;tup&apos;"><xsl:text>Tupi languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;tr&apos;"><xsl:text>Turkish</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ota&apos;"><xsl:text>Turkish, Ottoman (1500-1928)</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;tk&apos;"><xsl:text>Turkmen</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;tvl&apos;"><xsl:text>Tuvalu</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;tyv&apos;"><xsl:text>Tuvinian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;tw&apos;"><xsl:text>Twi</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;udm&apos;"><xsl:text>Udmurt</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;uga&apos;"><xsl:text>Ugaritic</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ug&apos;"><xsl:text>Uighur</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;uk&apos;"><xsl:text>Ukrainian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;umb&apos;"><xsl:text>Umbundu</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;mis&apos;"><xsl:text>Uncoded languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;und&apos;"><xsl:text>Undetermined</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;hsb&apos;"><xsl:text>Upper Sorbian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ur&apos;"><xsl:text>Urdu</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ug&apos;"><xsl:text>Uyghur</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;uz&apos;"><xsl:text>Uzbek</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;vai&apos;"><xsl:text>Vai</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ca&apos;"><xsl:text>Valencian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ve&apos;"><xsl:text>Venda</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;vi&apos;"><xsl:text>Vietnamese</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;vo&apos;"><xsl:text>Volap&#x00FC;k</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;vot&apos;"><xsl:text>Votic</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;wak&apos;"><xsl:text>Wakashan languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;wa&apos;"><xsl:text>Walloon</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;war&apos;"><xsl:text>Waray</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;was&apos;"><xsl:text>Washo</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;cy&apos;"><xsl:text>Welsh</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;fy&apos;"><xsl:text>Western Frisian</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;him&apos;"><xsl:text>Western Pahari languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;wal&apos;"><xsl:text>Wolaitta</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;wal&apos;"><xsl:text>Wolaytta</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;wo&apos;"><xsl:text>Wolof</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;xh&apos;"><xsl:text>Xhosa</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;sah&apos;"><xsl:text>Yakut</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;yao&apos;"><xsl:text>Yao</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;yap&apos;"><xsl:text>Yapese</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;yi&apos;"><xsl:text>Yiddish</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;yo&apos;"><xsl:text>Yoruba</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;ypk&apos;"><xsl:text>Yupik languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;znd&apos;"><xsl:text>Zande languages</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;zap&apos;"><xsl:text>Zapotec</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;zza&apos;"><xsl:text>Zaza</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;zza&apos;"><xsl:text>Zazaki</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;zen&apos;"><xsl:text>Zenaga</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;za&apos;"><xsl:text>Zhuang</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;zu&apos;"><xsl:text>Zulu</xsl:text></xsl:when>
			<xsl:when test="n1:languageCode/@code  = &apos;zun&apos;"><xsl:text>Zuni</xsl:text></xsl:when>
		</xsl:choose>	
        </td>
      </tbody>
    </table>
  </xsl:template>
   <!-- author -->
   <xsl:template name="author">
      <xsl:if test="n1:author">
         <table class="header_table">
            <tbody>
               <xsl:for-each select="n1:author/n1:assignedAuthor">
                  <tr>
                     <td width="20%" bgcolor="#3399ff">
                        <span class="td_label">
                           <xsl:text>Author</xsl:text>
                        </span>
                     </td>
                     <td width="80%">
                        <xsl:choose>
                           <xsl:when test="n1:assignedPerson/n1:name">
                              <xsl:call-template name="show-name">
                                 <xsl:with-param name="name" select="n1:assignedPerson/n1:name"/>
                              </xsl:call-template>
                              <xsl:if test="n1:representedOrganization">
                                 <xsl:text>, </xsl:text>
                                 <xsl:call-template name="show-name">
                                    <xsl:with-param name="name" select="n1:representedOrganization/n1:name"/>
                                 </xsl:call-template>
                              </xsl:if>
                           </xsl:when>
                           <xsl:when test="n1:assignedAuthoringDevice/n1:softwareName">
                              <xsl:value-of select="n1:assignedAuthoringDevice/n1:softwareName"/>
                           </xsl:when>
                           <xsl:when test="n1:representedOrganization">
                              <xsl:call-template name="show-name">
                                 <xsl:with-param name="name" select="n1:representedOrganization/n1:name"/>
                              </xsl:call-template>
                           </xsl:when>
                           <xsl:otherwise>
                              <xsl:for-each select="n1:id">
                                 <xsl:call-template name="show-id"/>
                                 <br/>
                              </xsl:for-each>
                           </xsl:otherwise>
                        </xsl:choose>
                     </td>
                  </tr>
                  <xsl:if test="n1:addr | n1:telecom">
                     <tr>
                        <td bgcolor="#3399ff">
                           <span class="td_label">
                              <xsl:text>Contact info</xsl:text>
                           </span>
                        </td>
                        <td>
                           <xsl:call-template name="show-contactInfo">
                              <xsl:with-param name="contact" select="."/>
                           </xsl:call-template>
                        </td>
                     </tr>
                  </xsl:if>
               </xsl:for-each>
            </tbody>
         </table>
      </xsl:if>
   </xsl:template>
   <!--  authenticator -->
   <xsl:template name="authenticator">
      <xsl:if test="n1:authenticator">
         <table class="header_table">
            <tbody>
               <tr>
                  <xsl:for-each select="n1:authenticator">
                     <tr>
                        <td width="20%" bgcolor="#3399ff">
                           <span class="td_label">
                              <xsl:text>Signed </xsl:text>
                           </span>
                        </td>
                        <td width="80%">
                           <xsl:call-template name="show-name">
                              <xsl:with-param name="name" select="n1:assignedEntity/n1:assignedPerson/n1:name"/>
                           </xsl:call-template>
                           <xsl:text> at </xsl:text>
                           <xsl:call-template name="show-time">
                              <xsl:with-param name="date" select="n1:time"/>
                           </xsl:call-template>
                        </td>
                     </tr>
                     <xsl:if test="n1:assignedEntity/n1:addr | n1:assignedEntity/n1:telecom">
                        <tr>
                           <td bgcolor="#3399ff">
                              <span class="td_label">
                                 <xsl:text>Contact info</xsl:text>
                              </span>
                           </td>
                           <td width="80%">
                              <xsl:call-template name="show-contactInfo">
                                 <xsl:with-param name="contact" select="n1:assignedEntity"/>
                              </xsl:call-template>
                           </td>
                        </tr>
                     </xsl:if>
                  </xsl:for-each>
               </tr>
            </tbody>
         </table>
      </xsl:if>
   </xsl:template>
   <!-- legalAuthenticator -->
   <xsl:template name="legalAuthenticator">
      <xsl:if test="n1:legalAuthenticator">
         <table class="header_table">
            <tbody>
               <tr>
                  <td width="20%" bgcolor="#3399ff">
                     <span class="td_label">
                        <xsl:text>Legal authenticator</xsl:text>
                     </span>
                  </td>
                  <td width="80%">
                     <xsl:call-template name="show-assignedEntity">
                        <xsl:with-param name="asgnEntity" select="n1:legalAuthenticator/n1:assignedEntity"/>
                     </xsl:call-template>
                     <xsl:text> </xsl:text>
                     <xsl:call-template name="show-sig">
                        <xsl:with-param name="sig" select="n1:legalAuthenticator/n1:signatureCode"/>
                     </xsl:call-template>
                     <xsl:if test="n1:legalAuthenticator/n1:time/@value">
                        <xsl:text> at </xsl:text>
                        <xsl:call-template name="show-time">
                           <xsl:with-param name="datetime" select="n1:legalAuthenticator/n1:time"/>
                        </xsl:call-template>
                     </xsl:if>
                  </td>
               </tr>
               <xsl:if test="n1:legalAuthenticator/n1:assignedEntity/n1:addr | n1:legalAuthenticator/n1:assignedEntity/n1:telecom">
                  <tr>
                     <td bgcolor="#3399ff">
                        <span class="td_label">
                           <xsl:text>Contact info</xsl:text>
                        </span>
                     </td>
                     <td>
                        <xsl:call-template name="show-contactInfo">
                           <xsl:with-param name="contact" select="n1:legalAuthenticator/n1:assignedEntity"/>
                        </xsl:call-template>
                     </td>
                  </tr>
               </xsl:if>
            </tbody>
         </table>
      </xsl:if>
   </xsl:template>
   <!-- dataEnterer -->
   <xsl:template name="dataEnterer">
      <xsl:if test="n1:dataEnterer">
         <table class="header_table">
            <tbody>
               <tr>
                  <td width="20%" bgcolor="#3399ff">
                     <span class="td_label">
                        <xsl:text>Entered by</xsl:text>
                     </span>
                  </td>
                  <td width="80%">
                     <xsl:call-template name="show-assignedEntity">
                        <xsl:with-param name="asgnEntity" select="n1:dataEnterer/n1:assignedEntity"/>
                     </xsl:call-template>
                  </td>
               </tr>
               <xsl:if test="n1:dataEnterer/n1:assignedEntity/n1:addr | n1:dataEnterer/n1:assignedEntity/n1:telecom">
                  <tr>
                     <td bgcolor="#3399ff">
                        <span class="td_label">
                           <xsl:text>Contact info</xsl:text>
                        </span>
                     </td>
                     <td>
                        <xsl:call-template name="show-contactInfo">
                           <xsl:with-param name="contact" select="n1:dataEnterer/n1:assignedEntity"/>
                        </xsl:call-template>
                     </td>
                  </tr>
               </xsl:if>
            </tbody>
         </table>
      </xsl:if>
   </xsl:template>
   <!-- componentOf -->
   <xsl:template name="componentof">
      <xsl:if test="n1:componentOf">
         <table class="header_table">
            <tbody>
               <xsl:for-each select="n1:componentOf/n1:encompassingEncounter">
                  <xsl:if test="n1:id">
                     <tr>
                        <xsl:choose>
                           <xsl:when test="n1:code">
                              <td width="20%" bgcolor="#3399ff">
                                 <span class="td_label">
                                    <xsl:text>Encounter Id</xsl:text>
                                 </span>
                              </td>
                              <td width="30%">
                                 <xsl:call-template name="show-id">
                                    <xsl:with-param name="id" select="n1:id"/>
                                 </xsl:call-template>
                              </td>
                              <td width="15%" bgcolor="#3399ff">
                                 <span class="td_label">
                                    <xsl:text>Encounter Type</xsl:text>
                                 </span>
                              </td>
                              <td>
                                 <xsl:call-template name="show-code">
                                    <xsl:with-param name="code" select="n1:code"/>
                                 </xsl:call-template>
                              </td>
                           </xsl:when>
                           <xsl:otherwise>
                              <td width="20%" bgcolor="#3399ff">
                                 <span class="td_label">
                                    <xsl:text>Encounter Id</xsl:text>
                                 </span>
                              </td>
                              <td>
                                 <xsl:call-template name="show-id">
                                    <xsl:with-param name="id" select="n1:id"/>
                                 </xsl:call-template>
                              </td>
                           </xsl:otherwise>
                        </xsl:choose>
                     </tr>
                  </xsl:if>
                  <tr>
                     <td width="20%" bgcolor="#3399ff">
                        <span class="td_label">
                           <xsl:text>Encounter Date</xsl:text>
                        </span>
                     </td>
                     <td colspan="3">
                        <xsl:if test="n1:effectiveTime">
                           <xsl:choose>
                              <xsl:when test="n1:effectiveTime/@value">
                                 <xsl:text>&#160;at&#160;</xsl:text>
                                 <xsl:call-template name="show-time">
                                    <xsl:with-param name="datetime" select="n1:effectiveTime"/>
                                 </xsl:call-template>
                              </xsl:when>
                              <xsl:when test="n1:effectiveTime/n1:low">
                                 <xsl:text>&#160;From&#160;</xsl:text>
                                 <xsl:call-template name="show-time">
                                    <xsl:with-param name="datetime" select="n1:effectiveTime/n1:low"/>
                                 </xsl:call-template>
                                 <xsl:if test="n1:effectiveTime/n1:high">
                                    <xsl:text> to </xsl:text>
                                    <xsl:call-template name="show-time">
                                       <xsl:with-param name="datetime" select="n1:effectiveTime/n1:high"/>
                                    </xsl:call-template>
                                 </xsl:if>
                              </xsl:when>
                           </xsl:choose>
                        </xsl:if>
                     </td>
                  </tr>
                  <xsl:if test="n1:location/n1:healthCareFacility">
                     <tr>
                        <td width="20%" bgcolor="#3399ff">
                           <span class="td_label">
                              <xsl:text>Encounter Location</xsl:text>
                           </span>
                        </td>
                        <td colspan="3">
                           <xsl:choose>
                              <xsl:when test="n1:location/n1:healthCareFacility/n1:location/n1:name">
                                 <xsl:call-template name="show-name">
                                    <xsl:with-param name="name" select="n1:location/n1:healthCareFacility/n1:location/n1:name"/>
                                 </xsl:call-template>
                                 <xsl:for-each select="n1:location/n1:healthCareFacility/n1:serviceProviderOrganization/n1:name">
                                    <xsl:text> of </xsl:text>
                                    <xsl:call-template name="show-name">
                                       <xsl:with-param name="name" select="n1:location/n1:healthCareFacility/n1:serviceProviderOrganization/n1:name"/>
                                    </xsl:call-template>
                                 </xsl:for-each>
                              </xsl:when>
                              <xsl:when test="n1:location/n1:healthCareFacility/n1:code">
                                 <xsl:call-template name="show-code">
                                    <xsl:with-param name="code" select="n1:location/n1:healthCareFacility/n1:code"/>
                                 </xsl:call-template>
                              </xsl:when>
                              <xsl:otherwise>
                                 <xsl:if test="n1:location/n1:healthCareFacility/n1:id">
                                    <xsl:text>id: </xsl:text>
                                    <xsl:for-each select="n1:location/n1:healthCareFacility/n1:id">
                                       <xsl:call-template name="show-id">
                                          <xsl:with-param name="id" select="."/>
                                       </xsl:call-template>
                                    </xsl:for-each>
                                 </xsl:if>
                              </xsl:otherwise>
                           </xsl:choose>
                        </td>
                     </tr>
                  </xsl:if>
                  <xsl:if test="n1:responsibleParty">
                     <tr>
                        <td width="20%" bgcolor="#3399ff">
                           <span class="td_label">
                              <xsl:text>Responsible party</xsl:text>
                           </span>
                        </td>
                        <td colspan="3">
                           <xsl:call-template name="show-assignedEntity">
                              <xsl:with-param name="asgnEntity" select="n1:responsibleParty/n1:assignedEntity"/>
                           </xsl:call-template>
                        </td>
                     </tr>
                  </xsl:if>
                  <xsl:if test="n1:responsibleParty/n1:assignedEntity/n1:addr | n1:responsibleParty/n1:assignedEntity/n1:telecom">
                     <tr>
                        <td width="20%" bgcolor="#3399ff">
                           <span class="td_label">
                              <xsl:text>Contact info</xsl:text>
                           </span>
                        </td>
                        <td colspan="3">
                           <xsl:call-template name="show-contactInfo">
                              <xsl:with-param name="contact" select="n1:responsibleParty/n1:assignedEntity"/>
                           </xsl:call-template>
                        </td>
                     </tr>
                  </xsl:if>
               </xsl:for-each>
            </tbody>
         </table>
      </xsl:if>
   </xsl:template>
   <!-- custodian -->
   <xsl:template name="custodian">
      <xsl:if test="n1:custodian">
         <table class="header_table">
            <tbody>
               <tr>
                  <td width="20%" bgcolor="#3399ff">
                     <span class="td_label">
                        <xsl:text>Document maintained by</xsl:text>
                     </span>
                  </td>
                  <td width="80%">
                     <xsl:choose>
                        <xsl:when test="n1:custodian/n1:assignedCustodian/n1:representedCustodianOrganization/n1:name">
                           <xsl:call-template name="show-name">
                              <xsl:with-param name="name" select="n1:custodian/n1:assignedCustodian/n1:representedCustodianOrganization/n1:name"/>
                           </xsl:call-template>
                        </xsl:when>
                        <xsl:otherwise>
                           <xsl:for-each select="n1:custodian/n1:assignedCustodian/n1:representedCustodianOrganization/n1:id">
                              <xsl:call-template name="show-id"/>
                              <xsl:if test="position()!=last()">
                                 <br/>
                              </xsl:if>
                           </xsl:for-each>
                        </xsl:otherwise>
                     </xsl:choose>
                  </td>
               </tr>
               <xsl:if test="n1:custodian/n1:assignedCustodian/n1:representedCustodianOrganization/n1:addr |             n1:custodian/n1:assignedCustodian/n1:representedCustodianOrganization/n1:telecom">
                  <tr>
                     <td bgcolor="#3399ff">
                        <span class="td_label">
                           <xsl:text>Contact info</xsl:text>
                        </span>
                     </td>
                     <td width="80%">
                        <xsl:call-template name="show-contactInfo">
                           <xsl:with-param name="contact" select="n1:custodian/n1:assignedCustodian/n1:representedCustodianOrganization"/>
                        </xsl:call-template>
                     </td>
                  </tr>
               </xsl:if>
            </tbody>
         </table>
      </xsl:if>
   </xsl:template>
   <!-- documentationOf -->
   <xsl:template name="documentationOf">
      <xsl:if test="n1:documentationOf">
         <table class="header_table">
            <tbody>
               <xsl:for-each select="n1:documentationOf">
                  <xsl:if test="n1:serviceEvent/@classCode and n1:serviceEvent/n1:code">
                     <xsl:variable name="displayName">
                        <xsl:call-template name="show-actClassCode">
                           <xsl:with-param name="clsCode" select="n1:serviceEvent/@classCode"/>
                        </xsl:call-template>
                     </xsl:variable>
                     <xsl:if test="$displayName">
                        <tr>
                           <td width="20%" bgcolor="#3399ff">
                              <span class="td_label">
                                 <xsl:call-template name="firstCharCaseUp">
                                    <xsl:with-param name="data" select="$displayName"/>
                                 </xsl:call-template>
                              </span>
                           </td>
                           <td width="80%" colspan="3">
                              <xsl:call-template name="show-code">
                                 <xsl:with-param name="code" select="n1:serviceEvent/n1:code"/>
                              </xsl:call-template>
                              <xsl:if test="n1:serviceEvent/n1:effectiveTime">
                                 <xsl:choose>
                                    <xsl:when test="n1:serviceEvent/n1:effectiveTime/@value">
                                       <xsl:text>&#160;at&#160;</xsl:text>
                                       <xsl:call-template name="show-time">
                                          <xsl:with-param name="datetime" select="n1:serviceEvent/n1:effectiveTime"/>
                                       </xsl:call-template>
                                    </xsl:when>
                                    <xsl:when test="n1:serviceEvent/n1:effectiveTime/n1:low">
                                       <xsl:text>&#160;from&#160;</xsl:text>
                                       <xsl:call-template name="show-time">
                                          <xsl:with-param name="datetime" select="n1:serviceEvent/n1:effectiveTime/n1:low"/>
                                       </xsl:call-template>
                                       <xsl:if test="n1:serviceEvent/n1:effectiveTime/n1:high">
                                          <xsl:text> to </xsl:text>
                                          <xsl:call-template name="show-time">
                                             <xsl:with-param name="datetime" select="n1:serviceEvent/n1:effectiveTime/n1:high"/>
                                          </xsl:call-template>
                                       </xsl:if>
                                    </xsl:when>
                                 </xsl:choose>
                              </xsl:if>
                           </td>
                        </tr>
                     </xsl:if>
                  </xsl:if>
                  <xsl:for-each select="n1:serviceEvent/n1:performer">
                     <xsl:variable name="displayName">
                        <xsl:call-template name="show-participationType">
                           <xsl:with-param name="ptype" select="@typeCode"/>
                        </xsl:call-template>
                        <xsl:text> </xsl:text>
                        <xsl:if test="n1:functionCode/@code">
                           <xsl:call-template name="show-participationFunction">
                              <xsl:with-param name="pFunction" select="n1:functionCode/@code"/>
                           </xsl:call-template>
                        </xsl:if>
                     </xsl:variable>
                     <tr>
                        <td width="20%" bgcolor="#3399ff">
                           <span class="td_label">
                              <xsl:call-template name="firstCharCaseUp">
                                 <xsl:with-param name="data" select="$displayName"/>
                              </xsl:call-template>
                           </span>
                        </td>
                        <td width="80%" colspan="3">
                           <xsl:call-template name="show-assignedEntity">
                              <xsl:with-param name="asgnEntity" select="n1:assignedEntity"/>
                           </xsl:call-template>
                        </td>
                     </tr>
                  </xsl:for-each>
               </xsl:for-each>
            </tbody>
         </table>
      </xsl:if>
   </xsl:template>
   <!-- inFulfillmentOf -->
   <xsl:template name="inFulfillmentOf">
      <xsl:if test="n1:infulfillmentOf">
         <table class="header_table">
            <tbody>
               <xsl:for-each select="n1:inFulfillmentOf">
                  <tr>
                     <td width="20%" bgcolor="#3399ff">
                        <span class="td_label">
                           <xsl:text>In fulfillment of</xsl:text>
                        </span>
                     </td>
                     <td width="80%">
                        <xsl:for-each select="n1:order">
                           <xsl:for-each select="n1:id">
                              <xsl:call-template name="show-id"/>
                           </xsl:for-each>
                           <xsl:for-each select="n1:code">
                              <xsl:text>&#160;</xsl:text>
                              <xsl:call-template name="show-code">
                                 <xsl:with-param name="code" select="."/>
                              </xsl:call-template>
                           </xsl:for-each>
                           <xsl:for-each select="n1:priorityCode">
                              <xsl:text>&#160;</xsl:text>
                              <xsl:call-template name="show-code">
                                 <xsl:with-param name="code" select="."/>
                              </xsl:call-template>
                           </xsl:for-each>
                        </xsl:for-each>
                     </td>
                  </tr>
               </xsl:for-each>
            </tbody>
         </table>
      </xsl:if>
   </xsl:template>
   <!-- informant -->
   <xsl:template name="informant">
      <xsl:if test="n1:informant">
         <table class="header_table">
            <tbody>
               <xsl:for-each select="n1:informant">
                  <tr>
                     <td width="20%" bgcolor="#3399ff">
                        <span class="td_label">
                           <xsl:text>Informant</xsl:text>
                        </span>
                     </td>
                     <td width="80%">
                        <xsl:if test="n1:assignedEntity">
                           <xsl:call-template name="show-assignedEntity">
                              <xsl:with-param name="asgnEntity" select="n1:assignedEntity"/>
                           </xsl:call-template>
                        </xsl:if>
                        <xsl:if test="n1:relatedEntity">
                           <xsl:call-template name="show-relatedEntity">
                              <xsl:with-param name="relatedEntity" select="n1:relatedEntity"/>
                           </xsl:call-template>
                        </xsl:if>
                     </td>
                  </tr>
                  <xsl:choose>
                     <xsl:when test="n1:assignedEntity/n1:addr | n1:assignedEntity/n1:telecom">
                        <tr>
                           <td bgcolor="#3399ff">
                              <span class="td_label">
                                 <xsl:text>Contact info</xsl:text>
                              </span>
                           </td>
                           <td>
                              <xsl:if test="n1:assignedEntity">
                                 <xsl:call-template name="show-contactInfo">
                                    <xsl:with-param name="contact" select="n1:assignedEntity"/>
                                 </xsl:call-template>
                              </xsl:if>
                           </td>
                        </tr>
                     </xsl:when>
                     <xsl:when test="n1:relatedEntity/n1:addr | n1:relatedEntity/n1:telecom">
                        <tr>
                           <td bgcolor="#3399ff">
                              <span class="td_label">
                                 <xsl:text>Contact info</xsl:text>
                              </span>
                           </td>
                           <td>
                              <xsl:if test="n1:relatedEntity">
                                 <xsl:call-template name="show-contactInfo">
                                    <xsl:with-param name="contact" select="n1:relatedEntity"/>
                                 </xsl:call-template>
                              </xsl:if>
                           </td>
                        </tr>
                     </xsl:when>
                  </xsl:choose>
               </xsl:for-each>
            </tbody>
         </table>
      </xsl:if>
   </xsl:template>
   <!-- informantionRecipient -->
   <xsl:template name="informationRecipient">
      <xsl:if test="n1:informationRecipient">
         <table class="header_table">
            <tbody>
               <xsl:for-each select="n1:informationRecipient">
                  <tr>
                     <td width="20%" bgcolor="#3399ff">
                        <span class="td_label">
                           <xsl:text>Information recipient:</xsl:text>
                        </span>
                     </td>
                     <td width="80%">
                        <xsl:choose>
                           <xsl:when test="n1:intendedRecipient/n1:informationRecipient/n1:name">
                              <xsl:for-each select="n1:intendedRecipient/n1:informationRecipient">
                                 <xsl:call-template name="show-name">
                                    <xsl:with-param name="name" select="n1:name"/>
                                 </xsl:call-template>
                                 <xsl:if test="position() != last()">
                                    <br/>
                                 </xsl:if>
                              </xsl:for-each>
                           </xsl:when>
                           <xsl:otherwise>
                              <xsl:for-each select="n1:intendedRecipient">
                                 <xsl:for-each select="n1:id">
                                    <xsl:call-template name="show-id"/>
                                 </xsl:for-each>
                                 <xsl:if test="position() != last()">
                                    <br/>
                                 </xsl:if>
                                 <br/>
                              </xsl:for-each>
                           </xsl:otherwise>
                        </xsl:choose>
                     </td>
                  </tr>
                  <xsl:if test="n1:intendedRecipient/n1:addr | n1:intendedRecipient/n1:telecom">
                     <tr>
                        <td bgcolor="#3399ff">
                           <span class="td_label">
                              <xsl:text>Contact info</xsl:text>
                           </span>
                        </td>
                        <td>
                           <xsl:call-template name="show-contactInfo">
                              <xsl:with-param name="contact" select="n1:intendedRecipient"/>
                           </xsl:call-template>
                        </td>
                     </tr>
                  </xsl:if>
               </xsl:for-each>
            </tbody>
         </table>
      </xsl:if>
   </xsl:template>
   <!-- participant -->
   <xsl:template name="participant">
      <xsl:if test="n1:participant">
         <table class="header_table">
            <tbody>
               <xsl:for-each select="n1:participant">
                  <tr>
                     <td width="20%" bgcolor="#3399ff">
                        <xsl:variable name="participtRole">
                           <xsl:call-template name="translateRoleAssoCode">
                              <xsl:with-param name="classCode" select="n1:associatedEntity/@classCode"/>
                              <xsl:with-param name="code" select="n1:associatedEntity/n1:code"/>
                           </xsl:call-template>
                        </xsl:variable>
                        <xsl:choose>
                           <xsl:when test="$participtRole">
                              <span class="td_label">
                                 <xsl:call-template name="firstCharCaseUp">
                                    <xsl:with-param name="data" select="$participtRole"/>
                                 </xsl:call-template>
                              </span>
                           </xsl:when>
                           <xsl:otherwise>
                              <span class="td_label">
                                 <xsl:text>Participant</xsl:text>
                              </span>
                           </xsl:otherwise>
                        </xsl:choose>
                     </td>
                     <td width="80%">
                        <xsl:if test="n1:functionCode">
                           <xsl:call-template name="show-code">
                              <xsl:with-param name="code" select="n1:functionCode"/>
                           </xsl:call-template>
                        </xsl:if>
                        <xsl:call-template name="show-associatedEntity">
                           <xsl:with-param name="assoEntity" select="n1:associatedEntity"/>
                        </xsl:call-template>
                        <xsl:if test="n1:time">
                           <xsl:if test="n1:time/n1:low">
                              <xsl:text> from </xsl:text>
                              <xsl:call-template name="show-time">
                                 <xsl:with-param name="datetime" select="n1:time/n1:low"/>
                              </xsl:call-template>
                           </xsl:if>
                           <xsl:if test="n1:time/n1:high">
                              <xsl:text> to </xsl:text>
                              <xsl:call-template name="show-time">
                                 <xsl:with-param name="datetime" select="n1:time/n1:high"/>
                              </xsl:call-template>
                           </xsl:if>
                        </xsl:if>
                        <xsl:if test="position() != last()">
                           <br/>
                        </xsl:if>
                     </td>
                  </tr>
                  <xsl:if test="n1:associatedEntity/n1:addr | n1:associatedEntity/n1:telecom">
                     <tr>
                        <td bgcolor="#3399ff">
                           <span class="td_label">
                              <xsl:text>Contact info</xsl:text>
                           </span>
                        </td>
                        <td>
                           <xsl:call-template name="show-contactInfo">
                              <xsl:with-param name="contact" select="n1:associatedEntity"/>
                           </xsl:call-template>
                        </td>
                     </tr>
                  </xsl:if>
               </xsl:for-each>
            </tbody>
         </table>
      </xsl:if>
   </xsl:template>
   <!-- recordTarget -->
   <xsl:template name="recordTarget">
      <table class="header_table">
         <tbody>
            <xsl:for-each select="/n1:ClinicalDocument/n1:recordTarget/n1:patientRole">
               <xsl:if test="not(n1:id/@nullFlavor)">
                  <tr>
                     <td width="20%" bgcolor="#3399ff">
                        <span class="td_label">
                           <xsl:text>Patient</xsl:text>
                        </span>
                     </td>
                     <td colspan="3">
                        <xsl:call-template name="show-name">
                           <xsl:with-param name="name" select="n1:patient/n1:name"/>
                        </xsl:call-template>
                     </td>
                  </tr>
                  <tr>
                     <td width="20%" bgcolor="#3399ff">
                        <span class="td_label">
                           <xsl:text>Date of birth</xsl:text>
                        </span>
                     </td>
                     <td width="30%">
                        <xsl:call-template name="show-time">
                           <xsl:with-param name="datetime" select="n1:patient/n1:birthTime"/>
                        </xsl:call-template>
                     </td>
                     <td width="15%" bgcolor="#3399ff">
                        <span class="td_label">
                           <xsl:text>Sex</xsl:text>
                        </span>
                     </td>
                     <td>
                        <xsl:for-each select="n1:patient/n1:administrativeGenderCode">
                           <xsl:call-template name="show-gender"/>
                        </xsl:for-each>
                     </td>
                  </tr>
                  <xsl:if test="n1:patient/n1:raceCode | (n1:patient/n1:ethnicGroupCode)">
                     <tr>
                        <td width="20%" bgcolor="#3399ff">
                           <span class="td_label">
                              <xsl:text>Race</xsl:text>
                           </span>
                        </td>
                        <td width="30%">
                           <xsl:choose>
                              <xsl:when test="n1:patient/n1:raceCode">
                                 <xsl:for-each select="n1:patient/n1:raceCode">
                                    <xsl:call-template name="show-race-ethnicity"/>
                                 </xsl:for-each>
                              </xsl:when>
                              <xsl:otherwise>
                                 <xsl:text>Information not available</xsl:text>
                              </xsl:otherwise>
                           </xsl:choose>
                        </td>
                        <td width="15%" bgcolor="#3399ff">
                           <span class="td_label">
                              <xsl:text>Ethnicity</xsl:text>
                           </span>
                        </td>
                        <td>
                           <xsl:choose>
                              <xsl:when test="n1:patient/n1:ethnicGroupCode">
                                 <xsl:for-each select="n1:patient/n1:ethnicGroupCode">
                                    <xsl:call-template name="show-race-ethnicity"/>
                                 </xsl:for-each>
                              </xsl:when>
                              <xsl:otherwise>
                                 <xsl:text>Information not available</xsl:text>
                              </xsl:otherwise>
                           </xsl:choose>
                        </td>
                     </tr>
                  </xsl:if>
                  <tr>
                     <td bgcolor="#3399ff">
                        <span class="td_label">
                           <xsl:text>Contact info</xsl:text>
                        </span>
                     </td>
                     <td>
                        <xsl:call-template name="show-contactInfo">
                           <xsl:with-param name="contact" select="."/>
                        </xsl:call-template>
                     </td>
                     <td bgcolor="#3399ff">
                        <span class="td_label">
                           <xsl:text>Patient IDs</xsl:text>
                        </span>
                     </td>
                     <td>
                        <xsl:for-each select="n1:id">
                           <xsl:call-template name="show-id"/>
                           <br/>
                        </xsl:for-each>
                     </td>
                  </tr>
               </xsl:if>
            </xsl:for-each>
         </tbody>
      </table>
   </xsl:template>
   <!-- relatedDocument -->
   <xsl:template name="relatedDocument">
      <xsl:if test="n1:relatedDocument">
         <table class="header_table">
            <tbody>
               <xsl:for-each select="n1:relatedDocument">
                  <tr>
                     <td width="20%" bgcolor="#3399ff">
                        <span class="td_label">
                           <xsl:text>Related document</xsl:text>
                        </span>
                     </td>
                     <td width="80%">
                        <xsl:for-each select="n1:parentDocument">
                           <xsl:for-each select="n1:id">
                              <xsl:call-template name="show-id"/>
                              <br/>
                           </xsl:for-each>
                        </xsl:for-each>
                     </td>
                  </tr>
               </xsl:for-each>
            </tbody>
         </table>
      </xsl:if>
   </xsl:template>
   <!-- authorization (consent) -->
   <xsl:template name="authorization">
      <xsl:if test="n1:authorization">
         <table class="header_table">
            <tbody>
               <xsl:for-each select="n1:authorization">
                  <tr>
                     <td width="20%" bgcolor="#3399ff">
                        <span class="td_label">
                           <xsl:text>Consent</xsl:text>
                        </span>
                     </td>
                     <td width="80%">
                        <xsl:choose>
                           <xsl:when test="n1:consent/n1:code">
                              <xsl:call-template name="show-code">
                                 <xsl:with-param name="code" select="n1:consent/n1:code"/>
                              </xsl:call-template>
                           </xsl:when>
                           <xsl:otherwise>
                              <xsl:call-template name="show-code">
                                 <xsl:with-param name="code" select="n1:consent/n1:statusCode"/>
                              </xsl:call-template>
                           </xsl:otherwise>
                        </xsl:choose>
                        <br/>
                     </td>
                  </tr>
               </xsl:for-each>
            </tbody>
         </table>
      </xsl:if>
   </xsl:template>
   <!-- setAndVersion -->
   <xsl:template name="setAndVersion">
      <xsl:if test="n1:setId and n1:versionNumber">
         <table class="header_table">
            <tbody>
               <tr>
                  <td width="20%">
                     <xsl:text>SetId and Version</xsl:text>
                  </td>
                  <td colspan="3">
                     <xsl:text>SetId: </xsl:text>
                     <xsl:call-template name="show-id">
                        <xsl:with-param name="id" select="n1:setId"/>
                     </xsl:call-template>
                     <xsl:text>  Version: </xsl:text>
                     <xsl:value-of select="n1:versionNumber/@value"/>
                  </td>
               </tr>
            </tbody>
         </table>
      </xsl:if>
   </xsl:template>
   <!-- show StructuredBody  -->
   <xsl:template match="n1:component/n1:structuredBody">
      <xsl:for-each select="n1:component/n1:section">
         <xsl:call-template name="section"/>
      </xsl:for-each>
   </xsl:template>
   <!-- show nonXMLBody -->
   <xsl:template match='n1:component/n1:nonXMLBody'>
      <xsl:choose>
         <!-- if there is a reference, use that in an IFRAME -->
         <xsl:when test='n1:text/n1:reference'>
            <IFRAME name='nonXMLBody' id='nonXMLBody' WIDTH='80%' HEIGHT='600' src='{n1:text/n1:reference/@value}'/>
         </xsl:when>
         <xsl:when test='n1:text/@mediaType="text/plain"'>
            <pre>
               <xsl:value-of select='n1:text/text()'/>
            </pre>
         </xsl:when>
         <xsl:otherwise>
            <CENTER>Cannot display the text</CENTER>
         </xsl:otherwise>
      </xsl:choose>
   </xsl:template>
   <!-- top level component/section: display title and text,
     and process any nested component/sections
   -->
   <xsl:template name="section">
      <xsl:call-template name="section-title">
         <xsl:with-param name="title" select="n1:title"/>
      </xsl:call-template>
      <xsl:call-template name="section-author"/>
      <xsl:call-template name="section-text"/>
      <xsl:for-each select="n1:component/n1:section">
         <xsl:call-template name="nestedSection">
            <xsl:with-param name="margin" select="2"/>
         </xsl:call-template>
      </xsl:for-each>
   </xsl:template>
   <!-- top level section title -->
   <xsl:template name="section-title">
      <xsl:param name="title"/>
      <xsl:choose>
         <xsl:when test="count(/n1:ClinicalDocument/n1:component/n1:structuredBody/n1:component[n1:section]) &gt; 1">
            <h3>
               <a name="{generate-id($title)}" href="#toc">
                  <xsl:value-of select="$title"/>
               </a>
            </h3>
         </xsl:when>
         <xsl:otherwise>
            <h3>
               <xsl:value-of select="$title"/>
            </h3>
         </xsl:otherwise>
      </xsl:choose>
   </xsl:template>
   <!-- section author -->
   <xsl:template name="section-author">
      <xsl:if test="count(n1:author)&gt;0">
         <div style="margin-left : 2em;">
            <b>
               <xsl:text>Section Author: </xsl:text>
            </b>
            <xsl:for-each select="n1:author/n1:assignedAuthor">
               <xsl:choose>
                  <xsl:when test="n1:assignedPerson/n1:name">
                     <xsl:call-template name="show-name">
                        <xsl:with-param name="name" select="n1:assignedPerson/n1:name"/>
                     </xsl:call-template>
                     <xsl:if test="n1:representedOrganization">
                        <xsl:text>, </xsl:text>
                        <xsl:call-template name="show-name">
                           <xsl:with-param name="name" select="n1:representedOrganization/n1:name"/>
                        </xsl:call-template>
                     </xsl:if>
                  </xsl:when>
                  <xsl:when test="n1:assignedAuthoringDevice/n1:softwareName">
                     <xsl:value-of select="n1:assignedAuthoringDevice/n1:softwareName"/>
                  </xsl:when>
                  <xsl:otherwise>
                     <xsl:for-each select="n1:id">
                        <xsl:call-template name="show-id"/>
                        <br/>
                     </xsl:for-each>
                  </xsl:otherwise>
               </xsl:choose>
            </xsl:for-each>
            <br/>
         </div>
      </xsl:if>
   </xsl:template>
   <!-- top-level section Text   -->
   <xsl:template name="section-text">
      <div>
         <xsl:apply-templates select="n1:text"/>
      </div>
   </xsl:template>
   <!-- nested component/section -->
   <xsl:template name="nestedSection">
      <xsl:param name="margin"/>
      <h4 style="margin-left : {$margin}em;">
         <xsl:value-of select="n1:title"/>
      </h4>
      <div style="margin-left : {$margin}em;">
         <xsl:apply-templates select="n1:text"/>
      </div>
      <xsl:for-each select="n1:component/n1:section">
         <xsl:call-template name="nestedSection">
            <xsl:with-param name="margin" select="2*$margin"/>
         </xsl:call-template>
      </xsl:for-each>
   </xsl:template>
   <!--   paragraph  -->
   <xsl:template match="n1:paragraph">
      <p>
         <xsl:apply-templates/>
      </p>
   </xsl:template>
   <!--   pre format  -->
   <xsl:template match="n1:pre">
      <pre>
         <xsl:apply-templates/>
      </pre>
   </xsl:template>
   <!--   Content w/ deleted text is hidden -->
   <xsl:template match="n1:content[@revised='delete']"/>
   <!--   content  -->
   <xsl:template match="n1:content">
      <xsl:apply-templates/>
   </xsl:template>
   <!-- line break -->
   <xsl:template match="n1:br">
      <xsl:element name='br'>
         <xsl:apply-templates/>
      </xsl:element>
   </xsl:template>
   <!--   list  -->
   <xsl:template match="n1:list">
      <xsl:if test="n1:caption">
         <p>
            <b>
               <xsl:apply-templates select="n1:caption"/>
            </b>
         </p>
      </xsl:if>
      <ul>
         <xsl:for-each select="n1:item">
            <li>
               <xsl:apply-templates/>
            </li>
         </xsl:for-each>
      </ul>
   </xsl:template>
   <xsl:template match="n1:list[@listType='ordered']">
      <xsl:if test="n1:caption">
         <span style="font-weight:bold; ">
            <xsl:apply-templates select="n1:caption"/>
         </span>
      </xsl:if>
      <ol>
         <xsl:for-each select="n1:item">
            <li>
               <xsl:apply-templates/>
            </li>
         </xsl:for-each>
      </ol>
   </xsl:template>
   <!--   caption  -->
   <xsl:template match="n1:caption">
      <xsl:apply-templates/>
      <xsl:text>: </xsl:text>
   </xsl:template>
   <!--  Tables   -->
   <xsl:template match="n1:table/@*|n1:thead/@*|n1:tfoot/@*|n1:tbody/@*|n1:colgroup/@*|n1:col/@*|n1:tr/@*|n1:th/@*|n1:td/@*">
      <xsl:copy>
         <xsl:copy-of select="@*"/>
         <xsl:apply-templates/>
      </xsl:copy>
   </xsl:template>
   <xsl:template match="n1:table">
      <table class="narr_table">
         <xsl:copy-of select="@*"/>
         <xsl:apply-templates/>
      </table>
   </xsl:template>
   <xsl:template match="n1:thead">
      <thead>
         <xsl:copy-of select="@*"/>
         <xsl:apply-templates/>
      </thead>
   </xsl:template>
   <xsl:template match="n1:tfoot">
      <tfoot>
         <xsl:copy-of select="@*"/>
         <xsl:apply-templates/>
      </tfoot>
   </xsl:template>
   <xsl:template match="n1:tbody">
      <tbody>
         <xsl:copy-of select="@*"/>
         <xsl:apply-templates/>
      </tbody>
   </xsl:template>
   <xsl:template match="n1:colgroup">
      <colgroup>
         <xsl:copy-of select="@*"/>
         <xsl:apply-templates/>
      </colgroup>
   </xsl:template>
   <xsl:template match="n1:col">
      <col>
         <xsl:copy-of select="@*"/>
         <xsl:apply-templates/>
      </col>
   </xsl:template>
   <xsl:template match="n1:tr">
      <tr class="narr_tr">
         <xsl:copy-of select="@*"/>
         <xsl:apply-templates/>
      </tr>
   </xsl:template>
   <xsl:template match="n1:th">
      <th class="narr_th">
         <xsl:copy-of select="@*"/>
         <xsl:apply-templates/>
      </th>
   </xsl:template>
   <xsl:template match="n1:td">
      <td>
         <xsl:copy-of select="@*"/>
         <xsl:apply-templates/>
      </td>
   </xsl:template>
   <xsl:template match="n1:table/n1:caption">
      <span style="font-weight:bold; ">
         <xsl:apply-templates/>
      </span>
   </xsl:template>
   <!--   RenderMultiMedia 
    this currently only handles GIF's and JPEG's.  It could, however,
    be extended by including other image MIME types in the predicate
    and/or by generating <object> or <applet> tag with the correct
    params depending on the media type  @ID  =$imageRef  referencedObject
    -->
   <xsl:template match="n1:renderMultiMedia">
      <xsl:variable name="imageRef" select="@referencedObject"/>
      <xsl:choose>
         <xsl:when test="//n1:regionOfInterest[@ID=$imageRef]">
            <!-- Here is where the Region of Interest image referencing goes -->
            <xsl:if test="//n1:regionOfInterest[@ID=$imageRef]//n1:observationMedia/n1:value[@mediaType='image/gif' or
 @mediaType='image/jpeg']">
               <br clear="all"/>
               <xsl:element name="img">
                  <xsl:attribute name="src"><xsl:value-of select="//n1:regionOfInterest[@ID=$imageRef]//n1:observationMedia/n1:value/n1:reference/@value"/></xsl:attribute>
               </xsl:element>
            </xsl:if>
         </xsl:when>
         <xsl:otherwise>
            <!-- Here is where the direct MultiMedia image referencing goes -->
            <xsl:if test="//n1:observationMedia[@ID=$imageRef]/n1:value[@mediaType='image/gif' or @mediaType='image/jpeg']">
               <br clear="all"/>
               <xsl:element name="img">
                  <xsl:attribute name="src"><xsl:value-of select="//n1:observationMedia[@ID=$imageRef]/n1:value/n1:reference/@value"/></xsl:attribute>
               </xsl:element>
            </xsl:if>
         </xsl:otherwise>
      </xsl:choose>
   </xsl:template>
   <!--    Stylecode processing   
    Supports Bold, Underline and Italics display
    -->
   <xsl:template match="//n1:*[@styleCode]">
      <xsl:if test="@styleCode='Bold'">
         <xsl:element name="b">
            <xsl:apply-templates/>
         </xsl:element>
      </xsl:if>
      <xsl:if test="@styleCode='Italics'">
         <xsl:element name="i">
            <xsl:apply-templates/>
         </xsl:element>
      </xsl:if>
      <xsl:if test="@styleCode='Underline'">
         <xsl:element name="u">
            <xsl:apply-templates/>
         </xsl:element>
      </xsl:if>
      <xsl:if test="contains(@styleCode,'Bold') and contains(@styleCode,'Italics') and not (contains(@styleCode, 'Underline'))">
         <xsl:element name="b">
            <xsl:element name="i">
               <xsl:apply-templates/>
            </xsl:element>
         </xsl:element>
      </xsl:if>
      <xsl:if test="contains(@styleCode,'Bold') and contains(@styleCode,'Underline') and not (contains(@styleCode, 'Italics'))">
         <xsl:element name="b">
            <xsl:element name="u">
               <xsl:apply-templates/>
            </xsl:element>
         </xsl:element>
      </xsl:if>
      <xsl:if test="contains(@styleCode,'Italics') and contains(@styleCode,'Underline') and not (contains(@styleCode, 'Bold'))">
         <xsl:element name="i">
            <xsl:element name="u">
               <xsl:apply-templates/>
            </xsl:element>
         </xsl:element>
      </xsl:if>
      <xsl:if test="contains(@styleCode,'Italics') and contains(@styleCode,'Underline') and contains(@styleCode, 'Bold')">
         <xsl:element name="b">
            <xsl:element name="i">
               <xsl:element name="u">
                  <xsl:apply-templates/>
               </xsl:element>
            </xsl:element>
         </xsl:element>
      </xsl:if>
      <xsl:if test="not (contains(@styleCode,'Italics') or contains(@styleCode,'Underline') or contains(@styleCode, 'Bold'))">
         <xsl:apply-templates/>
      </xsl:if>
   </xsl:template>
   <!--    Superscript or Subscript   -->
   <xsl:template match="n1:sup">
      <xsl:element name="sup">
         <xsl:apply-templates/>
      </xsl:element>
   </xsl:template>
   <xsl:template match="n1:sub">
      <xsl:element name="sub">
         <xsl:apply-templates/>
      </xsl:element>
   </xsl:template>
   <!-- show-signature -->
   <xsl:template name="show-sig">
      <xsl:param name="sig"/>
      <xsl:choose>
         <xsl:when test="$sig/@code =&apos;S&apos;">
            <xsl:text>signed</xsl:text>
         </xsl:when>
         <xsl:when test="$sig/@code=&apos;I&apos;">
            <xsl:text>intended</xsl:text>
         </xsl:when>
         <xsl:when test="$sig/@code=&apos;X&apos;">
            <xsl:text>signature required</xsl:text>
         </xsl:when>
      </xsl:choose>
   </xsl:template>
   <!--  show-id -->
   <xsl:template name="show-id">
      <xsl:param name="id"/>
      <xsl:choose>
         <xsl:when test="not($id)">
            <xsl:if test="not(@nullFlavor)">
               <xsl:if test="@extension">
                  <xsl:value-of select="@extension"/>
               </xsl:if>
               <xsl:text> </xsl:text>
               <xsl:value-of select="@root"/>
            </xsl:if>
         </xsl:when>
         <xsl:otherwise>
            <xsl:if test="not($id/@nullFlavor)">
               <xsl:if test="$id/@extension">
                  <xsl:value-of select="$id/@extension"/>
               </xsl:if>
               <xsl:text> </xsl:text>
               <xsl:value-of select="$id/@root"/>
            </xsl:if>
         </xsl:otherwise>
      </xsl:choose>
   </xsl:template>
   <!-- show-name  -->
   <xsl:template name="show-name">
      <xsl:param name="name"/>
      <xsl:choose>
         <xsl:when test="$name/n1:family">
            <xsl:if test="$name/n1:prefix">
               <xsl:value-of select="$name/n1:prefix"/>
               <xsl:text> </xsl:text>
            </xsl:if>
            <xsl:value-of select="$name/n1:given"/>
            <xsl:text> </xsl:text>
            <xsl:value-of select="$name/n1:family"/>
            <xsl:if test="$name/n1:suffix">
               <xsl:text>, </xsl:text>
               <xsl:value-of select="$name/n1:suffix"/>
            </xsl:if>
         </xsl:when>
         <xsl:otherwise>
            <xsl:value-of select="$name"/>
         </xsl:otherwise>
      </xsl:choose>
   </xsl:template>
   <!-- show-gender  -->
   <xsl:template name="show-gender">
      <xsl:choose>
         <xsl:when test="@code   = &apos;M&apos;">
            <xsl:text>Male</xsl:text>
         </xsl:when>
         <xsl:when test="@code  = &apos;F&apos;">
            <xsl:text>Female</xsl:text>
         </xsl:when>
         <xsl:when test="@code  = &apos;UN&apos;">
            <xsl:text>Undifferentiated</xsl:text>
         </xsl:when>
         <xsl:when test="@code  = &apos;UNK&apos;">
            <xsl:text>Unknown</xsl:text>
         </xsl:when>
      </xsl:choose>
   </xsl:template>
   <!-- show-race-ethnicity  -->
   <xsl:template name="show-race-ethnicity">
      <xsl:choose>
         <xsl:when test="@displayName">
            <xsl:value-of select="@displayName"/>
         </xsl:when>
         <xsl:otherwise>
            <xsl:value-of select="@code"/>
         </xsl:otherwise>
      </xsl:choose>
   </xsl:template>
   <!-- show-contactInfo -->
   <xsl:template name="show-contactInfo">
      <xsl:param name="contact"/>
      <xsl:call-template name="show-address">
         <xsl:with-param name="address" select="$contact/n1:addr"/>
      </xsl:call-template>
      <xsl:call-template name="show-telecom">
         <xsl:with-param name="telecom" select="$contact/n1:telecom"/>
      </xsl:call-template>
   </xsl:template>
   <!-- show-address -->
   <xsl:template name="show-address">
      <xsl:param name="address"/>
      <xsl:choose>
         <xsl:when test="$address">
            <xsl:if test="$address/@use">
               <xsl:text> </xsl:text>
               <xsl:call-template name="translateTelecomCode">
                  <xsl:with-param name="code" select="$address/@use"/>
               </xsl:call-template>
               <xsl:text>:</xsl:text>
               <br/>
            </xsl:if>
            <xsl:for-each select="$address/n1:streetAddressLine">
               <xsl:value-of select="."/>
               <br/>
            </xsl:for-each>
            <xsl:if test="$address/n1:streetName">
               <xsl:value-of select="$address/n1:streetName"/>
               <xsl:text> </xsl:text>
               <xsl:value-of select="$address/n1:houseNumber"/>
               <br/>
            </xsl:if>
            <xsl:if test="string-length($address/n1:city)>0">
               <xsl:value-of select="$address/n1:city"/>
            </xsl:if>
            <xsl:if test="string-length($address/n1:state)>0">
               <xsl:text>,&#160;</xsl:text>
               <xsl:value-of select="$address/n1:state"/>
            </xsl:if>
            <xsl:if test="string-length($address/n1:postalCode)>0">
               <xsl:text>&#160;</xsl:text>
               <xsl:value-of select="$address/n1:postalCode"/>
            </xsl:if>
            <xsl:if test="string-length($address/n1:country)>0">
               <xsl:text>,&#160;</xsl:text>
               <xsl:value-of select="$address/n1:country"/>
            </xsl:if>
         </xsl:when>
         <xsl:otherwise>
            <xsl:text>address not available</xsl:text>
         </xsl:otherwise>
      </xsl:choose>
      <br/>
   </xsl:template>
   <!-- show-telecom -->
   <xsl:template name="show-telecom">
      <xsl:param name="telecom"/>
      <xsl:choose>
         <xsl:when test="$telecom">
            <xsl:variable name="type" select="substring-before($telecom/@value, ':')"/>
            <xsl:variable name="value" select="substring-after($telecom/@value, ':')"/>
            <xsl:if test="$type">
               <xsl:call-template name="translateTelecomCode">
                  <xsl:with-param name="code" select="$type"/>
               </xsl:call-template>
               <xsl:if test="@use">
                  <xsl:text> (</xsl:text>
                  <xsl:call-template name="translateTelecomCode">
                     <xsl:with-param name="code" select="@use"/>
                  </xsl:call-template>
                  <xsl:text>)</xsl:text>
               </xsl:if>
               <xsl:text>: </xsl:text>
               <xsl:text> </xsl:text>
               <xsl:value-of select="$value"/>
            </xsl:if>
         </xsl:when>
         <xsl:otherwise>
            <xsl:text>Telecom information not available</xsl:text>
         </xsl:otherwise>
      </xsl:choose>
      <br/>
   </xsl:template>
   <!-- show-recipientType -->
   <xsl:template name="show-recipientType">
      <xsl:param name="typeCode"/>
      <xsl:choose>
         <xsl:when test="$typeCode='PRCP'">Primary Recipient:</xsl:when>
         <xsl:when test="$typeCode='TRC'">Secondary Recipient:</xsl:when>
         <xsl:otherwise>Recipient:</xsl:otherwise>
      </xsl:choose>
   </xsl:template>
   <!-- Convert Telecom URL to display text -->
   <xsl:template name="translateTelecomCode">
      <xsl:param name="code"/>
      <!--xsl:value-of select="document('voc.xml')/systems/system[@root=$code/@codeSystem]/code[@value=$code/@code]/@displayName"/-->
      <!--xsl:value-of select="document('codes.xml')/*/code[@code=$code]/@display"/-->
      <xsl:choose>
         <!-- lookup table Telecom URI -->
         <xsl:when test="$code='tel'">
            <xsl:text>Tel</xsl:text>
         </xsl:when>
         <xsl:when test="$code='fax'">
            <xsl:text>Fax</xsl:text>
         </xsl:when>
         <xsl:when test="$code='http'">
            <xsl:text>Web</xsl:text>
         </xsl:when>
         <xsl:when test="$code='mailto'">
            <xsl:text>Mail</xsl:text>
         </xsl:when>
         <xsl:when test="$code='H'">
            <xsl:text>Home</xsl:text>
         </xsl:when>
         <xsl:when test="$code='HV'">
            <xsl:text>Vacation Home</xsl:text>
         </xsl:when>
         <xsl:when test="$code='HP'">
            <xsl:text>Primary Home</xsl:text>
         </xsl:when>
         <xsl:when test="$code='WP'">
            <xsl:text>Work Place</xsl:text>
         </xsl:when>
         <xsl:when test="$code='PUB'">
            <xsl:text>Pub</xsl:text>
         </xsl:when>
         <xsl:otherwise>
            <xsl:text>{$code='</xsl:text>
            <xsl:value-of select="$code"/>
            <xsl:text>'?}</xsl:text>
         </xsl:otherwise>
      </xsl:choose>
   </xsl:template>
   <!-- convert RoleClassAssociative code to display text -->
   <xsl:template name="translateRoleAssoCode">
      <xsl:param name="classCode"/>
      <xsl:param name="code"/>
      <xsl:choose>
         <xsl:when test="$classCode='AFFL'">
            <xsl:text>affiliate</xsl:text>
         </xsl:when>
         <xsl:when test="$classCode='AGNT'">
            <xsl:text>agent</xsl:text>
         </xsl:when>
         <xsl:when test="$classCode='ASSIGNED'">
            <xsl:text>assigned entity</xsl:text>
         </xsl:when>
         <xsl:when test="$classCode='COMPAR'">
            <xsl:text>commissioning party</xsl:text>
         </xsl:when>
         <xsl:when test="$classCode='CON'">
            <xsl:text>contact</xsl:text>
         </xsl:when>
         <xsl:when test="$classCode='ECON'">
            <xsl:text>emergency contact</xsl:text>
         </xsl:when>
         <xsl:when test="$classCode='NOK'">
            <xsl:text>next of kin</xsl:text>
         </xsl:when>
         <xsl:when test="$classCode='SGNOFF'">
            <xsl:text>signing authority</xsl:text>
         </xsl:when>
         <xsl:when test="$classCode='GUARD'">
            <xsl:text>guardian</xsl:text>
         </xsl:when>
         <xsl:when test="$classCode='GUAR'">
            <xsl:text>guardian</xsl:text>
         </xsl:when>
         <xsl:when test="$classCode='CIT'">
            <xsl:text>citizen</xsl:text>
         </xsl:when>
         <xsl:when test="$classCode='COVPTY'">
            <xsl:text>covered party</xsl:text>
         </xsl:when>
         <xsl:when test="$classCode='PRS'">
            <xsl:text>personal relationship</xsl:text>
         </xsl:when>
         <xsl:when test="$classCode='CAREGIVER'">
            <xsl:text>care giver</xsl:text>
         </xsl:when>
         <xsl:otherwise>
            <xsl:text>{$classCode='</xsl:text>
            <xsl:value-of select="$classCode"/>
            <xsl:text>'?}</xsl:text>
         </xsl:otherwise>
      </xsl:choose>
      <xsl:if test="($code/@code) and ($code/@codeSystem='2.16.840.1.113883.5.111')">
         <xsl:text> </xsl:text>
         <xsl:choose>
            <xsl:when test="$code/@code='FTH'">
               <xsl:text>(Father)</xsl:text>
            </xsl:when>
            <xsl:when test="$code/@code='MTH'">
               <xsl:text>(Mother)</xsl:text>
            </xsl:when>
            <xsl:when test="$code/@code='NPRN'">
               <xsl:text>(Natural parent)</xsl:text>
            </xsl:when>
            <xsl:when test="$code/@code='STPPRN'">
               <xsl:text>(Step parent)</xsl:text>
            </xsl:when>
            <xsl:when test="$code/@code='SONC'">
               <xsl:text>(Son)</xsl:text>
            </xsl:when>
            <xsl:when test="$code/@code='DAUC'">
               <xsl:text>(Daughter)</xsl:text>
            </xsl:when>
            <xsl:when test="$code/@code='CHILD'">
               <xsl:text>(Child)</xsl:text>
            </xsl:when>
            <xsl:when test="$code/@code='EXT'">
               <xsl:text>(Extended family member)</xsl:text>
            </xsl:when>
            <xsl:when test="$code/@code='NBOR'">
               <xsl:text>(Neighbor)</xsl:text>
            </xsl:when>
            <xsl:when test="$code/@code='SIGOTHR'">
               <xsl:text>(Significant other)</xsl:text>
            </xsl:when>
            <xsl:otherwise>
               <xsl:text>{$code/@code='</xsl:text>
               <xsl:value-of select="$code/@code"/>
               <xsl:text>'?}</xsl:text>
            </xsl:otherwise>
         </xsl:choose>
      </xsl:if>
   </xsl:template>
   <!-- show time -->
   <xsl:template name="show-time">
      <xsl:param name="datetime"/>
      <xsl:choose>
         <xsl:when test="not($datetime)">
            <xsl:call-template name="formatDateTime">
               <xsl:with-param name="date" select="@value"/>
            </xsl:call-template>
            <xsl:text> </xsl:text>
         </xsl:when>
         <xsl:otherwise>
            <xsl:call-template name="formatDateTime">
               <xsl:with-param name="date" select="$datetime/@value"/>
            </xsl:call-template>
            <xsl:text> </xsl:text>
         </xsl:otherwise>
      </xsl:choose>
   </xsl:template>
   <!-- paticipant facility and date -->
   <xsl:template name="facilityAndDates">
      <table class="header_table">
         <tbody>
            <!-- facility id -->
            <tr>
               <td width="20%" bgcolor="#3399ff">
                  <span class="td_label">
                     <xsl:text>Facility ID</xsl:text>
                  </span>
               </td>
               <td colspan="3">
                  <xsl:choose>
                     <xsl:when test="count(/n1:ClinicalDocument/n1:participant
                                      [@typeCode='LOC'][@contextControlCode='OP']
                                      /n1:associatedEntity[@classCode='SDLOC']/n1:id)&gt;0">
                        <!-- change context node -->
                        <xsl:for-each select="/n1:ClinicalDocument/n1:participant
                                      [@typeCode='LOC'][@contextControlCode='OP']
                                      /n1:associatedEntity[@classCode='SDLOC']/n1:id">
                           <xsl:call-template name="show-id"/>
                           <!-- change context node again, for the code -->
                           <xsl:for-each select="../n1:code">
                              <xsl:text> (</xsl:text>
                              <xsl:call-template name="show-code">
                                 <xsl:with-param name="code" select="."/>
                              </xsl:call-template>
                              <xsl:text>)</xsl:text>
                           </xsl:for-each>
                        </xsl:for-each>
                     </xsl:when>
                     <xsl:otherwise>
                 Not available
                             </xsl:otherwise>
                  </xsl:choose>
               </td>
            </tr>
            <!-- Period reported -->
            <tr>
               <td width="20%" bgcolor="#3399ff">
                  <span class="td_label">
                     <xsl:text>First day of period reported</xsl:text>
                  </span>
               </td>
               <td colspan="3">
                  <xsl:call-template name="show-time">
                     <xsl:with-param name="datetime" select="/n1:ClinicalDocument/n1:documentationOf
                                      /n1:serviceEvent/n1:effectiveTime/n1:low"/>
                  </xsl:call-template>
               </td>
            </tr>
            <tr>
               <td width="20%" bgcolor="#3399ff">
                  <span class="td_label">
                     <xsl:text>Last day of period reported</xsl:text>
                  </span>
               </td>
               <td colspan="3">
                  <xsl:call-template name="show-time">
                     <xsl:with-param name="datetime" select="/n1:ClinicalDocument/n1:documentationOf
                                      /n1:serviceEvent/n1:effectiveTime/n1:high"/>
                  </xsl:call-template>
               </td>
            </tr>
         </tbody>
      </table>
   </xsl:template>
   <!-- show assignedEntity -->
   <xsl:template name="show-assignedEntity">
      <xsl:param name="asgnEntity"/>
      <xsl:choose>
         <xsl:when test="$asgnEntity/n1:assignedPerson/n1:name">
            <xsl:call-template name="show-name">
               <xsl:with-param name="name" select="$asgnEntity/n1:assignedPerson/n1:name"/>
            </xsl:call-template>
            <xsl:if test="$asgnEntity/n1:representedOrganization/n1:name">
               <xsl:text> of </xsl:text>
               <xsl:value-of select="$asgnEntity/n1:representedOrganization/n1:name"/>
            </xsl:if>
         </xsl:when>
         <xsl:when test="$asgnEntity/n1:representedOrganization">
            <xsl:value-of select="$asgnEntity/n1:representedOrganization/n1:name"/>
         </xsl:when>
         <xsl:otherwise>
            <xsl:for-each select="$asgnEntity/n1:id">
               <xsl:call-template name="show-id"/>
               <xsl:choose>
                  <xsl:when test="position()!=last()">
                     <xsl:text>, </xsl:text>
                  </xsl:when>
                  <xsl:otherwise>
                     <br/>
                  </xsl:otherwise>
               </xsl:choose>
            </xsl:for-each>
         </xsl:otherwise>
      </xsl:choose>
   </xsl:template>
   <!-- show relatedEntity -->
   <xsl:template name="show-relatedEntity">
      <xsl:param name="relatedEntity"/>
      <xsl:choose>
         <xsl:when test="$relatedEntity/n1:relatedPerson/n1:name">
            <xsl:call-template name="show-name">
               <xsl:with-param name="name" select="$relatedEntity/n1:relatedPerson/n1:name"/>
            </xsl:call-template>
         </xsl:when>
      </xsl:choose>
   </xsl:template>
   <!-- show associatedEntity -->
   <xsl:template name="show-associatedEntity">
      <xsl:param name="assoEntity"/>
      <xsl:choose>
         <xsl:when test="$assoEntity/n1:associatedPerson">
            <xsl:for-each select="$assoEntity/n1:associatedPerson/n1:name">
               <xsl:call-template name="show-name">
                  <xsl:with-param name="name" select="."/>
               </xsl:call-template>
               <br/>
            </xsl:for-each>
         </xsl:when>
         <xsl:when test="$assoEntity/n1:scopingOrganization">
            <xsl:for-each select="$assoEntity/n1:scopingOrganization">
               <xsl:if test="n1:name">
                  <xsl:call-template name="show-name">
                     <xsl:with-param name="name" select="n1:name"/>
                  </xsl:call-template>
                  <br/>
               </xsl:if>
               <xsl:if test="n1:standardIndustryClassCode">
                  <xsl:value-of select="n1:standardIndustryClassCode/@displayName"/>
                  <xsl:text> code:</xsl:text>
                  <xsl:value-of select="n1:standardIndustryClassCode/@code"/>
               </xsl:if>
            </xsl:for-each>
         </xsl:when>
         <xsl:when test="$assoEntity/n1:code">
            <xsl:call-template name="show-code">
               <xsl:with-param name="code" select="$assoEntity/n1:code"/>
            </xsl:call-template>
         </xsl:when>
         <xsl:when test="$assoEntity/n1:id">
            <xsl:value-of select="$assoEntity/n1:id/@extension"/>
            <xsl:text> </xsl:text>
            <xsl:value-of select="$assoEntity/n1:id/@root"/>
         </xsl:when>
      </xsl:choose>
   </xsl:template>
   <!-- show code 
    if originalText present, return it, otherwise, check and return attribute: display name
    -->
   <xsl:template name="show-code">
      <xsl:param name="code"/>
      <xsl:variable name="this-codeSystem">
         <xsl:value-of select="$code/@codeSystem"/>
      </xsl:variable>
      <xsl:variable name="this-code">
         <xsl:value-of select="$code/@code"/>
      </xsl:variable>
      <xsl:choose>
         <xsl:when test="$code/n1:originalText">
            <xsl:value-of select="$code/n1:originalText"/>
         </xsl:when>
         <xsl:when test="$code/@displayName">
            <xsl:value-of select="$code/@displayName"/>
         </xsl:when>
         <!--
      <xsl:when test="$the-valuesets/*/voc:system[@root=$this-codeSystem]/voc:code[@value=$this-code]/@displayName">
        <xsl:value-of select="$the-valuesets/*/voc:system[@root=$this-codeSystem]/voc:code[@value=$this-code]/@displayName"/>
      </xsl:when>
      -->
         <xsl:otherwise>
            <xsl:value-of select="$this-code"/>
         </xsl:otherwise>
      </xsl:choose>
   </xsl:template>
   <!-- show classCode -->
   <xsl:template name="show-actClassCode">
      <xsl:param name="clsCode"/>
      <xsl:choose>
         <xsl:when test=" $clsCode = 'ACT' ">
            <xsl:text>healthcare service</xsl:text>
         </xsl:when>
         <xsl:when test=" $clsCode = 'ACCM' ">
            <xsl:text>accommodation</xsl:text>
         </xsl:when>
         <xsl:when test=" $clsCode = 'ACCT' ">
            <xsl:text>account</xsl:text>
         </xsl:when>
         <xsl:when test=" $clsCode = 'ACSN' ">
            <xsl:text>accession</xsl:text>
         </xsl:when>
         <xsl:when test=" $clsCode = 'ADJUD' ">
            <xsl:text>financial adjudication</xsl:text>
         </xsl:when>
         <xsl:when test=" $clsCode = 'CONS' ">
            <xsl:text>consent</xsl:text>
         </xsl:when>
         <xsl:when test=" $clsCode = 'CONTREG' ">
            <xsl:text>container registration</xsl:text>
         </xsl:when>
         <xsl:when test=" $clsCode = 'CTTEVENT' ">
            <xsl:text>clinical trial timepoint event</xsl:text>
         </xsl:when>
         <xsl:when test=" $clsCode = 'DISPACT' ">
            <xsl:text>disciplinary action</xsl:text>
         </xsl:when>
         <xsl:when test=" $clsCode = 'ENC' ">
            <xsl:text>encounter</xsl:text>
         </xsl:when>
         <xsl:when test=" $clsCode = 'INC' ">
            <xsl:text>incident</xsl:text>
         </xsl:when>
         <xsl:when test=" $clsCode = 'INFRM' ">
            <xsl:text>inform</xsl:text>
         </xsl:when>
         <xsl:when test=" $clsCode = 'INVE' ">
            <xsl:text>invoice element</xsl:text>
         </xsl:when>
         <xsl:when test=" $clsCode = 'LIST' ">
            <xsl:text>working list</xsl:text>
         </xsl:when>
         <xsl:when test=" $clsCode = 'MPROT' ">
            <xsl:text>monitoring program</xsl:text>
         </xsl:when>
         <xsl:when test=" $clsCode = 'PCPR' ">
            <xsl:text>care provision</xsl:text>
         </xsl:when>
         <xsl:when test=" $clsCode = 'PROC' ">
            <xsl:text>procedure</xsl:text>
         </xsl:when>
         <xsl:when test=" $clsCode = 'REG' ">
            <xsl:text>registration</xsl:text>
         </xsl:when>
         <xsl:when test=" $clsCode = 'REV' ">
            <xsl:text>review</xsl:text>
         </xsl:when>
         <xsl:when test=" $clsCode = 'SBADM' ">
            <xsl:text>substance administration</xsl:text>
         </xsl:when>
         <xsl:when test=" $clsCode = 'SPCTRT' ">
            <xsl:text>speciment treatment</xsl:text>
         </xsl:when>
         <xsl:when test=" $clsCode = 'SUBST' ">
            <xsl:text>substitution</xsl:text>
         </xsl:when>
         <xsl:when test=" $clsCode = 'TRNS' ">
            <xsl:text>transportation</xsl:text>
         </xsl:when>
         <xsl:when test=" $clsCode = 'VERIF' ">
            <xsl:text>verification</xsl:text>
         </xsl:when>
         <xsl:when test=" $clsCode = 'XACT' ">
            <xsl:text>financial transaction</xsl:text>
         </xsl:when>
      </xsl:choose>
   </xsl:template>
   <!-- show participationType -->
   <xsl:template name="show-participationType">
      <xsl:param name="ptype"/>
      <xsl:choose>
         <xsl:when test=" $ptype='PPRF' ">
            <xsl:text>primary performer</xsl:text>
         </xsl:when>
         <xsl:when test=" $ptype='PRF' ">
            <xsl:text>performer</xsl:text>
         </xsl:when>
         <xsl:when test=" $ptype='VRF' ">
            <xsl:text>verifier</xsl:text>
         </xsl:when>
         <xsl:when test=" $ptype='SPRF' ">
            <xsl:text>secondary performer</xsl:text>
         </xsl:when>
      </xsl:choose>
   </xsl:template>
   <!-- show participationFunction -->
   <xsl:template name="show-participationFunction">
      <xsl:param name="pFunction"/>
      <xsl:choose>
         <!-- From the HL7 v3 ParticipationFunction code system -->
         <xsl:when test=" $pFunction = 'ADMPHYS' ">
            <xsl:text>(admitting physician)</xsl:text>
         </xsl:when>
         <xsl:when test=" $pFunction = 'ANEST' ">
            <xsl:text>(anesthesist)</xsl:text>
         </xsl:when>
         <xsl:when test=" $pFunction = 'ANRS' ">
            <xsl:text>(anesthesia nurse)</xsl:text>
         </xsl:when>
         <xsl:when test=" $pFunction = 'ATTPHYS' ">
            <xsl:text>(attending physician)</xsl:text>
         </xsl:when>
         <xsl:when test=" $pFunction = 'DISPHYS' ">
            <xsl:text>(discharging physician)</xsl:text>
         </xsl:when>
         <xsl:when test=" $pFunction = 'FASST' ">
            <xsl:text>(first assistant surgeon)</xsl:text>
         </xsl:when>
         <xsl:when test=" $pFunction = 'MDWF' ">
            <xsl:text>(midwife)</xsl:text>
         </xsl:when>
         <xsl:when test=" $pFunction = 'NASST' ">
            <xsl:text>(nurse assistant)</xsl:text>
         </xsl:when>
         <xsl:when test=" $pFunction = 'PCP' ">
            <xsl:text>(primary care physician)</xsl:text>
         </xsl:when>
         <xsl:when test=" $pFunction = 'PRISURG' ">
            <xsl:text>(primary surgeon)</xsl:text>
         </xsl:when>
         <xsl:when test=" $pFunction = 'RNDPHYS' ">
            <xsl:text>(rounding physician)</xsl:text>
         </xsl:when>
         <xsl:when test=" $pFunction = 'SASST' ">
            <xsl:text>(second assistant surgeon)</xsl:text>
         </xsl:when>
         <xsl:when test=" $pFunction = 'SNRS' ">
            <xsl:text>(scrub nurse)</xsl:text>
         </xsl:when>
         <xsl:when test=" $pFunction = 'TASST' ">
            <xsl:text>(third assistant)</xsl:text>
         </xsl:when>
         <!-- From the HL7 v2 Provider Role code system (2.16.840.1.113883.12.443) which is used by HITSP -->
         <xsl:when test=" $pFunction = 'CP' ">
            <xsl:text>(consulting provider)</xsl:text>
         </xsl:when>
         <xsl:when test=" $pFunction = 'PP' ">
            <xsl:text>(primary care provider)</xsl:text>
         </xsl:when>
         <xsl:when test=" $pFunction = 'RP' ">
            <xsl:text>(referring provider)</xsl:text>
         </xsl:when>
         <xsl:when test=" $pFunction = 'MP' ">
            <xsl:text>(medical home provider)</xsl:text>
         </xsl:when>
      </xsl:choose>
   </xsl:template>
   <xsl:template name="formatDateTime">
      <xsl:param name="date"/>
      <!-- month -->
      <xsl:variable name="month" select="substring ($date, 5, 2)"/>
      <xsl:choose>
         <xsl:when test="$month='01'">
            <xsl:text>January </xsl:text>
         </xsl:when>
         <xsl:when test="$month='02'">
            <xsl:text>February </xsl:text>
         </xsl:when>
         <xsl:when test="$month='03'">
            <xsl:text>March </xsl:text>
         </xsl:when>
         <xsl:when test="$month='04'">
            <xsl:text>April </xsl:text>
         </xsl:when>
         <xsl:when test="$month='05'">
            <xsl:text>May </xsl:text>
         </xsl:when>
         <xsl:when test="$month='06'">
            <xsl:text>June </xsl:text>
         </xsl:when>
         <xsl:when test="$month='07'">
            <xsl:text>July </xsl:text>
         </xsl:when>
         <xsl:when test="$month='08'">
            <xsl:text>August </xsl:text>
         </xsl:when>
         <xsl:when test="$month='09'">
            <xsl:text>September </xsl:text>
         </xsl:when>
         <xsl:when test="$month='10'">
            <xsl:text>October </xsl:text>
         </xsl:when>
         <xsl:when test="$month='11'">
            <xsl:text>November </xsl:text>
         </xsl:when>
         <xsl:when test="$month='12'">
            <xsl:text>December </xsl:text>
         </xsl:when>
      </xsl:choose>
      <!-- day -->
      <xsl:choose>
         <xsl:when test='substring ($date, 7, 1)="0"'>
            <xsl:value-of select="substring ($date, 8, 1)"/>
            <xsl:text>, </xsl:text>
         </xsl:when>
         <xsl:otherwise>
            <xsl:value-of select="substring ($date, 7, 2)"/>
            <xsl:text>, </xsl:text>
         </xsl:otherwise>
      </xsl:choose>
      <!-- year -->
      <xsl:value-of select="substring ($date, 1, 4)"/>
      <!-- time and US timezone -->
      <xsl:if test="string-length($date) > 8">
         <xsl:text>, </xsl:text>
         <!-- time -->
         <xsl:variable name="time">
            <xsl:value-of select="substring($date,9,6)"/>
         </xsl:variable>
         <xsl:variable name="hh">
            <xsl:value-of select="substring($time,1,2)"/>
         </xsl:variable>
         <xsl:variable name="mm">
            <xsl:value-of select="substring($time,3,2)"/>
         </xsl:variable>
         <xsl:variable name="ss">
            <xsl:value-of select="substring($time,5,2)"/>
         </xsl:variable>
         <xsl:if test="string-length($hh)&gt;1">
            <xsl:value-of select="$hh"/>
            <xsl:if test="string-length($mm)&gt;1 and not(contains($mm,'-')) and not (contains($mm,'+'))">
               <xsl:text>:</xsl:text>
               <xsl:value-of select="$mm"/>
               <xsl:if test="string-length($ss)&gt;1 and not(contains($ss,'-')) and not (contains($ss,'+'))">
                  <xsl:text>:</xsl:text>
                  <xsl:value-of select="$ss"/>
               </xsl:if>
            </xsl:if>
         </xsl:if>
         <!-- time zone -->
         <xsl:variable name="tzon">
            <xsl:choose>
               <xsl:when test="contains($date,'+')">
                  <xsl:text>+</xsl:text>
                  <xsl:value-of select="substring-after($date, '+')"/>
               </xsl:when>
               <xsl:when test="contains($date,'-')">
                  <xsl:text>-</xsl:text>
                  <xsl:value-of select="substring-after($date, '-')"/>
               </xsl:when>
            </xsl:choose>
         </xsl:variable>
         <xsl:choose>
            <!-- reference: http://www.timeanddate.com/library/abbreviations/timezones/na/ -->
            <xsl:when test="$tzon = '-0500' ">
               <xsl:text>, EST</xsl:text>
            </xsl:when>
            <xsl:when test="$tzon = '-0600' ">
               <xsl:text>, CST</xsl:text>
            </xsl:when>
            <xsl:when test="$tzon = '-0700' ">
               <xsl:text>, MST</xsl:text>
            </xsl:when>
            <xsl:when test="$tzon = '-0800' ">
               <xsl:text>, PST</xsl:text>
            </xsl:when>
            <xsl:otherwise>
               <xsl:text> </xsl:text>
               <xsl:value-of select="$tzon"/>
            </xsl:otherwise>
         </xsl:choose>
      </xsl:if>
   </xsl:template>
   <!-- convert to lower case -->
   <xsl:template name="caseDown">
      <xsl:param name="data"/>
      <xsl:if test="$data">
         <xsl:value-of select="translate($data, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ','abcdefghijklmnopqrstuvwxyz')"/>
      </xsl:if>
   </xsl:template>
   <!-- convert to upper case -->
   <xsl:template name="caseUp">
      <xsl:param name="data"/>
      <xsl:if test="$data">
         <xsl:value-of select="translate($data,'abcdefghijklmnopqrstuvwxyz', 'ABCDEFGHIJKLMNOPQRSTUVWXYZ')"/>
      </xsl:if>
   </xsl:template>
   <!-- convert first character to upper case -->
   <xsl:template name="firstCharCaseUp">
      <xsl:param name="data"/>
      <xsl:if test="$data">
         <xsl:call-template name="caseUp">
            <xsl:with-param name="data" select="substring($data,1,1)"/>
         </xsl:call-template>
         <xsl:value-of select="substring($data,2)"/>
      </xsl:if>
   </xsl:template>
   <!-- show-noneFlavor -->
   <xsl:template name="show-noneFlavor">
      <xsl:param name="nf"/>
      <xsl:choose>
         <xsl:when test=" $nf = 'NI' ">
            <xsl:text>no information</xsl:text>
         </xsl:when>
         <xsl:when test=" $nf = 'INV' ">
            <xsl:text>invalid</xsl:text>
         </xsl:when>
         <xsl:when test=" $nf = 'MSK' ">
            <xsl:text>masked</xsl:text>
         </xsl:when>
         <xsl:when test=" $nf = 'NA' ">
            <xsl:text>not applicable</xsl:text>
         </xsl:when>
         <xsl:when test=" $nf = 'UNK' ">
            <xsl:text>unknown</xsl:text>
         </xsl:when>
         <xsl:when test=" $nf = 'OTH' ">
            <xsl:text>other</xsl:text>
         </xsl:when>
      </xsl:choose>
   </xsl:template>
   <xsl:template name="addCSS">
      <style type="text/css">
         <xsl:text>
body {
  color: #003366;
  background-color: #FFFFFF;
  font-family: Verdana, Tahoma, sans-serif;
  font-size: 11px;
}
a {
  color: #003366;
  background-color: #FFFFFF;
}
h1 {
  font-size: 12pt;
  font-weight: bold;
}
h2 {
  font-size: 11pt;
  font-weight: bold;
}
h3 {
  font-size: 10pt;
  font-weight: bold;
}
h4 {
  font-size: 8pt;
  font-weight: bold;
}
div {
  width: 80%;
}
table {
  line-height: 10pt;
  width: 80%;
}
tr {
  background-color: #ccccff;
}
td {
  padding: 0.1cm 0.2cm;
  vertical-align: top;
}
.h1center {
  font-size: 12pt;
  font-weight: bold;
  text-align: center;
  width: 80%;
}
.header_table{
  border: 1pt inset #00008b;
}
.narr_table {
  width: 100%;
}
.narr_tr {
  background-color: #ffffcc;
}
.narr_th {
  background-color: #ffd700;
}
.td_label{
  font-weight: bold;
  color: white;
}
          </xsl:text>
      </style>
   </xsl:template>
</xsl:stylesheet>
