(function (app) {


    app.controller('AddBikeController', AddBikeController);

    AddBikeController.$inject = ['$scope', 'AddBikeService', 'TypeService'];

    function AddBikeController($scope, AddBikeService, TypeService) {
        $scope.pageClass = 'page-addBike';
        $scope.addBike = addBike;
        $scope.model = {
            types: [],
            sex: null,
            price: null,
            idType: null
        };
        TypeService.getType($scope.model);       

        $scope.file = {}
        
        $scope.options = {
            change: function(file) {
                file.$upload('http://localhost:64069/api/admin/upload', $scope.file);
                //file.$preview($scope.items[i]);
                $scope.file = file;
            }
        }

        function addBike() {         
            AddBikeService.addBike($scope.model, $scope.file);
        }

    }

})(angular.module('BikeRental'));



