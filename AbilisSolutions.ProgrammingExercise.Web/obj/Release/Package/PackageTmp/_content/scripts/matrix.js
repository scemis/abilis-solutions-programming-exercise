/// <reference path="enums.js" />

var matrixModule = (function () {

    // private functions
    function bindEvents() {
        $(document).off('js-init');
        $(document).on('js-init', function () {
            submitForm();
        });

        $("[name='cb-show-prime']").off('switchChange.bootstrapSwitch');
        $("[name='cb-show-prime']").on('switchChange.bootstrapSwitch', function (event, state) {
            // clean up
            $('#multiplication-table-wrapper td.prime').removeClass('prime-on');
            $('#hidShowPrimeNumbers').val(EnumBoolean.False);

            // show prime
            if (state) {
                $('#multiplication-table-wrapper td.prime').addClass('prime-on');
                $('#hidShowPrimeNumbers').val(EnumBoolean.True);
            }
        });

        $('.matrix-size-item').off('click');
        $('.matrix-size-item').on('click', function () {
            // get data
            var size = $(this).data('size');
            // update ui
            $('.matrix-size-item').removeClass('active');
            $(this).addClass('active');
            $('#matrix-size-control span.value').text(size + 'X' + size);
            // update form's model
            $('#hidMatrixSize').val(size);
            // refresh form
            submitForm();
        });

        $('.matrix-base-item').off('click');
        $('.matrix-base-item').on('click', function () {
            // get data
            var base = $(this).data('base');
            // update ui
            $('.matrix-base-item').removeClass('active');
            $(this).addClass('active');
            $('#matrix-base-control span.value').text($(this).text());
            // update form's model
            $('#hidMatrixBase').val(base);
            // refresh form
            submitForm();
        });
    }

    // submit form
    function submitForm() {
        $('#frmGetMatrixAsync').submit();
    }
        
    // puvlic functions
    function init() {
        // init bootstrap tooltip
        $('#multiplication-table-wrapper [data-toggle="tooltip"]').tooltip();

        // init bootstrap-switch
        $("[name='cb-show-prime']").bootstrapSwitch();

        // bind events
        bindEvents();
    }

    function onMatrixLoad() {
        init();

        // hide tooltips
        $('.tooltip').hide();
    }

    return {
        init: init,
        onMatrixLoad: onMatrixLoad
    };

})();

matrixModule.init();