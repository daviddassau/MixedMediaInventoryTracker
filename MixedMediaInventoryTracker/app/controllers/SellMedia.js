app.controller("SellMedia", ["$scope", "$http", "$location", "$routeParams", "toastr",
    function ($scope, $http, $location, $routeParams, toastr) {

        $scope.message = "Sell Media Item";

        $scope.sellMediaItem = {};
        $scope.items = {};

        $scope.selectMediaItem = function (item) {
            $scope.sellMediaItem.mediaId = item.mediaId;
        };

        $http.get("api/media/mediaItemToSell").then(function (results) {
            $scope.items = results.data;
        });

        var sellItem = function myfunction(sellMediaItem) {
            return $http.post("api/soldmedia", sellMediaItem);
        }

        $scope.submitSoldMediaItem = function (sellMediaItem) {
            sellMediaItem.MediaId = sellMediaItem.Media.Id;
            sellItem(sellMediaItem).then(function () {
                toastr.success('Success!', 'You sold that item.');
                $location.path("/viewSoldMedia");
            }).catch(function (error) {
                console.log("error in submitSoldMediaItem", error);
            });
        }

    }
]);