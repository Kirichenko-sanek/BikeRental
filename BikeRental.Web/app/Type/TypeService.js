(function (app) {


    app.factory('TypeService', TypeService);

    TypeService.$inject = ['$http', '$location', '$rootScope'];

    function TypeService($http, $location, $rootScope) {

        var service = {
            getType: getType
    }

        function getType(model) {
            $http.get($rootScope.localAddress + 'api/profile/getTypes')
                .then(
                    function (data) {
                        model.types = data.data;
                        //$location.path('/takeBike');
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

