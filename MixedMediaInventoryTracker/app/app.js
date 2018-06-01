var app = angular.module("MixedMediaInventoryTracker", ["ngRoute"]);

app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider.when("/",
        {
            templateUrl: "/app/partials/index.html",
            controller: "HomeController"
        })
        .when("/viewMedia",
        {
            templateUrl: "/app/partials/viewMedia.html",
            controller: "ViewMedia"
        })
        .when("/viewLentMedia",
        {
            templateUrl: "/app/partials/viewLentMedia.html",
            controller: "ViewLentMedia"
        })
        .when("/viewSoldMedia",
        {
            templateUrl: "/app/partials/viewSoldMedia.html",
            controller: "ViewSoldMedia"
        })
        .when("/createMedia",
        {
            templateUrl: "/app/partials/createMedia.html",
            controller: "CreateMedia"
        });
}]);