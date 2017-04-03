$(".editar").on("click", function (e) {
    var id = e.target.id;

    var inputs = $("#" + id + " .input");
    var divs = $("#" + id + " .col-md-10");
    var dni = $("#" + id + " #documento");
    var eliminar = $("#" + id + " .eliminar");
    var form = $("#" + id + "");

    inputs.removeAttr("disabled");
    dni.attr("disabled", "true");
    eliminar.hide();
    inputs.show();
    divs.show();
    $(this).parent().hide();
    form.attr('action', '/Home/ModificarDatos');
})
$(".accordion-titulo").click(function () {

    var contenido = $(this).next(".accordion-content");
    if (contenido.css("display") == "none") { //open		
        contenido.slideDown(250);
        $(this).addClass("open");
    }
    else { //close		
        contenido.slideUp(250);
        $(this).removeClass("open");
    }
})
$(".eliminar").submit("submit", function (e) {
    var id = e.target.id;
    var dni = $("#" + id + " #documento");
    dni.attr("disabled", "false");

    var form = $("#" + id + "");
})



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
})

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
        $("#fechon").show();
        $('#formulario').attr('action', '/Home/ConsultarRegLiqFecha');
    }
})


$("#modificar").on("click", function () {
    $("#enviar").show();
    $(this).hide();
    $("#formulario .input").removeAttr("disabled");
})

function hecho() {
    var hecho = document.getElementById("hecho").textContent;
    if (hecho != "") {
        $("#hecho").slideUp(10000);
    }
}
hecho();

function error() {
    var error = document.getElementById("error").textContent;
    if (error != "") {
        $("#error").show();
        $("#error").slideUp(10000);
    }
}
error();



