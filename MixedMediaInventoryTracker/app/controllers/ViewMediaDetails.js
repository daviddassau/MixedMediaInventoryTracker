app.controller("ViewMediaDetails", ["$scope", "$http", "$location", "$routeParams", "moment",
    function ($scope, $http, $location, $routeParams, moment) {

        $scope.message = "Media Details";

        $scope.itemDetails = {};

        function getItemDetails() {
            $http.get(`api/media/${$routeParams.id}`).then(function (result) {
                $scope.itemDetails = result.data;
            }).catch(function (error) {
                console.log("error in getItemDetails", error);
            });
        }

        console.log(getItemDetails());

    }
]);

