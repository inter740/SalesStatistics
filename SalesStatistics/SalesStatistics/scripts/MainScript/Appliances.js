$(function () {
    $('#Large').prop("checked", true);
    $('#Small').prop("checked", false);

    $('#Large,#kbt').click(function () {
        $('#Large').prop("checked", true);
        $('#Small').prop("checked", false);
    });
    $('#Small,#mbt').click(function () {
        $('#Small').prop("checked", true);
        $('#Large').prop("checked", false);
    });


    $("#AddAppliances").click(function () {
        "use strict";
        var price = $('#AppliancesPrice').val();
        var count = $('#AppliancesCount').val();
        var type = $(".typeAppliances:checked").val();

        var appliances = { "Price": price, "Count": count, "Type": type };

        $.ajax({
            type: "POST",
            url: "http://localhost:50601/Home/AddAppliances",
            dataType: "json",
            data: { appliances: appliances }
        });

        $('#AppliancesPrice').val('');
        $('#AppliancesCount').val('1');

        $('#appliancesSuccessfullyAddedText').fadeIn(200);
        $('#appliancesSuccessfullyAddedText').fadeOut(3500);
    });
})