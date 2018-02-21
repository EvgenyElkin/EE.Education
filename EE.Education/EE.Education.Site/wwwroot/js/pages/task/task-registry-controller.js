;(function() {
    "use strict";

    angular
        .module("EducationApp")
        .controller("TaskRegistryController", controller);

  controller.$inject = ["$timeout", "$http"];

  function controller($timeout, $http) {
      var self = this;
      $timeout(function() {
          $http.get("/Task/GetAll")
              .then(function(response) {
                  self.tasks = response.data.items;
              });
      });
  }
})();