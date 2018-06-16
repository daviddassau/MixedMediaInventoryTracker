﻿app.controller("ViewMedia", ["$scope", "$http", "$location", "$routeParams", "moment", "toastr",
    function ($scope, $http, $location, $routeParams, moment, toastr) {

        $scope.message = "My Media";

        $http.get("/api/media").then(function (results) {
            $scope.mediaItems = results.data;

            var mediaTypeData = $scope.mediaItems.map(function (item) {
                return item.MediaType;
            });
            console.log(mediaTypeData);
            $scope.data = mediaTypeData;
        });

        $scope.viewMediaItemDetails = function (id) {
            $location.path(`/viewMedia/${id}`);
        }

        $scope.editMediaItem = function (id) {
            $location.path(`/viewMedia/edit/${id}`);
        };

        $scope.lendMediaItem = function (id) {
            $location.path(`/viewLentMedia/${id}`);
        }

        $scope.deleteMediaItem = function (id) {
            $location.path(`/viewMedia/delete/${id}`);
        };
        
    }
]);

