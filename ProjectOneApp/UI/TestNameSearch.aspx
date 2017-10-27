<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestNameSearch.aspx.cs" Inherits="ProjectArnobApp.UI.TestNameSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Name Wise</title>
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
    <div>
    
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
        <asp:Label ID="Label1" runat="server" Text="From Date"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="fromTextBox" runat="server" TextMode="Date" AutoCompleteType="Disabled"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="To Date"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="toTextBox" runat="server" TextMode="Date"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="showButtonTestNameSearch"  runat="server" Height="31px" OnClick="showButtonTestNameSearch_Click" Text="Show" Width="152px" />
        <br />
        <br />
        <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <asp:HiddenField ID="fromDateHiddenField" runat="server" />
        <asp:HiddenField ID="toDateHiddenField" runat="server" />

        <asp:GridView ID="TestNameSearchGridview" runat="server" Width="468px" AutoGenerateColumns="False" Height="154px" CellPadding="4" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="SL.">
                    <ItemTemplate>
                    <asp:Label ID="Label0" runat="server" Text='<%#Container.DataItemIndex+1 %>'>'></asp:Label>
                        
                        
                    </ItemTemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Test Name">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("TestName")%>'>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total Test">
                <ItemTemplate>                                                           
                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("TotalTest")%>'>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total Amount">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("TotalAmount")%>'>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                </Columns>
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
&nbsp;&nbsp;
        <asp:Button ID="pdfButtonTestNameSearch" runat="server" Height="36px" Text="PDF" Width="177px" OnClick="pdfButtonTestNameSearch_Click" Visible="False" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Total"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="totalTestNameSearch" runat="server" ReadOnly="True" Width="84px"></asp:TextBox>
    &nbsp;
        <br />
        <br />
&nbsp;
        </form>
</body>
</html>
