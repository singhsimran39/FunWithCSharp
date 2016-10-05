<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MegaChallengeCasino.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Currency:&nbsp;
        <asp:DropDownList ID="currencyDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="currencyDropDownList_SelectedIndexChanged">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>USD</asp:ListItem>
            <asp:ListItem>GBP</asp:ListItem>
            <asp:ListItem>EUR</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
    
        <asp:Image ID="firstImage" runat="server" Height="150px" />
        <asp:Image ID="secondImage" runat="server" Height="150px" />
        <asp:Image ID="thirdImage" runat="server" Height="150px" />
        <br />
        <br />
        Your Bet:&nbsp; 
        <asp:TextBox ID="yourBetTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="leverButton" runat="server" OnClick="leverButton_Click" Text="Pull the Lever!" />
        <br />
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
        <br />
        <br />
        Player&#39;s Money: <asp:Label ID="moneyLabel" runat="server"></asp:Label>
        <br />
        <br />
        1 Cherry - x2 Your Bet<br />
        2 Cherries - x3 Your Bet<br />
        3 Cherries - x4 Your Bet<br />
        3 7&#39;s - Jackpot - x100 Your Bet<br />
        HOWEVER ... if there&#39;s even one BAR you win nothing..</div>
    </form>
</body>
</html>
