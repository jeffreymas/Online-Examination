var table = null;

$(document).ready(function () {
    //debugger;
    table = $('#TblNotif').DataTable({
        "processing": true,
        "responsive": true,
        "pagiantion": true,
        "stateSave": true,
        "ajax": {
            url: "/notif/load/",
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
            { "data": "message" },
            {
                "data": "createdDate",
                'render': function (jsonDate) {
                    var date = new Date(jsonDate);
                    return moment(date).format('DD MM YYYY HH:mm:ss');
                }
            },
            {
                "sortable": false,
                "render": function (data, type, row, meta) {
                    $('[data-toggle="tooltip"]').tooltip();
                    return '<button class="btn btn-outline-danger btn-circle" data-placement="center" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return Delete(' + meta.row + ')" ><i class="fa fa-lg fa-times"></i></button>'
                }
            }
        ]
    });
});

function Delete(number) {
    var id = table.row(number).data().id;
    $.ajax({
        url: "/notif/ReadNotif/",
        data: { id: id }
    }).then((result) => {
        if (result.success.statusCode == 200) {
            table.ajax.reload(null, false);
        } else {
            swal.fire('Error', 'Delete failed', 'Error');
        }
    })
}