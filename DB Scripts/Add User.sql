USE [C:\JEN\PERSONAL\500\AGILEPMT\SWENG500_TEAM1\PROJECTMANAGER\PROJECTMANAGERWEB\APP_DATA\PROJECTMANAGER.MDF]
GO

INSERT INTO [dbo].[Users]
           ([UserName]
           ,[Password]
           ,[UserRole]
           ,[FirstName]
           ,[LastName]
           ,[Email]
           ,[PhoneNumber]
           ,[Position]
           ,[TeamName])
     VALUES
           ('jlw923', 
           'password',
           'Manager', 
           'Jennifer', 
           'Wyatt', 
           'jlw923@psu.edu', 
           '814-555-1212', 
           'Project Manager', 
           'Development Team')
GO


