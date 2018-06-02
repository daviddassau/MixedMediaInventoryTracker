app.controller("DeleteMedia", ["$scope", "$http", "$location", "$routeParams",
    function ($scope, $http, $location, $routeParams) {

        $scope.mediaItem = {};

        $http.get(`api/media/${$routeParams.id}`).then(function (result) {
            $scope.mediaItem = result.data;
        });



    }
]);

