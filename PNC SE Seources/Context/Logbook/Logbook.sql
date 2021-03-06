IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'Logbook')
	DROP DATABASE [Logbook]
GO

CREATE DATABASE [Logbook]  ON (NAME = N'Logbook_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL\data\Logbook_Data.MDF' , SIZE = 2, FILEGROWTH = 10%) LOG ON (NAME = N'Logbook_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL\data\Logbook_Log.LDF' , SIZE = 1, FILEGROWTH = 10%)
 COLLATE SQL_Latin1_General_CP1_CI_AS
GO

exec sp_dboption N'Logbook', N'autoclose', N'true'
GO

exec sp_dboption N'Logbook', N'bulkcopy', N'false'
GO

exec sp_dboption N'Logbook', N'trunc. log', N'true'
GO

exec sp_dboption N'Logbook', N'torn page detection', N'true'
GO

exec sp_dboption N'Logbook', N'read only', N'false'
GO

exec sp_dboption N'Logbook', N'dbo use', N'false'
GO

exec sp_dboption N'Logbook', N'single', N'false'
GO

exec sp_dboption N'Logbook', N'autoshrink', N'true'
GO

exec sp_dboption N'Logbook', N'ANSI null default', N'false'
GO

exec sp_dboption N'Logbook', N'recursive triggers', N'false'
GO

exec sp_dboption N'Logbook', N'ANSI nulls', N'false'
GO

exec sp_dboption N'Logbook', N'concat null yields null', N'false'
GO

exec sp_dboption N'Logbook', N'cursor close on commit', N'false'
GO

exec sp_dboption N'Logbook', N'default to local cursor', N'false'
GO

exec sp_dboption N'Logbook', N'quoted identifier', N'false'
GO

exec sp_dboption N'Logbook', N'ANSI warnings', N'false'
GO

exec sp_dboption N'Logbook', N'auto create statistics', N'true'
GO

exec sp_dboption N'Logbook', N'auto update statistics', N'true'
GO

use [Logbook]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Entries]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Entries]
GO

CREATE TABLE [dbo].[Entries] (
	[Entry] [int] NOT NULL ,
	[Machine] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[AppDomain] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[ThreadID] [int] NOT NULL ,
	[ThreadName] [char] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ContextID] [int] NOT NULL ,
	[User] [char] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Assembly] [char] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Type] [char] (35) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[MemberAccessed] [char] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Date] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Time] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[ExceptionName] [char] (35) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ExceptionMessage] [char] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Event] [char] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Entries] WITH NOCHECK ADD 
	CONSTRAINT [PK_Entries] PRIMARY KEY  CLUSTERED 
	(
		[Entry]
	)  ON [PRIMARY] 
GO

