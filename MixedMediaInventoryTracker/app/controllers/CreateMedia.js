app.controller("CreateMedia", ["$scope", "$http", "$location",
    function ($scope, $http, $location) {

        $scope.message = "Add New Media Item";

        $scope.createMediaItem = {};

        $scope.submitForm = function () {

            var newMediaItem = {
                "mediaTypeId": $scope.createMediaItem.mediaTypeId,
                "mediaConditionId": $scope.createMediaItem.mediaConditionId,
                "title": $scope.createMediaItem.title,

            };

        };



        $scope.submitForm = function () {

            var newComputer = {
                "computermanufacturer": $scope.addcomputer.computermanufacturer,
                "computermake": $scope.addcomputer.computermake,
                "purchasedate": $scope.addcomputer.purchasedate
            };

            createNewComputer(newComputer).then(function () {
                $location.path("/computers");
            }).catch(function (error) {
                console.log(error);
            });

        };

    }
]);