(function (app) {


    app.controller('rootController', rootController);

    app.option

    rootController.$inject = ['$rootScope', '$location', '$http'];

    function rootController($rootScope, $location, $http) {
        $rootScope.logoff = logoff;
        $rootScope.userInSystem = userInSystem();
       

        function logoff() {
            $http.post('http://localhost:64069/api/account/logoff')
                .then(
                    function (data) {
                        if (data.data === true) {
                            $rootScope.userLog = 0;
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

        function userInSystem() {
            //$rootScope.userLog = 0;
            $http.get('http://localhost:64069/api/account/userInSystem')
                .then(
                    function (data) {
                        if (data.data !== 0) {
                            $rootScope.userLog = data.data;
                        } else {
                            $rootScope.userLog = 0;
                        }
                    })
                .catch(function (result) {
                    console.log('Result: ', result);
                })
                .finally(function () {
                    console.log('Finally');
                });
        }


       
    }

})(angular.module('BikeRental'));
