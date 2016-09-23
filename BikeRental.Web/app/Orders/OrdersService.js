(function (app) {

    app.factory('OrdersService', OrdersService);

    OrdersService.$inject = ['$http', '$rootScope', '$location'];

    function OrdersService($http, $rootScope, $location) {

        var service = {
            getOrders: getOrders
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

        return service;
    }
})(angular.module('BikeRental'));
