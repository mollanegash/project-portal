<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="TestForm.ProjectsCS.ForgetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            width: 36%;
            height: 305px;
        }
        .auto-style4 {
            width: 260px;
        }
    </style>
</head>
<body style="width: 1696px; height: 166px">
      <div>
            <h1 class="auto-style2">Forgot Password</h1>
      </div>

    <form id="form1" runat="server">
      
        <table align="center" class="auto-style3">
            <tr>
                <td class="auto-style4">User Name</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Height="25px" Width="308px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Name</td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server" Height="25px" Width="308px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">New password</td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server" Height="25px" TextMode="Password" Width="308px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Confirm Password</td>
                <td>
                    <asp:TextBox ID="TextBox7" runat="server" Height="25px" TextMode="Password" Width="308px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Error" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Height="39px" OnClick="Button1_Click" Text="Reset Password" Width="156px" />
                </td>
            </tr>
        </table>
      
    </form>
    
</body>
</html>
