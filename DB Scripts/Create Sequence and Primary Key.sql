ALTER TABLE dbo.YourTable
ADD ID INT IDENTITY(1,1)

ALTER TABLE dbo.YourTable
ADD CONSTRAINT PK_YourTable PRIMARY KEY(ID)