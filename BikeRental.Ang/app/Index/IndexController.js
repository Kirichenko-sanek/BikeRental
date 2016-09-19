(function (app) {


    app.controller('IndexController', IndexController);


    IndexController.$inject = ['$scope', 'apiService', '$location', '$rootScope', 'LogInService'];
    function IndexController($scope, apiService, $location, $rootScope, LogInService) {
        $scope.userData = {};
        $scope.pageClass = 'page-home';
        $scope.userData.displayUserInfo = displayUserInfo;
        $scope = start;


        function start() {
            $location.path('#/home');
        }

        function displayUserInfo() {
            $scope.userData.isUserLoggedIn = LogInService.isUserLoggedIn();

            if ($scope.userData.isUserLoggedIn) {
                $scope.email = $rootScope.repository.loggedUser.email;
            }
        }

        $scope.start();
        $scope.userData.displayUserInfo();
    }

})(angular.module('BikeRental'));
