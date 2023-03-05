# HealthEquity
##############

CODE CHALLENGE
======================================
C#/Razor

You have a model that is a car. You want to define its make, model, year, doors, colors, price. Build a simple service that contains some basic
CRUD operations against a list of cars:

private List<Car> cars = new (){

new Car { Id = 1, Make = "Audi", Model = "R8", Year = 2018, Doors = 2, Color = "Red", Price = 79995 },
new Car { Id = 2, Make = “Tesla", Model = “3", Year = 2018, Doors = 4, Color = "Black", Price = 54995 },
new Car { Id = 3, Make = "Porsche", Model = " 911 991", Year = 2020, Doors = 2, Color = "White", Price = 155000 },
new Car { Id = 4, Make = "Mercedes-Benz", Model = "GLE 63S", Year = 2021, Doors = 5, Color = "Blue", Price = 83995 },
new Car { Id = 5, Make = "BMW", Model = "X6 M", Year = 2020, Doors = 5, Color = "Silver", Price = 62995 },
};

Build a simple page markup with where you display the car information and allow the user to guess the price. If within 5,000 of the guess, display a great job message
in green.

#########################################################################################################################

SQL SERVER EXERCISE
======================================
SQL
You have three different tables:

  A Customer Table with FirstName, LastName, Age, Occupation, MartialStatus, PersonID

  An Orders Table with OrderID, PersonID, DateCreated, MethodofPurchase
  
  An Orders Details table with OrderID, OrderDetailID, ProductNumber, ProductID, ProductOrigin
--------------------------------------
Please return a result of the customers who ordered product ID = 1112222333 and return
FirstName and LastName as full name, age, orderid, datecreated, MethodOfPurchase as Purchase Method, ProductNumber and ProductOrigin


SOLUTION
--------------------------------------
SELECT DISTINCT CONCAT(FIRST_NAME,' ',LAST_NAME) 'Full Name', age, OrderID, DateCreated, MethodOfPurchase as Purchase Method, ProductNumber , ProductOrigin
  FROM Customer C
  
INNER JOIN Orders O 
  
ON O.PersonId = C.PersonID
  
INNER JOIN OrdersDetail OD
  
ON OD.OrderId = O.OrderID
  
WHERE ProductId = 1112222333
