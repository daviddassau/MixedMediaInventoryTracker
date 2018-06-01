app.controller("ViewMedia", ["$scope", "$http", "$location", "$routeParams",
    function ($scope, $http, $location, $routeParams) {

        $scope.message = "My Media";

        $http.get("/api/media").then(function (results) {
            $scope.mediaItems = results.data;
        });

        $scope.editMediaItem = function (id) {
            $location.path(`/viewMedia/edit/${id}`);
        };
        
    }
]);

