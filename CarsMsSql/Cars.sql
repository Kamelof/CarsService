    CREATE TABLE [dbo].[Cars]
    (
	    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
        [ReleasDate] INT NOT NULL, 
        [Title] NVARCHAR(50) NOT NULL, 
        [Price] FLOAT NOT NULL, 
        [Weight] INT NOT NULL, 
        [ColorId] NVARCHAR(50) NOT NULL, 
        [CarBodyId] NVARCHAR(50) NOT NULL,
        CONSTRAINT FK_Color FOREIGN KEY (ColorId) REFERENCES Colors(Title),
        CONSTRAINT FK_CarBody FOREIGN KEY (CarBodyId) REFERENCES CarBodies(Title)
    )