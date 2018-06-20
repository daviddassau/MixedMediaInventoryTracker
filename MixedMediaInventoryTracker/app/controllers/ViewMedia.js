app.controller("ViewMedia", ["$scope", "$route", "$http", "$location", "$routeParams", "moment", "toastr",
    function ($scope, $route, $http, $location, $routeParams, moment, toastr) {

        $scope.message = "My Media";

        $http.get("/api/media").then(function (results) {
            $scope.mediaItems = results.data;
        });

        $scope.viewMediaItemDetails = function (id) {
            $location.path(`/viewMedia/${id}`);
        };

        $scope.editMediaItem = function (id) {
            $location.path(`/viewMedia/edit/${id}`);
        };

        $scope.lendMediaItem = function (id) {
            $location.path(`/viewLentMedia/${id}`);
        };

        $scope.deleteMediaItem = function (id) {
            $http.delete(`api/media/${id}`).then(function () {
                toastr.error('Item deleted', 'You successfully deleted that item from your list.');
                $route.reload();
            }).catch(function (error) {
                console.log("error in deleteMediaItem", error);
            });
        };
        
    }
]);

