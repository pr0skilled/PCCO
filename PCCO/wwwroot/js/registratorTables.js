$(document).ready(function () {
    $('#tableIndData').DataTable(
        {
            responsive: true,
            scrollX: true,
            columnDefs: [{
                targets: Array.from(Array(29).keys()),
                render: $.fn.dataTable.render.ellipsis(50)
            }]
        });
});

$(document).ready(function () {
    $('#tableLegData').DataTable(
        {
            responsive: true,
            scrollX: true,
            columnDefs: [{
                targets: Array.from(Array(24).keys()),
                render: $.fn.dataTable.render.ellipsis(50)
            }]
        });
});