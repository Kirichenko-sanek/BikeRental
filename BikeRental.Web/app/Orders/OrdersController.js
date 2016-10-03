(function(app) {
    app.controller('ordersController', ordersController);
    ordersController.$inject = ['$scope', 'ordersService', '$mdDialog'];

    function ordersController($scope, ordersService, $mdDialog) {
        $scope.pageClass = 'page-orders';
        $scope.deleteOrder = deleteOrder;
        $scope.model = {
            orders: []
        }
        ordersService.getOrders($scope.model);

        function deleteOrder(id) {
            ordersService.deleteOrder(id);
        }

        $scope.showConfirm = function(ev, id) {
            // Appending dialog to document.body to cover sidenav in docs app
            var confirm = $mdDialog.confirm()
                .title('You really want to delete the order?')
                .targetEvent(ev)
                .ok('Delete')
                .cancel('Cancel');

            $mdDialog.show(confirm).then(function() {
                deleteOrder(id);
            }, function() {});
        }
    }
})(angular.module('BikeRental'));