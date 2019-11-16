
//Open ready	
$( window ).on( "load", function() {
	
	const hovershadow = "4px 12px 20px #525050"
		//#d7caf1  - was 0px 15px 20px #d7caf1
	const nop = "0px 0px 0px #000000"
	const dateingLabel = "#datinglabel"
	const relationshipslabel = "#relationshipslabel"
	const chooseservicetype = "#chooseservicetype"
	
	$( "#collapseeOne" ).hide();
	 $( "#collapseeTwo" ).hide();
	 $( "#collapseeThree" ).hide();
	 $( "#collapseeFour" ).hide();
	 $( "#collapseeFive" ).hide();
	 $( "#collapseeSix" ).hide();
	 
	 $( chooseservicetype ).css("border-bottom", "1px solid #525050");
	 $( chooseservicetype ).css("border-bottom-left-radius", ".3em");
	 $( chooseservicetype ).css("border-bottom-right-radius", ".3em");
	 $( "#relationshipServices" ).hide();
	 $( "#datingServices" ).hide(); 
	 
	 
	
//FAQs OnClick functions

	$( "div#headingg" ).hover(function() {
		$(this).css("box-shadow", hovershadow);
		}, function(){
		$(this).css("box-shadow", nop);
	});	

	$( "#headinggOne" ).click(function() {
		$( "#collapseeOne" ).toggle( "slow" );
	});	
	
	$( "#headinggTwo" ).click(function() {
		$( "#collapseeTwo" ).toggle( "slow" );
	});	
	
	$( "#headinggThree" ).click(function() {
		$( "#collapseeThree" ).toggle( "slow" );
	});	
	
	$( "#headinggFour" ).click(function() {
		$( "#collapseeFour" ).toggle( "slow" );
	});	
	
	$( "#headinggFive" ).click(function() {
		$( "#collapseeFive" ).toggle( "slow" );
	});	
	
	$( "#headinggSix" ).click(function() {
		$( "#collapseeSix" ).toggle( "slow" );
	});	
	

	
	
//Form OnClick functions	
	
	$( "div#imgRowHomePage img" ).hover(function() {
		$(this).css("box-shadow", hovershadow);
		}, function(){
		$(this).css("box-shadow", nop);
	});	
	
	$( "div#chooseservicetype label" ).hover(function() {
		$(this).css("box-shadow", hovershadow);
		}, function(){
		$(this).css("box-shadow", nop);
	});	
	
	$( "div#relationshipServices label" ).hover(function() {
		$(this).css("box-shadow", hovershadow);
		}, function(){
		$(this).css("box-shadow", nop);
	});	
	
	$( "div#datingServices label" ).hover(function() {
		$(this).css("box-shadow", hovershadow);
		}, function(){
		$(this).css("box-shadow", nop);
	});	
	
	$("#relationships").click(function() {
		//delete bottom border
		$(chooseservicetype).css("border-bottom", "0px solid #525050");	
		
		//Change Text Color
		$(relationshipslabel).css("color", "black");
		$(dateingLabel).css("color", "#636161");
		
		//Change Text Size
		//$(relationshipslabel).css("font-size", "35");
		//$(dateingLabel).css("font-size", "18");
		
		//Fancy Border
		$(dateingLabel).css("border-bottom", "1px solid #525050");
		$(dateingLabel).css("border-left", "1px solid #525050");
		$(dateingLabel).css("border-bottom-left-radius", ".3em");
		$(dateingLabel).css("background-color", "#525050");
		$(relationshipslabel).css("border-bottom", "0px solid #525050");
		$(relationshipslabel).css("border-right", "0px solid #525050");
		$(relationshipslabel).css("border-bottom-right-radius", ".3em");
		$(relationshipslabel).css("background-color", "#f6e6de");
		
		//Hide Actual Services
		$( "div#relationshipServices" ).show("slow");
		$( "div#datingServices" ).hide("slow");
		
		//deselect old values in dating and clear dating highilght
		$('#profileoverhaul').prop('checked', false); // Unchecks it
		$('#phoneorvideo').prop('checked', false); // Unchecks it
		$('#monthcommitment').prop('checked', false); // Unchecks it
		$("#profileoverhaulcard").css("background-color", "#f6e6de");
		$("#monthcommitmentcard").css("background-color", "#f6e6de");
		$("#phoneorvideocard").css("background-color", "#f6e6de");
		
	 });	
	
	$("#dating").click(function() {
		//delete bottom border
		$(chooseservicetype).css("border-bottom", "0px solid #525050");	
		
		//Change Text Color
		$(dateingLabel).css("color", "black");
		$(relationshipslabel).css("color", "#636161");
		
		//Change Text Size
		//$(dateingLabel).css("font-size", "35");
		//$(relationshipslabel).css("font-size", "18");
		
		//Fancy Border
		$(relationshipslabel).css("border-bottom", "1px solid #525050");
		$(relationshipslabel).css("border-right", "1px solid #525050");
		$(relationshipslabel).css("border-bottom-right-radius", ".3em");
		$(relationshipslabel).css("background-color", "#525050");
		$(dateingLabel).css("border-bottom", "0px solid #525050");
		$(dateingLabel).css("border-left", "0px solid #525050");
		$(dateingLabel).css("border-bottom-left-radius", ".3em");
		$(dateingLabel).css("background-color", "#f6e6de");
		
		//Hide Actual Services
		$( "div#datingServices" ).show("slow");
		$( "div#relationshipServices" ).hide("slow");
		
		//deselect old values in dating and clear dating highilght
		$('#relationshipsmonthcommitment').prop('checked', false); // Unchecks it
		$('#relationshipsphoneorvideo').prop('checked', false); // Unchecks it
		$("#relationshipsmonthcommitmentcard").css("background-color", "#f6e6de");
		$("#relationshipsphoneorvideocard").css("background-color", "#f6e6de");	
	  });

//Service Cards On click
	$( "#profileoverhaul" ).click(function() {
		if ($('#profileoverhaulcard input:checked').length == 0) {
			$("#profileoverhaulcard").css("background-color", "#f6e6de");	
		} else {
			$("#profileoverhaulcard").css("background-color", "#d7caf1");
		}
	});	

	$( "#relationshipsmonthcommitment" ).click(function() {
		if ($('#relationshipsmonthcommitmentcard input:checked').length == 0) {
			$("#relationshipsmonthcommitmentcard").css("background-color", "#f6e6de");	
		} else {
			$("#relationshipsmonthcommitmentcard").css("background-color", "#d7caf1");
		}
	});	

	$( "#relationshipsphoneorvideo" ).click(function() {
		if ($('#relationshipsphoneorvideocard input:checked').length == 0) {
			$("#relationshipsphoneorvideocard").css("background-color", "#f6e6de");	
		} else {
			$("#relationshipsphoneorvideocard").css("background-color", "#d7caf1");
		}
	});	


	$( "#phoneorvideo" ).click(function() {
		if ($('#phoneorvideocard input:checked').length == 0) {
			$("#phoneorvideocard").css("background-color", "#f6e6de");	
		} else {
			$("#phoneorvideocard").css("background-color", "#d7caf1");
		}
	});	


	$( "#monthcommitment" ).click(function() {
		if ($('#monthcommitmentcard input:checked').length == 0) {
			$("#monthcommitmentcard").css("background-color", "#f6e6de");	
		} else {
			$("#monthcommitmentcard").css("background-color", "#d7caf1");
		}
	});	

//Close ready
});



	


	  
 