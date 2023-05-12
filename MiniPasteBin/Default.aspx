<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MiniPasteBin.Default" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MiniPasteBin</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="InsertTextBox" runat="server" TextMode="MultiLine" Height="271px" Width="403px"></asp:TextBox>
        <br />
        <br />
        <asp:CheckBox ID="PrivateCheckBox" runat="server" Text="Private"/>
        <br />
        <asp:TextBox ID="PrivatePasswordTextBox" runat="server" TextMode="Password"></asp:TextBox> Password
        <br />
        <br />
        <asp:CheckBox ID="BurnAfterRedingCheckBox" runat="server" Text="BurnAfterReding"/>
        <br />
        <br />
        <asp:Button ID="CreateNewPasteBinButton" runat="server" Text="Create" OnClick="CreateNewPasteBinButton_Click" />
        <br />
        <br />
        <br />
        <asp:DropDownList ID="BinsDropDown" runat="server" AutoPostBack="true"></asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="GoToBinButton" runat="server" Text="Go to selected bin" OnClick="GoToBinButton_Click" />
    </form>
</body>
</html>
