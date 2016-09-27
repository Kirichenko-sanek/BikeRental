(function (app) {


    app.controller('rootController', rootController);

    app.option

    rootController.$inject = ['$rootScope', '$location', '$http', 'localStorageService'];

    function rootController($rootScope, $location, $http, localStorageService) {
        $rootScope.logoff = logoff;
        $rootScope.userInSystem = userInSystem();
       

        function logoff() {
            localStorageService.remove('authorizationData');
            $rootScope.userLog = 0;
            $location.path('/home');
        }

        function userInSystem() {
            var aut = localStorageService.get('authorizationData');
            if (aut !== undefined) {
                $http.post('http://localhost:64069/api/account/userInSystem?userName=' + aut.userName)
                    .then(
                        function (data) {
                            $rootScope.userLog = data.data;
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
