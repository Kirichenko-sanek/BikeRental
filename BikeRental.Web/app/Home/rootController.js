(function(app) {
    app.controller('rootController', rootController);
    rootController.$inject = ['$q', '$rootScope', '$location', '$http', 'localStorageService'];

    function rootController($q, $rootScope, $location, $http, localStorageService) {
        $rootScope.logoff = logoff;

        function logoff() {
            localStorageService.remove('authorizationData');
            $rootScope.userLog = null;
            $rootScope.userNameLog = '';
            $location.path('/home');
        }
    }
})(angular.module('BikeRental'));