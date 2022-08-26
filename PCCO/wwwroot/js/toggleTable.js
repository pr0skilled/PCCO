$(document).ready(function () {
    var e = document.getElementById('searchIndBtn');
    console.log(e);
    e.addEventListener("click", () => {
        var individual = document.getElementById("indListDiv");
        var legal = document.getElementById("legListDiv");
        individual.style.display = "";
        legal.style.display = "none";
    });
});

$(document).ready(function () {
    var e = document.getElementById('searchLegBtn');
    console.log(e);
    e.addEventListener("click", () => {
        var individual = document.getElementById("indListDiv");
        var legal = document.getElementById("legListDiv");
        individual.style.display = "none";
        legal.style.display = "";
    });
});