var table = null;
//var arrSubjects = [];

$(document).ready(function () {
    //debugger;
    table = $("#TblExam").DataTable({
        "processing": true,
        "responsive": true,
        "pagination": true,
        "stateSave": true,
        "ajax": {
            url: "/resulttrainer/load/",
            type: "GET",
            dataType: "json",
            dataSrc: ""
        },
        "columnDefs": [{
            sortable: false,
            "class": "index",
            targets: 0
        }],
        order: [[1, 'asc']],
        fixedColumns: true,
        "columns": [
            { "data": null },
            { "data": "employeeId" },
            { "data": "subjects.name" },
            {
                "data": "createdDate",
                "render": function (jsonDate) {
                    var date = moment(jsonDate).format("DD MMMM YYYY, h:mm:ss a");
                    return date;
                }
            },
            { "data": "score" },
            {
                "data": "score",
                "render": function (score) {
                    if (score >= 80) {
                        return "Passed";
                    } else {
                        return "Failed";
                    }
                }
            },
            {
                "sortable": false,
                "render": function (data, type, row, meta) {
                    //console.log(row);
                    $('[data-toggle="tooltip"]').tooltip();
                    return '<button class="btn btn-outline-info btn-circle" data-placement="left" data-toggle="tooltip" data-animation="false" title="See Answers" onclick="return GoToAnswers(' + meta.row + ')" ><i class="fa fa-lg fa-eye"></i></button>'
                }
            }
        ],
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'csvHtml5',
                text: '<i class="fas fa-file-csv"></i> CSV Export',
                className: 'btn btn-info',
                title: 'Division List',
                filename: 'cek ' + moment()
            },
            {
                extend: 'excelHtml5',
                text: '<i class="fas fa-file-excel"></i> Excel Export',
                className: 'btn btn-info',
                title: 'Division List',
                filename: 'cek ' + moment()
            },
            {
                extend: 'pdfHtml5',
                text: '<i class="fas fa-file-pdf"></i> PDF Export',
                className: 'btn btn-info',
                title: 'Division List',
                filename: 'cek ' + moment(),
                exportOptions: {
                    columns: [0, 1, 2, 3, 4],
                    search: 'applied',
                    order: 'applied',
                    modifier: {
                        page: 'current',
                    },
                },
                customize: function (doc) {
                    //debugger;
                    var rowCount = doc.content[1].table.body.length;
                    for (i = 1; i < rowCount; i++) {
                        doc.content[1].table.body[i][2].alignment = 'center';
                    };
                    doc.content[1].table.body[0][0].text = 'No.';
                    doc.content[1].table.body[0][2].text = 'Divisions';
                    doc.content[1].table.body[0][2].text = 'Departments';
                    doc['footer'] = (function (page, pages) {
                        return {
                            columns: [
                                'This is your left footer column',
                                {
                                    // This is the right column
                                    alignment: 'right',
                                    text: ['page ', { text: page.toString() }, ' of ', { text: pages.toString() }]
                                }
                            ],
                            margin: [10, 0]
                        }
                    });
                }
            }
        ],
        initComplete: function () {
            //debugger;
            this.api().columns(1).every(function () {
                var column = this;
                var select = $('<select><option value="">All Trainee</option></select>')
                    .appendTo($(column.header()).empty())
                    .on('change', function () {
                        var val = $.fn.dataTable.util.escapeRegex(
                            $(this).val()
                        );
                        column
                            .search(val ? '^' + val + '$' : '', true, false)
                            .draw();
                    });
                column.data().unique().sort().each(function (d, j) {
                    select.append('<option value="' + d + '">' + d + '</option>');
                });
            });
            this.api().columns(2).every(function () {
                var column = this;
                var select = $('<select><option value="">All Subjects</option></select>')
                    .appendTo($(column.header()).empty())
                    .on('change', function () {
                        var val = $.fn.dataTable.util.escapeRegex(
                            $(this).val()
                        );
                        column
                            .search(val ? '^' + val + '$' : '', true, false)
                            .draw();
                    });
                column.data().unique().sort().each(function (d, j) {
                    select.append('<option value="' + d + '">' + d + '</option>');
                });
            });
        }
    });
    table.on('order.dt search.dt', function () {
        table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
});

function GoToAnswers(number) {
    debugger;
    var id = table.row(number).data().id;
    $.ajax({
        url: "/resulttrainer/GoToAnswers",
        type: 'post',
        data: { id: id }
    }).then((result) => {
        window.location.href = "/answer";
    })
}
