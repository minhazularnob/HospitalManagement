<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="seventhCaseUI.aspx.cs" Inherits="ProjectOneApp.UI.seventhCaseUI" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Seventh Case</title>
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
        <br />

        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="From Date"></asp:Label>
        <asp:TextBox ID="txtFromDate" runat="server" TextMode="Date"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="To Date"></asp:Label>
        <asp:TextBox ID="txtToDate" runat="server" TextMode="Date"></asp:TextBox>
        <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="Show" />
        <br />
        <br />
        <br />
        <asp:Label ID="lblMessege" runat="server" ForeColor="#CC3300"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="GridViewUnpaidBill" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <br />
        <br />
        <br />
        <asp:Button ID="btnPdf" runat="server" Text="PDF" OnClick="btnPdf_Click" Visible="False" />
        <asp:Label ID="Label4" runat="server" Text="Total"></asp:Label>
        <asp:TextBox ID="txtTotal" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />

    </form>

</body>

</html>