<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="studentLogged.aspx.cs" Inherits="TestForm.ProjectsCS.LoggedIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

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
    <script src="JS/LoggedInJS.js"></script>
    <script src="JS/CSPPJQuery.js"></script>

</head>
<body>
    <header class="header-banner">

        <!-- DOM innerHTML navigation bar -->
        <div id="universal-navbar"></div>
         <form id="form2" runat="server">
            <div>
                <p>Hello Student</p>
                <asp:Button ID="UserLabel1" runat="server" Text="No user" />
                <asp:Button ID="logOutButton" runat="server" Text="Logout" onclick="logoutEventMethod" />

            </div>
        <main class="projectMain">
        <div class="container container-add">
            <h1 class="pageintroduction">Add Project</h1>
            <div id="formWrapper">
                <form name="AddProject" >

                    <div id="rowA" class="form-group">
                        <label for="ProjectName" class="label-Project">ProjectName</label>
                        <asp:TextBox ID="ProjectNameBox" Class="form-control" placeholder="Project Name" runat="server"></asp:TextBox>
                        <p id="ProjectName-error" class="customFormErrorText"></p>
                    </div>

                    <div id="rowe" class="form-group">
                        <label for="ProjectDescription" class="label-Project">ProjectDescription</label>
                        <asp:TextBox ID="projectDesBox" Class="form-control" placeholder="Project Descriptipn" runat="server"></asp:TextBox>
                        <p id="ProjectDescription-error" class="customFormErrorText"></p>

                    </div>
                    <div id="rowg" class="form-group">
                        <label for="Link" class="label-Project">Link</label>
                        <asp:TextBox ID="LinkBox" Class="form-control" placeholder="Link" runat="server"></asp:TextBox>
                        <p id="Authors-error" class="customFormErrorText"></p>

                    </div>
                    <div id="rowh" class="form-group">
                        <label for="UploadDate" class="label-Project">UploadDate </label>
                        <asp:TextBox ID="uploadBox" class="form-control" Rows="3" placeholder="has to be 10/2/2020" runat="server"></asp:TextBox>
                        <p id="UploadDate-error" class="customFormErrorText"></p>
                    </div>

                    <div id="rowi" class="form-group">
                        <label for="ProjectTag1" class="label-Project">ProjectTag1</label>
                        <asp:TextBox ID="projectTagBox" class="form-control" Rows="3" placeholder="ProjectTag1" runat="server"></asp:TextBox>
                        <p id="ProjectTag1-error" class="customFormErrorText"></p>
                    </div>
                    <div id="rowk" class="form-group">
                        <div class="col-sm">
                            <asp:Button ID="sumbit" Text="Submit" class="btn btn-dark btn-lg btn-form login-butto float-right" runat="server" OnClick="SubmitEventMethod" />
                        </div>
                    </div>
                </form>
                 <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            </div>
        </div>
    </main>
    </form>
      
        <!-- DOM innerHTML logo text -->
        <div id="universal-header"></div>

    </header>
    <footer class="footer-bg">
        <!-- DOM innerHTML footer -->
        <div id="universal-footer"></div>

    </footer>
</body>
</html>
