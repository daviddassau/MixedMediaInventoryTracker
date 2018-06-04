app.controller("MarkAsLent", ["$scope", "$http", "$location", "$routeParams",
    function ($scope, $http, $location, $routeParams) {

        $scope.message = "Mark this item as Lent";

        $scope.mediaItem = {};

        $http.get(`api/media/${$routeParams.id}`).then(function (result) {
            $scope.mediaItem = result.data;
        });

    }
]);