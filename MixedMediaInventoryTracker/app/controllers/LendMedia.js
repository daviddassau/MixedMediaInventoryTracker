app.controller("LendMedia", ["$scope", "$http", "$location", "$routeParams", "toastr",
    function ($scope, $http, $location, $routeParams, toastr) {

        $scope.message = "Lend Media Item";

        $scope.lendMediaItem = {};
        $scope.items = {};

        $scope.selectMediaItem = function (item) {
            $scope.lendMediaItem.mediaId = item.mediaId;
        };

        $http.get("api/media/mediaItemToLend").then(function (results) {
            $scope.items = results.data;
        });

        //$scope.showMediaArt = function (movie) {
        //    $scope.lendMediaItem.artworkUrl100 = movie.artworkUrl100;
        //}

        var lendItem = function myfunction(lendMediaItem) {
            return $http.post("api/lentmedia", lendMediaItem);
        }

        $scope.submitLendMediaItem = function (lendMediaItem) {
            lendMediaItem.MediaId = lendMediaItem.Media.Id;
            lendItem(lendMediaItem).then(function () {
                toastr.success('You added that item to your lent items list!', 'Success!');
                $location.path("/viewLentMedia");
            }).catch(function (error) {
                console.log("error in submitLendMediaItem", error);
            });
        }

    }
]);