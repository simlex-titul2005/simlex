var promise = require('es6-promise'),
    gulp = require('gulp'),
    watch = require('gulp-watch'),
    del = require('del'),
    concat = require('gulp-concat'),
    uglify = require('gulp-uglify'),
    merge = require('merge-stream'),
    order = require('gulp-order'),
    less = require('gulp-less'),
    cleanCSS = require('gulp-clean-css'),
    autoprefixer = require('gulp-autoprefixer'),
    rename = require('gulp-rename');

function clear() {
    del([
        'content/dist/css/**/*.css',
        'content/dist/js/**/*.js',
        'content/dist/fonts/**/*'
    ]);
}

function createCss() {
    gulp.src([
        'less/site.less',
        'less/nav-bar.less'
    ])
        .pipe(less())
        .pipe(cleanCSS({ compatibility: 'ie8' }))
        .pipe(autoprefixer('last 2 version', 'safari 5', 'ie 8', 'ie 9'))
        .pipe(concat('site.min.css'))
        .pipe(gulp.dest('content/dist/css'));

    //by one less
    //gulp.src([
    //   'less/error-page.less'
    //])
    //    .pipe(less())
    //    .pipe(cleanCSS({ compatibility: 'ie8' }))
    //    .pipe(autoprefixer('last 2 version', 'safari 5', 'ie 8', 'ie 9'))
    //    .pipe(rename({
    //        suffix: '.min'
    //    }))
    //    .pipe(gulp.dest('content/dist/css'));
}

function createJs() {
    gulp.src([
        'scripts/page.js',
        'scripts/navbar.js'
    ])
        .pipe(uglify())
        .pipe(concat('site.min.js'))
        .pipe(gulp.dest('content/dist/js'));


    //by one js
    //gulp.src([
    //    'scripts/ge-for-gamers-block.js'
    //])
    //    .pipe(uglify())
    //    .pipe(rename({
    //        suffix: '.min'
    //    }))
    //    .pipe(gulp.dest('content/dist/js'));
}

gulp.task('watch', function (cb) {
    watch([
        'less/**/*.less',
        'scripts/**/*.js'
    ], function () {
        clear();
        createCss();
        createJs();
    });
});