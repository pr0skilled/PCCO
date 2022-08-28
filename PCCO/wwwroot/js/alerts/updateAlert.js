$(document).ready(function () {
    $('form #btn-save').click(function (e) {
        let form = $(this).closest('form');

        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, I\'m sure!'
        }).then((result) => {
            if (result.isConfirmed) {
                form.submit();
            } else {
                e.preventDefault();
            }
        });
    });
});

function updateAlert(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, I\'m sure!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                success: function () {
                    localStorage.setItem('success', 'Success!')
                    window.location.reload();
                }
            });
        }
    });
}