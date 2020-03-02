var tblSucursalesData = [];
var idSucursal;
$(document).ready(function () {

    jQuery.noConflict();
      
    cargaTablaSucursales();

    $("#frmEditSucursal").validate({
        errorElement: 'span',
        rules: {
            NombreEdit: {
                required: true
            }
        },
        messages: {
            NombreEdit: {
                required: "El campo nombre es obligatorio"
            }
        },
        submitHandler: function () {
            //$("#NombreEdit").val(data[0].Nombre);
            //$("#UbicacionEdit").val(data[0].Ubicacion);
            //$("#TelefonosEdit").val(data[0].Telefonos);
            $.ajax({
                dataType: "json",
                data: JSON.stringify(),
                url: '../Branch/updateBranch?' + 'Id=' + idSucursal + '&Nombre=' + $("#NombreEdit").val() + '&Ubicacion=' + $("#UbicacionEdit").val() + '&Telefonos=' + $("#TelefonosEdit").val(),
                type: 'post',
                beforeSend: function () {
                    mostrarModal("mdlCargando");
                },
                error: function () {
                    ocultarModal("mdlEditSucursal");
                    ocultarModal("mdlCargando");
                    mostrarModalMensaje("mdlMensaje", "Ocurrio un error al modificar la sucursal.");
                },
                success: function (data) {
                    if (data != "0") {
                        ocultarModal("mdlEditSucursal");
                        ocultarModal("mdlCargando");
                        mostrarModalMensaje("mdlMensaje", "La sucursal se modifico correctamente.");
                        cargaTablaSucursales();
                    }
                    else {
                        ocultarModal("mdlEditSucursal");
                        ocultarModal("mdlCargando");
                        mostrarModalMensaje("mdlMensaje", "Ocurrio un error al modificar la sucursal.");
                    }
                }
            });

        }
    });

    $('#mdlInsertSucursal').on('hidden.bs.modal', function () {
        $(this).find('form')[0].reset();
        var validator = $("#frmInsertSucursal").validate();
        validator.resetForm();
    });

    $('#mdlEditSucursal').on('hidden.bs.modal', function () {
        $(this).find('form')[0].reset();
        var validator = $("#frmEditSucursal").validate();
        validator.resetForm();
    });

    $('#AddSucursal').on('click', function () {
        $("#Nombre").val('');
        $("#Ubicacion").val('');
        $("#Telefonos").val('');
        mostrarModal("mdlInsertSucursal");
    });

    $('#btnAceptDeleteSucursal').on('click', function () {
        $.ajax({
            dataType: "json",
            data: idSucursal,
            url: '../Branch/deleteBranch?id=' + idSucursal,
            type: 'post',
            beforeSend: function () {
                mostrarModal("mdlCargando");
            },
            error: function () {
                ocultarModal("mdlDeleteSucursal");
                ocultarModal("mdlCargando");
                mostrarModalMensaje("mdlMensaje", "Ocurrio un error al eliminar la sucursal.");
            },
            success: function (data) {

                if (data != "0") {
                    ocultarModal("mdlDeleteSucursal");
                    ocultarModal("mdlCargando");
                    mostrarModalMensaje("mdlMensaje", "La sucursal se eliminado correctamente.");
                    cargaTablaSucursales();
                }
                else {
                    ocultarModal("mdlDeleteSucursal");
                    ocultarModal("mdlCargando");
                    mostrarModalMensaje("mdlMensaje", "Ocurrio un error al eliminar la sucursal.");
                }

                
            }

        });
    });


    $("#frmInsertSucursal").validate({
        errorElement: 'span',
        rules: {
            Nombre: {
                required: true
            }
        },
        messages: {
            Nombre: {
                required: "El campo nombre es obligatorio"
            }
        },
        submitHandler: function () {
          
            $.ajax({
                dataType: "json",
                data: JSON.stringify(),
                url: '../Branch/addBranch?Nombre=' + $("#Nombre").val() + '&Ubicacion=' + $("#Ubicacion").val() + '&Telefonos=' + $("#Telefonos").val(),
                type: 'post',
                beforeSend: function () {
                    mostrarModal("mdlCargando");
                },
                error: function () {
                    ocultarModal("mdlInsertSucursal");
                    ocultarModal("mdlCargando");
                    mostrarModalMensaje("mdlMensaje", "Ocurrio un error al agregar la sucursal.");
                },
                success: function (data) {
                    if (data != "0") {
                        ocultarModal("mdlInsertSucursal");
                        ocultarModal("mdlCargando");
                        mostrarModalMensaje("mdlMensaje", "La sucursal se agrego correctamente.");
                        cargaTablaSucursales();
                    }
                    else {
                        ocultarModal("mdlInsertSucursal");
                        ocultarModal("mdlCargando");
                        mostrarModalMensaje("mdlMensaje", "Ocurrio un error al agregar la sucursal.");
                    }
                }
            });

        }
    });


});

function cargaTablaSucursales() {
    $("#tblSucursales").empty();
    tblSucursalesData.length = 0;
    $.ajax({
        dataType: "json",
        url: '../Branch/getBranchs',
        type: 'post',
        beforeSend: function () {
            $("#tblSucursales").html("<p align='center'><img src='../Content/img/ajax-loader.gif' /></p>");
        },
        success: function (data) {
            tblSucursalesData.push("<table class=\"table table-striped table-bordered table-hover\" id=\"dtSucursales\">" +
                "<thead>" +
                "<tr>" +
                "<th style=\"color: blue;\">Nombre</th>" +
                "<th style=\"color: blue;\">Ubicacion</th>" +
                "<th style=\"color: blue;\">Telefonos</th>" +
                "<th style=\"color: blue;\">Fecha de Alta</th>" +
                "<th style=\"color: blue;\">Acciones</th>" +
                "</tr>" +
                "</thead>" +
                "<tbody>");
            for (var i = 0; i < data.length; i++) {
                tblSucursalesData.push("<tr class=\"odd gradeX\">" +
                    "<td>" + data[i].Nombre + "</td>" +
                    "<td>" + data[i].Ubicacion + "</td>" +
                    "<td>" + data[i].Telefonos + "</td>" +
                    "<td>" + data[i].FCreacion + "</td>" +
                    "<td class=\"center\"> <button style=\"color:#003082; background-color:transparent; border:none;\" title=\"Editar Sucursal\" id=\"btnEditarSucursal" + data[i].IdSucursal + "\" value=\"" + data[i].IdSucursal + "\" data-toggle=\"modal\" > <i class=\"fa fa-edit\" style=\"font-size: 30px;\"></i></button><button style=\"color:#003082;background-color:transparent; border:none;\" title=\"Eliminar Sucursal\" id=\"btnEliminarSucursal" + data[i].IdSucursal + "\" value=\"" + data[i].IdSucursal + "\" data-toggle=\"modal\"  class=\"eliminar\"> <i class=\"fa fa-trash-o\" style=\"font-size: 30px;\"></i></button></td>" +
                    "</tr>");
            }
            tblSucursalesData.push(" </tbody>" +
                "</table>");
            document.getElementById('tblSucursales').innerHTML = tblSucursalesData.join('');
           $('#dtSucursales').dataTable();
        }
    });

    $(document).delegate('button[id^="btnEliminarSucursal"]', 'click', function () {
        idSucursal = $(this).val();
        mostrarModal("mdlDeleteSucursal");
    });

    $(document).delegate('button[id^="btnEditarSucursal"]', 'click', function () {
        idSucursal = $(this).val();
        $.ajax({
            dataType: "json",
            data: JSON.stringify(),
            url: '../Branch/getBranchById?Id=' + idSucursal,
            type: 'post',
            beforeSend: function () {
                //mostrarModal("mdlCargando");
            },
            success: function (data) {
                
                $("#NombreEdit").val(data[0].Nombre);
                $("#UbicacionEdit").val(data[0].Ubicacion);
                $("#TelefonosEdit").val(data[0].Telefonos);
                //$("#FechaCreacionEdit").val(data[0].FechaCreacion);
                mostrarModal("mdlEditSucursal");
                
                //ocultarModal("mdlCargando");
            }

        });
    });
}