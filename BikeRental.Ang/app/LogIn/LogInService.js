(function(app) {


    app.factory('LogInService', LogInService);

    LogInService.$inject = ['apiService', '$http', '$location', '$rootScope'];

    function LogInService(apiService, $http, $location, $rootScope) {

        var service = {
            login: login

            
    }

        function login(model) {
            model.error = '';
            $http.post('api/account/login', model)
                .then(function (data) {
                    if (data.data.Error !== '') {
                        model.error = data.data.Error;
                        $location.path('/login');
                    } else {
                        $rootScope.userLog = data.data.IdUser;
                        $location.path('/home');
                    }
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

