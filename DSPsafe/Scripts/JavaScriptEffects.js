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

function changeIcon() {
    var type = $("#typeForIcon").val();
    $("#displayIncident").text(type);
    switch (type) {
        case "Threat":
            $("#typeIcon").attr("src", "/Images/icons/threatIcon.jpg");
            break;
        case "Damage":
            $("#typeIcon").attr("src", "/Images/icons/damage.png");
            break;
        case "Slip":
            $("#typeIcon").attr("src", "/Images/icons/fall.jpg");
            break;
        case "Assault":
            $("#typeIcon").attr("src", "/Images/icons/assaultIcon.png");
            break;
        case "Manual Handling":
            $("#typeIcon").attr("src", "/Images/icons/manHandling.png");
            break;
    }
    $('#myModal').modal('show');
}