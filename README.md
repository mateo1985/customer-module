# customer-module
This is example of MVC application which contains one module loaded dynamically

This is the application for presenting possibilities of modularity in MVC. 
The module contains controller for backend methods to update/remove/add/get Customers.
This is only backend part for front-end part i would use Angular as another service.

To be able to run the project please do:
1) Run the script for LocalDB from the file ./local-db-database.sql
2) Change connection string in ./SimpleModularApplication/appsettings.json for your database
3) Run the command 'dotnet build' in the root folder
4) Go to folder ./SimpleModularApplication and run command 'dotnet run'

After this step you have your appliation up and running.
1) Get all users run the script 'get-all-users.sh' or run

`curl -X GET \
  http://localhost:[PORT]/Customer`
  
2) Put the user to database run the 'put-user.sh' or run

`curl -X PUT \
  http://localhost:[PORT]/Customer \
  -H 'content-type: application/json' \
  -d '{
	"Name": "ExampleName",
	"Surrname": "ExampleSurrname",
	"Telephone": "+481231231",
	"Address": "BoleslawaChrobrego 123"
}'`

3) Updating the user run 'update-user.sh' or run

`curl -X POST \
  http://localhost:[PORT]/Customer \
  -H 'content-type: application/json' \
  -d '{
	"Id": "50002",
	"Name": "User name",
	"Surrname": "Day",
	"Telephone": "+481231231",
	"Address": "Test address"
}'
`

4) Removing the user run the 'remove-user.sh' or
`curl -X DELETE \
  http://localhost:[PORT]Customer/Index/<id>`
  
  
TODO:
- Frontend application in Angular 5 with lazy module loading on the other hosting
- Some authorization
- Api versioning
- Additional unit testing