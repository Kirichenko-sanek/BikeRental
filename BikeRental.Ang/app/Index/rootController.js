(function (app) {


    app.controller('rootController', rootController);


    rootController.$inject = ['$rootScope', '$location', '$http'];

    function rootController($rootScope, $location, $http ) {
        $rootScope.logoff = logoff;
        $rootScope.userInSystem = userInSystem();
       

        function logoff() {
            $http.post('api/account/logoff')
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
            $http.get('api/account/userInSystem')
                .then(
                    function (data) {
                        if (data.data !== 0) {
                            $rootScope.userLog = data.data;
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
