# Description
A simple e-commerce site showcasing user signup and login, product listing, Add to cart, simplified checkout persisting the information in a database.
# Requirements
-  User registration (Register with an email address and password and confirm password),
-  User login (with an email address and password)
-  Display a list of products (show product image, product name, price and quantity)
-  Add to cart button next to each product
-  View shopping cart (show the product, quantity and price with a Total value of all the products selected)
-  Checkout button (send an email to the logged-in users' email address with all the products they have purchased with an order number)
-  Store user information in a database as well as the products purchased for each user
against an order number.
# Roadmap
##  User Authentication  
1. Create 3 projects 
   -  Data library
   -  WebAPI
   -  User Interface
2. Setup Data Access register & login for users.
   -  Create a database
      -  Users: UserID, Username, password
   -  Database user services to be injected into the webApi
   -  Create User controller and add register & login endpoints
   -  Setup jwt authentication.
3. Configure swagger documentation in web api for tests
4. Setup Login and Register in user interface
   -  Create http factory
   -  Create  a login service to call the web api.
   -  Create page layouts for login and register
   -  Inject login service and call the API.
##  Shop or Catalogue
 1.  Create Product table (ProductName, ProductDescription, Price, ImagePath)
   -  Add DataAccess stored procedure and DAL services in DataAccess Library to inject to Product
   -  Create API Endpoints to support(Create/GetAll/GetByID)
   -  Create Front-end service to call the endpoint
   -  Create a catalogue page to display the products and inject front-end services
##  Order
   -  Create order table(OrderID, OrderDate, Customer)
   -  Create OrderDetails table
   -  Create stored procedures and Data access Services in DataAccess Library
   -  Create add button which will add products to a cart
   -  Create a cart page, Send Email function and call relevant APIs
##  Create Integration Test for the APIs
   -  Create product integration tests
   -  Ensure its authenticating the user.

# Trade-Offs
   -  *Data access* 
      -  Chose a custom data access library instead of Entity Framework
      -  This will allow me to reuse the class in other projects 
      -  Database swap should it be required. Only implement IDataAccess with the new db.
   -  *API Paradigm*
      -  RESTful APIs and not RPCs / GraphQL
      -  Its because they are easy to build and maintain 
      -  Standardized method names, arguments and status codes 
   -  *Authentication* 
      -  Chose custom authentication a instead of out-of-the-box   
      -  Much as it would take more time, I needed to be in control
      -  I needed it as a customizable template for future projects
      -  It was a great leaning process.
# Dependencies
To be communicated in version 2.0.0.0
# Help
Help documentation will be published after the first release build (v. 1.0.0.0) is released.
# What if I had more time?
-  Stote jwt in protected storage and not localstorage
-  Implement refresh tokens
-  Improve password encryption function.
-  Refactor UserAuthentication service in StoreUI for better code reuse
-  Extend integration tests to cover all other endpoints

# Contributing
 Just chat on mail.
# Lisence
This project's license is in review.
# Contact
Arthur Namu arthur.namu@gmail.com

