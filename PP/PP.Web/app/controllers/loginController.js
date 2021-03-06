﻿'use strict';
app.controller('loginController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {

    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.message = "";
    // pp - eto zdorovo 
    $scope.login = function () {

        authService.login($scope.loginData).then(function (response) {

            $location.path('/dashboard');

        },
         function (err) {
             $scope.message = err.error_description;
         });
    };

}]);