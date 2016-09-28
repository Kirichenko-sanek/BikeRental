(function (app) {


    app.factory('ListBikeService', ListBikeService);

    ListBikeService.$inject = ['$http','$route', '$location'];

    function ListBikeService($http,$route, $location) {

        var service = {
            listBike: listBike,
            deleteBike: deleteBike,
            editStatus: editStatus
        }

        function listBike(model) {
            $http.get('http://localhost:64069/api/admin/getBikes')
                .then(
                    function (data) {
                        model.bikes = data.data;
                    })
                .catch(function (result) {
                    console.log('Result: ', result);
                })
                .finally(function () {
                    console.log('Finally');

                });
        }

        function deleteBike(id) {
            $http.post('http://localhost:64069/api/admin/deleteBike/' + id)
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

        function editStatus(id) {
            $http.post('http://localhost:64069/api/admin/editStatus/' + id)
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

