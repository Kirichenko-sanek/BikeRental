(function (app) {

    app.controller('OrdersController', OrdersController);

    OrdersController.$inject = ['$scope','OrdersService'];

    function OrdersController($scope, OrdersService) {
        $scope.pageClass = 'page-orders';
        $scope.model = 
        {
            orders: []
        }
        OrdersService.getOrders($scope.model);


    }

})(angular.module('BikeRental'));