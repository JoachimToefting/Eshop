// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
function Themechange() {
	console.log("js start");
	var theme = document.getElementsByClassName("themeMode");
	var themecheckbox = document.getElementById("ThemeCheckbox");

	console.log(themecheckbox.checked);
	if (themecheckbox.checked == true) {
		document.cookie = "Theme=themeMode-black;samesite=lax";
	}
	else {
		document.cookie = "Theme=themeMode-white;samesite=lax";
	}

	for (var i = 0; i < theme.length; i++) {
		theme[i].classList.toggle("themeMode-white");
		theme[i].classList.toggle("themeMode-black");
	}
	console.log("cookie changes")
}