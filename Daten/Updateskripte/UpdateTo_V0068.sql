﻿-- Gegner erweitern
ALTER TABLE GegnerBase ADD Verbreitung nvarchar(1000)
GO
ALTER TABLE GegnerBase ADD Jagdreaktion nvarchar(1000)
GO
ALTER TABLE GegnerBase ADD Beute nvarchar(1000)
GO
ALTER TABLE GegnerBase ADD Auftreten nvarchar(1000)
GO
ALTER TABLE GegnerBase ALTER COLUMN GS DROP DEFAULT
GO
ALTER TABLE GegnerBase ALTER COLUMN GS float NOT NULL
GO
ALTER TABLE GegnerBase ALTER COLUMN GS2 float
GO
ALTER TABLE GegnerBase ALTER COLUMN GS3 float
GO
ALTER TABLE Gegner ALTER COLUMN GS DROP DEFAULT
GO
ALTER TABLE Gegner ALTER COLUMN GS float NOT NULL
GO
ALTER TABLE Gegner ALTER COLUMN GS2 float
GO
ALTER TABLE Gegner ALTER COLUMN GS3 float