// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $(document).on('click', '.order-row', function () {
        var orderId = $(this).data('id');

        $.ajax({
            type: 'GET',
            url: '/Order/Get/' + orderId,
            success: function (response) {
                $('#orderDetailsContent').html(response);
                var modal = new bootstrap.Modal(document.getElementById('orderDetailsModal'));
                modal.show();
            },
            error: function (response) {
                console.error("Ошибка загрузки данных заказа", response);
            }
        });
    });
});
