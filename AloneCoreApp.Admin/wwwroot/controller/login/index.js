﻿/**
 * LOGIN JS
 * */

var loginController = function () {
    this.initialize = function () {
        registerEvents();
    }

    var registerEvents = function () {
        $('#btnLogin').on('click', function (e) {         
            if (validateLogin()) {
                e.preventDefault();
                var user = $('#txtUserName').val();
                var password = $('#txtPassword').val();
                login(user, password);
            } else return false;
        });
    }

    // Validata when login
    function validateLogin() {
        var user = $('#txtUserName').val();
        if (user === '' || user === 'underfined') {
            alone.notify('Tài khoản không được để trống', 'danger');
            return false;
        }
        var pass = $('#txtPassword').val();
        if (pass === '' || pass === 'underfined') {
            alone.notify('Mật khẩu không được để trống', 'danger');
            return false;
        }

        return true;
    }

    // Login
    var login = function (user, pass) {
        $.ajax({
            type: 'POST',
            data: JSON.stringify( {
                UserName: user,
                Password: pass
            }),
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            url: '/Account/Login',
            beforeSend: function () {
                alone.startLoading();
            },
            success: function (res) {
                if (res.Success) {
                    alone.stopLoading();
                    window.location.href = '/Home/Index';
                }
                else {
                    alone.notify(res.Messages, 'danger');
                    alone.stopLoading();
                }
            },
            error: function () {
                alone.notify('Có lỗi xảy ra khi đăng nhập!', 'danger');
                alone.stopLoading();
            }
        })
    }
}