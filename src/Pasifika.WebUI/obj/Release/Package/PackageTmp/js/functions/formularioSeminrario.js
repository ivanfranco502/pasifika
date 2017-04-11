$(function () {

    $('#Pais').change(function () {
        if ($(this).val() == 'es')
            $('#idProvincia').prop('disabled', false);
        else
            $('#idProvincia').prop('disabled', true);

    });

    $(".custom-select").select2({
        dropdownCssClass: 'custom-select',
        minimumResultsForSearch: -1
    });
    $(".custom-select-2").select2({
        dropdownCssClass: 'custom-select-2',
        minimumResultsForSearch: -1
    });

    // Contacto form
    $('form.contacto').on('submit', function (e) {
        $('.error-text').addClass('hide');

        if (validacion() === true) {
            //$('.feedbackFormulario').modal();
            //return false;
            return true;
        }

        $('.error-text').removeClass('hide');
        return false;
    });
});

var validacion = function () {
    var form = $('form.contacto');
    var formData = $('form.contacto').serializeArray();

    $('form.contacto .has-error').removeClass('has-error');

    if ($(form).find('[name=Nombre]').val() == '') {
        addError('Nombre');
    }
    if ($(form).find('[name=Apellido]').val() == '') {
        addError('Apellido');
    }
    if ($(form).find('[name=Email]').val() == '') {
        addError('Email');
    }

    if ((form).find('[name=Telefono]').val() == '') {
        addError('Telefono');
    }

    if ($(form).find('[name=Pais]').val() == '') {
        addError('Pais');
    }

    if ($(form).find('[name=Pais]').val() != 'otro') {
        if ($(form).find('[name=idProvincia]').val() == '') {
            addError('idProvincia');
        }
    }

    if ($(form).find('[name=Sexo]:checked').prop('checked') !== true) {
        addError('Sexo');
    }

    if ($(form).find('[name=destino]').val() == '') {
        addError('destino');
    }
    if ($(form).find('[name=tipoViaje]').val() == '') {
        addError('tipoViaje');
    }
    if ($(form).find('[name=fechaSalidaMes]').val() == '') {
        addError('fechaSalidaMes');
    }
    if ($(form).find('[name=fechaSalidaAnio]').val() == '') {
        addError('fechaSalidaAnio');
    }
    if ($(form).find('[name=presupuestoEstimado]').val() == '') {
        addError('presupuestoEstimado');
    }

    if ($(form).find('[name=Sesion]').val() == '') {
        addError('Sesion');
    }

    /*if ($(form).find('[name=news]').prop('checked') !== true) {
        addError('news');
    }*/

    if ($(form).find('[name=privacidad]').prop('checked') === false) {
        addError('privacidad');
    }

    if ($('form.contacto .has-error').length > 0) {
        return false;
    }

    return true;
};

var addError = function (where) {
    $('form.contacto').find('[name=' + where + ']').closest('.form-group').addClass('has-error');
}

$('#idProvincia').change(function () {
    $('#Provincia').val($('#idProvincia').select2('data').text);
});

$('#destino').change(function () {
    $('#destinoText').val($('#destino').select2('data').text);
});

$('#tipoViaje').change(function () {
    $('#tipoViajeText').val($('#tipoViaje').select2('data').text);
});

$('#fechaSalidaMes').change(function () {
    $('#fechaSalidaMesText').val($('#fechaSalidaMes').select2('data').text);
});