# TestExApp
Для запуска приложения потребутся:
SQL Server Express
Node.js package
Перед запуском web-api нужно обновить баху данных: запустить команду Update-Database в консоли диспетчера пакетов.
Для запуска проекта на ангуляр нужно выполнить следующие команды в папке Angular:
npm install
ng serve
После чего перейти по http://localhost:4200/.

На странице отображаются две таблицы:
сверху для добавления объектов, чуть ниже отображается спсиок сохранненых объектов.
Также добавлена пагинация. Размер страницы 5, кнопки для перехода по страницам появялются тогда, когда количетсво сохраненных объектов становится больще 5.
Чтобы добавить объекты в базу данных потребуется ввести значения и нажать кнопку "Add". Затем нужно нажатьь кнопку "Save".
