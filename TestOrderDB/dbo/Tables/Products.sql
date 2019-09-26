CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductName] NVARCHAR(500) NOT NULL, 
    CONSTRAINT [AK_Products_ProductName] UNIQUE ([ProductName])
)
