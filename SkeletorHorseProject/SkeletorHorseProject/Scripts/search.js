$(document).ready(function () {

    $('#search_term').autocomplete({
        source: "/Search/SearchAutoComplete",
        select: function (event, ui) {
            $("#search_id").val(ui.item.Id);
        }
    });

    $('#search_button').click(function (e) {
        if ($('.search_box').is(":visible")) {
            var value = parseInt($('#search_id').val());
            if (value > 0) {
                window.location = '/horseprofile/index/' + value;
            } else if ($('.search_box input').val() === "") {
                $('.search_box').animate({ width: 'toggle' }, 300);
            }
        } else {
            $('.search_box').animate({ width: 'toggle' }, 300);
            $(".search_box input").focus();
        }
    });

    //$('.search_box input').keypress(function (e) {
    //    if (e.which == 13) {
    //        var value = parseInt($('#search_id').val());
    //        if (value > 0) {
    //            window.location = '/horseprofile/index/' + value;
    //        } else if ($('.search_box input').val() === "") {
    //            $('.search_box').animate({ width: 'toggle' }, 300);
    //        }
    //    }
    //});

});