<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="secondCaseUI.aspx.cs" Inherits="ProjectOneApp.UI.secondCase" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Type</title>
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
        
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Test Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="testNameTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Fee"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="feeTextBox" runat="server" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="BDT"></asp:Label>
                    
                </td>
            </tr>
            
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Test Type"></asp:Label>
                    
                </td>
                <td>
                    <asp:DropDownList ID="testTypeDropDownList" runat="server"></asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>
                    
                </td>
                <td>
                    <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="messageLabel" runat="server" ForeColor="#FF3300"  ></asp:Label>
                </td>
            </tr>

        </table>
        
        <asp:GridView runat="server" ID="testSetupGridView" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Sl">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%#Container.DataItemIndex+1%>'>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Test Name">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("TestName")%>'>'></asp:Label>                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FEE">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("Fee")%>'>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Type">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("TestTypeName")%>'>'></asp:Label>                        
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            

        </asp:GridView>

        <div>
        </div>
    </form>
</body>
</html>
