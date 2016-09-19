(function (app) {


    app.controller('IndexController', IndexController);


    IndexController.$inject = ['$scope'];
    function IndexController($scope) {
        $scope.pageClass = 'page-home';
    }

})(angular.module('BikeRental'));
