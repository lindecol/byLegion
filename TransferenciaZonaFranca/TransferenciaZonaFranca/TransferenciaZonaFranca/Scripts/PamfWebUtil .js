function LimpiaDatos() {
    LimpiarTexto('#aspnetForm');
}

/* Hace el llamado al ajaxSetup estándar */
function PamfSetup() {
	$.ajaxSetup({
	    cache: false,
	    type: "POST",
	    dataType: "json",
	    contentType: "application/json; charset=utf-8",
	    async: true,
	    beforeSend: function (objeto) {
	        $("#aspnetForm").mask("Cargando...")
	    },
	    complete: function (objeto, exito) {
	        $("#aspnetForm").unmask();
	        if (exito != "success") {
	            jAlert();
	        }
	    }
	});
}

/*	Muestra un conjunto de registros en la tabla especificada usando el template 
	El parámetro encabezados es un array con los títulos de los encabezados de cada columna.
	En caso que no existan registros, se puede mostrar un mensaje estándar indicando que no existen registros */
function MostrarRegistrosENTabla(registros, tabla, template, encabezados, mensaje, usarEstiloPopup) {
    $(tabla).empty();
    if (registros == null || registros.length < 1) {
	    $(tabla).hide();
	    if (mensaje != null) {
	    	MostrarMensajeInfo('No hay registros con estos criterios de búsqueda.', mensaje);
	    }
    } else {
        $(tabla).empty();
        $(tabla).show();
	    $(tabla).append(GenerarEncabezadoTabla(encabezados));
		$(tabla + " tbody").remove();
		$(template).tmpl(registros).appendTo(tabla);

		if (usarEstiloPopup == null || usarEstiloPopup != 'popup') {
		    MostrarEnTabla(tabla);
		}
		else {
		    MostrarEnTablaPopup(tabla);
		}
	}
}

/* Utilizado por MostrarRegistrosENTabla para generar los encabezados de la tabla a partir de una lista */
function GenerarEncabezadoTabla(encabezados) {
	var resultado = '<thead><tr>';
	for (var i in encabezados) {
        var encabezado = encabezados[i];
        var texto = '&nbsp';
        resultado += '<th';

        for(var propiedad in encabezado) {            
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

/* Abre el popup con los parámetros indicados. */
function MostrarPopup(div, ancho, titulo) {
    $(div).dialog({
        width: ancho,
        resizable: false,
        modal: true,
        title: titulo,
        open: function () {
            $(this).parent().appendTo($('#aspnetForm'));
            $("#aspnetForm").validate().resetForm();
        }
    });
}

/* Asigna el estilo de fecha al control de texto . */
function AsignarDatePicker(control) {
    $(control).datepicker({
        changeMonth: true,
        changeYear: true
    });
}

/* Convierte el texto ingresado por el usuario a formato Date de javascript. */
function ConvertStringToDate(date) {    
    var elem = date.split('/');
    var d, m, y;
    d = elem[0];
    m = elem[1];
    y = elem[2];
    var resultado = new Date(y, m - 1, d, 0, 0, 0, 0);
    return resultado;
}

/* Recorta un texto demasiado largo para presentarlo en una tabla de datos. */
function TextoLargo(texto) {
    if (texto != null && texto.length > 300) {
        return texto.substr(0, 300) + ' ...';
    }
    else {
        return texto;
    }
}

/* Indica si el texto de un combo seleccionado corresponde a una versión publicada */
function ESVersionPublicada(nombreCombo) {
    return $(nombreCombo + ' :selected').text().indexOf('(Publicada)') >= 0;
}

/* Agrega la función para validar longitud exacta */
function AgregarValidadorExactLength() {
    jQuery.validator.addMethod("exactlength", function (value, element, param) {
        return this.optional(element) || value.length == param;
    });
}

/* Agrega la función para validar el formato de fecha */
function AgregarValidadorFormatoFecha() {
    jQuery.validator.addMethod("dateFormat", function (value, element, param) {
        var fecha = ConvertStringToDate(value);
        var textoFechaConvertido = dateFormat(fecha, "dd/mm/yyyy")
        return textoFechaConvertido == value;
    });
}

function AgregarValidadorcheckForWhiteSpaceErrors() {
    jQuery.validator.addMethod("checkForWhiteSpaceErrors", function (value, element, param) {
        var elem = $(element);
        var val = element.val();
        //Now you have a choice.  Either use trim, or if you believe that 
        //  that is not working, use a regex.
        if (val && $.trim(val) == '') {
            return false;
        }
        //or 
        if (val && val.match(/^\s+|\s+$/g)) {
            return false;
        }
        return true;
    });
}
//Muestra el mensaje sin efectos
function MostrarMensajeFijo(mensaje, ControlId) {
    $(ControlId).empty();
    $(ControlId).html();
    $(ControlId).show();
    $(ControlId).append(mensaje);
}

//Configura el control de calendario con el formato dd/MM/yyyy
function ConfigurarCalendario() {
    $.datepicker.regional['es'] = ListCalendario;
    $.datepicker.setDefaults($.datepicker.regional['es']);
}

//Selecciona la opción del combo a partir de su descripción
function SeleccionarPorDescripcion(nombreSelect, descripcion) {
    var encontrado = false;
    $("select#" + nombreSelect + " option").each(function () { if (this.text == descripcion) { this.selected = true; encontrado = true; } });
    if (!encontrado) {
        $("#" + nombreSelect).val('');
    }
}

//Muestra una alerta, si no se especifica título deja PAMF
function MensajeAlerta(message, title, callback) {
    if (title == null) {
        title = 'PAMF';
    }
    jAlertInfo(message, title, callback)
}