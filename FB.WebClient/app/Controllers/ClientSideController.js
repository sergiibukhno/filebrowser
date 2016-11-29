(function () {

    var ClientSideController = function ($scope, $http, ConstService) {
        
        var getDrives = function () {
            $http.get(ConstService.serverApiConst+ConstService.driveControllerConst).then(function (response) {
                $scope.resultDrives = response.data;
            });
            $scope.backsymbol = false;
            $scope.results = [];
        };

        var getDriveDirs = function (dir) {
            var encodedDir = dir.replace(/:/g, "d0td0t").replace(/\\/g, "b3cks1").replace(/\./g, "t0d").replace(/#/g, "sh4");
            $http.get(ConstService.serverApiConst+ConstService.driveControllerConst + '/' + encodedDir).then(function (response) {
                $scope.results = response.data;
                $scope.countresults = [];
                $scope.resultDrives = [];
                $scope.backsymbol = true;
            });
        };

        var getDirs = function (dir) {
            var encodedDir = dir.replace(/:/g, "d0td0t").replace(/\\/g, "b3cks1").replace(/\./g, "t0d").replace(/#/g, "sh4");
            $http.get(ConstService.serverApiConst+ConstService.driveControllerConst + '/' + encodedDir).then(function (response) {
                $scope.results = response.data; 
            });

            $http.get(ConstService.serverApiConst+ConstService.countControllerConst + '/' + encodedDir).then(function (response) {
                $scope.countresults = response.data; 
            });
            $scope.backsymbol = true;
        };

        var goDirBack = function (dir) {
            var index = dir.lastIndexOf("\\");
            if (index >= 3) {
                dir = dir.slice(0, index);
                getDirs(dir);
            }

            if (index <= 2) {

                if (dir.length <= 3) {
                    getDrives();
                }

                else {
                    dir = dir.slice(0, index + 1);
                    getDriveDirs(dir);
                }                
            }
        }

        $scope.getDrives = getDrives;        
        $scope.getDirs = getDirs;
        $scope.getDriveDirs = getDriveDirs;
        $scope.goDirBack = goDirBack;
        getDrives();
    };

    myApp.controller("ClientSideController", ["$scope", "$http", "ConstService", ClientSideController]);

}());