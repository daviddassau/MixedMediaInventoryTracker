app.controller("ViewLentMedia", ["$scope", "$http", "$location",
    function ($scope, $http, $location) {

        $scope.message = "Lent Media Items";

        $http.get("/api/lentmedia").then(function (results) {
            $scope.lentMediaItems = results.data;
        });

    }
]);

