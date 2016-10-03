(function(app) {
    app.factory('typeService', typeService);
    typeService.$inject = ['$http', '$location', '$rootScope'];

    function typeService($http, $location, $rootScope) {
        var service = {
            getType: getType
        }

        function getType(model) {
            $http.get($rootScope.localAddress + 'api/profile/getTypes')
                .then(
                    function(data) {
                        model.types = data.data;
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