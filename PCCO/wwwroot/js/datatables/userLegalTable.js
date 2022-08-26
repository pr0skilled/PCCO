$(document).ready(function () {
    $('#tableUserLegData').DataTable(
        {
            responsive: true,
            columnDefs: [{
                targets: Array.from(Array(4).keys()),
                render: $.fn.dataTable.render.ellipsis(50)
            }]
        });
});