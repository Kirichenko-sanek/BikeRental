(function() {
    window.angular.module('BikeRental', ['ngRoute', 'ngCookies', 'oi.file', 'LocalStorageModule', 'ngAria', 'ngAnimate', 'ngMaterial', 'ngProgress'])
        .config(config).run(run);
    config.$inject = ['$routeProvider', '$locationProvider'];
    run.$inject = ['localStorageService', '$http', '$rootScope'];

    function config($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(true);
        $locationProvider.hashPrefix('!');
        $routeProvider
            .when("/", {
                templateUrl: "app/Home/home.html",
                controller: "homeController"
            })
            .when("/login", {
                templateUrl: "app/LogIn/login.html",
                controller: "logInController"

            })
            .when("/takeBike", {
                templateUrl: "app/TakeBike/takeBike.html",
                controller: "takeBikeController"
            })
            .when("/userOrders", {
                templateUrl: "app/Orders/userOrders.html",
                controller: "ordersController"
            })
            .when("/addBike", {
                templateUrl: "app/AddBike/addBike.html",
                controller: "addBikeController"
            })
            .when("/listBike", {
                templateUrl: "app/ListBike/listBike.html",
                controller: "listBikeController"
            })
            .when("/editBike/:id", {
                templateUrl: "app/EditBike/editBike.html",
                controller: "editBikeController"
            })
            .when("/home", {
                templateUrl: "app/Home/home.html",
                controller: "homeController"
            });
        
    }
    function run(localStorageService, $http, $rootScope) {
        $rootScope.localAddress = '/rentalapi/';
        var aut = localStorageService.get('authorizationData');

        if (aut !== null) {
            $http.defaults.headers.common['Authorization'] = 'Bearer ' + aut.token;
            $http.post($rootScope.localAddress + 'api/account/userInSystem')
                .then(
                    function (data) {
                        $rootScope.userLog = data.data;
                        $rootScope.userNameLog = aut.userName;
                    })
                .catch(function (result) {
                    console.log('Result: ', result);
                })
                .finally(function () {
                    console.log('Finally');
                });
        } else {
            $rootScope.userLog = null;
        }
    }
})();