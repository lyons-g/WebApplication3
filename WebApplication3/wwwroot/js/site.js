// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function FGCx() {
    var FGx = document.getElementById("FGM").value;
    var FGAx = document.getElementById("FGA").value;
    var FGpc = (FGx / FGAx)*100;
    document.getElementById("FGperC").value = FGpc;
}

function twoX() {

    var two = document.getElementById("Two_PM").value;
    var twoA = document.getElementById("Two_PA").value;
    var twoPC = (two / twoA)*100;
    document.getElementById("TwoPerC").value = twoPC;
}

function threeX() {
    var three = document.getElementById("Three_PM").value;
    var threeA = document.getElementById("Three_PA").value;
    var threePC = (three / threeA)*100;
    document.getElementById("Three_PC").value = threePC;
}

function FTx() {
    var FTx = document.getElementById("FTM").value;
    var FTAx = document.getElementById("FTA").value;
    var FTpc = (FTx / FTAx)*100;
    document.getElementById("FT_PC").value = FTpc;
}

function REBs() {
    var ORB = parseInt(document.getElementById("O_Rb").value);
    var DRB = parseInt(document.getElementById("D_Rb").value);
    var TRB = parseInt(ORB + DRB);

    document.getElementById("Total_Reb").value = TRB;
}



