
function error() {
    $("#error").show();
    $("#error").slideUp(10000);
}
error();



$(".desplegar").click(function (e) {
    //Averiguo que elemento fue clickeado
    var id = e.target.id;
    //Activo el evento submit del form
    document.getElementById(id).submit();
    // ...
});
