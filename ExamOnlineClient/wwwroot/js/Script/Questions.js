var table = null;
var arrSub = [];
var arrSec = [];

$(document).ready(function () {
    debugger;
    table = $('#ManageQuestions').DataTable({
        "processing": true,
        "responsive": true,
        "pagination": true,
        "stateSave": true,
        "scrollX": true,
        "ajax": {
            url: "/questions/loadquestion",
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
            { "data": "questions" },
            { "data": "subjects.name" },
            { "data": "section.name" },
            { "data": "optionA" },
            { "data": "optionB" },
            { "data": "optionC" },
            { "data": "optionD" },
            { "data": "optionE" },
            { "data": "key" },
            {
                "sortable": false,
                "render": function (data, type, row, meta) {
                    $('[data-toggle="tooltip"]').tooltip();
                    return '<button class="btn btn-outline-warning btn-circle" data-placement="left" data-toggle="tooltip" data-animation="false" title="Edit" onclick="return GetById(' + meta.row + ')" ><i class="fa fa-lg fa-edit"></i></button>'
                        + '&nbsp;'
                        + '<button class="btn btn-outline-danger btn-circle" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return Delete(' + meta.row + ')" ><i class="fa fa-lg fa-times"></i></button>'
                }
            }
        ]
    });
});

function ClearScreen() {
    $('#Id').val('');
    $('#QuestionDetail').val('');
    $('#OptionA').val('');
    $('#OptionB').val('');
    $('#OptionC').val('');
    $('#OptionD').val('');
    $('#OptionE').val('');
    $('#Key').val('');
    $('#update').hide();
    $('#add').show();
}

function LoadSubject(element) {
    //debugger;
    if (arrSub.length === 0) {
        $.ajax({
            type: "Get",
            url: "/subjects/load",
            success: function (data) {
                arrSub = data;
                renderDepart(element);
            }
        });
    }
    else {
        renderDepart(element);
    }
}

function renderDepart(element) {
    var $option = $(element);
    $option.empty();
    $option.append($('<option/>').val('0').text('Select Subject').hide());
    $.each(arrSub, function (i, val) {
        $option.append($('<option/>').val(val.id).text(val.name))
    });
}
LoadSubject($('#SubOption'))


function LoadSection(element) {
    //debugger;
    if (arrSec.length === 0) {
        $.ajax({
            type: "Get",
            url: "/sections/loadsection",
            success: function (data) {
                arrSec = data;
                _renderDepart(element);
            }
        });
    }
    else {
        _renderDepart(element);
    }
}

function _renderDepart(element) {
    var $option = $(element);
    $option.empty();
    $option.append($('<option/>').val('0').text('Select Section').hide());
    $.each(arrSec, function (i, val) {
        $option.append($('<option/>').val(val.id).text(val.name))
    });
}


LoadSection($('#SectionOption'))

function GetById(number) {
    debugger;
    var id = table.row(number).data().id;
    $.ajax({
        url: "/questions/GetById/",
        data: { id: id }
    }).then((result) => {
        debugger;
        $('#Id').val(result.id);
        $('#SubOption').val(result.subjectId);
        $('#SectionOption').val(result.sectionId);
        $('#QuestionDetail').val(result.questions);
        $('#OptionA').val(result.optionA);
        $('#OptionB').val(result.optionB);
        $('#OptionC').val(result.optionC);
        $('#OptionD').val(result.optionD);
        $('#OptionE').val(result.optionE);
        $('#Key').val(result.key);
        $('#add').hide();
        $('#update').show();
        $('#myModal').modal('show');
    })
}

function Save() {
    debugger;
    if ($('#OptionA').val() == $('#Key').val() || $('#OptionB').val() == $('#Key').val() || $('#OptionC').val() == $('#Key').val() || $('#OptionD').val() == $('#Key').val() || $('#OptionE').val() == $('#Key').val()) {
        var Ques = new Object();
        Ques.id = null;
        Ques.subjectId = $('#SubOption').val();
        Ques.sectionId = $('#SectionOption').val();
        Ques.questions = $('#QuestionDetail').val();
        Ques.optionA = $('#OptionA').val();
        Ques.optionB = $('#OptionB').val();
        Ques.optionC = $('#OptionC').val();
        Ques.optionD = $('#OptionD').val();
        Ques.optionE = $('#OptionE').val();
        Ques.key = $('#Key').val();
        $.ajax({
            type: 'POST',
            url: "/questions/InsertOrUpdate/",
            cache: false,
            dataType: "JSON",
            data: Ques
        }).then((result) => {
            debugger;
            if (result.statusCode == 200) {
                Swal.fire({
                    position: 'center',
                    icon: 'success',
                    title: 'Data inserted Successfully',
                    showConfirmButton: false,
                    timer: 1500,
                })
                table.ajax.reload(null, false);
            } else {
                Swal.fire('Error', 'Failed to Input', 'error');
                ClearScreen();
            }
        })
    } else {
        debugger
        $.notify({
            // options
            icon: 'fas fa-alarm-clock',
            title: 'Notification : ',
            message: 'One option must be the same as the key',
        }, {
            // settings
            element: 'body',
            type: "warning",
            allow_dismiss: true,
            placement: {
                from: "top",
                align: "center"
            },
            timer: 1000,
            delay: 5000,
            animate: {
                enter: 'animated fadeInDown',
                exit: 'animated fadeOutUp'
            },
            icon_type: 'class',
            template: '<div data-notify="container" class="col-xs-11 col-sm-3 alert alert-{0}" role="alert">' +
                '<button type="button" aria-hidden="true" class="close" data-notify="dismiss">×</button>' +
                '<span data-notify="icon"></span> ' +
                '<span data-notify="title">{1}</span> ' +
                '<span data-notify="message">{2}</span>' +
                '<div class="progress" data-notify="progressbar">' +
                '<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
                '</div>' +
                '<a href="{3}" target="{4}" data-notify="url"></a>' +
                '</div>'
        });
    }
}

function Update() {
    debugger;
    if ($('#OptionA').val() == $('#Key').val() || $('#OptionB').val() == $('#Key').val() || $('#OptionC').val() == $('#Key').val() || $('#OptionD').val() == $('#Key').val() || $('#OptionE').val() == $('#Key').val()) {
        var Ques = new Object();
        Ques.id = $('#Id').val();
        Ques.subjectId = $('#SubOption').val();
        Ques.sectionId = $('#SectionOption').val();
        Ques.questions = $('#QuestionDetail').val();
        Ques.optionA = $('#OptionA').val();
        Ques.optionB = $('#OptionB').val();
        Ques.optionC = $('#OptionC').val();
        Ques.optionD = $('#OptionD').val();
        Ques.optionE = $('#OptionE').val();
        Ques.key = $('#Key').val();
        $.ajax({
            type: 'POST',
            url: "/questions/InsertOrUpdate/",
            cache: false,
            dataType: "JSON",
            data: Ques
        }).then((result) => {
            debugger;
            if (result.statusCode == 200) {
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
    } else {
        debugger
        $.notify({
            // options
            icon: 'fas fa-alarm-clock',
            title: 'Notification : ',
            message: 'One option must be the same as the key',
        }, {
            // settings
            element: 'body',
            type: "warning",
            allow_dismiss: true,
            placement: {
                from: "top",
                align: "center"
            },
            timer: 1000,
            delay: 5000,
            animate: {
                enter: 'animated fadeInDown',
                exit: 'animated fadeOutUp'
            },
            icon_type: 'class',
            template: '<div data-notify="container" class="col-xs-11 col-sm-3 alert alert-{0}" role="alert">' +
                '<button type="button" aria-hidden="true" class="close" data-notify="dismiss">×</button>' +
                '<span data-notify="icon"></span> ' +
                '<span data-notify="title">{1}</span> ' +
                '<span data-notify="message">{2}</span>' +
                '<div class="progress" data-notify="progressbar">' +
                '<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
                '</div>' +
                '<a href="{3}" target="{4}" data-notify="url"></a>' +
                '</div>'
         });
    }
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
                url: "/questions/Delete/",
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