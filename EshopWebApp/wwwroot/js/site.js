﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
function Themechange() {
	var theme = document.getElementsByClassName("themeMode");
	var themecheckbox = document.getElementById("ThemeCheckbox");

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
}
function AddToCart(id) {
	let count = document.getElementById("Count" + id).value;
	let Cart = [];


	if (getCookie("Cart") != null) {
		console.log("stupid");
		Cart = JSON.parse(getCookie("Cart"));
	}

	console.log("nice 2");
	Cart.push(
		{
			'CartItem': {
				'ProductID': id,
				'Count': count
			}
		}
	);
	document.cookie = "Cart=" + JSON.stringify(Cart) + ";samesite=lax";
}

//https://stackoverflow.com/questions/10730362/get-cookie-by-name
function getCookie(name) {
	const value = `; ${document.cookie}`;
	const parts = value.split(`; ${name}=`);
	if (parts.length === 2) return parts.pop().split(';').shift();
}