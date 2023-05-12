<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasteBins.aspx.cs" Inherits="MiniPasteBin.PasteBins" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MiniPasteBin</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="BackButton" runat="server" Text="Back" OnClick="BackButton_Click" />
        <br />
        <br />
        <br />
        <asp:TextBox ID="PasteBinTextBox" runat="server" TextMode="MultiLine" Height="271px" Width="403px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="CreationDatelabel" runat="server"></asp:Label> Creation date
        <br />
        <br />
        <asp:Label ID="LastVisitedLabel" runat="server"></asp:Label> Last visited
        <br />
        <br />
        <asp:Label ID="ExpirationDateLabel" runat="server"></asp:Label> Expiration date
    </form>
</body>
</html>
