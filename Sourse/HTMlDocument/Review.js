$(function(){
    $(window).scroll(function() {
        if ($(window).scrollTop() > 80){
            $("#sidebar-content").css({ "position": "fixed", "top": "20px"});
        }
        else if ($(window).scrollTop() < 80){
            $("#sidebar-content").css({ "position": "absolute", "top": "100px"});
        }
    });
});

function position(IdName) {
    window.scrollTo(0, document.getElementById(IdName).offsetTop);
}





