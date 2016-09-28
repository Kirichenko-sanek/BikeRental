(function (app) {


    app.controller('ListBikeController', ListBikeController);

    ListBikeController.$inject = ['$scope', '$http', 'ListBikeService'];

    function ListBikeController($scope, $http, ListBikeService) {

        $scope.pageClass = 'page-listBike';
        $scope.deleteBike = deleteBike;
        $scope.editStatus = editStatus;
        $scope.model = {
            bikes:[]

        };

        ListBikeService.listBike($scope.model);

        function deleteBike(id) {
            ListBikeService.deleteBike(id);
        }

        function editStatus(id) {
            ListBikeService.editStatus(id);
        }



    }
})(angular.module('BikeRental'));
