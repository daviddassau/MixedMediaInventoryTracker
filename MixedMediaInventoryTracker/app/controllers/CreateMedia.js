app.controller("CreateMedia", ["$scope", "$http", "$location",
    function ($scope, $http, $location) {

        $scope.message = "Add New Media Item";

        $scope.newMediaItem = {};
        $scope.types = {};
        $scope.conditions = {};

        $scope.selectMediaType = function (type) {
            $scope.newMediaItem.mediaType = type.mediaType;
        };

        $scope.selectMediaCondition = function (condition) {
            $scope.newMediaItem.mediaCondition = condition.mediaCondition;
        };

        $http.get("/api/mediaType").then(function (results) {
            $scope.types = results.data;
        });

        $http.get("/api/mediaCondition").then(function (results) {
            $scope.conditions = results.data;
        });

        var createNewMediaItem = function (newMediaItem) {
            return $http.post("api/media", newMediaItem);
        }

        $scope.submitNewMediaItem = function (newMediaItem) {
            createNewMediaItem(newMediaItem).then(function () {
                console.log(newMediaItem);
                //$location.path("/viewMedia");
            }).catch(function (error) {
                console.log(error);
            });
        }

        $scope.viewMediaItems = function () {
            $location.path("/viewMedia");
        }

    }
]);