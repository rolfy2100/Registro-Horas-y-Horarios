$(document).ready(function () {
document.getElementById("entrasale").innerHTML = "<h3>" + localStorage.getItem("entrasalida") + "</h3>";
localStorage.removeItem("entrasalida");
})