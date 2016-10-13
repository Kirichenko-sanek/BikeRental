/// <binding ProjectOpened='js:build' />

var gulp = require('gulp'),
    uglify = require('gulp-uglify'),
    concat = require('gulp-concat'),
    cssmin = require('gulp-minify-css'),
    inject = require('gulp-inject'),
    htmlbuild = require('gulp-htmlbuild'),
    ghtmlSrc = require('gulp-html-src');



var path = {
    build: {
        js: 'buildP/js/',
        css: 'buildP/css/'
    }
};

gulp.task('build',
    function () {
        gulp.src('index.html')
            .pipe(ghtmlSrc({ presets: 'css' }))
            .pipe(cssmin())
            .pipe(concat('main.css'))
            .pipe(gulp.dest(path.build.css));

        gulp.src('index.html')
            .pipe(ghtmlSrc())
            .pipe(uglify())
            .pipe(concat('main.js'))
            .pipe(gulp.dest(path.build.js));

        gulp.src(['index.html'])
            .pipe(htmlbuild({
                js: htmlbuild.preprocess.js(function(block) {
                    block.write('buildP/js/main.js');
                    block.end();
                }),
                css: htmlbuild.preprocess.css(function (block) {
                    block.write('buildP/css/main.css');
                    block.end();
                })
            }))
            .pipe(gulp.dest('buildP'));
    });




