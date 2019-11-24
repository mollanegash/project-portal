﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectList.aspx.cs" Inherits="TestForm.ProjectsCS.ProjectList" %>
<%@ Register Assembly="AjaxControlToolKit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">

    <!-- Required meta tags -->
    <meta name="description" content="WebDev">
    <meta name="keywords" content="Computer Science Project Portal">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta charset="UTF-8">

    <title>Computer Science Project Portal</title>

    <!-- Bootstrap css -->
    <link rel="stylesheet"
        href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
        integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T"
        crossorigin="anonymous">
    <link href="https://fonts.googleapis.com/css?family=Be+Vietnam&display=swap" rel="stylesheet">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>


    <!-- Custom CSS  - put last to override bootstrap where needed-->
    <link rel="stylesheet" href="CSS/CSPPstylesheet.css">

    <script src="JS/jquery-3.3.1.js"></script>
    <script src="JS/CSPPJQuery.js"></script>

</head>
<body>
<form class="form2" runat="server">
    <header class="header-banner">

        <!-- DOM innerHTML navigation bar -->
        <div id="universal-navbar">
            <div class="container-fluid">
                <nav class="navbar">
                    <img class="cs-logo" src="Images/Logo.png" alt="cs-portal-logo">
                    <button class="navbar-toggler " type="button" data-toggle="collapse" data-target="#navbarTarget" aria-expanded="false">
                        <span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span>
                    </button>
                    <div id="navbarTarget" class="collapse">
                        <ul class="nav nav-fill ">
                            <li class="nav-item"> 
                              <asp:LinkButton ID="hyperlinkRedireced" CssClass="nav-link" runat="server" OnClick="hyperlinkRedireced_Click">Home</asp:LinkButton>                                
                            </li>
                            <li class="nav-item">
                                <a class="nav-link nav-projectlist" href="ProjectList.aspx">Project List</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link nav-submit" href="submitsearch.cshtml">Search Project</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="registeration.aspx">Signup</a>
                            </li>
                        </ul>
                    </div>
                </nav>
            </div>
        </div>
            <div style="margin-top: 5%; ">
                <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" runat="server"></asp:ScriptManager>

                    <asp:GridView ID="EmpGridView" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CssClass="auto-style8" OnSelectedIndexChanged="EmpGridView_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField HeaderText="Project ID" DataField="P_ID" ItemStyle-Width="200">
                                <ItemStyle Width="200px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="P_Name" HeaderText="Project Name" ItemStyle-Width="200">
                                <ItemStyle Width="200px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="UploadDate" DataFormatString="{0:MM/dd/yy}" HeaderText="Upload Date" ItemStyle-Width="200">
                                <ItemStyle Width="200px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Link" HeaderText="Link" ItemStyle-Width="200">
                                <ItemStyle Width="200px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Tag" HeaderText="Tag" ItemStyle-Width="200">
                                <ItemStyle Width="200px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Descrip" HeaderText="Description" ItemStyle-Width="100">
                                <ItemStyle Width="200px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="UserID" HeaderText="Student ID" ItemStyle-Width="100">
                                <ItemStyle Width="200px"></ItemStyle>
                            </asp:BoundField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="EditButton1" runat="server" Height="40px"
                                        Width="150px" Text="View" OnClick="View_Click" />
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

                    <asp:LinkButton ID="LinkButton1" runat="server" Style="display: none"></asp:LinkButton>
                    <asp:Panel ID="Panel1" runat="server" Height="319px" Width="600px" BackColor="White" BorderColor="Black" BorderStyle="Ridge" ForeColor="#003399">
                        <br />
                        <br />
                        <table>
                            <tr>
                                <td class="auto-style lblStyle">Project Name</td>
                                <td>
                                    <asp:Label ID="lbl1" runat="server" CssClass="offset-sm-0" Width="400px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style lblStyle">Upload Date</td>
                                <td>
                                    <asp:Label ID="lbl2" runat="server" Width="400px"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table class="w-100">
                            <tr>
                                <td class="auto-style lblStyle">Link </td>
                                <td>
                                    <asp:Label ID="lbl3" runat="server" Width="400px"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table class="w-100">
                            <tr>
                                <td class="auto-style lblStyle">Tag</td>
                                <td>
                                    <asp:Label ID="lbl4" runat="server" Width="400px"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table class="w-100">
                            <tr>
                                <td class="auto-style lblStyle">Description</td>
                                <td>
                                    <asp:Label ID="lbl5" runat="server" Width="400px"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table class="w-100">
                            <tr>
                                <td class="auto-style10">
                                    <asp:Button ID="Button3" runat="server" Text="Close" Width="140px" OnClick="Button3_Click" />
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
      
    </header>
 </form>

    <footer class="footer-bg">
        <!-- DOM innerHTML footer -->
        <div id="universal-footer">

            <div class="container-fluid">
                <nav class="navbar  nav-footer navbar-expand-sm">
                    <ul class="navbar-nav nav-footer">
                        <li class="nav-item ">
                            <a class="nav-link nav-item-footer" href="#">About </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link nav-item-footer" href="#">Contact Us </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link nav-item-footer" href="#">Term of Use </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link nav-item-footer" href="#">Policy </a>
                        </li>
                    </ul>
                </nav>
                <div class="right-footer">
                    <p>
                        &copy; 2019     CSprojectportal.com<p>
                </div>
            </div>
        </div>
    </footer>


</body>
</html>