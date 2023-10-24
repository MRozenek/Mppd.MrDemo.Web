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
USE [MddpMrDemo];
GO

INSERT INTO [dbo].[ResourceType]([Id], [Name])
VALUES  (1, 'Departmant'),
        (2, 'Employee');
GO

INSERT INTO [dbo].[Resource]([Id],[Name],[ResourceTypeId])
VALUES  (1, 'HR', 1),
        (2, 'IT', 1);
GO

INSERT INTO [dbo].[Resource]([Id],[Name],[ResourceTypeId])
VALUES  (3, 'Magda Chuda', 2),
        (4, 'Mario Warszawski', 2),
        (5, 'Marian Mrożonek', 2);
GO

INSERT INTO [dbo].[HierarchyTree]([Id], [ResourceId], [ResourceParentId], [ResourceManagerId])
VALUES  (1, 3/*Magda Chuda*/, 1/*HR*/, NULL),
        (2, 4/*Mario Warszawski*/, 2/*IT*/, NULL),
        (3, 5/*Marian Mrożonek*/, 2/*IT*/, 4)
GO

INSERT INTO [dbo].[DbVersion]([Number])
VALUES  ('1.0.0.0');
GO
