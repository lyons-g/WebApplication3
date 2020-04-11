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

/*
console.log(Data[0].myMeanFGA);
console.log(Data[0].myTwo);
console.log(Data[0].myThree);
console.log(Data[0].myFT);
console.log(Data[0].myRBS);
console.log(Data[0].myAST);
console.log(Data[0].myTO);
console.log(Data[0].mySteals);
console.log(Data[0].myBLK);
console.log(Data[0].myPTS);



*/




//myChart - fg%
var data = [];

function getChartData() {

    var x = $('#dataTable').find("tr:eq(1)").find("td:eq(2)").html();
    data.push(x);
    renderChart(data);
}

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




//myChart1 - 2%
var data1 = [];

function getChartData1() {
    var a = $('#dataTable').find("tr:eq(1)").find("td:eq(5)").html();
    data1.push(a);
    renderChart1(data1);
    console.log(data1);
}
function renderChart1(data, labels) {
    var ctx1 = document.getElementById("myChart1").getContext('2d');
    var myChart1 = new Chart(ctx1, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                data: data1
            },
            {
                data: [Data[0].myTwo]
            }
            ]
        }
    });
}



//myChart2 - 3%
var data2 = [];

function getChartData2() {
    var b = $('#dataTable').find("tr:eq(1)").find("td:eq(8)").html();
    data2.push(b);
    renderChart2(data2);
    console.log(data2);
}
function renderChart2(data, labels) {
    var ctx2 = document.getElementById("myChart2").getContext('2d');
    var myChart2 = new Chart(ctx2, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                data: data2
            },
            {
                data: [Data[0].myThree]
            }
            ]
        }
    });
}



//myChart3 - FT%
var data3 = [];

function getChartData3() {
    var c = $('#dataTable').find("tr:eq(1)").find("td:eq(11)").html();
    data3.push(c);
    renderChart3(data3);
    console.log(data3);
}
function renderChart3(data, labels) {
    var ctx3 = document.getElementById("myChart3").getContext('2d');
    var myChart3 = new Chart(ctx3, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                data: data3
            },
            {
                data: [Data[0].myFT]
            }
            ]
        }
    });
}




//myChart4 - Total Rebounds
var data4 = [];

function getChartData4() {
    var d = $('#dataTable').find("tr:eq(1)").find("td:eq(14)").html();
    data4.push(d);
    renderChart4(data4);
    console.log(data4);
}
function renderChart4(data, labels) {
    var ctx4 = document.getElementById("myChart4").getContext('2d');
    var myChart4 = new Chart(ctx4, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                data: data4
            },
            {
                data: [Data[0].myRBS]
            }
            ]
        }
    });
}


//myChart5 - Assists
var data5 = [];

function getChartData5() {
    var e = $('#dataTable').find("tr:eq(1)").find("td:eq(15)").html();
    data5.push(e);
    renderChart5(data5);
    console.log(data5);
}
function renderChart5(data, labels) {
    var ctx5 = document.getElementById("myChart5").getContext('2d');
    var myChart5 = new Chart(ctx5, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                data: data5
            },
            {
                data: [Data[0].myAST]
            }
            ]
        }
    });
}



//myChart6 - Turnover
var data6 = [];

function getChartData6() {
    var f = $('#dataTable').find("tr:eq(1)").find("td:eq(16)").html();
    data6.push(f);
    renderChart6(data6);
    console.log(data6);
}
function renderChart6(data, labels) {
    var ctx6 = document.getElementById("myChart6").getContext('2d');
    var myChart6 = new Chart(ctx6, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                data: data6
            },
            {
                data: [Data[0].myTO]
            }
            ]
        }
    });
}


//myChart7 - Steals
var data7 = [];

function getChartData7() {
    var g = $('#dataTable').find("tr:eq(1)").find("td:eq(17)").html();
    data7.push(g);
    renderChart7(data7);
    console.log(data7);
}
function renderChart7(data, labels) {
    var ctx7 = document.getElementById("myChart7").getContext('2d');
    var myChart7 = new Chart(ctx7, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                data: data7
            },
            {
                data: [Data[0].mySteals]
            }
            ]
        }
    });
}



//myChart8 - Blocks
var data8 = [];

function getChartData8() {
    var h = $('#dataTable').find("tr:eq(1)").find("td:eq(18)").html();
    data8.push(h);
    renderChart8(data8);
    console.log(data8);
}
function renderChart8(data, labels) {
    var ctx8 = document.getElementById("myChart8").getContext('2d');
    var myChart8 = new Chart(ctx8, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                data: data8
            },
            {
                data: [Data[0].myBLK]
            }
            ]
        }
    });
}


//myChart9 - Points
var data9 = [];

function getChartData9() {
    var i = $('#dataTable').find("tr:eq(1)").find("td:eq(19)").html();
    data9.push(i);
    renderChart9(data9);
    console.log(data9);
}
function renderChart9(data, labels) {
    var ctx9 = document.getElementById("myChart9").getContext('2d');
    var myChart9 = new Chart(ctx9, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                data: data9
            },
            {
                data: [Data[0].myPTS]
            }
            ]
        }
    });
}


$("#renderBtn").click(
    function () {
        getChartData();
        getChartData1();
        getChartData2();
        getChartData3();
        getChartData4();
        getChartData5();
        getChartData6();
        getChartData7();
        getChartData8();
        getChartData9();
        getScrollBar();

    }
);


function getScrollBar() {
    $(function () {

        var $sidebar = $("#sidebar"),
            $window = $(window),
            offset = $sidebar.offset(),
            topPadding = 15;

        $window.scroll(function () {
            if ($window.scrollTop() > offset.top) {
                $sidebar.stop().animate({
                    marginTop: $window.scrollTop() - offset.top + topPadding
                });
            } else {
                $sidebar.stop().animate({
                    marginTop: 0
                });
            }
        });

    });
};

// Not using modules in app. Just for testing
module.exports = {
    FGCx,
    GetJSON_SimpleD
};