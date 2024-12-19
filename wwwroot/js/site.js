// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function CreatePerson() {
    $.ajax({
        url: "/People/Create",
        type: "GET",
        data: {}
    }).done(function (result) {
        $('#myModal').modal('show');
        $('#myModalLabel').html('افزودن کاربر جدید');
        $('#myModalBody').html(result);
    });
}

function EditPerson(id) {
    $.ajax({
        url: "/People/Edit/" + id,
        type: "GET",
        data: {}
    }).done(function (result) {
        $('#myModal').modal('show');
        $('#myModalLabel').html('ویرایش کاربر');
        $('#myModalBody').html(result);
    });
}

function DeletePerson(id) {
    $.ajax({
        url: "/People/Delete/" + id,
        type: "GET",
        data: {}
    }).done(function (result) {
        $('#myModal').modal('show');
        $('#myModalLabel').html('آیا از حذف کاربر مطمئن هستید؟');
        $('#myModalBody').html(result);
    });
}

function DetailsPerson(id) {
    $.ajax({
        url: "/People/Details/" + id,
        type: "GET",
        data: {}
    }).done(function (result) {
        $('#myModal').modal('show');
        $('#myModalLabel').html('جزئیات کاربر');
        $('#myModalBody').html(result);
    });
}
