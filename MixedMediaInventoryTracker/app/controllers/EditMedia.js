app.controller("EditMedia", ["$scope", "$http", "$location", "$routeParams",
    function ($scope, $http, $location, $routeParams) {

        $scope.message = "Edit Media";

        $scope.mediaItem = {};

        $http.get(`api/media/${$routeParams.id}`).then(function (result) {
            result.data.DatePurchased = new Date(result.data.DatePurchased);
            $scope.mediaItem = result.data;
        });

        //var getSingleMediaItem = function () {
        //    $http.get(`api/media/${$routeParams.id}`).then(function (result) {
        //        result.data.DatePurchased = new Date(result.data.DatePurchased);
        //        $scope.editMediaItem = result.data;
        //    });
        //};

        //console.log(getSingleMediaItem());
        //getSingleMediaItem();

    }
]);

