(function () {

    var ForwardController = function ($scope, $http, $routeParams) {


        var dirName = $routeParams.OriginalPath;
        var getnewInfo = function () {

            $http.get('http://localhost:56802/api/values' + '/' + dirName).then(function (response) {

                $scope.Info = response.data;

            });
        };


        getnewInfo();

    };

    myApp.controller("ForwardController", ["$scope", "$http", "$routeParams", ForwardController]);

}());