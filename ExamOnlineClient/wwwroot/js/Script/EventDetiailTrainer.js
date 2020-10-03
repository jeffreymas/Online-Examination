var table = null;
var arrEmployee = [];

$(document).ready(function () {
    //debugger;
    table = $('#TblEventDetailsT').DataTable({
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