$(document).ready(function () {
    loadData();
});
var id = null;
function loadData() {
    $.ajax({
        url: "/notifications/loadnotif",
        data: "",
        cache: false,
        type: "GET",
        dataType: "JSON"
    }).then((result) => {
        debugger;
        $('#Id').append(result.id);
        $('#Message').append(result.message);
        $('#Emp').append(result.nama);
        var date = moment(result.createdDate).format("DD MMMM YYYY, h:mm:ss a");
        $('#Date').append(date);  
    });
}

