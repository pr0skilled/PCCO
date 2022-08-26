$(document).ready(function () {
    $('#tableUserIndData').DataTable(
        {
            responsive: true,
            scrollX: true,
            columnDefs: [{
                targets: Array.from(Array(13).keys()),
                render: $.fn.dataTable.render.ellipsis(50)
            }]
        });
});