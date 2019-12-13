<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TestForm.index" %>


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
	<script src="JS/indexJs.js"></script>
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
		<main class="wrapper">
			<div class="container container-fluid">
				<div class="loginTitle">
					Account Login
				</div>
				<form class="form-container" runat="server">
					<div class="form-group">
						<label for="exampleInputEmail1" class="form-label">Email address</label>
                        <asp:TextBox ID="usernameTextBox" class="form-control" placeholder="Enter Email Address" runat="server" />

					</div>
					<div class="form-group">
						<label for="exampleInputPassword1" class="form-label">Password</label>
						<asp:TextBox ID="passwordTextBos" class="form-control" placeholder="Enter password" TextMode="Password" runat="server" />
					</div>
                    <div class="errorText" style="text-align:center">
                        <asp:Label ID="errorLogin" runat="server" Text=""></asp:Label>
                    </div>                
					<div  >
						<label class=""><a href="">Forgot your password ? </a></label>
					</div>
					<div class="btn-submit">
                            <asp:Button ID="submitButton" Text="Enter" class="enterBtn btn btn-dark" runat="server" onClick="SubmitEventMethod"/>
							<button class="loginBtn loginBtn--google">
								Google
							</button>
					</div>

				</form>
			</div>

		</main>
	</main>

	<footer class="footer-bg">
		<!-- DOM innerHTML footer -->
		<div id="universal-footer"></div>
	</footer>

</body>
</html>

