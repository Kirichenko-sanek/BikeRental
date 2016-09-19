(function(app) {


    app.factory('LogInService', LogInService);

    LogInService.$inject = ['apiService', '$http', '$location'];

    function LogInService(apiService, $http, $location) {

        var service = {
            login: login
        }

        function login(model) {          
            $http.post('api/account/authenticate', model)
                .then(function (data) {
                    if (data.data.Error != null) {
                        model.error = data.data.Error;
                        $location.path('/login');
                    } else {
                        model.error = '';
                        $location.path('/home');
                    }
                })
                .catch(function(result) {
                    console.log('Result: ', result);
                })
                .finally(function() {
                    console.log('Finally');
                });

            //var loginMod = $http.post('#/api/Account/authenticate', model);
        }

      
        return service;
    }
})(angular.module('BikeRental'));

