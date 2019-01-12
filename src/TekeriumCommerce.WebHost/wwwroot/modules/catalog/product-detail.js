$(document).ready(function () {
    $('.sp-wrap').smoothproducts();

    $('#increase').on('click',
        function () {
            var quantityInput = $('#number');
            quantityInput.val(parseInt(quantityInput.val(), 10) + 1);
        });

    $('#decrease').on('click',
        function () {
            var quantityInput = $('#number');
            if (quantityInput.val() > 1) {
                quantityInput.val(quantityInput.val() - 1);
            }
        });
});