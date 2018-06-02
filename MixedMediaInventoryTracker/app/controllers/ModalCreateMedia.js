app.controller("ModalCreateMedia", ["$scope", "$http", "$location",
    function ($scope, $http, $location) {

        $scope.viewMediaItems = function () {
            $location.path("/viewMedia");
        }

    }
]);