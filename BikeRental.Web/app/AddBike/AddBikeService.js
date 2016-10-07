(function(app) {
    app.factory('addBikeService', addBikeService);
    addBikeService.$inject = ['$http', '$location', '$rootScope', 'localStorageService'];

    function addBikeService($http, $location, $rootScope, localStorageService) {
        var service = {
            addBike: addBike
        }

        function addBike(model, file) {
            var fd = new FormData();
            fd.set('file', file);
            file.$upload($rootScope.localAddress + 'api/admin/upload', fd)
                .then(function(data) {
                    model.photo = data.data;
                    $http.post($rootScope.localAddress + 'api/admin/addBike', model)
                        .then(function(data) {
                            $location.path('/listBike');
                        })
                        .catch(function (result) {
                            if (status === 401) {
                                $location.path('/login');
                            }
                            console.log('Result: ', result);
                        })
                        .finally(function() {
                            console.log('Finally');
                        });
                });
        }
        return service;
    }
})(angular.module('BikeRental'));