﻿﻿let gulp = require('gulp');
let del = require('del');
let sass = require("gulp-sass");


// ========== Main Build ========== //

gulp.task('build', ['sass'], function() {

});


// ========== Sass ========== //

gulp.task('sass', ['sass:clean'], function() {
  return gulp.src('Styles/*.scss')
    .pipe(sass())
    .pipe(gulp.dest('./wwwroot/styles'));
});

gulp.task('sass:clean', function() {
    return del(['./wwwroot/styles/*']);
});


// ========== Watch ========== //

gulp.task('watch', function() {
    gulp.watch(['./Styles/*.scss'], ['sass']);
});
