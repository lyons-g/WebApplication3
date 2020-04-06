//trend page to graphs

function GetJSON_Simple() {
    var resp2 = [];
    $.ajax({
        type: "GET",
        url: '/Games/Method',
        async: false,
        contentType: "application/json",
        success: function (data) {
            resp2.push(data);
        },
        error: function (req, status, error) {
            alert("error");
        }

    });
    return resp2;
}

var simpleData = GetJSON_Simple();
var ctx = document.getElementById("Graph1")
var ctx2 = document.getElementById("Graph2")
var ctx3 = document.getElementById("Graph3")
var ctx4 = document.getElementById("Graph4")
var ctx5 = document.getElementById("Graph5")
var ctx6 = document.getElementById("Graph6")
var ctx7 = document.getElementById("Graph7")
var ctx8 = document.getElementById("Graph8")


Chart.defaults.global.elements.rectangle.borderWidth = 2;
Chart.defaults.global.responsive = true;
Chart.defaults.scale.ticks.beginAtZero = "true";
Chart.defaults.global.datasets.bar.borderColor = myBorderColors;
Chart.defaults.global.layout.padding.right = 75;


console.log(simpleData[0].myFGA);
console.log(simpleData[0].myFGM);
console.log(simpleData[0].myFGpc);

var barChartData = {
    labels: simpleData[0].myNotes,
    datasets: [{
        label: 'FG',
        data: simpleData[0].myFGM
    },
    {
        label: 'FGA',
        data: simpleData[0].myFGA
    },
    {
        label: 'FG%',
        data: simpleData[0].myFGpc
    }
    ]
};



var two = {
    labels: simpleData[0].myNotes,
    datasets: [{
        label: '2P',
        data: simpleData[0].myTwo
    },
    {
        label: '2A',
        data: simpleData[0].myTwoA
    },
    {
        label: '2%',
        data: simpleData[0].myTwoPC
    }
    ]
};

var three = {
    labels: simpleData[0].myNotes,
    datasets: [{
        label: '3P',
        data: simpleData[0].myThree
    },
    {
        label: '3A',
        data: simpleData[0].myThreeA
    },
    {
        label: '3%',
        data: simpleData[0].myThreePC
    }
    ]
};

var four = {
    labels: simpleData[0].myNotes,
    datasets: [{
        label: 'FT',
        data: simpleData[0].myFT
    },
    {
        label: 'FTA',
        data: simpleData[0].myFTA
    },
    {
        label: 'FT%',
        data: simpleData[0].myFTpc
    }
    ]
};

var five = {
    labels: simpleData[0].myNotes,
    datasets: [{
        label: 'OR',
        data: simpleData[0].myOR
    },
    {
        label: 'DR',
        data: simpleData[0].myDR
    },
    {
        label: 'TR',
        data: simpleData[0].myTR
    }
    ]
};

var six = {
    labels: simpleData[0].myNotes,
    datasets: [{
        label: 'Ast',
        data: simpleData[0].myAST
    },
    {
        label: 'TO',
        data: simpleData[0].myTO
    }]
};

var seven = {
    labels: simpleData[0].myNotes,
    datasets: [{
        label: 'Steals',
        data: simpleData[0].myST
    }]
};

var eight = {
    labels: simpleData[0].myNotes,
    datasets: [{
        label: 'Points',
        data: simpleData[0].myPoints
    }]
};


var win = simpleData[0].myWin;
var myBorderColors = []; //win.map(b => b ? "rgba(0, 177, 106, 1)" : "rgba(207, 0, 15, 1)");

console.log(Chart.defaults);

$.each(win, function (index, value) {
    if (value === true) {
        myBorderColors[index] = "rgba(0, 177, 106, 1)";
    } else {
        myBorderColors[index] = "rgba(207, 0, 15, 1)";
    }
});

window.onload = function () {
    window.Graph1 = Chart.Bar(ctx, { data: barChartData });
    window.Graph2 = Chart.Bar(ctx2, { data: two });
    window.Graph3 = Chart.Bar(ctx3, { data: three });
    window.Graph4 = Chart.Bar(ctx4, { data: four });
    window.Graph5 = Chart.Bar(ctx5, { data: five });
    window.Graph6 = Chart.Bar(ctx6, { data: six });
    window.Graph7 = Chart.Bar(ctx7, { data: seven });
    window.Graph8 = Chart.Bar(ctx8, { data: eight });

};


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