;(function() {
    "use strict";
    angular
        .module("EducationApp")
        .service("account", ["$sessionStorage", service]);
    
    function service($sessoinStorage) {
        var isAuthenticatedKey = "IsAuthenticated";
        var accessTokenKey = "AccessToken";

        var self = this;

        self.isAuthenticated = function () {
            return $sessoinStorage[isAuthenticatedKey];
        };

        self.getToken = function () {
            return $sessoinStorage[accessTokenKey];
        }

        self.login = function (token) {
            $sessoinStorage[accessTokenKey] = token; 
            $sessoinStorage[isAuthenticatedKey] = true;
        }

        self.logout = function () {
            $sessoinStorage[accessTokenKey] = undefined;
            $sessoinStorage[isAuthenticatedKey] = false;
        }

        return self;
    }
})();