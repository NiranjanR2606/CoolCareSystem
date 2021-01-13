$(".btnRate").click(function () {
    var Id = $(this).parent().attr("id");
    $("td.action_div_" + Id).addClass("hidden");
    $("td#star_div_" + Id).removeClass("hidden");
    $(".btnRate,.btnStatus").addClass("disabled");
})


$(".star").mouseenter(function () {
    var Id = $(this).attr("Id")
    $("i.star").removeClass("glyphicon-star");
    $("i.star").addClass("glyphicon-star-empty");
    for(var i=1;i<=Id;i++)
    {
        if ($("i#" + i + ".star").hasClass("glyphicon-star-empty"))
        {
            $("i#" + i + ".star").removeClass("glyphicon-star-empty");
            $("i#" + i + ".star").addClass("glyphicon-star");
        }
    }
})


$(".starDiv").mouseleave(function () {
    $("i.star").removeClass("glyphicon-star");
    $("i.star").addClass("glyphicon-star-empty");
})

