<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="indexUI.aspx.cs" Inherits="ProjectOneApp.UI.indexUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test</title>

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
                    <asp:Label ID="Label1" runat="server" Text="Type Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="typeNameTextBox" runat="server"></asp:TextBox>
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
        <asp:GridView runat="server" ID="typeNameGridView" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Sl">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%#Container.DataItemIndex+1%>'>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Type Name">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("TypeName")%>'>'></asp:Label>                        
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            

        </asp:GridView>
&nbsp;
    </form>
</body>
</html>
