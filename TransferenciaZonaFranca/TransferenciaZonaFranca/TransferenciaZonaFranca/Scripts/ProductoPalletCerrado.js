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

    ConsultarProductosPalletCerrado(CriterioBusqueda);
    
});



//Función   que consulta ARTICULOS por nombre
function ConsultarProductosPalletCerrado(CriterioBusqueda) {


    var params = new Object();
    params.CodigoPallet = CriterioBusqueda

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "AdministracionPalletsCerrados.aspx/ConsultarProductoPalletCerrados",
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
            
             { h: 'Tubo', style: 'width: 50px', sort: 'Tubo' }
            , { h: 'Codigo', style: 'width: 50px;', sort: 'Codigo' }
             , { h: 'Descripcion', style: 'width:250px;', sort: 'Descripcion' }
              ,{ h: 'Secuencia', style: 'width: 50px;', sort: 'Secuencia' }
             , { h: 'Capacidad', style: 'width: 50px;', sort: 'Capacidad' }
             , { h: 'Volumen', style: 'width: 50px;', sort: 'Volumen' }
             , { h: '', style: 'width: 50px;', sort: '' }
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

    var data = JSON.stringify({ Codigo: CodigoPallet, Pallet: $("#txtCriterioBusqueda").val() });
    $.ajax({
        url: 'AdministracionPalletsCerrados.aspx/EliminarProductoPallet',
        data: data,
        success: function (response) {
            // jAlert('Registro Eliminado Satisfactoriamente');
            ConsultarProductosPalletCerrado($("#txtCriterioBusqueda").val());
        }
    })

}


