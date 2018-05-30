app.controller("CreateMedia", ["$scope", "$http", "$location",
    function ($scope, $http, $location) {

        $scope.message = "Add New Media Item";

        $scope.createMediaItem = {};

        var createNewMediaItem = function (mediaItem) {
            return $http.post("api/media", JSON.stringify(mediaItem));
        }

        $scope.submitForm = function () {

            var newMediaItem = {
                "mediaTypeId": $scope.createMediaItem.mediaTypeId,
                "mediaConditionId": $scope.createMediaItem.mediaConditionId,
                "title": $scope.createMediaItem.title,
                "datePurchased": $scope.createMediaItem.datePurchased,
                "isLentOut": $scope.createMediaItem.isLentOut,
                "notes": $scope.createMediaItem.notes
            };

            createNewMediaItem(newMediaItem).then(function () {
                $location.path("/viewMedia");
            }).catch(function (error) {
                console.log(error);
            });

        };

    }
]);