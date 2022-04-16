CREATE VIEW [dbo].[vw_CompleteOrder]
	AS 
	SELECT [o].[OrderID], [o].[Customer], [o].[OrderDate], [o].[TotalValue], [ol].[OrderListID], 
	[ol].[ProductID], [ol].[Quantity], [ol].[ProductPrice], [ol].[TotalItemPrice]
	from dbo.t_Order o
	LEFT JOIN  dbo.t_OrderList ol on o.OrderID = ol.OrderID
