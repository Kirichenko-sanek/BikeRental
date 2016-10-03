(function (app) {

    app.factory('OrdersService', OrdersService);

    OrdersService.$inject = ['$http','$route', '$rootScope', '$location'];

    function OrdersService($http, $route, $rootScope, $location) {

        var service = {
            getOrders: getOrders,
            deleteOrder: deleteOrder
        }

        function getOrders(model) {
            $http.get($rootScope.localAddress + 'api/profile/getOrders/' + $rootScope.userLog)
                .then(function (data) {
                    if (data.data.length === 0) {
                        model.orders = null;
                    } else {
                        model.orders = data.data;
                    }
                    $location.path('/userOrders');
                })
                .catch(function (result) {
                    model.orders = null;
                    console.log('Result: ', result);
                })
                .finally(function () {                 
                    console.log('Finally');
                    
                });
        }

        function deleteOrder(id) {
            $http.post($rootScope.localAddress + 'api/profile/deleteOrder/' + id)
                .then(
                    function (data) {
                        $route.reload();

                    })
                .catch(function (result) {
                    console.log('Result: ', result);
                })
                .finally(function () {
                    console.log('Finally');
                });
        }

        return service;
    }
})(angular.module('BikeRental'));
