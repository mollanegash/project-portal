<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="TestForm.StudentList" %>
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
        .auto-style23 {
            text-align: center;
            color: #000099;
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
                <asp:Button ID="UserLabel1" runat="server" Text="No user" OnClick="UserLabel1_Click" />
                <asp:Button ID="loggoutButton" runat="server" Text="Logout" OnClick="logoutEventMethod" />
                <div class="table-container">
                    <h4 class="auto-style23"><strong>Student's List</strong></h4>
                    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

                    <asp:GridView ID="EmpGridView" ShowHeaderWhenEmpty="True" AutoGenerateColumns="false" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CssClass="auto-style8" OnSelectedIndexChanged="EmpGridView_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField HeaderText="Name" DataField="Fname" ItemStyle-Width="200">
                                <ItemStyle Width="200px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Lname" HeaderText="Last Name" ItemStyle-Width="200">
                                <ItemStyle Width="200px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="School" HeaderText="School" ItemStyle-Width="200">
                                <ItemStyle Width="200px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="email" HeaderText="Contact" ItemStyle-Width="200">
                                <ItemStyle Width="200px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="S_UID" HeaderText="Student ID" ItemStyle-Width="200">
                                <ItemStyle Width="200px"></ItemStyle>
                            </asp:BoundField> 
                             <asp:BoundField DataField="P_Name" HeaderText="Project Name" ItemStyle-Width="200">
                                <ItemStyle Width="200px"></ItemStyle>
                            </asp:BoundField> 
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="ButtonClick1" runat="server" Height="40px"
                                        Width="150px" Text="Delete" OnClick="ButtonClick1_Click"  />
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
                </div>
        </form>
              
    </header>
    <footer class="footer-bg">
		<!-- DOM innerHTML footer -->
		<div id="universal-footer"></div>
	</footer>
</body>
</html>

