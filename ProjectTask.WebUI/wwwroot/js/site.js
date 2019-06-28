$(function () {
    $.ajaxSetup({ cache: false });
    $(".modalItems").click(function (e) {
        e.preventDefault();
        $.get(this.href, function (data) {
            $('#modalContent').html(data);
            $("#modal-placeholder").modal('toggle');
        });
    });

    var placeholderElement = $('#modal-placeholder');

    placeholderElement.on('click', '[data-save="modal"]', function (event) {
        event.preventDefault();
        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var dataToSend = form.serialize();
        $.post(actionUrl, dataToSend).done(function (data) {
            var newBody = $('.modal-body', data);
            placeholderElement.find('.modal-body').replaceWith(newBody);
            var isValid = newBody.find('[name="IsValid"]').val() == 'True';
            if (isValid) {
                location.reload();
                //placeholderElement.modal('hide');
            }
        });
    });
})