(function (app) {

    app.controller('OrdersController', OrdersController);

    OrdersController.$inject = ['$scope','OrdersService'];

    function OrdersController($scope, OrdersService) {
        $scope.pageClass = 'page-orders';
        $scope.deleteOrder = deleteOrder;
        $scope.model = 
        {
            orders: []
        }
        OrdersService.getOrders($scope.model);

        function deleteOrder(id) {
            OrdersService.deleteOrder(id);
        }
    }

})(angular.module('BikeRental'));