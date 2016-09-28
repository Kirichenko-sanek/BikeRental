(function (app) {


    app.factory('TypeService', TypeService);

    TypeService.$inject = ['$http', '$location'];

    function TypeService($http, $location) {

        var service = {
            getType: getType
    }

        function getType(model) {
            $http.get('http://localhost:64069/api/profile/getTypes')
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

