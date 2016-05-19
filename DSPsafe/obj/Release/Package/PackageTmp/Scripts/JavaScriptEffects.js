$('.carousel').carousel({
    interval: 1800 // in milliseconds  
})

function viewPie() {
    $("#chartdiv").slideToggle(600);
}

function viewBar() {
    $("#chartRegion").slideToggle(600);
}

function viewTable() {
    $("#IncTable").slideToggle(600);
}