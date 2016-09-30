(function (app) {


    app.controller('ListBikeController', ListBikeController);

    ListBikeController.$inject = ['$scope', '$http', 'ListBikeService', '$mdDialog'];

    function ListBikeController($scope, $http, ListBikeService, $mdDialog) {

        $scope.pageClass = 'page-listBike';
        $scope.deleteBike = deleteBike;
        $scope.editStatus = editStatus;
        $scope.model = {
            bikes:[]

        };

        ListBikeService.listBike($scope.model);

        function deleteBike(id) {
            ListBikeService.deleteBike(id);
        }

        function editStatus(id) {
            ListBikeService.editStatus(id);
        }

        $scope.showConfirm = function (ev, id) {
            // Appending dialog to document.body to cover sidenav in docs app
            var confirm = $mdDialog.confirm()
                  .title('You really want to delete the bike?')
                  .targetEvent(ev)
                  .ok('Delete')
                  .cancel('Cancel');

            $mdDialog.show(confirm).then(function () {
                deleteBike(id);
            }, function () {
            });
        }

    }
})(angular.module('BikeRental'));
