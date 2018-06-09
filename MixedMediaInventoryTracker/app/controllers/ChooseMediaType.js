app.controller("ChooseMediaType", ["$scope", "$http", "$location", "$routeParams", "moment",
    function ($scope, $http, $location, $routeParams, moment) {

        $scope.message = "Choose The Media Type";



        //$http.get("/api/media").then(function (results) {
        //    $scope.mediaItems = results.data;
        //});

        //$scope.viewMediaItemDetails = function (id) {
        //    $location.path(`/viewMedia/${id}`);
        //}

        //$scope.editMediaItem = function (id) {
        //    $location.path(`/viewMedia/edit/${id}`);
        //};

        //$scope.lendMediaItem = function (id) {
        //    $location.path(`/viewLentMedia/${id}`);
        //}

        //$scope.deleteMediaItem = function (id) {
        //    $location.path(`/viewMedia/delete/${id}`);
        //};

    }
]);

