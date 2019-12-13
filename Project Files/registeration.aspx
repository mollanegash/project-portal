<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registeration.aspx.cs" Inherits="TestForm.registeration" %>

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
	<script src="JS/CSPPjavascript.js"></script>
	<script src="JS/CSPPJQuery.js"></script>

</head>
<body>
	<header class ="header-banner">

		<!-- DOM innerHTML navigation bar -->
		<div id="universal-navbar"></div>
		<!-- DOM innerHTML logo text -->
		<div id="universal-header"></div>
	</header>

  <main >
    <div class="container">
      <div class="form-container">
          <h3><strong>Sign up Form</strong></h3>
        <div class="col-md-12 col-xs-offset-1 col-sm-offset-2 col-md-8 col-md-offset-2">
          <form class="form-horizontal" runat="server">
            <br>
            <fieldset class="fieldset-box">
              <div class="form-group">
                <label for="name" class="cols-sm-2 control-label">Name</label>
                <div class="col-md-8">
                  <asp:TextBox ID="firstnameTextBox" class="form-control" placeholder="Enter your first name" runat="server" />
                </div>
              </div>
              <div class="form-group">
                <label for="lastName" class="cols-sm-2 control-label">Last Name</label>
                <div class="col-md-8">
                  <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-envelope fa" aria-hidden="true"></i></span>
                   <asp:TextBox ID="lastNameTextBox" class="form-control" placeholder="Enter your last name" runat="server" />
                  </div>
                </div>
              </div>

              <div class="form-group">
                <label for="school" class="cols-sm-2 control-label">School</label>
                <div class="col-md-8">
                  <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-users fa" aria-hidden="true"></i></span>
                    <asp:TextBox ID="schoolTextBox" class="form-control" placeholder="Enter your school" runat="server" />
                  </div>
                </div>
              </div>

              <div class="form-group">
                <label for="occupation" class="cols-sm-2 control-label">Occupation</label>
                <div class="col-md-8">
                  <div class="dropdown">
                    <asp:DropDownList ID="DropDownList1" class="form-control" runat="server">
                        <asp:ListItem value ="0" runat="server">Select</asp:ListItem>
                        <asp:ListItem runat="server">Student</asp:ListItem>
                        <asp:ListItem runat="server">Faculty</asp:ListItem>
                    </asp:DropDownList>
                  </div>
                </div>
              </div>
              <script src="JS/CSPPjavascript.js"></script>
              <div class="form-group">
                <label for="username" class="cols-sm-2 control-label">Email</label>
                <div class="col-md-8">
                  <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-lock fa-lg" aria-hidden="true"></i></span>
                    <asp:TextBox ID="usernameTextBox" class="form-control" placeholder="Enter your email" runat="server" />
                  </div>
                </div>
              </div>

              <div class="form-group">
                <label for="password" class="cols-sm-2 control-label">Password</label>
                <div class="col-md-8">
                  <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-lock fa-lg" aria-hidden="true"></i></span>
                     <asp:TextBox ID="passwordTextBox" class="form-control" placeholder="Enter your password" TextMode="Password" runat="server" />
                  </div>
                </div>
              </div>

              <div class="form-group">
                <label for="confirmPass" class="cols-sm-2 control-label">Confirm Password</label>
                <div class="col-md-8">
                  <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-lock fa-lg" aria-hidden="true"></i></span>
                    <asp:TextBox ID="confirmPasswordTextBox" class="form-control" placeholder="Confirm your password" TextMode="Password" runat="server" />
                  </div>
                </div>
              </div>
              <div class="form-group ">
                <asp:Button ID="registerButton" Text="Register" class="enterBtn btn btn-dark btn-lg btn-form" runat="server" onClick="RegisterEventMethod"/>
              </div>
                <div class="errorText">
                    <asp:Label ID="lblErrorMessage" runat="server"  Text=""></asp:Label>
                </div>  
            </fieldset>
              <asp:GridView ID="GridView1" runat="server"></asp:GridView>
          </form>    
        </div>
      </div>
    </div>
     

      
  </main>

<footer class="footer-bg">
  <!-- DOM innerHTML footer -->
  <div id="universal-footer"></div>
</footer>


</body>
</html>