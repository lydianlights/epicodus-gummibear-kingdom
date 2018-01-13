# Gummi Bear Kingdom Product Site

#### _Code review project for Epicodus .NET week 1_

#### _**By Rane Fields**_

## Description

This app allows an administrator to manage the Gummi Bear Kingdom's product site using a web-based interface

## Setup/Installation Requirements

* Clone the project using this link: `https://gitlab.com/lydianlights-epicodus/dotnet/gummibear-kingdom.git`
* Install `.NET Core 1.1`. You can get it  [here](https://github.com/dotnet/core/blob/master/release-notes/download-archives/1.1.4-download.md).
* A mySQL server is required for this project. If you have no mySQL server environment on your computer, you can get MAMP [here](https://www.mamp.info/en/downloads/).
* Configure your server to listen on port 8889 and start it.
* Open the main project directory `./GummiBearKingdom` using terminal or powershell.
* Run `$ dotnet restore` to fetch the project dependencies.
* Run `$ npm install` to fetch the project node packages.
* Run `$ dotnet ef database update --context GummiBearKingdomContext` to build the project database.
* Run `$ dotnet run` to start the server.

## Running Tests

* Open the main project directory `./GummiBearKingdom` using terminal or powershell.
* Run `$ dotnet restore` to fetch the project dependencies.
* Run `$ npm install` to fetch the project node packages.
* Run `$ dotnet ef database update --context GummiBearKingdomContext` to build the project database.
* Run `$ dotnet ef database update --context TestGummiBearKingdomContext` to build the test database.
* Open the testing directory `./GummiBearKingdomTests`
* Run `$ dotnet restore` to fetch the test dependencies.
* Run `$ dotnet test` to start the tests.

## Technologies Used

* This project is powered by [ASP .NET Core v1.1.2](https://docs.microsoft.com/en-us/aspnet/core/).
* This project uses [Entity Framework Core v1.1.2](https://github.com/aspnet/EntityFrameworkCore) as an ORM database manager.

## Known Bugs

* No input validation.
* Product list breaks completely if any product values are null.
* No confirmation when deleting data from database.

## License

*This page is hereby released as public domain. No permission necessary for modification and distribution.*

Copyright (c) 2018 **_Rane Fields_**
