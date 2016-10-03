(function(app) {
    app.controller('editBikeController', editBikeController);
    editBikeController.$inject = ['$scope', '$http', 'editBikeService'];

    function editBikeController($scope, $http, editBikeService) {
        $scope.pageClass = 'page-editBike';
        $scope.editBike = editBike;
        $scope.model = {
            Types: [],
            Bike: null
        };
        $scope.file = null;

        $scope.options = {
            change: function(file) {
                //file.$preview($scope.items[i]);
                $scope.file = file;
            }
        }
        editBikeService.getBike($scope.model);

        function editBike() {
            editBikeService.editBike($scope.model, $scope.file);
        }
    }
})(angular.module('BikeRental'));