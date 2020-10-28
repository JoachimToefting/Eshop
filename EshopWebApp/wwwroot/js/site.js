// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
function Themechange() {
	var theme = document.getElementsByClassName("themeMode");
	var themecheckbox = document.getElementById("ThemeCheckbox");

	if (themecheckbox.checked == true) {
		document.cookie = "Theme=themeMode-black;samesite=lax;path=/";
	}
	else {
		document.cookie = "Theme=themeMode-white;samesite=lax;path=/";
	}

	for (var i = 0; i < theme.length; i++) {
		theme[i].classList.toggle("themeMode-white");
		theme[i].classList.toggle("themeMode-black");
	}
}
function AddToCart(id) {
	let count = document.getElementById("Count" + id).value;
	let Cart = [];


	if (count != "") {
		if (getCookie("Cart") != null) {
			Cart = JSON.parse(decodeURIComponent(getCookie("Cart")));
		}
		Cart.push(
			{
				'ProductID': id,
				'Count': parseInt(count)
			}
		);
		document.cookie = "Cart=" + encodeURIComponent(JSON.stringify(Cart)) + ";samesite=lax";
		UpdateCartCount();
		alert("You have added product to your cart");
	}
}
function UpdateCartCount() {
	var cartcountObject = document.getElementById("cartcount");
	var cartcount = 0;
	var Cart = []
	if (getCookie("Cart") != null) {
		Cart = JSON.parse(decodeURIComponent(getCookie("Cart")));
	}
	for (var i = 0; i < Cart.length; i++) {
		cartcount = cartcount + Cart[i]["Count"];
	}
	cartcountObject.innerText = cartcount;
	
}

//https://stackoverflow.com/questions/10730362/get-cookie-by-name
function getCookie(name) {
	const value = `; ${document.cookie}`;
	const parts = value.split(`; ${name}=`);
	if (parts.length === 2) return parts.pop().split(';').shift();
}