(function (app) {

    app.factory('OrdersService', OrdersService);

    OrdersService.$inject = ['$http','$rootScope'];

    function OrdersService($http, $rootScope) {

        var service = {
            getOrders: getOrders
        }

        function getOrders(model) {
            $http.get('api/profile/getOrders/' + $rootScope.userLog)
                .then(function (data) {
                    model = data.data;
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
