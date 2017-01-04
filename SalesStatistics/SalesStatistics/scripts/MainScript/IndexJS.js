var way = 'http://localhost:50601';

$('#StatisticsContainer').css('border-color', '#4169e1');
$('#linkBest').css('background-color', '#4169e1');

$('#linkBest').click(function () {
    $('#StatisticsContainer').css('border-color', '#4169e1');
    $('#linkBest').css('background-color', '#4169e1');
    $('#linkAppliances').css('background-color', '#478CFB');
    $('#linkInsurance').css('background-color', '#478CFB');
    $('#linkSim').css('background-color', '#478CFB');

    changeDateToDefault();
    ReturnBestsellersForMonth();
});

$('#linkAppliances').click(function () {
    $('#StatisticsContainer').css('border-color', '#4169e1');
    $('#linkAppliances').css('background-color', '#4169e1');
    $('#linkBest').css('background-color', '#478CFB');
    $('#linkInsurance').css('background-color', '#478CFB');
    $('#linkSim').css('background-color', '#478CFB');

    changeDateToDefault();
    ReturnAppliancesForMonth();
});

$('#linkSim').click(function () {
    $('#StatisticsContainer').css('border-color', '#4169e1');
    $('#linkSim').css('background-color', '#4169e1');
    $('#linkAppliances').css('background-color', '#478CFB');
    $('#linkInsurance').css('background-color', '#478CFB');
    $('#linkBest').css('background-color', '#478CFB');

    changeDateToDefault();
    $('#searchByOperatorsForSim').prop('checked', false);
    $('#selectSearchByOperatorsForSim').prop('disabled', true);
    ReturnSimForMonthForOperator();
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

function setDate() {
    var m = 0;
    while (m < 12) {
        m++;
        $('.selectMonth').append($('<option class="optionInSelectMonth" value="' + m + '">' + m + '</option>'));
    }
    var monthNow = $('.selectMonth').data("month");
    $(".selectMonth [value=" + monthNow + "]").attr("selected", "selected");

    var y = 0;
    while (y < 4) {
        var year = $('.selectYear').data("year") - y;
        y++;
        $('.selectYear').append($('<option class="optionInSelectMonth" value="' + year + '">' + year + '</option>'));
    }
    var yearNow = $('.selectYear').data("year");
    $(".selectYear [value=" + yearNow + "]").attr("selected", "selected");
}

function changeDateToDefault() {
    var monthNow = $('.selectMonth').data("month");
    $('.selectMonth').val(monthNow);

    var yearNow = $('.selectYear').data("year");
    $('.selectYear').val(yearNow);
}

$('.selectYear').change(function() {
    ReturnBestsellersForMonth();
});

//--------------------------------------------------------------------------Start Bestsellers

function returnTabaleForBestsellers(obj) {

    $('.addedTr').detach();

    for (var i = 0; i < obj.length; i++) {
        var date = obj[i].Date;
        $('#BestsellerTable').append('<tr class="addedTr"><td> ' + date + ' </td><td>' + obj[i].Price + '</td><td>' + obj[i].Count + '</td></tr>');
    }

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
};
function ReturnBestsellersForMonth() {
    var month = $('.selectMonth').val();
    var year = $('.selectYear').val();
    var dto = {
        Month: month,
        Year: year
}

    $.ajax({
        type: "POST",
        url: way + '/Statistics/ReturnBestsellersPerMonth',
        dataType: "json",
        data: { dto: dto },
        success: function (obj) {
            returnTabaleForBestsellers(obj);
        }
    });
}

//Startup page
$('#startingMontForBestsellers').prop('disabled', true);
$('#finalMonthForBestsellers').prop('disabled', true);

setDate();

ReturnBestsellersForMonth();

//filters by one month
$('#searchByMonth').click(function () {
    changeDateToDefault();

    $('#searchByPeriod').prop('checked', false);
    $('#startingMontForBestsellers').prop('disabled', true);
    $('#finalMonthForBestsellers').prop('disabled', true);

    $('#selectSearchByMonth').prop('disabled', false);

    ReturnBestsellersForMonth();
});

//change selected month in #selectSearchByMonth
$('#selectSearchByMonth').change(function () {

    ReturnBestsellersForMonth();
});


//filters by period

function returnBestsellersByPeriod() {
    $.ajax({
        type: "POST",
        url: way + '/Statistics/ReturnBestsellersForPeriod',
        dataType: "json",
        data: { dto: periodBest() },
        success: function (obj) {
            returnTabaleForBestsellers(obj);
        }
    });
}

function periodBest() {
    var startingMonth = $('#startingMontForBestsellers').val();
    var finalMonth = $('#finalMonthForBestsellers').val();
    var year = $('.selectYear').val();
    var dto = {
        StartMonth: startingMonth,
        EndMonth: finalMonth,
        Year: year
}

    return dto;
}

$('#searchByPeriod').click(function () {
    $('#searchByMonth').prop('checked', false);
});


$('#searchByPeriod').click(function () {
    changeDateToDefault();

    $('#searchByMonth').prop('checked', false);
    $('#startingMontForBestsellers').prop('disabled', false);
    $('#finalMonthForBestsellers').prop('disabled', false);

    $('#selectSearchByMonth').prop('disabled', true);

    returnBestsellersByPeriod();
});

$('#startingMontForBestsellers, #finalMonthForBestsellers').change(function () {

    returnBestsellersByPeriod();
});

//--------------------------------------------------------------------------End Bestsellers



//------------------------------------------------------------------------Start Appliances
function returnTabaleForApplianceses(obj) {

    $('.addedTr').detach();

    for (var i = 0; i < obj.length; i++) {
        var date = obj[i].Date;
        $('#AppliancesTable').append('<tr class="addedTr"><td> ' + date + ' </td><td>' + obj[i].Price + '</td><td>' + obj[i].Count + '</td></tr>');
    }

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



    $('#NumberOfSalesAppliancesLabel').text(count);
    $('#totalPriceOfSalesAppliancesLabel').text(totalPrice);
    $('#arangePriceOfSalesAppliancesLabel').text(arangePrice);
};

function ReturnAppliancesForMonth() {

    var month = $('#selectSearchByMonthForAppliances').val();

    var dto = { Month: month };

    $.ajax({
        type: "POST",
        url: way + '/Statistics/ReturnAppliancesesForMonth',
        dataType: "json",
        data: { dto: dto },
        success: function (obj) {
            returnTabaleForApplianceses(obj);

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
}

//starting page
$('#startingMonthForAppliances').prop('disabled', true);
$('#finalMonthForAppliances').prop('disabled', true);


//filters by one month
$('#searchByMonthForAppliances').click(function () {
    changeDateToDefault();

    $('#searchByPeriodForAppliances').prop('checked', false);
    $('#startingMonthForAppliances').prop('disabled', true);
    $('#finalMonthForAppliances').prop('disabled', true);

    $('#selectSearchByMonthForAppliances').prop('disabled', false);

    ReturnAppliancesForMonth();

});

$('#selectSearchByMonthForAppliances').change(function () {

    ReturnAppliancesForMonth();
});



//filters by period

function ReturnAppliancesForPeiod() {
    $.ajax({
        type: "POST",
        url: way + '/Statistics/ReturnAppliancesesForPeriod',
        dataType: "json",
        data: { dto: periodAppliances() },
        success: function (obj) {
            returnTabaleForApplianceses(obj);
        }
    });
}

function periodAppliances() {
    var startingMonth = $('#startingMonthForAppliances').val();
    var finalMonth = $('#finalMonthForAppliances').val();
    var dto = {
        StartMonth: startingMonth,
        EndMonth: finalMonth
    }

    return dto;
}

$('#searchByPeriodForAppliances').click(function () {
    $('#searchByMonthForAppliances').prop('checked', false);
});


$('#searchByPeriodForAppliances').click(function () {
    changeDateToDefault();
    $('#searchByMonthForAppliances').prop('checked', false);
    $('#startingMonthForAppliances').prop('disabled', false);
    $('#finalMonthForAppliances').prop('disabled', false);

    $('#selectSearchByMonthForAppliances').prop('disabled', true);

    ReturnAppliancesForPeiod();
});

$('#startingMonthForAppliances, #finalMonthForAppliances').change(function () {
    $('#selectSearchByMonthForAppliances').prop('checked', false);
    $('#selectSearchByMonthForAppliances').prop('disabled', true);

    $('#finalMonthForAppliances').prop('disabled', false);
    $('#startingMonthForAppliances').prop('disabled', false);

    ReturnAppliancesForPeiod();
});

//----------------------------------------------------------------------------------End Appliances

//----------------------------------------------------------------------------------Starting SimCard

function returnTabaleForSim(obj) {

    $('.addedTr').detach(); //clean off

    for (var i = 0; i < obj.length; i++) {

        $('#SimTable').append('<tr class="addedTr"><td> ' + obj[i].Date + ' </td><td>' + obj[i].Operator + '</td></tr>');
    }

    var count = obj.length;

    $('#NumberOfSalesSimLabel').text(count);
};

//startup page
$('#selectSearchByOperatorsForSim').prop('disabled', true);


//search witch the operator
$('#searchByOperatorsForSim').click(function () {
    checkOnSelectOperator();
});


function ReturnSimForMonthForOperator(operator) {

    var controllerMethod;


    if (operator == null) {
        controllerMethod = way + '/Statistics/ReturnSimForMonth';
    } else {
        controllerMethod = way + '/Statistics/ReturnSimForMonthForOperator';
    }

    var month = $('#selectSearchByMonthForSim').val();

    var dto = { Month: month, Operator: operator };

    $.ajax({
        type: "POST",
        url: controllerMethod,
        dataType: "json",
        data: { dto: dto },
        success: function (obj) {
            returnTabaleForSim(obj);

            var count = obj.length;
            $('#NumberOfSalesSimLabel').text(count);
        }
    });

}

function checkWhichSearchIsActiveByMonthOrForPeriod(operator) {
    if ($('#searchByMonthForSim').is(':checked')) {
        return ReturnSimForMonthForOperator(operator);
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
        changeDateToDefault();
        checkOnSelectOperator();
    } else {
        ReturnSimForMonthForOperator();
    }

    $('#searchForPeriodForSim').prop('checked', false);
    $('#startingMonthForSim').prop('disabled', true);
    $('#finalMonthForSim').prop('disabled', true);

    $('#selectSearchByMonthForSim').prop('disabled', false);


});

$('#selectSearchByMonthForSim').change(function () {
    var selectedOperator = null;
    if ($('#selectSearchByOperatorsForSim').prop('disabled') == false) {
        selectedOperator = $('#selectSearchByOperatorsForSim').val();
        $(checkWhichSearchIsActiveByMonthOrForPeriod(selectedOperator));
    }

    $(checkWhichSearchIsActiveByMonthOrForPeriod(selectedOperator));
});


$('#selectSearchByOperatorsForSim').change(function () {
    var selectedOperator = $('#selectSearchByOperatorsForSim').val();
    $(ReturnSimForMonthForOperator(selectedOperator));
});



//filters by period

function SearchForPeriodForSim(operator) {
    var controllerMethod;
    if (operator == undefined) {
        controllerMethod = way + '/Statistics/ReturnSimForMonth';
        operator = null;
    } else {
        controllerMethod = way + '/Statistics/ReturnSimForPeriodForOperator';
    }

    var startMonth = $('#startingMonthForSim').val();
    var finalMonth = $('#finalMonthForSim').val();

    var dto = { StartMonth: startMonth, EndMonth: finalMonth, Operator: operator };

    $.ajax({
        type: "POST",
        url: controllerMethod,
        dataType: "json",
        data: { dto: dto },
        success: function (obj) {
            ReturnSimForPeriodForOperator(operator);

            var count = obj.length;
            $('#NumberOfSalesSimLabel').text(count);
        }
    });
}

function ReturnSimForPeriodForOperator(operator) {

    var controllerMethod;


    if (operator == null) {
        controllerMethod = way + '/Statistics/ReturnSimForPeriod';
    } else {
        controllerMethod = way + '/Statistics/ReturnSimForPeriodForOperator';
    }

    var startMonth = $('#startingMonthForSim').val();
    var finalMonth = $('#finalMonthForSim').val();
    var dto = { StartMonth: startMonth, EndMonth: finalMonth, Operator: operator };

    $.ajax({
        type: "POST",
        url: controllerMethod,
        dataType: "json",
        data: { dto: dto },
        success: function (obj) {
            returnTabaleForSim(obj);

            var count = obj.length;
            $('#NumberOfSalesSimLabel').text(count);
        }
    });

}

$('#startingMonthForSim,#finalMonthForSim').change(function () {
    var selectedOperator = null;
    if ($('#selectSearchByOperatorsForSim').prop('disabled') === false) {
        selectedOperator = $('#selectSearchByOperatorsForSim').val();
    }
    $(checkWhichSearchIsActiveByMonthOrForPeriod(selectedOperator));
});

$('#searchForPeriodForSim').click(function () {
    if ($('#searchForPeriodForSim').is(':checked')) {
        changeDateToDefault();
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
