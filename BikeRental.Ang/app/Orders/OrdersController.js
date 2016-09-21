(function (app) {

    app.controller('OrdersController', OrdersController);

    OrdersController.$inject = ['$scope','OrdersService'];

    function OrdersController($scope, OrdersService) {
        $scope.pageClass = 'page-orders';
        $scope.getOrders = getOrders;
        $scope.model = {
            idOrder: null,
            idUder: null,
            idBike: null,
            timeStart: null,
            timeEnd: null,
            dateOrder: null,
            status: null,
            beforStart: null,
            beforEnd: null,
            photo: null,
            priceOrder: null
        };
        $scope.getOrders();

        function getOrders() {
            OrdersService.getOrders($scope.model);
        }
    }

})(angular.module('BikeRental'));