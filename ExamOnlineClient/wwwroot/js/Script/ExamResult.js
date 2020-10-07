$(document).ready(function () {
    loadData();
});
var id = null;
function loadData() {
    $.ajax({
        url: "/result/ExResult",
        data: "",
        cache: false,
        type: "GET",
        dataType: "JSON"
    }).then((result) => {
        debugger;
        $('#Id').append(result.id);
        $('#Message').append(result.score);
    });
}

