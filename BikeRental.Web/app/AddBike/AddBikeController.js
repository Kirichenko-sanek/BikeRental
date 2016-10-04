(function(app) {

    app.controller('addBikeController', addBikeController);

    addBikeController.$inject = ['$scope', 'addBikeService', '$http', 'typeService'];

    function addBikeController($scope, addBikeService, $http, typeService) {
        $scope.pageClass = 'page-addBike';
        $scope.addBike = addBike;
        $scope.model = {
            types: [],
            sex: null,
            price: null,
            idType: null,
            idPhoto: null,
            photo: ''
        };
        typeService.getType($scope.model);

        $scope.file = {}

        $scope.options = {
            change: function(file) {
                //file.$preview($scope.items[i]);
                $scope.file = file;
            }
        }

        function addBike() {
            addBikeService.addBike($scope.model, $scope.file);
        }

    }

})(angular.module('BikeRental'));