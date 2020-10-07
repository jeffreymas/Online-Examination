var table = null;

$(document).ready(function () {
    debugger;
    table = $('#TblAnswers').DataTable({
        "processing": true,
        "responsive": true,
        "pagination": true,
        "stateSave": true,
        "ajax": {
            url: "/Answer/load",
            type: "get",
            dataType: "json",
            dataSrc: "",
        },
        "columns": [
            {
                "data": "id",
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            { "data": "question.questions" },
            { "data": "question.key" },
            { "data": "answers" }
            //console.log(row);
        ]
    });
});