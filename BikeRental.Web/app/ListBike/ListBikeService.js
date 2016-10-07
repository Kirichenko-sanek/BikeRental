(function(app) {
    app.factory('listBikeService', listBikeService);
    listBikeService.$inject = ['$http', '$rootScope', '$route', '$location'];

    function listBikeService($http, $rootScope, $route, $location) {
        var service = {
            listBike: listBike,
            deleteBike: deleteBike,
            editStatus: editStatus
        }

        function listBike(model) {
            $http.get($rootScope.localAddress + 'api/admin/getBikes')
                .then(
                    function(data) {
                        model.bikes = data.data;
                    })
                .catch(function (result) {
                    if (status === 401) {
                        $location.path('/login');
                    }
                    console.log('Result: ', result);
                })
                .finally(function() {
                    console.log('Finally');
                });
        }

        function deleteBike(id) {
            $http.post($rootScope.localAddress + 'api/admin/deleteBike/' + id)
                .then(
                    function(data) {
                        $route.reload();

                    })
                .catch(function (result) {
                    if (status === 401) {
                        $location.path('/login');
                    }
                    console.log('Result: ', result);
                })
                .finally(function() {
                    console.log('Finally');
                });
        }

        function editStatus(id) {
            $http.post($rootScope.localAddress + 'api/admin/editStatus/' + id)
                .then(
                    function(data) {
                        $route.reload();
                    })
                .catch(function (result) {
                    if (status === 401) {
                        $location.path('/login');
                    }
                    console.log('Result: ', result);
                })
                .finally(function() {
                    console.log('Finally');
                });
        }
        return service;
    }
})(angular.module('BikeRental'));