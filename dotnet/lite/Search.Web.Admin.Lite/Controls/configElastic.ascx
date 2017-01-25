<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="configElastic.ascx.cs" Inherits="Search.Web.Admin.Lite.Controls.configElastic" %>
<asp:Label ID="lbl_eUrl" runat="server" Text="Elastic URL:"></asp:Label>
<asp:TextBox ID="txt_eUrl" runat="server" Text="http://localhost:9200"></asp:TextBox>
<br />
<asp:Label ID="lbl_aliasName" runat="server" Text="Alias Name"></asp:Label>
<asp:TextBox ID="txt_aliasName" runat="server"></asp:TextBox>
<asp:Label ID="lbl_aliasLocation" runat="server" Text="Alias Location"></asp:Label>
<asp:TextBox ID="txt_aliasLocation" runat="server"></asp:TextBox>
<asp:Label ID="lbl_aliasType" runat="server" Text="Alias Type"></asp:Label>
<asp:TextBox ID="txt_aliasType" runat="server"></asp:TextBox>
<asp:Label ID="lbl_aliasCollection" runat="server" Text="Alias Collection Name"></asp:Label>
<asp:TextBox ID="txt_aliasCollection" runat="server"></asp:TextBox>
<asp:Button ID="btn_addAlias" runat="server"  Text="Add Alias" OnClick="addIndexAlias" />
<br />
<asp:Label ID="lbl_aliasResults" runat="server" Text="aliasResults"></asp:Label>
<br />  
<asp:Label ID="lbl_siteMapName" runat="server" Text="Site Map Name"></asp:Label>
<asp:TextBox ID="txt_siteMapName" runat="server"></asp:TextBox>
<asp:Label ID="lbl_siteMapUrl" runat="server" Text="Site Map Url"></asp:Label>
<asp:TextBox ID="txt_siteMapUrl" runat="server"></asp:TextBox>
<asp:Label ID="lbl_siteMapIndexPath" runat="server" Text="Site Map Index Path"></asp:Label>
<asp:TextBox ID="txt_siteMapIndexPath" runat="server"></asp:TextBox>
<asp:Button ID="btn_addSiteMap" runat="server"  Text="Add Site Map" OnClick="addSiteMap" />
<br />
<asp:Label ID="lbl_siteMapResults" runat="server" Text="siteMapResults"></asp:Label>
<br />
<br />
<asp:Label ID="lbl_rssName" runat="server" Text="RSS Feed Name"></asp:Label>
<asp:TextBox ID="txt_rssName" runat="server"></asp:TextBox>
<asp:Label ID="lbl_rssUrl" runat="server" Text="RSS Feed Url"></asp:Label>
<asp:TextBox ID="txt_rssUrl" runat="server"></asp:TextBox>
<asp:Label ID="lbl_rssIndexPath" runat="server" Text="RSS Index Path"></asp:Label>
<asp:TextBox ID="txt_rssIndexPath" runat="server"></asp:TextBox>
<asp:Button ID="btn_rss" runat="server"  Text="Add RSS Feed" OnClick="addRssFeed" />
<br />
<asp:Label ID="lbl_rssResults" runat="server" Text="rssResults"></asp:Label>
<br />
<br />
