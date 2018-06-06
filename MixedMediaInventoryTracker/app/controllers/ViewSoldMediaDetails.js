app.controller("ViewSoldMediaDetails", ["$scope", "$http", "$location", "$routeParams", "moment",
    function ($scope, $http, $location, $routeParams, moment) {

        $scope.message = "Sold Media Details";

        $scope.soldItemDetails = {};

        function getItemDetails() {
            $http.get(`api/soldmedia/soldMediaItemDetails/${$routeParams.id}`).then(function (result) {
                $scope.soldItemDetails = result.data;
            }).catch(function (error) {
                console.log("error in getItemDetails", error);
            });
        }

        getItemDetails();

    }
]);

