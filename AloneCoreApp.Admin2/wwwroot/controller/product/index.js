var productController = function () {
    this.initialize = function () {
        init();
        loadCategories();
        registerEvents();
        //registerControls();
    }

    function registerEvents() {

        //Init validation
        //$('#frmMaintainance').validate({
        //    errorClass: 'red',
        //    ignore: [],
        //    lang: 'vi',
        //    rules: {
        //        txtNameM: { required: true },
        //        ddlCategoryIdM: { required: true },
        //        txtPriceM: {
        //            required: true,
        //            number: true
        //        },
        //        txtOriginalPriceM: {
        //            required: true,
        //            number: true
        //        },
        //        txtPromotionPriceM: {
        //            required: true,
        //            number: true
        //        }
        //    }
        //});
        $('body').on('keypress', 'input[type="search"]', function (e) {
            //e.preventDefault();
            if (e.key === 'Enter' || e.keyCode === 13) {
                $('#tblProduct').DataTable().ajax.reload();
            }
        });

        // Event on change ddlCategory
        $("#ddlCategory").on('change', function (e) {
            $('#tblProduct').DataTable().ajax.reload();
        })
        //$("#ddlCategory").select2({
        //    tags: true
        //});

        //$('#btnCreate').on('click', function (e) {
        //    resetFormMaintainance();
        //    initTreeDropDownCategory();
        //    $('#modal-add-edit').modal('show');
        //});

        $('body').on('click', '.btn-edit', function (e) {
            e.preventDefault();
            var id = $(this)[0].id;
            var source = encodeURIComponent(window.location.pathname);
            window.location.replace('detail?id=' + id + '&source=' + source);
        });
        $('body').on('click', '.btn-delete', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            alone.confirm('Are you sure to delete?', function () {
                $.ajax({
                    type: "POST",
                    url: "/Product/Delete",
                    data: { id: that },
                    dataType: "json",
                    beforeSend: function () {
                        alone.startLoading();
                    },
                    success: function (response) {
                        alone.notify('Delete successful', 'success');
                        alone.stopLoading();
                        $('#tblProduct').DataTable().ajax.reload();
                    },
                    error: function (status) {
                        alone.notify('Has an error in delete progress', 'error');
                        alone.stopLoading();
                    }
                });
            });
        });

        //$('#btnSave').on('click', function (e) {
        //    if ($('#frmMaintainance').valid()) {
        //        e.preventDefault();
        //        var id = $('#hidIdM').val();
        //        var name = $('#txtNameM').val();
        //        var categoryId = $('#ddlCategoryIdM').combotree('getValue');

        //        var description = $('#txtDescM').val();
        //        var unit = $('#txtUnitM').val();

        //        var price = $('#txtPriceM').val();
        //        var originalPrice = $('#txtOriginalPriceM').val();
        //        var promotionPrice = $('#txtPromotionPriceM').val();

        //        //var image = $('#txtImageM').val();

        //        var tags = $('#txtTagM').val();
        //        var seoKeyword = $('#txtMetakeywordM').val();
        //        var seoMetaDescription = $('#txtMetaDescriptionM').val();
        //        var seoPageTitle = $('#txtSeoPageTitleM').val();
        //        var seoAlias = $('#txtSeoAliasM').val();

        //        var content = CKEDITOR.instances.txtContentM.getData();
        //        var status = $('#ckStatusM').prop('checked') == true ? 1 : 0;
        //        var hot = $('#ckHotM').prop('checked');
        //        var showHome = $('#ckShowHomeM').prop('checked');

        //        $.ajax({
        //            type: "POST",
        //            url: "/Product/SaveEntity",
        //            data: {
        //                Id: id,
        //                Name: name,
        //                CategoryId: categoryId,
        //                Image: '',
        //                Price: price,
        //                OriginalPrice: originalPrice,
        //                PromotionPrice: promotionPrice,
        //                Description: description,
        //                Content: content,
        //                HomeFlag: showHome,
        //                HotFlag: hot,
        //                Tags: tags,
        //                Unit: unit,
        //                Status: status,
        //                SeoPageTitle: seoPageTitle,
        //                SeoAlias: seoAlias,
        //                SeoKeywords: seoKeyword,
        //                SeoDescription: seoMetaDescription
        //            },
        //            dataType: "json",
        //            beforeSend: function () {
        //                alone.startLoading();
        //            },
        //            success: function (response) {
        //                alone.notify('Update product successful', 'success');
        //                $('#modal-add-edit').modal('hide');
        //                resetFormMaintainance();

        //                alone.stopLoading();
        //                $('#productDatatable').DataTable().ajax.reload();
        //            },
        //            error: function () {
        //                alone.notify('Has an error in save product progress', 'error');
        //                alone.stopLoading();
        //            }
        //        });
        //        return false;
        //    }

        //});
    }

    function registerControls() {
        CKEDITOR.replace('txtContentM', {});
        //Fix: cannot click on element ck in modal
        $.fn.modal.Constructor.prototype.enforceFocus = function () {
            $(document)
                .off('focusin.bs.modal') // guard against infinite focus loop
                .on('focusin.bs.modal', $.proxy(function (e) {
                    if (
                        this.$element[0] !== e.target && !this.$element.has(e.target).length
                        // CKEditor compatibility fix start.
                        && !$(e.target).closest('.cke_dialog, .cke').length
                        // CKEditor compatibility fix end.
                    ) {
                        this.$element.trigger('focus');
                    }
                }, this));
        };
    }

    // Load danh sách category vào ddl
    function loadCategories() {
        $.ajax({
            type: "GET",
            url: "/Product/GetAllProductCategory",
            dataType: 'json',
            success: function (res) {
                var render = "<option value=''>--- Select Category ---</option>";
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

    function init() {
        $('#tblProduct').DataTable({
            processing: true,
            serverSide: true,
            paging: true,
            search: false,
            searching: true,
            scrollY: false,
            bLengthChange: false,
            language: {
                info: "Hiện thị _START_ đến _END_ của _TOTAL_ mục",
                lengthMenu: "Hiện thị _MENU_ mục",
                search: "Search",
                processing: "Đang tải dữ liệu...",
                paginate: {
                    previous: "Đầu",
                    next: "Tiếp theo",
                    sLast: "Cuối"
                }
            },
            ajax: {
                url: "/Product/GetProductPaging",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "JSON",
                data: function (data) {
                    var settings = $("#tblProduct").dataTable().fnSettings();
                    var currentPageIndex = Math.ceil(settings._iDisplayStart / settings._iDisplayLength) + 1;
                    var request =
                    {
                        CategoryId: parseInt($('#ddlCategory').val(), 10),
                        PageSize: alone.configs.pageSize,
                        Page: currentPageIndex,
                        Keyword: $('.dataTables_filter input[type="search"]').val()
                    };
                    return JSON.stringify(request);
                },
                dataSrc: function (res) {
                    if (res.Result != null && res.Result.Results != null) {
                        return res.Result.Results;
                    }
                    else {
                        alone.notify('Cannot load data of Product', 'danger');
                        return [];
                    }
                },
                dataFilter: function (data) {
                    var page = $.parseJSON(data);
                    if (page.Result == null) {
                        page.recordsTotal = 0;
                        page.recordsFiltered = 0;
                        return JSON.stringify(page);
                    }
                    page.recordsTotal = page.Result.RowCount;
                    page.recordsFiltered = page.Result.RowCount;
                    return JSON.stringify(page);
                },
                error: function (status) {
                    alone.notify('Cannot load data of Product', 'danger');
                }
            },
            columns: [
                { "data": "Id", "width": "7%" },
                {
                    "data": null, render: function (data, type, row) {
                        return '<div class="d-flex align-items-center">' +
                            '<img class="img-fluid rounded" src="../assets/images/others/thumb-9.jpg" style="max-width: 60px" alt="">' +
                            '<h6 class="m-b-0 m-l-10">' + row.Name +
                            '</h6></div>';
                    },
                    "width": "20%"
                },
                { "data": "Price", "width": "10%" },
                { "data": "PromotionPrice", "width": "10%" },
                { "data": "ProductCategory.Name", "width": "15%" },
                {
                    "data": "Status", render: function (data, type, row) {
                        return '<div class="d-flex align-items-center">' +
                            '<div class="badge badge-success badge-dot m-r-10"></div>' +
                            '<div>aa</div>  </div>';
                    },
                    "width": '10%'
                },
                {
                    mRender: function (data, type, row) {
                        return '<a class="btn btn-icon btn-hover btn-sm btn-rounded pull-right btn-view" href="#" id="' + row.Id + '"><i class="anticon anticon-eye"></i></a>' +
                            '<a class="btn btn-icon btn-hover btn-sm btn-rounded pull-right btn-edit" href="#" id="' + row.Id + '"><i class="anticon anticon-edit"></i></a>' +
                            '<a class="btn btn-icon btn-hover btn-sm btn-rounded btn-delete" href = "#" id="' + row.Id + '" > <i class="anticon anticon-delete"></i></a >'
                    }
                    , "width": "10%"
                }
            ]
            ,
            initComplete: function () {
                $("#tblProduct label input").attr('id', 'search_box');
                var input = $('.dataTables_filter input').unbind(),
                    self = this.api(),
                    $searchButton = $('<a href="javascript:void(0);"' +
                        '<i class="anticon anticon-search"></i></a>')
                        .click(function () {
                            self.search(input.val()).draw();
                        })
                $('.dataTables_filter').append($searchButton);
            },
        });

        //$('<div class="col-md-6 col-sm-6">' +
        //    '<select class="form-control text-center" id="ddlCategory">' +
        //    '</select>' +
        //    '</div>').appendTo("#productDatatable_wrapper .dataTables_filter");
    }

    function resetFormMaintainance() {
        $('#hidIdM').val(0);
        $('#txtNameM').val('');
        initTreeDropDownCategory('');

        $('#txtDescM').val('');
        $('#txtUnitM').val('');

        $('#txtPriceM').val('0');
        $('#txtOriginalPriceM').val('');
        $('#txtPromotionPriceM').val('');

        //$('#txtImageM').val('');

        $('#txtTagM').val('');
        $('#txtMetakeywordM').val('');
        $('#txtMetaDescriptionM').val('');
        $('#txtSeoPageTitleM').val('');
        $('#txtSeoAliasM').val('');

        //CKEDITOR.instances.txtContentM.setData('');
        $('#ckStatusM').prop('checked', true);
        $('#ckHotM').prop('checked', false);
        $('#ckShowHomeM').prop('checked', false);

    }

    //function initTreeDropDownCategory(selectedId) {
    //    $.ajax({
    //        url: "/ProductCategory/GetAll",
    //        type: 'GET',
    //        dataType: 'json',
    //        async: false,
    //        success: function (response) {
    //            var data = [];
    //            $.each(response, function (i, item) {
    //                data.push({
    //                    id: item.Id,
    //                    text: item.Name,
    //                    parentId: item.ParentId,
    //                    sortOrder: item.SortOrder
    //                });
    //            });
    //            var arr = alone.createTree(data);
    //            $('#ddlCategoryIdM').combotree({
    //                data: arr
    //            });
    //            if (selectedId != undefined) {
    //                $('#ddlCategoryIdM').combotree('setValue', selectedId);
    //            }
    //        }
    //    });
    //}
}