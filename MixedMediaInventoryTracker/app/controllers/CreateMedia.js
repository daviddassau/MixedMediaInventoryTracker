app.controller("CreateMedia", ["$scope", "$http", "$location", "toastr",
    function ($scope, $http, $location, toastr) {

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
                toastr.success('Success!', 'You added that item to your lent items list!');
                $location.path("/viewMedia");
            }).catch(function (error) {
                console.log(error);
            });
        }

    }
]);