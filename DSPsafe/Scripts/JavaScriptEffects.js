$('.carousel').carousel({
    interval: 1800 // in milliseconds  
})

function viewPie() {
    $("#chartdiv").slideToggle(600);
    setTimeout(generatePie, 650);   
}

function viewBar() {
    $("#chartRegion").slideToggle(600);
    setTimeout(generateStackedChart, 550);
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

function generatePie() {
    var myUrl = "Incidents/GetData"
    AmCharts.makeChart("chartdiv",
       {
           "type": "pie",
           "balloonText": "[[title]]<br><span style='font-size:14px'><b>[[value]]</b> ([[percents]]%)</span>",
           "titleField": "typeInc",
           "valueField": "countOf",
           "allLabels": [],
           "balloon": {},
           "legend": {
               "enabled": true,
               "align": "center",
               "markerType": "circle"
           },
           "titles": [],
           "dataLoader": {
               "url": myUrl,
               "format": "json"
           }
       }
   );
}

function generateStackedChart() {
    var myUrl = "Incidents/GetBreakdown";
    AmCharts.makeChart("chartRegion",
                {
                    "type": "serial",
                    "categoryField": "category",
                    "startDuration": 3,
                    "theme": "default",
                    "categoryAxis": {
                        "classNameField": "[[Region]]",
                        "gridPosition": "start",
                        "fillAlpha": 0.02,
                        "gridAlpha": 0.01,
                        "title": "Breakdown of Incidents by Region"
                    },
                    "trendLines": [],
                    "graphs": [
                        {
                            "balloonText": "[[title]] :[[value]]",
                            "fillAlphas": 1,
                            "id": "AmGraph-1",
                            "title": "Assault",
                            "type": "column",
                            "valueField": "countAssault"
                        },
                        {
                            "balloonText": "[[title]] :[[value]]",
                            "fillAlphas": 1,
                            "id": "AmGraph-2",
                            "title": "Threat",
                            "type": "column",
                            "valueField": "countThreat"
                        },
                        {
                            "balloonText": "[[title]] :[[value]]",
                            "fillAlphas": 1,
                            "id": "AmGraph-3",
                            "title": "Slip",
                            "type": "column",
                            "valueField": "countSlip"
                        },
                        {
                            "balloonText": "[[title]] :[[value]]",
                            "fillAlphas": 1,
                            "id": "AmGraph-4",
                            "title": "Manual Handling",
                            "type": "column",
                            "valueField": "countManual"
                        },
                        {
                            "balloonText": "[[title]] :[[value]]",
                            "fillAlphas": 1,
                            "fillColors": "#9400D3",
                            "id": "AmGraph-6",
                            "title": "Damage",
                            "type": "column",
                            "valueField": "countDamage"
                        }
                    ],
                    "guides": [],
                    "valueAxes": [
                        {
                            "id": "ValueAxis-1",
                            "stackType": "regular",
                            "title": "Incidents"
                        }
                    ],
                    "allLabels": [],
                    "balloon": {
                        "animationDuration": 0.34,
                        "fadeOutDuration": 0.26,
                        "fillAlpha": 0.96
                    },
                    "legend": {
                        "enabled": true,
                        "useGraphSettings": true
                    },
                    "titles": [
                        {
                            "alpha": 0,
                            "id": "Title-1",
                            "size": 15,
                            "text": "Breakdown of incidents"
                        }
                    ],
                    "dataLoader": {
                        "url": myUrl,
                        "format": "json"
                    }
                }
            );
}