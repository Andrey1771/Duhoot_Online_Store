$(document).ready(function() {
    $('.header__burger').click(function(event) {
        $('.header__burger').toggleClass('active');
        $('body').toggleClass('lock');
        toggleLogoVisibility();
    });
    $('.header__link').click(function(event) {
        $('.header__burger').removeClass('active');
        $('body').removeClass('lock');
        toggleLogoVisibility();
    });
});

function toggleLogoVisibility() {
    switch (document.querySelector('.container__logo').classList.contains('disable')) {
        case true:
            document.querySelector('.container__menu__links').classList.remove('activeBlock');
            document.querySelector('.container__logo').classList.remove('disable');
            break;
        case false:
            document.querySelector('.container__menu__links').classList.add('activeBlock');
            document.querySelector('.container__logo').classList.add('disable');
            break;
        default:
            console.log(`Exception, ok != bool`);
    }
}