var commonModule = (function () {

    // private functions
    function bindEvents() {
        $(document).off('js-init');
        $(document).on('js-init', function () {
            // init bootstrap tooltip
            $('[data-toggle="tooltip"]').tooltip();
        });
    }

    // puvlic functions
    function init() {
        bindEvents();
    }

    return {
        init: init,
        bindEvents: bindEvents
    };

})();

commonModule.init();