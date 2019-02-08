$(function() {
    $('#lang li').on('click',
        (e) => {
            console.log('fa');

            var lang = $(this).find('a').attr('data-value'),
                $langForm = $('#lang-form'),
                $cultureInput = $langForm.find('input[name=culture]');

            $langForm.submit();

            console.log(lang);

            if ($cultureInput.val() === lang) {
                e.preventDefault();
                return;
            } else {
                console.log('here');
                $cultureInput.val(lang);
                console.log($cultureInput);
                $langForm[0].submit();
                console.log($langForm);
            }
        });
});