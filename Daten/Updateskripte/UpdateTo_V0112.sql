﻿-- Modifikatoren für abgeleitete Werte auftrennen
ALTER TABLE [Held] ADD [LE_ModGen] int DEFAULT 0;
ALTER TABLE [Held] ADD [LE_ModZukauf] int DEFAULT 0;
ALTER TABLE [Held] ADD [AU_ModGen] int DEFAULT 0;
ALTER TABLE [Held] ADD [AU_ModZukauf] int DEFAULT 0;
ALTER TABLE [Held] ADD [AE_ModGen] int DEFAULT 0;
ALTER TABLE [Held] ADD [AE_ModZukauf] int DEFAULT 0;
ALTER TABLE [Held] ADD [AE_pAsP] int DEFAULT 0;
ALTER TABLE [Held] ADD [KE_ModGen] int DEFAULT 0;
ALTER TABLE [Held] ADD [KE_ModZukauf] int DEFAULT 0;
ALTER TABLE [Held] ADD [KE_pKaP] int DEFAULT 0;

-- TODO: Mod-Werte auf neue Felder verteilen
-- [LE_ModGen] = Wert nach Rasse setzen und [LE_Mod] reduzieren
-- [LE_Mod] modifizieren um VN: Hohe Lebenskraft (+1 LeP pro Stufe; max. 6), Niedrige Lebenskraft (-1 LeP pro Stufe; max. 6)

-- [AU_ModGen] = Wert nach Rasse setzen und [AU_Mod] reduzieren
-- [AU_Mod] modifizieren um VN: Ausdauernd (+2 AuP pro Stufe; max. 3 Stufen, also 6 AuP), Kurzatmig (-2 AuP pro Stufe; max. 3 Stufen, also 6 AuP)

-- [AE_Mod] modifizieren um VN: Vollzauberer (+12 AsP), Halbzauberer (+6 AsP), Viertelzauberer (-6 AsP), Zauberhaar (+7 AsP), Astralmacht (+1 AsP pro Stufe; max. 6), Niedrige Astralkraft (-1 AsP pro Stufe; max. 6)
-- [KE_Mod] modifizieren um Vorteil Geweiht [zwölfgöttliche Kirche/H'Ranga/Angrosch/Gravesh/Xo'Artal-Stadtpantheon]; SF Spätweihe Alveranische Gottheit/Spätweihe Namenloser/Spätweihe (Xo'Artal-Pantheon)/Spätweihe (Xo'Artal-Pantheon) (+24 KaP), 
--				Geweiht [nicht-alveranische Gottheit]; SF Spätweihe Nichtalveranische Gottheit/Kontakt zum Großen Geist (+12 KaP), Vorteil Sacerdos I bis IV; SF Spätweihe Dunkle Zeiten I bis III (+6 je Stufe)

-- Spähtweihe DDZ korrigieren: Die SF kann in drei Stufen vorkommen.
UPDATE [Sonderfertigkeit] SET [Name] = N'Spätweihe Dunkle Zeiten I' WHERE [SonderfertigkeitGUID] = N'00000000-0000-0000-005f-000000000923';
INSERT INTO [Sonderfertigkeit] ([SonderfertigkeitGUID],[Name],[HatWert],[Typ],[Literatur]) VALUES (N'00000000-0000-0000-005f-000000001988',N'Spätweihe Dunkle Zeiten II',0,N'Klerikal',N'OiC 43');
INSERT INTO [Sonderfertigkeit] ([SonderfertigkeitGUID],[Name],[HatWert],[Typ],[Literatur]) VALUES (N'00000000-0000-0000-005f-000000001989',N'Spätweihe Dunkle Zeiten III',0,N'Klerikal',N'OiC 43');
INSERT INTO [Sonderfertigkeit_Setting] ([SonderfertigkeitGUID],[SettingGUID]) VALUES (N'00000000-0000-0000-005f-000000001988',N'00000000-0000-0000-5e77-000000000002');
INSERT INTO [Sonderfertigkeit_Setting] ([SonderfertigkeitGUID],[SettingGUID]) VALUES (N'00000000-0000-0000-005f-000000001989',N'00000000-0000-0000-5e77-000000000002');

-- DSA5 Anpassungen
ALTER TABLE [Held] ADD [LeiteigenschaftMagisch] nvarchar(2);
-- TODO: Wert aus vorhandenen SF setzen
ALTER TABLE [Held] ADD [LeiteigenschaftKlerikal] nvarchar(2);

--TODO Waffenset

--TODO MT: Datenanpassungen Literatur