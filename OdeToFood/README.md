# ASP .Net Core Fundamentals Project

## OdeToFood

<p>This is the main project</p>

# Prepare the Database and App for Production

In SQL Management Studio go to **Logins** and create a new user **IIS AppPool\OdeToFood**

In the properties of the new user go to **Server Roles** and check the **dbcreator** option.

To create the database connection string to the main client application create new **appsettings.Production.json** <br/>
file and set the production database connection string and publish the App.

# Publish App
To publish the application in a folder **dotnet publish -o c:\temp\odetofood --self-contained -r win-x64** 

# GitHub

GitHub URL https://github.com/Ulysses31/react-tasks-mern.git

# Contact Me

You can contact me for any help at <a href="mailto:iordanidischr@gmail.com">iordanidischr@gmail.com</a>

