$(".image-link").hover(
    function () {
        var id = $(this).attr("id");
        $("#" + id+".centered").css("color", "black");
    }
);

$(".image-link").mouseout(
    function () {
        var id = $(this).attr("id");
        $("#" + id + ".centered").css("color", "white");
    }
);
