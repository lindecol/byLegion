var mydata = 0;

$(document).ready(function () {

  
  //  $("#TProductos").dataTable();
});


 var mydata;
 var Option;


function Setup() {
   
    $.ajaxSetup({
        cache: false,
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        async: true,
        beforeSend: function (objeto) {
            //$("#Principal").mask()
        },
        complete: function (objeto, exito) {
            if (exito != "success") {

            }
        }
    });




}

Setup();

function FormatForm(strValor) {
    if (strValor.indexOf('?') != -1)
        strValor = strValor.substring(0, strValor.indexOf('?'));
    else
        strValor = strValor;
    return strValor;
};



$('#BtnBuscar').click(function () {

    var CriterioBusqueda = $("#txtCriterioBusqueda").val();

    ConsultarTransferenciasOBC(CriterioBusqueda);
    
});


function EliminarTrans(CodigoPallet) {

    var data = JSON.stringify({ Codigo: CodigoPallet });
    $.ajax({
        url: 'EliminarTransferenciasOBC.aspx/EliminarTransferencia',
        data: data,
        success: function (response) {
             jAlert('Registro Eliminado Satisfactoriamente');
            ConsultarTransferenciasOBC($("#txtCriterioBusqueda").val());
        }
    })

}

function Eliminar(Codigo) {
    if (confirm('Esta seguro eliminar la transferencia?')) {
        EliminarTrans(Codigo);
    }
}

$('#BtnEliminar').click(function () {

    var CriterioBusqueda = $("#txtCriterioBusqueda").val();

    Eliminar(CriterioBusqueda);

});

//Función   las trasnferencias por ruta
function ConsultarTransferenciasOBC(CriterioBusqueda) {


    var params = new Object();
    params.CodigoPallet = CriterioBusqueda

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "EliminarTransferenciasOBC.aspx/ConsultarTransferenciasOBC",
        data: JSON.stringify(params),
        dataType: "json",
        async: false,
        success: function (response, textStatus) {

            var registros = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            //           
            CargarTabla(registros);

        },
        error: function (request, status, error) {
            alert(jQuery.parseJSON(request.responseText).Message);
        }
    });

}

function CargarTabla(registros) {

//    $(TProductos).empty();
//    $(TProductos).show();
//    //$(TProductos).append(GenerarEncabezadoTabla(encabezados));
//    //$(TProductos + " tbody").remove();
    //    $(dProductos).tmpl(registros).appendTo(TProductos);

    var encabezados = [
            
             { h: 'Ruta', style: 'width: 50px', sort: 'Ruta' }
            , { h: 'Pallet', style: 'width: 50px;', sort: 'Pallet' }
             , { h: 'Fecha', style: 'width:250px;', sort: 'Fecha' }
        ];



    $("#TProductos").empty();
    $("#TProductos").show();
    $("#TProductos").append(GenerarEncabezadoTabla(encabezados));
    $("#TProductos tbody").remove();
    $("#dProductos").tmpl(registros).appendTo('#TProductos');

    var oTable = $("#TProductos").dataTable({ "sScrollY": 450, "bRetrieve": true, "bFilter": false });
    if (oTable) {
        oTable.fnDestroy();
        oTable = undefined;
    }
  $.fn.dataTableExt.oStdClasses.sWrapper = "dataTables_wrapper";
    $("#TProductos").dataTable({ "sScrollY": 450, "bRetrieve": true, "bFilter": false, "sDom": 'T<"clear">lfrtip' });

}


/* Utilizado por MostrarRegistrosENTabla para generar los encabezados de la tabla a partir de una lista */
function GenerarEncabezadoTabla(encabezados) {
    var resultado = '<thead><tr>';
    for (var i in encabezados) {
        var encabezado = encabezados[i];
        var texto = '&nbsp';
        resultado += '<th';

        for (var propiedad in encabezado) {
            if (propiedad != 'h') {
                resultado += ' ' + propiedad + '="' + encabezado[propiedad] + '"';
            }
            else {
                texto = encabezado[propiedad];
            }
        }
        //Cierra el tag de apertura th
        resultado += '>' + texto + '</th>';
    }
    resultado += '</tr></thead>';
    return resultado;
}

function VentanaEditar() {
    $("#ModalBusqueda").dialog({
        height: 200,
        width: 470,
        modal: true
    });
    return false

}




$('#btnGuardar').click(function () {

    if (jQuery.trim($('#txtCodigoP').val()) == '') {
        jAlert('Se requiere Digitar Código del Pallet', 'Validación Datos');
        $('#txtArticulo').focus();
        return;
    }



    if (jQuery.trim($('#cmbTipo').val()) == '0') {
        jAlert('Se requiere Seleccionar Un estado Inicial del Pallet', 'Validación Datos');
        $('#txtArticulo').focus();
        return;
    }

    if (Option == 2) {
        ActualizarPallet();
    } else {
        ValidarExistePallet($("#txtCodigoP").val());
       

    }

});


function ActualizarPallet() {
    var registro = new Object();

    var data = JSON.stringify({ Codigo: $("#txtCodigoP").val(), Estado: $("#cmbTipo").val(), Observaciones: $("#txtArticulo").val() });
    $.ajax({
        url: 'AdmInistracionPallets.aspx/ActualizarPallet',
        data: data,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato.IdError == '02') {
                jAlert('error al Actualizar Registro');
            } else {
                $("#ModalBusqueda").dialog("destroy");
                ConsultarPallet($("#txtCriterioBusqueda").val());
                $('#txtCodigoP').val('');
                
            }
        }
    })

};









