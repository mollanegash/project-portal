<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FacultyLogged.aspx.cs" Inherits="TestForm.ProjectsCS.FacultyLogged " %>

<%@ Register Assembly="AjaxControlToolKit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <!-- Required meta tags -->
    <meta name="description" content="WebDev" />
    <meta name="keywords" content="Computer Science Project Portal" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta charset="UTF-8" />

    <title>Computer Science Project Portal</title>

    <!-- Bootstrap css -->
    <link rel="stylesheet"
        href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
        integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T"
        crossorigin="anonymous" />
    <link href="https://fonts.googleapis.com/css?family=Be+Vietnam&display=swap" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>


    <!-- Custom CSS  - put last to override bootstrap where needed-->
    <link rel="stylesheet" href="CSS/CSPPstylesheet.css" />

    <script src="JS/jquery-3.3.1.js"></script>
    <script src="JS/FacultyLogged.js"></script>
    <script src="JS/CSPPJQuery.js"></script>

    <style type="text/css">
        .auto-style11 {
            width: 100%;
            margin-top: 10px;
            text-align: center;
            margin-left: auto;
            margin-right: auto;
            margin-bottom: auto;
        }
    </style>

</head>
<body>
    <header class="header-banner">

        <!-- DOM innerHTML navigation bar -->
        <div id="universal-navbar"></div>
        <form id="form1" runat="server">
            <div>
                <p>Hello Faculty</p>
                <asp:Button ID="UserLabel1" runat="server" Text="No user" OnClick="FacProfile_click" Style="height: 35px" />
                <asp:Button ID="loggoutButton" runat="server" Text="Logout" OnClick="logoutEventMethod" />
                <div class="auto-style11">
                    <h4 style="font-weight: bold; color: darkblue; margin-top: 30px;">ALL Student Projects</h4>
                    <br />
                    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
                    <div class="text-left">
                        
                             <asp:GridView ID="EmpGridView" ShowHeaderWhenEmpty="True" AutoGenerateColumns="false" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CssClass="auto-style8" OnSelectedIndexChanged="EmpGridView_SelectedIndexChanged" HorizontalAlign="Center" Width="1103px">
                        <Columns>
                            <asp:BoundField HeaderText="Name" DataField="Fname" ItemStyle-Width="200">
                                <ItemStyle Width="200px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Lname" HeaderText="Last Name" ItemStyle-Width="200">
                                <ItemStyle Width="200px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="P_Name" HeaderText="Project Name" ItemStyle-Width="200">
                                <ItemStyle Width="200px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Descrip" HeaderText="Description" ItemStyle-Width="200">
                                <ItemStyle Width="200px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Link" HeaderText="Link" ItemStyle-Width="200">
                                <ItemStyle Width="200px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="U_ID" HeaderText="Student ID" ItemStyle-Width="100">
                                <ItemStyle Width="200px"></ItemStyle>
                            </asp:BoundField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="ButtonClick1" runat="server" Height="40px"
                                        Width="150px" Text="View Detail" OnClick="ButtonClick1_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />
                    </asp:GridView>
                        
                    </div>

                    <asp:LinkButton ID="LinkButton1" runat="server" Style="display: none"></asp:LinkButton>
                    <asp:Panel ID="Panel1" runat="server" Height="319px" Width="600px" BackColor="White" BorderColor="Black" BorderStyle="Ridge" ForeColor="#003399">
                        <br />
                        <br />
                        <table>
                            <tr>
                                <td class="auto-style lblStyle">Student Name</td>
                                <td>
                                    <asp:Label class="auto-style7" ID="Label1" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style lblStyle">Student Lastname</td>
                                <td>
                                    <asp:Label class="auto-style7" ID="Label2" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table class="w-100">
                            <tr>
                                <td class="auto-style lblStyle">Project Name </td>
                                <td class="text-left">
                                    <asp:Label class="auto-style7" ID="Label3" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table class="w-100">
                            <tr>
                                <td class="auto-style lblStyle">Description</td>
                                <td class="text-left">
                                    <asp:Label class="auto-style7" ID="Label4" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table class="w-100">
                            <tr>
                                <td class="auto-style lblStyle">Link Project</td>
                                <td class="text-left">
                                    <asp:Label class="auto-style7" ID="Label5" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table class="w-100">
                            <tr>
                                <td class="auto-style lblStyle">Student ID</td>
                                <td class="text-left">
                                    <asp:Label class="auto-style7" ID="Label6" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table class="w-100">
                            <tr>
                                <td class="auto-style10">
                                    <asp:Button ID="Button1" runat="server" Text="ADD" OnClick="AddClick" Width="140px" />
                                </td>
                                <td class="auto-style10">
                                    <asp:Button ID="Button3" runat="server" Text="CANCLE" Width="140px" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <br />
                        <br />
                    </asp:Panel>
                    <ajax:ModalPopupExtender ID="ModalPopupExtender1" TargetControlID="LinkButton1" PopupControlID="Panel1" CancelControlID="Button3" BackgroundCssClass="modalBackground" runat="server"></ajax:ModalPopupExtender>
                </div>
            </div>
        </form>
         <br />
    <br />
    <br />
    </header >
   
                       
    <footer class="footer-bg">
        <!-- DOM innerHTML footer -->
        <div id="universal-footer"></div>
    </footer>
</body>

</html>

