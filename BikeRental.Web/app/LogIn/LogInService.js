(function(app) {


    app.factory('LogInService', LogInService);

    LogInService.$inject = ['$http', '$location', '$rootScope', 'localStorageService'];

    function LogInService($http, $location, $rootScope, localStorageService) {

        var service = {
            login: login

            
    }

        function login(model) {
            model.error = '';
            var aut = "grant_type=password&username=" + model.email + "&password=" + model.password;
            $http.post('http://localhost:64069/token', aut)
                .then(function (data) {
                    localStorageService.set('authorizationData',
                    { token: data.data.access_token, userName: model.email });
                    $http.post('http://localhost:64069/api/account/userInSystem?userName=' + aut.userName)
                    .then(
                        function (data) {
                            $rootScope.userLog = data.data;
                        })
                    .catch(function (result) {
                        console.log('Result: ', result);
                    })
                    .finally(function () {
                        console.log('Finally');
                    });

                    $location.path('/home');

                })
                .catch(function (result) {
                    model.error = result.data.error_description;
                    $location.path('/login');
                    console.log('Result: ', result);
                })
                .finally(function() {
                    console.log('Finally');
                });
        }

        

      
        return service;
    }
})(angular.module('BikeRental'));

