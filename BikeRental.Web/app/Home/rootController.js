(function(app) {
    app.controller('rootController', rootController);
    rootController.$inject = ['$q', '$rootScope', '$location', '$http', 'localStorageService'];

    function rootController($q, $rootScope, $location, $http, localStorageService) {
        $rootScope.localAddress = '/rentalapi/';
        $rootScope.logoff = logoff;
        $rootScope.userInSystem = userInSystem();

        function logoff() {
            localStorageService.remove('authorizationData');
            $rootScope.userLog = 0;
            $rootScope.userNameLog = '';
            $location.path('/home');
        }

        function userInSystem() {
            var aut = localStorageService.get('authorizationData');

            if (aut !== null) {
                $http.defaults.headers.common['Authorization'] = 'Bearer ' + aut.token;
                $http.post($rootScope.localAddress + 'api/account/userInSystem?userName=' + aut.userName)
                    .then(
                        function(data) {
                            $rootScope.userLog = data.data;
                            $rootScope.userNameLog = aut.userName;
                        })
                    .catch(function(result) {
                        console.log('Result: ', result);
                    })
                    .finally(function() {
                        console.log('Finally');
                    });
            } else {
                $rootScope.userLog = 0;
            }
        }
    }
})(angular.module('BikeRental'));