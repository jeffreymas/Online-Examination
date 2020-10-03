var table = null;

$(document).ready(function () {
    debugger;
    table = $('#tbSection').DataTable({
        "processing": true,
        "responsive": true,
        "pagination": true,
        "stateSave": true,
        "ajax": {
            url: "/sections/LoadSection/",
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
                        + '<button class="btn btn-outline-danger btn-circle" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return Delete(' + row.Id + ')" ><i class="fa fa-lg fa-times"></i></button>'
                }
            }
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
        url: "/sections/GetById/",
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
    item.name = $('#Name').val();
    $.ajax({
        type: "POST",
        url: "/sections/InsertOrUpdate/",
        cache: false,
        dataType: "JSON",
        data: item
    }).then((result) => {
        debugger;
        if (result.statusCode == 200) {
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
        url: '/sections/InsertOrUpdate/',
        cache: false,
        dataType: "JSON",
        data: item
    }).then((result) => {
        if (result.statusCode == 200) {
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

function Delete(del) {
    var id = table.row(del).data().id;
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!',
    }).then((resultSwal) => {
        if (resultSwal.value) {
            debugger;
            $.ajax({
                url: "/sections/Delete/",
                data: { id: id }
            }).then((result) => {
                debugger;
                if (result.statusCode == 200) {
                    //debugger;
                    Swal.fire({
                        position: 'center',
                        icon: 'success',
                        title: 'Delete Successfully',
                        showConfirmButton: false,
                        timer: 1500,
                    });
                    table.ajax.reload(null, false);
                } else {
                    Swal.fire('Error', 'Failed to Delete', 'error');
                    ClearScreen();
                }
            })
        };
    });
}