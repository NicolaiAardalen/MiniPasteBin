<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasteBins.aspx.cs" Inherits="MiniPasteBin.PasteBins" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MiniPasteBin</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="PasteBinTextBox" runat="server" TextMode="MultiLine" Height="271px" Width="403px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="CreationDatelabel" runat="server"></asp:Label> CreationDate
        <br />
        <br />
        <asp:Label ID="LastVisitedLabel" runat="server"></asp:Label> LastVisited
        <br />
        <br />
        <asp:Label ID="ExpirationDateLabel" runat="server"></asp:Label> ExpirationDate
    </form>
</body>
</html>
