// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//Create and Edit - self populating form fields 
function FGCx() {
    var FGx = document.getElementById("FGM").value;
    var FGAx = document.getElementById("FGA").value;
    var FGpc = (FGx / FGAx) * 100;
    document.getElementById("FGperC").value = FGpc;
}

function twoX() {

    var two = document.getElementById("Two_PM").value;
    var twoA = document.getElementById("Two_PA").value;
    var twoPC = (two / twoA) * 100;
    document.getElementById("TwoPerC").value = twoPC;
}

function threeX() {
    var three = document.getElementById("Three_PM").value;
    var threeA = document.getElementById("Three_PA").value;
    var threePC = (three / threeA) * 100;
    document.getElementById("Three_PC").value = threePC;
}

function FTx() {
    var FTx = document.getElementById("FTM").value;
    var FTAx = document.getElementById("FTA").value;
    var FTpc = (FTx / FTAx) * 100;
    document.getElementById("FT_PC").value = FTpc;
}

function REBs() {
    var ORB = parseInt(document.getElementById("O_Rb").value);
    var DRB = parseInt(document.getElementById("D_Rb").value);
    var TRB = parseInt(ORB + DRB);

    document.getElementById("Total_Reb").value = TRB;
}


//Details page
Chart.defaults.scale.ticks.beginAtZero = "true";

function GetJSON_SimpleD() {
    var resp3 = [];
    $.ajax({
        type: "GET",
        url: '/Games/DetailsGraph',
        async: false,
        contentType: "application/json",
        success: function (data) {
            resp3.push(data);
        },
        error: function (req, status, error) {
            alert("error");
        }

    });
    return resp3;
}


var Data = GetJSON_SimpleD();

console.log(Data[0].myMeanFGA);

function renderChart(data, labels) {
    var ctx = document.getElementById("myChart").getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                data: data
            },
            {
                data: [Data[0].myMeanFGA]
                }
                    ]
        },
    });
}

var data = [];

function getChartData() {
    
    var x = $('#dataTable').find("tr:eq(1)").find("td:eq(1)").html();
    data.push(x);
    renderChart(data);
}

$("#renderBtn").click(
    function () {
        getChartData();
    }
);




 
/*var ctx = document.getElementById("DetGraph1")



var barChartData = {
    
    datasets: [{
        label: 'FG',
        data: [Data[0].myMeanFGA]
        
    } ]
    };


window.onclick = function Add () {
    window.DetGraph1 = new Chart.Bar(ctx, { data: barChartData })
};


var data = 14;
function addData() {
    DetGraph1.data.datasets.forEach((dataset)) => {
        data.data.push()
    }
    DetGraph1.update();
}




//window.onload  = function () {
  //  window.DetGraph1 = Chart.Bar(ctx, { data: barChartData });
          

    //};






function F() {

    var table = document.getElementById('dataTable')
    var json = [];
    var headers = [];



    for (var i = 0; i < table.rows[0].cells.length; i++) {
        headers[i] = table.rows[0].cells[i].innerHTM.toLowerCase().replace(/ /gi, '');
    }

    for (var i = 1; i < table.rows.length; i++) {

        var tableRow = table.rows[i];
        var rowData = {};
        for (var j = 0; j < tableRow.cells.length; j++) {
            rowData[headers[j]] = tableRow.cells[j].innerHTML;
        }

        json.push(rowData);
    }

    console.log(json);



}*/



