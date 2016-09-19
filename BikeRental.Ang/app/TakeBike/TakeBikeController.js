(function (app) {


    app.controller('TakeBikeController', TakeBikeController);

    TakeBikeController.$inject = ['$scope', 'TakeBikeService', 'TypeService'];

    function TakeBikeController($scope, TakeBikeService, TypeService) {
        $scope.pageClass = 'page-takeBike';
        $scope.model = {
            errror: '',
            timeStart: '',
            timeEnd: '',
            accessTime: '',
            timeNow: Date(),
            types: TypeService.getType(),
            selectType:null
    };

        function takeBike() {
            TakeBikeService.takeBike($scope.model);
        }

    }

})(angular.module('BikeRental'));
