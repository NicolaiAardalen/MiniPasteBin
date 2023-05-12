<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordPrivate.aspx.cs" Inherits="MiniPasteBin.PasswordPrivate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="BackButton" runat="server" Text="Back" OnClick="BackButton_Click" />
        <br />
        <br />
        <br />
        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox> Password
        <br />
        <br />
        <asp:Button ID="CheckPasswordButton" runat="server" Text="Log in" OnClick="CheckPasswordButton_Click" />
    </form>
</body>
</html>