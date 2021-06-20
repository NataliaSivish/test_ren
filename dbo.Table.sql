CREATE TABLE [dbo].[Office]
(
	[Id] INT IDENTITY PRIMARY KEY, 
    [Name] VARCHAR(255) NOT NULL, 
    [BeginTime] TIME NOT NULL, 
    [EndTime] TIME NOT NULL
)
