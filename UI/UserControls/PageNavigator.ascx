<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PageNavigator.ascx.cs" Inherits="Acurus.Capella.UI.PageNavigator" %>

<asp:LinkButton ID="lbtnFirst" runat="server" onclick="lbtnFirst_Click">First</asp:LinkButton>
<asp:LinkButton ID="lbtnPrevious" runat="server" onclick="lbtnPrevious_Click">Previous</asp:LinkButton>
<asp:LinkButton ID="lbtnNext" runat="server" onclick="lbtnNext_Click">Next</asp:LinkButton>
<asp:LinkButton ID="lbtnLast" runat="server" onclick="lbtnLast_Click">Last</asp:LinkButton>

<asp:Label ID="lblShowing" runat="server" Text=""></asp:Label>


