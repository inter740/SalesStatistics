$(function () {
    $("#AddSim").click(function () {
        "use strict";
        var operator = $('#operators option:selected').text();

        var simCard = { "Operator": operator };

        $.ajax({
            type: "POST",
            url: "Home/AddSimCard",
            dataType: "json",
            data: { simCard: simCard }
        });
    });
})