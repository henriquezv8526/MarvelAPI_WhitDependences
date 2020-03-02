
function mostrarAviso(texto, clase) {
    $("#popupAvisos").html("<center><h4 class=\"modal-title\">" + texto + "</h4>"
                       + "<p><button type=\"button\" style=\"background-color:#003082;\" class=\"btn btn-primary\" id=\"AceptarAviso\"" +
                       "onclick=\"document.getElementById('popupAvisos').style.display = 'none'; document.getElementById('fondoPopupAvisos').style.display = 'none'\">Aceptar</button></p></center>");
    $("#popupAvisos").addClass(clase);
    document.getElementById('popupAvisos').style.display = 'block';
    document.getElementById('fondoPopupAvisos').style.display = 'block';
}

function mostrarAvisoSinBtn(texto, clase) {
    $("#popupAvisos").html("<center><h4 class=\"modal-title\">" + texto + "</h4> </center>");
    $("#popupAvisos").addClass(clase);
    document.getElementById('popupAvisos').style.display = 'block';
    document.getElementById('fondoPopupAvisos').style.display = 'block';
}

function ocultarAviso(clase) {
    $("#popupAvisos").html("");
    $("#popupAvisos").removeClass(clase);
    document.getElementById('popupAvisos').style.display = 'none';
    document.getElementById('fondoPopupAvisos').style.display = 'none';
}

function ocultarModal(IdModal) {
    $('#' + IdModal).modal('hide');
}

function mostrarModal(IdModal) {
    $('#' + IdModal).modal('show');
}

function ocultarModalMensaje(IdModal) {
    $('#' + IdModal).modal('hide');
    $('#txtMensaje').html("");
}

function mostrarModalMensaje(IdModal,mensaje) {
    $('#' + IdModal).modal('show');
    $('#txtMensaje').html(mensaje);
}