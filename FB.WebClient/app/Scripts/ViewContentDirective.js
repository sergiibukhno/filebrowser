myApp.directive('ngContent', function ($compile) {
    return {
        restrict: 'EA',
        scope: {
            requestedExtension: '=',
            serverRequest: '='
        },
        
        link: function (scope, elem, attrs) {
            scope.$watchGroup(['requestedExtension', 'serverRequest'], function (newValues, oldValues, scope) {
            var html;

            if (scope.requestedExtension == "jpg" || scope.requestedExtension == "png") {
                html = '<img ng-src="' + scope.serverRequest + '" alt="Alternate Text" />';
            }

            if (scope.requestedExtension == "pdf" || scope.requestedExtension == "txt" || scope.requestedExtension == "doc") {
                html = '<iframe width="550" height="600" ng-src="'+scope.serverRequest+'"></iframe>';
            }

            if (scope.requestedExtension == "mp3") {
                html = '<audio controls ng-src="' + scope.serverRequest + '"></audio>';
            }

            if (scope.requestedExtension == "mp4") {
                html = '<video width="550" ng-src="' + scope.serverRequest + '" controls></video>';
            }

            var element = $compile(html)(scope);
            elem.empty();
            elem.append(element);
            });
        }
    };
});