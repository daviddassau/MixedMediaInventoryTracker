app.controller("EditMedia", ["$scope", "$http", "$location", "$routeParams",
    function ($scope, $http, $location, $routeParams) {

        $scope.message = "Edit Media";

        $scope.mediaItem = {};
        $scope.mediaType = {};

        $http.get(`api/media/${$routeParams.id}`).then(function (result) {
            result.data.DatePurchased = new Date(result.data.DatePurchased);
            $scope.mediaItem = result.data;
        });

        $http.get("api/mediaType").then(function (result) {
            $scope.mediaType = result.data;
        });

        $scope.submitEditedMediaItem = function () {
            $http.put(`api/media/${$routeParams.id}`, $scope.mediaItem).then(function () {
                console.log(mediaItem);
            }).catch(function (error) {
                console.log("error in submitEditedMediaItem", error);
            });
        }



        //var editMediaItem = function (mediaItem) {
        //    return $http.put(`api/media/${id}`, mediaItem);
        //};

        //$scope.submitEditedMediaItem = function (mediaItem) {
        //    editMediaItem(mediaItem).then(function () {
        //        console.log(mediaItem);
        //        $location.path("/viewMedia");
        //    }).catch(function (error) {
        //        console.log(error);
        //    });
        //}

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

