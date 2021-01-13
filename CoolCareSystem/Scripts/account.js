$(document).ready(function () {

    setTimeout(function () {
        $(".alert-message").fadeOut("fast");
    }, 2000);

    var show = 1;

    $("i.showpassword").parent().click(function () {
        if (show % 2 != 0) {
            $("i.showpassword").removeClass("glyphicon-eye-open");
            $("i.showpassword").addClass("glyphicon-eye-close");
            $("i.showpassword").parent().parent().find("input").attr("type", "text");
            show++;
        }
        else if (show % 2 == 0) {
            $("i.showpassword").removeClass("glyphicon-eye-close");
            $("i.showpassword").addClass("glyphicon-eye-open");
            $("i.showpassword").parent().parent().find("input").attr("type", "password");
            show++;
        }
    });
});

function changePasswordMode() {
    var passwordEditor = $("#Password").dxTextBox("instance");
    passwordEditor.option("mode", passwordEditor.option("mode") === "text" ? "password" : "text");
    var passwordToggle = $("#PasswordToggle").dxButton("instance");
    if (passwordToggle.option('icon') == "glyphicon glyphicon-eye-open") {
        passwordToggle.option('icon', "glyphicon glyphicon-eye-close")
    }
    else {
        passwordToggle.option('icon', "glyphicon glyphicon-eye-open")
    }
}