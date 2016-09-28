(function (app) {

    app.factory('OrdersService', OrdersService);

    OrdersService.$inject = ['$http','$route', '$rootScope', '$location'];

    function OrdersService($http, $route, $rootScope, $location) {

        var service = {
            getOrders: getOrders,
            deleteOrder: deleteOrder
        }

        function getOrders(model) {
            $http.get('http://localhost:64069/api/profile/getOrders/' + $rootScope.userLog)
                .then(function (data) {
                    model.orders = data.data;
                    $location.path('/userOrders');
                })
                .catch(function (result) {
                    console.log('Result: ', result);
                })
                .finally(function () {                 
                    console.log('Finally');
                    
                });
        }

        function deleteOrder(id) {
            $http.post('http://localhost:64069/api/profile/deleteOrder/' + id)
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
