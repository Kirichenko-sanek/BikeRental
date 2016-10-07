(function(app) {
    app.factory('editBikeService', editBikeService);
    editBikeService.$inject = ['$http', '$routeParams', '$location', '$rootScope', 'localStorageService'];

    function editBikeService($http, $routeParams, $location, $rootScope, localStorageService) {
        var service = {
            getBike: getBike,
            editBike: editBike
        }

        function getBike(model) {
            var currentId = $routeParams.id;
            $http.get($rootScope.localAddress + 'api/admin/getBike/' + currentId)
                .then(function(data) {
                    model.Types = data.data.Types;
                    model.Bike = data.data.Bike;

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
        }

        function editBike(model, file) {
            if (file !== null) {
                var fd = new FormData();
                fd.set('file', file);
                file.$upload($rootScope.localAddress + 'api/admin/upload', fd)
                    .then(function(data) {
                        model.Bike.photo = data.data;
                        $http.post($rootScope.localAddress + 'api/admin/editBike', model)
                            .then(function(data) {
                                $location.path('/listBike');
                            })
                            .catch(function (result) {
                                console.log('Result: ', result);
                            })
                            .finally(function() {
                                console.log('Finally');
                            });
                    });
            } else {
                $http.post($rootScope.localAddress + 'api/admin/editBike', model)
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
            }
        }
        return service;
    }
})(angular.module('BikeRental'));