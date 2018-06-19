app.controller("HomeController", ["$scope", "$http", "moment",
    function ($scope, $http, moment) {

        $scope.message = "Hello World";

        //$scope.labels = ["Download Sales", "In-Store Sales", "Mail-Order Sales"];
        //$scope.data = [300, 500, 100];

        $http.get("/api/media/getRecentlyAdded").then(function (results) {
            $scope.mediaItems = results.data;
        });

    }
]);