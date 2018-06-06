app.controller("EditMedia", ["$scope", "$http", "$location", "$routeParams", "toastr",
    function ($scope, $http, $location, $routeParams, toastr) {

        $scope.message = "Edit Media";

        $scope.mediaItem = {};
        $scope.mediaType = {};
        $scope.mediaCondition = {};

        $http.get(`api/media/${$routeParams.id}`).then(function (result) {
            result.data.DatePurchased = new Date(result.data.DatePurchased);
            $scope.mediaItem = result.data;
            $scope.mediaItem.MediaConditionId = $scope.mediaItem.MediaConditionId.toString();
            $scope.mediaItem.MediaTypeId = $scope.mediaItem.MediaTypeId.toString();
        });

        $http.get("api/mediaType").then(function (result) {
            $scope.mediaType = result.data;
        });

        $http.get("api/mediaCondition").then(function (result) {
            $scope.mediaCondition = result.data;
        });

        $scope.submitEditedMediaItem = function () {
            $http.put(`api/media/${$routeParams.id}`, $scope.mediaItem).then(function () {
                toastr.success('Success!', 'You revised that item!');
                $location.path("/viewMedia");
            }).catch(function (error) {
                console.log("error in submitEditedMediaItem", error);
            });
        }

    }
]);

