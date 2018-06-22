app.controller("ViewSoldMediaDetails", ["$scope", "$http", "$location", "$routeParams", "moment",
    function ($scope, $http, $location, $routeParams, moment) {

        $scope.message = "Sold Media Details";

        $scope.itemDetails = {};

        function getItemDetails() {
            $http.get(`api/soldmedia/soldMediaItemDetails/${$routeParams.id}`).then(function (result) {

                var notesField = document.getElementById('notesSold');

                $scope.itemDetails = result.data;

                if ($scope.itemDetails.Notes == null) {
                    notesField.style.display = "none";
                }

            }).catch(function (error) {
                console.log("error in getItemDetails", error);
            });
        }

        getItemDetails();

    }
]);

