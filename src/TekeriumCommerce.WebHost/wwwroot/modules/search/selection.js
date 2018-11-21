/* ===== Logic for creating fake Select Boxes ===== */
$('.sel').each(function () {
    $(this).children('select').css('display', 'none');

    var $current = $(this);

    $(this).find('option').each(function (i) {
        if (i == 0) {
            $current.prepend($('<div>', {
                class: $current.attr('class').replace(/sel/g, 'sel__box')
            }));

            var placeholder = $(this).text();
            $current.prepend($('<span>', {
                class: $current.attr('class').replace(/sel/g, 'sel__placeholder'),
                text: placeholder,
                'data-placeholder': placeholder
            }));

            return;
        }

        $current.children('div').append($('<span>', {
            class: $current.attr('class').replace(/sel/g, 'sel__box__options'),
            text: $(this).text()
        }));
    });
});

function renderProfile() {
    let $current = $('.sel--super-man');
    $current.children('.sel__placeholder').remove();
    $current.children('.sel__box').remove();
    $('.sel--super-man option').each(function(i) {
        console.log('x');
        if (i == 0) {
            console.log(i);
            $current.prepend($('<div>',
                {
                    class: $current.attr('class').replace(/sel/g, 'sel__box')
                }));

            var placeholder = $(this).text();
            $current.prepend($('<span>',
                {
                    class: $current.attr('class').replace(/sel/g, 'sel__placeholder'),
                    text: placeholder,
                    'data-placeholder': placeholder
                }));

            return;
        }

        $current.children('div').append($('<span>',
            {
                class: $current.attr('class').replace(/sel/g, 'sel__box__options'),
                text: $(this).text()
            }));
    });
}

function renderRim() {
    let $current = $('.sel--man');
    $current.children('.sel__placeholder').remove();
    $current.children('.sel__box').remove();
    $('.sel--man option').each(function (i) {
        console.log('x');
        if (i == 0) {
            console.log(i);
            $current.prepend($('<div>',
                {
                    class: $current.attr('class').replace(/sel/g, 'sel__box')
                }));

            var placeholder = $(this).text();
            $current.prepend($('<span>',
                {
                    class: $current.attr('class').replace(/sel/g, 'sel__placeholder'),
                    text: placeholder,
                    'data-placeholder': placeholder
                }));

            return;
        }

        $current.children('div').append($('<span>',
            {
                class: $current.attr('class').replace(/sel/g, 'sel__box__options'),
                text: $(this).text()
            }));
    });
}


// Toggling the `.active` state on the `.sel`.

$('.sel').click(function () {
    $(this).toggleClass('active');
});

// Toggling the `.selected` state on the options.
$('.sel__box__options').click(function () {
    var txt = $(this).text();
    var index = $(this).index();

    $(this).siblings('.sel__box__options').removeClass('selected');
    $(this).addClass('selected');

    var $currentSel = $(this).closest('.sel');
    $currentSel.children('.sel__placeholder').text(txt);
    $currentSel.children('select').prop('selectedIndex', index + 1).trigger('change');
});

function clickProfile()
{
    $('.sel__box__options--super-man').click(function () {
        var txt = $(this).text();
        var index = $(this).index();

        $(this).siblings('.sel__box__options').removeClass('selected');
        $(this).addClass('selected');

        var $currentSel = $(this).closest('.sel');
        $currentSel.children('.sel__placeholder').text(txt);
        $currentSel.children('select').prop('selectedIndex', index + 1).trigger('change');
    });
}

function clickRim() {
    $('.sel__box__options--man').click(function () {
        var txt = $(this).text();
        var index = $(this).index();

        $(this).siblings('.sel__box__options').removeClass('selected');
        $(this).addClass('selected');

        var $currentSel = $(this).closest('.sel');
        $currentSel.children('.sel__placeholder').text(txt);
        $currentSel.children('select').prop('selectedIndex', index + 1).trigger('change');
    });
}