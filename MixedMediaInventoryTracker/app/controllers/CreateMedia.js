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
                $location.path("/viewMedia");
            }).catch(function (error) {
                console.log(error);
            });
        }

        //$scope.createMediaItem = {};

        //var createNewMediaItem = function (mediaItem) {
        //    return $http.post("api/media", JSON.stringify(mediaItem));
        //}

        //$scope.submitForm = function () {

        //    var newMediaItem = {
        //        "mediaTypeId": $scope.createMediaItem.mediaTypeId,
        //        "mediaConditionId": $scope.createMediaItem.mediaConditionId,
        //        "title": $scope.createMediaItem.title,
        //        "datePurchased": $scope.createMediaItem.datePurchased,
        //        "isLentOut": $scope.createMediaItem.isLentOut,
        //        "notes": $scope.createMediaItem.notes
        //    };

        //    createNewMediaItem(newMediaItem).then(function () {
        //        $location.path("/viewMedia");
        //    }).catch(function (error) {
        //        console.log(error);
        //    });

        //};

    }
]);