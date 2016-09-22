(function (app) {


    app.controller('HomeController', HomeController);


    HomeController.$inject = ['$scope'];
    function HomeController($scope) {
        $scope.pageClass = 'page-home';
    }

})(angular.module('BikeRental'));
