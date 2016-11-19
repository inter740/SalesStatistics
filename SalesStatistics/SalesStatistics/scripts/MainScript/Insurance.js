$(function () {
    $("#AddInsuranceButton").click(function () {
        "use strict";
        var price = $('#InsurancePrice').val();
        var type = $('#typeInsurance option:selected').attr('id');

        var insurance = { "Price": price, "Type": type };

        $.ajax({
            type: "POST",
            url: "http://localhost:50601/Home/AddInsurance",
            dataType: "json",
            data: { insurance: insurance }
        });
        $('#InsurancePrice').val('');

        $('#insuranceSuccessfullyAddedText').fadeIn(200);
        $('#insuranceSuccessfullyAddedText').fadeOut(3500);
    });
})