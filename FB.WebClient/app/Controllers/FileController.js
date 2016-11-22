(function () {

    var FileController = function ($http) {

        var getInfo = function () {

            $http.get('http://localhost:56802/api/BrowsingFiles').then(function (response) {

                this.Info = response.data;

            });
        };


        getInfo();

    };

    myApp.controller("FileController", ["$http", FileController]);

}());