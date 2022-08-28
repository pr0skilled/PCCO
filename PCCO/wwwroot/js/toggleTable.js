$(document).ready(function () {
    var e = document.getElementById('searchIndBtn');
    e.addEventListener("click", () => {
        var individual = document.getElementById("indListDiv");
        var legal = document.getElementById("legListDiv");
        individual.style.display = "";
        legal.style.display = "none";
    });
});

$(document).ready(function () {
    var e = document.getElementById('searchLegBtn');
    e.addEventListener("click", () => {
        var individual = document.getElementById("indListDiv");
        var legal = document.getElementById("legListDiv");
        individual.style.display = "none";
        legal.style.display = "";
    });
});