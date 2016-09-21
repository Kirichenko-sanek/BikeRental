﻿(function(app) {


        app.controller('TakeBikeController', TakeBikeController);

        TakeBikeController.$inject = ['$scope', '$http', 'TakeBikeService', 'TypeService'];

        function TakeBikeController($scope, $http, TakeBikeService, TypeService) {

            $scope.pageClass = 'page-takeBike';
            $scope.takeBike = takeBike;
            $scope.model = {
                error: '',
                timeStart: '',
                timeEnd: '',
                accessTime: '',
                selectSex: '',
                timeNow: Date(),
                types:[],
                selectType: null

            };
            TypeService.getType($scope.model);


        function takeBike() {
            TakeBikeService.takeBike($scope.model);
        }
        



    }
})(angular.module('BikeRental'));
