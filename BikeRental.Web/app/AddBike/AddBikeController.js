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


        function addBike() {         
            AddBikeService.addBike($scope.model);
        }

    }

})(angular.module('BikeRental'));



