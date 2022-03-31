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
# Trade-Offs
   -  *Data access* 
      - Chose a custom data access library instead of Entity Framework
      -  This will allow me to reuse the class in other projects 
      -  Database swap should it be required. Only implement IDataAccess with the new db.
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
-  Store API Endpoints in configuration file
-  Stote jwt in a more secure location and not localstorage
-  Implement refresh tokens
-  Improve password encryption function.
-  Refactor UserAuthentication service in StoreUI for better code reuse
# Contributing
 Just chat on mail.
# Lisence
This project's license is in review.
# Contact
Arthur Namu arthur.namu@gmail.com

