var way = 'http://localhost:50601';

function CreateTabale(obj) {
    $('.addedTr').detach(); //clean off
    for (var i = 0; i < obj.length; i++) {
        $('.AdminTable').append('<tr class="addedTr"><td> ' + obj[i].LastName + ' </td><td>' + obj[i].FirstName + '</td></tr>');
    }
    var count = obj.length;
    $('#NumberOfUsers').text(count);
};

function createList(obj) {
    $('#adminList').empty();
    for (var i = 0; i < obj.length; i++) {
        $('#adminList').append('<div class="userListBox"><input class="addedList" id="input' + obj[i].Id + '" data-userId="' + obj[i].Id + '" value="' + obj[i].LastName + ' ' + obj[i].FirstName + '" disabled="true"/></div> ' +
            '<div><button class="changeBtn" id="changeBtn' + obj[i].Id + '" data-userId="' + obj[i].Id + '">Change</button> ' +
            '<button class="adminBtn" data-userId="' + obj[i].Id + '">Delete</button></div> </br>');
    }
}

function ReturnAllUsers() {
    $.ajax({
        type: "POST",
        url: way + '/Admin/GetAllUsers',
        dataType: "json",
        data: {},
        success: function(obj) {
            createList(obj);
            var count = obj.length;
            $('#NumberOfUsers').text(count);
        }
    });
}

$('#showAllUsers').click(function() {
    ReturnAllUsers();
});

$('#changeBtn').on("click", function () {
    alert(1);
});

//todo change and other function change db
$(document).on("click", ".changeBtn", function () {
    var inputId = $(this).data("userid");
    $("#input" + inputId + "").prop("disabled", false);
    alert(inputId);
});