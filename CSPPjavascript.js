
//Onload  // DOM innerHTML stuff
	window.onload = function() {	 
	 
	
		document.getElementById("universal-navbar").innerHTML =
			 '<div class="container-fluid">'+
				 '<nav>'+
				    '<ul class="nav nav-fill">'+
					  '<li class="nav-item">'+
					  	'<a class="nav-link" href="index.html">Home</a>'+
					  '</li>'+
					  '<li class="nav-item">'+
					  	'<a class="nav-link" href="addproject.cshtml">Add Project</a>'+
					  '</li>'+
					   '<li class="nav-item">'+
					  	'<a class="nav-link" href="searchresults.cshtml">Projects List</a>'+
					  '</li>'+
					   '</li>'+
					   '<li class="nav-item">'+
					  	'<a class="nav-link" href="submitsearch.cshtml">Search</a>'+
					  '</li>'+
					'</ul>'+
				'</nav>'+
			 '</div>';
		 
		 document.getElementById("universal-header").innerHTML =
			'<div class="container-fluid">'+
				'<div class="container-header">'+
					'<img class ="cs-logo" src="Logo.png" alt="cs-portal-logo">'+
					'<h1 class="logo-header text-center">Computer Science Project Portal</h1>'+
				'</div>'+
				'<h3 class="sub-logo-header">CS673 Team 4</h3>'+
				
			'</div>';
		 
		 document.getElementById("universal-footer").innerHTML =
			'<div class="container text-center footer">'+
					'<nav class="">'+
						'<ul class="">'+
							'<li class="" >'+
								'<a class="" href="#">About |</a>'+
							'</li>'+
							'<li class="">'+
								'<a class="" href="#">Contact Us |</a>'+
							'</li>'+
							'<li class="">'+
								'<a class="" href="#">Term of Use |</a>'+
							'</li>'+
							'<li class="">'+
								'<a class="" href="#">Policy |</a>'+
							'</li>'+
						'</ul>'+
					'</nav>'+

						'<p>CSprojectportal.com<p>'+

			'</div>';
		 

}
