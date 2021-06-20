CREATE TABLE [dbo].[Office]
(
	[Id] INT IDENTITY PRIMARY KEY, 
    [Name] VARCHAR(255) NOT NULL,
	[BeginTime] time(7) NOT NULL,
	[EndTime] time(7) NOT NULL,
)
