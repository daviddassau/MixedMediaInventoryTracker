app.controller("EditMedia", ["$scope", "$http", "$location", "$routeParams",
    function ($scope, $http, $location, $routeParams) {

        $scope.message = "Edit Media";

        $scope.editMediaItem = {};

        var getSingleMediaItem = function () {
            $http.get(`api/media/${$routeParams.id}`).then(function (result) {
                result.data.DatePurchased = new Date(result.data.DatePurchased);
                $scope.editMediaItem = result.data;
            });
        };

        console.log(getSingleMediaItem());
        getSingleMediaItem();

    }
]);

