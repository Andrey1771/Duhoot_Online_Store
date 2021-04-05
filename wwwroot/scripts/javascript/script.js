let wC__house__icon = document.getElementById('wC__house__icon');
let wC__girl__icon = document.getElementById('wC__girl__icon');
let wC__hat__icon = document.getElementById('wC__hat__icon');
let wC__music__icon = document.getElementById('wC__music__icon');
let wC__bus__icon = document.getElementById('wC__bus__icon');

let wC__icons__bg = document.getElementsByClassName('whatCanIconsBackground');


let reality__house = document.getElementById('reality__house');
let reality__girl = document.getElementById('reality__girl');
let reality__hat = document.getElementById('reality__hat');
let reality__music = document.getElementById('reality__music');
let reality__bus = document.getElementById('reality__bus');

let reality__item = document.getElementsByClassName('reality__item');
let reality__title = document.getElementById('reality__title');


wC__house__icon.onclick = function () {
	for (let element of wC__icons__bg) {
		if (element.id != 'wC__house__icon') {
			if (element.classList.contains('active')) {
				element.classList.remove('active');
			}
		}
	};

	for (let element of reality__item) {
		if (element.id != 'reality__house') {
			if (element.classList.contains('active')) {
				element.classList.remove('active');
			}
		}
	};

	wC__house__icon.classList.toggle('active');
	reality__house.classList.toggle('active');

	if (reality__house.classList.contains('active')) {
		reality__title.classList.add('active');
	}
	else {
		reality__title.classList.remove('active');
	}

	reality__title.innerHTML = 'Reality';
}

wC__girl__icon.onclick = function () {
	for (let element of wC__icons__bg) {
		if (element.id != 'wC__girl__icon') {
			if (element.classList.contains('active')) {
				element.classList.remove('active');
			}
		}
	};

	for (let element of reality__item) {
		if (element.id != 'reality__girl') {
			if (element.classList.contains('active')) {
				element.classList.remove('active');
			}
		}
	};

	wC__girl__icon.classList.toggle('active');
	reality__girl.classList.toggle('active');

	if (reality__girl.classList.contains('active')) {
		reality__title.classList.add('active');
	}
	else {
		reality__title.classList.remove('active');
	}

	reality__title.innerHTML = 'Living';
}

wC__hat__icon.onclick = function () {
	for (let element of wC__icons__bg) {
		if (element.id != 'wC__hat__icon') {
			if (element.classList.contains('active')) {
				element.classList.remove('active');
			}
		}
	};

	for (let element of reality__item) {
		if (element.id != 'reality__hat') {
			if (element.classList.contains('active')) {
				element.classList.remove('active');
			}
		}
	};

	wC__hat__icon.classList.toggle('active');
	reality__hat.classList.toggle('active');

	if (reality__hat.classList.contains('active')) {
		reality__title.classList.add('active');
	}
	else {
		reality__title.classList.remove('active');
	}

	reality__title.innerHTML = 'Education';
}

wC__music__icon.onclick = function () {
	for (let element of wC__icons__bg) {
		if (element.id != 'wC__music__icon') {
			if (element.classList.contains('active')) {
				element.classList.remove('active');
			}
		}
	};

	for (let element of reality__item) {
		if (element.id != 'reality__music') {
			if (element.classList.contains('active')) {
				element.classList.remove('active');
			}
		}
	};

	wC__music__icon.classList.toggle('active');
	reality__music.classList.toggle('active');

	if (reality__music.classList.contains('active')) {
		reality__title.classList.add('active');
	}
	else {
		reality__title.classList.remove('active');
	}

	reality__title.innerHTML = 'Entertainment';
}

wC__bus__icon.onclick = function () {
	for (let element of wC__icons__bg) {
		if (element.id != 'wC__bus__icon') {
			if (element.classList.contains('active')) {
				element.classList.remove('active');
			}
		}
	};

	for (let element of reality__item) {
		if (element.id != 'reality__bus') {
			if (element.classList.contains('active')) {
				element.classList.remove('active');
			}
		}
	};

	wC__bus__icon.classList.toggle('active');
	reality__bus.classList.toggle('active');

	if (reality__bus.classList.contains('active')) {
		reality__title.classList.add('active');
	}
	else {
		reality__title.classList.remove('active');
	}

	reality__title.innerHTML = 'Mobility';
}

document.addEventListener('keydown', (event) => {
  const keyName = event.key;

  	if (keyName == 'ArrowRight') {
  		if (wC__bus__icon.classList.contains('active')) {
			wC__bus__icon.classList.remove('active');
			wC__house__icon.classList.add('active');
			reality__bus.classList.remove('active');
			reality__house.classList.add('active');
			reality__title.innerHTML = 'Reality';
		}
		else {
			if (wC__music__icon.classList.contains('active')) {
				wC__music__icon.classList.remove('active');
				wC__bus__icon.classList.add('active');
				reality__music.classList.remove('active');
				reality__bus.classList.add('active');
				reality__title.innerHTML = 'Mobility';
			}
			else {
				if (wC__hat__icon.classList.contains('active')) {
					wC__hat__icon.classList.remove('active');
					wC__music__icon.classList.add('active');
					reality__hat.classList.remove('active');
					reality__music.classList.add('active');
					reality__title.innerHTML = 'Entertainment';
				}
				else {
					if (wC__girl__icon.classList.contains('active')) {
						wC__girl__icon.classList.remove('active');
						wC__hat__icon.classList.add('active');
						reality__girl.classList.remove('active');
						reality__hat.classList.add('active');
						reality__title.innerHTML = 'Education';
					}
					else {
						if (wC__house__icon.classList.contains('active')) {
							wC__house__icon.classList.remove('active');
							wC__girl__icon.classList.add('active');
							reality__house.classList.remove('active');
							reality__girl.classList.add('active');
							reality__title.innerHTML = 'Living';
						}
					}
				}
			}
		}
	}	
		
	if (keyName == 'ArrowLeft') {
  		if (wC__house__icon.classList.contains('active')) {
			wC__house__icon.classList.remove('active');
			wC__bus__icon.classList.add('active');
			reality__house.classList.remove('active');
			reality__bus.classList.add('active');
			reality__title.innerHTML = 'Mobility';
		}
		else {
			if (wC__bus__icon.classList.contains('active')) {
				wC__bus__icon.classList.remove('active');
				wC__music__icon.classList.add('active');
				reality__bus.classList.remove('active');
				reality__music.classList.add('active');
				reality__title.innerHTML = 'Entertainment';
			}
			else {
				if (wC__music__icon.classList.contains('active')) {
					wC__music__icon.classList.remove('active');
					wC__hat__icon.classList.add('active');
					reality__music.classList.remove('active');
					reality__hat.classList.add('active');
					reality__title.innerHTML = 'Education';
				}
				else {
					if (wC__hat__icon.classList.contains('active')) {
						wC__hat__icon.classList.remove('active');
						wC__girl__icon.classList.add('active');
						reality__hat.classList.remove('active');
						reality__girl.classList.add('active');
						reality__title.innerHTML = 'Living';
					}
					else {
						if (wC__girl__icon.classList.contains('active')) {
							wC__girl__icon.classList.remove('active');
							wC__house__icon.classList.add('active');
							reality__girl.classList.remove('active');
							reality__house.classList.add('active');
							reality__title.innerHTML = 'Reality';
						}
					}
				}
			}
		}
	}
});