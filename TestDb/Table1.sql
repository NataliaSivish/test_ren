/*
Число сегментов должно быть задано как примерно в два раза 
превышающее максимально ожидаемое количество уникальных значений в 
ключе индекса с округлением до ближайшего четного числа.
*/

CREATE TABLE [dbo].[Table1]
(
	[Id] INT NOT NULL PRIMARY KEY NONCLUSTERED HASH WITH (BUCKET_COUNT = 131072), 
    [Name] NCHAR(10) NULL
) WITH (MEMORY_OPTIMIZED = ON)

GO

/*
Не изменяйте переменные пути или имени базы данных.
Все переменные sqlcmd будут надлежащим образом 
подстановлены во время сборки и развертывания.
*/

ALTER DATABASE [$(DatabaseName)]
	ADD FILEGROUP [Table1_FG] CONTAINS MEMORY_OPTIMIZED_DATA