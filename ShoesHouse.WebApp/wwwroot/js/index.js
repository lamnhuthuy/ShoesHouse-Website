function changeSates() {
    document.querySelector(".overlay").style.display = "block";
    document.querySelector(".menu-mobile").style.transform = "translateX(0)";
}
function ext() {
    document.querySelector(".menu-mobile").style.transform = "translateX(-100%)";
    document.querySelector(".overlay").style.display = "none";
}
var container = document.querySelector(".trending-item-overlay");
var items = document.querySelectorAll(".trending-item-all");
var itemLength = items.length;
var size = items[0].clientWidth;
var index = 0;
function handleTrendingRight() {
    if (index >= itemLength - 1) {
        gotoSlide(0);
        return;
    }
    index++;
    gotoSlide(index);
}
function handleTrendingLeft() {
    if (index <= 0) {
        gotoSlide(itemLength - 1);
        return;
    }
    index--;
    gotoSlide(index);
}
function gotoSlide(number) {
    container.style.transform = "translateX(" + -size * number + "px)";
    index = number;
}
