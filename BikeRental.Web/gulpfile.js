/// <binding ProjectOpened='js:build' />

var gulp = require('gulp'),
    uglify = require('gulp-uglify'),
    concat = require('gulp-concat'),
    cssmin = require('gulp-minify-css');


var path = {
    build: {
        js: 'buildP/js/',
        css: 'buildP/css/'
    },
    src: {
        js: [
            'Scripts/jquery.min.js',
            'Scripts/bootstrap/js/bootstrap.min.js',
            'Scripts/default.js',
            'Scripts/carousel/jquery.carouFredSel-6.2.0-packed.js',
            'Scripts/build/jquery.datetimepicker.full.min.js',
            'bower_components/angular/angular.js',
            'bower_components/angular-route/angular-route.js',
            'bower_components/angular-cookies/angular-cookies.js',
            'bower_components/angular-mocks/angular-mocks.js',
            'bower_components/angular-local-storage/dist/angular-local-storage.js',
            'bower_components/oi.file/oi.file.js',
            'bower_components/angular-animate/angular-animate.js',
            'bower_components/angular-aria/angular-aria.js',
            'bower_components/angular-material/angular-material-mocks.js',
            'bower_components/angular-material/angular-material.js',
            'bower_components/ngprogress/build/ngProgress.js',
            'app/app.js',
            'app/Home/rootController.js',
            'app/LogIn/logInService.js',
            'app/LogIn/logInController.js',
            'app/Home/homeController.js',
            'app/TakeBike/takeBikeDirective.js',
            'app/TakeBike/takeBikeController.js',
            'app/TakeBike/takeBikeService.js',
            'app/Type/typeService.js',
            'app/Orders/ordersController.js',
            'app/Orders/ordersService.js',
            'app/AddBike/addBikeController.js',
            'app/AddBike/addBikeService.js',
            'app/ListBike/listBikeController.js',
            'app/ListBike/listBikeService.js',
            'app/EditBike/editBikeController.js',
            'app/EditBike/editBikeService.js'
        ],
        css: [
            'scripts/bootstrap/css/bootstrap.min.css',
            'scripts/bootstrap/css/bootstrap-responsive.min.css',
            'scripts/fontawesome/css/font-awesome.min.css',
            'scripts/carousel/style.css',
            'styles/custom.css',
            'Content/jquery.datetimepicker.css',
            'bower_components/angular-material/angular-material.css',
            'bower_components/ngprogress/ngProgress.css'
        ]
    }
};

gulp.task('js:build', function () {

    gulp.src(path.src.js)
        .pipe(uglify())
        .pipe(concat('main.js'))
        .pipe(gulp.dest(path.build.js));

});
gulp.task('css:build', function () {

    gulp.src(path.src.css)
        .pipe(cssmin())
        .pipe(concat('main.css'))
        .pipe(gulp.dest(path.build.css));

});




