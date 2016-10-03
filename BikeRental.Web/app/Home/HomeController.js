(function(app) {
	app.controller('homeController', homeController);
	homeController.$inject = ['$scope'];

	function homeController($scope) {
		$scope.pageClass = 'page-home';
	}
})(angular.module('BikeRental'));