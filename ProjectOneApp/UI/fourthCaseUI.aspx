<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fourthCaseUI.aspx.cs" Inherits="ProjectOneApp.UI.fourthCaseUI" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Payment</title>
    <link href="../CSS/stylesheet.css" rel="stylesheet" />
</head>

<body>
<nav>
    <ul>
        <li><a href="#">Home</a></li>
        <li><a >Setup </a>
            <ul>
                <li><a href="indexUI.aspx">TestType</a></li>
                <li><a href="secondCaseUI.aspx">Test</a></li>
            </ul>
        </li>
        <li><a >Test Request</a>
            <ul>
                <li><a href="thirdCaseUI.aspx">Entry</a></li>
                <li><a href="fourthCaseUI.aspx">Payment</a></li>
            </ul>
        </li>
        <li><a >Report</a>
            <ul>
                <li><a href="TestNameSearch.aspx">Test Wise</a></li>
                <li><a href="TestTypeSearch.aspx">Type Wise</a></li>
                <li><a href="seventhCaseUI.aspx">Unpaid Bill</a></li>
            </ul>               
        </li>  
        <li><a href="#">About</a></li>
    </ul>        
</nav>

    <form id="form1" runat="server">

        <br />
        <br />
        <br />
        <br />

        <asp:Label ID="Label1" runat="server" Text="Bill No :"></asp:Label>
        <asp:TextBox ID="txtBill" runat="server"></asp:TextBox>

        <br />

        <asp:Label ID="Label5" runat="server" Text="  or"></asp:Label>

        <asp:Label ID="Label2" runat="server" Text="Mobile No. :"></asp:Label>
        <asp:TextBox ID="txtMobile" runat="server" TextMode="Number"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />

        <br />

        <asp:Label ID="Label3" runat="server" Text="Amount :"></asp:Label>
        <asp:TextBox ID="txtAmount" runat="server" ReadOnly="True" TextMode="Number"></asp:TextBox>

            <br />

            <asp:Label ID="Label4" runat="server" Text="Due Date :"></asp:Label>
            <asp:TextBox ID="txtDueDate" runat="server" ReadOnly="True"></asp:TextBox>
            <br />
            <asp:Button ID="btnPay" runat="server" OnClick="btnPay_Click" Text="Pay" />
            <br />
            <asp:Label ID="lblPayStatus" runat="server" ForeColor="#009900"></asp:Label>


        <asp:Label ID="lblWarning" runat="server" ForeColor="#FF3300"></asp:Label>


        <asp:GridView ID="GridViewDueBill" runat="server" Height="159px" OnSelectedIndexChanged="GridViewDueBill_SelectedIndexChanged" Width="686px">
        </asp:GridView>


    </form>

</body>

</html>