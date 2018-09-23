
$(function () {

    jQuery('.showSingle').click(function () {
        jQuery('.targetDiv').hide();
        jQuery('#div' + $(this).attr('targetDiv')).fadeIn(2000);
    });
});


$(document).ready(function () {
    $("#lstdisplay").DataTable();

    $("#div2").toggle();
    $("#div3").toggle();
    $("#div4").toggle();
    $("#div5").toggle();
});