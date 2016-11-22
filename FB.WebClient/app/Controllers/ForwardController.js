(function () {

    var ForwardController = function ($http, $routeParams) {


        var dirName = $routeParams.OriginalPath;
        var getnewInfo = function () {

            $http.get('http://localhost:56802/api/BrowsingFiles' + '/' + dirName).then(function (response) {

                this.Info = response.data;

            });
        };


        getnewInfo();

    };

    myApp.controller("ForwardController", ["$http", "$routeParams", ForwardController]);

}());