IF $(IsTest) = 1
BEGIN
	DELETE FROM OrderDetails
	DELETE FROM Products
	DELETE FROM Orders

	SET IDENTITY_INSERT Products ON
	INSERT INTO Products(Id, ProductName) VALUES(1, N'Product #1'), (2, N'Product #2'), (3, N'Product #3'), (4, N'Product #4')
	SET IDENTITY_INSERT Products OFF

	SET IDENTITY_INSERT Orders ON
	INSERT INTO Orders(Id, OrderName, CreateDate, Status) VALUES(1, N'Order #1', '2017-01-01T15:48:00', 0), (2, N'Order #2', '2018-02-01', 1)
	SET IDENTITY_INSERT Orders OFF

	INSERT INTO OrderDetails(OrderId, ProductId, Quantity, Price) VALUES(1, 1, 3, 300), (1, 2, 2, 200), (1, 4, 2, 340), (2, 1, 5, 200), (2, 2, 2, 200), (2, 2, 2, 400), (2, 4, 3, 500), (2, 3, 6, 200)
END