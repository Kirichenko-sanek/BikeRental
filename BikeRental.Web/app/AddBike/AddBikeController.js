(function (app) {


    app.controller('AddBikeController', AddBikeController);

    AddBikeController.$inject = ['$scope', 'AddBikeService','$http', 'TypeService'];

    function AddBikeController($scope, AddBikeService,$http, TypeService) {
        $scope.pageClass = 'page-addBike';
        $scope.addBike = addBike;
        $scope.model = {
            types: [],
            sex: null,
            price: null,
            idType: null,
            idPhoto: null,
            photo:''
        };
        TypeService.getType($scope.model);       

        $scope.file = {}
        
        $scope.options = {
            change: function (file) {       
                //file.$preview($scope.items[i]);
                $scope.file = file;
            }
        }

        function addBike() {         
            AddBikeService.addBike($scope.model, $scope.file);
        }

    }

})(angular.module('BikeRental'));



