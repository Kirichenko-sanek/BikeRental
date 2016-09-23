(function (app) {


    app.factory('TakeBikeService', TakeBikeService);

    TakeBikeService.$inject = ['$http', '$location', '$rootScope'];

    function TakeBikeService($http, $location, $rootScope) {

        var service = {
            takeBike: takebike
        }

        function takebike(model) {
            model.error = '';
            $http.post('http://localhost:64069/api/profile/takeBike/' + $rootScope.userLog, model)
                .then(function (data) {
                    if (data.data.Error !== '') {
                        model.error = data.data.Error;
                        model.accessTime = data.data.AccessTime;
                        $location.path('/takeBike');
                    } else {
                        $location.path('/home');
                    }
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

