var app = angular.module("MixedMediaInventoryTracker", ["ngRoute", "toastr", "angularMoment", "chart.js"]);

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
        .when("/chooseMediaType",
        {
            templateUrl: "/app/partials/chooseMediaType.html",
            controller: "ChooseMediaType"
        })
        .when("/createMedia/:id",
        {
            templateUrl: "/app/partials/createMedia.html",
            controller: "CreateMedia"
        })
        .when("/createMedia/music/:id",
        {
            templateUrl: "/app/partials/createMediaMusic.html",
            controller: "CreateMediaMusic"
        })
        .when("/createMedia/movies/:id",
        {
            templateUrl: "/app/partials/createMediaMovies.html",
            controller: "CreateMediaMovies"
        })
        .when("/createMedia/books/:id",
        {
            templateUrl: "/app/partials/createMediaBooks.html",
            controller: "CreateMediaBooks"
        })
        .when("/viewMedia/:id",
        {
            templateUrl: "/app/partials/viewMediaDetails.html",
            controller: "ViewMediaDetails"
        })
        .when("/viewLentMedia",
        {
            templateUrl: "/app/partials/viewLentMedia.html",
            controller: "ViewLentMedia"
        })
        .when("/viewLentMedia/details/:id",
        {
            templateUrl: "/app/partials/viewLentMediaDetails.html",
            controller: "ViewLentMediaDetails"
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
        .when("/viewSoldMedia/details/:id",
        {
            templateUrl: "/app/partials/viewSoldMediaDetails.html",
            controller: "ViewSoldMediaDetails"
        })
        .when("/sellMedia",
        {
            templateUrl: "/app/partials/sellMedia.html",
            controller: "SellMedia"
        })
        .when("/viewMedia/edit/:id",
        {
            templateUrl: "/app/partials/editMedia.html",
            controller: "EditMedia"
        })
        .when("/viewMedia/delete/:id",
        {
            templateUrl: "/app/partials/deleteMedia.html",
            controller: "DeleteMedia"
        });
}]);