# FleetManager-csharp

Done as an exercise in summer 2019.

Supports adding, editing and deleting a car, 
getting info of a spesific car, all of the cars, cars by model year, cars by make and cars by model.

Database can be initialized with seed-data from car.csv file with the following command:
```
mongoimport -d <database> -c <collection name> --type csv --file <path to csv> --headerline
```

## Built with
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/#pivot=entityfmwk) - The framework used
* [MongoDB](https://www.mongodb.com/) - The database used


## How to run the application

In Microsoft Visual Studio: open the application and click "FleetManager.sln", change "Eatech.FleetManager.Web" to be the start up project. Then the application can be build.

appsettings.json includes the info of connection, database name (FleetManagerDB) and collection name (Cars).


## How to test the application

### PostMan sample requests

https://www.getpostman.com/collections/9a53f4b3caf6a6575cdb

### Swagger documentation

`<base address>`

Now: http://localhost:57540/


## 

###### TODO: Edit and add unit tests
