(function (app) {


    app.controller('LogInController', LogInController);

    LogInController.$inject = ['$scope', 'LogInService','$rootScope', '$location'];

    function LogInController($scope, LogInService, $rootScope, $location) {
        $scope.pageClass = 'page-login';
        $scope.login = login;
        $scope.model = {
            email: '',
            password: '',
            error: '',
            userId: 0
    };

        function login() {
            LogInService.login($scope.model);
        }
    }

})(angular.module('BikeRental'));
