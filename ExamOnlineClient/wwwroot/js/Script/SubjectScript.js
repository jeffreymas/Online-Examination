var table = null;

$(document).ready(function () {
    debugger;
    table = $('#TblSubject').DataTable({
        "processing": true,
        "responsive": true,
        "pagination": true,
        "stateSave": true,
        "ajax": {
            url: "/subjects/Load/",
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
            {
                "sortable": false,
                "render": function (data, type, row, meta) {
                    //debugger;
                    console.log(row);
                    $('[data-toggle="tooltip"]').tooltip();
                    return '<button class="btn btn-outline-warning btn-circle" data-placement="left" data-toggle="tooltip" data-animation="false" title="Edit" onclick="return GetById(' + meta.row + ')" ><i class="fa fa-lg fa-edit"></i></button>'
                        + '&nbsp;'
                        + '<button class="btn btn-outline-danger btn-circle" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return Delete('+ row.Id +')" ><i class="fa fa-lg fa-times"></i></button>'
                }
            }
        ]
    });
});


var _table = null;

$(document).ready(function () {
    debugger;
    _table = $('#subjectTrainer').DataTable({
        "processing": true,
        "responsive": true,
        "pagination": true,
        "stateSave": true,
        "ajax": {
            url: "/subjects/Load/",
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
            { "data": "name" }
        ]
    });
});

function ClearScreen() {
    $('#Id').val('');
    $('#Name').val('');
    $('#update').hide();
    $('#add').show();
}

function GetById(number) {
    debugger;
    var id = table.row(number).data().id;
    $.ajax({
        url: "/subjects/GetById/",
        data: { id: id },
    }).then((result) => {
        debugger;
        $('#Id').val(result.id);
        $('#Name').val(result.name);
        $('#add').hide();
        $('#update').show();
        $('#myModal').modal('show');
    })
}

function Save() {
    debugger;
    var item = new Object();
    item.Name = $('#Name').val();
    $.ajax({
        type: "POST",
        url: "/subjects/insert",
        cache: false,
        dataType: "JSON",
        data: item
    }).then((result) => {
        debugger;
        if (result.success == true) {
            swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Data Saved',
                showConfirmationButton: false,
                timer: 1500
            })
            table.ajax.reload(null, false);
        } else {
            swal.fire('Error', 'Failed to save', 'error');
            ClearScreen();
        }
    })
}

function Update() {
    var item = new Object();
    item.id = $('#Id').val();
    item.name = $('#Name').val();
    $.ajax({
        type: 'POST',
        url: '/subjects/insert/',
        cache: false,
        dataType: "JSON",
        data: item
    }).then((result) => {
        if (result.success == true) {
            swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Data Updated',
                showConfirmationButton: false,
                timer: 1500
            });
            table.ajax.reload(null, false);
        } else {
            swal.fire('Error', 'Failed to input', 'error');
            ClearScreen();
        }
    })
}

function Delete(number) {
    var id = table.row(number).data().id;
    debugger;
    swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        showCancelButton: true,
        confirmationButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmationButtonText: 'Yes'
    }).then((resultSwal) => {
        if (resultSwal.value == true) {
            debugger;
            $.ajax({
                url: "/subjects/delete/",
                data: { id: id }
            }).then((result) => {
                if (result.success == true) {
                    debugger;
                    swal.fire({
                        position: 'center',
                        icon: 'success',
                        title: 'Deleted',
                        showConfirmationButton: false,
                        timer: 1500
                    });
                    table.ajax.reload(null, false);
                } else {
                    swal.fire('Error', 'Failed to Delete', 'error');
                    ClearScreen();
                }
            })
        };
    });
}