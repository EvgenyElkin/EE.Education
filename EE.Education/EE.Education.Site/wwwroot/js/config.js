;(function() {
  angular
  	.module("EducationApp")
    .constant("$config", {
        appname: "Edu",
        menu: [
            {
                name: "Личный кабинет",
                url: "/account/view",
                icon: "user"
            },
            {
                name: "Задачи",
                url: "/task/registry",
                icon: "browser"
            },
            {
                name: "Уроки",
                url: "/lession/registry",
                icon: "file"
            }
        ]
    });
})();
