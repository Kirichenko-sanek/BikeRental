(function(app) {
    app.controller('takeBikeController', takeBikeController);
    takeBikeController.$inject = ['$scope', '$http', 'takeBikeService', 'typeService', '$filter'];

    function takeBikeController($scope, $http, takeBikeService, typeService, $filter) {
        $scope.pageClass = 'page-takeBike';
        $scope.takeBike = takeBike;

        var nowTime = $filter('date')(new Date(),'yyyy/MM/dd HH:mm');

        $scope.model = {
            error: '',
            timeStart: nowTime,
            timeEnd: nowTime,
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