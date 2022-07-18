<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:n1="urn:hl7-org:v3"
                xmlns:in="urn:lantana-com:inline-variable-data">
    <xsl:output method="html" indent="yes" version="4.01" encoding="ISO-8859-1" doctype-system="http://www.w3.org/TR/html4/strict.dtd" doctype-public="-//W3C//DTD HTML 4.01//EN"/>
	<xsl:template match="ClinicalDocument">	
	<html>
	<head></head>
	<body style="background-color:#fffff0;">
	
	<table>
	<tr>
		<!--<xsl:text>NT_Bad_GenderCode_r11_v2.xml</xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;">
			<font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
			- Consol US Realm Header SHALL contain at least one [1..*] recordTarget, where its type is Record Target (CONF:5266) each SHALL contain exactly one [1..1] patientRole, where (CONF:5268) patient Role SHALL contain exactly one [1..1] patient, where (CONF:1198-5283) patient SHALL contain exactly one [1..1] administrativeGenderCode, which SHALL be selected from ValueSet Administrative Gender (HL7 V3) 2.16.840.1.113883.1.11.1 DYNAMIC (CONF:6394, R2.1=CONF:1198-6394)<br/><b>/ClinicalDocument/recordTarget/patientRole/patient</b><br/>Line number: <b>120</b></td>
	</tr>

	<tr>
		<!--<xsl:text>NT_BadXml_r11_v2.xml</xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		CCDA Document Details: NegativeTesting_CCDS / NT_BadXml_r11_v2.xml - 
		Service Error Message: The service has encountered an error parsing the document. Please verify the document does not contain in-line XSL styling and/or address the following error: Element type &quot;templateId&quot; must be followed by either attribute specifications, &quot;&gt;&quot; or &quot;/&gt;&quot;.</td>
	</tr>

	<tr>
		<!--<xsl:text>NT_Bad_DocCode_r11_v2.xml</xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		 - Consol Continuity Of Care Document SHALL contain exactly one [1..1] code (CONF:17180)/@code=&quot;34133-9&quot; Summarization of Episode Note (CodeSystem: 2.16.840.1.113883.6.1 LOINC) (CONF:17181)<br/><b>/ClinicalDocument</b><br/>Line number: <b>31</b></td>
	</tr>
	
	<tr>
		<!--<xsl:text>NT_Bad_AllergySectionCode_r11_v2.xml</xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		 - Consol Allergies Section Entries Optional SHALL contain exactly one [1..1] code (CONF:15345)/@code=&quot;48765-2&quot; Allergies, adverse reactions, alerts (CodeSystem: 2.16.840.1.113883.6.1 LOINC) (CONF:15346)<br/><b>/ClinicalDocument/component/structuredBody/component/section</b><br/>Line number: <b>658</b></td>
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		 - Consol Allergies Section SHALL contain exactly one [1..1] code (CONF:15349)/@code=&quot;48765-2&quot; Allergies, adverse reactions, alerts (CodeSystem: 2.16.840.1.113883.6.1 LOINC) (CONF:15350)<br/><b>/ClinicalDocument/component/structuredBody/component/section</b><br/>Line number: <b>658</b></td>
	</tr>

	<tr>
		<!--<xsl:text>NT_Bad_DocEffectiveTime_r11_v2.xml</xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		 - Consol Continuity Of Care Document SHALL contain exactly one [1..1] code (CONF:17180)/@code=&quot;34133-9&quot; Summarization of Episode Note (CodeSystem: 2.16.840.1.113883.6.1 LOINC) (CONF:17181)<br/><b>/ClinicalDocument</b><br/>Line number: <b>31</b></td>	
	</tr>

	<tr>
		<!--<xsl:text>NT_Bad_DocTypeId_r11_v2.xml</xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		 - Consol US Realm Header typeId SHALL contain exactly one [1..1] @extension=&quot;POCD_HD000040&quot; (CONF:5251, R2.1=CONF:1198-5251)<br/><b>/ClinicalDocument</b><br/>Line number: <b>31</b></td>	
	</tr>

	<tr>
		<!--<xsl:text>NT_Bad_EthnicityCodeSystem_r11_v2.xml</xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		 - Consol US Realm Header SHALL contain at least one [1..*] recordTarget, where its type is Record Target (CONF:5266) each SHALL contain exactly one [1..1] patientRole, where (CONF:5268) patient Role SHALL contain exactly one [1..1] patient, where (CONF:1198-5283) patient MAY contain zero or one [0..1] ethnicGroupCode, which SHALL be selected from ValueSet Ethnicity Value Set 2.16.840.1.114222.4.11.837 DYNAMIC (CONF:5323)<br/><b>/ClinicalDocument/recordTarget/patientRole/patient</b><br/>Line number: <b>120</b></td>
	</tr>

	<tr>
		<!--<xsl:text>NT_Bad_EthnicityCode_r11_v2.xml</xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		 - Consol US Realm Header SHALL contain at least one [1..*] recordTarget, where its type is Record Target (CONF:5266) each SHALL contain exactly one [1..1] patientRole, where (CONF:5268) patient Role SHALL contain exactly one [1..1] patient, where (CONF:1198-5283) patient MAY contain zero or one [0..1] ethnicGroupCode, which SHALL be selected from ValueSet Ethnicity Value Set 2.16.840.1.114222.4.11.837 DYNAMIC (CONF:5323)<br/><b>/ClinicalDocument/recordTarget/patientRole/patient</b><br/>Line number: <b>120</b></td>
	</tr>

	<tr>
		<!--<xsl:text>NT_Bad_GenderCodeSystem_r11_v2.xml</xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol US Realm Header SHALL contain at least one [1..*] recordTarget, where its type is Record Target (CONF:5266) each SHALL contain exactly one [1..1] patientRole, where (CONF:5268) patient Role SHALL contain exactly one [1..1] patient, where (CONF:1198-5283) patient SHALL contain exactly one [1..1] administrativeGenderCode, which SHALL be selected from ValueSet Administrative Gender (HL7 V3) 2.16.840.1.113883.1.11.1 DYNAMIC (CONF:6394, R2.1=CONF:1198-6394)<br/><b>/ClinicalDocument/recordTarget/patientRole/patient</b><br/>Line number: <b>120</b></td>	
	</tr>

	<tr>
		<!--<xsl:text></xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol US Realm Header SHALL contain at least one [1..*] recordTarget, where its type is Record Target (CONF:5266) each SHALL contain exactly one [1..1] patientRole, where (CONF:5268) patient Role SHALL contain exactly one [1..1] patient, where (CONF:1198-5283) patient SHALL contain exactly one [1..1] administrativeGenderCode, which SHALL be selected from ValueSet Administrative Gender (HL7 V3) 2.16.840.1.113883.1.11.1 DYNAMIC (CONF:6394, R2.1=CONF:1198-6394)<br/><b>/ClinicalDocument/recordTarget/patientRole/patient</b><br/>Line number: <b>120</b></td>	
	</tr>

	<tr>
		<!--<xsl:text>NT_Bad_MedicationSectionCode_r11_v2.xml</xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		 - Consol Medications Section Entries Optional SHALL contain exactly one [1..1] code/@code=&quot;10160-0&quot; History of medication use (CodeSystem: 2.16.840.1.113883.6.1 LOINC) (CONF:7792)<br/><b>/ClinicalDocument/component/structuredBody/component[5]/section</b><br/>Line number: <b>1693</b></td>	
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		 - Consol Medications Section SHALL contain exactly one [1..1] code/@code=&quot;10160-0&quot; History of medication use (CodeSystem: 2.16.840.1.113883.6.1 LOINC) (CONF:7569)<br/><b>/ClinicalDocument/component/structuredBody/component[5]/section</b><br/>Line number: <b>1693</b></td>
	</tr>

	<tr>
		<td style="border-bottom:.5pt solid lightblue;">
			<font style="font-family: verdana;color: red;font-size: 14px">
				<xsl:text>|Error</xsl:text>
			</font>
			The &quot;validateST&quot; invariant is violated on &quot;org.eclipse.mdht.uml.hl7.datatypes.impl.ENXPImpl@66391177{http:///resource32331.xml#//@clinicalDocument/@recordTarget.0/@patientRole/@patient/@name.0/@given.0}&quot;<br/><b>/ClinicalDocument/recordTarget/patientRole/patient/name/given</b><br/>Line number: <b>127</b>
		</td>
	</tr>

	<tr>
		<!--<xsl:text>NT_Bad_PatientLastName_r1_v2.xml</xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		 - The 'validateST' invariant is violated on 'org.eclipse.mdht.uml.hl7.datatypes.impl.ENXPImpl@530cd1e3{http:///resource32335.xml#//@clinicalDocument/@recordTarget.0/@patientRole/@patient/@name.0/@family.0}'<br/><b>/ClinicalDocument/recordTarget/patientRole/patient/name/family</b><br/>Line number: <b>131</b></td>
	</tr>

	<tr>
		<!--<xsl:text>NT_Bad_PatientMiddleName_r11_v2.xml</xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		 - The 'validateST' invariant is violated on 'org.eclipse.mdht.uml.hl7.datatypes.impl.ENXPImpl@76156560{http:///resource32339.xml#//@clinicalDocument/@recordTarget.0/@patientRole/@patient/@name.0/@given.2}'<br/><b>/ClinicalDocument/recordTarget/patientRole/patient/name/given[3]</b><br/>Line number: <b>129</b></td>
	</tr>

	<tr>
		<!--<xsl:text>NT_Bad_PatientPreviousName_r11_v2.xml</xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- The 'validateST' invariant is violated on 'org.eclipse.mdht.uml.hl7.datatypes.impl.ENXPImpl@7e7761b1{http:///resource32342.xml#//@clinicalDocument/@recordTarget.0/@patientRole/@patient/@name.0/@given.1}'<br/><b>/ClinicalDocument/recordTarget/patientRole/patient/name/given[2]</b><br/>Line number: <b>128</b></td>
	</tr>

	<tr>
		<!--<xsl:text>NT_Bad_PatientSuffix_r11_v2.xml</xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		 - The 'validateST' invariant is violated on 'org.eclipse.mdht.uml.hl7.datatypes.impl.ENXPImpl@24febc2{http:///resource32343.xml#//@clinicalDocument/@recordTarget.0/@patientRole/@patient/@name.0/@suffix.0}'<br/><b>/ClinicalDocument/recordTarget/patientRole/patient/name/suffix</b><br/>Line number: <b>132</b></td>
	</tr>

	<tr>
		<!--<xsl:text>NT_Bad_PreferredLanguageCodeSystem_r11_v2.xml</xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- cvc-complex-type.3.2.2: Attribute 'codeSystem' is not allowed to appear in element 'languageCode'.</td>
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- The 'validateCodeSystem' invariant is violated on 'org.eclipse.mdht.uml.hl7.datatypes.impl.CSImpl@33c708b1{http:///resource32345.xml#//@clinicalDocument/@recordTarget.0/@patientRole/@patient/@languageCommunication.0/@languageCode}'<br/>
		<b>/ClinicalDocument/recordTarget/patientRole/patient/languageCommunication/languageCode</b><br/>Line number: <b>203</b></td>
	</tr>

	<tr>
		<!--<xsl:text>NT_Bad_ProblemSectionCode_r11_v2.xml</xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Problem Section SHALL contain exactly one [1..1] code (CONF:15409)/@code=&quot;11450-4&quot; Problem List (CodeSystem: 2.16.840.1.113883.6.1 LOINC) (CONF:15410)<br/><b>/ClinicalDocument/component/structuredBody/component[9]/section</b><br/>Line number: <b>2639</b></td>
	</tr>

	<tr>
		<!--<xsl:text>NT_Bad_RaceCodeSystem_r11_v2.xml</xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol US Realm Header SHALL contain at least one [1..*] recordTarget, where its type is Record Target (CONF:5266) each SHALL contain exactly one [1..1] patientRole, where (CONF:5268) patient Role SHALL contain exactly one [1..1] patient, where (CONF:1198-5283) patient SHOULD contain zero or one [0..1] raceCode, which SHALL be selected from ValueSet Race 2.16.840.1.113883.1.11.14914 DYNAMIC (CONF:5322)<br/><b>/ClinicalDocument/recordTarget/patientRole/patient</b><br/>Line number: <b>120</b></td>
	</tr>

	<tr>
		<!--<xsl:text>NT_Missing_PatientLastName_r11_v2.xml</xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol US Realm Header SHALL contain at least one [1..*] recordTarget, where its type is Record Target (CONF:5266) each SHALL contain exactly one [1..1] patientRole, where (CONF:5268) patient Role SHALL contain exactly one [1..1] patient, where (CONF:1198-5283) each SHALL contain at least one [1..*] name (CONF:5284, CONF:10411, R2.1=CONF:1198-5284, DSTU:808) name SHALL contain exactly one [1..1] family (CONF:7159, R2.1=CONF:81-7159)<br/><b>/ClinicalDocument/recordTarget/patientRole/patient/name</b><br/>Line number: <b>124</b></td>
	</tr>

	<tr>
		<!--<xsl:text>NT_Missing_PatientName_r11_v2.xml</xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol US Realm Header SHALL contain at least one [1..*] recordTarget, where its type is Record Target (CONF:5266) each SHALL contain exactly one [1..1] patientRole, where (CONF:5268) patient Role SHALL contain exactly one [1..1] patient, where (CONF:1198-5283) patient SHALL contain at least one [1..*] name (CONF:5284, CONF:10411, R2.1=CONF:1198-5284, DSTU:808)<br/><b>/ClinicalDocument/recordTarget/patientRole/patient</b><br/>Line number: <b>120</b></td>
	</tr>
	
	<tr>
		<!--<xsl:text>NT_CP_Sample1_r21_v5.xml</xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol US Realm Header SHALL contain at least one [1..*] recordTarget, where its type is Record Target (CONF:5266) each SHALL contain exactly one [1..1] patientRole, where (CONF:5268) patient Role SHALL contain exactly one [1..1] patient, where (CONF:1198-5283) patient SHALL contain exactly one [1..1] administrativeGenderCode, which SHALL be selected from ValueSet Administrative Gender (HL7 V3) 2.16.840.1.113883.1.11.1 DYNAMIC (CONF:6394, R2.1=CONF:1198-6394)<br/><b>/ClinicalDocument/recordTarget/patientRole/patient</b><br/>Line number: <b>52</b></td>
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		 - Consol US Realm Header (V3) SHALL contain at least one [1..*] recordTarget, where its type is Record Target (CONF:1198-5266) each SHALL contain exactly one [1..1] patientRole, where (CONF:1198-5267) patient Role SHALL contain exactly one [1..1] patient, where (CONF:1198-5283) patient SHALL contain exactly one [1..1] raceCode, which SHALL be selected from ValueSet Race Category Excluding Nulls 2.16.840.1.113883.3.2074.1.1.3 DYNAMIC (CONF:1198-5322)<br/><b>/ClinicalDocument/recordTarget/patientRole/patient</b><br/>Line number: <b>52</b></td>
	</tr>
	<tr>
		 <td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol US Realm Header (V3) SHALL contain at least one [1..*] recordTarget, where its type is Record Target (CONF:1198-5266) each SHALL contain exactly one [1..1] patientRole, where (CONF:1198-5267) patient Role SHALL contain exactly one [1..1] patient, where (CONF:1198-5283) patient SHALL contain exactly one [1..1] ethnicGroupCode, which SHALL be selected from ValueSet EthnicityGroup 2.16.840.1.114222.4.11.837 DYNAMIC (CONF:1198-5323)<br/><b>/ClinicalDocument/recordTarget/patientRole/patient</b><br/>Line number: <b>52</b></td>	
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- The 'validateST' invariant is violated on 'org.eclipse.mdht.uml.hl7.datatypes.impl.ENXPImpl@434b4716{http:///resource32387.xml#//@clinicalDocument/@recordTarget.0/@patientRole/@patient/@name.0/@given.0}'<br/><b>/ClinicalDocument/recordTarget/patientRole/patient/name/given</b><br/>Line number: <b>55</b></td>
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- The 'validateST' invariant is violated on 'org.eclipse.mdht.uml.hl7.datatypes.impl.ENXPImpl@65ca4837{http:///resource32387.xml#//@clinicalDocument/@recordTarget.0/@patientRole/@patient/@name.0/@family.0}'<br/><b>/ClinicalDocument/recordTarget/patientRole/patient/name/family</b><br/>Line number: <b>59</b></td>
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- The 'validateST' invariant is violated on 'org.eclipse.mdht.uml.hl7.datatypes.impl.ENXPImpl@62250f75{http:///resource32387.xml#//@clinicalDocument/@recordTarget.0/@patientRole/@patient/@name.0/@suffix.0}'<br/><b>/ClinicalDocument/recordTarget/patientRole/patient/name/suffix</b><br/>Line number: <b>61</b></td>
		</tr>
	<tr>	
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Goals Section If section/@nullFlavor is not present, SHALL contain [1..*] entry such that it (CONF:1098-30719, CONF:1098-30720) Conforms to Goal Observation (templateId: 2.16.840.1.113883.10.20.22.4.121)<br/><b>/ClinicalDocument/component/structuredBody/component[16]/section</b><br/>Line number: <b>2168</b></td>
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Health Concerns Section (V2) If section/@nullFlavor is not present, SHALL contain [1..*] entry such that it (CONF:1198-30768, CONF:1198-30769) Conforms to Health Concern Act (templateId: 2.16.840.1.113883.10.20.22.4.132:2015-08-01)<br/><b>/ClinicalDocument/component/structuredBody/component[17]/section</b><br/>Line number: <b>2211</b></td>
	</tr>
	
	<tr>
		<!--<xsl:text>NT_CP_Sample2_r21_v4.xml</xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Health Concerns Section (V2) SHALL contain exactly one [1..1] code (CONF:1198-28806)/@code=&quot;75310-3&quot; Health concerns document (CodeSystem: 2.16.840.1.113883.6.1 LOINC) (CONF:1198-28807, CONF:1198-28808)<br/><b>/ClinicalDocument/component/structuredBody/component/section</b><br/>Line number: <b>433</b></td>
	</tr>
	<tr>
	<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Goals Section SHALL contain exactly one [1..1] code (CONF:1098-29586)/@code=&quot;61146-7&quot; Goals (CodeSystem: 2.16.840.1.113883.6.1 LOINC) (CONF:1098-29588)<br/><b>/ClinicalDocument/component/structuredBody/component[2]/section</b><br/>Line number: <b>736</b></td>
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Health Status Evaluations And Outcomes Section SHALL contain exactly one [1..1] code (CONF:1098-29580)/@code=&quot;11383-7&quot; Patient Problem Outcome (CodeSystem: 2.16.840.1.113883.6.1 LOINC) (CONF:1098-29581, CONF:1098-29582)<br/><b>/ClinicalDocument/component/structuredBody/component[4]/section</b><br/>Line number: <b>1237</b></td>
	</tr>
	
	<tr>
		<!--<xsl:text>NT_CP_Sample3_r21_v4.xml</xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Care Plan (V2) SHALL contain [1..1] component such that it (CONF:1198-28755, CONF:1198-28756) Conforms to Health Concerns Section (V2) (templateId: 2.16.840.1.113883.10.20.22.2.58:2015-08-01)<br/><b>/ClinicalDocument</b><br/>Line number: <b>14</b></td>
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Care Plan (V2) SHALL contain [1..1] component such that it (CONF:1198-28761, CONF:1198-28762) Conforms to Goals Section (templateId: 2.16.840.1.113883.10.20.22.2.60)<br/><b>/ClinicalDocument</b><br/>Line number: <b>14</b></td>
	</tr>
	
	<tr>
		<!--<xsl:text>NT_CP_Sample4_r21_v4.xml</xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Health Concerns Section (V2) If section/@nullFlavor is not present, SHALL contain [1..*] entry such that it (CONF:1198-30768, CONF:1198-30769) Conforms to Health Concern Act (templateId: 2.16.840.1.113883.10.20.22.4.132:2015-08-01)<br/><b>/ClinicalDocument/component/structuredBody/component/section</b><br/>Line number: <b>433</b></td>
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Goals Section If section/@nullFlavor is not present, SHALL contain [1..*] entry such that it (CONF:1098-30719, CONF:1098-30720) Conforms to Goal Observation (templateId: 2.16.840.1.113883.10.20.22.4.121)<br/><b>/ClinicalDocument/component/structuredBody/component[2]/section</b><br/>Line number: <b>735</b></td>
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Health Status Evaluations And Outcomes Section If section/@nullFlavor is not present, SHALL contain [1..*] entry such that it (CONF:1098-31227, CONF:1098-31228) Conforms to Outcome Observation (templateId: 2.16.840.1.113883.10.20.22.4.144)<br/><b>/ClinicalDocument/component/structuredBody/component[4]/section</b><br/>Line number: <b>1234</b></td>
	</tr>
	
	<!-- Additonal Files -->
	<tr>
		<!--<xsl:text>NT_Bad_AllergyConcernElements_r11_v3.xml</xsl:text>-->		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Allergy Problem Act SHALL contain exactly one [1..1] code (CONF:NEW) code /@code SHALL="CONC" Concern (CodeSystem: HL7ActClass 2.16.840.1.113883.5.6) or code/@code SHALL="48765-2" Allergies, adverse reactions, alerts (CodeSystem: LOINC 2.16.840.1.113883.6.1 STATIC) (CONF:NEW)<br/><b>/ClinicalDocument/component/structuredBody/component/section/entry[2]/act/code</b>
		Line number: <b>879</b></td>
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Allergy Problem Act SHALL contain exactly one [1..1] code (CONF:NEW) code /@code SHALL=&quot;CONC&quot; Concern (CodeSystem: HL7ActClass 2.16.840.1.113883.5.6) or code/@code SHALL=&quot;48765-2&quot; Allergies, adverse reactions, alerts (CodeSystem: LOINC 2.16.840.1.113883.6.1 STATIC) (CONF:NEW)<br/>
		<b>/ClinicalDocument/component/structuredBody/component/section/entry[3]/act/code</b>Line number: <b>1039</b></td>
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Allergy Problem Act SHALL contain exactly one [1..1] code (CONF:NEW) code /@code SHALL="CONC" Concern (CodeSystem: HL7ActClass 2.16.840.1.113883.5.6) or code/@code SHALL="48765-2" Allergies, adverse reactions, alerts (CodeSystem: LOINC 2.16.840.1.113883.6.1 STATIC) (CONF:NEW)<b>/ClinicalDocument/component/structuredBody/component/section/entry[4]/act/code</b>
		Line number: <b>1198</b></td>
	</tr>
		
	<tr>
		<!--<xsl:text>NT_Bad_AllergyIntoleranceObservationElements_r11_v3.xml</xsl:text>-->		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Allergy Problem Act SHALL contain [1..*] entryRelationship such that it (CONF:7509, CONF:7915, CONF:14925) Contains @typeCode=&quot;SUBJ&quot; SUBJ, and Conforms to Allergy Observation (templateId: 2.16.840.1.113883.10.20.22.4.7)<br/><b>/ClinicalDocument/component/structuredBody/component/section/entry/act</b><br/>
		Line number: <b>710</b></td>
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Substance Or Device Allergy Observation SHALL contain exactly one [1..1] value with @xsi:type="CD" (CONF:16312, R2.0=CONF:1098-16312), which SHALL be selected from ValueSet Allergy/Adverse Event Type 2.16.840.1.113883.3.88.12.3221.6.2 DYNAMIC (CONF:16317, R2.0=CONF:1098-16317)<br/>
		<b>/ClinicalDocument/component/structuredBody/component/section/entry[2]/act/entryRelationship/observation</b><br/>
		Line number: <b>893</b></td>
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Allergy Observation SHALL contain exactly one [1..1] value with @xsi:type="CD", which SHALL be selected from ValueSet Allergy/Adverse Event Type 2.16.840.1.113883.3.88.12.3221.6.2 DYNAMIC (CONF:7390, CONF:9139)<br/>
		<b>/ClinicalDocument/component/structuredBody/component/section/entry[2]/act/entryRelationship/observation</b>
		Line number: <b>893</b></td>
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Substance Or Device Allergy Observation SHALL contain exactly one [1..1] value with @xsi:type="CD" (CONF:16312, R2.0=CONF:1098-16312), which SHALL be selected from ValueSet Allergy/Adverse Event Type 2.16.840.1.113883.3.88.12.3221.6.2 DYNAMIC (CONF:16317, R2.0=CONF:1098-16317)<br/>
		<b>/ClinicalDocument/component/structuredBody/component/section/entry[3]/act/entryRelationship/observation</b>
		Line number: <b>1052</b></td>
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Allergy Observation SHALL contain exactly one [1..1] value with @xsi:type="CD", which SHALL be selected from ValueSet Allergy/Adverse Event Type 2.16.840.1.113883.3.88.12.3221.6.2 DYNAMIC (CONF:7390, CONF:9139)<br/>
		<b>/ClinicalDocument/component/structuredBody/component/section/entry[3]/act/entryRelationship/observation</b>
		Line number: <b>1052</b></td>
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Substance Or Device Allergy Observation SHALL contain exactly one [1..1] value with @xsi:type="CD" (CONF:16312, R2.0=CONF:1098-16312), which SHALL be selected from ValueSet Allergy/Adverse Event Type 2.16.840.1.113883.3.88.12.3221.6.2 DYNAMIC (CONF:16317, R2.0=CONF:1098-16317)<br/>
		<b>/ClinicalDocument/component/structuredBody/component/section/entry[4]/act/entryRelationship/observation</b>
		Line number: <b>1212</b></td>
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Allergy Observation SHALL contain exactly one [1..1] value with @xsi:type="CD", which SHALL be selected from ValueSet Allergy/Adverse Event Type 2.16.840.1.113883.3.88.12.3221.6.2 DYNAMIC (CONF:7390, CONF:9139)<br/>
		<b>/ClinicalDocument/component/structuredBody/component/section/entry[4]/act/entryRelationship/observation</b><br/>
		Line number: <b>1212</b></td>
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Allergy Observation SHOULD contain zero or one [0..1] participant, where its type is Participant (CONF:7402) each SHALL contain exactly one [1..1] participantRole, where (CONF:7404) each SHALL contain exactly one [1..1] playingEntity, where (CONF:7406) playingEntity code SHALL be selected from ValueSet Substance-Reactant for Intolerance 2.16.840.1.113762.1.4.1010.1 DYNAMIC. Note: Value set intentionally defined as a GROUPING made up of: Value Set: Medication Drug Class (2.16.840.1.113883.3.88.12.80.18) (NDFRT drug class codes); Value Set: Clinical Drug Ingredient (2.16.840.1.113762.1.4.1010.7) (RxNORM ingredient codes); Value Set: Unique Ingredient Identifier - Complete Set (2.16.840.1.113883.3.88.12.80.20) (UNII ingredient codes); Value Set: Substance Other Than Clinical Drug (2.16.840.1.113762.1.4.1010.9) (SNOMED CT substance codes). (CONF:7419)<br/>
		<b>/ClinicalDocument/component/structuredBody/component/section/entry[7]/act/entryRelationship/observation/participant/participantRole/playingEntity</b>
		Line number: <b>1724</b></td>
	</tr>
	<tr>
		<!--<xsl:text>NT_Bad_MedicationActivityElements_r11_v3.xml</xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>		
		- Consol Medication Activity MAY contain zero or one [0..1] routeCode (Route), which SHALL be selected from ValueSet Medication Route FDA Value Set 2.16.840.1.113883.3.88.12.3221.8.7 DYNAMIC (CONF:7514)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[5]/section/entry[4]/substanceAdministration</b><br/>
		Line number: <b>2750</b>
		</td>
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Medication Activity MAY contain zero or one [0..1] administrationUnitCode (Product Form), which SHALL be selected from ValueSet Medication Product Form Value Set 2.16.840.1.113883.3.88.12.3221.8.11 DYNAMIC (CONF:7519)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[5]/section/entry[5]/substanceAdministration</b><br/>
		Line number: <b>3089</b>
		</td>
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Medication Activity MAY contain zero or one [0..1] administrationUnitCode (Product Form), which SHALL be selected from ValueSet Medication Product Form Value Set 2.16.840.1.113883.3.88.12.3221.8.11 DYNAMIC (CONF:7519)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[5]/section/entry[6]/substanceAdministration</b><br/>
		Line number: <b>3428</b>
		</td>
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Medication Activity MAY contain zero or one [0..1] administrationUnitCode (Product Form), which SHALL be selected from ValueSet Medication Product Form Value Set 2.16.840.1.113883.3.88.12.3221.8.11 DYNAMIC (CONF:7519)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[5]/section/entry[7]/substanceAdministration</b><br/>
		Line number: <b>3767</b>
		</td>		
	</tr>
	<tr>
		<!--<xsl:text>NT_Bad_MedicationInformationElements_r11_v3.xml</xsl:text>-->		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Medication Activity SHALL contain exactly one [1..1] consumable (Medication Information), where its type is Consumable (CONF:7520) consumable SHALL contain exactly one [1..1] manufacturedProduct, where its type is Medication Information (CONF:16085)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[5]/section/entry/substanceAdministration/consumable</b><br/>
		Line number: <b>1775</b>	
		</td>
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Medication Information SHALL contain exactly one [1..1] manufacturedMaterial, where its type is Medication Information Manufactured Material (CONF:7411) manufacturedMaterial SHALL contain exactly one [1..1] code, which SHALL be selected from ValueSet Medication Clinical Drug Name Value Set 2.16.840.1.113883.3.88.12.80.17 DYNAMIC (CONF:7412)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[5]/section/entry[4]/substanceAdministration/consumable/manufacturedProduct/manufacturedMaterial</b><br/>
		Line number: <b>2800</b>
		</td>
	</tr>
	<tr>
		<!--<xsl:text>NT_Bad_PatientFirstName_r11_v2.xml</xsl:text>-->		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
			- The &quot;validateST&quot; invariant is violated on &quot;org.eclipse.mdht.uml.hl7.datatypes.impl.ENXPImpl@18eaeb7f{http:///resource32553.xml#//@clinicalDocument/@recordTarget.0/@patientRole/@patient/@name.0/@given.0}&quot;<br/><b>/ClinicalDocument/recordTarget/patientRole/patient/name/given</b>
			Line number: <b>127</b>
		</td>
	</tr>
	<tr>
		<!--<xsl:text>NT_Bad_ProblemConcernElements_r11_v3.xml</xsl:text>-->		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Problem Concern Act SHALL contain exactly one [1..1] code (CONF:9027)/@code="CONC" Concern (CodeSystem: 2.16.840.1.113883.5.6 HL7ActClass) (CONF:9440)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[9]/section/entry[2]/act</b><br/>
		Line number: <b>2814</b>
		</td>
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>		
		- Consol Problem Concern Act SHALL contain exactly one [1..1] code (CONF:9027)/@code="CONC" Concern (CodeSystem: 2.16.840.1.113883.5.6 HL7ActClass) (CONF:9440)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[9]/section/entry[3]/act</b><br/>
		Line number: <b>2966</b>
		</td>
	</tr>
	<tr>
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Problem Concern Act SHALL contain exactly one [1..1] code (CONF:9027)/@code="CONC" Concern (CodeSystem: 2.16.840.1.113883.5.6 HL7ActClass) (CONF:9440)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[9]/section/entry[4]/act</b><br/>
		Line number: <b>3118</b>
		</td>
	</tr>
	<tr>
		<!--<xsl:text>NT_Bad_ProblemObservationElements_r11_v3.xml</xsl:text>-->		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Problem Concern Act SHALL contain [1..*] entryRelationship such that it (CONF:15980) Contains @typeCode="SUBJ" SUBJ, and Conforms to Problem Observation (templateId: 2.16.840.1.113883.10.20.22.4.4)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[9]/section/entry/act</b><br/>
		Line number: <b>2662</b>
		</td>
	</tr>
	<tr>
		<!--<xsl:text>NT_Bad_ProblemSectionTemplateId_r11_v3.xml</xsl:text>-->		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Continuity Of Care Document SHALL contain [1..1] component such that it (CONF:9449) Conforms to Problem Section (templateId: 2.16.840.1.113883.10.20.22.2.5.1)<br/>
		<b>/ClinicalDocument</b><br/>
		Line number: <b>31</b>
		</td>
	</tr>
	<tr>
		<!--<xsl:text>NT_CCDS_Sample1_r21_v4.xml</xsl:text>-->		
	<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>		
	- Consol Allergies and Intolerances Section (entries required) (V3) SHALL contain exactly one [1..1] code (CONF:1198-15349)/@code="48765-2" Allergies, adverse reactions, alerts (CodeSystem: 2.16.840.1.113883.6.1 LOINC) (CONF:1198-15350, CONF:1198-32140)<br/>
	<b>/ClinicalDocument/component/structuredBody/component/section</b><br/>
	Line number: <b>400</b>
	</td>
	</tr>
	<tr>
	<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
	- Consol Medications Section2 SHALL contain exactly one [1..1] code (CONF:1098-15387)/@code="10160-0" History of medication use (CodeSystem: 2.16.840.1.113883.6.1 LOINC) (CONF:1098-15388, CONF:1098-30825)<br/>
	<b>/ClinicalDocument/component/structuredBody/component[2]/section</b><br/>
	Line number: <b>600</b>
	</td>
	</tr>
	<tr>	
	<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
	 - Consol Problem Section (V3) (entries required) SHALL contain exactly one [1..1] code (CONF:1198-15409)/@code="11450-4" Problem List (CodeSystem: 2.16.840.1.113883.6.1 LOINC) (CONF:1198-15410, CONF:1198-31142)<br/>
	<b>/ClinicalDocument/component/structuredBody/component[4]/section</b><br/>
	Line number: <b>873</b>
	</td>
	</tr>
	<tr>	
	<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
	 - Consol Encounters Section (entries required) (V3) SHALL contain exactly one [1..1] code (CONF:1198-15466)/@code="46240-8" Encounters (CodeSystem: 2.16.840.1.113883.6.1 LOINC) (CONF:1198-15467, CONF:1198-31137)<br/>
	<b>/ClinicalDocument/component/structuredBody/component[5]/section</b><br/>
	Line number: <b>1101</b>
	</td>
	</tr>
	<tr>	
	<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
	 - Consol Procedures Section2 SHALL contain exactly one [1..1] code (CONF:1098-15425)/@code="47519-4" History of Procedures (CodeSystem: 2.16.840.1.113883.6.1 LOINC) (CONF:1098-15426, CONF:1098-31138)<br/>
	<b>/ClinicalDocument/component/structuredBody/component[7]/section</b><br/>
	Line number: <b>1284</b>
	</td>
	</tr>
	<tr>	
	<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
	- Consol Immunizations Section (entries required) (V3) SHALL contain exactly one [1..1] code (CONF:1198-15369)/@code="11369-6" Immunizations (CodeSystem: 2.16.840.1.113883.6.1 LOINC) (CONF:1198-15370, CONF:1198-32147)<br/>
	<b>/ClinicalDocument/component/structuredBody/component[8]/section</b><br/>
	Line number: <b>1426</b>
	</td>
	</tr>
	<tr>	
	<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
	- Consol Vital Signs Section (entries required) (V3) SHALL contain exactly one [1..1] code (CONF:1198-15962)/@code="8716-3" Vital Signs (CodeSystem: 2.16.840.1.113883.6.1 LOINC) (CONF:1198-15963, CONF:1198-30903)<br/>
	<b>/ClinicalDocument/component/structuredBody/component[9]/section</b><br/>
	Line number: <b>1554</b>
	</td>
	</tr>
	<tr>	
	<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
	- Consol Social History Section (V3) SHALL contain exactly one [1..1] code (CONF:1198-14819)/@code="29762-2" Social History (CodeSystem: ) (CONF:1198-14820, CONF:1198-30814)<br/>
	<b>/ClinicalDocument/component/structuredBody/component[10]/section</b><br/>
	Line number: <b>1630</b>
	</td>
	</tr>
	<tr>	
	<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
	- Consol Results Section (entries required) (V3) SHALL contain exactly one [1..1] code (CONF:1198-15433)/@code="30954-2" Relevant diagnostic tests and/or laboratory data (CodeSystem: 2.16.840.1.113883.6.1 LOINC) (CONF:1198-15434, CONF:1198-31040)<br/>
	<b>/ClinicalDocument/component/structuredBody/component[11]/section</b><br/>
	Line number: <b>1709</b>
	</td>
	</tr>
	<tr>	
	<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
	- Consol Goals Section If section/@nullFlavor is not present, SHALL contain [1..*] entry such that it (CONF:1098-30719, CONF:1098-30720) Conforms to Goal Observation (templateId: 2.16.840.1.113883.10.20.22.4.121)<br/>
	<b>/ClinicalDocument/component/structuredBody/component[17]/section</b><br/>
	Line number: <b>2270</b>
	</td>
	</tr>
	<tr>	
	<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
	 - Consol Health Concerns Section (V2) If section/@nullFlavor is not present, SHALL contain [1..*] entry such that it (CONF:1198-30768, CONF:1198-30769) Conforms to Health Concern Act (templateId: 2.16.840.1.113883.10.20.22.4.132:2015-08-01)<br/>
	<b>/ClinicalDocument/component/structuredBody/component[18]/section</b><br/>
	Line number: <b>2313</b>
	</td>	
	</tr>
	<tr>
		<!--<xsl:text>NT_CCDS_Sample2_r21_v4.xml</xsl:text>-->		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>		
		 - Consol Continuity of Care Document (CCD) (V3) SHALL contain [1..1] component such that it (CONF:1198-30661, CONF:1198-30662) Conforms to Allergies and Intolerances Section (entries required) (V3) (templateId: 2.16.840.1.113883.10.20.22.2.6.1:2015-08-01)<br/>
		<b>/ClinicalDocument</b><br/>
		Line number: <b>17</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Continuity of Care Document (CCD) (V3) SHALL contain [1..1] component such that it (CONF:1198-30663, CONF:1198-30664) Conforms to Medications Section2 (templateId: 2.16.840.1.113883.10.20.22.2.1.1:2014-06-09)<br/>
		<b>/ClinicalDocument</b><br/>
		Line number: <b>17</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Continuity of Care Document (CCD) (V3) SHALL contain [1..1] component such that it (CONF:1198-30665, CONF:1198-30666) Conforms to Problem Section (V3) (entries required) (templateId: 2.16.840.1.113883.10.20.22.2.5.1:2015-08-01)<br/>
		<b>/ClinicalDocument</b><br/>
		Line number: <b>17</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Continuity of Care Document (CCD) (V3) SHALL contain [1..1] component such that it (CONF:1198-30669, CONF:1198-30670) Conforms to Results Section (entries required) (V3) (templateId: 2.16.840.1.113883.10.20.22.2.3.1:2015-08-01)<br/>
		<b>/ClinicalDocument</b><br/>
		Line number: <b>17</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>		
		- Consol Continuity of Care Document (CCD) (V3) SHALL contain [1..1] component such that it (CONF:1198-30687, CONF:1198-30688) Conforms to Social History Section (V3) (templateId: 2.16.840.1.113883.10.20.22.2.17:2015-08-01)<br/>
		<b>/ClinicalDocument</b><br/>
		Line number: <b>17</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Continuity of Care Document (CCD) (V3) SHALL contain [1..1] component such that it (CONF:1198-30689, CONF:1198-30690) Conforms to Vital Signs Section (entries required) (V3) (templateId: 2.16.840.1.113883.10.20.22.2.4.1:2015-08-01)<br/>
		<b>/ClinicalDocument</b><br/>
		Line number: <b>17</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Goals Section If section/@nullFlavor is not present, SHALL contain [1..*] entry such that it (CONF:1098-30719, CONF:1098-30720) Conforms to Goal Observation (templateId: 2.16.840.1.113883.10.20.22.4.121)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[17]/section</b><br/>
		Line number: <b>2262</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Health Concerns Section (V2) If section/@nullFlavor is not present, SHALL contain [1..*] entry such that it (CONF:1198-30768, CONF:1198-30769) Conforms to Health Concern Act (templateId: 2.16.840.1.113883.10.20.22.4.132:2015-08-01)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[18]/section</b><br/>
		Line number: <b>2305</b>	
		</td>		
	</tr>
	<tr>
		<!--<xsl:text>NT_CCDS_Sample3_r21_v4.xml</xsl:text>-->		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Allergies and Intolerances Section (entries required) (V3) If section/@nullFlavor is not present, SHALL contain [1..*] entry such that it (CONF:1198-7531, CONF:1198-15446) Conforms to Allergy Concern Act (V3) (templateId: 2.16.840.1.113883.10.20.22.4.30:2015-08-01)<br/>
		<b>/ClinicalDocument/component/structuredBody/component/section</b><br/>
		Line number: <b>400</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Medications Section2 If section/@nullFlavor is not present, SHALL contain [1..*] entry such that it (CONF:1098-7572, CONF:1098-10077) Conforms to Medication Activity2 (templateId: 2.16.840.1.113883.10.20.22.4.16:2014-06-09)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[2]/section</b><br/>
		Line number: <b>531</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Problem Section (V3) (entries required) If section/@nullFlavor is not present, SHALL contain [1..*] entry such that it (CONF:1198-9183, CONF:1198-15506) Conforms to Problem Concern Act (V3) (templateId: 2.16.840.1.113883.10.20.22.4.3:2015-08-01)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[4]/section</b><br/>
		Line number: <b>627</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Encounters Section (entries required) (V3) If section/@nullFlavor is not present, SHALL contain [1..*] entry such that it (CONF:1198-8709, CONF:1198-15468) Conforms to Encounter Activity (V3) (templateId: 2.16.840.1.113883.10.20.22.4.49:2015-08-01)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[5]/section</b><br/>
		Line number: <b>692</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Procedures Section2 If section/@nullFlavor is not present there SHALL be at least one entry conformant to Procedure Activity Act (V2) (templateId 2.16.840.1.113883.10.20.22.4.12:2014-06-09) OR Procedure Activity Observation (V2) (templateId: 2.16.840.1.113883.10.20.22.4.13:2014-06-09) OR Procedure Activity Procedure (V2) (templateId: 2.16.840.1.113883.10.20.22.4.14:2014-06-09)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[7]/section</b><br/>
		Line number: <b>875</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Immunizations Section (entries required) (V3) If section/@nullFlavor is not present, SHALL contain [1..*] entry such that it (CONF:1198-9019, CONF:1198-15495) Conforms to Immunization Activity (V3) (templateId: 2.16.840.1.113883.10.20.22.4.52:2015-08-01)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[8]/section</b><br/>
		Line number: <b>946</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Vital Signs Section (entries required) (V3) If section/@nullFlavor is not present, SHALL contain [1..*] entry such that it (CONF:1198-7276, CONF:1198-15964) Conforms to Vital Signs Organizer (V3) (templateId: 2.16.840.1.113883.10.20.22.4.26:2015-08-01)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[9]/section</b><br/>
		Line number: <b>1014</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Results Section (entries required) (V3) If section/@nullFlavor is not present, SHALL contain [1..*] entry such that it (CONF:1198-7112, CONF:1198-15516) Conforms to Result Organizer (V3) (templateId: 2.16.840.1.113883.10.20.22.4.1:2015-08-01)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[11]/section</b><br/>
		Line number: <b>1167</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Goals Section If section/@nullFlavor is not present, SHALL contain [1..*] entry such that it (CONF:1098-30719, CONF:1098-30720) Conforms to Goal Observation (templateId: 2.16.840.1.113883.10.20.22.4.121)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[17]/section</b><br/>
		Line number: <b>1560</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Health Concerns Section (V2) If section/@nullFlavor is not present, SHALL contain [1..*] entry such that it (CONF:1198-30768, CONF:1198-30769) Conforms to Health Concern Act (templateId: 2.16.840.1.113883.10.20.22.4.132:2015-08-01)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[18]/section</b><br/>
		Line number: <b>1603</b>
		</td>
	</tr>
	<tr>
		<!--<xsl:text>NT_CCDS_Sample4_r21_v4.xml</xsl:text>-->		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Substance Or Device Allergy Observation SHALL contain exactly one [1..1] value with @xsi:type="CD" (CONF:16312, R2.0=CONF:1098-16312), which SHALL be selected from ValueSet Allergy/Adverse Event Type 2.16.840.1.113883.3.88.12.3221.6.2 DYNAMIC (CONF:16317, R2.0=CONF:1098-16317)<br/>
		<b>/ClinicalDocument/component/structuredBody/component/section/entry/act/entryRelationship/observation</b><br/>
		Line number: <b>463</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Allergy Observation2 SHALL contain exactly one [1..1] value with @xsi:type="CD", which SHALL be selected from ValueSet Allergy/Adverse Event Type 2.16.840.1.113883.3.88.12.3221.6.2 DYNAMIC CONF:1098-7390)<br/>
		<b>/ClinicalDocument/component/structuredBody/component/section/entry/act/entryRelationship/observation</b><br/>
		Line number: <b>463</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Severity Observation SHALL contain exactly one [1..1] value (Severity Coded) with @xsi:type="CD", which SHALL be selected from ValueSet Problem Severity 2.16.840.1.113883.3.88.12.3221.6.8 DYNAMIC (CONF:7356, R2.0=CONF:1098-7356)<br/>
		<b>/ClinicalDocument/component/structuredBody/component/section/entry/act/entryRelationship/observation/entryRelationship/observation</b><br/>
		Line number: <b>501</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Encounter Diagnosis (V3) SHALL contain exactly one [1..1] code (CONF:1198-19182)/@code="29308-4" Diagnosis (CodeSystem: 2.16.840.1.113883.6.1 LOINC) (CONF:1198-19183, CONF:1198-32160)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[5]/section/entry/encounter/entryRelationship/act</b><br/>
		Line number: <b>1178</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Vital Signs Organizer (V3) SHALL contain exactly one [1..1] code (CONF:1198-32740)/@code="46680005" Vital Signs (CodeSystem: 2.16.840.1.113883.6.96 SNOMEDCT) (CONF:1198-32741, CONF:1198-32742) Compatibility support for C-CDA R1.1 and C-CDA 2.1: A vitals organizer conformant to both C-CDA 1.1 and C-CDA 2.1 would contain the SNOMED code (46680005) from R1.1 in the root code and a LOINC code in the translation. A vitals organizer conformant to only C-CDA 2.1 would only contain the LOINC code in the root code.<br/>
		<b>/ClinicalDocument/component/structuredBody/component[9]/section/entry/organizer</b><br/>
		Line number: <b>1591</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Tobacco Use2 SHALL contain exactly one [1..1] code (CONF:1098-19174)/@code="11367-0" History of tobacco use (CodeSystem: ) (CONF:1098-19175, CONF:1098-32172)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[10]/section/entry/observation</b><br/>
		Line number: <b>1673</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Tobacco Use SHALL contain exactly one [1..1] code (CONF:16560) code /@code SHALL="ASSERTION" Assertion (CodeSystem: 2.16.840.1.113883.5.4 HL7ActCode) OR code/@code SHALL="11367-0" History of tobacco use (CodeSystem: 2.16.840.1.113883.6.1 LOINC) (CONF:16560)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[10]/section/entry/observation/code</b><br/>
		Line number: <b>1680</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Smoking Status Meaningful Use2 SHALL contain exactly one [1..1] code (CONF:1098-19170)/@code="72166-2" Tobacco smoking status NHIS (CodeSystem: 2.16.840.1.113883.6.1 LOINC) (CONF:1098-31039, CONF:1098-32157, DSTU:596)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[10]/section/entry[2]/observation</b><br/>
		Line number: <b>1700</b>
		</td>	
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Smoking Status Meaningful Use2 SHALL contain exactly one [1..1] value with @xsi:type="CD" (CONF:1098-14810), which SHALL be selected from ValueSet Current Smoking Status 2.16.840.1.113883.11.20.9.38 STATIC 2014-09-01 (CONF:1098-14817)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[10]/section/entry[2]/observation</b><br/>
		Line number: <b>1700</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Smoking Status Observation SHALL contain exactly one [1..1] code (CONF:14808) code /@code SHALL="ASSERTION" Assertion (CodeSystem: 2.16.840.1.113883.5.4 HL7ActCode) OR code/@code SHALL="72166-2" Tobacco smoking status NHIS (CodeSystem: 2.16.840.1.113883.6.1 LOINC) (CONF:14808, DSTU:596)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[10]/section/entry[2]/observation/code</b><br/>
		Line number: <b>1707</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Goals Section If section/@nullFlavor is not present, SHALL contain [1..*] entry such that it (CONF:1098-30719, CONF:1098-30720) Conforms to Goal Observation (templateId: 2.16.840.1.113883.10.20.22.4.121)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[17]/section</b><br/>
		Line number: <b>2287</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Health Concerns Section (V2) If section/@nullFlavor is not present, SHALL contain [1..*] entry such that it (CONF:1198-30768, CONF:1198-30769) Conforms to Health Concern Act (templateId: 2.16.840.1.113883.10.20.22.4.132:2015-08-01)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[18]/section</b><br/>
		Line number: <b>2330</b>
		</td>
	</tr>
	<tr>
		<!--<xsl:text>NT_CCDS_Sample5_r21_v4.xml</xsl:text>-->
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>		
		- Consol US Realm Header SHALL contain at least one [1..*] recordTarget, where its type is Record Target (CONF:5266) each SHALL contain exactly one [1..1] patientRole, where (CONF:5268) patient Role SHALL contain exactly one [1..1] patient, where (CONF:1198-5283) patient SHALL contain exactly one [1..1] administrativeGenderCode, which SHALL be selected from ValueSet Administrative Gender (HL7 V3) 2.16.840.1.113883.1.11.1 DYNAMIC (CONF:6394, R2.1=CONF:1198-6394)<br/>
		<b>/ClinicalDocument/recordTarget/patientRole/patient</b><br/>
		Line number: <b>55</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol US Realm Header (V3) SHALL contain at least one [1..*] recordTarget, where its type is Record Target (CONF:1198-5266) each SHALL contain exactly one [1..1] patientRole, where (CONF:1198-5267) patient Role SHALL contain exactly one [1..1] patient, where (CONF:1198-5283) patient SHALL contain exactly one [1..1] raceCode, which SHALL be selected from ValueSet Race Category Excluding Nulls 2.16.840.1.113883.3.2074.1.1.3 DYNAMIC (CONF:1198-5322)<br/>
		<b>/ClinicalDocument/recordTarget/patientRole/patient</b><br/>
		Line number: <b>55</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol US Realm Header (V3) SHALL contain at least one [1..*] recordTarget, where its type is Record Target (CONF:1198-5266) each SHALL contain exactly one [1..1] patientRole, where (CONF:1198-5267) patient Role SHALL contain exactly one [1..1] patient, where (CONF:1198-5283) patient SHALL contain exactly one [1..1] ethnicGroupCode, which SHALL be selected from ValueSet EthnicityGroup 2.16.840.1.114222.4.11.837 DYNAMIC (CONF:1198-5323)<br/>
		<b>/ClinicalDocument/recordTarget/patientRole/patient</b><br/>
		Line number: <b>55</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- The 'validateST' invariant is violated on 'org.eclipse.mdht.uml.hl7.datatypes.impl.ENXPImpl@a32da2b{http:///resource32600.xml#//@clinicalDocument/@recordTarget.0/@patientRole/@patient/@name.0/@given.0}'<br/>
		<b>/ClinicalDocument/recordTarget/patientRole/patient/name/given</b><br/>
		Line number: <b>58</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		 - The 'validateST' invariant is violated on 'org.eclipse.mdht.uml.hl7.datatypes.impl.ENXPImpl@57f0ec70{http:///resource32600.xml#//@clinicalDocument/@recordTarget.0/@patientRole/@patient/@name.0/@family.0}'<br/>
		<b>/ClinicalDocument/recordTarget/patientRole/patient/name/family</b><br/>
		Line number: <b>62</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- The 'validateST' invariant is violated on 'org.eclipse.mdht.uml.hl7.datatypes.impl.ENXPImpl@6c21988c{http:///resource32600.xml#//@clinicalDocument/@recordTarget.0/@patientRole/@patient/@name.0/@suffix.0}'<br/>
		<b>/ClinicalDocument/recordTarget/patientRole/patient/name/suffix</b><br/>
		Line number: <b>64</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		- Consol Goals Section If section/@nullFlavor is not present, SHALL contain [1..*] entry such that it (CONF:1098-30719, CONF:1098-30720) Conforms to Goal Observation (templateId: 2.16.840.1.113883.10.20.22.4.121)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[17]/section</b><br/>
		Line number: <b>2272</b>
		</td>
	</tr>
	<tr>		
		<td style="border-bottom:.5pt solid lightblue;"><font style="font-family: verdana;color: red;font-size: 14px"><xsl:text>|Error</xsl:text></font>
		 - Consol Health Concerns Section (V2) If section/@nullFlavor is not present, SHALL contain [1..*] entry such that it (CONF:1198-30768, CONF:1198-30769) Conforms to Health Concern Act (templateId: 2.16.840.1.113883.10.20.22.4.132:2015-08-01)<br/>
		<b>/ClinicalDocument/component/structuredBody/component[18]/section</b><br/>
		Line number: <b>2315</b>
		</td>
	</tr>	
	</table>	
	</body>
	</html>
    </xsl:template>
	</xsl:stylesheet>