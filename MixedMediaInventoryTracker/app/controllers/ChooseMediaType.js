app.controller("ChooseMediaType", ["$scope", "$http", "$location", "$routeParams", "moment",
    function ($scope, $http, $location, $routeParams, moment) {

        $scope.message = "Choose The Media Type";
        
        $http.get("/api/mediaType").then(function (results) {
            $scope.mediaTypes = results.data;
        });

        $scope.chooseMediaType = function (id) {
            if (id <= 3) {
                $location.path(`/createMedia/music/${id}`);
            } else
                $location.path(`/createMedia/${id}`);
            
        };

    }
]);

