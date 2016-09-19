(function (app) {


    app.factory('TypeService', TypeService);

    TypeService.$inject = ['$http', '$location', '$rootScope'];

    function TypeService($http, $location, $rootScope) {

        var service = {
            getType: getType
    }

        function getType() {
            $http.get('api/profile/getTypes')
                .then(
                    function(data) {

                    })
                .catch(function(result) {
                    console.log('Result: ', result);
                })
                .finally(function() {
                    console.log('Finally');
                });
        }



        return service;
    }
})(angular.module('BikeRental'));

