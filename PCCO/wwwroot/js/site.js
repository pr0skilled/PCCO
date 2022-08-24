$(function () {
    $('[data-toggle="tooltip"]').tooltip();
});

$(function () {
    setTimeout(function () {
        $('body').removeClass('loading');
    }, 1000);
});

function updateRequirements(e, c) {
    var element = document.getElementById(e);
    var length = element.value.length;
    if (length > 0) {
        document.getElementById(c).setAttribute('required', '');
    } else {
        document.getElementById(c).removeAttribute('required');
    }
}

function expandRow(id) {
    const c = document.getElementById(id).children;
    for (let i = 0; i < c.length; i++) {
        if (c[i].getElementsByTagName("span").length !== 0) {
            let title = c[i].getElementsByTagName("span")[0].getAttribute('title');
            let text = c[i].getElementsByTagName("span")[0].textContent;
            c[i].getElementsByTagName("span")[0].setAttribute('title', text);
            c[i].getElementsByTagName("span")[0].textContent = title;
        }
    }
}