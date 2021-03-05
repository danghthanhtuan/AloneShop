var QuantityManagement = function () {
    var cachedObj = {
        colors: [],
        sizes: []
    }

    this.initialize = function () {
        loadColors();
        loadSizes();
        registerEvents();
    }

    function registerEvents() {
        loadQuantities();   

        //$('body').on('click', '.btn-quantity', function (e) {
        //    e.preventdefault();
        //    var that = $(this).data('id');
        //    $('#hidid').val(that);
        //    loadquantities();          
        //});

        $('body').on('click', '.btn-delete-quantity', function (e) {
            e.preventDefault();
            $(this).closest('tr').remove();
        });

        $('#btn-add-quantity').on('click', function () {
            var template = $('#template-table-quantity').html();
            var render = Mustache.render(template, {
                Id: 0,
                Colors: getColorOptions(null),
                Sizes: getSizeOptions(null),
                Quantity: 0
            });
            $('#table-quantity-content').append(render);
        });

        // Save
        $("#btnSaveQuantity").on('click', function () {
            if (!validateQuantity()) {
                var quantityList = [];
                $.each($('#table-quantity-content').find('tr'), function (i, item) {
                    quantityList.push({
                        Id: $(item).data('id'),
                        //ProductId: $('#hidId').val(),
                        ProductId: alone.getParameterByName('id'),
                        Quantity: $(item).find('input.txtQuantity').first().val(),
                        SizeId: $(item).find('select.ddlSizeId').first().val(),
                        ColorId: $(item).find('select.ddlColorId').first().val(),
                    });
                });
                $.ajax({
                    url: APP_CONFIG.ApiUpdateQuantity + "?productId=" + alone.getParameterByName('id'),
                    data: JSON.stringify(quantityList),
                    type: 'post',
                    contentType: 'application/json',
                    success: function (response) {
                        loadQuantities();
                        alone.notify('Cập nhật thành công!', 'success')
                    },
                    error: function () {
                        alone.notify('Cập nhật không thành công!', 'danger')
                    }
                });
            }     
        });
    }

    function loadQuantities() {
        $.ajax({
            url: APP_CONFIG.ApiGetQuantity,
            data: {
                productId: alone.getParameterByName('id')
            },
            type: 'get',
            dataType: 'json',
            success: function (response) {
                var render = '';
                var template = $('#template-table-quantity').html();
                $.each(response.result, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.id,
                        Colors: getColorOptions(item.colorId),
                        Sizes: getSizeOptions(item.sizeId),
                        Quantity: item.quantity
                    });
                });
                $('#table-quantity-content').html(render);
                //resetFile();
            }
        });
    }

    function loadColors() {
        return $.ajax({
            type: "GET",
            url: APP_CONFIG.ApiGetColorAll,
            contentType: "application/json",
            dataType: "json",
            async: false,
            success: function (response) {
                cachedObj.colors = response.result;
            },
            error: function () {
                alone.notify('Có lỗi xảy ra', 'danger');
            }
        });
    }

    function loadSizes() {
        return $.ajax({
            type: "GET",
            url: APP_CONFIG.ApiGetSizeAll,
            contentType: "application/json",
            dataType: "json",
            async: false,
            success: function (response) {
                cachedObj.sizes = response.result;
            },
            error: function () {
                alone.notify('Có lỗi xảy ra', 'danger');
            }
        });
    }
    function getColorOptions(selectedId) {
        //if (cachedObj.colors.length == 0) loadColors();

        var colors = "<select class='custom-select ddlColorId' style='min-width:120px;'>";
        $.each(cachedObj.colors, function (i, color) {
            if (selectedId === color.id)
                colors += '<option value="' + color.id + '" selected="select">' + color.name + '</option>';
            else
                colors += '<option value="' + color.id + '">' + color.name + '</option>';
        });
        colors += "</select>";
        return colors;
    }

    function getSizeOptions(selectedId) {
        //if (cachedObj.sizes.length == null) loadSizes();

        var sizes = "<select class='custom-select ddlSizeId' style='min-width:120px;'>";
        $.each(cachedObj.sizes, function (i, size) {
            if (selectedId === size.id)
                sizes += '<option value="' + size.id + '" selected="select">' + size.name + '</option>';
            else
                sizes += '<option value="' + size.id + '">' + size.name + '</option>';
        });
        sizes += "</select>";
        return sizes;
    }

    function validateQuantity() {
        var isSuccess = false;
        $.each($('#table-quantity-content').find('tr'), function (i, item) {
            var moreThan0 = parseInt($(item).find('input.txtQuantity').first().val());
            if (moreThan0 < 0) {
                alone.notify('Nhập số lượng lớn hơn 0!', 'danger');
                isSuccess = true;               
            }
        });

        return isSuccess;
    }
}