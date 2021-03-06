﻿var currentChart = null;

// Gets the current hall ID (returned as string)
function GetCurrentHallID() {
    return document.getElementById("lblHallID").textContent;
}

// Draws a chart on the statsCanvas. Draws a line chart if !!line, bar chart if !line
function DrawChart(chartData, Bar) {
    if (currentChart != null) {
        currentChart.destroy();
    }
    
    var ctx = document.getElementById("statsCanvas").getContext("2d");

    var t = new Chart(ctx);
    if (!!Bar) {
       currentChart =  t.Bar(chartData, {
            responsive: true,
            animation: true,
            toolTip: {
                shared: "true",
                content: "auto",
                enabled: "true"
            }
        });
    }

    var legend = document.getElementById("legend");
    legend.innerHTML = currentChart.generateLegend();
}

// Performs an ajax call to the given dataFunction, gets data for all halls if !currentHall
function GetData(dataFunction, currentHall) {
    var chartData;
    var hallID = -1;

    if (!!currentHall) {
        hallID = GetCurrentHallID();
    }

    $.ajax({
        async: false,
        type: "POST",
        contentType: "application/x-www-form-urlencoded",
        url: "Data.asmx/" + dataFunction,
        dataType: "html",
        data: 'hallID=' + hallID,
        success: function (data, textStatus) {
            if (textStatus === "success") {
                if (data.hasOwnProperty('d')) {
                    msg = data.d;
                } else {
                    msg = data;
                }
                chartData = JSON.parse(msg);
            }
        },
        error: function (data, status, error) {
            alert("data: " + data + "\nstatus: " + status + "\nerror: " + error);
        }
    });

    return chartData;
}

/**
 * Gets the data from the given data function using GetData and calls DrawChart with the data.
 * @param {String} Function from /Stats/Data.asmx to call
 * @param {Boolean} True if the chart is a line graph
 * @param {Boolean} If true will only get stats for current hall
 * @return {Boolean} false
 */
function OpenChart(dataFunction, isBarGraph, currentHall) {
    var chartData = GetData(dataFunction, currentHall);
    DrawChart(chartData, isBarGraph);
    return false;
}

function OpenPizzaByDayOfWeekLine(currentHall) {
    return OpenChart("PizzaDayOfWeekLine", true, currentHall);
}

function OpenPizzaByHourLine(currentHall) {
    return OpenChart("PizzaHourLine", true, currentHall);
}

function OpenPackageByDayOfWeekLine(currentHall) {
    return OpenChart("PackageDayOfWeekLine", true, currentHall);
}

function OpenPackageByHourLine(currentHall) {
    return OpenChart("PackageHourLine", true, currentHall);
}

function OpenProductByDayOfWeekLine(currentHall) {
    return OpenChart("ProductDayOfWeekLine", true, currentHall);
}

function OpenProductByHourLine(currentHall) {
    return OpenChart("ProductHourLine", true, currentHall);
}

function OpenPizzaByDayOfWeekLineComparison() {
    return OpenChart("PizzaDayOfWeekLineComparison", true, -1);
}

function OpenPizzaByHourLineComparison() {
    return OpenChart("PizzaHourLineComparison", true, -1);
}

function OpenPackageByDayOfWeekLineComparison() {
    return OpenChart("PackageDayOfWeekLineComparison", true, -1);
}

function OpenPackageByHourLineComparison() {
    return OpenChart("PackageHourLineComparison", true, -1);
}

function OpenPizzaByDayOfWeekAll() {
    return OpenChart("PizzaDayOfWeekLineAll", true, -1);
}

function OpenDVDCheckOutByDayOfWeekLine(currentHall) {
    return OpenChart("DVDCheckOutDayOfWeekLine", true, currentHall);
}