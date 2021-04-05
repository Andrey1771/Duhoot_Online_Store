let houseFilter = document.getElementById('houseFilter');
let girlFilter = document.getElementById('girlFilter');
let hatFilter = document.getElementById('hatFilter');
let musicFilter = document.getElementById('musicFilter');
let busFilter = document.getElementById('busFilter');

let filterLinksBG = document.getElementsByClassName('filterLinksBackground');

let greenCards = document.getElementsByClassName('green__card');
let redCards = document.getElementsByClassName('red__card');
let blueCards = document.getElementsByClassName('blue__card');
let orangeCards = document.getElementsByClassName('orange__card');
let purpleCards = document.getElementsByClassName('purple__card');


houseFilter.onclick = function () {
	houseFilter.classList.toggle('active');

	for (let element of greenCards) {
		element.classList.toggle('active');
	}
}

girlFilter.onclick = function () {
	girlFilter.classList.toggle('active');

	for (let element of redCards) {
		element.classList.toggle('active');
	}
}

hatFilter.onclick = function () {
	hatFilter.classList.toggle('active');

	for (let element of blueCards) {
		element.classList.toggle('active');
	}
}

musicFilter.onclick = function () {
	musicFilter.classList.toggle('active');

	for (let element of orangeCards) {
		element.classList.toggle('active');
	}
}

busFilter.onclick = function () {
	busFilter.classList.toggle('active');

	for (let element of purpleCards) {
		element.classList.toggle('active');
	}
}