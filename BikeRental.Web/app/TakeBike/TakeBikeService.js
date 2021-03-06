﻿(function(app) {
    app.factory('takeBikeService', takeBikeService);
    takeBikeService.$inject = ['$http', '$location', '$rootScope'];

    function takeBikeService($http, $location, $rootScope) {
        var service = {
            takeBike: takebike
        }

        function takebike(model) {
            model.error = '';
            if (model.timeStart > model.timeEnd) {
                model.error = 'Rental period is entered incorrectly';
                $location.path('/takeBike');
            } else {
                $http.post($rootScope.localAddress + 'api/profile/takeBike', model)
                    .then(function(data) {
                        if (data.data.Error !== null) {
                            model.error = data.data.Error;
                            model.accessTime = data.data.AccessTime;
                            $location.path('/takeBike');
                        } else {
                            $location.path('/userOrders');
                        }
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