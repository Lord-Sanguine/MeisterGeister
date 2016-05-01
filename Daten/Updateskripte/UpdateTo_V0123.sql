﻿--Magieresistenz bei Zaubern eintragen
UPDATE Zauber SET Magieresistenz = 1 where ZauberGUID IN
('00000000-0000-0000-00ca-000000000010',
'00000000-0000-0000-00ca-000000000024',
'00000000-0000-0000-00ca-000000000026',
'00000000-0000-0000-00ca-000000000032',
'00000000-0000-0000-00ca-000000000033',
'00000000-0000-0000-00ca-000000000042',
'00000000-0000-0000-00ca-000000000043',
'00000000-0000-0000-00ca-000000000044',
'00000000-0000-0000-00ca-000000000046',
'00000000-0000-0000-00ca-000000000047',
'00000000-0000-0000-00ca-000000000056',
'00000000-0000-0000-00ca-000000000057',
'00000000-0000-0000-00ca-000000000064',
'00000000-0000-0000-00ca-000000000070',
'00000000-0000-0000-00ca-000000000080',
'00000000-0000-0000-00ca-000000000088',
'00000000-0000-0000-00ca-000000000100',
'00000000-0000-0000-00ca-000000000101',
'00000000-0000-0000-00ca-000000000102',
'00000000-0000-0000-00ca-000000000103',
'00000000-0000-0000-00ca-000000000108',
'00000000-0000-0000-00ca-000000000110',
'00000000-0000-0000-00ca-000000000111',
'00000000-0000-0000-00ca-000000000118',
'00000000-0000-0000-00ca-000000000119',
'00000000-0000-0000-00ca-000000000121',
'00000000-0000-0000-00ca-000000000128',
'00000000-0000-0000-00ca-000000000134',
'00000000-0000-0000-00ca-000000000135',
'00000000-0000-0000-00ca-000000000136',
'00000000-0000-0000-00ca-000000000140',
'00000000-0000-0000-00ca-000000000149',
'00000000-0000-0000-00ca-000000000151',
'00000000-0000-0000-00ca-000000000153',
'00000000-0000-0000-00ca-000000000161',
'00000000-0000-0000-00ca-000000000173',
'00000000-0000-0000-00ca-000000000199',
'00000000-0000-0000-00ca-000000000200',
'00000000-0000-0000-00ca-000000000212',
'00000000-0000-0000-00ca-000000000219',
'00000000-0000-0000-00ca-000000000222',
'00000000-0000-0000-00ca-000000000223',
'00000000-0000-0000-00ca-000000000226',
'00000000-0000-0000-00ca-000000000231',
'00000000-0000-0000-00ca-000000000233',
'00000000-0000-0000-00ca-000000000234',
'00000000-0000-0000-00ca-000000000236',
'00000000-0000-0000-00ca-000000000238',
'00000000-0000-0000-00ca-000000000240',
'00000000-0000-0000-00ca-000000000246',
'00000000-0000-0000-00ca-000000000260',
'00000000-0000-0000-00ca-000000000264',
'00000000-0000-0000-00ca-000000000266',
'00000000-0000-0000-00ca-000000000272',
'00000000-0000-0000-00ca-000000000274',
'00000000-0000-0000-00ca-000000000302',
'00000000-0000-0000-00ca-000000000304',
'00000000-0000-0000-00ca-000000000305',
'00000000-0000-0000-00ca-000000000369',
'00000000-0000-0000-00ca-000000000371')
GO

--Die Zauberdauer wird anschließend noch eingetragen
--Nicht alle Zauber haben eine konstante Zauberdauer
--Deshalb tragen wir nicht alle ein, sondern nur die konstanten
ALTER TABLE Zauber ALTER COLUMN Zauberdauer int;

--Doppelte Zauber entfernen
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000349' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000370';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000370';

UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000369' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000348';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000348';
--Fesselranken
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000350' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000371';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000371';
--Elementarer Wirbel
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000293' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000078';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000078';
--Feuermähne
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000351' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000372';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000372';
--Glacoflumen
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000347' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000368';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000368';
--Igniplano
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000318' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000354' or ZauberGUID='00000000-0000-0000-00ca-000000000375';
UPDATE Zauber_Setting SET ZauberGUID='00000000-0000-0000-00ca-000000000318' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000354';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000354' or ZauberGUID='00000000-0000-0000-00ca-000000000375';
--Kraft des Humus
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000355' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000376';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000376';
--Stimme des Windes
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000356' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000377';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000377';
--Sumpfstrudel
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000357' WHERE Zauberguid in ('00000000-0000-0000-00ca-000000000253','00000000-0000-0000-00ca-000000000378');
INSERT INTO Zauber_Setting (ZauberGUID, SettingGUID, Repräsentationen) VALUES ('00000000-0000-0000-00ca-000000000357', '00000000-0000-0000-5e77-000000000002', 'Dru 2');
DELETE FROM Zauber WHERE Zauberguid in ('00000000-0000-0000-00ca-000000000253','00000000-0000-0000-00ca-000000000378');
--Tenebraro
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000365' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000387';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000387';
--Wand aus Element
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000365' WHERE ZauberGUID in ('00000000-0000-0000-00ca-000000000358', '00000000-0000-0000-00ca-000000000379');
DELETE FROM Zauber WHERE ZauberGUID in ('00000000-0000-0000-00ca-000000000358', '00000000-0000-0000-00ca-000000000379');
--Wand aus Flammen
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000278' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000387';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000387';
--Warmes Gefriere
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000359' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000385';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000385';
--Windgeflüster
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000360' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000386';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000386';


--Dämonenbann
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000332' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000060';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000060';
--Agrimoth
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000332' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000009';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000009';
--Amazeroth
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000333' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000011';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000011';
--Asfaloth
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000334' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000023';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000023';
--Belhalhar
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000335' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000036';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000036';
--Belkelel
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000336' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000037';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000037';
--Belzhorash
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000337' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000178';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000178';
--Blakharaz
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000338' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000040';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000040';
--Charyptoroth
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000339' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000051';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000051';
--Nagrach/Belshirash
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000341' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000183';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000183';
--Lolgramoth
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000340' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000164';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000164';
--Tasfarelel
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000342' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000255';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000255';
--Thargunitoth
UPDATE Held_Zauber SET ZauberGUID='00000000-0000-0000-00ca-000000000343' WHERE ZauberGUID='00000000-0000-0000-00ca-000000000258';
DELETE FROM Zauber WHERE ZauberGUID='00000000-0000-0000-00ca-000000000258';

--TODO: Zauberdauer eintragen

UPDATE [Zauber] SET [Zauberdauer] = 40 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000002';
UPDATE [Zauber] SET [Zauberdauer] = 40 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000003';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000004';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000005';
UPDATE [Zauber] SET [Zauberdauer] = 3 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000006';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000007';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000008';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000010';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000013';
UPDATE [Zauber] SET [Zauberdauer] = 40 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000015';
UPDATE [Zauber] SET [Zauberdauer] = 4 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000016';
UPDATE [Zauber] SET [Zauberdauer] = 40 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000017';
UPDATE [Zauber] SET [Zauberdauer] = 4 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000021';
UPDATE [Zauber] SET [Zauberdauer] = 3 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000022';
UPDATE [Zauber] SET [Zauberdauer] = 6 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000024';
UPDATE [Zauber] SET [Zauberdauer] = 30 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000025';
UPDATE [Zauber] SET [Zauberdauer] = 7 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000026';
UPDATE [Zauber] SET [Zauberdauer] = 15 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000027';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000028';
UPDATE [Zauber] SET [Zauberdauer] = 2 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000030';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000033';
UPDATE [Zauber] SET [Zauberdauer] = 600 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000034';
UPDATE [Zauber] SET [Zauberdauer] = 40 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000035';
UPDATE [Zauber] SET [Zauberdauer] = 15 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000038';
UPDATE [Zauber] SET [Zauberdauer] = 4 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000039';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000041';
UPDATE [Zauber] SET [Zauberdauer] = 30 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000042';
UPDATE [Zauber] SET [Zauberdauer] = 400 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000043';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000044';
UPDATE [Zauber] SET [Zauberdauer] = 1 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000046';
UPDATE [Zauber] SET [Zauberdauer] = 4 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000047';
UPDATE [Zauber] SET [Zauberdauer] = 3 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000048';
UPDATE [Zauber] SET [Zauberdauer] = 40 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000049';
UPDATE [Zauber] SET [Zauberdauer] = 2 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000050';
UPDATE [Zauber] SET [Zauberdauer] = 3 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000055';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000056';
UPDATE [Zauber] SET [Zauberdauer] = 2 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000057';
UPDATE [Zauber] SET [Zauberdauer] = 200 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000058';
UPDATE [Zauber] SET [Zauberdauer] = 2400 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000059';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000061';
UPDATE [Zauber] SET [Zauberdauer] = 7 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000062';
UPDATE [Zauber] SET [Zauberdauer] = 4 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000064';
UPDATE [Zauber] SET [Zauberdauer] = 1200 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000065';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000066';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000067';
UPDATE [Zauber] SET [Zauberdauer] = 6 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000068';
UPDATE [Zauber] SET [Zauberdauer] = 40 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000069';
UPDATE [Zauber] SET [Zauberdauer] = 3 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000070';
UPDATE [Zauber] SET [Zauberdauer] = 40 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000071';
UPDATE [Zauber] SET [Zauberdauer] = 600 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000072';
UPDATE [Zauber] SET [Zauberdauer] = 2 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000073';
UPDATE [Zauber] SET [Zauberdauer] = 2 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000074';
UPDATE [Zauber] SET [Zauberdauer] = 40 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000076';
UPDATE [Zauber] SET [Zauberdauer] = 200 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000077';
UPDATE [Zauber] SET [Zauberdauer] = 40 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000079';
UPDATE [Zauber] SET [Zauberdauer] = 3 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000080';
UPDATE [Zauber] SET [Zauberdauer] = 15 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000081';
UPDATE [Zauber] SET [Zauberdauer] = 4 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000082';
UPDATE [Zauber] SET [Zauberdauer] = 2 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000083';
UPDATE [Zauber] SET [Zauberdauer] = 6 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000086';
UPDATE [Zauber] SET [Zauberdauer] = 2 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000087';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000088';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000089';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000090';
UPDATE [Zauber] SET [Zauberdauer] = 4 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000091';
UPDATE [Zauber] SET [Zauberdauer] = 7 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000092';
UPDATE [Zauber] SET [Zauberdauer] = 2 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000093';
UPDATE [Zauber] SET [Zauberdauer] = 2 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000094';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000095';
UPDATE [Zauber] SET [Zauberdauer] = 14400 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000096';
UPDATE [Zauber] SET [Zauberdauer] = 200 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000099';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000100';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000101';
UPDATE [Zauber] SET [Zauberdauer] = 2 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000102';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000103';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000104';
UPDATE [Zauber] SET [Zauberdauer] = 3 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000105';
UPDATE [Zauber] SET [Zauberdauer] = 8 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000107';
UPDATE [Zauber] SET [Zauberdauer] = 2 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000108';
UPDATE [Zauber] SET [Zauberdauer] = 12 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000109';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000110';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000111';
UPDATE [Zauber] SET [Zauberdauer] = 4 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000112';
UPDATE [Zauber] SET [Zauberdauer] = 2 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000113';
UPDATE [Zauber] SET [Zauberdauer] = 200 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000114';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000115';
UPDATE [Zauber] SET [Zauberdauer] = 3 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000116';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000117';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000118';
UPDATE [Zauber] SET [Zauberdauer] = 2 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000119';
UPDATE [Zauber] SET [Zauberdauer] = 4 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000120';
UPDATE [Zauber] SET [Zauberdauer] = 3 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000121';
UPDATE [Zauber] SET [Zauberdauer] = 4 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000122';
UPDATE [Zauber] SET [Zauberdauer] = 4 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000123';
UPDATE [Zauber] SET [Zauberdauer] = 7 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000124';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000125';
UPDATE [Zauber] SET [Zauberdauer] = 2 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000126';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000128';
UPDATE [Zauber] SET [Zauberdauer] = 200 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000129';
UPDATE [Zauber] SET [Zauberdauer] = 7 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000131';
UPDATE [Zauber] SET [Zauberdauer] = 40 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000132';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000133';
UPDATE [Zauber] SET [Zauberdauer] = 4 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000134';
UPDATE [Zauber] SET [Zauberdauer] = 4 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000135';
UPDATE [Zauber] SET [Zauberdauer] = 3 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000136';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000137';
UPDATE [Zauber] SET [Zauberdauer] = 7 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000138';
UPDATE [Zauber] SET [Zauberdauer] = 1 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000139';
UPDATE [Zauber] SET [Zauberdauer] = 4 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000140';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000141';
UPDATE [Zauber] SET [Zauberdauer] = 7 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000142';
UPDATE [Zauber] SET [Zauberdauer] = 1200 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000143';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000144';
UPDATE [Zauber] SET [Zauberdauer] = 40 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000145';
UPDATE [Zauber] SET [Zauberdauer] = 7 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000146';
UPDATE [Zauber] SET [Zauberdauer] = 7 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000147';
UPDATE [Zauber] SET [Zauberdauer] = 6 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000148';
UPDATE [Zauber] SET [Zauberdauer] = 1 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000149';
UPDATE [Zauber] SET [Zauberdauer] = 2 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000151';
UPDATE [Zauber] SET [Zauberdauer] = 4 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000152';
UPDATE [Zauber] SET [Zauberdauer] = 1200 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000153';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000154';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000155';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000156';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000157';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000158';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000159';
UPDATE [Zauber] SET [Zauberdauer] = 200 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000160';
UPDATE [Zauber] SET [Zauberdauer] = 7 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000161';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000162';
UPDATE [Zauber] SET [Zauberdauer] = 2 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000163';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000165';
UPDATE [Zauber] SET [Zauberdauer] = 200 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000166';
UPDATE [Zauber] SET [Zauberdauer] = 40 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000167';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000168';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000169';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000170';
UPDATE [Zauber] SET [Zauberdauer] = 2400 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000171';
UPDATE [Zauber] SET [Zauberdauer] = 7 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000172';
UPDATE [Zauber] SET [Zauberdauer] = 600 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000173';
UPDATE [Zauber] SET [Zauberdauer] = 200 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000174';
UPDATE [Zauber] SET [Zauberdauer] = 40 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000176';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000179';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000180';
UPDATE [Zauber] SET [Zauberdauer] = 4 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000181';
UPDATE [Zauber] SET [Zauberdauer] = 2 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000182';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000184';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000185';
UPDATE [Zauber] SET [Zauberdauer] = 600 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000186';
UPDATE [Zauber] SET [Zauberdauer] = 15 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000187';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000188';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000189';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000190';
UPDATE [Zauber] SET [Zauberdauer] = 25 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000191';
UPDATE [Zauber] SET [Zauberdauer] = 50 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000192';
UPDATE [Zauber] SET [Zauberdauer] = 15 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000193';
UPDATE [Zauber] SET [Zauberdauer] = 4 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000194';
UPDATE [Zauber] SET [Zauberdauer] = 4 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000195';
UPDATE [Zauber] SET [Zauberdauer] = 7 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000196';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000197';
UPDATE [Zauber] SET [Zauberdauer] = 6 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000198';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000199';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000200';
UPDATE [Zauber] SET [Zauberdauer] = 6 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000201';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000203';
UPDATE [Zauber] SET [Zauberdauer] = 600 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000204';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000205';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000206';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000207';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000208';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000209';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000210';
UPDATE [Zauber] SET [Zauberdauer] = 50 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000211';
UPDATE [Zauber] SET [Zauberdauer] = 3 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000212';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000213';
UPDATE [Zauber] SET [Zauberdauer] = 8 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000214';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000215';
UPDATE [Zauber] SET [Zauberdauer] = 4 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000216';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000217';
UPDATE [Zauber] SET [Zauberdauer] = 50 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000218';
UPDATE [Zauber] SET [Zauberdauer] = 3 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000219';
UPDATE [Zauber] SET [Zauberdauer] = 8 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000220';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000221';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000222';
UPDATE [Zauber] SET [Zauberdauer] = 4 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000223';
UPDATE [Zauber] SET [Zauberdauer] = 50 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000224';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000225';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000226';
UPDATE [Zauber] SET [Zauberdauer] = 4 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000227';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000228';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000229';
UPDATE [Zauber] SET [Zauberdauer] = 6 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000230';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000231';
UPDATE [Zauber] SET [Zauberdauer] = 200 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000232';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000233';
UPDATE [Zauber] SET [Zauberdauer] = 3 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000234';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000235';
UPDATE [Zauber] SET [Zauberdauer] = 200 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000236';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000237';
UPDATE [Zauber] SET [Zauberdauer] = 6 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000238';
UPDATE [Zauber] SET [Zauberdauer] = 7 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000239';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000240';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000241';
UPDATE [Zauber] SET [Zauberdauer] = 2 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000242';
UPDATE [Zauber] SET [Zauberdauer] = 50 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000243';
UPDATE [Zauber] SET [Zauberdauer] = 30 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000244';
UPDATE [Zauber] SET [Zauberdauer] = 7 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000246';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000247';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000248';
UPDATE [Zauber] SET [Zauberdauer] = 4 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000249';
UPDATE [Zauber] SET [Zauberdauer] = 16800 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000250';
UPDATE [Zauber] SET [Zauberdauer] = 16800 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000251';
UPDATE [Zauber] SET [Zauberdauer] = 7 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000252';
UPDATE [Zauber] SET [Zauberdauer] = 200 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000254';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000256';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000257';
UPDATE [Zauber] SET [Zauberdauer] = 50 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000259';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000260';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000261';
UPDATE [Zauber] SET [Zauberdauer] = 200 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000262';
UPDATE [Zauber] SET [Zauberdauer] = 8 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000263';
UPDATE [Zauber] SET [Zauberdauer] = 3 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000265';
UPDATE [Zauber] SET [Zauberdauer] = 200 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000266';
UPDATE [Zauber] SET [Zauberdauer] = 200 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000267';
UPDATE [Zauber] SET [Zauberdauer] = 30 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000268';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000269';
UPDATE [Zauber] SET [Zauberdauer] = 50 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000270';
UPDATE [Zauber] SET [Zauberdauer] = 2 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000271';
UPDATE [Zauber] SET [Zauberdauer] = 2 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000272';
UPDATE [Zauber] SET [Zauberdauer] = 50 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000273';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000274';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000276';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000277';
UPDATE [Zauber] SET [Zauberdauer] = 30 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000278';
UPDATE [Zauber] SET [Zauberdauer] = 30 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000279';
UPDATE [Zauber] SET [Zauberdauer] = 30 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000280';
UPDATE [Zauber] SET [Zauberdauer] = 30 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000281';
UPDATE [Zauber] SET [Zauberdauer] = 30 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000282';
UPDATE [Zauber] SET [Zauberdauer] = 30 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000283';
UPDATE [Zauber] SET [Zauberdauer] = 8 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000284';
UPDATE [Zauber] SET [Zauberdauer] = 30 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000285';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000286';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000287';
UPDATE [Zauber] SET [Zauberdauer] = 1200 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000288';
UPDATE [Zauber] SET [Zauberdauer] = 10 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000289';
UPDATE [Zauber] SET [Zauberdauer] = 6 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000290';
UPDATE [Zauber] SET [Zauberdauer] = 200 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000291';
UPDATE [Zauber] SET [Zauberdauer] = 400 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000292';
UPDATE [Zauber] SET [Zauberdauer] = 15 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000293';
UPDATE [Zauber] SET [Zauberdauer] = 30 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000294';
UPDATE [Zauber] SET [Zauberdauer] = 6 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000295';
UPDATE [Zauber] SET [Zauberdauer] = 20 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000296';
UPDATE [Zauber] SET [Zauberdauer] = 3 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000297';
UPDATE [Zauber] SET [Zauberdauer] = 2 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000298';
UPDATE [Zauber] SET [Zauberdauer] = 200 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000299';
UPDATE [Zauber] SET [Zauberdauer] = 600 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000300';
UPDATE [Zauber] SET [Zauberdauer] = 200 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000301';
UPDATE [Zauber] SET [Zauberdauer] = 5 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000303';
UPDATE [Zauber] SET [Zauberdauer] = 4 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000304';
UPDATE [Zauber] SET [Zauberdauer] = 3 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000305';
UPDATE [Zauber] SET [Zauberdauer] = 7 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000306';
UPDATE [Zauber] SET [Zauberdauer] = 7 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000307';
UPDATE [Zauber] SET [Zauberdauer] = 7 WHERE [ZauberGUID]='00000000-0000-0000-00ca-000000000308';