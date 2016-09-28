(function () {


    window.angular.module('BikeRental', ['ngRoute', 'ngCookies', 'LocalStorageModule', 'angularFileUpload'])
        .config(config);

    config.$inject = ['$routeProvider', '$httpProvider'];
    function config($routeProvider, $httpProvider) {

        $routeProvider
            .when("/", {
                templateUrl: "app/Home/home.html",
                controller: "HomeController"
            })
            .when("/login",
            {
                templateUrl: "app/LogIn/login.html",
                controller: "LogInController"
               
            })
            .when("/takeBike",
            {
                templateUrl: "app/TakeBike/takeBike.html",
                controller: "TakeBikeController"
            })
            .when("/userOrders",
            {
                templateUrl: "app/Orders/userOrders.html",
                controller: "OrdersController"
            })
            .when("/adminPage",
            {
                templateUrl: "app/Admin/adminPage.html"
                
            })
            .when("/addBike",
            {
                templateUrl: "app/AddBike/addBike.html",
                controller: "AddBikeController"
            })
            .when("/listBike",
            {
                templateUrl: "app/ListBike/listBike.html",
                controller: "ListBikeController"
            })
            .when("/home",
            {
                templateUrl: "app/Home/home.html",
                controller: "HomeController"
                
            });




    }



})();






