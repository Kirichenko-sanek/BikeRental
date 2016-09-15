(function (app) {


    app.controller('IndexController', window.IndexController);


    IndexController.$inject = ['$scope', 'apiService', '$location'];
    function IndexController($scope, apiService, $location) {
        $scope.pageClass = 'page-home';
        $scope.start();


        function start() {
            $location.path('#/');
        }

    }

})(angular.module('BikeRental'));
