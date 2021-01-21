var loginController = function () {
    this.initialize = function () {
        registerEvents();
    }

    var registerEvents = function () {
        //$('#frmLogin').validate({
        //    errorClass: 'red',
        //    ignore: [],
        //    lang: 'en',
        //    rules: {
        //        userName: {
        //            required: true
        //        },
        //        password: {
        //            required: true
        //        }
        //    }
        //});
        $('#btnLogin').on('click', function (e) {
            //if ($('#frmLogin').valid()) {
                e.preventDefault();
                var user = $('#txtUserName').val();
                var password = $('#txtPassword').val();
                login(user, password);
            //}

        });
    }

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
            success: function (res) {
                if (res.Success) {
                    window.location.href = "/Home/Index";
                }
                else {
                    alone.notify('Login failed', 'error');
                }
            }
        })
    }
}