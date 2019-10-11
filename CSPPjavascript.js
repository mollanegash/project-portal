
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
				'<h1 class="logo-header text-center">Computer Science Project Portal<span class="tinyheader">M.Ed</span></h1>'+
				'<h3 class="sub-logo-header text-center">CS673 Team 4</h3>'+
			'</div>';
		 
		 document.getElementById("universal-footer").innerHTML =
			'<div class="container text-center footer">'+
				'<p>common footer . . .</p>'+
			'</div>';
		 
		 document.getElementById("universal-services").innerHTML =
				 '<div id="chooseservicetype" class="chooseservicetype">'+
				    '<div class="row">'+
				    	'<div id="relationshipslabel" class="col-sm float-left servicesbuttons">'+
							'<label for="relationships">'+
							'<input class="form-check-input" type="radio" id="relationships" name="servicetype" value="Relationship Services">'+
							'<span class="pageintroduction">Relationships</span>'+
							'</label>'+
				    	'</div>'+
				    	'<div id="datinglabel" class="col-sm float-right servicesbuttons">'+
						  	'<label  for="dating">'+
						  	'<input class="form-check-input" type="radio" id="dating" name="servicetype" value="Dating Services">'+
						  	'<span class="pageintroduction">Dating</span>'+
						  	'</label>'+
				    	'</div>'+
				    '</div>'+
			    '</div>'+
			  '<div id="relationshipServices" class="relationshipServices">'+
				  '<div class="row">'+
					  '<div class="col-md">'+
					    '<div id="relationshipsphoneorvideocard" class="servicescards">'+
					      '<label class="form-check-label" for="relationshipsphoneorvideo">'+
					      '<span class="card-tittle">Phone or Video Sessions</span>'+
					      '<span class="card-textt price">$90</span>'+
					      '<span class="card-textt">One hour coaching sessions. </span>'+
					      '<input type="checkbox" name="relationshipsservice" id="relationshipsphoneorvideo" value="RS: Phone or Video">'+
					      '</label>'+
					    '</div>'+
					  '</div>'+
					  '<div class="col-md">'+
					    '<div id="relationshipsmonthcommitmentcard" class="servicescards">'+
					      '<label class="form-check-label" for="relationshipsmonthcommitment">'+
					      '<span class="card-tittle">3 Month Commitment</span>'+
					      '<span class="card-textt price">$1,900</span>'+
					      '<span class="card-textt">Includes daily accountability texts, homework via email, and weekly one-hour video or phone sessions.</span>'+
					      '<input type="checkbox" name="relationshipsservice" id="relationshipsmonthcommitment" value="RS: 3 Month Commitment!">'+
					      '</label>'+
					    '</div>'+
					  '</div>'+
				   '</div>'+
				'</div>'+
				'<div id="datingServices" class="datingServices">'+
					'<div class="row">'+
					  '<div class="col-md">'+
					    '<div id="profileoverhaulcard" class="servicescards">'+
					      '<label class="form-check-label" for="profileoverhaul">'+
					      '<span class="card-tittle">Profile Overhaul</span>'+
					      '<span class="card-textt price">$199</span>'+
					      '<span class="card-textt">A one time service that '+
					      'offers profile photo suggestions, edits and rewrites or creates new dating profile.  Includes '+
					     '30-60 minute phone consult.</span>'+
					      '<input type="checkbox" name="datingservice" id="profileoverhaul" value="Dt: Profile Overhaul">'+
					      '</label>'+
					   '</div>'+
					  '</div>'+
					  '<div class="col-md">'+
					    '<div id="phoneorvideocard" class="servicescards">'+
					      '<label class="form-check-label" for="phoneorvideo">'+
					      '<span class="card-tittle">Phone/Video Coaching</span>'+
						  '<span class="card-textt price">$90</span>'+
						  '<span class="card-textt">One hour coaching sessions.</span>'+
						  '<input type="checkbox" name="datingservice" id="phoneorvideo" value="Dt: Phone/Video">'+
					      '</label>'+
					    '</div>'+
					  '</div>'+
					  '<div class="col-md">'+
					    '<div id="monthcommitmentcard" class="servicescards">'+
					      '<label class="form-check-label" for="monthcommitment">'+
					      '<span class="card-tittle">3 Month Commitment</span>'+
					      '<span class="card-textt price">$1,900</span>'+
					      '<span class="card-textt">One Hour coaching once per week, daily accountability texts,'+ 
					      'profile overhaul, image consulting, and more.</span>'+
					      '<input type="checkbox" name="datingservice" id="monthcommitment" value="Dt: 3 Month Commitment!">'+
					      '</label>'+
					    '</div>'+
					  '</div>'+
					'</div>'+
				'</div>';	
	}

//Validate Form
	function validateForm() {
		var alphaExp = /^[a-zA-Z]+$/;
		var ProjectNumber = document.getElementById("ProjectNumber");
		var ProjectName = document.getElementById("ProjectName");
		var ProjectDescription = document.getElementById("ProjectDescription");
		var Authors = document.getElementById("Authors");
		var UploadDate = document.getElementById("UploadDate");
		var ProjectTag1 = document.getElementById("ProjectTag1");
		var killatend = false
		
		if (ProjectNumber.value.length < 1) {
			document.getElementById("ProjectNumber-error").innerHTML = "^^Sorry: Name must have 1 digit.";
			ProjectNumber.focus();
			killatend = true;
		} else {
			document.getElementById("ProjectNumber-error").innerHTML = "";
		}
		
			
		if (ProjectName.value.length < 2) {
			document.getElementById("ProjectName-error").innerHTML = "^^Sorry: email must contain more than two (2) characters.";
			ProjectName.focus();
			killatend = true;
		} else {
			document.getElementById("ProjectName-error").innerHTML = "";
		}
		
		
		if (ProjectDescription.value.length < 2) {
			document.getElementById("ProjectDescription-error").innerHTML = "^^Sorry: City/State must contain more than two (2) characters.";
			ProjectDescription.focus();
			killatend = true;
		} else {
			document.getElementById("ProjectDescription-error").innerHTML = "";
		}		
		if (Authors.value.length < 2) {
			document.getElementById("Authors-error").innerHTML = "^^Sorry: Love Life Now must contain more than two (2) characters.";
			Authors.focus();
			killatend = true;
		} else {
			document.getElementById("Authors-error").innerHTML = "";
		}
		
		if (UploadDate.value.length < 2) {
			document.getElementById("UploadDate-error").innerHTML = "^^Sorry: Struggles must contain more than two (2) characters.";
			strugNow.focus();
			killatend = true;
		} else {
			document.getElementById("UploadDate-error").innerHTML = "";
		}
		
		if (ProjectTag1.value.length < 2) {
			document.getElementById("ProjectTag1-error").innerHTML = "^^Sorry: Goals must contain more than two (2) characters.";
			ProjectTag1.focus();
			killatend = true;
		} else {
			document.getElementById("ProjectTag1-error").innerHTML = "";
		}
		
		if (killatend != false){
			return false;
		}
		return true;
	}
}
