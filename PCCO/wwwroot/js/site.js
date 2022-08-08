$(function () {
    $('[data-toggle="tooltip"]').tooltip();
});

function showIndividualFunc() {
    document.getElementById("legalItemsList").style.display = "none";
    document.getElementById("individualItemsList").style.display = "";
}

function showLegalFunc() {
    document.getElementById("individualItemsList").style.display = "none";
    document.getElementById("legalItemsList").style.display = "";
}

$(function () {
    setTimeout(function () {
        $('body').removeClass('loading');
    }, 1000);
});
