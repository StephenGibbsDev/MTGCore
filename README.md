# MTGCore

**First time set-up**

Download:
https://nodejs.org/en/download/

After cloning the project and downloading Node.js, navigate to the `ClientApp` directory with the `package.json` file and run `npm ci`. The path to this directory should be the following:

`...\MTGCore\src\MTGCore.ClientApp\ClientApp`

`npm ci` will perform a clean install, installing all of the dependencies you need for the Vue front-end of the project to work as expected.

**Running the project**

In the `ClientApp` directory, run `npm run serve`. This will run `vue-cli-service serve`, creating a dev server at `localhost:8080' and watching for changes. You can now access the front-end of the app.

To run the backend, run the `MTGCore.Proxy` and `MTGCore` projects in tandem.

In MS Visual Studio, this can be done by right clicking on the solution and then `Set Startup Projects...`. You should check `Multiple startup projects` and then set both `MTGCore` and `MTGCore.Proxy` to `Start`.

**Debugging**

If you encounter an issue with the frontend not working as expected and are running the project locally, you can debug by placing breakpoints in the backend to see if they are hit and also using developer tools packaged with most browsers.

E.G. In Firefox, the JS Console is handy for viewing frontend errors and you can use the Network tab to check if the front-end is successfully calling the backend - or if an invalid status code is being returned.

**Migrations**

This project is built using a code first approach with EF Core. The classes modelling the DB tables are in `MTGCore.Repository/Models`. Everytime a table model is changed, a migration has to be created and the database updated. These migrations are stored in `MTGCore.Repository/Models` and make it possible to rollback database changes.

You can run a migration either in the VS package manager console or by using the .NET Core CLI. You may have to specify which project the context exists in. The following is how you can create a migration in package manager:

`Add-Migration {MigrationName} -OutputDir {OutputDirectory} -Project {ProjectPath}`

You can update the database from your migrations by using the following command in PM:

`Update-Database`

More information on EF Core code first can be found here: https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=vs

**Testing**

You can run front-end unit tests with `npm test:unit`.

Backend unit tests can be run by right clicking on the `MTGCore.Tests` project and selecting `Run Unit Tests`.
