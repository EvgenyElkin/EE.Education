;(function() {
    "use strict";

    angular
        .module("EducationApp")
        .controller("AccountLoginController", controller);

    controller.$inject = ["$http", "$location", "md5", "account"];
    
    function controller($http, $location, $md5, account) {
        var self = this;
        self.model = {};
        self.errorMessage = undefined;

        function handleAuthResponse(response) {
            if (!response.data.isSuccess) {
                self.model.message = response.data.message;
                return;
            }
            self.model.message = undefined;
            account.login(response.data.accessToken);
            $location.path("/");
        }

        self.login = function () {
            var data = {
                Email: self.model.email,
                PassHash: $md5.createHash(self.model.pass)
            };
            console.log(data);
            $http.post("/account/login", data).then(handleAuthResponse);
        }

        self.register = function () {
            if (self.model.pass !== self.model.confirmPass) {
                self.model.message = "Пароли не совпадают";
                return;
            }
            var data = {
                Email: self.model.email,
                PassHash: $md5.createHash(self.model.pass),
                FirstName: self.model.firstName,
                LastName: self.model.firstName,
                MiddleName: self.model.firstName
            };
            $http.post("/account/register", data).then(handleAuthResponse);
        }
    }
})();