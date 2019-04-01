$(document).ready(function () {

    var addButton = document.getElementById("AddButton");
    var listButton = document.getElementById("ListButton");
    var hook = document.getElementById("hook");
    var baseURL = "https://localhost:44350/admin/"

    $.ajax({
        url: baseURL + 'AddList/',
        type: 'get',
        success: function (data) {
            $(hook).html(data);
        }
    });

    $(addButton).on("click", function () {
        $.ajax({
            url: baseURL + 'AddVideo/',
            type: 'get',
            success: function (data) {
                $(hook).html(data);
            }
        });
    });

    $(listButton).on("click", function () {
        $.ajax({
            url: baseURL + 'AddList/',
            type: 'get',
            success: function (data) {
                $(hook).html(data);
            }
        });
    });
});