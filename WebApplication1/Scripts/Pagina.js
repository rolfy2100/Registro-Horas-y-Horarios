
    //Registrar fecha de entrada
    document.getElementById("fechaentrada").value = "";
    var fechita0 = localStorage.getItem("fechafinal0")
    if (fechita0 != "undefined" && fechita0 != "" && fechita0 != false && fechita0 != null) {
        document.getElementById("fechaentrada").value = fechita0;


    }
    else {
        var fechaHora0 = new Date();
        var año0 = fechaHora0.getFullYear();
        var mes0 = fechaHora0.getMonth() + 1;
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

        var horas = parseInt(localStorage.getItem("horas"));
        var minutos = parseInt(localStorage.getItem("minutos"));
        var segundos = parseInt(localStorage.getItem("segundos"));
    }
    else{
            var fechaHora = new Date();
            var horas = fechaHora.getHours();
            var minutos = fechaHora.getMinutes();
            var segundos = fechaHora.getSeconds();

            var horas1 = horas;
            var minutos1 = minutos;
            var segundos1 = segundos;

            localStorage.setItem("horas", horas);
            localStorage.setItem("minutos", minutos);
            localStorage.setItem("segundos", segundos);

            if (horas < 10) { var horas1 = '0' + horas1; }
            if (minutos < 10) {var minutos1 = '0' + minutos1; }
            if (segundos < 10) {var segundos1 = '0' + segundos1; }
            var horariofinal1 =  horas1 + ':' + minutos1 + ':' + segundos1;
            localStorage.setItem("horariofinal2", horariofinal1);
            document.getElementById("lala").value = horariofinal1;
            }


    //Finalizar conteo, Log out
    $("#salir").on("click", function () {
        //Obtengo Fecha de salida y hora de salida
        var fechaHora3 = new Date();
        var año3 = fechaHora3.getFullYear();
        var mes3 = fechaHora3.getMonth() + 1;
        var fecha3 = fechaHora3.getDate();
        var horas3 = fechaHora3.getHours();
        var minutos3 = fechaHora3.getMinutes();
        var segundos3 = fechaHora3.getSeconds();

 
        //Paso a segundos hora entra y hora salida
        if (horas3 => horas)
        {
            var horasegout = horas3 * 3600;
            var minsegout = minutos3 * 60;
            var horasegin = horas * 3600;
            var minsegin = minutos * 60;
            var segout = horasegout + minsegout + segundos3;
            var segin = horasegin + minsegin + segundos;
            var segtrabajados = segout - segin;
        }
        else
        {
            var horatrans = horas3 + 24;
            var horasegout = horas3 * 3600;
            var minsegout = minutos3 * 60;
            var horasegin = horas * 3600;
            var minsegin = minutos * 60;
            var segout = horasegout + minsegout + segundos3;
            var segin = horasegin + minsegin + segundos;
            //Calculo en segundos el tiempo trabajado
            var segtrabajados = segout - segin;
        }
        //Paso a minutos y horas el tiempo trabajado
        var seg = segtrabajados % 60;
        var mininter = segtrabajados / 60;
        if (mininter > 60)
        {
        var min = mininter % 60;
        }
        else
        {
         var min = 0;
        }
        var hor = mininter / 60;
        if (hor < 1)
        {
            hor = 0;
        }
        if (min < 1)
        {
            min = 0;
        }
        
        //Agrego un 0 al frente de los valores de solo un digito
        if (hor < 10) { var hor = '0' + hor; }
        if (min < 10) { var min = '0' + min; }
        if (seg < 10) { var seg = '0' + seg; }

        //Asi se va a mostrar las horas trabajadas en la vista
        var horastrabajadas = hor + ":" + min + ":" + seg;
        
        //Agrego un 0 al frente de los valores de solo un digito de la hora de salida
        if (horas3 < 10) { var horas3 = '0' + horas3; }
        if (minutos3 < 10) { var minutos3 = '0' + minutos3; }
        if (segundos3 < 10) { var segundos3 = '0' + segundos3; }

        var usuario = document.getElementById('usuario22').value;
        var horaentrada = localStorage.getItem("horariofinal2");
        document.getElementById("contar").value = segtrabajados;
        document.getElementById("horastrabajadas").value = horastrabajadas;
        document.getElementById("horasalida").value =  horas3 + ':' + minutos3 + ':' + segundos3;
        localStorage.setItem("entrasalida", 'Trabajaste desde' + " " + horaentrada + " " + 'hasta' + " " + horas3 + ":" + minutos3 + ":" + segundos3);
        localStorage.setItem('usuario', usuario);
        localStorage.removeItem("fechafinal0");
        localStorage.removeItem("horariofinal2");
        localStorage.removeItem("horas");
        localStorage.removeItem("minutos")
        localStorage.removeItem("segundos");
        //clearInterval(temporizador);
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

