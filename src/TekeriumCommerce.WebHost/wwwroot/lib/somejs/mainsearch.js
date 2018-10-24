$('select#Profile').change(function () {
    let v = JSON.stringify({
        Width: $('select#Width').val(),
        Profile: $('select#Profile').val(),
        SearchCriteriaOptions: 2
    });
    action(v, 'select#RimSize', '/search/selectprofile');
});

$('select#Width').change(function () {
    let v = JSON.stringify({
        Width: $('select#Width').val(),
        Profile: null,
        SearchCriteriaOptions: 1
    });
    action(v, 'select#Profile', '/search/selectwidth');
});

function action(v, to, url) {
    console.log(v);
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: url,
        dataType: 'application/json',
        data: v,
        statusCode: {
            200: function (result) {
                var text = JSON.parse(result.responseText);
                var selectoption = '';

                $.each(text,
                    function (i) {
                        selectoption += '<option value="' + text[i] + '">' + text[i] + '</option>';
                    });
                $(to).append(selectoption);

                console.log(selectoption);
            }
        }
    });
}