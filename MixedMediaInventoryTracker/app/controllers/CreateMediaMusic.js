app.controller("CreateMediaMusic", ["$scope", "$http", "$location", "$routeParams", "toastr",
    function ($scope, $http, $location, $routeParams, toastr) {

        $scope.message = "Add New Media Item";

        $scope.mediaType = {};

        function getMediaType() {
            $http.get(`api/mediaType/${$routeParams.id}`).then(function (result) {
                $scope.mediaType = result.data;
            }).catch(function (error) {
                console.log("error in getMediaType", error);
            });
        }

        getMediaType();



        $scope.itunesMedia = {};

        $scope.getMusicFromItunes = function (itunesMedia) {
            $http.get(`api/media/searchMusic/${itunesMedia.collectionName}`).then(function (results) {
                $scope.itunesMedia.results = results.data.results;
            }).catch(function (error) {
                console.log("error in getMusicFromItunes", error);
            });
        }

        $scope.selectMedia = function (music) {
            $scope.newMediaItem.Artist = music.artistName;
            $scope.newMediaItem.Title = music.collectionName;
            $scope.newMediaItem.artworkUrl100 = music.artworkUrl100;
        }



        $scope.newMediaItem = {
            mediaTypeId: $routeParams.id
        };
        $scope.conditions = {};

        $scope.selectMediaCondition = function (condition) {
            $scope.newMediaItem.mediaCondition = condition.mediaCondition;
        };

        $http.get("/api/mediaCondition").then(function (results) {
            $scope.conditions = results.data;
        });

        var createNewMediaItem = function (newMediaItem) {
            return $http.post("api/media", newMediaItem);
        }

        $scope.submitNewMediaItem = function (newMediaItem) {
            createNewMediaItem(newMediaItem).then(function () {
                toastr.success('Success!', 'You added that item to your lent items list!');
                $location.path("/viewMedia");
            }).catch(function (error) {
                console.log(error);
            });
        }

    }
]);