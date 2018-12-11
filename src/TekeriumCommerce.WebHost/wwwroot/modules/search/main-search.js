$('select#Width').change(function () {
    let v = JSON.stringify({
        Width: $('select#Width').val(),
        Profile: null,
        SearchCriteriaOptions: 1
    });
    action(v, 'select#Profile', '/Search/searchapi/selectwidth');

    // clean up rim sizes:
    var rimElLength = $('select#RimSize').find("option").length;
    for (var i = 0; i < rimElLength - 1; i++) {
        $('select#RimSize').find('option:last').remove();
    }
});

$('select#Profile').change(function () {
    let v = JSON.stringify({
        Width: $('select#Width').val(),
        Profile: $('select#Profile').val(),
        SearchCriteriaOptions: 2
    });
    action(v, 'select#RimSize', '/Search/searchapi/selectprofile');
});

function action(v, to, url) {
    console.log(v);
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: url,
        dataType: 'application/json',
        data: v,
        async: false,
        statusCode: {
            200: function (result) {
                var text = JSON.parse(result.responseText);
                var l = $(to).find("option").length;
                for (var i = 0; i < l-1; i++) {
                    $(to).find("option:last").remove();
                }

                var selectoption = '';

                $.each(text,
                    function (i) {
                        selectoption += '<option value="' + text[i] + '">' + text[i] + '</option>';
                    });

                $(to).append(selectoption);
            }
        }
    });
}

// form validation
$('form').submit(function(e) {
    // get value of width
    let widthvalue = $('select#Width option:selected').val();

    // value of profile
    let profilevalue = $('select#Profile option:selected').val();

    // value of rim size
    let rimsizevalue = $('select#RimSize option:selected').val();

    if (widthvalue == 'choose') {
        widthelement = $('select#Width');
        widthelement.addClass('red-border');

        setTimeout(
            function () { widthelement.removeClass('red-border'); },
            2000
        );

        e.preventDefault(e);
    }

    if (profilevalue == 'choose') {
        profileelement = $('select#Profile');
        profileelement.addClass('red-border');

        setTimeout(
            function () { profileelement.removeClass('red-border'); },
            2000
        );

        e.preventDefault(e);
    }

    if (rimsizevalue == 'choose') {
        rimsizeelement = $('select#RimSize');
        rimsizeelement.addClass('red-border');

        setTimeout(
            function () { rimsizeelement.removeClass('red-border'); },
            2000
        );

        e.preventDefault(e);
    }
});