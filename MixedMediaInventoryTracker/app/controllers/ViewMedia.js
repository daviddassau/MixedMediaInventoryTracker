app.controller("ViewMedia", ["$scope", "$http", "$location",
    function ($scope, $http, $location) {

        $scope.message = "My Media";

        $scope.mediaItem = {};
        $scope.types = {};

        $scope.displayMediaType = function (type) {
            $scope.mediaItem.mediaType = type.mediaType;
        };

        $http.get("/api/mediaType").then(function (results) {
            $scope.types = results.data;
        });

        var getAllMediaItems = function () {
            $http.get("/api/media").then(function (result) {
                $scope.mediaItems = result.data;
            });
        };

        getAllMediaItems();
        
    }
]);

