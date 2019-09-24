
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
					  	'<a class="nav-link" href="addproject.html">Add Project</a>'+
					  '</li>'+
					   '<li class="nav-item">'+
					  	'<a class="nav-link" href="viewproject.html">View Projects</a>'+
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
		var name = document.getElementById("name");
		var email = document.getElementById("email");
		var cityOrState = document.getElementById("cityOrState");
		var age = document.getElementById("age");
		var loveLifeNow = document.getElementById("loveLifeNow");
		var strugNow = document.getElementById("strugNow");
		var ideally6Months = document.getElementById("ideally6Months");
		var timing = document.getElementById("timing");
		var killatend = false
		
		if (name.value.length < 2) {
			document.getElementById("name-error").innerHTML = "^^Sorry: Name must contain more than two (2) characters.";
			name.focus();
			killatend = true;
		} else {
			document.getElementById("name-error").innerHTML = "";
		}
		
			
		if (email.value.length < 2) {
			document.getElementById("email-error").innerHTML = "^^Sorry: email must contain more than two (2) characters.";
			email.focus();
			killatend = true;
		} 
		else if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(myForm.emailAddr.value)){
			document.getElementById("email-error").innerHTML = "";
		}else {
			document.getElementById("email-error").innerHTML = "^^Invalid Email Address";
			email.focus();
			killatend = true;
		}
		
		if (cityOrState.value.length < 2) {
			document.getElementById("cityOrState-error").innerHTML = "^^Sorry: City/State must contain more than two (2) characters.";
			cityOrState.focus();
			killatend = true;
		} else {
			document.getElementById("cityOrState-error").innerHTML = "";
		}
		
		if (loveLifeNow.value.length < 2) {
			document.getElementById("loveLifeNow-error").innerHTML = "^^Sorry: Love Life Now must contain more than two (2) characters.";
			loveLifeNow.focus();
			killatend = true;
		} else {
			document.getElementById("loveLifeNow-error").innerHTML = "";
		}
		
		if (strugNow.value.length < 2) {
			document.getElementById("strugNow-error").innerHTML = "^^Sorry: Struggles must contain more than two (2) characters.";
			strugNow.focus();
			killatend = true;
		} else {
			document.getElementById("strugNow-error").innerHTML = "";
		}
		
		if (ideally6Months.value.length < 2) {
			document.getElementById("ideally6Months-error").innerHTML = "^^Sorry: Goals must contain more than two (2) characters.";
			ideally6Months.focus();
			killatend = true;
		} else {
			document.getElementById("ideally6Months-error").innerHTML = "";
		}
		
		if (timing.value.length < 2) {
			document.getElementById("timing-error").innerHTML = "^^Sorry: Timing must contain more than two (2) characters.";
			timing.focus();
			killatend = true;
		} else {
			document.getElementById("timing-error").innerHTML = "";
		}
		
		if (age.value.match(alphaExp)) {
			document.getElementById("age-error").innerHTML = "^^Sorry: Please only enter numbers for age";
			age.focus();
			killatend = true;
		} else {
			document.getElementById("age-error").innerHTML = "";
		}
		
		if (age.value.length != 2) {
			document.getElementById("age-error").innerHTML = "^^Sorry: Age must be two (2) intigers.";
			age.focus();
			killatend = true;
		} else {
			document.getElementById("age-error").innerHTML = "";
		}
		
		//How to evaluate check boxes and radio buttons.  
		
		//Three Check button groups
			//Gender
				if ($('#rowf input:checked').length == 0) {
					document.getElementById("gender-error").innerHTML = "^^Sorry: Please choose a gender.";
					killatend = true;
				}else {
					document.getElementById("gender-error").innerHTML = "";
				}
			//Services
				if ($('#relationshipServices input:checked').length == 0 & $('#datingServices input:checked').length == 0) {
					document.getElementById("service-error").innerHTML = "^^Sorry: Please choose a service.";
					killatend = true;
				}else {
					document.getElementById("service-error").innerHTML = "";
				}
		//One radio group to check, choose
				//if ($('#chooseservicetype input:checked').length == 0) {
				//	document.getElementById("chooseservicetype-error").innerHTML = "Sorry: Please choose a gender.";
				//	//chooseservicetype.focus();
				//	killatend = true;
				//}else {
				//	document.getElementById("chooseservicetype-error").innerHTML = "";
				//}
		
		
		
		if (killatend != false){
			return false
		} 
		return true;
	}
	
	


	  
 