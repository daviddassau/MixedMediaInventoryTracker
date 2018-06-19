app.controller("HomeController", ["$scope", "$http", "moment",
    function ($scope, $http, moment) {

        $scope.labels = [];
        $scope.data = [];

        $http.get("/api/media/getRecentlyAdded").then(function (results) {
            $scope.mediaItems = results.data;
        });


        $http.get("api/media/chartMediaByType").then(function (results) {
            console.log(results.data);
            results.data.forEach(function (mediaType) {
                $scope.labels.push(mediaType.MediaType);
                $scope.data.push(mediaType.MediaCount);
            });
        }).catch(function (error) {
            console.log("error in get", error);
        });


        //$http.get("/api/lentmedia").then(function (results) {
        //    $scope.chartItems = results.data;

        //    console.log("get all lent media", $scope.chartItems);

        //    var lentMediaData = $scope.chartItems.map(function (item) {
        //        return item.Id;
        //    });
        //    console.log("lent media data", lentMediaData);
        //    $scope.labels = ["Lent out items"];
        //    $scope.data = [lentMediaData];
        //});

    }
]);