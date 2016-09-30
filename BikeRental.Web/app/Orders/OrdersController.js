(function (app) {

    app.controller('OrdersController', OrdersController);

    OrdersController.$inject = ['$scope', 'OrdersService', '$mdDialog'];

    function OrdersController($scope, OrdersService, $mdDialog) {
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

        $scope.showConfirm = function (ev,id) {
            // Appending dialog to document.body to cover sidenav in docs app
            var confirm = $mdDialog.confirm()
                  .title('You really want to delete the order?')
                  .targetEvent(ev)
                  .ok('Delete')
                  .cancel('Cancel');

            $mdDialog.show(confirm).then(function () {
                deleteOrder(id);
            }, function () {
            });
        }


    }

})(angular.module('BikeRental'));