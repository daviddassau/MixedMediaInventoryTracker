app.controller("ViewLentMedia", ["$scope", "$http", "$location", "moment",
    function ($scope, $http, $location, moment) {

        $scope.message = "Lent Media Items";

        $scope.date = new moment();

        $http.get("/api/lentmedia").then(function (results) {
            $scope.items = results.data;
        });

    }
]);

