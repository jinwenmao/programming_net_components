USE [master]
GO
/****** Object:  Database [Bank Account System]    Script Date: 02/16/2005 14:15:17 ******/
CREATE DATABASE [Bank Account System] ON  PRIMARY 
( NAME = N'Bank Account System', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\Bank Account System.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'Bank Account System_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\Bank Account System_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 1024KB )
 COLLATE SQL_Latin1_General_CP1_CI_AS
GO
EXEC dbo.sp_dbcmptlevel @dbname=N'Bank Account System', @new_cmptlevel=90
GO
EXEC [Bank Account System].[dbo].[sp_fulltext_database] @action = 'disable'
GO
ALTER DATABASE [Bank Account System] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Bank Account System] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Bank Account System] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Bank Account System] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Bank Account System] SET ARITHABORT OFF 
GO
ALTER DATABASE [Bank Account System] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Bank Account System] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Bank Account System] SET AUTO_SHRINK ON 
GO
ALTER DATABASE [Bank Account System] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Bank Account System] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Bank Account System] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Bank Account System] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Bank Account System] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Bank Account System] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Bank Account System] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Bank Account System] SET  READ_WRITE 
GO
ALTER DATABASE [Bank Account System] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Bank Account System] SET  MULTI_USER 
GO
ALTER DATABASE [Bank Account System] SET PAGE_VERIFY TORN_PAGE_DETECTION  
GO
ALTER DATABASE [Bank Account System] SET DB_CHAINING OFF 


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