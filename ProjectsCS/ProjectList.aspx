<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectList.aspx.cs" Inherits="TestForm.ProjectsCS.ProjectList" %>

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

        <form class="form2" runat="server">
            
              <asp:GridView ID="GridView1" runat="server"></asp:GridView>
              
        </form>
       
	</header>

   
<footer class="footer-bg">
  <!-- DOM innerHTML footer -->
  <div id="universal-footer"></div>
</footer>


</body>
</html>


