// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(window).scroll(function () {
    $('nav').toggleClass('scrollednav', $(this).scrollTop() > 20);
}
);


$(function () {
    $('nav ul li a').filter(function () {
        return this.href == location.href 
    }).parent().addClass('activee').siblings().removeClass('activee');

    $('nav ul li a').click(function () {
        $(this).parent().addClass('activee').siblings().removeClass('activee')
    });
});
$(window).scroll(function () {
    if ($(this).scrollTop() >= 50) {        // If page is scrolled more than 50px
        $('#return-to-top').fadeIn(200);    // Fade in the arrow
    } else {
        $('#return-to-top').fadeOut(200);   // Else fade out the arrow
    }
});
$('#return-to-top').click(function () {      // When arrow is clicked
    $('body,html').animate({
        scrollTop: 0                       // Scroll to top of body
    }, 500);
});


$(document).ready(function () {

    $(window).scroll(function () {
        if ($(this).scrollTop() > 30) {
        $("#havenicetrip").html("<h2>Have a nice Trip</h2>");
           //change yes to no
        } else {
            $("#havenicetrip").text("  Welcome to tourism Kosovo ");

            //set h1 text to yes
        }
});
});
$('.ml3').each(function () {
    $(this).html($(this).text().replace(/([^\x00-\x80]|\w)/g, "<span class='letter'>$&</span>"));
});

anime.timeline({ loop: true })
    .add({
        targets: '.ml3 .letter',
        opacity: [0, 1],
        easing: "easeInOutQuad",
        duration: 2250,
        delay: function (el, i) {
            return 150 * (i + 1)
        }
    });


    /*.add({
        targets: '.ml3',
        opacity: 0,
        duration: 1000,
        easing: "easeOutExpo",
        delay: 1000
    });*/