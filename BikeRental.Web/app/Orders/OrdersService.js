(function (app) {

    app.factory('OrdersService', OrdersService);

    OrdersService.$inject = ['$http', '$rootScope', '$location'];

    function OrdersService($http, $rootScope, $location) {

        var service = {
            getOrders: getOrders
        }

        function getOrders() {
            $http.get('http://localhost:64069/api/profile/getOrders/' + $rootScope.userLog)
                .then(function (data) {
                    return  data.data;
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
