$(function () {
    $("#AddInsuranceButton").click(function () {
        "use strict";
        var price = $('#InsurancePrice').val();
        var type = $('#typeInsurance option:selected').attr('id');

        var insurance = { "Price": price, "Type": type };

        $.ajax({
            type: "POST",
            url: "Home/AddInsurance",
            dataType: "json",
            data: { insurance: insurance }
        });
        $('#InsurancePrice').val('');
    });
})