app.controller("Modal", ["$scope", "$http", "$location", "$uibModal",
    function ($scope, $http, $location, $uibModal) {

        $scope.launchCreateMediaModal = (template, controller) => {
            
            var modalInstance = $uibModal.open({
                templateUrl: template,
                controller: controller,
                scope: $scope,
            });
            
        };

    }
]);