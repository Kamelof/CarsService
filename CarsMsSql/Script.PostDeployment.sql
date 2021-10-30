/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

insert into Colors (Title) values ('Red');
insert into Colors (Title) values ('Green');
insert into Colors (Title) values ('Blue');
insert into Colors (Title) values ('Yellow');
insert into Colors (Title) values ('Black');
insert into Colors (Title) values ('White');
insert into Colors (Title) values ('Orange');
insert into Colors (Title) values ('Purple');
insert into Colors (Title) values ('Brown');
insert into Colors (Title) values ('Gray');

insert into CarBodies (Title) values ('Sedan');
insert into CarBodies (Title) values ('Hatchback');
insert into CarBodies (Title) values ('Coupe');
insert into CarBodies (Title) values ('Cabriolet');
insert into CarBodies (Title) values ('Pickup');

declare @idColor int = (select Id from Colors where Title = 'Green');
declare @idCarBody int = (select Id from CarBodies where Title = 'Sedan');

insert into Cars values (NEWID(), 1998, 'BMW', 35.2, 2452, @idColor, @idCarBody);

insert into Roles values (0, 'User');
insert into Roles values (1, 'Manager');
insert into Roles values (2, 'Admin');

insert into Users(Id, [Login], FirstName, LastName, [Password], RoleId, IsActive) values (NEWID(), 'Admin', 'Admin', 'Main', 'NgAgJYx5Rcu/glVJpfix6RB11/6aDevwy3dSV407NkM=', 2, 1);