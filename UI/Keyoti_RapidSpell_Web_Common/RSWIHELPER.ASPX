<%@ Page language="c#"  validateRequest="false"  %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<script language="C#" runat="server">
            void Page_Load(object sender, EventArgs e)
            {
                //For technical reasons relating to having to declare the exact assembly name, this version of rswihelper.aspx uses code to add the
                //RapidSpellWInlineHelper control to the page - in a custom version of this, you could just use the RapidSpellWInlineHelper control tags.
                //Feel free to set properties in rapidSpellWInlineHelper1 as needed.
                Keyoti.RapidSpell.RapidSpellWInlineHelper rapidSpellWInlineHelper1 = new Keyoti.RapidSpell.RapidSpellWInlineHelper();
                Form1.Controls.Add(rapidSpellWInlineHelper1);
            }    
		</script>
</head>
	<body>
		<form id="Form1" method="post" runat="server">			
		</form>
	</body>
</html>
