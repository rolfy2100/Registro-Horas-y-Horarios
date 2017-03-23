$(document).ready(function () {
    var mensaje = localStorage.getItem("usuario")
    document.getElementById('entrasale').innerHTML = "<h1 class='text-center'>" + mensaje + "</h1>";
    document.getElementById("entrasale").innerHTML = "<h3>" + localStorage.getItem("entrasalida") + "</h3>";
    localStorage.removeItem("entrasalida");
    localStorage.removeItem('Usuario');
})
                
