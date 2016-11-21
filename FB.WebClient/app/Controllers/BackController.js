(function () {

    var BackController = function ($http, $routeParams) {


        var goback = function () {

            $http.put('http://localhost:56802/api/values').then(function (response) {

                this.Info = response.data;

            });
        };


        goback();

    };

    myApp.controller("BackController", ["$http", "$routeParams", BackController]);

}());