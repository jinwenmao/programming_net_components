IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'Bank Account System')
	DROP DATABASE [Bank Account System]
GO

CREATE DATABASE [Bank Account System]  ON (NAME = N'Bank Account System_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL\data\Bank Account System_Data.MDF' , SIZE = 1, FILEGROWTH = 10%) LOG ON (NAME = N'Bank Account System_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL\data\Bank Account System_Log.LDF' , SIZE = 1, FILEGROWTH = 10%)
 COLLATE SQL_Latin1_General_CP1_CI_AS
GO

exec sp_dboption N'Bank Account System', N'autoclose', N'false'
GO

exec sp_dboption N'Bank Account System', N'bulkcopy', N'false'
GO

exec sp_dboption N'Bank Account System', N'trunc. log', N'true'
GO

exec sp_dboption N'Bank Account System', N'torn page detection', N'true'
GO

exec sp_dboption N'Bank Account System', N'read only', N'false'
GO

exec sp_dboption N'Bank Account System', N'dbo use', N'false'
GO

exec sp_dboption N'Bank Account System', N'single', N'false'
GO

exec sp_dboption N'Bank Account System', N'autoshrink', N'true'
GO

exec sp_dboption N'Bank Account System', N'ANSI null default', N'false'
GO

exec sp_dboption N'Bank Account System', N'recursive triggers', N'false'
GO

exec sp_dboption N'Bank Account System', N'ANSI nulls', N'false'
GO

exec sp_dboption N'Bank Account System', N'concat null yields null', N'false'
GO

exec sp_dboption N'Bank Account System', N'cursor close on commit', N'false'
GO

exec sp_dboption N'Bank Account System', N'default to local cursor', N'false'
GO

exec sp_dboption N'Bank Account System', N'quoted identifier', N'false'
GO

exec sp_dboption N'Bank Account System', N'ANSI warnings', N'false'
GO

exec sp_dboption N'Bank Account System', N'auto create statistics', N'true'
GO

exec sp_dboption N'Bank Account System', N'auto update statistics', N'true'
GO

use [Bank Account System]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BankAccounts]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[BankAccounts]
GO

CREATE TABLE [dbo].[BankAccounts] (
	[Number] [int] NOT NULL ,
	[Balance] [money] NULL ,
	[Name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BankAccounts] WITH NOCHECK ADD 
	CONSTRAINT [PK_BankAccounts] PRIMARY KEY  CLUSTERED 
	(
		[Number]
	)  ON [PRIMARY] 
GO

INSERT INTO BankAccounts (Number, Balance, Name) Values (123,1000,'Juval')
INSERT INTO BankAccounts (Number, Balance, Name) Values (456, 1000, 'Brian')
GO
