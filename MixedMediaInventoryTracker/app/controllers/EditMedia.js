app.controller("EditMedia", ["$scope", "$http", "$location", "$routeParams",
    function ($scope, $http, $location, $routeParams) {

        $scope.message = "Edit Media";

        $scope.editMediaItem = {};

        var getSingleMediaItem = function () {
            $http.get(`api/media/${$routeParams.id}`).then(function (result) {
                console.log(result);
                //result.data.MediaTypeId = new Date(result.data.MediaTypeId);
                //result.data.MediaConditionId = new Date(result.data.MediaConditionId);
                $scope.editMediaItem = result.data;
            });
        };

        console.log(getSingleMediaItem());
        getSingleMediaItem();

    }
]);

