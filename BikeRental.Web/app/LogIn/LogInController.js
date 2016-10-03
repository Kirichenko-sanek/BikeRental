(function(app) {
    app.controller('logInController', logInController);
    logInController.$inject = ['$scope', 'logInService'];

    function logInController($scope, logInService) {
        $scope.pageClass = 'page-login';
        $scope.login = login;
        $scope.model = {
            email: null,
            password: null,
            error: '',
            userId: 0
        };

        function login() {
            logInService.login($scope.model);
        }

    }
})(angular.module('BikeRental'));