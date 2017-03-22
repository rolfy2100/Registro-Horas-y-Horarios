$(document).ready(function () {
    document.getElementById('entrasale').innerHTML = "<h1 class='text-center'>" + localStorage.getItem('usuario') + "</h1>";
    document.getElementById("entrasale").innerHTML = "<h3>" + localStorage.getItem("entrasalida") + "</h3>";
    localStorage.removeItem("entrasalida");
    localStorage.removeItem('Usuario');
})
                
