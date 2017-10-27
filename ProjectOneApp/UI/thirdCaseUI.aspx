<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="thirdCaseUI.aspx.cs" Inherits="ProjectOneApp.UI.thirdCaseUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Entry</title>
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
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Name of the Patient"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="nameOfThePatientTextBox" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="checkPatientHiddenField" runat="server" />
                    <asp:HiddenField ID="rowHiddenField" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Date Of Birth"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="dateOfBirthTextBox" runat="server" Width="182px" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Mobile No"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="mobileNoTextBox" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:Label ID="lblMobile" runat="server"></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Select Test"></asp:Label>
                    
                </td>
                <td>
                    <asp:DropDownList ID="testNameDropDownList" runat="server" OnSelectedIndexChanged="testNameDropDownList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Fee"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="feeTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    
                </td>
                <td>
                    <asp:Button ID="addButton" runat="server" Text="Add" OnClick="addButton_Click" />
                &nbsp;&nbsp;
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
                <asp:TemplateField HeaderText="Test">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("TestName")%>'>'></asp:Label>                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fee">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("Fee")%>'>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            

            </Columns>
            

        </asp:GridView>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Total"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="totalTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
                <td>
        <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" Width="74px" Visible="False" />
                    
                </td>
            </tr>
        </table>


    </form>
</body>
</html>
