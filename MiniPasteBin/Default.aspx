<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MiniPasteBin.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="InsertTextBox" runat="server" TextMode="MultiLine" Height="271px" Width="403px"></asp:TextBox>
        <br />
        <br />
        <asp:CheckBox ID="Private" runat="server" Text="Private" />
        <br />
        <asp:Button ID="CreateNewPasteBinButton" runat="server" Text="Create" />
    </form>
</body>
</html>
