;(function() {
    "use strict";

    angular
        .module("EducationApp")
        .controller("HomeController", controller);

  controller.$inject = ["$config"];

  function controller($config) {
      var self = this;
      self.test = $config.APP_NAME;
  }
})();