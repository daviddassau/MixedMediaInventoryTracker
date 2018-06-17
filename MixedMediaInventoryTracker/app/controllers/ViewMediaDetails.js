app.controller("ViewMediaDetails", ["$scope", "$http", "$location", "$routeParams", "moment",
    function ($scope, $http, $location, $routeParams, moment) {

        $scope.message = "Media Details";

        $scope.itemDetails = {};

        function getItemDetails() {

            

            $http.get(`api/media/mediaItemDetails/${$routeParams.id}`).then(function (result) {

                var artistField = document.getElementById('artist');
                var authorField = document.getElementById('author');

                $scope.itemDetails = result.data;

                if ($scope.itemDetails.MediaTypeId > 3 && $scope.itemDetails.MediaTypeId < 9) {
                    artistField.style.display = "none";
                    authorField.style.display = "none";
                } else if ($scope.itemDetails.MediaTypeId >= 9) {
                    artistField.style.display = "none";
                }

            }).catch(function (error) {
                console.log("error in getItemDetails", error);
            });
        }

        getItemDetails();

        $scope.editMediaItem = function (id) {
            $location.path(`/viewMedia/edit/${id}`);
        };

    }
]);

