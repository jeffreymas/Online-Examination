var table = null;

$(document).ready(function () {
    debugger;
    table = $('#subjectTrainer').DataTable({
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