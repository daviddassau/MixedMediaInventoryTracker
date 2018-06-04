app.controller("LendMedia", ["$scope", "$http", "$location", "$routeParams",
    function ($scope, $http, $location, $routeParams) {

        $scope.message = "Lend Media Item";

        $scope.lendMediaItem = {};
        $scope.items = {};

        $scope.selectMediaItem = function (item) {
            $scope.lendMediaItem.mediaId = item.mediaId;
        };

        $http.get("api/media").then(function (results) {
            $scope.items = results.data;
        });

    }
]);