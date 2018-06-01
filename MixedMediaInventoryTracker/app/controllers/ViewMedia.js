app.controller("ViewMedia", ["$scope", "$http", "$location",
    function ($scope, $http, $location) {

        $scope.message = "My Media";

        $http.get("/api/media").then(function (results) {
            $scope.mediaItems = results.data;
        });
        
    }
]);

