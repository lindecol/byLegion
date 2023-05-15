//$(document).ready(function () {

//    $.ajaxSetup({
//        cache: false,
//        type: "POST",
//        dataType: "json",
//        contentType: "application/json; charset=utf-8",
//        async: true,
//        beforeSend: function (objeto) {
//            $("#content").mask("Cargando...")
//        },
//        complete: function (objeto, exito) {
//            $("#content").unmask();
//            if (exito != "success") {
//                jAlert('Error al intentar cargar los datos....')
//            }

//        }
//    });
//var ListaProducto = Array();
function Setup() {
    $.ajaxSetup({
        cache: false,
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        async: true,   
        complete: function (objeto, exito) {         
            if (exito != "success") {
              
            }
        }
    });
}

Setup();


$('#btnAgregarProducto').click(function () {
    // AgregarTercero();
    CargarProductosGrilla();
});


    
    $('#LblAgregarPropietario').click(function () {
        // AgregarTercero();
        CargarProductosGrilla();
    });

//});


function CargarProductosGrilla() {
    // $.ajax({

    //            url: 'RegistroNacimiento.aspx/CargarDatosPropietario',
    //            data: "{'iNumRegistro':'" + iNumReporte + "'}",
    //            success: function (response) {
    //                var Tdato = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
    //                if (Tdato.NombreTercero == null) {
    //                    jAlert('Propietario no existe', MensajeTituloAlert);
    //                    $('#txtNombreTercero').val('');
    //                    $('#txtIdentificacionTercero').val('');
    //                    $('#cmbTercerosCriadero').empty();

    //                    return
    //                }

    AddProducto = new clsProductos();
    AddProducto.Codigo = jQuery.trim($('#txtCodigo').val());
    AddProducto.CodigoTubo = jQuery.trim($('#txtCodigoTubo').val());
    AddProducto.Descripcion = jQuery.trim($('#txtDescripcion').val());
    AddProducto.Capacidad = jQuery.trim($('#txtCapacidad').val());
    AddProducto.Cantidad = jQuery.trim($('#txtCantidad').val());
    AddProducto.Propiedad = jQuery.trim($('#txtPropiedad').val());
    AddProducto.Observacion = jQuery.trim($('#txtObservacion').val());
    // ItemsProductos.Productos[ItemsProductos.Productos.length] = AddProducto;
    //ListaProducto[ListaProducto.length] = AddProducto;
    CargarDatagrid()


    //            }
    //        })
};










function CargarDatagrid() {

    var hh = Array();
    AddProducto = new clsProductos();
    AddProducto.Codigo = jQuery.trim($('#txtCodigo').val());
    AddProducto.CodigoTubo = jQuery.trim($('#txtCodigoTubo').val());
    AddProducto.Descripcion =  jQuery.trim($('#txtDescripcion').val());
    AddProducto.Capacidad = jQuery.trim($('#txtCapacidad').val());
    AddProducto.Cantidad = jQuery.trim($('#txtCantidad').val());
    AddProducto.Propiedad = jQuery.trim($('#txtPropiedad').val());
    AddProducto.Observacion =  jQuery.trim($('#txtObservacion').val());
    AddProducto.productos = AddProducto;
    

    $("#TProductos tbody").remove();
    $('#dProductos').tmpl(AddProducto.productos).appendTo('#TProductos')
}




    function AgregarTercero() {

//        AddTercero = new clsTerceros();
//        AddTercero.idTercero = "14398652"//jQuery.trim($('#TBterceroID').val());
//        AddTercero.NombreTercero = "Roberto"//jQuery.trim($('#TBterceroNombre').val());
//        AddTercero.ApellidoTercero = "Saenz"//jQuery.trim($('#TBterceroApellido').val());
//        AddTercero.CodCriadero = "01"// jQuery.trim($('#TBterceroCodCriadero').val());
//        AddTercero.Criadero = "guamo"//jQuery.trim($('#TBterceroCriadero').val());
//        AddTercero.CodCiudadResidencia = "73001"// $('#TBterceroCiudad').val();
//        AddTercero.CiudadResidencia = "Bogota"//$('#TBterceroCiudad').val();
//        InsEjemp.Terceros[InsEjemp.Terceros.length] = AddTercero;
  
        CargarDatagrid()
    }


//    function CargarDatagrid() {

//       


//        $("#Tterceros tbody").remove();
//        $('#dTerceros').tmpl(InsEjemp.Terceros).appendTo('#Tterceros')
//    }

//    function CargarDatagrid() {

//        var hh = Array();
//        AddTercero = new clsTerceros();
//        AddTercero.idTercero = "14398652"//jQuery.trim($('#TBterceroID').val());
//        AddTercero.NombreTercero = "Roberto"//jQuery.trim($('#TBterceroNombre').val());
//        AddTercero.ApellidoTercero = "Saenz"//jQuery.trim($('#TBterceroApellido').val());
//        AddTercero.CodCriadero = "01"// jQuery.trim($('#TBterceroCodCriadero').val());
//        AddTercero.Criadero = "guamo"//jQuery.trim($('#TBterceroCriadero').val());
//        AddTercero.CodCiudadResidencia = "73001"// $('#TBterceroCiudad').val();
//        AddTercero.CiudadResidencia = "Bogota"//$('#TBterceroCiudad').val();
//        hh = AddTercero;

//        $("#Tterceros tbody").remove();
//        $('#dTerceros').tmpl(hh).appendTo('#Tterceros')
//    }



function EliminarTercero(idTercero) {
    Terceros = new Array();
    for (var i = 0; i < InsEjemp.Terceros.length; i++) {
        if (InsEjemp.Terceros[i].idTercero != idTercero) Terceros[Terceros.length] = InsEjemp.Terceros[i]
    }
    InsEjemp.Terceros = Terceros;
    CargarDatagrid()
}

function clsEjemplar() {
    this.NumeroRegistroid = null;
    this.NombreEjemplar = null;
    this.CodTipoRegistro = null;
    this.CodAsociacion = null;
    this.GradoGenotipo = null;
    this.FechaNacimiento = null;
    this.strFechaNacimiento = null;
    this.FechaAIE = null;
    this.strFechaAIE = null;
    this.CodTipoEquino = null;
    this.CodSexo = null;
    this.CodColor = null;
    this.CodTipoAndar = null;
    this.MicroChip = null;
    this.CodCriadero = null;
    this.Criadero = null;
    this.CodCriador = null;
    this.Criador = null;
    this.NumeroRegistroPadre = null;
    this.NombrePadre = null;
    this.NumeroRegistroMadre = null;
    this.NombreMadre = null;
    this.NombreAbueloMaterno = null;
    this.NombrePais = null;
    this.NombreDepartamento = null;
    this.NombreCiudad = null;
    this.idFeria = null;
    this.Terceros = new Array()
};
InsEjemp = new clsEjemplar();

function clsTerceros() {
    this.idTercero = null;
    this.NombreTercero = null;
    this.ApellidoTercero = null;
    this.CodCriadero = null;
    this.Criadero = null;
    this.CodCiudadResidencia = null;
    this.CiudadResidencia = null
};

function clsProductos() {
    this.Codigo = null;
    this.CodigoTubo = null;
    this.Descripcion = null;
    this.Capacidad = null;
    this.Cantidad = null;
    this.Propiedad = null;
    this.Observacion = null;
    this.productos = new Array();
};

function clsEjemplarPadre() {
    this.NumeroRegistroid = null;
    this.NombreEjemplar = null;
    this.CodTipoRegistro = null;
    this.CodAsociacion = null;
    this.GradoGenotipo = null;
    this.FechaNacimiento = null;
    this.strFechaNacimiento = null;
    this.FechaAIE = null;
    this.strFechaAIE = null;
    this.CodTipoEquino = null;
    this.CodSexo = null;
    this.CodColor = null;
    this.CodTipoAndar = null;
    this.MicroChip = null;
    this.CodCriadero = null;
    this.Criadero = null;
    this.CodCriador = null;
    this.Criador = null;
    this.NumeroRegistroPadre = null;
    this.NombrePadre = null;
    this.NumeroRegistroMadre = null;
    this.NombreMadre = null;
    this.NombreAbueloMaterno = null;
    this.NombrePais = null;
    this.NombreDepartamento = null;
    this.NombreCiudad = null;
    this.idFeria = null;
    this.Terceros = new Array()
};
InsEjempPadre = new clsEjemplar();
InsEjempMadre = new clsEjemplar();

