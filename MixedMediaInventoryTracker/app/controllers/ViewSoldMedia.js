app.controller("ViewSoldMedia", ["$scope", "$http", "$location",
    function ($scope, $http, $location) {

        $scope.message = "Sold Media Items";

        $http.get("api/soldmedia").then(function (results) {
            $scope.items = results.data;
        });

        $scope.viewSoldItemDetails = function (id) {
            $location.path(`/viewSoldMedia/details/${id}`);
        }

    }
]);

