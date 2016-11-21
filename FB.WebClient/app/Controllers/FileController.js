(function () {

    var FileController = function ($scope, $http) {

        var getInfo = function () {

            $http.get('http://localhost:56802/api/values').then(function (response) {

                $scope.Info = response.data;

            });
        };


        getInfo();

    };

    myApp.controller("FileController", ["$scope", "$http", FileController]);

}());