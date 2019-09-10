# WorkApp
Simple productivity app that I would like to use on my daily life. It has kanban board, todo and note taking features for now. Also I am planning to publish this app on the web free of charge.


It is not ready to use but I will be working on it.

### If you want to get it running locally, take these steps..
* This application requires ASP.NET Core 2.2 to be installed on your computer. If not so, please install it from [here.](https://dotnet.microsoft.com/download)
* Get the solution from github (clone or download)
* Change conntection strings in appsettings.json files in AspNetCoreMvc and Wpf projects, if needed. Note that this application uses Sql Server as its database.
* In the Package Manager Console set the Default Project to DataAcess and execute "Update-Database" command.
* Set the startup project as Wpf or AspNetMvc if needed.
* Build and run..

