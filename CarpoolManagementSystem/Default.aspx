<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home : Carpool Management</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="NameTextBox" placeholder="What is your name?" runat="server"></asp:TextBox>
        <asp:Button ID="OKButton" runat="server" Text="Ok" onClick="SubmitNameMethod"/>
    </div>
    </form>
</body>
</html>
