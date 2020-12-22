
function myFunction(id) {
    var x = document.getElementById(id);
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}

$("#buscarEgreso").click(function () {

    var egreso = ($("#id_egreso").val());

    //var id = ParseInt(egreso); no anda lo de parse (?

    console.log(egreso);

    var json = {}
    json["id_egreso"] = egreso;


    console.log(json);

    $.ajax({
        type: "POST",
        url: "/Home/BuscarEgreso",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(json),

        success: function (response) {

            console.log(response);

            var response = JSON.parse(response);

            var stream = "";
            for (var i = 0; i < response["items"].length; i++) {
                stream = stream + "<p><b>" + i + 1 + "- Item: </b>" + response["items"][i].item.descripcion + "</p>"
            }
            
            $("#egresoInfo").html("" +
                "<p><b>Egreso ID: </b>" + response["id_egreso"] + "</p>" +
                "<p><b>Cantidad de presupuestos requeridos: </b>" + response["cantPresupuestos"] + "</p>" +
                stream +
                "<p><b>Fecha: </b>" + response["fecha"] + "</p>" +
                "");
        }
    })

});

var i = 0;
var nuevosItems = ""
$("#addInput").click(function () {
    i++;
    nuevosItems += "" + '<input style="margin-left:40px;" type="text" id="nuevoItem' + i + '" name="nuevoItem" placeholder="Descripcion de item' + i + '" class="button button3"><input type="number" id="cantidad" name="cantidad" placeholder="Cantidad" class="button button3"><h6></h6><hr />' +  ""
    $("#itemsInput").html(nuevosItems);
});

var j = 0;
var nuevosItemsPresupuesto = ""
$("#addInputPresupuesto").click(function () {
    j++;
    nuevosItemsPresupuesto += "" + '<input style="margin-left:40px;" type="text" name="nuevoItemPresupuesto" placeholder="Descripcion de item' + j + '" class="button button3"><input type="number" id="precio" name="precio" placeholder="Precio unitario" class="button button3"><input type="number" id="cantidad" name="cantidad" placeholder="Cantidad" class="button button3"><h6></h6><hr />' + ""
    $("#itemsInputPresupuesto").html(nuevosItemsPresupuesto);
});

/*
$("#cargarIngreso").click(function () {

    var descripcion = $("#descripcion").val();
    var total = ParseInt($("#total").val());

    console.log(descripcion);
    console.log(total);

    var json = {}
    json["descripcion"] = descripcion;
    json["total"] = total;

    console.log(json);

    $.ajax({
        type: "POST",
        url: "/Home/CargarIngreso",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(json),

        success: function (response) {

            console.log(response);

            var response = JSON.parse(response);

            $("#ingresoInfo").html("" +
                "<p><b>Se cargo el ingreso con ID:  </b>" + response["id"] + "</p>" + "");

        }

    })

});
*/

$("#buscarIngreso").click(function () {

    var ingreso = ParseInt($("#id_ingreso").val());

    console.log(ingreso);

    var json = {}
    json["id"] = ingreso;

    console.log(json);

    $.ajax({
        type: "POST",
        url: "/Home/BuscarIngreso",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(json),

        success: function (response) {

            console.log(response);

            var response = JSON.parse(response);

            $("#egresoInfo").html("" +
                "<p><b>Ingreso ID: </b>" + response["id"] + "</p>" +
                "<p><b>Descripcion: </b>" + response["descripcion"] + "</p>" +
                "<p><b>Total: </b>" + response["total"] + "</p>" +
                "<p><b>Fecha: </b>" + response["fecha"] + "</p>" + "");
        }
    })

});



$("#-cargarProveedor").click(function () {

    var CUIT = $("#CUIT").val();
    var razon = ParseInt($("#razon").val());

    console.log(CUIT);
    console.log(razon);

    var json = {}
    json["CUIT"] = CUIT;
    json["razon"] = razon;

    console.log(json);

    $.ajax({
        type: "POST",
        url: "/Home/CargarProveedor",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(json),

        success: function (response) {

            console.log(response);

            var response = JSON.parse(response);

            $("#proveedorInfo").html("" +
                "<p><b>Se cargo el proveedor con ID:  </b>" + response["id"] + "</p>" + "");

        }

    })

});


$("#asignarCriterio").click(function () {

    var item = $("#item").val();
    var criterio = $("#criterio").val();
    var categoria = $("#categoria").val();

    console.log(item);
    console.log(criterio);
    console.log(categoria);

    var json = {}
    json["item"] = item;
    json["criterio"] = criterio;
    json["categoria"] = categoria;

    console.log(json);

    $.ajax({
        type: "POST",
        url: "/Home/AsignarCriterio",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(json),

        success: function (response) {

            console.log(response);

            var response = JSON.parse(response);

            $("#proveedorInfo").html("" +
                "Se asocio el item al criterio seleccionado" + "");

        }

    })

});

