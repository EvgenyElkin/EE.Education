;(function() {
  angular
  	.module("EducationApp")
    .constant("$config", {
        appname: "Edu",
        menu: [
            {
                name: "Личный кабинет",
                url: "accountView",
                icon: "user"
            },
            {
                name: "Задачи",
                url: "taskRegistry",
                icon: "browser"
            },
            {
                name: "Уроки",
                url: "lessionRegistry",
                icon: "file"
            }
        ]
    });
})();
