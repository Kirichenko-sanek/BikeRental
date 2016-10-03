(function (app) {


    app.factory('EditBikeService', EditBikeService);

    EditBikeService.$inject = ['$http','$routeParams', '$location', '$rootScope', 'localStorageService'];

    function EditBikeService($http,$routeParams, $location, $rootScope, localStorageService) {

        var service = {
            getBike: getBike
        }

        function getBike(model) {
            var currentId = $routeParams.id;
            $http.get($rootScope.localAddress + 'api/admin/getBike/' + currentId)
                .then(function (data) {
                    model.Types = data.data.Types;
                    model.Bike = data.data.Bike;

                })
                .catch(function (result) {
                    console.log('Result: ', result);
                })
                .finally(function () {
                    console.log('Finally');
                });
        }





        return service;
    }
})(angular.module('BikeRental'));

