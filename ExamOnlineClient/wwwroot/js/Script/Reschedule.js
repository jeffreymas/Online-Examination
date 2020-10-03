var table = null;
var nb = 0;

$(document).ready(function () {
    debugger;
    table = $("#Reschedule").DataTable({
        "processing": true,
        "responsive": true,
        "pagination": true,
        "stateSave": true,
        "ajax": {
            url: "/examinations/readSchedule/",
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
                }
            },
            { "data": "employeeId" },
            { "data": "subjectId" },
            {
                "data": "createdDate",
                "render": function (jsonDate) {
                    var date = moment(jsonDate).format("DD MMMM YYYY, h:mm:ss a");
                    return date;
                }
            },
            {
                "data": "rescheduleDate",
                "render": function (jsonDate) {
                    var date = moment(jsonDate).format("DD MMMM YYYY, h:mm:ss a");
                    return date;
                }
            },
            {
                "sortable": false,
                "render": function (data, type, row, meta) {
                    $('[data-toggle="tooltip"]').tooltip();
                    return '<button class="btn btn-outline-info btn-circle" data-placement="right" data-toggle="tooltip" data-animation="false" title="Detail" onclick="return GetById(' + meta.row + ')" ><i class="fa fa-lg fa-info"></i></button>'
                }
            }
        ],

    });
});



function ClearScreen() {
    LoadTrainee($('#TraineeOption'));
    $('#Id').val('');
    $('#TraineeOption').val('0');  
    $('#Name').val('');
    $('#Subject').val('');
    $('#Res').val('');
    $('#Update').hide();
    $('#Insert').show();
}

function GetById(number) {
    debugger;
    var id = table.row(number).data().id;
    $.ajax({
        url: "/examinations/GetById/",
        data: { id: id }
    }).then((result) => {
        debugger;
        $('#Id').append(result.id);
        $('#Name').append(result.employeeId);
        $('#Res').append(result.rescheduleDate);

        $('#Name').val(result.employeeId);
        $('#Id').val(result.id);
        $('#Update').show();
        $('#myModal').modal('show');
    })
}


function approve() {
    debugger;
    var Acc = new Object();
    Acc.id = $('#Id').val();
    Acc.employeeId = $('#Name').val();
    $.ajax({
        type: 'POST',
        url: "/examinations/Approve/",
        cache: false,
        dataType: "JSON",
        data: Acc
    }).then((result) => {
        debugger;
        if (result.statusCode == 200) {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Reschedule Has Been Approved',
                showConfirmButton: false,
                timer: 1500
            });
            table.ajax.reload(null, false);
        } else {
            Swal.fire('Error', 'Failed to Approved', 'error');
            ClearScreen();
        }
    })
}

function reject() {
    debugger;
    var acc = new Object();
    acc.id = $('#Id').val();
    acc.employeeId = $('#Name').val();
    $.ajax({
        type: 'POST',
        url: "/examinations/Reject/",
        cache: false,
        datatype: "json",
        data: acc
    }).then((result) => {
        debugger;
        if (result.statusCode == 200) {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Reschedule Has Been Rejected',
                showConfirmButton: false,
                timer: 1500
            });
            table.ajax.reload(null, false);
        } else {
            Swal.fire('Error', 'Failed to Approved', 'error');
            ClearScreen();
        }
    })
}