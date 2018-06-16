app.controller("HomeController", ["$scope",
    function ($scope) {

        $scope.message = "Hello World";

        $scope.labels = ["Download Sales", "In-Store Sales", "Mail-Order Sales"];
        $scope.data = [300, 500, 100];

    }
]);