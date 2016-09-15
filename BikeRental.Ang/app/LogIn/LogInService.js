(function (app) {


    app.factory('LogInService', LogInService);

    LogInService.$inject = ['apiService','notificationService','$http', '$base64', '$cookieStore', '$rootScope'];

    function LogInService(apiService, notificationService, $http, $base64, $cookieStore, $rootScope) {

        var service = {
            login: login


        }

        function login(user, completed) {
            apiService.post('/api/account/authenticate', user,
            completed,
            loginFailed);
        }

        function loginFailed(response) {
            notificationService.displayError(response.data);
        }


        return service;
    }
})(angular.module('BikeRental'));

