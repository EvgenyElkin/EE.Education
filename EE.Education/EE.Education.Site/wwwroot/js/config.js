;(function() {
  angular
  	.module("EducationApp")
    .constant("$config", {
        appname: "Протоколы",
        menu: [
            {
                title: "Задачи",
                url: "tasks",
                icon: "browser", 
                items: [    
                    { name: "Задача 1" },
                    { name: "Задача 1" },
                    { name: "Задача 1" }
                ]
            },
            {
                title: "Настройки",
                url: "settings",
                icon: "setting", 
                items: [
                    { name: "Настройка 1" },
                    { name: "Настройка 1" },
                    { name: "Настройка 1" }
                ]
            }
        ]
    });
})();
