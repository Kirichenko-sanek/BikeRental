(function (app) {


    app.controller('EditBikeController', EditBikeController);

    EditBikeController.$inject = ['$scope', '$http', 'EditBikeService'];

    function EditBikeController($scope, $http, EditBikeService) {
        
        $scope.pageClass = 'page-editBike';
        $scope.editBike = editBike;
        $scope.model = {
            Types: [],
            Bike: null

        };
        $scope.file = null;

        $scope.options = {
            change: function (file) {
                //file.$preview($scope.items[i]);
                $scope.file = file;
            }
        }


        EditBikeService.getBike($scope.model);

        function editBike() {
            EditBikeService.editBike($scope.model, $scope.file);
        }



    }
})(angular.module('BikeRental'));
