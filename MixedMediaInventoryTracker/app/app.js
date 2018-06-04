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
        .when("/viewLentMedia/:id",
        {
            templateUrl: "/app/partials/markAsLent.html",
            controller: "MarkAsLent"
        })
        .when("/lendMedia",
        {
            templateUrl: "/app/partials/lendMedia.html",
            controller: "LendMedia"
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
        })
        .when("/viewMedia/edit/:id",
        {
            templateUrl: "/app/partials/editMedia.html",
            controller: "EditMedia"
        });
}]);