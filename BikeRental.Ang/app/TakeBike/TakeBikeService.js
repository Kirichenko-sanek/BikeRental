(function (app) {


    app.factory('TekeService', TekeService);

    TekeService.$inject = [ '$http', '$location', '$rootScope'];

    function TekeService($http, $location, $rootScope) {

        var service = {
            takeBike: takebike
        }

        function takebike(model) {

        }



        return service;
    }
})(angular.module('BikeRental'));

