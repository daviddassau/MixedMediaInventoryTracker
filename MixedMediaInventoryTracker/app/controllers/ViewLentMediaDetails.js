app.controller("ViewLentMediaDetails", ["$scope", "$http", "$location", "$routeParams", "moment", "toastr",
    function ($scope, $http, $location, $routeParams, moment, toastr) {

        $scope.message = "Lent Media Details";

        $scope.itemDetails = {};

        function getItemDetails() {
            $http.get(`api/lentmedia/lentMediaItemDetails/${$routeParams.id}`).then(function (result) {
                $scope.itemDetails = result.data;
            }).catch(function (error) {
                console.log("error in getItemDetails", error);
            });
        }

        getItemDetails();


        $scope.returnMedia = function () {
            $http.delete(`api/lentmedia/${$routeParams.id}`, $scope.itemDetails).then(function () {
                console.log($scope.itemDetails);
                toastr.success("The item has been added back to your inventory.", 'Congrats on getting your item back!');
                $location.path("/viewMedia");
            }).catch(function (error) {
                console.log("error in returnMedia", error);
            });
        }

    }
]);

