$(document).ready(function() {
    $('.header__burger').click(function(event) {
        $('.header__burger,.header__menu').toggleClass('active');
        $('body').toggleClass('lock');
    });
});
const popupLinks = document.querySelectorAll('.popup__login-link');
const body = document.querySelector('body');
const lockPadding = document.querySelectorAll(".lock-padding");

let unlock = true;

const timeout = 800;

if(popupLinks.length > 0) {
	for (let index = 0; index < popupLinks.length; ++index)
	{
		const popupLink = popupLinks[index];
		popupLink.addEventListener("click", function (e) {
			const popupName = popupLink.getAttribute('href').replace('#', '');
			const currentPopup = document.getElementById(popupName);
			popupOpen(currentPopup);
			e.preventDefault();
		});
	}
}

const popupCloseIcon = document.querySelectorAll('.close-popup__login');

if(popupCloseIcon.length > 0) {//Stupid check?)
	for(let index = 0; index < popupCloseIcon.length; ++index)
	{
		const el = popupCloseIcon[index];
		el.addEventListener('click', function (e){
			popupClose(el.closest('.popup__login'));
			e.preventDefault();
		});
	}
}

function popupOpen(currentPopup)
{
	if(currentPopup && unlock) 
	{
		const popupActive = document.querySelector('.popup__login.open');
		if(popupActive)
		{
			popupClose(popupActive, false);
		} else
		{
			bodyLock();
		}
		currentPopup.classList.add('open');
		currentPopup.addEventListener("click", function (e) {
			if(!e.target.closest('.popup__login__content')) {
				popupClose(e.target.closest('.popup__login'));
			}
		})
	}
}

function popupClose(popupActive, doUnlock = true)
{
	if(unlock)
	{
		popupActive.classList.remove('open');
		if(doUnlock)
		{
			bodyUnLock();
		}
	}
}

function bodyLock()
{
	const lockPaddingValue = window.innerWidth - document.querySelector('.external__container').offsetWidth + 'px';


	for (let index = 0; index < lockPadding.length; ++index)
	{
		const el = lockPadding[index];
		el.style.paddingRight = lockPaddingValue;
	}
	body.style.paddingRight = lockPaddingValue;
	body.classList.add('lock');

	unlock = false;
	setTimeout(function() {
		unlock = true;
	}, timeout);
}

function bodyUnLock() 
{
	setTimeout(function() 
	{
		for(let index = 0; index < lockPadding.length; ++index)
		{
			const el = lockPadding[index];
			el.style.paddingRight = '0px';
		}
		body.style.paddingRight = '0px';
		body.classList.remove('lock');

		
	},);
	unlock = false;
	setTimeout(function() {
	unlock = true;
}, timeout);

}

document.addEventListener('keydown', function(e){
	if(e.which === 27){
		const popupActive = document.querySelector('.popup__login.open');
		popupClose(popupActive);
	}
});


(function() {

  // проверяем поддержку
  if (!Element.prototype.closest) {

    // реализуем
    Element.prototype.closest = function(css) {
      var node = this;

      while (node) {
        if (node.matches(css)) return node;
        else node = node.parentElement;
      }
      return null;
    };
  }

})();

(function() {

  // проверяем поддержку
  if (!Element.prototype.matches) {

    // определяем свойство
    Element.prototype.matches = Element.prototype.matchesSelector ||
      Element.prototype.webkitMatchesSelector ||
      Element.prototype.mozMatchesSelector ||
      Element.prototype.msMatchesSelector;

  }

})();
$(document).ready(function() {

/*$(document).ready(function() {
    $('#houseFilter').click(function() {
   $(this).css('background-color', "#1baf5d");
});
});*/

$("#houseFilter").click( function(){
	if($("#houseFilter.greenBackground").classList.has(greenBackground))
		$("#houseFilter.greenBackground").removeClass('greenBackground');
    $(this).addClass('greenBackground');
});

$('.showMoreCards').click( function(){
    $('.showMoreCards').removeClass('showCards');
    $(this).addClass('showCards');
});
});
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