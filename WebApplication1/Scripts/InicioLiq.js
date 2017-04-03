
function error5() {
    var error5 = document.getElementById("error5").textContent;
    if (error5 != "") {
        $("#error5").slideUp(10000);
    }
}
error5();

$(".desplegar").click(function (e) {
    //Averiguo que elemento fue clickeado
    var id = e.target.id;
    //Activo el evento submit del form
    document.getElementById(id).submit();
    // ...
});

opcion = "1";
$("#buscador").on("change", function () {
    var opcion = "1";
    opcion = $(this).val();
    if (opcion == "2" && opcion != undefined) {
        $("#mes").show();
        $("#operador").show();
        $('#formulario').attr('action', '/Home/ConsultarRegLiqMes');
        $("#fechon").hide();
    }
    else {
        $("#mes").hide();
        $("#operador").hide();
        $('#formulario').attr('action', '/Home/ConsultarRegLiqFecha');
    }
})

function error() {
    var error = document.getElementById("error").textContent;
    if (error != "") {
        $("#error").show();
        $("#error").slideUp(10000);
    }
}
error();
