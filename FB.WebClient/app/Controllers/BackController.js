(function () {

    var BackController = function ($scope, $http, $routeParams) {


        var goback = function () {

            $http.put('http://localhost:56802/api/values').then(function (response) {

                $scope.Info = response.data;

            });
        };


        goback();

    };

    myApp.controller("BackController", ["$scope", "$http", "$routeParams", BackController]);

}());