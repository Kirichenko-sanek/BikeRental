﻿(function(app) {
    app.controller('listBikeController', listBikeController);
    listBikeController.$inject = ['$scope', '$http', 'listBikeService', '$mdDialog', '$location'];

    function listBikeController($scope, $http, listBikeService, $mdDialog, $location) {
        $scope.pageClass = 'page-listBike';
        $scope.deleteBike = deleteBike;
        $scope.editStatus = editStatus;
        $scope.goEdit = goEdit;
        $scope.model = {
            bikes: []
        };
        listBikeService.listBike($scope.model);

        function deleteBike(id) {
            listBikeService.deleteBike(id);
        }

        function goEdit(id) {
            $location.path('/editBike/'+ id);
        }

        function editStatus(id) {
            listBikeService.editStatus(id);
        }
        $scope.showConfirm = function(ev, id) {
            // Appending dialog to document.body to cover sidenav in docs app
            var confirm = $mdDialog.confirm()
                .title('You really want to delete the bike?')
                .targetEvent(ev)
                .ok('Delete')
                .cancel('Cancel');
            $mdDialog.show(confirm).then(function() {
                deleteBike(id);
            }, function() {});
        }
    }
})(angular.module('BikeRental'));