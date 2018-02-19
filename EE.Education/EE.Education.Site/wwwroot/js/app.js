(function() {
  angular
    .module("EducationApp", ["ngRoute", "semantic-ui"])
    .config(config);
    
  config.$inject = ["$routeProvider", "$locationProvider", "$httpProvider"];
    
  function config($routeProvider, $locationProvider, $httpProvider) {

    $locationProvider.html5Mode(false);

    // routes
      $routeProvider
          .when("/",
              {
                  templateUrl: "js/pages/home/home.html",
                  controller: "HomeController",
                  controllerAs: "home"
              })
          .when("/tasks",
              {
                  templateUrl: "js/pages/tasks/tasks.html",
                  controller: "TasksController",
                  controllerAs: "tasks"
              })
          .otherwise({
              redirectTo: "/"
          });

    $httpProvider.interceptors.push("authInterceptor");
  }

  angular
    .module("EducationApp")
    .factory("authInterceptor", authInterceptor);

  authInterceptor.$inject = ["$rootScope", "$q", "$location"];

  function authInterceptor($rootScope, $q, $location) {

    return {

      // intercept every request
      request: function(config) {
        config.headers = config.headers || {};
        return config;
      },

      // Catch 404 errors
      responseError: function(response) {
        if (response.status === 404) {
          $location.path("/");
          return $q.reject(response);
        } else {
          return $q.reject(response);
        }
      }
    };
  }

  angular
    .module("EducationApp")
    .run(run);

  run.$inject = ["$rootScope", "$location"];

  function run($rootScope, $location) {
    // put here everything that you need to run on page load
  }
})();