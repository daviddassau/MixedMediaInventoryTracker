app.controller("HomeController", ["$scope", "$http", "moment",
    function ($scope, $http, moment) {
        

        $http.get("/api/media/getRecentlyAdded").then(function (results) {
            $scope.mediaItems = results.data;
        });


        $http.get("api/media/chartMediaByType").then(function (results) {
            //console.log(results.data);

            $scope.labelsMediaType = [];
            $scope.dataMediaType = [];

            results.data.forEach(function (mediaType) {
                $scope.labelsMediaType.push(mediaType.MediaType);
                $scope.dataMediaType.push(mediaType.MediaCount);
            });
        }).catch(function (error) {
            console.log("error in get", error);
        });


        $http.get("api/media/chartMediaLentOut").then(function (results) {

            $scope.labelsLentOut = [];
            $scope.dataLentOut = [];

            results.data.forEach(function (lentItems) {
                //console.log(lentItems.LendeeName);
                //console.log(lentItems.Title);
                $scope.labelsLentOut.push(lentItems.MediaType);
                $scope.dataLentOut.push(lentItems.MediaCount);
            });
        }).catch(function (error) {
            console.log("error in lent media chart", error);
        });

    }
]);