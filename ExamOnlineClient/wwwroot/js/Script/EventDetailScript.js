var table = null;
var arrEmployee = [];

$(document).ready(function () {
    //debugger;
    table = $('#TblEventDetails').DataTable({
        "processing": true,
        "responsive": true,
        "pagination": true,
        "stateSave": true,
        "ajax": {
            url: "/eventdetails/load/",
            type: "GET",
            dataType: "json",
            dataSrc: ""
        },
        "columns": [
            {
                "data":"id",
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            { "data": "name" },
            { "data": "nik" },
            { "data": "roleName" },
            {
                "sortable": false,
                "render": function (data, type, row, meta) {
                    $('[data-toggle="tooltip"]').tooltip();
                    return '<button class="btn btn-outline-danger btn-circle" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return Delete(' + meta.row + ')" ><i class="fa fa-lg fa-times"></i></button>'
                }
            }
        ]
        //initComplete: function () {
        //    debugger;
        //    this.api().columns(1).everyday(function () {
        //        var column = this;
        //        var select = $('<select><option value="">'All Trainee'</option></select>')
        //            .appendTo($(column.header()).empty())
        //            .on('change', function () {
        //                var val = $.fn.dataTable.util.escapeRegex(
        //                    $(this).val()
        //                );
        //                column
        //                    .search(val ? '^' + val + '$' : '', true, false)
        //                    .draw();
        //            });
        //        column.data().unique().sort().each(function (d, j) {
        //            select.append('<option value=">' + d + '</option>');
        //        });
        //    });
        //}
    });
});

function ClearScreen() {
    //debugger;
    LoadEmployee($('#EmployeeOption'));
    $('#EmployeeOption').val('0');
    $('#Id').val('');
    $('#Name').val('');
    $('#update').hide();
    $('#add').show();
    //$('#myModal').modal('show');
}

function LoadEmployee(element) {
    //debugger;
    if (arrEmployee.length === 0) {
        $.ajax({
            type: "Get",
            url: "/eventdetails/LoadEmployee",
            success: function (data) {
                arrEmployee = data;
                renderEmployee(element);
            }
        });
    } else {
        renderEmployee(element);
    }
}

function renderEmployee(element) {
    //debugger;
    var $option = $(element);
    $option.empty();
    $option.append($('<option/>').val('0').text('Select Trainee').hide());
    $.each(arrEmployee, function (i, val) {
        $option.append($('<option/>').val(val.id).text(val.name))
    });
}

LoadEmployee($('#EmployeeOption'));

function GetById(id) {
    $.ajax({
        url: "/EventDetails/Load",  //go to get employee details
        data: { id: id }
    }).then((result) => {
        $('#myModal').modal('show');
        $('Name').val(result.name);
        $('#add').hide();
        $('#update').show();
    })
}

function Save() {
    //debugger;
    //var id = table.row(number).data().id;
    var item = new Object();
    item.EmployeeId = $('#EmployeeOption').val();
    $.ajax({
        type: "POST",
        url: "/EventDetails/Insert/",
        cache: false,
        dataType: "JSON",
        data: item
    }).then((result) => {
        debugger;
        if (result.success == true) {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Data Saved',
                showConfirmButton: false,
                timer: 1500
            });
            $('#TblEventDetails').DataTable().ajax.reload(null, false);
        } else {
            Swal.fire('Error', "Insert data failed", 'error');
            ClearScreen();
        }
    });
}


function Delete(number) {
    debugger;
    var item = new Object();
    item.EmployeeId = table.row(number).data().id;
    swal.fire({
        title: 'Are you sure?',
        text: "This is cannot be undo",
        showCancelButton: true,
        confirmationButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmationButtonText: 'Yes',
    }).then((resultSwal) => {
        if (resultSwal.value) {
            debugger;
            $.ajax({
                url: "/eventDetails/delete",
                data: item
            }).then((result) => {
                if (result.success == true) {
                    debugger;
                    Swal.fire({
                        position: 'center',
                        icon: 'success',
                        title: 'Delete Successfully',
                        showConfirmButton: false,
                        timer: 1500
                    });
                    $('#TblEventDetails').DataTable().ajax.reload(null, false);
                } else {
                    Swal.fire('Error', 'Failed to delete', 'error');
                    ClearScreen();
                }
            })
        }
    })
}


var _table = null;

$(document).ready(function () {
    //debugger;
    _table = $('#TblEventDetailsT').DataTable({
        "processing": true,
        "responsive": true,
        "pagination": true,
        "stateSave": true,
        "ajax": {
            url: "/eventdetails/load/",
            type: "GET",
            dataType: "json",
            dataSrc: ""
        },
        "columns": [
            {
                "data": "id",
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            { "data": "name" },
            { "data": "nik" },
            { "data": "roleName" }
        ]
    });
});