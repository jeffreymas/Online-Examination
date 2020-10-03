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
                        + '&nbsp;'
                        + '<button class="btn btn-outline-info btn-circle" data-placement="right" data-toggle="tooltip" data-animation="false" title="Exam Result" onclick="return GetExam(' + meta.row + ')" ><i class="fa fa-lg fa-eye"></i></button>'
                }
            }
        ]
        
    });
});


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
            { "data": "roleName" },
            {
                "sortable": false,
                "render": function (data, type, row, meta) {
                    $('[data-toggle="tooltip"]').tooltip();
                    return '<button class="btn btn-outline-info btn-circle" data-placement="right" data-toggle="tooltip" data-animation="false" title="Exam Result" onclick="return GetExam2(' + meta.row + ')" ><i class="fa fa-lg fa-eye"></i></button>'
                }
            }
        ]
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

function GetExam(number) {
    //debugger;
    var id = table.row(number).data().id;
    $.ajax({
        url: "/eventdetails/GoToExam",
        type: 'post',
        data: { id: id }
    }).then((result) => {
        window.location.href = "/resulttrainer";
    })
}

function GetExam2(number) {
    //debugger;
    var id = _table.row(number).data().id;
    $.ajax({
        url: "/eventdetails/GoToExam",
        type: 'post',
        data: { id: id }
    }).then((result) => {
        window.location.href = "/resulttrainer";
    })
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