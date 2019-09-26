CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [OrderName] NVARCHAR(500) NOT NULL, 
    [CreateDate] DATETIME NOT NULL, 
    [Status] INT NOT NULL
)
