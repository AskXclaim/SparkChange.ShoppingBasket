# Spark Change shopping basket
## Summary
A demo shopping basket application for SparkChange, built using clean architecture.

### Introduction
This is a web Api implementation of a ShoppingBasket feature based on the requirement provided.

### Setup & Running the project
Clone a copy of the project and run using your preferred IDE that can run .sln files
e.g., JetBrain Rider, Visual Studio, Visual Studio code.
On cloning the repository to your local system, set the start-up project to 'ShoppingBasket.Api'
i.e., the web Api project and run. NB you may need to allow your IDE to run as an administrator.

It would set up an in-memory database used by the project. This would come pre-loaded with four items and their prices.
A summary of the four items is below:
Soup – $0.65 per tin, Bread – $0.80 per loaf, Milk – $1.15 per bottle, Apples – $1.00 per bag.

### Things to note
- Each time you stop the application, it rests all the data back to its default - which is no items in the basket
- At times you are required to fill in a currency code which is a three-character [Iso-standard-code](https://en.wikipedia.org/wiki/ISO_4217) for currencies.
- When asked for a BasketKey you can use alphabetical character and though not case sensitive, each item you add to the Basket is 
linked to a BasketKey, with the BasketKey needed to access the Basket.
- This project uses the middleware approach to deal with error handling,
- Though effort has been put into making this application robust it is by no means production ready.
