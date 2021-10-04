<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Lab_8.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>Students</h1>
        <div>
            <p>
                Student Name:&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:TextBox runat="server" ID="stuName" CssClass="input"></asp:TextBox>
                <asp:Label runat="server" ID="nameError" Class="error" Visible="false"/>
            </p>

            <p>
                Student Type:&nbsp;&nbsp;&nbsp;&nbsp;

                <asp:DropdownList ID="dropdown" runat="server" CssClass="input">
                    <asp:ListItem Value ="-1" Text="Select ..."></asp:ListItem>    
                    <asp:ListItem Value ="0" Text="Full Time Student"></asp:ListItem>    
                    <asp:ListItem Value ="1" Text="Part Time Student"></asp:ListItem>    
                    <asp:ListItem Value ="2" Text="Co-op Student"></asp:ListItem>    
                </asp:DropdownList>
                <asp:Label runat="server" ID="dropError" Class="error" Visible="false"/>
            </p>
        </div>

        <div>
            <asp:Button id="cmdOK" runat="server" Text="Add" Class="button" OnClick="cmdOK_Click" />
        </div> 

        <div>
            <asp:Table ID="tblStudent" runat="server" CssClass="table"> 
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
        <asp:HyperLink ID="HyperLink1" NavigateUrl="RegisterCourse.aspx" runat="server">Register Courses</asp:HyperLink>
    </form>
</body>
</html>
