var tblSucursalesData = [];
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
        url: '../ComicsStore/getComicsForBranc',
        type: 'post',
        beforeSend: function () {
            $("#tblSucursales").html("<p align='center'><img src='../Content/img/ajax-loader.gif' /></p>");
        },
        success: function (data) {
            tblSucursalesData.push("<table class=\"table table-striped table-bordered table-hover\" id=\"dtSucursales\">" +
                "<thead>" +
                "<tr>" +
                "<th style=\"color: blue;\"></th>" +
                "<th style=\"color: blue;\">Titulo Comic</th>" +
                "<th style=\"color: blue;\">Formato</th>" +
                "<th style=\"color: blue;\">Num Paginas</th>" +
                "<th style=\"color: blue;\">Nombre Sucursal</th>" +
                "<th style=\"color: blue;\">Ubicacion</th>" +
                "</tr>" +
                "</thead>" +
                "<tbody>");
            for (var i = 0; i < data.length; i++) {
                tblSucursalesData.push("<tr class=\"odd gradeX\">" +
                    "<td align='center'> " + ((data[i].Codigo === 0) ? "" : " <input name=\"AdminComicInput\" id=\"chk" + data[i].IdProducto + "\" class=\"select-checkbox\" type=\"checkbox\" value=\"" + data[i].IdProducto + "\"" + ((data[i].Check == true) ? 'checked' : '') + "> ") + " </td>" +
                    "<td>" + data[i].TituloComic + "</td>" +
                    "<td>" + data[i].Formato + "</td>" +
                    "<td>" + data[i].NumPaginas + "</td>" +
                    "<td>" + data[i].NombreSucursal + "</td>" +
                    "<td>" + data[i].Ubicacion + "</td>" +
                    
                    "</tr>");
            }
            tblSucursalesData.push(" </tbody>" +
                "</table>");
            document.getElementById('tblSucursales').innerHTML = tblSucursalesData.join('');
            $('#dtSucursales').dataTable();
        }
    });

  
    
}