$("#buscarUsuario").click(function () {

    //var usuarioId = parseInt($("#usuario").val());
    var usuario = $("#usuarioNombre").val();

    console.log(usuario);

    var json = {}
    json["nombre"] = usuario;

    console.log(json);

    $.ajax({
        type: "POST",
        url: "/Home/BuscarUsuario",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(json),

        success: function (response) {

            console.log(response);

            var response = JSON.parse(response);

            var stream = "";
            for (var i = 0; i < response["tweets"].length; i++) {
                stream = stream + "<p><b>TWEET: </b>" + response["tweets"][i].texto + "</p>"
            }

            $("#usuarioInfo").html("" +
                "<p><b>Usuario ID: </b>" + response["id"] + "</p>" +
                "<p><b>Nombre: </b>" + response["nombre"] + "</p>" +
                 stream + "");

        }

    })

});


$("#crearUsuario").click(function () {

    var usuarioNombre = $("#nuevoNombre").val();
    var usuarioContrasenia = $("#nuevoContrasenia").val();

    console.log(usuarioNombre);
    console.log(usuarioContrasenia);

    var json = {}
    json["nombre"] = usuarioNombre;
    json["contrasenia"] = usuarioContrasenia;

    console.log(json);

    $.ajax({
        type: "POST",
        url: "/Home/CrearUsuario",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(json),

        success: function (response) {

            console.log(response);

            var response = JSON.parse(response);

            $("#creacionInfo").html("" +
                "<p><b>Se creo el usuario con ID:  </b>" + response["id"] + "</p>" + "");

        }

    })

});


var i = 0;
var nuevosTweets = ""
$("#addInput").click(function () {
    i++;
    nuevosTweets += "" + '<input type="text" id="nuevoTweet' + i + '" name="nuevoTweet" placeholder="Escribir Tweet' + i + '" class="button button3"><h6></h6>' + ""
    $("#itemsInput").html(nuevosTweets);
});

/*
$("#tweetear").click(function () {
    $.ajax({
        url: "Home/Tweetear",
        method: "POST",
        dataType: 'json',
        data: $('#items').serialize(),
        success: function (responce) {
            $("#tweetearInfo").html("" +
                "<p>Tweets publicados!</p>" + "");
        }
    });
}) */