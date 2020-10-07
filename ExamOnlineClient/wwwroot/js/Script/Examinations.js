var table = null;
var arrTrainee = [];
var arrSubjects = [];

$(document).ready(function () {
    //debugger;
    table = $("#ManageQuestions").DataTable({
        "processing": true,
        "responsive": true,
        "pagination": true,
        "stateSave": true,
        "ajax": {
            url: "/examinations/loadexamination",
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
            { "data": "employeeName" },
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
                "sortable": false,
                "render": function (data, type, row, meta) {
                    //console.log(row);
                    $('[data-toggle="tooltip"]').tooltip();
                    return '<button class="btn btn-outline-warning btn-circle" data-placement="left" data-toggle="tooltip" data-animation="false" title="Edit" onclick="return GetById(' + meta.row + ')" ><i class="fa fa-lg fa-edit"></i></button>'
                        + '&nbsp;'
                        + '<button class="btn btn-outline-danger btn-circle" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return Delete(' + meta.row + ')" ><i class="fa fa-lg fa-times"></i></button>'
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
                    columns: [1, 2, 3, 4],
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
                    doc.content[1].table.body[0][2].text = 'Trainee Name';
                    doc.content[1].table.body[0][2].text = 'Subject';
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

function LoadTrainee(element) {
    //debugger;
    if (arrTrainee.length === 0) {
        $.ajax({
            type: "Get",
            url: "/examinations/loademployee",
            success: function (data) {
                arrTrainee = data;
                renderTrainee(element);
            }
        });
    }
    else {
        renderTrainee(element);
    }
}

function renderTrainee(element) {
    var $option = $(element);
    $option.empty();
    $option.append($('<option/>').val('0').text('Select Trainee').hide());
    $.each(arrTrainee, function (i, val) {
        $option.append($('<option/>').val(val.id).text(val.name));
    });
}

LoadTrainee($('#TraineeOption'));


function LoadSubjects(element) {
    //debugger;
    if (arrSubjects.length === 0) {
        $.ajax({
            type: "Get",
            url: "/subjects/Load/",
            success: function (data) {
                arrSubjects = data;
                renderSubjects(element);
            }
        });
    }
    else {
        renderSubjects(element);
    }
}

function renderSubjects(element) {
    var $option = $(element);
    $option.empty();
    $option.append($('<option/>').val('0').text('Select Subjects').hide());
    $.each(arrSubjects, function (i, val) {
        $option.append($('<option/>').val(val.id).text(val.name));
    });
}

LoadSubjects($('#SubjectsOption'));

function ClearScreen() {
    debugger;
    LoadTrainee($('#TraineeOption'));
    LoadSubjects($('#SubjectsOption'));
    $('#Update').hide();
    $('#Insert').show();
}

function Delete(nummber) {
    //debugger;
    var id = table.row(nummber).data().id;
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        //debugger;
        if (result.value) {
            $.ajax({
                url: "/examinations/delete/",
                data: { Id: id }
            }).then((result) => {
                //debugger;
                if (result.statusCode === 200) {
                    Swal.fire({
                        position: 'center',
                        icon: 'success',
                        title: 'Delete Successfully',
                        showConfirmButton: false,
                        timer: 1500
                    });
                    table.ajax.reload(null, false);
                } else {
                    Swal.fire('Error', 'Failed to Delete', 'error');
                    ClearScreen();
                }
            });
        }
    });
}

function Save() {
    debugger;
    var a = validateForm();
    if (a === false) {
        Swal.fire('Please Fill All Field');
        return true;
    } else if(a === true) {
        var Examination = new Object();
        Examination.Id = null;
        Examination.CreatedDate = $('#Schedule').val();
        Examination.EmployeeId = $('#TraineeOption').val();
        Examination.SubjectId = $('#SubjectsOption').val();
        $.ajax({
            type: 'POST',
            url: "/examinations/InsertOrUpdate/",
            cache: false,
            dataType: "JSON",
            data: Examination
        }).then((result) => {
            debugger;
            if (result.statusCode === 200) {
                Swal.fire({
                    position: 'center',
                    icon: 'success',
                    title: 'Data inserted Successfully',
                    showConfirmButton: false,
                    timer: 1500
                });
                table.ajax.reload(null, false);
            } else {
                Swal.fire('Error', 'Failed to Input', 'error');
                ClearScreen();
            }
        });
    }
}

function GetById(number) {
    debugger;
    var id = table.row(number).data().id;
    $.ajax({
        url: "/examinations/GetById/",
        data: { id: id }
    }).then((result) => {
        debugger;
        $('#Id').val(result.id);
        $('#SubjectsOption').val(result.subjectId);
        $('#TraineeOption').val(result.employeeId);
        $('#Schedule').val(result.createdDate);
        $('#Insert').hide();
        $('#Update').show();
        $('#exampleModal').modal('show');
    })
}



function Update() {
    debugger;
    var Examination = new Object();
    Examination.Id = $('#Id').val();;
    Examination.CreatedDate = $('#Schedule').val();
    Examination.EmployeeId = $('#TraineeOption').val();
    Examination.SubjectId = $('#SubjectsOption').val();
    $.ajax({
        type: 'POST',
        url: "/examinations/InsertOrUpdate/",
        cache: false,
        dataType: "JSON",
        data: Examination
    }).then((result) => {
        debugger;
        if (result.statusCode === 200) {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Data Updated Successfully',
                showConfirmButton: false,
                timer: 1500,
            });
            table.ajax.reload(null, false);
        } else {
            Swal.fire('Error', 'Failed to Input', 'error');
            ClearScreen();
        }
    })
}


function validateForm() {
    debugger;
    var a = $('#SubjectsOption').val();
    var b = $('#TraineeOption').val();
    var c = $('#Schedule').val();;
    if (a === 0 || a === "0", b === 0 || b === "0", c === null || c === "") {
        return false;
    } else {
        return true;
    }
}