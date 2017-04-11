var header;
$(function() {
    // Go to top
    $('.up').on('click', function(e) {
        e.preventDefault();
        $('html, body').animate({
            scrollTop: 0
        }, 1000);
    });
    // Cache dom
    header = $(".navbar-header");

    // Typeahead
    $('.typeahead').typeahead({
        source: ["item1", "item2", "item3"]
    });

    // Clearable input search
    function tog(v) {
        return v ? 'addClass' : 'removeClass';
    }
    $(document).on('input', '.clearable', function() {
        $(this)[tog(this.value)]('x');
    }).on('mousemove', '.x', function(e) {
        $(this)[tog(this.offsetWidth - 25 < e.clientX - this.getBoundingClientRect().left)]('onX');
    }).on('click', '.onX', function() {
        $(this).removeClass('x onX').val('').change();
    });

    // Open/close sidebar menu helpers
    $('.nav-sidebar').on('show.bs.collapse', function(e) {
        $(e.target).prev().addClass('active');
    });
    $('.nav-sidebar').on('hide.bs.collapse', function(e) {
        $(e.target).prev().removeClass('active');
    });

    // Newsletter form HOME
    $('.newsletter-home-form').on('submit', function (e) {
        e.preventDefault();
        $('.confirmNewsletter').modal();
        $('.confirm').parent().show();
        $('.feedback-text').hide();
        $('#emailNewsConfirm').val($('#emailNewsHome').val())
        return false;
    });

    // Newsletter form
    $('.newsletter-form').on('submit', function(e) {
        e.preventDefault();
        $('.confirmNewsletter').modal();
        $('.confirm').parent().show();
        $('.feedback-text').hide();
        $('#emailNewsConfirm').val($('#emailNews').val())
        return false;
    });

// Contacto form
    $('.confirmNewsletter').on('submit', function (e) {
        e.preventDefault();
        $('.confirmNewsletter .error-text').addClass('hide');

        if (validacionNewsConfirm() === true) {
            var data = JSON.stringify({
                email: $('#emailNewsConfirm').val()
            });

            $.ajax({
                type: 'POST',
                url: '/Home/Newsletter',
                data: data,
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            })
            .done(function (msg) {
                if (msg == 0) {
                    $('.confirm').parent().hide();
                    $('.feedback-text').show();

                    $('#emailNews').val('');
                    $('#emailNewsHome').val('');
                    $('.newsletter-form-confirm').find('[name=privacidadNews]').prop('checked', false);
                }
            })
            .fail(function () {
                
            })
            .always(function () {
                
            });

            return false;
        }

        $('.error-text').removeClass('hide');
        return false;
    });

});


var validacionNewsConfirm = function() {
    var form = $('.newsletter-form-confirm');
    var formData = $('.newsletter-form-confirm').serializeArray();

    $('.newsletter-form-confirm .has-error').removeClass('has-error');

    if ($(form).find('[id=emailNewsConfirm]').val() == '') {
        addErrorNews('emailNewsConfirm');
    }

    if( $(form).find('[name=privacidadNews]').prop('checked') === false ) {
        addErrorNews('privacidadNews');
    }

    if($('.newsletter-form-confirm .has-error').length > 0) {
        return false;
    }

    return true;
};

var addErrorNews = function(where) {
    $('.newsletter-form-confirm').find('[name=' + where + ']').closest('.form-group').addClass('has-error');
};


// Limit execution helper
function debounce(func, wait, immediate) {
    var timeout;
    return function() {
        var context = this,
            args = arguments;
        var later = function() {
            timeout = null;
            if (!immediate) func.apply(context, args);
        };
        var callNow = immediate && !timeout;
        clearTimeout(timeout);
        timeout = setTimeout(later, wait);
        if (callNow) func.apply(context, args);
    };
};
