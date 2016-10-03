(function() {
    window.angular.module('BikeRental', ['ngRoute', 'ngCookies', 'oi.file', 'LocalStorageModule', 'ngAria', 'ngAnimate', 'ngMaterial'])
        .config(config);
    config.$inject = ['$routeProvider', '$httpProvider'];

    function config($routeProvider, $httpProvider) {
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
})();