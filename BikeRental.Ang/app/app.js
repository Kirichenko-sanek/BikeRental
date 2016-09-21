(function () {


    window.angular.module('BikeRental', ['ngRoute', 'ngCookies', 'base64'])
        .config(config);

    config.$inject = ['$routeProvider'];
    function config($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "app/Index/Index.html",
                controller: "IndexController"
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
            .when("/home",
            {
                templateUrl: "app/Index/Index.html",
                controller: "IndexController"
                
            });
    }



})();






