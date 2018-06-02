app.controller("DeleteMedia", ["$scope", "$http", "$location", "$routeParams",
    function ($scope, $http, $location, $routeParams) {

        $scope.mediaItem = {};

        $http.get(`api/media/${$routeParams.id}`).then(function (result) {
            console.log(result);
            $scope.mediaItem = result.data;
        });

        $scope.deleteMediaItem = function () {
            $http.delete(`api/media/${$routeParams.id}`).then(function () {
                $location.path("/viewMedia");
            }).catch(function (error) {
                console.log("error in deleteMediaItem", error);
            });
        }

    }
]);

