(function (app) {


    app.controller('LogInController', LogInController);

    LogInController.$inject = ['$scope', 'LogInService','$rootScope', '$location'];

    function LogInController($scope, LogInService, $rootScope, $location) {
        $scope.pageClass = 'page-login';
        $scope.login = login;
        $scope.user = {};

        function login() {
            LogInService.login($scope.user, loginCompleted);
        }

        function loginCompleted(result) {
            if (result.data.success) {
                LogInService.saveCredentials($scope.user);
                $scope.userData.displayUserInfo();
                if ($rootScope.previousState)
                    $location.path($rootScope.previousState);
                else
                    $location.path('/');
            }
            
        }
    }

})(angular.module('BikeRental'));
