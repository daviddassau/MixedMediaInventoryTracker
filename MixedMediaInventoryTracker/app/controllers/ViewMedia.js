app.controller("ViewMedia", ["$scope", "$http", "$location",
    function ($scope, $http, $location) {

        $scope.message = "My Media";

        var getAllMediaItems = function () {
            $http.get("/api/media").then(function (result) {
                $scope.mediaItems = result.data;
            });
        };

        getAllMediaItems();
        
    }
]);

