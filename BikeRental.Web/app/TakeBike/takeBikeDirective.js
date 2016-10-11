(function (app) {
    app.directive('datetimepicker',function() {
        return {
            restrict: 'C',
            require: 'ngModel',
            link: function (scope, element) {
                $(element).datetimepicker({
                    minDate: Date.now()
                });
            }
        };
    });

    


})(angular.module('BikeRental'));