
//Onload  // DOM innerHTML stuff
window.onload = function () {

    document.getElementById("universal-navbar").innerHTML =
        '<div class="container-fluid">' +
        '<nav class="navbar">' +
        '<img class ="cs-logo" src="Images/Logo.png" alt="cs-portal-logo">' +
        '<button  class="navbar-toggler " type="button" data-toggle="collapse" data-target="#navbarTarget" aria-expanded="false">'
        + '<span class="icon-bar"></span> <span class="icon-bar"></span><span class="icon-bar"></span>'
        + '</button>' + '<div  id="navbarTarget" class="collapse">' +
        '<ul class="nav nav-fill "   >' +
        '<li class="nav-item">' +
        '<a class="nav-link nav-home" href="index.aspx" >Home</a>' +
        '</li>' +
        '<li class="nav-item">' +
        '<a class="nav-link nav-projectlist" href="ProjectList.aspx">Project List</a>' +
        '</li>' +
        '</li>' +
        '<li class="nav-item">' +
        '<a class="nav-link" href="registeration.aspx">Signup</a>' +
        '</li>' +
        '</ul>' +
        '</div>'
    '</nav>' +
        '</div>';

    document.getElementById("universal-header").innerHTML =
        '<div class="container-fluid">' +
        '<div class="container-header">' +
        '<h1 class="logo-header text-center">Computer Science Project Portal</h1>' +
        '</div>' +
        '<h3 class="sub-logo-header">CS673 Team 4</h3>' +

        '</div>';

    document.getElementById("universal-footer").innerHTML =
        '<div class="container-fluid">' +
        '<nav class="navbar  nav-footer navbar-expand-sm >' +
        ' <ul class="navbar-nav nav-footer">' +
        '<li class="nav-item " >' +
        '<a class="nav-link nav-item-footer" href="#"> About </a>' +
        '</li>' +
        '<li class="nav-item">' +
        '<a class="nav-link nav-item-footer" href="#">Contact Us </a>' +
        '</li>' +
        '<li class="nav-item">' +
        '<a class="nav-link nav-item-footer" href="#">Term of Use </a>' +
        '</li>' +
        '<li class="nav-item">' +
        '<a class="nav-link nav-item-footer" href="#">Policy </a>' +
        '</li>' +
        '</ul>' +
        '</nav>' +
        '<div class="right-footer">' +
        '<p>&copy; 2019     CSprojectportal.com<p>' +
        '</div>' +
        '	</div>' +
        '</div>';

}

$('.dropdown-menu li').on('click', function () {
    var getValue = $(this).text();
    $('.dropdown-select').text(getValue);
});

