DECLARE @dbname varchar(128)
SET @dbname = N'MachineMonitoring'

IF (not EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = @dbname OR name = @dbname)))
Create Database MachineMonitoring

--------------------

Go
use MachineMonitoring
GO


-------------------Delete Table MachineProduction if Exists --------------------
IF (EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE   TABLE_NAME = 'MachineProduction'))
BEGIN	 	
    DROP TABLE MachineProduction
END
GO

-------------------Delete Table Machine if Exists --------------------
IF (EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE  TABLE_NAME = 'Machine'))
BEGIN
		DROP TABLE Machine
END
GO

-------------------Create Table Machine --------------------
CREATE TABLE [dbo].[Machine](
	[MachineId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](250) NULL,
 CONSTRAINT [PK_Machine] PRIMARY KEY CLUSTERED 
([MachineId] ASC) ON [PRIMARY]) ON [PRIMARY]
GO


-------------------Create Table [MachineProduction] --------------------

CREATE TABLE [dbo].[MachineProduction](
	[MachineProductionId] [int] IDENTITY(1,1) NOT NULL,
	[MachineID] [int] NOT NULL,
	[TotalProduction] [int] NOT NULL,
 CONSTRAINT [PK_MachineProduction] PRIMARY KEY CLUSTERED 
(
	[MachineProductionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MachineProduction] ADD  CONSTRAINT [DF_MachineProduction_TotalProduction]  DEFAULT ((0)) FOR [TotalProduction]
GO

ALTER TABLE [dbo].[MachineProduction]  WITH CHECK ADD  CONSTRAINT [FK_MachineProduction_Machine] FOREIGN KEY([MachineID])
REFERENCES [dbo].[Machine] ([MachineId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[MachineProduction] CHECK CONSTRAINT [FK_MachineProduction_Machine]
GO


------------------------------------Seeding DATA -----------------------------------------
SET IDENTITY_INSERT [dbo].Machine ON

INSERT INTO Machine(MachineId,Name,Description)
values
(
	1,
	'Equipment A',
	'Description A'
),(
	2,
	'Equipment B',
	'Description B'
)
SET IDENTITY_INSERT [dbo].Machine Off



INSERT INTO [MachineProduction](MachineId,TotalProduction)
values
(
	1,	
	34
),(
	1,	
	89
),(
	1,	
	87
)
,(
	2,	
	89
)
,(
	2,	
	98
)

