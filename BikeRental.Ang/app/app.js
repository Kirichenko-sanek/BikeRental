(function () {


    window.angular.module('BikeRental', ['ngRoute', 'ngCookies', 'base64'])
        .config(config);
        //.run(run);

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
            .when("/home",
            {
                templateUrl: "app/Home/Index.html",
                controller: "HomeController"
                
            });
    }


    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];
    
    function run($rootScope, $location, $cookieStore, $http) {
        $rootScope.repository = $cookieStore.get('repository') || {};
        if ($rootScope.repository.loggedUser) {
            $http.defaults.headers.common['Authorization'] = $rootScope.repository.loggedUser.authdata;
        }

        $(document).ready(function () {
            $(".fancybox").fancybox({
                openEffect: 'none',
                closeEffect: 'none'
            });

            $('.fancybox-media').fancybox({
                openEffect: 'none',
                closeEffect: 'none',
                helpers: {
                    media: {}
                }
            });

            $('[data-toggle=offcanvas]').click(function () {
                $('.row-offcanvas').toggleClass('active');
            });
        });
    }

    isAuthenticated.$inject = ['LogInService', '$rootScope', '$location'];

    function isAuthenticated(LogInService, $rootScope, $location) {
        if (!LogInService.isUserLoggedIn()) {
            $rootScope.previousState = $location.path();
            $location.path('/login');
        }
    }



})();






