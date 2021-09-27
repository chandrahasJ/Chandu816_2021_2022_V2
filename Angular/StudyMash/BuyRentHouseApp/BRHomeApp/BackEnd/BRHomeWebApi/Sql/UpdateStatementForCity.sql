/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Name]
      ,[LastUpdateOn]
      ,[LastUpdatedBy]
      ,[CountryName]
  FROM [BRHome].[dbo].[Cities]

  Update [BRHome].[dbo].[Cities]
  SET 

  Id	Name
26	New York
27	Delhi
28	Udupi
29	Surat
30	Seattle
31	New Jerasy
35	Vegas
36	Oslo
37	Paris
38	Rajkot
39	Kabul
40	Rajkot