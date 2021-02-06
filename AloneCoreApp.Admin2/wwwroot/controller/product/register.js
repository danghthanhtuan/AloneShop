var productRegisterController = function () {
    this.initialize = function () {
        loadData();
        loadCategories();
        registerEvents();
        //registerControls();
    }
    function registerEvents() {
        $('#btnBack').on('click', function (e) {
            e.preventDefault();
            window.location.href = alone.getParameterByName('source');
        });



        // Validate Form Product
        $('#frmProduct').validate({
            ignore: ':hidden:not(:checkbox)',
            errorElement: 'label',
            errorClass: 'is-invalid',
            validClass: 'is-valid',
            rules: {
                inputProductName: {
                    required: true
                },
                inputPrice: {
                    required: true
                },
                inputPricePromotion: {
                    required: true
                },
                inputPriceOriginal: {
                    required: true
                },
                inputCategory: {
                    required: true
                }
            }
        });

        $('#btnSave').on('click', function (e) {
            if ($('#frmProduct').valid()) {
                $.ajax({
                    type: "post",
                    url: "/Product/AddProduct",
                    data: createProducPostData(),
                    dataType: "json",
                    beforesend: function () {
                        alone.startloading();
                    },
                    success: function (response) {
                        alone.notify('Add product successful', 'success');
                        alone.stopLoading();
                        window.location.href = '/product/index';
                    },
                    error: function () {
                        alone.notify('has an error in save product progress', 'error');
                        alone.stopLoading();
                    }
                });
                return false;
            }

        });
    }

    function loadData() {
        if (parseInt(alone.getParameterByName('id')) > 0) {
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
    }

    // Load danh sách category vào ddl
    function loadCategories() {
        $.ajax({
            type: "GET",
            url: "/Product/GetAllProductCategory",
            dataType: 'json',
            success: function (res) {
                var render = "<option value=''>---Select Category---</option>";
                $.each(res.Result, function (i, item) {
                    render += "<option value='" + item.Id + "'>" + item.Name + "</option>";
                });
                $("#ddlCategory").html(render);
            },
            error: function (status) {
                alone.notify('Cannot load data of ProductCategory', 'danger');
            }
        })
    }
}
function createProducPostData() {
    //var image = $('#txtImageM').val();
    //var content = CKEDITOR.instances.txtContentM.getData();
    //var status = $('#ckStatusM').prop('checked') == true ? 1 : 0;
    //var hot = $('#ckHotM').prop('checked');
    //var showHome = $('#ckShowHomeM').prop('checked');

    var data = {
        Id: $('#hdfProductId').val(),
        Name: $('#txtProductName').val(),
        CategoryId: $('#ddlCategory').val(),
        Image: '',
        Price: $('#txtPrice').val(),
        OriginalPrice: $('#txtOriginalPrice').val(),
        PromotionPrice: $('#txtPromotionPrice').val(),
        Description: '',
        Content: '',
        HomeFlag: true,
        HotFlag: true,
        Tags: $('#txtTags').val(),
        //Unit: unit,
        Status: 1,
        SeoPageTitle: $('#txtSeoPageTitle').val(),
        SeoAlias: $('#txtSeoAliasM').val(),
        SeoKeywords: $('#txtSeoKeyword').val(),
        SeoDescription: $('#txtSeoPageTitle').val()
    }
    return data;
}


function bindData(data) {
    //alone.notify('su', 'success');
    $('#txtProductName').val(data.Name);
    $('#imgProduct').prop('src', data.Image);
    $('#txtPrice').val(data.Price);
    $('#txtPromotionPrice').val(data.PromotionPrice);
    $('#txtOriginalPrice').val(data.OriginalPrice);
}
