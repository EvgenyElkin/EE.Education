(function() {
    "use strict";

    angular
        .module("EducationApp")
        .directive("menu", menu);

    menu.$inject = ["$config"];

    function menu($config) {
        return {
            restrict: "E",
            scope: {},
            templateUrl: "js/directives/menu/menu.tmpl.html",
            link: function($scope) {
                $scope.appname = $config.appname;
                $scope.menu = $config.menu;
            }
        };
    }
})();