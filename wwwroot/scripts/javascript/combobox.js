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