var usuario = document.getElementById('usuario').value;
localStorage.setItem('usuario', usuario);

//Registrar fecha de entrada
document.getElementById("fechaentrada").value = "";
var fechita0 = localStorage.getItem("fechafinal0")
if (fechita0 != "undefined" && fechita0 != "" && fechita0 != false && fechita0 != null) {
    document.getElementById("fechaentrada").value = fechita0;

}
else {
    var fechaHora0 = new Date();
    var año0 = fechaHora0.getFullYear();
    var mes0 =+ fechaHora0.getMonth() + 1;
    var fecha0 = fechaHora0.getDate();
    var fechafinal0 = fecha0 + "/" + mes0 + "/" + año0;
    localStorage.setItem("fechafinal0", fechafinal0);
    document.getElementById("fechaentrada").value = fechafinal0;
}

//Registrar hora de entrada
var horita = localStorage.getItem("horariofinal2")
if (horita != "undefined" && horita != "" && horita != false && horita != null)
{
    document.getElementById("lala").value = horita;

}
else{
        var fechaHora = new Date();
        var horas = fechaHora.getHours();
        var minutos = fechaHora.getMinutes();
        var segundos = fechaHora.getSeconds();

        if (horas < 10) { horas = '0' + horas; }
        if (minutos < 10) { minutos = '0' + minutos; }
        if (segundos < 10) { segundos = '0' + segundos; }
        var horariofinal1 =  horas + ':' + minutos + ':' + segundos;
        localStorage.setItem("horariofinal2", horariofinal1);
        document.getElementById("lala").value = horariofinal1;
        }


        //Contador
        var segundos2 = 0;
        var temporizador = setInterval(function contador() {
            segundos2 = localStorage.getItem("segundos");
            ++segundos2;

            var tiempo = segundos2
            localStorage.setItem("segundos", segundos2);
            document.getElementById("contar").value = tiempo;
        }, 1000);



//Finalizar conteo, Log out
    $("#salir").on("click", function () {
        var fechaHora3 = new Date();
        var año3 = fechaHora3.getFullYear();
        var mes3 = fechaHora3.getMonth() * 1;
        var fecha3 = fechaHora3.getDate();
        var horas3 = fechaHora3.getHours();
        var minutos3 = fechaHora3.getMinutes();
        var segundos3 = fechaHora3.getSeconds();

        if (horas3 < 10) { horas3 = '0' + horas3; }
        if (minutos3 < 10) { minutos3 = '0' + minutos3; }
        if (segundos3 < 10) { segundos3 = '0' + segundos3; }

        if (fecha0 != fecha3) { segundos3 = segundos3 + " " + "+1" }
        clearInterval(temporizador);

        document.getElementById("horasalida").value =  horas3 + ':' + minutos3 + ':' + segundos3;
        localStorage.setItem("entrasalida", 'Trabajaste desde' + " " + horariofinal1 + " " + 'hasta' + " " + horas3 + ":" + minutos3 + ":" + segundos3);
        localStorage.removeItem("fechafinal0");
        localStorage.removeItem("horariofinal2");
        localStorage.removeItem("segundos");
    })

    $("#href").on("click", function () {
        document.getElementById('form2').submit();
        return false;
    })

    //Deshabilitar cierre de ventana y retroceso
    window.onbeforeunload = function () {
        return "¿Estás seguro que deseas salir de la actual página?"
    }
    function deshabilitaRetroceso() {
        window.location.hash = "no-back-button";
        window.location.hash = "Again-No-back-button" //chrome
        window.onhashchange = function () { window.location.hash = "no-back-button"; }
    }
    deshabilitaRetroceso();

