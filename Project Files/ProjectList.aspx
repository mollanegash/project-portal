<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectList.aspx.cs" Inherits="TestForm.ProjectsCS.ProjectList" %>
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

    <style type="text/css">
        .auto-style11 {
            margin-left: 138;
        }
        .auto-style16 {
            width: 99%;
            height: 107px;
        }
        .auto-style17 {
            width: 192px;
        }
        .auto-style21 {
            margin-left: 0;
            margin-top: 0;
        }
        .auto-style22 {
            margin-left: 61;
        }
    </style>

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
                                <a class="nav-link" href="registeration.aspx">Signup</a>
                            </li>
                        </ul>
                    </div>
                </nav>
            </div>
        </div>
            <div style="margin-top: 5%; " class="text-center">
                
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="222px" style="margin-right: 50px">
                    <asp:ListItem>Select Search</asp:ListItem>
                    <asp:ListItem>Author Name</asp:ListItem>
                    <asp:ListItem>Project Name</asp:ListItem>
                    <asp:ListItem>Project ID</asp:ListItem>
                    <asp:ListItem>Project Tag</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="TextBox1" runat="server" placeholder="Type Search" CssClass="auto-style11" Height="30px" Width="295px" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                <br/>
                <br />
                
                <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" runat="server"></asp:ScriptManager>
                <h4 style="font-weight: bold; color: darkblue; margin-bottom: 30px; " class="text-center"> Projects list</h4>
                    <asp:GridView ID="EmpGridView" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CssClass="auto-style8" OnSelectedIndexChanged="EmpGridView_SelectedIndexChanged" Height="255px" HorizontalAlign="Center" Width="1285px" AllowPaging="True" OnSelectedIndexChanging="EmpGridView_SelectedIndexChanging" style="margin-top: 0px" OnPageIndexChanging="EmpGridView_PageIndexChanging" PageSize="6" AllowCustomPaging="True">
                        <Columns>
                            <asp:BoundField  DataField="P_ID" HeaderText="Project ID" ItemStyle-Width="200">
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
                            <asp:BoundField DataField="FName" HeaderText="Student Name" ItemStyle-Width="100">
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
                    
                    </asp:GridView>

                    <asp:LinkButton ID="LinkButton1" runat="server" Style="display: none"></asp:LinkButton>
                    <div class="text-left">
                    <asp:Panel ID="Panel1" runat="server" Height="345px" Width="678px" BackColor="White" BorderColor="White" BorderStyle="Ridge" ForeColor="#003399" ScrollBars="Vertical">
                        <br />
                        <br />
                        <table>
                            <tr>
                                <td class="auto-style lblStyle">Project ID</td>
                                <td>
                                    <asp:Label ID="lbl0" runat="server" CssClass="offset-sm-0" Width="400px"></asp:Label>
                                </td>
                            </tr>
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
                        
                        <div class="text-left lblStyle">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                     <asp:Label ID="Label4" runat="server" Text="Comment" Font-Bold="True" ForeColor="Black" BackColor="#FFFF99"></asp:Label>
                            <br />
                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                            <ItemTemplate>                        
                                <br />
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("ComName") %>'></asp:Label>
                                <br />
                        <asp:Label ID="Label2"  runat="server" Text='<%#Eval("DateComment", "{0:MM/dd/yy}") %>'></asp:Label>
                                <br />
                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("CommentText") %>'></asp:Label>
                                   <br />
                            </ItemTemplate>
                    
                        </asp:Repeater>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                           
                        </div>
                       <br />
                        <table class="w-100">
                            <tr>
                                <td class="auto-style17 lblStyle"> Name</td>
                                <td>
                                    <asp:TextBox ID="TextName" runat="server" CssClass="offset-sm-0" Height="27px" Width="310px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table class="auto-style16">
                            <tr>
                                <td class="auto-style17 lblStyle"> Comment</td>
                                <td>
                                    <asp:TextBox ID="TextComment" runat="server" CssClass="auto-style21" Height="68px" Width="310px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table class="w-100">
                            <tr>
                                <td class="text-center">
                                   
                                    <asp:Button class="auto-style17 lblStyle" ID="Comment" runat="server" Text="ADD COMMENT" Width="237px" OnClick="Comment_Click1" Height="40px" />
                                                                    
                                </td>
                                <td>
                                    <asp:Button class="auto-style17 lblStyle" ID="Button3" runat="server" Text="CLOSE" Width="210px"  OnClick="Button3_Click" CssClass="auto-style22" Height="41px" />   
                                </td>
                            </tr>
                        </table>
                         <table class="w-100">
                            <tr>
                                <td class="auto-style10">

                                    &nbsp;</td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <br />
                        <br />
                    </asp:Panel>
                    </div>
                    <ajax:ModalPopupExtender ID="ModalPopupExtender1" TargetControlID="LinkButton1" PopupControlID="Panel1" CancelControlID="Button3" BackgroundCssClass="modalBackground" runat="server"></ajax:ModalPopupExtender>
                </div>
        
       <br/>
    <br/>
    </header>
 </form>
   

    <footer class="footer-bg">
        <!-- DOM innerHTML footer -->
        <div id="universal-footer">

            <div class="container-fluid">
                <nav class="navbar  nav-footer navbar-expand-sm">
                    <ul class="navbar-nav nav-footer">
                        <li class="nav-item ">
                            <a class="nav-link nav-item-footer" href="#">About                 </li>
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
