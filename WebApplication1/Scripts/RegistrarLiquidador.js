var user = document.getElementsByName("user").value;
var contra = document.getElementsByName("contra").value;
var nombres = document.getElementsByName("nombres").value;
var apellidos = document.getElementsByName("apellidos").value;
var dni = document.getElementsByName("dni").value;
var fechanacimiento = document.getElementsByName("fechanacimiento").value;
var estadocivil = document.getElementsByName("estadocivil").value;
var direccion = document.getElementsByName("direccion").value;
var mail = document.getElementsByName("mail").value;
var usuario = document.getElementsByName("usuario").value;
var contraseña = document.getElementsByName("contraseña").value;

$("#submit").submit(function (e) {


    if (user == null && contra == null && nombres == null && apellidos == null && dni == null && fechanacimiento == null && estadocivil == null && direccion == null && mail == null && usuario == null && contraseña == null)
    {
        e.preventDefault();
        var error1 = "Todos los campos son obligatorios";
        document.getElementById("nombres").innerHTML = "<h5 id='error3'>" + error1 + "</h5>";
        $("#error3").slideUp(10000);
    }

    if(estadocivil != 'soltero' || estadocivil != 'casado' || estadocivil != 'Casado' || estadocivil != "Soltero")
    {
        e.preventDefault();
        var error2 = 'El campo solo admite los valores soltero o casado';
        document.getElementById("error2").textContent =  error2;
        $("#error2").show();
        $("#error5").show();
        $("#error5").slideUp(10000);
        $("#error2").slideUp(10000);
    }
    else
    {

    }
})
