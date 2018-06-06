app.controller("ViewLentMediaDetails", ["$scope", "$http", "$location", "$routeParams", "moment",
    function ($scope, $http, $location, $routeParams, moment) {

        $scope.message = "Lent Media Details";

        $scope.itemDetails = {};

        //function getItemDetails() {
        //    $http.get(`api/media/mediaItemDetails/${$routeParams.id}`).then(function (result) {
        //        $scope.itemDetails = result.data;
        //    }).catch(function (error) {
        //        console.log("error in getItemDetails", error);
        //    });
        //}

        //getItemDetails();

    }
]);

