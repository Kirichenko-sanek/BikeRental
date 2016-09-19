(function (app) {


    app.controller('LogInController', LogInController);

    LogInController.$inject = ['$scope', 'LogInService'];

    function LogInController($scope, LogInService) {
        $scope.pageClass = 'page-login';
        $scope.login = login;
        $scope.model = {
            email: null,
            password: null,
            error: '',
            userId: 0
    };

        function login() {
            LogInService.login($scope.model);
        }

    }

})(angular.module('BikeRental'));
