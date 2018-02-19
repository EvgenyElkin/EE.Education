(function() {
    "use strict";

    angular
        .module("EducationApp")
        .directive("menu", menu);

    menu.$inject = ["$config", "$http"];

    function menu($config, $http) {
        return {
            restrict: "E",
            scope: {},
            templateUrl: "js/directives/menu/menu.tmpl.html",
            link: function($scope) {
                $scope.appname = $config.appname;
                $scope.menu = [];

                $http.get("/Task/GetAll")
                    .then(function(response) {
                        var tasks = response.data.items;
                        $scope.menu.push({
                            name: "Задачи",
                            groups: _.chain(tasks)
                                .groupBy(function(x) { return x.group; })
                                .each(function(group) {
                                    return {
                                        title: group[0].group,
                                        items: group
                                    };
                                })
                                .value()
                        });
                    });
            }
        };
    }
})();