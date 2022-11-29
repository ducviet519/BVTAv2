// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$.fn.clearData = function ($form) {
    $form.find('input:text, input:password, input:file, select, textarea').val('');
    $form.find('input:radio, input:checkbox')
        .removeAttr('checked').removeAttr('selected');
}

$.fn.callModal = function (url) {

    var ReportPopupElement = $('#myPopup');
    $.ajax({
        url: url,
        dataType: 'html',
        success: function (data) {
            $("body").find(".modal-backdrop").remove();
            ReportPopupElement.html(data);
            ReportPopupElement.find('.modal').modal('show');
        }, error: function (xhr, status) {
            switch (status) {
                case 404:
                    $(this).callToast("error", 'Lỗi!', 'Đường dẫn không đúng hoặc tính năng không tồn tại!');
                    break;
                case 500:
                    $(this).callToast("error", 'Lỗi!', 'Không kết nối được tới Server!');
                    break;
                case 0:
                    $(this).callToast("error", 'Lỗi!', 'Hệ thống không phản hồi!');
                    break;
                default:
                    $(this).callToast("error", 'Lỗi!', 'Sự cố không xác định! Lỗi: ' + status);
            }
        },
    });
}

$.fn.callToast = function (status, title, msg) {
    toastr.options = {
        "closeButton": false,
        "debug": true,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
    if (status == "success") {
        toastr.success(msg, title)
    }
    else if (status == "info") {
        toastr.info(msg, title)
    }
    else if (status == "warning") {
        toastr.warning(msg, title)
    }
    else if (status == "error") {
        toastr.error(msg, title)
    }
}

$.fn.callTreeView = function (id, url) {
    $.getJSON(url, function (data) {
        $(id).treeview({
            data: data,
            enableLinks: true,
            collapseIcon: 'fas fa-minus',
            expandIcon: 'fas fa-plus'
        });
    });
    
}

//Test Export trong trường hợp không truyền exportColumn
$.fn.callDataTableExportExcel = function (btnName, btnClass, excellTitle, excelSheetName, exportColumn) {
    var array = [];
    $.each(exportColumn.split(','), function (idx, val) {
        array.push(parseInt(val));
    });
    if (btnName == '') { btnName = "Xuất Excel"; }
    if (btnClass == '') { btnName = "btn btn-danger btn-sm"; }
    if (excellTitle == '') { excellTitle = "Xuất dữ liệu Excel - Bệnh viện Tâm Anh"; }
    if (excelSheetName == '') { excelSheetName = "Dữ liệu"; }
    if (exportColumn == '') { exportColumn = ':visible'; }

    $(this).DataTable({
        "paging": true,
        "lengthChange": false,
        "pageLength": 15,
        "searching": true,
        "processing": true,
        "ordering": true,
        "info": true,
        "autoWidth": true,
        "responsive": true,
        "order": [[0, 'asc']],
        "columnDefs": [
            { targets: -1, visible: false },
            { className: "text-wrap", targets: "_all" },
            { defaultContent: '', targets: "_all" },
        ],
        "dom": 'Bfrtip',
        "buttons": [{
            "extend": 'excel',
            "text": btnName,
            "className": btnClass,
            "title": excellTitle,
            "sheetName": excelSheetName,
            "exportOptions": { columns: array },
        }],
        "initComplete": function (settings, json) {
            $(".buttons-excel").removeClass("dt-button");
        },
        "language": {
            "sProcessing": "Đang tải dữ liệu...",
            "sLengthMenu": "Xem _MENU_ mục",
            "sZeroRecords": "Không tìm thấy dòng nào phù hợp",
            "sInfo": "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ mục",
            "sInfoEmpty": "Đang xem 0 đến 0 trong tổng số 0 mục",
            "sInfoFiltered": "(được lọc từ _MAX_ mục)",
            "sInfoPostFix": "",
            "sSearch": "Tìm:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "Đầu",
                "sPrevious": "Trước",
                "sNext": "Tiếp",
                "sLast": "Cuối"
            }
        },
    });
}

$.fn.callDataTableCheckbox = function (id, columnData, url, pageLength, disableColumn) {
    var array = [];
    $.each(disableColumn.split(','), function (idx, val) {
        array.push(parseInt(val));
    });
    if (disableColumn == '') { disableColumn = 0; }
    var table = $(id).DataTable();
    if ($.fn.dataTable.isDataTable(id)) {
        table.destroy();
        $(id).find('tbody').empty();
    }
    var table = $(id).DataTable({
        "paging": true,
        "lengthChange": false,
        "pageLength": pageLength,
        "searching": true,
        "processing": true,
        "ordering": true,
        "info": true,
        "autoWidth": true,
        "autoFill": true,
        "responsive": true,
        "ajax": {
            "url": url,
            "type": "GET",
            "datatype": "json"
        },
        "columns": columnData,
        "order": [[1, 'asc']],
        "columnDefs": [
            { "className": 'select-checkbox', "orderable": false, "targets": 0 },
            //{ 'targets': 0, 'checkboxes': { 'selectRow': true } },
            { "orderable": false, "targets": array },
        ],
        "select": {
            "style": 'multi',
            "selector": 'td:first-child'
        },
        "language": {
            "sProcessing": "Đang tải dữ liệu...",
            "sLengthMenu": "Xem _MENU_ mục",
            "sZeroRecords": "Không tìm thấy dòng nào phù hợp",
            "sInfo": "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ mục",
            "sInfoEmpty": "Đang xem 0 đến 0 trong tổng số 0 mục",
            "sInfoFiltered": "(được lọc từ _MAX_ mục)",
            "sInfoPostFix": "",
            "sSearch": "Tìm:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "Đầu",
                "sPrevious": "Trước",
                "sNext": "Tiếp",
                "sLast": "Cuối"
            },
            "select": {
                "rows": {
                    _: "Đã chọn %d dòng",
                    0: "Click vào dòng để chọn",
                    1: "Đã chọn 1 dòng"
                }
            }
        },
    });
    return table;
}

$.fn.callDataTable_Checkbox_RowGrouping = function (groupColumn, colspanColumn) {

    var table = $("#tableChiDinh").DataTable({
        "paging": true,
        "lengthChange": false,
        "pageLength": 15,
        "searching": true,
        "processing": true,
        "ordering": true,
        "info": true,
        "autoWidth": true,
        "autoFill": true,
        "responsive": true,
        "columnDefs": [
            { "className": 'select-checkbox', "orderable": false, "targets": 0 },
            { "visible": false, "targets": groupColumn },
            { className: "text-wrap", targets: "_all" },
            { defaultContent: '', targets: "_all" },
        ],
        "order": [[groupColumn, 'asc']],
        "select": {
            "style": 'multi',
            "selector": 'td:first-child'
        },
        "language": {
            "sProcessing": "Đang tải dữ liệu...",
            "sLengthMenu": "Xem _MENU_ mục",
            "sZeroRecords": "Không tìm thấy dòng nào phù hợp",
            "sInfo": "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ mục",
            "sInfoEmpty": "Đang xem 0 đến 0 trong tổng số 0 mục",
            "sInfoFiltered": "(được lọc từ _MAX_ mục)",
            "sInfoPostFix": "",
            "sSearch": "Tìm:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "Đầu",
                "sPrevious": "Trước",
                "sNext": "Tiếp",
                "sLast": "Cuối"
            },
            "select": {
                "rows": {
                    _: "Đã chọn %d dòng",
                    0: "Click vào dòng để chọn",
                    1: "Đã chọn 1 dòng"
                }
            }
        },
        "drawCallback": function (settings) {
            var api = this.api();
            var rows = api.rows({ page: 'current' }).nodes();
            var last = null;

            api
                .column(groupColumn, { page: 'current' })
                .data()
                .each(function (group, i) {
                    if (last !== group) {
                        $(rows)
                            .eq(i)
                            .before('<tr class="group"><td colspan="' + colspanColumn + '">' + group + '</td></tr>');

                        last = group;
                    }
                });
        },
    });
    return table;
}

$.fn.callDataTable = function (id, columnData, url, pageLength, disableColumn) {
    var array = [];
    $.each(disableColumn.split(','), function (idx, val) {
        array.push(parseInt(val));
    });
    if (disableColumn == '') { disableColumn = 0; }
    var table = $(id).DataTable();
    if ($.fn.dataTable.isDataTable(id)) {
        table.destroy();
        $(id).find('tbody').empty();
    }
    var table = $(id).DataTable({
        "paging": true,
        "lengthChange": false,
        "pageLength": pageLength,
        "searching": true,
        "processing": true,
        "ordering": true,
        "info": true,
        "autoWidth": true,
        "responsive": false,
        "order": [[0, 'asc']],
        "columnDefs": [
            { orderable: false, targets: array },
            { className: "text-wrap", targets: "_all" },
            { defaultContent: '', targets: "_all" },
        ],
        "ajax": {
            "url": url,
            "type": "GET",
            "datatype": "json"
        },
        "columns": columnData,
        "language": {
            "sProcessing": "Đang tải dữ liệu...",
            "sLengthMenu": "Xem _MENU_ mục",
            "sZeroRecords": "Không tìm thấy dòng nào phù hợp",
            "sInfo": "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ mục",
            "sInfoEmpty": "Đang xem 0 đến 0 trong tổng số 0 mục",
            "sInfoFiltered": "(được lọc từ _MAX_ mục)",
            "sInfoPostFix": "",
            "sSearch": "Tìm:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "Đầu",
                "sPrevious": "Trước",
                "sNext": "Tiếp",
                "sLast": "Cuối"
            }
        },
    });
    return table;
}

function searchDataTable(id, columnData, url, pageLength, disableColumn) {
    var array = [];
    $.each(disableColumn.split(','), function (idx, val) {
        array.push(parseInt(val));
    });
    if (disableColumn == '') { disableColumn = 0; }
    var table = $(id).DataTable();
    if ($.fn.dataTable.isDataTable(id)) {
        table.destroy();
        $(id).find('tbody').empty();
    }
    $(id).DataTable({
        "paging": true,
        "lengthChange": false,
        "pageLength": pageLength,
        "searching": true,
        "processing": true,
        "ordering": true,
        "info": true,
        "autoWidth": true,
        "responsive": false,
        "order": [[0, 'asc']],
        "columnDefs": [
            { orderable: false, targets: array },
            { className: "text-wrap", targets: "_all" },
            { defaultContent: '', targets: "_all" },
        ],
        "ajax": {
            "url": url,
            "type": "GET",
            "datatype": "json"
        },
        "columns": columnData,
        "language": {
            "sProcessing": "Đang tải dữ liệu...",
            "sLengthMenu": "Xem _MENU_ mục",
            "sZeroRecords": "Không tìm thấy dòng nào phù hợp",
            "sInfo": "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ mục",
            "sInfoEmpty": "Đang xem 0 đến 0 trong tổng số 0 mục",
            "sInfoFiltered": "(được lọc từ _MAX_ mục)",
            "sInfoPostFix": "",
            "sSearch": "Tìm:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "Đầu",
                "sPrevious": "Trước",
                "sNext": "Tiếp",
                "sLast": "Cuối"
            }
        },
    });
}

$.fn.callSelect2 = function (id, url, placeholder) {
    $(id).select2({
        ajax: {
            url: url,
            dataType: 'json',
            data: function (params) {
                return {
                    term: params.term,
                };
            },
            processResults: function (data) {
                return {
                    results: $.map(data.data, function (item) {
                        return {
                            text: item.ma + '|' + item.hoten,
                            id: item.ma
                        }
                    })
                };
            }
        },
        placeholder: placeholder,
        allowClear: true,
        width: "100%",
        language: "vi",
        templateResult: function (option) {
            var item = option.text.split('|');
            var ob = jQuery(
                '<div class="row justify-content-between">' +
                '<div class="col-3">' + item[0] + '</div>' +
                '<div class="col-9 text-wrap">' + item[1] + '</div>' +
                '</div>');
            return ob;
        },
        templateSelection: function (option) {
            var item = option.text.split('|');
            return item[1];
        },
        escapeMarkup: function (m) {
            return m;
        }
    });
}



