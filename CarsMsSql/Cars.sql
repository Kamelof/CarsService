    CREATE TABLE [dbo].[Cars]
    (
	    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
        [ReleasDate] INT NOT NULL, 
        [Title] NVARCHAR(50) NOT NULL, 
        [Price] FLOAT NOT NULL, 
        [Weight] INT NOT NULL, 
        [ColorId] INT NOT NULL, 
        [CarBodyId] INT NOT NULL,
        CONSTRAINT FK_Color FOREIGN KEY (ColorId) REFERENCES Colors(Id),
        CONSTRAINT FK_CarBody FOREIGN KEY (CarBodyId) REFERENCES CarBodies(Id)
    )