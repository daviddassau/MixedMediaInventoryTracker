﻿app.controller("ViewSoldMediaDetails", ["$scope", "$http", "$location", "$routeParams", "moment",
    function ($scope, $http, $location, $routeParams, moment) {

        $scope.message = "Sold Media Details";

        //$scope.itemDetails = {};

        //function getItemDetails() {
        //    $http.get(`api/lentmedia/lentMediaItemDetails/${$routeParams.id}`).then(function (result) {
        //        $scope.itemDetails = result.data;
        //    }).catch(function (error) {
        //        console.log("error in getItemDetails", error);
        //    });
        //}

        //getItemDetails();

    }
]);

