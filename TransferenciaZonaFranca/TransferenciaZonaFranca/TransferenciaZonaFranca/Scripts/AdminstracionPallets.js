var mydata = 0;

$(document).ready(function () {

  
  //  $("#TProductos").dataTable();
});

CargarDocumentos();
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

    ConsultarPallet(CriterioBusqueda);
    
});


$('#btnLiberar').click(function () {

    var CriterioBusqueda = $("#txtCodigoP").val();

    LiberarPallet(CriterioBusqueda);

});



function LiberarPallet(CodigoPallet) {

    var data = JSON.stringify({ Codigo: CodigoPallet });
    $.ajax({
        url: 'AdministracionPallets.aspx/LiberarPallet',
        data: data,
        success: function (response) {
            $("#ModalBusqueda").dialog("destroy");
            jAlert('Pallet Liberado Satisfactoriamente');
            ConsultarPallet($("#txtCriterioBusqueda").val());
        }
    })

}


//Función de Cargar Tipos de Documentos
function CargarDocumentos() {

    var params = new Object();
    params.ConectarA = jQuery.trim($('#lblBd').text())

   // var datos = JSON.stringify({ ConectarA: 'a' });
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: 'MatarSesion.aspx/CargarDocumentos',
        // data: datos,
        data: JSON.stringify(params),
        error: function (objeto, quepaso, otroobj) {
            mostrarError(objeto, quepaso, otroobj);
        },
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato != null) {
                $('#CmbTipo').empty();
                $('#CmbTipo').append('<option value="-1" selected="selected">Seleccione...</option>');
                $.each(Tdato, function (i, v) {
                    $('#CmbTipo').append('<option value="' + v.Tipodoc + '">' + v.DescripcionTipoDoc + '</option>');
                });
            }
        }
    });
}

//Función   que consulta ARTICULOS por nombre
function ConsultarPallet(CriterioBusqueda) {


    var params = new Object();
    params.CodigoPallet = CriterioBusqueda

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "AdministracionPallets.aspx/ConsultarPallets",
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
             { h: 'IdPallet', style: 'width: 38px;', sort: 'IdPallet' }
            , { h: 'Estado', style: 'width: 60px', sort: 'Estado' }
            , { h: 'Observaciones', style: 'width: 90px;', sort: 'Observaciones' }
             , { h: '', style: 'width: 40px;', sort: '' }
             , { h: '', style: 'width: 40px;', sort: '' }
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

function Editar(Codigo, Estado, Observaciones) {



    var tipo = Estado;
   
    $("#txtCodigoP").attr('readonly', true);
    $("#txtArticulo").attr('readonly', false);
   // $("#cmbTipo option[value=" + tipo + "]").attr("selected", true);
    $("#cmbTipo option[value=D]").attr("disabled", false);
    $("#cmbTipo option[value=C]").attr("disabled", false);
    $("#cmbTipo option[value=I]").attr("disabled", false);

    jQuery.trim($('#txtCodigoP').val(Codigo));
    jQuery.trim($('#txtArticulo').val(Observaciones));

    if (tipo == "Cerrado")
        tipo = "C";
    if (tipo == "Disponible")
        tipo = "D";
    if (tipo == "Inactivo")
        tipo = "I";
    if (tipo == "")
        tipo = 0;


    $("#cmbTipo option[value=" + tipo + "]").attr("selected", true);
    

    
    VentanaEditar();
    Option = 2;//Editar

}

function Eliminar(Codigo) {
    if (confirm('Esta seguro de eliminar el Producto seleccionado?')) {
        EliminarPallet(Codigo);
    }
}

function Nuevo() {

    $('#txtCodigoP').val('');
    $('#txtArticulo').val('');
    $('#txtCodigoP').focus();
    $('#txtCodigoP').attr('readonly', false);
   // $('#txtArticulo').attr('readonly', false);
    $("#cmbTipo option[value=D]").attr("selected", true);
    $("#cmbTipo option[value=C]").attr("disabled", true);
    $("#cmbTipo option[value=I]").attr("disabled", true);
    //$('#cmbTipo option:not(:selected)').attr('disabled', true);
    $('#cmbTipo').attr('readonly', false);
    VentanaEditar();
    Option = 1;  //Nuevo

}
$('#BtnNuevo').click(function () {

    Nuevo();

});

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

function NuevoPallet() {
    var registro = new Object();

    var data = JSON.stringify({ Codigo: $("#txtCodigoP").val(), Estado: $("#cmbTipo").val(), Observaciones: $("#txtArticulo").val() });
    $.ajax({
        url: 'AdmInistracionPallets.aspx/NuevoPallet',
        data: data,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato.IdError == '02') {
                jAlert('error al Ingresar Registro');
            } else {
                $("#ModalBusqueda").dialog("destroy");
                ConsultarPallet($("#txtCriterioBusqueda").val());
            }
        }
    })

};








//Función valida la cantidad de productos en ram
function ValidarExistePallet(Codigo) {


    var datos = JSON.stringify({ Codigo: Codigo});
    $.ajax({
        url: 'AdministracionPallets.aspx/ValidarExistePallet',
        data: datos,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato > 0) {
                jAlert('El pallet ya se encuentra registrado, Edítelo.');

            } else {
                NuevoPallet();
            }

        }
    });
}

function EliminarPallet(CodigoPallet) {

    var data = JSON.stringify({ Codigo: CodigoPallet });
    $.ajax({
        url: 'AdministracionPallets.aspx/EliminarPallet',
        data: data,
        success: function (response) {
            // jAlert('Registro Eliminado Satisfactoriamente');
            ConsultarPallet($("#txtCriterioBusqueda").val());
        }
    })

}


$('#btnEliminarSesion').click(function () {

    var UsuarioEliminar = $("#txtUsuario").val();

    if (jQuery.trim($('#CmbTipo').val()) == '-1') {
        jAlert('Seleccione el tipo de Documento donde eliminará la sesión', 'Validación Datos');
        $("#Principal").unmask();
        return;
    }

    var data = JSON.stringify({ Usuario: UsuarioEliminar, Doc: jQuery.trim($('#CmbTipo').val()) });
    $.ajax({
        url: 'MatarSesion.aspx/EliminarSesionUsuario',
        data: data,
        success: function (response) {
            jAlert('Proceso Realizado Satisfactoriamente');
           
        }
    })

});