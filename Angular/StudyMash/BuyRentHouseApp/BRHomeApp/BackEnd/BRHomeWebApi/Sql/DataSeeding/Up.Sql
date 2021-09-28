DECLARE @UserID as INT
--------------------------
--Create User
--------------------------
IF not exists (select Id from Users where Username='CPoojari')
insert into Users(Username,Password, PasswordKey,Email,Mobile, LastUpdatedOn,LastUpdatedBy)
select 'CPoojari',
0xC1BD00E48CEF5DB111AB285ED7EE06438745A3F4423D8ADC223577A5AFEE62E451223434674B1C84504FCADCC529D0762FD0EA394AA7F38DA77329C869FE5F75,
0x5C02EC3B438038EF6D2C4402B4F982638FE06ABA4EE9FD4018DE8CC3DBA67DA05842289D2B57CE3112155191DCBB2DF2508D1A8641792DD527FA3F93EE1DF4E646F2FF45BD519ADBC10A7E22C13C66DA62702412303B867E50F9A34DC6B94709C46189E92EF84604ED3641A7CA3C7DDA1B7B776CE0ED916FB438B89E6FD27174,
'admin@admin.com',
1234567890,
getdate(),
0

SET @UserID = (select id from Users where Username='CPoojari')

--------------------------
--Seed Property Types
--------------------------
IF not exists (select name from PropertyTypes where Name='House')
insert into PropertyTypes(Name,LastUpdatedOn,LastUpdatedBy)
select 'House', GETDATE(),@UserID

IF not exists (select name from PropertyTypes where Name='Apartment')
insert into PropertyTypes(Name,LastUpdatedOn,LastUpdatedBy)
select 'Apartment', GETDATE(),@UserID
	
IF not exists (select name from PropertyTypes where Name='Duplex')
insert into PropertyTypes(Name,LastUpdatedOn,LastUpdatedBy)
select 'Duplex', GETDATE(),@UserID


--------------------------
--Seed Furnishing Types
--------------------------
IF not exists (select name from FurnishingTypes where Name='Fully')
insert into FurnishingTypes(Name, LastUpdatedOn, LastUpdatedBy)
select 'Fully', GETDATE(),@UserID
	
IF not exists (select name from FurnishingTypes where Name='Semi')
insert into FurnishingTypes(Name, LastUpdatedOn, LastUpdatedBy)
select 'Semi', GETDATE(),@UserID
	
IF not exists (select name from FurnishingTypes where Name='Unfurnished')
insert into FurnishingTypes(Name, LastUpdatedOn, LastUpdatedBy)
select 'Unfurnished', GETDATE(),@UserID

--------------------------
--Seed Cities
--------------------------
IF not exists (select name from Cities where Name='New York')
insert into Cities(Name, LastUpdatedOn, LastUpdatedBy, CountryName) 
values('New York',GETDATE(),@UserID,'U.S.A')
IF not exists (select name from Cities where Name='Delhi')
insert into Cities(Name, LastUpdatedOn, LastUpdatedBy, CountryName) 
values('Delhi',GETDATE(),@UserID,'India')
IF not exists (select name from Cities where Name='Udupi')
insert into Cities(Name, LastUpdatedOn, LastUpdatedBy, CountryName) 
values('Udupi',GETDATE(),@UserID,'India')
IF not exists (select name from Cities where Name='Surat')
insert into Cities(Name, LastUpdatedOn, LastUpdatedBy, CountryName) 
values('Surat',GETDATE(),@UserID,'India')
IF not exists (select name from Cities where Name='Seattle')
insert into Cities(Name, LastUpdatedOn, LastUpdatedBy, CountryName) 
values('Seattle',GETDATE(),@UserID,'U.S.A')
IF not exists (select name from Cities where Name='New Jerasy')
insert into Cities(Name, LastUpdatedOn, LastUpdatedBy, CountryName) 
values('New Jerasy',GETDATE(),@UserID,'U.S.A')
IF not exists (select name from Cities where Name='Vegas')
insert into Cities(Name, LastUpdatedOn, LastUpdatedBy, CountryName) 
values('Vegas',GETDATE(),@UserID,'U.S.A')
IF not exists (select name from Cities where Name='Oslo')
insert into Cities(Name, LastUpdatedOn, LastUpdatedBy, CountryName) 
values('Oslo',GETDATE(),@UserID,'Norway')
IF not exists (select name from Cities where Name='Paris')
insert into Cities(Name, LastUpdatedOn, LastUpdatedBy, CountryName) 
values('Paris',GETDATE(),@UserID,'Italy')
IF not exists (select name from Cities where Name='Rajkot')
insert into Cities(Name, LastUpdatedOn, LastUpdatedBy, CountryName) 
values('Rajkot',GETDATE(),@UserID,'India')
IF not exists (select name from Cities where Name='Kabul')
insert into Cities(Name, LastUpdatedOn, LastUpdatedBy, CountryName) 
values('Kabul',GETDATE(),@UserID,'Afgan')
IF not exists (select name from Cities where Name='Rajkot')
insert into Cities(Name, LastUpdatedOn, LastUpdatedBy, CountryName) 
values('Rajkot',GETDATE(),@UserID,'India')

--------------------------
--Seed Properties
--------------------------
--Seed property for sell
IF not exists (select top 1 name from Properties where Name='White House Demo')
insert into Properties(SellRent,Name,PropertyTypeId,BHK,FurnishingTypeId,Price,BuiltArea,CarpetArea,Address,
Address2,CityId,FloorNo,TotalFloors,ReadyToMove,MainEntrance,Security,Gated,Maintenance,EstPossessionOn,Age,Description,PostedOn,PostedBy,LastUpdatedOn,LastUpdatedBy)
select 
1, --Sell Rent
'White House Demo', --Name
(select Id from PropertyTypes where Name='Apartment'), --Property Type ID
2, --BHK
(select Id from FurnishingTypes where Name='Fully'), --Furnishing Type ID
1800, --Price
1400, --Built Area
900, --Carpet Area
'6 Street', --Address
'Golf Course Road', -- Address2
(select top 1 Id from Cities), -- City ID
3, -- Floor No
3, --Total Floors
1, --Ready to Move
'East', --Main Entrance
0, --Security
1, --Gated
300, -- Maintenance
'2019-01-01', -- Establishment or Posession on
0, --Age
'Well Maintained builder floor available for rent at prime location. # property features- - 5 mins away from metro station - Gated community - 24*7 security. # property includes- - Big rooms (Cross ventilation & proper sunlight) - 
Drawing and dining area - Washrooms - Balcony - Modular kitchen - Near gym, market, temple and park - Easy commuting to major destination. Feel free to call With Query.', --Description
GETDATE(), --Posted on
@UserID, --Posted by
GETDATE(), --Last Updated on
@UserID --Last Updated by

---------------------------
--Seed property for rent
---------------------------
IF not exists (select top 1 name from Properties where Name='Birla House Demo')
insert into Properties(SellRent,Name,PropertyTypeId,BHK,FurnishingTypeId,Price,BuiltArea,CarpetArea,Address,
Address2,CityId,FloorNo,TotalFloors,ReadyToMove,MainEntrance,Security,Gated,Maintenance,EstPossessionOn,Age,Description,PostedOn,PostedBy,LastUpdatedOn,LastUpdatedBy)
select 
2, --Sell Rent
'Birla House Demo', --Name
(select Id from PropertyTypes where Name='Apartment'), --Property Type ID
2, --BHK
(select Id from FurnishingTypes where Name='Fully'), --Furnishing Type ID
1800, --Price
1400, --Built Area
900, --Carpet Area
'6 Street', --Address
'Golf Course Road', -- Address2
(select top 1 Id from Cities), -- City ID
3, -- Floor No
3, --Total Floors
1, --Ready to Move
'East', --Main Entrance
0, --Security
1, --Gated
300, -- Maintenance
'2019-01-01', -- Establishment or Posession on
0, --Age
'Well Maintained builder floor available for rent at prime location. # property features- - 5 mins away from metro station - Gated community - 24*7 security. # property includes- - Big rooms (Cross ventilation & proper sunlight) - 
Drawing and dining area - Washrooms - Balcony - Modular kitchen - Near gym, market, temple and park - Easy commuting to major destination. Feel free to call With Query.', --Description
GETDATE(), --Posted on
@UserID, --Posted by
GETDATE(), --Last Updated on
@UserID --Last Updated by

