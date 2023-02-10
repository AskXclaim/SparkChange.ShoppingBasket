# Spark Change shopping basket
## Summary
A demo shopping basket application for SparkChange, built using clean architecture.

### Introduction
This is a web api implementation of a ShoppingBasket feature based on the requirement provided.

### Setup & Running the project
Clone a copy of the project and run using your preferred IDE that can run .sln file 
e.g. JetBrain Rider, Visual Studio, Visual Studio code.
On cloning the repository to your local system, set the startup project to 'ShoppingBasket.Api' 
i.e. the web Api project and run. NB you may need to allow your IDE run as an administrator.

It would setup an in memory database used by the project. This would come pre-loaded with four items an their prices.
A summary of the four items are below:
Soup – $0.65 per tin, Bread – $0.80 per loaf, Milk – $1.15 per bottle, Apples – $1.00 per bag.

### Things to note
 - Each time you stop the application, it rests all the data back to its default - which is no items in the basket
 - At times you are required to fill in a currencyCode which is a three character [Iso-standard-code](https://en.wikipedia.org/wiki/ISO_4217) for currencies.
 - Though effort has been put in to making this application robust it is by no means production ready.