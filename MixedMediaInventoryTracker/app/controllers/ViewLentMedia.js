app.controller("ViewLentMedia", ["$scope", "$http", "$location", "moment",
    function ($scope, $http, $location, moment) {

        $scope.message = "Lent Media Items";

        $http.get("/api/lentmedia").then(function (results) {
            $scope.items = results.data;
        });

        $scope.viewLentItemDetails = function (id) {
            $location.path(`/viewLentMedia/details/${id}`);
        }

        $scope.viewMediaItemDetails = function (id) {
            $location.path(`/viewMedia/${id}`);
        }
    }
]);

