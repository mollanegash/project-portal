<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FacultyLogged.aspx.cs" Inherits="TestForm.ProjectsCS.FacultyLogged " %>

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
	<header class ="header-banner">

		<!-- DOM innerHTML navigation bar -->
		<div id="universal-navbar"></div>
         <form id="form1" runat="server">
        <div>        
           <p>Hello Faculty</p>
           <asp:Button ID="UserLabel1" runat="server" Text="No user" />
           <asp:Button ID="loggoutButton" runat="server" Text="Logout" OnClick="logoutEventMethod" />    

        </div>
    </form>
                
		<!-- DOM innerHTML logo text -->
		<div id="universal-header"></div>
    
        
	</header>

</html>

