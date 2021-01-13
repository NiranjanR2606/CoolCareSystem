$(document).ready(function () {

    setTimeout(function () {
        $(".alert-message").fadeOut("fast");
    }, 2000);

    $("input.priceInput").attr('maxlength', '8');
});

$(function () {
    function readURL(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {

                $("img#imgpreview").attr("src", e.target.result);
                $("p#imgpreviewName").html("<b>" + input.files[0].name + "</b>");
            }

            reader.readAsDataURL(input.files[0]);
        }
    }

    $("#ImageUpload").change(function () {
        readURL(this)
    });

    $("input.priceInput").on("input", function () {
        var val = $(this).val();
        if (isNaN(val)) {
            val = val.replace(/[^0-9\.]/g, '');
            if (val.split('.').length > 2)
                val = val.replace(/\.+$/, "");
        }
        $(this).val(val);
    });  
    
});