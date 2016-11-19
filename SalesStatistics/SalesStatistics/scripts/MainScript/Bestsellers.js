$(function () {
    $("#AddBestseller").click(function () {
        "use strict";
        var price = $('#BestsellersPrice').val();
        var count = $('#BestsellersCount').val();
        var id = $('#user').data('userid');

        var bestseller = { "Price": price, "Count": count, UserId: id };

        $.ajax({
            type: "POST",
            url: "http://localhost:50601/Home/AddBestsellers",
            dataType: "json",
            data: { bestseller: bestseller }
        });
        $('#BestsellersPrice').val('');
        $('#BestsellersCount').val('1');

        $('#bestsellersSuccessfullyAddedText').fadeIn(200);
        $('#bestsellersSuccessfullyAddedText').fadeOut(3500);
    });
})