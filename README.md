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

**Testing**

You can run front-end unit tests with `npm test:unit`.
