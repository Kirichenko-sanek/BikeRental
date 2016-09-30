(function (app) {


    app.factory('AddBikeService', AddBikeService);

    AddBikeService.$inject = ['$http', '$location', '$rootScope', 'localStorageService'];

    function AddBikeService($http, $location, $rootScope, localStorageService) {

        var service = {
            addBike: addBike

        }

        function addBike(model,file) {
            $http.post('http://localhost:64069/api/admin/addBike', model)
               .then(function (data) {
                   /*if (data.data.Error !== '') {
                       model.error = data.data.Error;
                       model.accessTime = data.data.AccessTime;
                       $location.path('/takeBike');
                   } else {
                       $location.path('/home');
                   }*/
               })
               .catch(function (result) {
                   console.log('Result: ', result);
               })
               .finally(function () {
                   console.log('Finally');
               });
        }
       




        return service;
    }
})(angular.module('BikeRental'));

