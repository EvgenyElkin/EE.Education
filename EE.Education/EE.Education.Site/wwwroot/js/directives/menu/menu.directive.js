(function() {
    "use strict";

    angular
        .module("EducationApp")
        .directive("menu", menu);

    menu.$inject = ["$config", "account", "$location"];

    function menu($config, account, $location) {
        return {
            restrict: "E",
            scope: {},
            templateUrl: "js/directives/menu/menu.tmpl.html",
            link: function($scope) {
                $scope.isAuthenticated = account.isAuthenticated;
                $scope.appname = $config.appname;
                $scope.menu = $config.menu;
                $scope.logout = function() {
                    account.logout();
                    $location.path("/account/login");
                };
            }
        };
    }
})();