$(document).on('change', 'select#Width', function () {
    let v = JSON.stringify({
        Width: $('select#Width').val(),
        Profile: null,
        SearchCriteriaOptions: 1
    });
    action(v, 'select#Profile', '/Search/searchapi/selectwidth');
    renderProfile();
    clickProfile();
});

$('select#Profile').change(function () {
    let v = JSON.stringify({
        Width: $('select#Width').val(),
        Profile: $('select#Profile').val(),
        SearchCriteriaOptions: 2
    });
    action(v, 'select#RimSize', '/Search/searchapi/selectprofile');
    renderRim();
    clickRim();
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