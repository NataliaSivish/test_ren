CREATE TABLE [dbo].[TimeSlot]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [BeginTime] TIME NOT NULL, 
    [EndTime] TIME NOT NULL, 
    [Date] DATE NOT NULL, 
    [OfficeId] INT NOT NULL, 
    CONSTRAINT [FK_TimeSlot_ToTable] FOREIGN KEY (OfficeId) REFERENCES Office (Id)
)
