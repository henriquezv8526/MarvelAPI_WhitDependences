var tblSucursalesData = [];
var tblPersonajesData = [];
var idSucursal;
$(document).ready(function () {

    jQuery.noConflict();

    cargaTablaSucursales();

});


function cargaTablaSucursales() {
    $("#tblSucursales").empty();
    tblSucursalesData.length = 0;
    $.ajax({
        dataType: "json",
        url: '../ListComics/getListComics',
        type: 'post',
        beforeSend: function () {
            $("#tblSucursales").html("<p align='center'><img src='../Content/img/ajax-loader.gif' /></p>");
        },
        success: function (data) {
            tblSucursalesData.push("<table class=\"table table-striped table-bordered table-hover\" id=\"dtSucursales\">" +
                "<thead>" +
                "<tr>" +
                "<th style=\"color: blue;\">Imagen</th>" +
                "<th style=\"color: blue;\">Titulo Comic</th>" +
                "<th style=\"color: blue;\">Volumen</th>" +
                "<th style=\"color: blue;\">Detalle</th>" +
                "</tr>" +
                "</thead>" +
                "<tbody>");
            for (var i = 0; i < data.length; i++) {
                tblSucursalesData.push("<tr class=\"odd gradeX\">" +
                    "<td>" + ((data[i].Imagen === "Default") ? "<img src='../Content/img/960px-User.jpg'   style=\"width:200px; height:auto;\"></td>" : "<img src='" + data[i].Imagen + "'   style=\"width:200px; height:auto;\"></td>") +
                    "<td>" + data[i].Nombre + "</td>" +
                    "<td>" + ((data[i].Volumen === "0") ? '' : data[i].Volumen) + "</td>" +
                    "<td class=\"center\"> <button style=\"color:#003082;background-color:transparent; border:none;\" title=\"Detalle del Comic\" id=\"btnDetalleImagen" + data[i].Id + "\" value=\"" + data[i].Id + "\" data-toggle=\"modal\"  class=\"eliminar\"> <i class=\"fa fa-edit\" style=\"font-size: 30px;\"></i></button></td>" +
                    
                    "</tr>");
            }
            tblSucursalesData.push(" </tbody>" +
                "</table>");
            document.getElementById('tblSucursales').innerHTML = tblSucursalesData.join('');
            $('#dtSucursales').dataTable();
        }
    });

}


$(document).delegate('button[id^="btnDetalleImagen"]', 'click', function () {
    idSucursal = $(this).val();
    validaExistencia(idSucursal);
    $.ajax({
        dataType: "json",
        data: JSON.stringify(),
        url: '../ListComics/getListComicsById?Id=' + idSucursal,
        type: 'post',
        beforeSend: function () {
            //mostrarModal("mdlCargando");
        },
        success: function (data) {

            $("#Imagen").attr("src", ((data[0].Imagen === "Default") ? "../Content/img/960px-User.jpg" : "" + data[0].Imagen + ""));
            $("#Titulo").val(data[0].Nombre);
            $("#Volumen").val(((data[0].Volumen === "0") ? "" : data[0].Volumen));
            $("#FLanzamiento").val(data[0].FechaLanzamiento);
            $("#Paginas").val(data[0].Paginas);
            $("#Descripcion").val(data[0].Descripcion);

            $("#tblPersonajes").empty();
            tblPersonajesData.length = 0;

           
            
            if (data[0].CountCharacter > 0) {
                
                //data[0].LstCharacterId.forEach((element) => {
                 $.ajax({
                     dataType: "json",
                     data: JSON.stringify(),
                     url: '../ListComics/getListCharacterByIds?Ids=' + data[0].LstCharacterId,
                     type: 'post',
                     beforeSend: function () {

                     },
                     success: function (data) {
                         
                             tblPersonajesData.push("<table class=\"table table-striped table-bordered table-hover\" id=\"dtPersonajes\">" +
                                 "<thead>" +
                                 "<tr>" +
                                 "<th style=\"color: blue;\">Personaje</th>" +
                                 "<th style=\"color: blue;\">Imagen</th>" +
                                 "</tr>" +
                                 "</thead>" +
                                 "<tbody>");
                         for (var i = 0; i < data.length; i++) {
                             tblPersonajesData.push("<tr class=\"odd gradeX\">" +
                                 "<td>" + data[i].Name + "</td>" +
                                 "<td>" + ((data[i].Image === "Default") ? "<img src='../Content/img/960px-User.jpg'   style=\"width:200px; height:auto;\"></td>" : "<img src='" + data[i].Image + "'   style=\"width:200px; height:auto;\"></td>") +
                                 "</tr>");
                         }
                         tblPersonajesData.push(" </tbody>" +
                             "</table>");
                         document.getElementById('tblPersonajes').innerHTML = tblPersonajesData.join('');
                         $('#dtPersonajes').dataTable();

                        // validaExistencia(_codigo);

                         mostrarModal("mdlDetailComic");
                     }

                    // });
                })

                

                
            }
            else {
                //validaExistencia(_codigo);
                mostrarModal("mdlDetailComic");
            }
        }

    });





});

function validaExistencia(_codigo) {
    
    $.ajax({
        dataType: "json",
        url: '../ListComics/getComicsExistBranch?codigo=' + _codigo,
        type: 'post',
        beforeSend: function () {
        },
        success: function (data) {
            $("#Sucursal").val(data);
        }
    });



}