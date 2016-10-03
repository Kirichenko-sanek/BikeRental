(function(app) {
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
                $http.post($rootScope.localAddress + 'api/profile/takeBike/' + $rootScope.userLog, model)
                    .then(function(data) {
                        if (data.data.Error !== '') {
                            model.error = data.data.Error;
                            model.accessTime = data.data.AccessTime;
                            $location.path('/takeBike');
                        } else {
                            $location.path('/userOrders');
                        }
                    })
                    .catch(function(result) {
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