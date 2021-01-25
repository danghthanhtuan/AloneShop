var productDetailController = function () {
    this.initialize = function () {
        loadData();
        //loadCategories();
        registerEvents();
        //registerControls();
    }
    function registerEvents() {
        $('#btnBack').on('click', function () {
            var url = alone.getParameterByName('source');
            window.location.replace(alone.getParameterByName('source'));    
        });
    }


    function loadData() {
        $.ajax({
            url: "/product/GetProductDetail",
            type: 'get',
            datatype: 'json',
            data: { productId: alone.getParameterByName('id') },
            success: function (res) {
                if (res.Success) {
                    bindData(res.Result);
                }
            },
            error: function (res) {

            }
        });
    }

    function bindData(data) {
        //alone.notify('su', 'success');
        $('#hName').text(data.Name);
        $('#imgProduct').prop('src', data.Image);
        $('#tdPrice').text(data.Price);
        $('#tdName').text(data.ProductCategory.Name);
    }
}