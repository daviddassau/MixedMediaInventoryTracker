app.controller("MarkAsLent", ["$scope", "$http", "$location", "$routeParams",
    function ($scope, $http, $location, $routeParams) {

        $scope.message = "Mark this item as Lent";

        $http.get(`api/media/mediaItemToLend/${$routeParams.id}`).then(function (result) {
            $scope.mediaItem = result.data;
        });

        var markItemAsLent = function (mediaItem) {

        }

    }
]);