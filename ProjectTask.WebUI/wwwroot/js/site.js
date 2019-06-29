
//init mvc grid
(function () {

    [].forEach.call(document.getElementsByClassName('mvc-grid'), function (element) {
        new MvcGrid(element);
    });

})();

//modal popup
(function () {
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
        alert(actionUrl);
        alert(dataToSend);
        $.post(actionUrl, dataToSend).done(function (data) {
            alert('AM HERE');
            var newBody = $('.modal-body', data);
            placeholderElement.find('.modal-body').replaceWith(newBody);
            alert(newBody.find('[name="IsValid"]').val());
            var isValid = newBody.find('[name="IsValid"]').val() === 'True';
            if (isValid) {
                location.reload();
                //placeholderElement.modal('hide');
            }
        });
    });
});
