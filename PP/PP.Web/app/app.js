var app = angular.module('PP', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function($routeProvider) {

    $routeProvider.when('/home', {
        controller: 'homeController',
        templateUrl: '/app/views/home.html'
    });

    $routeProvider.when('/login', {
        controller: 'loginController',
        templateUrl: '/app/views/login.html'
    });

    $routeProvider.when('/signup', {
        controller: 'signupController',
        templateUrl: '/app/views/signup.html'
    });

    $routeProvider.otherwise({ redirectTo: '/home' });

});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run([
    'authService', function(authService) {
        authService.fillAuthData();
    }
]);

// So far we’ve defined and mapped 3 views to their corresponding controllers as the below:

// 1. Home view which shows the home page and
// can be accessed by anonymous users on http://ngauthenticationweb.azurewebsites.net/#/home
// 2. Signup view which shows signup form and
// can be accessed by anonymous users on http://ngauthenticationweb.azurewebsites.net/#/signup
// 3. Log-in view which shows log-in form and
// can be accessed by anonymous users on http://ngauthenticationweb.azurewebsites.net/#/login