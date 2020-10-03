$(document).ready(function () {
    debugger;
    table = $('#TableResult').DataTable({
        "processing": true,
        "responsive": true,
        "pagination": true,
        "stateSave": true,
        "ajax": {
            url: "/Result/LoadResult",
            type: "GET",
            dataType: "json",
            dataSrc: "",
        },
        "columns": [
            {
                "data": "id",
                render: function (data, type, row, meta) {
                    //console.log(row);
                    return meta.row + meta.settings._iDisplayStart + 1;
                    //return meta.row + 1;
                }
            },
            { "data": "subjects.name" },
            {
                "data": "createdDate",
                "render": function (jsonDate) {
                    var date = moment(jsonDate).format("DD MMMM YYYY, h:mm:ss a");
                    return date;
                }
            },
            { "data": "score" }
        ]
    });
});