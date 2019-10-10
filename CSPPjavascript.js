
//Onload  // DOM innerHTML stuff
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
			return false;
		}
		return true;
	}
}
