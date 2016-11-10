var way = 'http://localhost:50601';

$('#StatisticsContainer').css('border-color', '#4169e1');
$('#linkBest').css('background-color', '#4169e1');

$('#linkBest').click(function () {
    $('#StatisticsContainer').css('border-color', '#4169e1');
    $('#linkBest').css('background-color', '#4169e1');
    $('#linkAppliances').css('background-color', '#478CFB');
    $('#linkInsurance').css('background-color', '#478CFB');
    $('#linkSim').css('background-color', '#478CFB');
});

$('#linkAppliances').click(function () {
    $('#StatisticsContainer').css('border-color', '#4169e1');
    $('#linkAppliances').css('background-color', '#4169e1');
    $('#linkBest').css('background-color', '#478CFB');
    $('#linkInsurance').css('background-color', '#478CFB');
    $('#linkSim').css('background-color', '#478CFB');
});

$('#linkSim').click(function () {
    $('#StatisticsContainer').css('border-color', '#4169e1');
    $('#linkSim').css('background-color', '#4169e1');
    $('#linkAppliances').css('background-color', '#478CFB');
    $('#linkInsurance').css('background-color', '#478CFB');
    $('#linkBest').css('background-color', '#478CFB');
});

$('#linkInsurance').click(function () {
    $('#StatisticsContainer').css('border-color', '#4169e1');
    $('#linkInsurance').css('background-color', '#4169e1');
    $('#linkAppliances').css('background-color', '#478CFB');
    $('#linkBest').css('background-color', '#478CFB');
    $('#linkSim').css('background-color', '#478CFB');
});

$('#linkAppliances').on('click', function () {
    $('.tab').hide();
    $('#containerForAppliances').show();
});

$('#linkBest').on('click', function () {
    $('.tab').hide();
    $('#containerForBestsellers').show();
});

$('#linkSim').on('click', function () {
    $('.tab').hide();
    $('#containerForSimCard').show();
});

$('#linkInsurance').on('click', function () {
    $('.tab').hide();
    $('#containerForInsurance').show();
});



$.ajax({
    type: "POST",
    url: way + '/Home/GetUserName',
    success: function (name) {

        $('#user').prop('hidden', false);
        $('.userName').text(name);
        if (name == "") {
            $('#user').prop('hidden', true);
        }
    }
});

function returnTabaleForBestsellers(obj) {

    $('.addedTr').detach();

    for (var i = 0; i < obj.length; i++) {
        var date = obj[i].Date;
        $('#BestsellerTable').append('<tr class="addedTr"><td> ' + date + ' </td><td>' + obj[i].Price + '</td><td>' + obj[i].Count + '</td></tr>');
    }
};



//--------------------------------------------------------------------------Start Bestsellers

//Startup page
$('#startingMontForBestsellers').prop('disabled', true);
$('#finalMonthForBestsellers').prop('disabled', true);

var m = 0;
while (m < 12) {
    m++;
    $('.selectMonth').append($('<option class="optionInSelectMonth" value="' + m + '">' + m + '</option>'));
}
var monthNow = $('.selectMonth').data("month");
$(".selectMonth [value=" + monthNow + "]").attr("selected", "selected");

function changeValueMonthToDefault() {
    var monthNow = $('.selectMonth').data("month");
    $('.selectMonth').val(monthNow);
}

function ReturnBestsellersPerMonth(month) {
    $.ajax({
        type: "POST",
        url: way + '/Statistics/ReturnPerMonth',
        dataType: "json",
        data: { month: month },
        success: function (obj) {
            returnTabaleForBestsellers(obj);

            var totalPrice = 0;
            var count = 0;
            var arangePrice = 0;

            for (var i = 0; i < obj.length; i++) {
                totalPrice += obj[i].Price;
                count += obj[i].Count;
            }

            if (totalPrice === 0) {
                arangePrice = 0;
            } else {
                arangePrice += Math.ceil(totalPrice / count);
            }

            $('#NumberOfSalesHitsLabel').text(count);
            $('#totalPriceOfSalesHitsLabel').text(totalPrice);
            $('#arangePriceOfSalesHitsLabel').text(arangePrice);
        }
    });
}

var month = $('.selectMonth').val();

ReturnBestsellersPerMonth(month);

//filters by one month
$('#searchByMonth').click(function () {
    changeValueMonthToDefault();

    $('#searchByPeriod').prop('checked', false);
    $('#startingMontForBestsellers').prop('disabled', true);
    $('#finalMonthForBestsellers').prop('disabled', true);

    $('#selectSearchByMonth').prop('disabled', false);

    var month = $('#selectSearchByMonth').val();

    ReturnBestsellersPerMonth(month);
});

//change selected month in #selectSearchByMonth
$('#selectSearchByMonth').change(function () {

    var month = $('#selectSearchByMonth').val();

    ReturnBestsellersPerMonth(month);
});


//filters by period


$('#searchByPeriod').click(function () {
    $('#searchByMonth').prop('checked', false);
});


$('#searchByPeriod').click(function () {
    changeValueMonthToDefault();

    $('#searchByMonth').prop('checked', false);
    $('#startingMontForBestsellers').prop('disabled', false);
    $('#finalMonthForBestsellers').prop('disabled', false);

    $('#selectSearchByMonth').prop('disabled', true);

    var startingMonth = $('#startingMontForBestsellers').val();
    var finalMonth = $('#finalMonthForBestsellers').val();
    var dto = { "StartMonth": startingMonth, "EndMonth": finalMonth };
    $.ajax({
        type: "POST",
        url: way + '/Statistics/ReturnHitsPerPeriod',
        dataType: "json",
        data: { dto: dto },
        success: function (obj) {
            var totalPrice = 0;
            var count = 0;
            var arangePrice = 0;

            for (var i = 0; i < obj.length; i++) {
                totalPrice += obj[i].Price;
                count += obj[i].Count;
            }

            if (totalPrice == 0) {
                arangePrice = 0;
            } else {
                arangePrice += Math.ceil(totalPrice / count);
            }

            $('#NumberOfSalesHitsLabel').text(count);
            $('#totalPriceOfSalesHitsLabel').text(totalPrice);
            $('#arangePriceOfSalesHitsLabel').text(arangePrice);
        }
    });
});

$('#startingMontForBestsellers, #finalMonthForBestsellers').change(function () {

    var startingMonth = $('#startingMontForBestsellers').val();
    var finalMonth = $('#finalMonthForBestsellers').val();

    $.ajax({
        type: "POST",
        url: way + '/Statistics/ReturnHitsPerPeriod',
        dataType: "json",
        data: { startingMonth: startingMonth, finalMonth: finalMonth },
        success: function (obj) {
            var totalPrice = 0;
            var count = 0;
            var arangePrice = 0;

            for (var i = 0; i < obj.length; i++) {
                totalPrice += obj[i].Price;
                count += obj[i].Count;
            }

            if (totalPrice == 0) {
                arangePrice = 0;
            } else {
                arangePrice += Math.ceil(totalPrice / count);
            }

            $('#NumberOfSalesHitsLabel').text(count);
            $('#totalPriceOfSalesHitsLabel').text(totalPrice);
            $('#arangePriceOfSalesHitsLabel').text(arangePrice);
        }
    });
});

//--------------------------------------------------------------------------End Bestsellers



//------------------------------------------------------------------------Start Appliances
//starting page
$('#startingMonthForAppliances').prop('disabled', true);
$('#finalMonthForAppliances').prop('disabled', true);

var month = $('#selectSearchByMonthForAppliances').val();
$.ajax({
    type: "POST",
    url: way + '/Statistics/ReturnAppliancesesPerMonth',
    dataType: "json",
    data: { month: month },
    success: function (obj) {
        var totalPrice = 0;
        var count = 0;
        var arangePrice = 0;

        for (var i = 0; i < obj.length; i++) {
            totalPrice += obj[i].Price;
            count += obj[i].Count;
        }

        if (totalPrice === 0) {
            arangePrice = 0;
        } else {
            arangePrice += Math.ceil(totalPrice / count);
        }

        $('#NumberOfSalesAppliancesLabel').text(count);
        $('#totalPriceOfSalesAppliancesLabel').text(totalPrice);
        $('#arangePriceOfSalesAppliancesLabel').text(arangePrice);
    }
});


//filters by one month
$('#searchByMonthForAppliances').click(function () {
    changeValueMonthToDefault();

    $('#searchByPeriodForAppliances').prop('checked', false);
    $('#startingMonthForAppliances').prop('disabled', true);
    $('#finalMonthForAppliances').prop('disabled', true);

    $('#selectSearchByMonthForAppliances').prop('disabled', false);

    var month = $('#selectSearchByMonthForAppliances').val();
    $.ajax({
        type: "POST",
        url: way + '/Statistics/ReturnAppliancesesPerMonth',
        dataType: "json",
        data: { month: month },
        success: function (obj) {
            var totalPrice = 0;
            var count = 0;
            var arangePrice = 0;

            for (var i = 0; i < obj.length; i++) {
                totalPrice += obj[i].Price;
                count += obj[i].Count;
            }

            if (totalPrice === 0) {
                arangePrice = 0;
            } else {
                arangePrice += Math.ceil(totalPrice / count);
            }

            $('#NumberOfSalesAppliancesLabel').text(count);
            $('#totalPriceOfSalesAppliancesLabel').text(totalPrice);
            $('#arangePriceOfSalesAppliancesLabel').text(arangePrice);
        }
    });
});

$('#selectSearchByMonthForAppliances').change(function () {

    var month = $('#selectSearchByMonthForAppliances').val();
    $.ajax({
        type: "POST",
        url: way + '/Statistics/ReturnAppliancesesPerMonth',
        dataType: "json",
        data: { month: month },
        success: function (obj) {
            var totalPrice = 0;
            var count = 0;
            var arangePrice = 0;

            for (var i = 0; i < obj.length; i++) {
                totalPrice += obj[i].Price;
                count += obj[i].Count;
            }

            if (totalPrice === 0) {
                arangePrice = 0;
            } else {
                arangePrice += Math.ceil(totalPrice / count);
            }

            $('#NumberOfSalesAppliancesLabel').text(count);
            $('#totalPriceOfSalesAppliancesLabel').text(totalPrice);
            $('#arangePriceOfSalesAppliancesLabel').text(arangePrice);
        }
    });
});

$('#searchByPeriodForAppliances').click(function () {
    $('#searchByMonthForAppliances').prop('checked', false);
});

//filters by period
$('#searchByPeriodForAppliances').click(function () {
    changeValueMonthToDefault();
    $('#searchByMonthForAppliances').prop('checked', false);
    $('#startingMonthForAppliances').prop('disabled', false);
    $('#finalMonthForAppliances').prop('disabled', false);

    $('#selectSearchByMonthForAppliances').prop('disabled', true);

    var startingMonth = $('#startingMonthForAppliances').val();
    var finalMonth = $('#finalMonthForAppliances').val();

    $.ajax({
        type: "POST",
        url: way + '/Statistics/ReturnAppliancesesPerPeriod',
        dataType: "json",
        data: { startingMonth: startingMonth, finalMonth: finalMonth },
        success: function (obj) {
            var totalPrice = 0;
            var count = 0;
            var arangePrice = 0;

            for (var i = 0; i < obj.length; i++) {
                totalPrice += obj[i].Price;
                count += obj[i].Count;
            }

            if (totalPrice === 0) {
                arangePrice = 0;
            } else {
                arangePrice += Math.ceil(totalPrice / count);
            }

            $('#NumberOfSalesAppliancesLabel').text(count);
            $('#totalPriceOfSalesAppliancesLabel').text(totalPrice);
            $('#arangePriceOfSalesAppliancesLabel').text(arangePrice);
        }
    });
});

$('#startingMonthForAppliances, #finalMonthForAppliances').change(function () {
    $('#selectSearchByMonthForAppliances').prop('checked', false);
    $('#selectSearchByMonthForAppliances').prop('disabled', true);

    $('#finalMonthForAppliances').prop('disabled', false);
    $('#startingMonthForAppliances').prop('disabled', false);

    var startingMonth = $('#startingMonthForAppliances').val();
    var finalMonth = $('#finalMonthForAppliances').val();

    $.ajax({
        type: "POST",
        url: way + '/Statistics/ReturnAppliancesesPerPeriod',
        dataType: "json",
        data: { startingMonth: startingMonth, finalMonth: finalMonth },
        success: function (obj) {
            var totalPrice = 0;
            var count = 0;
            var arangePrice = 0;

            for (var i = 0; i < obj.length; i++) {
                totalPrice += obj[i].Price;
                count += obj[i].Count;
            }

            if (totalPrice === 0) {
                arangePrice = 0;
            } else {
                arangePrice += Math.ceil(totalPrice / count);
            }

            $('#NumberOfSalesAppliancesLabel').text(count);
            $('#totalPriceOfSalesAppliancesLabel').text(totalPrice);
            $('#arangePriceOfSalesAppliancesLabel').text(arangePrice);
        }
    });
});

//----------------------------------------------------------------------------------End Appliances

//----------------------------------------------------------------------------------Starting SimCard
//startup page
$('#selectSearchByOperatorsForSim').prop('disabled', true);
$(SearchByOneMonth());



//search witch the operator
$('#searchByOperatorsForSim').click(function () {
    checkOnSelectOperator();
});


function SearchByOneMonth(operator) {

    var controllerMethod;

    if (operator == undefined) {
        controllerMethod = way + '/Statistics/ReturnSimPerMonth';
    } else {
        controllerMethod = way + '/Statistics/ReturnSimPerMonthByOperator';
    }

    var month = $('#selectSearchByMonthForSim').val();
    $.ajax({
        type: "POST",
        url: controllerMethod,
        dataType: "json",
        data: { month: month, operatorName: operator },
        success: function (obj) {
            var count = obj.length;

            $('#NumberOfSalesSimLabel').text(count);
        }
    });

}

function checkWhichSearchIsActiveByMonthOrForPeriod(operator) {
    if ($('#searchByMonthForSim').is(':checked')) {
        return SearchByOneMonth(operator);
    } else {
        return SearchForPeriodForSim(operator);
    }
}

function checkOnSelectOperator() {
    var selectedOperator;

    if ($("#searchByOperatorsForSim").is(":not(:checked)")) {
        $('#selectSearchByOperatorsForSim').prop('disabled', true);
        $(checkWhichSearchIsActiveByMonthOrForPeriod());
    }
    else {
        $('#selectSearchByOperatorsForSim').prop('disabled', false);

        selectedOperator = $('#selectSearchByOperatorsForSim').val();
        $(checkWhichSearchIsActiveByMonthOrForPeriod(selectedOperator));
    }
}

//filters by one month


$('#searchByMonthForSim').click(function () {
    if ($('#searchByMonthForSim').is(':checked')) {
        changeValueMonthToDefault();
        checkOnSelectOperator();
    } else {
        SearchByOneMonth();
    }

    $('#searchForPeriodForSim').prop('checked', false);
    $('#startingMonthForSim').prop('disabled', true);
    $('#finalMonthForSim').prop('disabled', true);

    $('#selectSearchByMonthForSim').prop('disabled', false);

});

$('#selectSearchByMonthForSim').change(function () {
    var selectedOperator;
    if ($('#selectSearchByOperatorsForSim').prop('disabled') == false) {
        selectedOperator = $('#selectSearchByOperatorsForSim').val();
    }

    $(checkWhichSearchIsActiveByMonthOrForPeriod(selectedOperator));
});


$('#selectSearchByOperatorsForSim').change(function () {
    var selectedOperator = $('#selectSearchByOperatorsForSim').val();
    $(SearchByOneMonth(selectedOperator));
});



//filters by period

function SearchForPeriodForSim(operator) {
    var controllerMethod;
    if (operator == undefined) {
        controllerMethod = way + '/Statistics/ReturnSimPerPeriod';
    } else {
        controllerMethod = way + '/Statistics/ReturnSimPerPeriodByOperator';
    }

    var startMonth = $('#startingMonthForSim').val();
    var finalMonth = $('#finalMonthForSim').val();

    $.ajax({
        type: "POST",
        url: controllerMethod,
        dataType: "json",
        data: { startingMonth: startMonth, finalMonth: finalMonth, operatorName: operator },
        success: function (obj) {
            var count = obj.length;

            $('#NumberOfSalesSimLabel').text(count);
        }
    });
}

$('#startingMonthForSim,#finalMonthForSim').change(function () {
    var selectedOperator;
    if ($('#selectSearchByOperatorsForSim').prop('disabled') === false) {
        selectedOperator = $('#selectSearchByOperatorsForSim').val();
    }
    $(checkWhichSearchIsActiveByMonthOrForPeriod(selectedOperator));
});

$('#searchForPeriodForSim').click(function () {
    if ($('#searchForPeriodForSim').is(':checked')) {
        changeValueMonthToDefault();
        checkOnSelectOperator();
    } else {
        SearchForPeriodForSim();
    }

    $('#searchByMonthForSim').prop('checked', false);
    $('#selectSearchByMonthForSim').prop('disabled', true);

    $('#startingMonthForSim').prop('disabled', false);
    $('#finalMonthForSim').prop('disabled', false);


});

//----------------------------------------------------------------------------------------------------End sim-card
