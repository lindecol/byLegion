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

    ConsultarArticuloPP(CriterioBusqueda, $("#cmbBuscarPor").val());
    
});



//Función   que consulta ARTICULOS por nombre
function ConsultarArticuloPP(id,Tipo) {


    var params = new Object();
    params.CodigoProducto = id;
    params.Tipo = Tipo;

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "ConfiguracionPP.aspx/ConsultarArticuloPP",
        data: JSON.stringify(params),
        dataType: "json",
        async: false,
        success: function (response, textStatus) {

            var registros = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            //           
            CargarTabla(registros);
            //            if (textStatus == "success") {
            //                $("#list").clearGridData();// LIMPIAR GRILLA
            //               
            //                var grid = $("#list")[0];
            //                grid.addJSONData(jQuery.parseJSON(data.d));
            //                mydata = data;
            //            }

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
             { h: 'Codigo', style: 'width: 38px;', sort: 'Codigo' }
            , { h: 'Descripcion', style: 'width: 60px', sort: 'Descripcion' }
            , { h: 'PesoPromedio', style: 'width: 90px;', sort: 'PesoPromedio' }
             , { h: 'Codigo Facturación', style: 'width: 90px;', sort: 'CodigoFacturacion' },
             , { h: 'Descripción Facturación', style: 'width: 50;', sort: 'DesCodigoFacturacion' },
             , { h: 'Tipo', style: 'width: 50px;', sort: 'Tipo' }
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
        height: 250,
        width: 470,
        modal: true
    });
    return false

}

function Editar(Codigo, Descripcion, PesoPromedio,CodigoFacturar,tipo) {

    $("#txtPeso").numeric(".");
    $("#txtPeso").focus();
    $("#txtCodigoP").attr('readonly', true);
    $("#txtArticulo").attr('readonly', true);
    jQuery.trim($('#txtCodigoP').val(Codigo));
    jQuery.trim($('#txtArticulo').val(Descripcion));
    jQuery.trim($('#txtPeso').val(PesoPromedio));
    jQuery.trim($('#txtCodigoFacturar').val(CodigoFacturar));

    if (tipo == "PP")
        tipo = 1;
    if (tipo == "SL")
        tipo = 2;
    if (tipo == "")
        tipo = 0;
    

    $("#cmbTipo option[value="+tipo+"]").attr("selected", true);
    
    VentanaEditar();
    Option = 2;//Editar

}

function Eliminar(Codigo) {
    if (confirm('Esta seguro de eliminar el Producto seleccionado?')) {
        EliminarProductoPP(Codigo);
    }
}

function Nuevo() {
    
    $("#txtPeso").numeric(".");
    $('#txtCodigoP').attr('readonly', false);
    $('#txtArticulo').attr('readonly', true);
    jQuery.trim($('#txtCodigoP').val(''));
    jQuery.trim($('#txtArticulo').val(''));
    jQuery.trim($('#txtPeso').val(''));
    jQuery.trim($('#txtCodigoFacturar').val(''));
    $("#cmbTipo option[value=0]").attr("selected", true);
    $('#txtCodigoP').focus();
    VentanaEditar();
    Option = 1;  //Nuevo

}
$('#BtnNuevo').click(function () {

    Nuevo();

});

$('#btnGuardar').click(function () {

    if (jQuery.trim($('#txtCodigoP').val()) == '') {
        jAlert('Se requiere Digitar el Código del producto', 'Validación Datos');
        $('#txtArticulo').focus();
       return;
    }

   if (jQuery.trim($('#txtPeso').val()) == '') {
       jAlert('Se requiere Digitar Peso Promedio del producto', 'Validación Datos');
       $('#txtArticulo').focus();
       return;
   }

   if (jQuery.trim($('#cmbTipo').val()) == '0') {
       jAlert('Se requiere Seleccionar tipo de articulo', 'Validación Datos');
       $('#txtArticulo').focus();
       return;
   }

    if (Option == 2) {
        AdministrarArticulosPP();
    } else {
        NuevoArticulosPP();
    }

});


function AdministrarArticulosPP() {
    var registro = new Object();

    var data = JSON.stringify({ Codigo: $("#txtCodigoP").val(), Peso: $("#txtPeso").val(), CodigoFacturar: $("#txtCodigoFacturar").val(), Tipo: $("#cmbTipo").val() });
    $.ajax({
        url: 'ConfiguracionPP.aspx/ActualizarPP',
        data: data,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato.IdError == '02') {
                jAlert('error al Actualizar Registro');
            } else {
                $("#ModalBusqueda").dialog("destroy");
                ConsultarArticuloPP($("#txtCriterioBusqueda").val(), $("#cmbBuscarPor").val());
            }
        }
    })

};

function NuevoArticulosPP() {
    var registro = new Object();

    var data = JSON.stringify({ Codigo: $("#txtCodigoP").val(), Peso: $("#txtPeso").val(), CodigoFacturar: $("#txtCodigoFacturar").val(), Tipo: $("#cmbTipo").val() });
    $.ajax({
        url: 'ConfiguracionPP.aspx/NuevoPP',
        data: data,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato.IdError == '02') {
                jAlert('error al Ingresar Registro');
            } else {
                $("#ModalBusqueda").dialog("destroy");
                ConsultarArticuloPP($("#txtCriterioBusqueda").val(), $("#cmbBuscarPor").val());
            }
        }
    })

};

//Función Carga la Informacion del Producto
function ConsultarProducto(Codigo) {

    if (Option == 1) {

        var datos = JSON.stringify({ Codigo: Codigo });
        $.ajax({
            url: 'ConfiguracionPP.aspx/ConsultarProducto',
            data: datos,
            success: function (response) {
                var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
                if (Tdato.length != 0) {

                    if (Tdato[0].EsCuentaCorriente != 'N') {
                        ValidarExisteArticulo_PP(Codigo);
                        $('#txtArticulo').val(Tdato[0].Descripcion);

                    } else {
                        $('#txtCodigoP').val('');
                        jAlert('El Producto ' + Codigo + ' No es de Cuenta Corriente', 'Maestro Productos');


                    }

                } else {
                    $('#txtCodigoP').val('');
                    jAlert('El Producto ' + Codigo + ' No existe, o No está Habilitado', 'Maestro Productos');

                    $('#txtArticulo').focus();

                    return;
                }

            }
        });
   }
}

//Función Carga la Informacion del Producto
function ConsultarProductoFacturacion(Codigo) {


        var datos = JSON.stringify({ Codigo: Codigo });
        $.ajax({
            url: 'ConfiguracionPP.aspx/ConsultarProducto',
            data: datos,
            success: function (response) {
                var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
                if (Tdato.length == 0) {
                    $('#txtCodigoFacturar').val('');
                    jAlert('El Producto ' + Codigo + ' No existe, o No está Habilitado', 'Maestro Productos');
                    $('#txtCodigoFacturar').focus();

                    return;
                }

            }
        });
    
}

$('#txtCodigoP').focusout(function () {

    if ($('#txtCodigoP').val() != "") {
        ConsultarProducto($('#txtCodigoP').val());
       
    }

});

$('#txtCodigoFacturar').focusout(function () {

    if ($('#txtCodigoFacturar').val() != "" && $('#txtCodigoFacturar').val() != "0") {
        ConsultarProductoFacturacion($('#txtCodigoFacturar').val());

    }

});

//Función valida la cantidad de productos en ram
function ValidarExisteArticulo_PP(CodigoProducto) {


    var datos = JSON.stringify({ Codigo: CodigoProducto});
    $.ajax({
        url: 'ConfiguracionPP.aspx/ValidarExisteArticulo_PP',
        data: datos,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato > 0) {
                $('#txtCodigoP').val('');
                jAlert('El producto ya se encuentra registrado como Propia Producción, Edítelo.');
                $('#txtArticulo').focus();
                $('#txtArticulo').val('');
                return;
            } 
        }
    });
}

function EliminarProductoPP(Producto) {
    
    var data = JSON.stringify({ Codigo: Producto });
    $.ajax({
        url: 'ConfiguracionPP.aspx/EliminarProductoPP',
        data: data,
        success: function (response) {
            // jAlert('Registro Eliminado Satisfactoriamente');
            ConsultarArticuloPP($("#txtCriterioBusqueda").val(), $("#cmbBuscarPor").val());
        }
    })

}