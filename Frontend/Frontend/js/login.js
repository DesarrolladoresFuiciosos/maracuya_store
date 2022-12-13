var Backend = "https://localhost:44320/api/";
var FrontUrl = "http://127.0.0.1:5500/";

$(document).ready(function(){
    $("#btn_Login").click(() => {
        login()
    });
    
});

function login(){
    var userEmail = $("#inputEmail").val();
    var userPassword = $("#inputPassword").val();

    if(userEmail != '' && userPassword != ''){
        $.ajax({
            type: 'GET',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",    
            url: Backend + "GetUsuariosValidacion?email="+ userEmail + "&password=" + userPassword,
            beforeSend: function () {},
            success: function (response) {
                console.log(response);
                if(JSON.stringify(response) != "[]"){
                    window.location.assign(FrontUrl);
                }else{
                    alert("No existe el usuario");
                }
            },
            error: function (err) {
                alert("No se pudo ejecutar el proceso");
            },
            timeout: 300000
    
        });
    }else {
        alert("Por favor llene todos los campos");
    }
}