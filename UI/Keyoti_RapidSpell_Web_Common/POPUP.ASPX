<%@ Page ClientTarget="uplevel" language="c#" validateRequest="false"  %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>Spell Checking</title>
		
		<style type="text/css">
		    body{overflow:hidden;}
		</style>
		<script language="C#" runat="server">
            void Page_Load(object sender, EventArgs e)
            {
                //For technical reasons relating to having to declare the exact assembly name, this version of popup.aspx uses code to add the
                //RapidSpellWeb control to the page - in a custom version of this, you could just use the RapidSpellWeb control tags.
                //Feel free to set properties in rapidSpellWeb1 as needed.
                Keyoti.RapidSpell.RapidSpellWeb rapidSpellWeb1 = new Keyoti.RapidSpell.RapidSpellWeb();
                rapidSpellWeb1.SSLFriendly = true;
                rapidSpellWeb1.Width = new Unit(100, UnitType.Percentage);

                Form1.Controls.Add(rapidSpellWeb1);
            }    
		</script>
		</head>
	<body>
		<div>
			<form method="post" runat="server" id="Form1">
			</form>
		</div>
	</body>
</html>
 