app.controller("SellMedia", ["$scope", "$http", "$location", "$routeParams",
    function ($scope, $http, $location, $routeParams) {

        $scope.message = "Sell Media Item";

        $scope.sellMediaItem = {};
        $scope.items = {};

        $scope.selectMediaItem = function (item) {
            $scope.sellMediaItem.mediaId = item.mediaId;
        };

        $http.get("api/media/mediaItemToSell").then(function (results) {
            $scope.items = results.data;
        });

        //var lendItem = function myfunction(lendMediaItem) {
        //    return $http.post("api/lentmedia", lendMediaItem);
        //}

        //$scope.submitLendMediaItem = function (lendMediaItem) {
        //    lendMediaItem.MediaId = lendMediaItem.Media.Id;
        //    lendItem(lendMediaItem).then(function () {
        //        $location.path("/viewLentMedia");
        //    }).catch(function (error) {
        //        console.log("error in submitLendMediaItem", error);
        //    });
        //}

    }
]);