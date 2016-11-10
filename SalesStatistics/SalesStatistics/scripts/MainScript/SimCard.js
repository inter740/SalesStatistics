$(function () {
    $("#AddSim").click(function () {
        "use strict";
        var operator = $('#operators option:selected').text();

        var simCard = { "Operator": operator };

        $.ajax({
            type: "POST",
            url: "http://localhost:50601/Home/AddSimCard",
            dataType: "json",
            data: { simCard: simCard }
        });
    });
})