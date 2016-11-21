var myApp = angular.module("myApp", ['ngRoute']);

myApp.config(function ($routeProvider) {

    $routeProvider
    .when("/", {
        templateUrl: 'app/Views/Layout2.html',
        controller: 'FileController'

    })




    .when("/Values/:OriginalPath", {
        templateUrl: 'app/Views/Layout2.html',
        controller: 'ForwardController'

    })





    .when("/Goback", {
        templateUrl: 'app/Views/Layout2.html',
        controller: 'BackController'

    })


    .when("/Goback/:value", {
        templateUrl: 'app/Views/Layout2.html',
        controller: 'BackController'

    });



});