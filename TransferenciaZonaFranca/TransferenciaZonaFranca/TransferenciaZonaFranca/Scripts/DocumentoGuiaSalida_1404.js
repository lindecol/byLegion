var mydata = 0;

$(document).ready(function () {


    $(window).bind("beforeunload", function (e) {

    EliminarTablaTemporalInicial(0);
        alert('Sesion Finalizada');   

    })

    //Tabular con la tecla Enter
    $("#txtCodigo").keypress(function (e) {
        if (e.which == 13) {
            e.preventDefault();
            $('#txtDescripcion').focus();
        }

        if (e.which == 32) {

            $("#list").clearGridData(); // LIMPIAR GRILLA

            $("#ModalBusqueda").dialog({
                height: 600,
                width: 600,
                modal: true
            });
            return false
        }
    });


    $("#txtDescripcion").keypress(function (e) {
        if (e.which == 13) {
            e.preventDefault();
            $('#txtCantidad').focus();
        }
    });

    $("#txtCantidad").keypress(function (e) {
        if (e.which == 13) {
            e.preventDefault();
            $('#txtCapacidad').focus();
        }
    });

    $("#txtCapacidad").keypress(function (e) {
        if (e.which == 13) {
            e.preventDefault();
            $('#txtVolumen').focus();
        }
    });

    $("#txtVolumen").keypress(function (e) {
        if (e.which == 13) {
            e.preventDefault();
            $('#txtObservacion').focus();
        }
    });

    $("#txtObservacion").keypress(function (e) {
        if (e.which == 13) {
            e.preventDefault();
            $('#btnAgregarProducto').focus();
        }
    });

    $("#txtSecuencia").keypress(function (e) {
        if (e.which == 13) {
            e.preventDefault();
            $('#txtCapacidad1').focus();
        }
    });

    $("#txtCapacidad1").keypress(function (e) {
        if (e.which == 13) {
            e.preventDefault();
            $('#txtVolumen1').focus();
        }
    });

    $("#txtVolumen1").keypress(function (e) {
        if (e.which == 13) {
            e.preventDefault();
            $('#btnAgregarProducto1').focus();
        }
    });

    $("#txtObservacion1").keypress(function (e) {
        if (e.which == 13) {
            e.preventDefault();
            $('#btnAgregarProducto1').focus();
        }
    });

    $("#txtRuta").keypress(function (e) {
        if (e.which == 13) {
            e.preventDefault();
            $('#txtVehiculo').focus();
        }

    });

    $("#txtVehiculo").keypress(function (e) {
        if (e.which == 13) {
            e.preventDefault();
            $('#txtCodigoConductor').focus();
        }
    });

    $("#txtCodigoConductor").keypress(function (e) {
        if (e.which == 13) {
            e.preventDefault();
            $('#txtCodigo').focus();
        }
        if (e.which == 32) {//buscar Conductores
            $("#list").clearGridData(); // LIMPIAR GRILLA
            $("#ModalBusquedaConductores").dialog({
                height: 600,
                width: 600,
                modal: true
            });
            return false
        }
    });



    $("#btnNuevo").attr('disabled', '-1');

    if ($('#hdIdEmpresa').val() == "25") {
        $("#btnProcesar").attr('disabled', '-1');
    } else {
        $("#btnVista").attr('disabled', '-1');
    }

    //grilla de busqueda de articulos
    $("#list").jqGrid({
        datatype: 'json',
        data: mydata,
        mtype: 'GET',
        colNames: ['Codigo', 'Descripcion'],
        colModel: [
	                { name: 'Codigo', index: 'Codigo', width: 40, sortable: false },
	                { name: 'Descripcion', index: 'Descripcion', width: 80, sortable: false }
                  ],
        //pager: jQuery('#pager'),
        rowNum: 1000,
        rowList: [10, 20, 50, 100],
        sortname: 'Codigo',
        sortorder: 'asc',
        viewrecords: true,
        imgpath: '/content/sunny/images',
        caption: 'Productos',
        height: 'auto',
        width: 540,


        //autowidth: true
        onSelectRow: function (id) {

            FilaSeleccionada(id, 1);

        }
    });


    //grilla de busqueda de conductores
    $("#listConductores").jqGrid({
        datatype: 'json',
        data: mydata,
        mtype: 'GET',
        colNames: ['Codigo', 'Nombre'],
        colModel: [
	                { name: 'CodigoConductor', index: 'CodigoConductor', width: 40, sortable: false },
	                { name: 'NombreConductor', index: 'NombreConductor', width: 80, sortable: false }
                  ],
        //pager: jQuery('#pager'),
        rowNum: 1000,
        rowList: [10, 20, 50, 100],
        sortname: 'NombreConductor',
        sortorder: 'des',
        viewrecords: true,
        imgpath: '/content/sunny/images',
        caption: 'Conductores',
        height: 'auto',
        width: 540,

        //autowidth: true
        onSelectRow: function (id) {

            FilaSeleccionada(id, 2);

        }
    });



});


var mydata;



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




$(function () {
    $("#txtFecha").datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'dd/mm/yy'
    });
});

//var EmpresaId = $('#lblEmpresa').val(); //  25;  //viene por sesion de logueo OPCION EMPRESA OXIGENOS PRUEBA
var IdRuta = null;


function FormatForm(strValor) {
    if (strValor.indexOf('?') != -1)
        strValor = strValor.substring(0, strValor.indexOf('?'));
    else
        strValor = strValor;
    return strValor;
};

//Evento del combo cmbEmpresaDestino
$('#cmbEmpresaDestino').change(function () {
    $('#cmbEmpresaDestino option:selected').each(function () {
        CargarSucursales($(this).val());
    });

});

$('#btnFacturar').click(function () {

  //  VerReporteFactura(jQuery.trim($('#LblNumeroFacturaGenerada').text()));
    VerReporteFactura(00002099);

});


$('#btnSalir').click(function () {

    javascript: window.close()
});




$('#btnCargarAut').click(function () {


    if (jQuery.trim($('#txtRuta').val()) == '') {
        jAlert('Se requiere digitar Capacidad', 'Validación Datos');
        return;
    }
    ConsultarCargueAutomaticoZF($("#lblIdEmpresa").text(), jQuery.trim($('#hdPuntoDeVentaCamionGuia').val()));

});

$('#btnRemito').click(function () {
    VerReporteRemito(jQuery.trim($('#txtNumeroDocumento').val()));
});

$('#RdbCargueAutomatico').click(function () {
   // $("#txtNumeroCargue").attr("style", "visibility: visible");
    $("#btnCargarAut").attr("style", "visibility: visible");
});

$('#RdbCargueManual').click(function () {
    $("#txtNumeroCargue").attr("style", "visibility: hidden")
    $("#btnCargarAut").attr("style", "visibility: hidden")
    $('#txtNumeroCargue').val('');
});

$('#btnAgregarProducto').click(function () {

    var existe = ValidarExsiteProductoGrillaPropios(jQuery.trim($('#txtCodigo').val()), jQuery.trim($('#txtCapacidad').val()), jQuery.trim($('#txtVolumen').val()));
    if (existe == false) {

        if (jQuery.trim($('#txtCodigo').val()) == '') {
            jAlert('Se requiere Digitar Código de Producto', 'Validación Datos');
            return;
        }

        if (jQuery.trim($('#txtCantidad').val()) == '') {
            jAlert('Se requiere  digitar Cantidad', 'Validación Datos');
            return;
        }

        if (jQuery.trim($('#txtCapacidad').val()) == '') {
            jAlert('Se requiere digitar Capacidad', 'Validación Datos');
            return;
        }

        if (jQuery.trim($('#txtVolumen').val()) == '') {
            jAlert('Se requiere digitar volumen', 'Validación Datos');
            return;
        }

        ValidarCantidadStock(jQuery.trim($('#lblIdEmpresa').text()), 1);

    } else {

        jAlert('Producto, Capacidad y Volumen ya existen en la grilla', 'Validación datos');
        return;
    }
});

$('#btnAgregarProducto1').click(function () {

    var existe = ValidarExsiteProductoGrillaAjenos(jQuery.trim($('#txtSecuencia').val()));

    if (existe == false) {

        if (jQuery.trim($('#txtCodigo1').val()) == '') {
            jAlert('Se requiere Digitar Código de Producto', 'Validación Datos');
            return
        }

        if (jQuery.trim($('#txtCapacidad1').val()) == '') {
            jAlert('Se requiere digitar Capacidad', 'Validación Datos');
            return
        }

        if (jQuery.trim($('#txtVolumen1').val()) == '') {
            jAlert('Se requiere digitar volumen', 'Validación Datos');
            return
        }

        if (jQuery.trim($('#txtSecuencia').val()) == '') {
            jAlert('Se requiere digitar Secuencia del Tubo', 'Validación Datos');
            return
        }

        if (jQuery.trim($('#txtCodigoTubo').val()) == '') {
            jAlert('Se requiere digitar código del Tubo', 'Validación Datos');
            return
        }

        if (jQuery.trim($('#txtCliente').val()) == '') {
            jAlert('Se requiere Propietario del Tubo', 'Validación Datos');
            return
        }


        ValidarCantidadStock(jQuery.trim($('#lblIdEmpresa').text()), 2);
        //AmacenarDetalleTablaTemporal(2);
    } else {

        jAlert('Secuencia del tubo ya existe en la grilla', 'Validación datos');
        return;
    }

});

$('#btnProcesar').click(function () {

//LETO
    if (confirm('Esta seguro de Procesar la Transferencia?')) {
        $("#Principal").mask();

        ValidarSiHayInventarioAbierto($('#hdIdEmpresa').val());
    }
    else {
        return false;
    }

});

$('#btnNuevo').click(function () {

    // Recargo la página
    location.reload();
    if (jQuery.trim($('#lblIdEmpresa').text()) == "25") {
        $("#btnProcesar").attr('disabled', '-1');
    }
});


$('#btnlimpiarGrilla').click(function () {


    if (confirm('Esta seguro eliminar Todos los elementos de la grilla?')) {
        prode = new Array();
        prode_1 = new Array();

        ItemsProductos.Productos = prode;
        ItemsProductosParticulares.ProductosParticulares = prode_1;

        var valorTempCilindrosP = $("#lblTotalCilindrosPraxair").text();

        $("#TProductos tbody").remove();
        $("#TproductosParticulares tbody").remove();
        $("#lblTotalCilindrosPraxair").text(0);
        $("#lblTotalCilindrosAjenos").text(0);


        EliminarTablaTemporalInicial(0);
    }
    else {
        return false;
    }

});

$('#btnVista').click(function () {

    $("#btnProcesar").removeAttr('disabled');
    VerReporteFacturaPreliminar($('#hdUsuario').val())
});


$('#txtSecuencia').change(function () {

    ConsultarTubo(jQuery.trim($('#lblIdEmpresa').text()));

    $("#txtCapacidad1").numeric("");
    $("#txtCantidad1").numeric(",");
    $("#txtVolumen1").numeric(",");

});

$('#txtCodigo').focusout(function () {
    //Opcion Variable que determina si se validara el codigo del producto de la grilla de Propioos o Particulares
    //1 = Grilla Producto Praxair
    //2 = Grilla Producto Particular

    if ($('#txtCodigo').val() != "") {

        var tmpIdsucursal = $('#hdIdSucursal').val();
        ConsultarProducto(jQuery.trim($('#lblIdEmpresa').text()), 1);

        $('#txtCantidad').val('');
        $('#txtCapacidad').val('');
        $("#txtCapacidad").numeric(".");
        $("#txtCantidad").numeric(".");
        $("#txtVolumen").numeric(".");
    }

});


$('#txtCodigo1').change(function () {
    //Opcion Variable que determina si se validara el codigo del producto de la grilla de Propioos o Particulares
    //1 = Grilla Producto Praxair
    //2 = Grilla Producto Particular
    ConsultarProducto(jQuery.trim($('#lblIdEmpresa').text()), 2);
});

$('#txtCantidad').change(function () {
    CalcularVolumen(1);
});


$('#txtVolumen').focusout(function () {

    var Cantidad = $('#txtCantidad').val();
    var Capacidad = $('#txtCapacidad').val();
    var VolumenActual = $('#txtVolumen').val();
    var VolumenCalculado = Cantidad * Capacidad;

    if (VolumenActual != 0) {
        if (VolumenActual != VolumenCalculado) {

            jAlert('El subtotal debe ser igual a la capacidad * cantidad en caso de ser llenos o 0(cero) en caso de ser vacios', 'Validación datos');
            $('#txtVolumen').val('')
            return;
        }

    }

    if (VolumenActual != "") {
        CantidadProductosEnRampa(jQuery.trim($('#lblIdEmpresa').text()), 1);
    }
});


$('#txtVolumen1').focusout(function () {

    var Cantidad = 1;
    var Capacidad = $('#txtCapacidad1').val();
    var VolumenActual = $('#txtVolumen1').val();
    var VolumenCalculado = Cantidad * Capacidad;

    if (VolumenActual != 0) {
        if (VolumenActual != VolumenCalculado) {

            jAlert('El volumen ingresado no corresponde con la cantidad y la capacidad, el único valor válido es 0 para vacios', 'Maestro Productos');
            $('#txtVolumen1').val('')
            return;
        }

    }

    VerificarEsatadoLLenoVacio($('#hdIdEmpresa').val());
});

$('#txtVehiculo').focusout(function () {

    if ($('#txtVehiculo').val() != "")
        EsVehiculoValido(jQuery.trim($('#lblIdEmpresa').text()));
});

$('#txtCodigoConductor').focusout(function () {

    if ($('#txtCodigoConductor').val() != "") {
        DatosConductor(jQuery.trim($('#lblIdEmpresa').text()));
    }
});

$('#txtCapacidad').focusout(function () {

    ValidarCapacidad(jQuery.trim($('#lblIdEmpresa').text()), 1);
});

$('#txtCapacidad1').focusout(function () {

    ValidarCapacidad(jQuery.trim($('#lblIdEmpresa').text()), 2);
});

$('#txtRuta').focusout(function () {
    EsRutaRampa(jQuery.trim($('#lblIdEmpresa').text()));
});

//Función de Cargar Sucursal definida en el WebMethod
function CargarSucursales(idEmpresa) {
    var datos = JSON.stringify({ IdEmpresa: idEmpresa, ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/SucursalesPorEmpresa',
        data: datos,
        error: function (objeto, quepaso, otroobj) {
            mostrarError(objeto, quepaso, otroobj);
        },
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato != null) {
                $('#CmbSucursalDestino').empty();
                $('#CmbSucursalDestino').append('<option value="-1" selected="selected">Seleccione...</option>');
                $.each(Tdato, function (i, v) {
                    $('#CmbSucursalDestino').append('<option value="' + v.SucursalId + '">' + v.Nombre + '</option>');
                });
            }
        }
    });
}


//Función Carga la Informacion del Producto
function ConsultarProducto(idEmpresa, Opcion) {

    var strCodigoProducto = "";

    if (Opcion == 1)
        strCodigoProducto = $("#txtCodigo").val();
    if (Opcion == 2)
        strCodigoProducto = $("#txtCodigo1").val();

    var datos = JSON.stringify({ IdEmpresa: idEmpresa, Codigo: strCodigoProducto, ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/ConsultarProducto',
        data: datos,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato.length != 0) {

                if (Tdato[0].EsCuentaCorriente != 'N') {

                    if (Opcion == 1) {
                        $('#txtDescripcion').val(Tdato[0].Descripcion);
                        $('#txtCodigo').val(Tdato[0].Codigo);
                        var Stock = Tdato[0].EsStockeable
                        if (Stock == 'S') {
                            EsGasStockeable(idEmpresa, Opcion);
                        }

                    } else {
                        $('#txtDescripcion1').val(Tdato[0].Descripcion);
                        $('#txtCodigo1').val(Tdato[0].Codigo);
                    }


                    $('#hdEsProductoStockeable').val(Tdato[0].EsStockeable);
                    $('#hdEsProductoCuentaCorriente').val(Tdato[0].EsCuentaCorriente);
                    $('#hdIdArticulo').val(Tdato[0].ProductoId);

                } else {
                    jAlert('El Producto ' + $('#txtCodigo').val() + ' No es de Cuenta Corriente', 'Maestro Productos');
                    LimpiarControles();

                }

            } else {
                jAlert('El Producto ' + $('#txtCodigo').val() + ' No existe, o No está Habilitado', 'Maestro Productos');

                LimpiarControles();

                return;
            }

        }
    });
}


//Función para cargar los items leidos en una OBC y cargarlos en la grillla
function ConsultarCargueAutomaticoZF(idEmpresa,Cargue) {
    var totalCilindrosPropios = 0;
    var totalCilindrosAjenos = 0;
    var cilindrosPropios = 0;
    var EmpDestino = jQuery.trim($('#cmbEmpresaDestino').val());
    var SucDestino = jQuery.trim($('#CmbSucursalDestino').val());

    var datos = JSON.stringify({ IdEmpresa: EmpDestino, Pto_venta: Cargue, Usuario: jQuery.trim($('#lblNombreUsuario').text()), Agencia: SucDestino, ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/ConsultarCargueAutomaticoZF_GuiaCarga',
        data: datos,
        error: function (objeto, quepaso, otroobj) {
            mostrarError(objeto, quepaso, otroobj);
        },
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato != null) {
              //  $("#lblPallets_").text(Tdato[0].Codigo);
                for (var i = 0; i < Tdato.length; i++) {

                    AddProducto = new clsProductos();
                    AddProducto.Codigo = Tdato[i].Codigo;

                    AddProducto.Descripcion = Tdato[i].Descripcion;
                    AddProducto.Capacidad = Tdato[i].Capacidad;
                    AddProducto.Cantidad = Tdato[i].Cantidad;
                    AddProducto.Volumen = Tdato[i].Volumen;
                    if (Tdato[i].PropietarioTubo != "") {
                        AddProducto.Propietario = Tdato[i].NombrePropietarioTubo;
                    } else {
                        AddProducto.Propietario = "N/A";
                    }

                    if (Tdato[i].Tubo != "") {
                        AddProducto.CodigoTubo = Tdato[i].Tubo;
                    } else {
                        AddProducto.CodigoTubo = 'N/A';
                    }
                    AddProducto.Observacion = "A";

                    if (Tdato[i].Secuencia == "") {
                        Tdato[i].Secuencia = "0";
                    }
                   // AmacenarDetalleTablaTemporal_Aut(1, Tdato[i].Codigo, Tdato[i].Capacidad, Tdato[i].Cantidad, Tdato[i].Volumen, Tdato[i].Secuencia);



                    if (Tdato[i].Secuencia != "0") {
                        AlmacenarDetalleTablaTemporalAgenos_Aut(2, Tdato[i].Codigo, Tdato[i].Capacidad, Tdato[i].Cantidad, Tdato[i].Volumen, Tdato[i].PropietarioTubo, Tdato[i].Tubo);
                        AddProducto.Secuencia = Tdato[i].Secuencia;
                        ItemsProductosParticulares.ProductosParticulares[ItemsProductosParticulares.ProductosParticulares.length] = AddProducto;
                        totalCilindrosAjenos = totalCilindrosAjenos + 1;

                    } else {
                        AlmacenarDetalleTablaTemporalAgenos_Aut(1, Tdato[i].Codigo, Tdato[i].Capacidad, Tdato[i].Cantidad, Tdato[i].Volumen, Tdato[i].PropietarioTubo, Tdato[i].Tubo);
                        ItemsProductos.Productos[ItemsProductos.Productos.length] = AddProducto;
                        cilindrosPropios = Tdato[i].Cantidad;
                        totalCilindrosPropios = totalCilindrosPropios + cilindrosPropios;
                    }
                }

                //total de cilindros propios
                var CilindrosActuales = 0;

                var cilindrosantes = 0;
                var cilindrosantes = jQuery.trim($('#lblTotalCilindrosPraxair').text());


                CilindrosActuales = parseFloat(CilindrosActuales) + totalCilindrosPropios + parseFloat(cilindrosantes);
                $("#lblTotalCilindrosPraxair").text(CilindrosActuales);
                if (CilindrosActuales > 0) {
                    CargarDatagrid();
                }
                

                //total de cilindros ajenos
                var cilindrosantesPar = 0;
                var cilindrosantesPar = jQuery.trim($('#lblTotalCilindrosAjenos').text());

                var CilindrosActualesAjenos = 0;
                CilindrosActualesAjenos = totalCilindrosAjenos + parseFloat(cilindrosantesPar);
                $("#lblTotalCilindrosAjenos").text(CilindrosActualesAjenos);
                if (CilindrosActualesAjenos > 0) {
                    CargarDatagridParticulares();
                }
            }
        }
    });
}



//Función Carga la Informacion del Producto
function ConsultarTubo(idEmpresa) {

    var datos = JSON.stringify({ IdEmpresa: idEmpresa, Secuencia: $("#txtSecuencia").val(), ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/ConsultarTubo',
        data: datos,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato.length != 0) {

                $('#txtCodigoTubo').val(Tdato[0].NumeroTubo);
                $('#txtCliente').val(Tdato[0].CodigoCliente + "-" + Tdato[0].NombreCliente);
                $('#txtCodigo1').val(Tdato[0].CodigoProducto);
                $('#txtDescripcion1').val(Tdato[0].NombreProducto);
                $('#hdnIdClienteTubo').val(Tdato[0].CodigoCliente);
                $("#hdIdArticulo").val(Tdato[0].IdProducto);
                $('#txtCapacidad1').val(Tdato[0].Capacidad);
                $('#txtVolumen1').val($('#txtCapacidad1').val());
                //  $('#txtObservacion1').focus();
                $('#txtVolumen1').focus();

            } else {
                jAlert('Número de secuencia de Tubo Inexistente o ya fue procesado');
                LimpiarControlesParticulares();

                return;
            }

        }
    });
}



//Función para hallar el factor de conversion de un producto
function BuscarFactorVta(idEmpresa, Opcion) {

    var strProducto = "";

    if (Opcion == 1)
        strProducto = $("#txtCodigo").val();
    else
        strProducto = $("#txtCodigo1").val();

    var datos = JSON.stringify({ IdEmpresa: idEmpresa, Codigo: strProducto, ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/BuscarFactorVta',
        data: datos,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato == 0) {
                jAlert('Falta el factor de conversión para el producto ' + strProducto, 'Maestro Productos');
                return;
            } else {
                if (Opcion == 1)
                    $('#txtCapacidad').val(Tdato);
                else
                    $('#txtCapacidad1').val(Tdato);
            }
        }
    });
}


//Función valida la cantidad de productos en ram
function CantidadProductosEnRampa(idEmpresa, Opcion) {

    var strProducto = "";
    var strEsPropio = "";
    var strVolumen = "";
    var strEsLleno = "1";
    var strCapacidad = "0";
    var CantidadSalen = 0;

    if (Opcion == 1) {
        strProducto = $("#txtCodigo").val();
        strEsPropio = "1";
        strVolumen = $("#txtVolumen").val();
        CantidadSalen = $("#txtCantidad").val();
    }

    if (Opcion == 2) {
        strProducto = $("#txtCodigo1").val();
        strEsPropio = "2";
        strVolumen = $("#txtVolumen1").val();
        strCapacidad = $("#txtCapacidad1").val();
        CantidadSalen = $("#txtCantidad1").val();
    }

    if (strVolumen == "0")
        strEsLleno = 2;

    var datos = JSON.stringify({ IdEmpresa: idEmpresa, Codigo: strProducto, EsPropio: strEsPropio, EsLleno: strEsLleno, Capacidad: strCapacidad, Agencia: jQuery.trim($('#lblAgencia1').text()), ConectarA: jQuery.trim($('#lblBd').text()), SubDep: jQuery.trim($('#lblSubdeposito').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/CantidadProductosEnRampa',
        data: datos,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato < CantidadSalen) {

                //                if ($('#txtVolumen').val() != '0') {
                jAlert('la cantidad de cilindros  en el sector A es de ' + Tdato + ' Cilindros, No puede retirarse una cantidad mayor de cilindros', 'Maestro Productos');
                if (Opcion == 1) {
                    $('#txtCapacidad').val('');
                    $('#txtVolumen').val('');
                } else {
                    $('#txtCapacidad1').val('');
                    $('#txtVolumen1').val('');
                }
                return;
                //                } else {
                //                    if (Opcion == 1)
                //                        $('#txtObservacion').focus;
                //                    else
                //                        $('#txtObservacion1').focus;
                //                }

            } else {
                if (Opcion == 1)
                    $('#txtObservacion').focus;
                else
                    $('#txtObservacion1').focus;

            }
        }
    });
}

//Función Carga la Informacion del Producto
function ValidarCantidades(idEmpresa) {

    var datos = JSON.stringify({ IdEmpresa: idEmpresa, Codigo: $("#txtCodigo").val() });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/CantidadProductosEnRampa',
        data: datos,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato < 0) {
                jAlert('La cantidad de cilindros llenos en el sector ' + Sector + ' es de ' + Tdato + ' cilindros. No puede retirarse una cantidad mayor de cilindros.');

            }
        }
    });
}


//Función para validar que las capacidades del producto sean validas
function ValidarCapacidad(idEmpresa, Opcion) {

    var IdArticulo = $("#hdIdArticulo").val();
    var strCapacidad = "";
    var strCodigoProducto = "";

    if (Opcion == 1) {
        strCapacidad = $("#txtCapacidad").val();
        strCodigoProducto = $("#txtCodigo").val();
    }
    else {
        strCapacidad = $("#txtCapacidad1").val();
        strCodigoProducto = $("#txtCodigo1").val();
    }

    //strCapacidad = strCapacidad.replace(".", ",");

    var datos = JSON.stringify({ IdEmpresa: idEmpresa, IdArticulo: $("#hdIdArticulo").val(), Capacidad: strCapacidad, ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/ValidarCapacidad',
        data: datos,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato == false) {
                jAlert('El producto ' + strCodigoProducto + ' no admite una capacidad de ' + strCapacidad, 'Control de Capacidades');


                if (Opcion == 1) {
                    $("#txtCapacidad").val('');
                    $("#txtVolumen").val('');

                } else {
                    $("#txtCapacidad1").val('');
                    $("#txtVolumen1").val('');
                }
            } else {

                if (Opcion == 1) {
                    CalcularVolumen(Opcion);
                }
                else {
                    CalcularVolumen(Opcion);
                }
            }
        }
    });
}

//Función para verificar que un gas es stockeable
function EsGasStockeable(idEmpresa, Opcion) {

    var strCodigoProducto = "";

    if (Opcion == 1)
        strCodigoProducto = $("#txtCodigo").val();
    if (Opcion == 2)
        strCodigoProducto = $("#txtCodigo1").val();


    var datos = JSON.stringify({ IdEmpresa: idEmpresa, CodigoProducto: strCodigoProducto, ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/GasStockeable',
        data: datos,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato == false) {
                BuscarFactorVta(idEmpresa, Opcion);
                if (Opcion == 1)
                    $('#txtCapacidad').attr('readonly', true);
                else
                    $('#txtCapacidad1').attr('readonly', true);
            } else {
                if (Opcion == 1)
                    $('#txtCapacidad').attr('readonly', false);
                else
                    $('#txtCapacidad1').attr('readonly', false);
            }
        }
    });
}

//Función que determina si una Ruta es Rampa
function EsRutaRampa(idEmpresa) {

    var datos = JSON.stringify({ IdEmpresa: idEmpresa, CodigoRuta: $("#txtRuta").val(), Agencia: jQuery.trim($('#lblAgencia1').text()), ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/EsRutaRampa',
        data: datos,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato == true) {
                jAlert('La ruta de transferencia no puede ser una ruta de rampa.', 'Control de Capacidades');
                $("#txtRuta").val('');
                $('#txtRuta').focus();
            } else {
                RutaTieneAlmacen(idEmpresa);
            }
        }
    });
}

//Función que determina la placa del vehiculo existe
function EsVehiculoValido(idEmpresa) {

    var datos = JSON.stringify({ IdEmpresa: idEmpresa, PlacaVehiculo: $("#txtVehiculo").val(), ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/EsVehiculoValidoGuiaCamion',
        data: datos,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato == false) {
                jAlert('Vehiculo no existe', 'Validación De Datos');
                $("#txtVehiculo").val('');
            } else {

                EstaEnTransitoCamion(idEmpresa);
            }
        }
    });
}


//Función que determina si el camion esta apto para salir y no se encuentra en transito
function EstaEnTransitoCamion(idEmpresa) {

    var datos = JSON.stringify({ IdEmpresa: idEmpresa, PlacaVehiculo: $("#txtVehiculo").val(), ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/EstaEnTransitoCamion',
        data: datos,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato == true) {
                jAlert('El vehiculo se encuentra en transito, debe realizar la rendicion.', 'Validación De Datos');
                $("#txtVehiculo").val('');
            }
        }
    });
}

//Función que determina si una Ruta es Rampa
function ValidarSiHayInventarioAbierto(idEmpresa) {

    var datos = JSON.stringify({ IdEmpresa: idEmpresa, Agencia: jQuery.trim($('#lblAgencia1').text()), ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/ValidarSiHayInventarioAbierto',
        data: datos,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato == true) {
                jAlert('Hay un inventario abierto. No se puede generar ningún movimiento de Entrada / Salida hasta que el inventario esté cerrado.', '');
                $("#Principal").unmask();
            } else {

                // AQUI HACER VALIDACION CUANDO VENGAN AUTOMATICOS
                ValidarCargueOBC(idEmpresa);
                //GuardarTablaTemporaldeStock();


                // no por ahora  ProcesarTransferencia(idEmpresa);
            }
        }
    });
}


//Función que valida los productos que vengan por cargue OBC
function ValidarCargueOBC(idEmpresa) {

    var datos = JSON.stringify({ IdEmpresa: idEmpresa, Usuario: jQuery.trim($('#lblNombreUsuario').text()), Agencia: jQuery.trim($('#lblAgencia1').text()), ConectarA: jQuery.trim($('#lblBd').text()), SubDep: jQuery.trim($('#lblSubdeposito').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/ValidarCargueOBC',
        data: datos,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato.MensajeError != "0") {
                jAlert(Tdato.MensajeError, 'Validación de datos');
                $("#Principal").unmask();
            } else {

                ProcesarTransferencia(idEmpresa);
              // llamar al procesar
            }
        }
    });
}

//Función que determina si un producto tiene lista de precios segun cliente
function ValidarSiTieneListaPrecios(idEmpresa, cliente, producto, espropio) {

    var datos = JSON.stringify({ IdEmpresa: idEmpresa, Cliente: cliente, Producto: producto, ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/ValidarSiTieneListaPrecios',
        data: datos,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato == false) {
                jAlert('El producto: ' + producto + ' no tiene lista de precios configurada para el cliente', 'Validación');
                if (espropio == 1) {
                    $('#txtCodigo').val('');
                } else {
                    $('#txtCodigo1').val('');
                }
            } else {
                ValidarSiTieneCod_Facturacion(idEmpresa, producto, espropio);
            }
        }
    });
}


//Función que determina si un producto tiene codigo de facturacion correspondiente
function ValidarSiTieneCod_Facturacion(idEmpresa, producto, espropio) {

    var datos = JSON.stringify({ IdEmpresa: idEmpresa, Producto: producto, ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/ValidarSiTieneCod_Facturacion',
        data: datos,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato == false) {
                jAlert('El producto: ' + producto + ' no tiene configurado el código de facturación', 'Validación');
                if (espropio == 1) {
                    $('#txtCodigo').val('');
                } else {
                    $('#txtCodigo1').val('');
                }
            } else {
                AmacenarDetalleTablaTemporal(espropio); 
            }
        }
    });
}

//Función que determina si una Ruta es Rampa
function RutaTieneAlmacen(idEmpresa) {

    var datos = JSON.stringify({ IdEmpresa: idEmpresa, CodigoRuta: $("#txtRuta").val(), Agencia: jQuery.trim($('#lblAgencia1').text()), ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/RutaTieneAlmacen',
        data: datos,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato.length == 0) {
                jAlert('La ruta no tiene un almacen asignado. Debera asiganarle un almacen, o seleccionar otra ruta', 'Control de Rutas');
                $("#txtRuta").val('');
            } else {

                if (Tdato[0].Sector != "T") {
                    jAlert('El sector de la ruta seleccionada no es de Transferencia', 'Control de Rutas');
                    $("#txtRuta").val('');
                } else
                    $("#hdSubdepositoDestino").val(Tdato[0].Subdeposito);
            }

        }
    });
}

//Función que determina si una Ruta es Rampa
function RutaCamionTieneAlmacen(idEmpresa) {

    var datos = JSON.stringify({ IdEmpresa: jQuery.trim($('#cmbEmpresaDestino').val()), CodigoRuta: $("#txtRutaSalida").val(), Agencia: jQuery.trim($('#CmbSucursalDestino').val()), ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/RutaTieneAlmacen',
        data: datos,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato.length == 0) {
                jAlert('La ruta de camión salida no tiene un almacen asignado. Debera asiganarle un almacen, o seleccionar otra ruta en la empresa Destino', 'Control de Rutas');
                $("#txtRutaSalida").val('');
            } else {

                //                if (Tdato[0].Sector != "T") {
                //                    jAlert('El sector de la ruta seleccionada no es de Transferencia', 'Control de Rutas');
                //                    $("#txtRuta").val('');
                //                } else
                $("#hdSubdepositoCamionGuia").val(Tdato[0].Subdeposito);
                ValidarPapeleriaRuta(idEmpresa);
            }

        }
    });
}


//Función que consulta el punto de venta y la papeleria de la ruta
function ValidarPapeleriaRuta(idEmpresa) {

    var datos = JSON.stringify({ IdEmpresa: jQuery.trim($('#cmbEmpresaDestino').val()), CodigoRuta: $("#txtRutaSalida").val(), Agencia: jQuery.trim($('#CmbSucursalDestino').val()), ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/ValidarPapeleriaRuta',
        data: datos,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato.length > 0) {

                if (Tdato[0].TienePapeleria != true) {
                    jAlert('La ruta no tiene configurado la papeleria manual en la empresa de destino', 'Control de Rutas');
                    $("#txtRutaSalida").val('');
                    return;
                }
                if (Tdato[0].PuntoVenta == "") {
                    jAlert('La ruta no tiene un punto de venta asignado en  la empresa de destino', 'Control de Rutas');
                    $("#txtRutaSalida").val('');
                    return;
                }

                $("#hdPuntoDeVentaCamionGuia").val(Tdato[0].PuntoVenta);
                // aqui siguiente validacion

            } else {

                jAlert('La ruta no tiene configurado la papeleria manual en la empresa de destino', 'Control de Rutas');
                $("#txtRutaSalida").val('');
            }

        }
    });
}

//Función que determina si una Ruta es Rampa
function FacturaGenerada(idEmpresa) {

    var datos = JSON.stringify({ IdEmpresa: idEmpresa, comprobante: $("#txtNumeroDocumento").val(), Agencia: jQuery.trim($('#lblAgencia1').text()), ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/FacturaGenerada',
        data: datos,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato != "") {
                $("#lblFacturaGenerada").text("Se ha Generado la Factura No : ");
                $("#LblNumeroFacturaGenerada").text(Tdato);

                VerReporteFactura(Tdato);
            } else {

            }
        }
    });
}

//Función que determina si una Ruta es Rampa
function GuiaCamionGenerada(idEmpresa) {

    var datos = JSON.stringify({ IdEmpresa: idEmpresa, comprobante: $("#txtNumeroDocumento").val(), Agencia: jQuery.trim($('#lblAgencia1').text()), ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/GuiaCamionGenerada',
        data: datos,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato != "") {
                $("#lblGuiaCamionGenerada").text("RC No : ");
                $("#lblNumeroGuiaCamionGenerada").text(Tdato);

                VerReporteGuiaCamion(Tdato);
            } else {

            }
        }
    });
}

//Función   que consulta el nombre del conductor
function DatosConductor(idEmpresa) {

    var datos = JSON.stringify({ IdEmpresa: idEmpresa, CodigoConductor: $("#txtCodigoConductor").val(), ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/DatosConductor',
        data: datos,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato.length == 0) {
                jAlert('Conductor No existe o está Inactivo', 'Validación Datos');
                $("#txtCodigoConductor").val('');
            } else {
                $("#lblNombreConductor").text(Tdato[0].NombreConductor);
            }
        }
    });
}

//Función   que consulta ARTICULOS por nombre
function ConsultarArticuloPorNombre(id) {


    var params = new Object();
    params.CodigoProducto = id;
    params.IdEmpresa = jQuery.trim($('#lblIdEmpresa').text());
    params.ConectarA = jQuery.trim($('#lblBd').text());

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "GuiaSalidaZonaFranca.aspx/ConsultarArticuloPorNombre",
        data: JSON.stringify(params),
        dataType: "json",
        async: false,
        success: function (data, textStatus) {

            if (textStatus == "success") {
                $("#list").clearGridData(); // LIMPIAR GRILLA

                var grid = $("#list")[0];
                grid.addJSONData(jQuery.parseJSON(data.d));
                mydata = data;
            }

        },
        error: function (request, status, error) {
            alert(jQuery.parseJSON(request.responseText).Message);
        }
    });

}

//Función   que consulta Conductores por Nombre
function ConsultarConductorPorNombre(Nombre) {


    var params = new Object();
    params.Nombre = Nombre;
    params.IdEmpresa = jQuery.trim($('#lblIdEmpresa').text());
    params.ConectarA = jQuery.trim($('#lblBd').text());

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "GuiaSalidaZonaFranca.aspx/ConsultarConductorPorNombre",
        data: JSON.stringify(params),
        dataType: "json",
        async: false,
        success: function (data, textStatus) {

            if (textStatus == "success") {
                $("#listConductores").clearGridData(); // LIMPIAR GRILLA

                var grid = $("#listConductores")[0];
                grid.addJSONData(jQuery.parseJSON(data.d));
                mydata = data;
            }

        },
        error: function (request, status, error) {
            alert(jQuery.parseJSON(request.responseText).Message);
        }
    });

}


//Función   que consulta ARTICULOS por Código
function ConsultarArticuloPorCodigo(id) {


    var params = new Object();
    params.CodigoProducto = id;
    params.IdEmpresa = jQuery.trim($('#lblIdEmpresa').text());
    params.ConectarA = jQuery.trim($('#lblBd').text());
    

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "GuiaSalidaZonaFranca.aspx/ConsultarArticuloPorCodigo",
        data: JSON.stringify(params),
        dataType: "json",
        async: false,
        success: function (data, textStatus) {

            if (textStatus == "success") {
                $("#list").clearGridData(); // LIMPIAR GRILLA
                var grid = $("#list")[0];
                grid.addJSONData(jQuery.parseJSON(data.d));
                mydata = data;
            }

        },
        error: function (request, status, error) {
            alert(jQuery.parseJSON(request.responseText).Message);
        }
    });

}


function CalcularVolumen(Opcion) {

    var Cantidad = 1;
    var Capacidad = "";
    if (Opcion == 1) {
        Cantidad = $('#txtCantidad').val();
        Capacidad = $('#txtCapacidad').val();
    } else {

        Capacidad = $('#txtCapacidad1').val();
    }

    var Volumen = Cantidad * Capacidad;
    if (Opcion == 1)
        $('#txtVolumen').val(Volumen);
    else
        $('#txtVolumen1').val(Volumen);

    var EsCtaCorriente = $('#hdEsProductoCuentaCorriente').val();


};

function AmacenarDetalleTablaTemporal(opcion) {
    var registro = new Object();

    if (opcion == 1) {
        registro.Codigo = jQuery.trim($('#txtCodigo').val());
        registro.Capacidad = jQuery.trim($('#txtCapacidad').val());
        registro.EntranSalen = jQuery.trim($('#txtCantidad').val());
        if (jQuery.trim($('#txtVolumen').val()) != 0) {
            registro.Cantidad = registro.Capacidad * registro.EntranSalen;
        } else {
            registro.Cantidad = 0;
        }
        registro.Secuencia = 0;

    } else {
        registro.Codigo = jQuery.trim($('#txtCodigo1').val());
        registro.Capacidad = jQuery.trim($('#txtCapacidad1').val());
        registro.EntranSalen = 1;
        if (jQuery.trim($('#txtVolumen1').val()) != 0) {
            registro.Cantidad = registro.Capacidad * registro.EntranSalen;
        } else {
            registro.Cantidad = 0;
        }
        registro.Secuencia = jQuery.trim($('#txtSecuencia').val());

    }

    AmacenarDetalleTablaTemporalAgenos(opcion);
    //    var data = JSON.stringify({ registro: registro });
    //    $.ajax({
    //        url: 'DocumentoTransferencia.aspx/GrabarDetalleTemporal',
    //        data: data,
    //        success: function (response) {
    //            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
    //            if (Tdato.IdError == '02') {
    //                jAlert('error al Ingresar en Grilla');
    //            } else {
    //                if (opcion == 1) {
    //                    AmacenarDetalleTablaTemporalAgenos(opcion);
    //                } else {
    //                    AmacenarDetalleTablaTemporalAgenos(opcion);
    //                }
    //            }
    //        }
    //    })

};

function AmacenarDetalleTablaTemporal_Totalizado(codigo, capacidad, cantidad, volumen, secuencia, opcion) {
    var registro = new Object();


    registro.Codigo = codigo;
    registro.Capacidad = capacidad;
    registro.EntranSalen = cantidad;
    registro.Cantidad = volumen;
    registro.Secuencia = secuencia;



    var data = JSON.stringify({ registro: registro });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/GrabarDetalleTemporal',
        data: data,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato.IdError == '02') {
                jAlert('error al Ingresar en Grilla');
            } else {
                if (opcion == 1) {
                    AmacenarDetalleTablaTemporalAgenos(opcion);
                } else {
                    AmacenarDetalleTablaTemporalAgenos(opcion);
                }
            }
        }
    })

};



function AmacenarDetalleTablaTemporalAgenos(Opcion) {
    var registro = new Object();


    if (Opcion == 1) {
        registro.Codigo = jQuery.trim($('#txtCodigo').val());
        registro.Capacidad = jQuery.trim($('#txtCapacidad').val());

        registro.EntranSalen = jQuery.trim($('#txtCantidad').val());

        if (jQuery.trim($('#txtVolumen').val()) != 0) {
            registro.Cantidad = registro.Capacidad * registro.EntranSalen; //  jQuery.trim($('#txtVolumen').val());
        } else {
            registro.Cantidad = 0;
        }
        registro.Tubo = 'N/A';
        registro.PropietarioTubo = 'N/A';
        registro.EsPropio = 1;
    } else {
        registro.Codigo = jQuery.trim($('#txtCodigo1').val());
        registro.Capacidad = jQuery.trim($('#txtCapacidad1').val());
        registro.EntranSalen = 1;
        if (jQuery.trim($('#txtVolumen1').val()) != 0) {
            registro.Cantidad = registro.Capacidad * registro.EntranSalen; //  jQuery.trim($('#txtVolumen1').val());
        } else {
            registro.Cantidad = 0;
        }
        registro.Tubo = jQuery.trim($('#txtCodigoTubo').val());
        registro.PropietarioTubo = jQuery.trim($('#hdnIdClienteTubo').val());
        registro.EsPropio = 0;
        registro.Secuencia = jQuery.trim($('#txtSecuencia').val());
    }


    var data = JSON.stringify({ registro: registro, ModoCargue: 'M', Usuario: jQuery.trim($('#lblNombreUsuario').text()), IdEmpresa: $('#hdIdEmpresa').val(), ConectarA: jQuery.trim($('#lblBd').text()),Doc:'G' });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/GrabarDetalleTemporalAgenos',
        data: data,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato.IdError == '02') {
                jAlert('error al Ingresar en Grilla');
            } else {

                if (Opcion == 1) {
                    CargarProductosGrilla();
                    LimpiarControles();
                } else {
                    CargarProductosParticularesGrilla();
                    LimpiarControlesParticulares();
                }
            }
        }
    })

};




function AmacenarDetalleTablaTemporal_Aut(opcion, Codigo, Capacidad, Cantidad, Volumen, secuencia) {
    var registro = new Object();


    registro.Codigo = Codigo;
    registro.Capacidad = Capacidad;
    registro.EntranSalen = Cantidad
    registro.Cantidad = Volumen;
    registro.Secuencia = secuencia;

    var data = JSON.stringify({ registro: registro, Usuario: jQuery.trim($('#lblNombreUsuario').text()), IdEmpresa: $('#hdIdEmpresa').val(), ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/GrabarDetalleTemporal',
        data: data,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato.IdError == '02') {
                jAlert('error al Ingresar en Grilla');
            } else {
                if (opcion == 1) {
                    AmacenarDetalleTablaTemporalAgenos(opcion);
                } else {
                    AmacenarDetalleTablaTemporalAgenos(opcion);
                }
            }
        }
    })

};

function AlmacenarDetalleTablaTemporalAgenos_Aut(Opcion, Codigo, Capacidad, Cantidad, Volumen, Propietario, Tubo) {
    var registro = new Object();


    if (Opcion == 1) {
        registro.Codigo = Codigo;
        registro.Capacidad = Capacidad;

        registro.EntranSalen = Cantidad;


        registro.Cantidad = Volumen; //  jQuery.trim($('#txtVolumen').val());

        registro.Tubo = 'N/A';
        registro.PropietarioTubo = 'N/A';
        registro.EsPropio = 1;
    } else {
        registro.Codigo = Codigo
        registro.Capacidad = Capacidad
        registro.EntranSalen = 1;
        registro.Cantidad = Volumen;
        registro.Tubo = Tubo;
        registro.PropietarioTubo = Propietario; //.trim($('#hdnIdClienteTubo').val());
        registro.EsPropio = 0;
        registro.Secuencia = 0;
    }


    var data = JSON.stringify({ registro: registro, ModoCargue: 'A', Usuario: jQuery.trim($('#lblNombreUsuario').text()), IdEmpresa: $('#hdIdEmpresa').val(), ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/GrabarDetalleTemporalAgenos',
        data: data,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato.IdError == '02') {
                jAlert('error al Ingresar en Grilla');
            } else {

                if (Opcion == 1) {
                    //CargarProductosGrilla();
                    LimpiarControles();
                } else {
                    // CargarProductosParticularesGrilla();
                    LimpiarControlesParticulares();
                }
            }
        }
    })

};

function ProcesarTransferencia(idEmpresa) {



    if (jQuery.trim($('#cmbEmpresaDestino').val()) == idEmpresa) {
        jAlert('No se puede realizar una transferencia a la misma empresa', 'Validación Datos');
        $("#Principal").unmask();
        return;
    }



    if (jQuery.trim($('#cmbEmpresaDestino').val()) == '1') {
        jAlert('Se requiere seleccionar Empresa Destino', 'Validación Datos');
        $("#Principal").unmask();
        return;
    }

    if (jQuery.trim($('#CmbSucursalDestino').val()) == '-1') {
        jAlert('Se requiere seleccionar Sucursal de Destino', 'Validación Datos');
        $("#Principal").unmask();
        return;
    }

    if (jQuery.trim($('#txtNumeroDocumento').val()) == '0') {
        jAlert('Número Documento Invalido', 'Validación Datos');
        $("#Principal").unmask();
        return;
    }

    if (jQuery.trim($('#txtRuta').val()) == '') {
        jAlert('Se requiere digitar una ruta', 'Validación Datos');
        $("#Principal").unmask();
        return;
    }

    if (jQuery.trim($('#txtCodigoConductor').val()) == '') {
        jAlert('Se requiere código de conductor', 'Validación Datos');
        $("#Principal").unmask();
        return;
    }

    if (jQuery.trim($('#txtRuta').val()) == '') {
        jAlert('Se requiere digitar una ruta', 'Validación Datos');
        $("#Principal").unmask();
        return;
    }

    if (jQuery.trim($('#txtVehiculo').val()) == '') {
        jAlert('Se requiere un Vehiculo', 'Validación Datos');
        $("#Principal").unmask();
        return;
    }

    if ((ItemsProductos.Productos.length == 0) && (ItemsProductosParticulares.ProductosParticulares == 0)) {

        jAlert('No ha Ingresado Productos para transferir', 'Validación Datos');
        $("#Principal").unmask();
        return;
    }


    //    //PRUEBA PARA INGRESAR EN TABLA TEMPORAL

    //    for (var i = 0; i < ItemsProductos.Productos.length; i++) {
    //        AmacenarDetalleTablaTemporal_Totalizado(ItemsProductos.Productos[i].Codigo,ItemsProductos.Productos[i].Capacidad,ItemsProductos.Productos[i].Cantidad,ItemsProductos.Productos[i].Volumen,0,1) 
    //    }

    //    for (var i = 0; i < ItemsProductosParticulares.ProductosParticulares.length; i++) {
    //        AmacenarDetalleTablaTemporal_Totalizado(ItemsProductosParticulares.ProductosParticulares[i].Codigo, ItemsProductosParticulares.ProductosParticulares[i].Capacidad, ItemsProductosParticulares.ProductosParticulares[i].Cantidad, ItemsProductosParticulares.ProductosParticulares.Volumen, ItemsProductosParticulares.ProductosParticulares.Secuencia, 1) 
    //    }





    //-------------------FIN DE PRUEBA PARA INGRESAR EN TABLA TEMPORAL
    var registro = new Object();

    //aqui proceso de encadenar los productos con seriales


    registro.EmpresaId = jQuery.trim($('#lblIdEmpresa').text()); // $('#cmbEmpresaOrigen').val();
    registro.EmpresaIdDestino = jQuery.trim($('#cmbEmpresaDestino').val());
    registro.IdGrupo = 1;
    registro.SubdepositoDestino = jQuery.trim($('#hdSubdepositoDestino').val());
    registro.SubdepositoOrigen = jQuery.trim($('#hdSubdepositoSucursal').val()); //; // por Logueo
    //registro.OficinaDestino = 1; No Aplica
    //registro.OficinaOrigen = 2;
    registro.CodigoRuta = jQuery.trim($('#txtRuta').val());
    registro.Usuario = "LSUAREZ"; // Por Logueo
    registro.AgenciaOrigen = jQuery.trim($('#hdIdSucursal').val()); // "00001"; // Por Logueo
    registro.NumeroComprobante = jQuery.trim($('#txtNumeroDocumento').val());
    registro.AgenciaDestino = jQuery.trim($('#CmbSucursalDestino').val());
    registro.Conductor = jQuery.trim($('#txtCodigoConductor').val());
    registro.Vehiculo = jQuery.trim($('#txtVehiculo').val());
    registro.Prefijo = jQuery.trim($('#txtTalonario').val());
    // registro.FechaComprobante = GenerarFechaJsonFecha(jQuery.trim($('#txtFecha').val()));
    registro.FechaComprobante = jQuery.trim($('#txtFecha').val());
    registro.ObservacionSerial = ArmarCadenaProductoSeriales();
    registro.GuiaSalida = jQuery.trim($('#txtRutaSalida').val()); 

    var data = JSON.stringify({ registro: registro, Usuario: jQuery.trim($('#lblNombreUsuario').text()), IdEmpresa: idEmpresa, Agencia: jQuery.trim($('#lblAgencia1').text()), ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/ProcesarTransaferencia',
        data: data,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato.IdError == "01") {
                jQuery.trim($('#txtNumeroDocumento').val(Tdato.ValorRetornado))
                $("#Principal").unmask();
                jAlert('Proceso Terminado Satisfactoriamente', 'Fin Proceso');
                $("#btnProcesar").attr('disabled', '-1');
                $("#btnNuevo").removeAttr('disabled');
                if (jQuery.trim($('#hdIdEmpresa').val()) == '25') {// solo si el proceso se realiza en Praxair(Tocancipa, se realiza proceso de facturación)
                    FacturaGenerada(idEmpresa);
                }
                VerReporteRemito(jQuery.trim($('#txtNumeroDocumento').val())); //Siempre se imprime remito
                GuiaCamionGenerada(idEmpresa);
            } else {
                $("#Principal").unmask();
                jAlert('Error al Procesar Transferencia:' + Tdato.MensajeError, 'Fin Proceso');
            }
        }

    })

};

function EliminarProductoGrillaPropia(Producto, Volumen, EsPropio, Secuencia, Tubo) {
    var registro = new Object();


    registro.Volumen = Volumen;
    registro.Codigo = Producto;
    registro.EsPropio = EsPropio;
    registro.Secuencia = Secuencia;
    registro.Tubo = Tubo;


    var data = JSON.stringify({ registro: registro, Usuario: jQuery.trim($('#lblNombreUsuario').text()), IdEmpresa: jQuery.trim($('#lblIdEmpresa').text()), ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/EliminarProductoGrillaPropia',
        data: data,
        success: function (response) {
            // jAlert('Proceso Terminado Satisfactoriamente');
        }
    })

};



//Función que determina si un cilindro esta lleno o vacio
function VerificarEsatadoLLenoVacio(idEmpresa) {

    var strtubo = jQuery.trim($('#txtCodigoTubo').val());
    var strCliente = jQuery.trim($('#hdnIdClienteTubo').val());
    var strVolumen = jQuery.trim($('#txtVolumen1').val());

    var datos = JSON.stringify({ IdEmpresa: idEmpresa, Cliente: strCliente, Tubo: strtubo, ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/VerificarEstadoLLenoVacio',
        data: datos,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            // 0 Cilindro vacio
            // 1 Cilindro LLeno
            if (Tdato == 0 && strVolumen != "0") {
                jAlert('El cilindro aún no ha pasado por el proceso de llenado');
            }
            if (Tdato == 1 && strVolumen == "0") {
                jAlert('El cilindro paso por el proceso de llenado. No puede salir vacio');
            }
        }
    });
}


//Validar si hay existencias  de producto en el stock
function ValidarCantidadStock(idEmpresa, EsPropio) {

    var Producto = 0;
    var Volumen = 0;
    var Cantidad = 0;
    var Capacidad = 0;
    var subDeposito = jQuery.trim($('#hdSubdepositoSucursal').val()); //; // por Logueo; //por logueo
    var Secuencia = 0;

    if (EsPropio == 1) {
        Producto = jQuery.trim($('#txtCodigo').val());
        Cantidad = jQuery.trim($('#txtCantidad').val());
        Capacidad = jQuery.trim($('#txtCapacidad').val());
        if (jQuery.trim($('#txtVolumen').val()) != 0) {
            Volumen = Cantidad * Capacidad;
        } else {
            Volume = 0;
        }
    }
    else {
        Producto = jQuery.trim($('#txtCodigo1').val());
        Volumen = jQuery.trim($('#txtVolumen1').val());
        Volumen = jQuery.trim($('#txtVolumen1').val());
        Secuencia = jQuery.trim($('#txtSecuencia').val());
    }

    var datos = JSON.stringify({ IdEmpresa: idEmpresa, Subdeposito: subDeposito, Producto: Producto, Usuario: jQuery.trim($('#lblNombreUsuario').text()), ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/ValidarCantidadStock',
        data: datos,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;

            if (jQuery.trim($('#txtVolumen').val()) != '0') {

                if (Volumen > Tdato) {
                    jAlert('No existe stock suficiente para este realizar salida a este producto, el stock actual es de: ' + Tdato + ' ', '');
                    return;
                }

            }

            if (idEmpresa == 25) {
                ValidarSiTieneListaPrecios(idEmpresa, "0000001", Producto, EsPropio)
            } else {
                AmacenarDetalleTablaTemporal(EsPropio);
            }

        }
    });
}



function CargarProductosGrilla() {

    AddProducto = new clsProductos();
    AddProducto.Codigo = jQuery.trim($('#txtCodigo').val());
    AddProducto.CodigoTubo = jQuery.trim($('#txtCodigoTubo').val());
    AddProducto.Descripcion = jQuery.trim($('#txtDescripcion').val());
    AddProducto.Capacidad = jQuery.trim($('#txtCapacidad').val());
    AddProducto.Cantidad = jQuery.trim($('#txtCantidad').val());
    AddProducto.Propiedad = jQuery.trim($('#txtPropiedad').val());
    AddProducto.Observacion = "M";
    var cant = jQuery.trim($('#txtCantidad').val());
    var Cap = jQuery.trim($('#txtCapacidad').val());
    if (jQuery.trim($('#txtVolumen').val()) != 0) {
        AddProducto.Volumen = AddProducto.Capacidad * AddProducto.Cantidad; //    jQuery.trim($('#txtVolumen').val());
    } else {
        AddProducto.Volumen = 0;
    }



    ItemsProductos.Productos[ItemsProductos.Productos.length] = AddProducto;

    //total de cilindros

    var CilindrosActuales = jQuery.trim($('#lblTotalCilindrosPraxair').text());
    CilindrosActuales = parseFloat(CilindrosActuales) + parseFloat(AddProducto.Cantidad);
    $("#lblTotalCilindrosPraxair").text(CilindrosActuales);
    CargarDatagrid()

};

function CargarDatagrid() {

    $("#TProductos tbody").remove();
    $('#dProductos').tmpl(ItemsProductos.Productos).appendTo('#TProductos')
}

function CargarProductosParticularesGrilla() {

    AddProducto = new clsProductos();
    AddProducto.Secuencia = jQuery.trim($('#txtSecuencia').val());
    AddProducto.CodigoTubo = jQuery.trim($('#txtCodigoTubo').val());
    AddProducto.Propietario = jQuery.trim($('#txtCliente').val());
    AddProducto.Codigo = jQuery.trim($('#txtCodigo1').val());
    AddProducto.Descripcion = jQuery.trim($('#txtDescripcion1').val());
    AddProducto.Capacidad = jQuery.trim($('#txtCapacidad1').val());
    AddProducto.Observacion = "M";// jQuery.trim($('#txtObservacion1').val());

    var cant = 1;
    var Cap = jQuery.trim($('#txtCapacidad1').val());
    if (jQuery.trim($('#txtVolumen1').val()) != 0) {
        AddProducto.Volumen = AddProducto.Capacidad * cant; //   jQuery.trim($('#txtVolumen1').val());
    } else {
        AddProducto.Volumen = 0;
    }
    ItemsProductosParticulares.ProductosParticulares[ItemsProductosParticulares.ProductosParticulares.length] = AddProducto;

    var CilindrosActuales = jQuery.trim($('#lblTotalCilindrosAjenos').text());
    CilindrosActuales = parseFloat(CilindrosActuales) + 1;
    $("#lblTotalCilindrosAjenos").text(CilindrosActuales);


    CargarDatagridParticulares();

};

function CargarDatagridParticulares() {

    $("#TproductosParticulares tbody").remove();
    $('#dProductosParticulares').tmpl(ItemsProductosParticulares.ProductosParticulares).appendTo('#TproductosParticulares')
}

function LimpiarControles() {

    $('#txtCodigo').val('');
    $('#txtDescripcion').val('');
    $('#txtCantidad').val('');
    $('#txtCapacidad').val('');
    $('#txtVolumen').val('');
    $('#txtObservacion').val('');
    $('#txtCodigo').focus();

}

function LimpiarControlesParticulares() {

    $('#txtSecuencia').val('');
    $('#txtCodigoTubo').val('');
    $('#txtCliente').val('');
    $('#txtCodigo1').val('');
    $('#txtDescripcion1').val('');
    $('#txtCapacidad1').val('');
    $('#txtVolumen1').val('');
    $('#txtObservacion1').val('');
    $('#txtSecuencia').focus();

}
function clsProductos() {

    this.Codigo = null;
    this.Descripcion = null;
    this.Capacidad = null;
    this.Cantidad = null;
    this.Propiedad = null;
    this.Observacion = null;
    this.Volumen = null;

    //propios para productos particulares
    this.CodigoTubo = null;
    this.Serial = null;
    this.Propietario = null;
    this.ModoCargue = null;

};

function clsListaProductos() {

    this.Productos = new Array()
};
ItemsProductos = new clsListaProductos();

function clsListaProductosParticulares() {

    this.ProductosParticulares = new Array()
};
ItemsProductosParticulares = new clsListaProductosParticulares();

function clsListaProductosParticularesOrdenados() {

    this.ProductosParticularesOrdenados = new Array()
};
ItemsProductosParticularesOrdenados = new clsListaProductosParticularesOrdenados();



//RRR
function Eliminar(idProducto, volumen, EsPropio) {


    if (confirm('Esta seguro de eliminar el Producto seleccionado?')) {
        Prod = new Array();
        var cantidadActual;
        for (var i = 0; i < ItemsProductos.Productos.length; i++) {
            if (ItemsProductos.Productos[i].Codigo == idProducto && ItemsProductos.Productos[i].Volumen == volumen) {
                EliminarProductoGrillaPropia(ItemsProductos.Productos[i].Codigo, ItemsProductos.Productos[i].Volumen, EsPropio, 0, 0);
                cantidadActual = ItemsProductos.Productos[i].Cantidad;
            }
            else {
                Prod[Prod.length] = ItemsProductos.Productos[i]
            }
        }

        var CilindrosActuales = jQuery.trim($('#lblTotalCilindrosPraxair').text());
        CilindrosActuales = parseFloat(CilindrosActuales) - parseFloat(cantidadActual);
        $("#lblTotalCilindrosPraxair").text(CilindrosActuales);

        ItemsProductos.Productos = Prod;
        CargarDatagrid();
        $('#txtCodigo').focus();
    }
    else {
        return false;
    }

}





function EliminarProductosParticular(idSecuencia, volumen, EsPropio) {

    if (confirm('Esta seguro de eliminar la secuencia de Tubo seleccionada?')) {
        ProdParti = new Array();
        for (var i = 0; i < ItemsProductosParticulares.ProductosParticulares.length; i++) {
            if (ItemsProductosParticulares.ProductosParticulares[i].Secuencia == idSecuencia && ItemsProductosParticulares.ProductosParticulares[i].Volumen == volumen) {
                EliminarProductoGrillaPropia(ItemsProductosParticulares.ProductosParticulares[i].Codigo, ItemsProductosParticulares.ProductosParticulares[i].Volumen, EsPropio, idSecuencia, ItemsProductosParticulares.ProductosParticulares[i].CodigoTubo);
            }
            else {
                ProdParti[ProdParti.length] = ItemsProductosParticulares.ProductosParticulares[i]
            }
        }
        ItemsProductosParticulares.ProductosParticulares = ProdParti;

        var CilindrosActuales = jQuery.trim($('#lblTotalCilindrosAjenos').text());
        CilindrosActuales = parseFloat(CilindrosActuales) - 1;
        $("#lblTotalCilindrosAjenos").text(CilindrosActuales);

        CargarDatagridParticulares();
        $('#txtSerial').focus();

    }
    else {
        return false;
    }
}




$('#txtRuta').bind("autocompleteselect", function (event, ui) {
    $('#txtRuta').val(ui.item.Codigo)
});
$(function () {
    function log(message) {
        $("<div/>").text(message).prependTo("#log");
        $("#log").attr("scrollTop", 0)
    }

    $("#txtRuta").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: 'GuiaSalidaZonaFranca.aspx/RutasPorSucursal',
                data: "{'IdEmpresa':'" + jQuery.trim($('#hdIdEmpresa').val()) + "','Codigo':'" + jQuery.trim($('#txtRuta').val()) + "','Agencia':'" + jQuery.trim($('#lblAgencia1').text()) +"','ConectarA':'" + jQuery.trim($('#lblBd').text()) + "'}",
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.Codigo,
                            value: item.Codigo,
                            Codigo: item.Codigo
                        }
                    }))
                }
            })
        },
        minLength: 2,
        select: function (event, ui) {
            log(ui.item ? "Selected: " + ui.item.label : "Nothing selected, input was " + this.value)
        },
        open: function () {
            $(this).removeClass("ui-corner-all").addClass("ui-corner-top")
        },
        close: function () {
            $(this).removeClass("ui-corner-top").addClass("ui-corner-all")
        }
    })
});


$('#txtRutaSalida').bind("autocompleteselect", function (event, ui) {


   
    $('#txtRutaSalida').val(ui.item.Codigo)
});
$(function () {
    function log(message) {
        $("<div/>").text(message).prependTo("#log");
        $("#log").attr("scrollTop", 0)
    }
    $("#txtRutaSalida").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: 'GuiaSalidaZonaFranca.aspx/RutasPorSucursal',
                data: "{'IdEmpresa':'" + jQuery.trim($('#cmbEmpresaDestino').val()) + "','Codigo':'" + jQuery.trim($('#txtRutaSalida').val()) + "','Agencia':'" + jQuery.trim($('#CmbSucursalDestino').val()) + "','ConectarA':'" + jQuery.trim($('#lblBd').text()) + "'}",
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.Codigo,
                            value: item.Codigo,
                            Codigo: item.Codigo
                        }
                    }))
                }
            })
        },
        minLength: 2,
        select: function (event, ui) {
            log(ui.item ? "Selected: " + ui.item.label : "Nothing selected, input was " + this.value)
        },
        open: function () {
            $(this).removeClass("ui-corner-all").addClass("ui-corner-top")
        },
        close: function () {
            $(this).removeClass("ui-corner-top").addClass("ui-corner-all")
        }
    })
});


function ValidarExsiteProductoGrillaPropios(Producto, Capacidad, Volumen) {
    var Exis = false
    for (var i = 0; i < ItemsProductos.Productos.length; i++) {
        if (ItemsProductos.Productos[i].Codigo == Producto) {
            if (ItemsProductos.Productos[i].Capacidad == Capacidad) {

                if (Volumen != 0) {
                    Exis = true;
                    return Exis;
                } else {
                    if (ItemsProductos.Productos[i].Volumen == Volumen) {
                        Exis = true;
                        return Exis;
                    }
                }
            }
        }

    }

    return Exis;
};

function ValidarExsiteProductoGrillaAjenos(Serial) {
    var Exis = false
    for (var i = 0; i < ItemsProductosParticulares.ProductosParticulares.length; i++) {
        if (ItemsProductosParticulares.ProductosParticulares[i].Secuencia == Serial) {
            Exis = true;
            return Exis;
        }
    }

    return Exis;
};


$('#LblBuscarProducto').click(function () {
    $("#list").clearGridData(); // LIMPIAR GRILLA
    $("#ModalBusqueda").dialog({
        height: 600,
        width: 600,
        modal: true
    });
    return false

});


$("#btnBuscarArticulo").click(function () {


    var seleccion = jQuery.trim($('#txtBuscarPor').val());

    var texto = $('#txtTextoBusqueda').val();

    if (texto == "") {
        jAlert('Seleccione un criterio de búsqueda');
        return;
    }

    if (seleccion == 1) {
        ConsultarArticuloPorNombre(texto);
    } else {
        ConsultarArticuloPorCodigo(texto);
    }

});


$("#btnBuscarConductor").click(function () {


    var seleccion = jQuery.trim($('#txtBuscarPor').val());

    var texto = $('#txtTextoBusquedaCond').val();

    if (texto == "") {
        jAlert('Seleccione un criterio de búsqueda');
        return;
    }

    if (seleccion == 1) {
        ConsultarConductorPorNombre(texto);
    }

});


function FilaSeleccionada(id, IdGrilla) {

    if (IdGrilla == 1) {// viene de grilla de articulos
        var ArtSeleccionado = jQuery('#list').getCell(id, "Codigo");


        $("#ModalBusqueda").dialog("destroy")
        $('#txtCodigo').val(ArtSeleccionado);
        $('#txtCodigo').focus();
    }
    if (IdGrilla == 2) {// viene de grilla de Conductores
        var CondSeleccionado = jQuery('#listConductores').getCell(id, "CodigoConductor");


        $("#ModalBusquedaConductores").dialog("destroy")
        $('#txtCodigoConductor').val(CondSeleccionado);
        $('#txtCodigoConductor').focus();
    }
};


function MostrarReporte() {
    $("#ModalBusqueda").dialog({
        height: 600,
        width: 600,
        modal: true
    });
    return false

}

function VerReporteFactura(comprobante) {


    var url = "PaginasReportes/Factura.aspx?C=" + comprobante + "&R=" + jQuery.trim($('#txtRuta').val());
    window.open(url, '_blank');
    return false;

}

function VerReporteFacturaPreliminar(Usuario) {


    var url = "PaginasReportes/FacturaPreliminar.aspx?C=" + Usuario + "&R=" + jQuery.trim($('#txtRuta').val() + "&T=" + jQuery.trim($('#txtVehiculo').val() + "&Num=" + jQuery.trim($('#txtNumeroDocumento').val())));
    window.open(url, '_blank');
    return false;

}

function VerReporteRemito(comprobante) {
    var url = "PaginasReportes/Remito.aspx?C=" + comprobante + "&SUB=" + jQuery.trim($('#hdSubdepositoSucursal').val() + "&S=" + jQuery.trim($('#txtTalonario').val()));
    window.open(url, '_blank');
    return false;

}

function VerReporteGuiaCamion(comprobante) {
    var url = "PaginasReportes/RemitoCamion.aspx?C=" + comprobante + "&C1=" + jQuery.trim($('#LblNumeroFacturaGenerada').val() + "&SUB=" + jQuery.trim($('#txtSucursalOrigen').val() + "&S=" + jQuery.trim($('#txtVehiculo').val())));
    window.open(url, '_blank');
    return false;

}

function ArmarCadenaProductoSeriales() {
    var Exis = false
    var CodigoTmp = "";
    var Cadena = "";
    var secuencia = "";

    //ItemsProductosParticularesOrdenados.ProductosParticularesOrdenados = ItemsProductosParticulares.ProductosParticulares.sort();
    ItemsProductosParticularesOrdenados.ProductosParticularesOrdenados = ItemsProductosParticulares.ProductosParticulares.sort(function (a, b) { return a.Codigo - b.Codigo });



    for (var i = 0; i < ItemsProductosParticulares.ProductosParticulares.length; i++) {

        if (ItemsProductosParticularesOrdenados.ProductosParticularesOrdenados[i].Descripcion != CodigoTmp) {

            if (i == 0) {
                Cadena = Cadena + " " + ItemsProductosParticularesOrdenados.ProductosParticularesOrdenados[i].Codigo + " " + ItemsProductosParticularesOrdenados.ProductosParticularesOrdenados[i].Descripcion + " : " + ItemsProductosParticularesOrdenados.ProductosParticularesOrdenados[i].CodigoTubo
            } else {
                Cadena = " " + Cadena + "&" + ItemsProductosParticularesOrdenados.ProductosParticularesOrdenados[i].Codigo + " " + ItemsProductosParticularesOrdenados.ProductosParticularesOrdenados[i].Descripcion + " : " + ItemsProductosParticularesOrdenados.ProductosParticularesOrdenados[i].CodigoTubo
            }

        } else {

            Cadena = Cadena + "," + ItemsProductosParticularesOrdenados.ProductosParticularesOrdenados[i].CodigoTubo;
        }

        CodigoTmp = ItemsProductosParticularesOrdenados.ProductosParticularesOrdenados[i].Descripcion


    }

    return Cadena;
};


function EliminarTablaTemporalInicial(idEmpresa) {

    var data = JSON.stringify({ TempIdEmpresa: jQuery.trim($('#hdIdEmpresa').val()), Usuario: jQuery.trim($('#lblNombreUsuario').text()), ConectarA: jQuery.trim($('#lblBd').text()),Doc:'G' });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/EliminaDetalleTemporalInicial',
        data: data,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            //            if (Tdato.IdError == '02') {
            //                jAlert('error al Ingresar en Grilla');
            //            } else {
            //                if (opcion == 1) {
            //                    AmacenarDetalleTablaTemporalAgenos(opcion);
            //                } else {
            //                    AmacenarDetalleTablaTemporalAgenos(opcion);
            //                }
            //            }
        }
    })

};


function GuardarTablaTemporaldeStock() {
    var Exis = false
    for (var i = 0; i < ItemsProductos.Productos.length; i++) {

        /*this.Codigo = null;
        this.Descripcion = null;
        this.Capacidad = null;
        this.Cantidad = null;
        this.Propiedad = null;
        this.Observacion = null;
        this.Volumen = null;

        //propios para productos particulares
        this.CodigoTubo = null;
        this.Serial = null;
        this.Propietario = null;*/

        AlmacenarDetalleTablaTemporalAgenos_Aut(1, ItemsProductos.Productos.Codigo, ItemsProductos.Productos.Capacidad, ItemsProductos.Productos.Cantidad, ItemsProductos.Productos.Volumen, '', '') 


    }
};


$('#btntest').click(function () {
    jAlert('Ok');
   
});


$('#txtRutaSalida').focusout(function () {


    if (jQuery.trim($('#txtRutaSalida').val()) != "") {

        RutaTieneCamion(jQuery.trim($('#cmbEmpresaDestino').val()), jQuery.trim($('#txtRutaSalida').val()), jQuery.trim($('#CmbSucursalDestino').val()));

    }
});

//Función que determina si una ruta ya tiene remito camion en la empresa de destino
function RutaTieneCamion(idEmpresa,Ruta,Agencia) {

    var datos = JSON.stringify({ IdEmpresa: idEmpresa, CodigoRuta: Ruta, Agencia: Agencia,ConectarA: jQuery.trim($('#lblBd').text()) });
    $.ajax({
        url: 'GuiaSalidaZonaFranca.aspx/EsRemitoCamion',
        data: datos,
        success: function (response) {
            var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
            if (Tdato == true) {
                jAlert('Esta Ruta ya tiene remito Camión en la empresa de destino', 'Control de Rutas');
                $("#txtRutaSalida").val('');
                //$('#txtRutaSalida').focus();
            } else {
                RutaCamionTieneAlmacen(idEmpresa);
            }
        }
    });
}