/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
   IF NOT EXISTS(SELECT * FROM t_User)
   BEGIN
    INSERT INTO t_User 
    (UserName, Password) Values ( 'test@mail.com' , '4kDYlBGZPdXSD9Tf4x/HQg==')
   END

   IF NOT EXISTS(SELECT * FROM t_Product)
   BEGIN
    INSERT INTO t_Product 
    (ProductName,ProductDescription,ImagePath,CategoryID,  ProductPrice)
    VALUES
    ('Cooking Pans','Non Stick Cooking Pans','images/kitchenware-1.jpg','1',10000.00),
    ('Dinnerset','24 Pc Dinnersets','images/kitchenware-2.jpg','1',5500.00),
    ('Kettle','1773 Kettle Design','images/kitchenware-3.jpg','1',1200.00),
    ('Grinder','Vegetable & Meat grinder','images/kitchenware-4.jpg','1',8500.00),
    ('Dinnerset','40 Pc Pocelein Dinnerset','images/kitchenware-5.jpg','1',14000.00);
   END


