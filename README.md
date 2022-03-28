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
# Dependencies
To be communicated in version 2.0.0.0
# Help
Help documentation will be published after the first release build (v. 1.0.0.0) is released.
# What if I had more time?
-  Under consideration
# Contributing
 Just chat on mail.
# Lisence
This project's license is in review.
# Contact
Arthur Namu arthur.namu@gmail.com

