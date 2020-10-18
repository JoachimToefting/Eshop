// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
function Themechange() {
	var theme = document.getElementsByClassName("themeMode");
	//var themecheckbox = document.getElementById("ThemeCheckbox");

	//if (themecheckbox.value == true) {
	//	document.cookie = "Theme=themeMode-black"
	//}
	//else {
	//	document.cookie = "Theme=themeMode-white"
	//}

	for (var i = 0; i < theme.length; i++) {
		theme[i].classList.toggle("themeMode-white");
		theme[i].classList.toggle("themeMode-black");
	}
}