(function (app) {


    app.controller('EditBikeController', EditBikeController);

    EditBikeController.$inject = ['$scope', '$http', 'EditBikeService'];

    function EditBikeController($scope, $http, EditBikeService) {
        
        $scope.pageClass = 'page-editBike';
        $scope.model = {
            Types: [],
            Bike: null

        };

        $scope.file = {}
        $scope.options = {
            //Вызывается для каждого выбранного файла
            change: function(file) {
                //В file содержится информация о файле
                //Загружаем на сервер
                file.$upload('/assets/images/Bikes', $scope.file);
            }
        }


        EditBikeService.getBike($scope.model);



    }
})(angular.module('BikeRental'));
