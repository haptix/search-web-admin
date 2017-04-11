<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Search.Web.Admin.Lite.Index" %>
<%@ Register TagPrefix="uc" TagName="configElastic" Src="~/Controls/configElastic.ascx" %>
<%@ Register Src="~/Controls/SearchAdminSettingsModule.ascx" TagPrefix="uc" TagName="SearchAdminSettingsModule" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div>
        <form id="form1" runat="server">
            <uc:SearchAdminSettingsModule runat="server" ID="SearchAdminSettingsModule" />
        </form>
    </div>
</body>
</html>
