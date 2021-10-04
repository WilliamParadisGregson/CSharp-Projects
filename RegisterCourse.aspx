
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab_8.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="App_Themes/SiteStyles.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
        <h1>Algonquin College Course Registration</h1>
        <div>
            <p>
                Student:&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:DropdownList ID="studentDropdown" runat="server" CssClass="input" AutoPostBack="True" OnSelectedIndexChanged="studentDropdown_SelectedIndexChanged">
                    <asp:ListItem Value ="-1" Text="Select ..."></asp:ListItem>      
                </asp:DropdownList>
                <asp:Label runat="server" ID="studentError" Class="error" Visible="false"/>
            </p>
            
        </div>

        <div>
            <asp:Label runat="server" ID="registered" Text = "Selected student has registered 0 course(s), 0 hours weekly" CssClass="distinct" Visible="true"/>
        </div>

        <div runat="server" id="courseBox">
            <h2>Following courses are currently available for registration</h2>
            <br/>
            <asp:Label runat="server" ID="courseError" Class="error" Visible="false"/>
            <asp:CheckBoxList ID="courseList" runat="server"></asp:CheckBoxList>
        

            </br>

            <div>
                <asp:Button id="cmdOK" runat="server" Text="Save" Class="button" OnClick="cmdOK_Click" />
            </div> 
        </div>
        
        <div>
            <asp:Label runat="server" ID="registry" Class="distict" Visible="false"/>
            <br />
        </div>

        <asp:HyperLink ID="HyperLink2" NavigateUrl="AddStudent.aspx" runat="server">Add Students</asp:HyperLink>

    </form>
</body>
</html>
