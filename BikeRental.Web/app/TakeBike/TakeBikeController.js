(function(app) {
    app.controller('takeBikeController', takeBikeController);
    takeBikeController.$inject = ['$scope', '$http', 'takeBikeService', 'typeService'];

    function takeBikeController($scope, $http, takeBikeService, typeService) {
        $scope.pageClass = 'page-takeBike';
        $scope.takeBike = takeBike;
        $scope.model = {
            error: '',
            timeStart: '',
            timeEnd: '',
            accessTime: null,
            selectSex: null,
            types: [],
            selectType: 0
        };
        typeService.getType($scope.model);

        function takeBike() {
            takeBikeService.takeBike($scope.model);
        }
    }
})(angular.module('BikeRental'));