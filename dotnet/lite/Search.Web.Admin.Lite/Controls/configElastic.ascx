<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="configElastic.ascx.cs" Inherits="Search.Web.Admin.Lite.Controls.configElastic" %>
<asp:Label ID="eUrl" runat="server" Text="Elastic URL:"></asp:Label>
<asp:TextBox runat="server" Text="http://localhost:9200"></asp:TextBox>
<br />
<asp:Label ID="lbl_siteMapName" runat="server" Text="Site Map Name"></asp:Label>
<asp:TextBox ID="txt_siteMapName" runat="server"></asp:TextBox>
<asp:Label ID="lbl_siteMapUrl" runat="server" Text="Site Map Url"></asp:Label>
<asp:TextBox ID="txt_siteMapUrl" runat="server"></asp:TextBox>
<asp:Button ID="btn_addSiteMap" runat="server"  Text="Add Site Map" />
<br />
<asp:Label ID="test" runat="server" Text="test"></asp:Label>
<br />
<br />
<asp:Label ID="lbl_rssName" runat="server" Text="RSS Feed Name"></asp:Label>
<asp:TextBox ID="txt_rssName" runat="server"></asp:TextBox>
<asp:Label ID="lbl_rssUrl" runat="server" Text="RSS Feed Url"></asp:Label>
<asp:TextBox ID="txt_rssUrl" runat="server"></asp:TextBox>
<asp:Button ID="btn_rss" runat="server"  Text="Add RSS Feed" />