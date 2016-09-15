(function (app) {
 

    app.factory('notificationService', notificationService);

    function notificationService() {

        var service = {
            displayError: displayError
        };

        return service;

        function displayError(error) {
            if (Array.isArray(error)) {
                error.forEach(function (err) {
                    window.toastr.error(err);
                });
            } else {
                window.toastr.error(error);
            }
        }
    }
})(angular.module('BikeRental'));