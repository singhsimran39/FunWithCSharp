﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengeFirstPapaBobsWebsite.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style2 {
            color: #FF0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>
            <asp:Image ID="bobImage" runat="server" ImageUrl="~/PapaBob.png" />
&nbsp;<span class="auto-style1">Papa Bob&#39;s Pizza and Software</span></h1>
            <asp:RadioButton ID="babyBobRadioButton" runat="server" GroupName="PizzaSize" Text="Baby Bob Size (10&quot;) - $10" />
        <br />
        <asp:RadioButton ID="mamaBobRadioButton" runat="server" GroupName="PizzaSize" Text="Mama Bob Size (13&quot;) - $13" />
        <br />
        <asp:RadioButton ID="papaBobRadioButton" runat="server" GroupName="PizzaSize" Text="Papa Bob Size (16&quot;) - $16" />
            &nbsp;<br />
        <br />
        <asp:RadioButton ID="thinCrustRadioButton" runat="server" GroupName="PizzaCrust" Text="Thin Crust" />
        <br />
        <asp:RadioButton ID="DeepDishRadioButton" runat="server" GroupName="PizzaCrust" Text="Deep Dish (+$2)" />
        <br />
        <br />
        <asp:CheckBox ID="pepperoniCheckBox" runat="server" Text="Peperoni (+$1.50)" />
        <br />
        <asp:CheckBox ID="onionsCheckBox" runat="server" Text="Onions (+$0.75)" />
        <br />
        <asp:CheckBox ID="greenPeppersCheckBox" runat="server" Text="Green Peppers (+$0.50)" />
        <br />
        <asp:CheckBox ID="redPeppersCheckBox" runat="server" Text="Red Peppers (+$0.75)" />
        <br />
        <asp:CheckBox ID="anchoviesCheckBox" runat="server" Text="Anchovies (+$2)" />
        <br />
        <br />
        <span class="auto-style1"><strong>Papa Bob&#39;s <span class="auto-style2">Special Deal</span></strong></span><br />
&nbsp;<br />
        Save $2 when you add Pepperoni, Green Pepper and Anchovies OR Pepperoni, Red Peppers and Onions to your pizza.<br />
        <br />
        <asp:Button ID="purchaseButton" runat="server" OnClick="purchaseButton_Click" Text="Purchase" />
        <br />
        <br />
        Total:&nbsp; $<asp:Label ID="priceLabel" runat="server"></asp:Label>
        <br />
        <br />
        Sorry, at this time you can only order one pizza online, and pick-up only ... we need a better website!</div>
    </form>
</body>
</html>
