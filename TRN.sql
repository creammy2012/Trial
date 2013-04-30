USE [master]
GO
/****** Object:  Database [TRN]    Script Date: 04/30/2013 11:58:47 ******/
CREATE DATABASE [TRN] ON  PRIMARY 
( NAME = N'TRN', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\TRN.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TRN_log', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\TRN_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TRN] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TRN].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TRN] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [TRN] SET ANSI_NULLS OFF
GO
ALTER DATABASE [TRN] SET ANSI_PADDING OFF
GO
ALTER DATABASE [TRN] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [TRN] SET ARITHABORT OFF
GO
ALTER DATABASE [TRN] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [TRN] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [TRN] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [TRN] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [TRN] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [TRN] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [TRN] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [TRN] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [TRN] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [TRN] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [TRN] SET  DISABLE_BROKER
GO
ALTER DATABASE [TRN] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [TRN] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [TRN] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [TRN] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [TRN] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [TRN] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [TRN] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [TRN] SET  READ_WRITE
GO
ALTER DATABASE [TRN] SET RECOVERY SIMPLE
GO
ALTER DATABASE [TRN] SET  MULTI_USER
GO
ALTER DATABASE [TRN] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [TRN] SET DB_CHAINING OFF
GO
USE [TRN]
GO
/****** Object:  Table [dbo].[Trn]    Script Date: 04/30/2013 11:58:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Trn](
	[TrnNum] [int] NOT NULL,
	[Fname] [varchar](50) NULL,
	[MiddleName] [varchar](50) NULL,
	[Lname] [varchar](50) NULL,
	[DOB] [date] NULL,
	[Gender] [varchar](10) NULL,
	[MotherMaiden] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[TrnNum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Trn] ([TrnNum], [Fname], [MiddleName], [Lname], [DOB], [Gender], [MotherMaiden]) VALUES (11111, N'Kareem', N'S', N'Scott', CAST(0xCE140B00 AS Date), N'male', N'Craig')
INSERT [dbo].[Trn] ([TrnNum], [Fname], [MiddleName], [Lname], [DOB], [Gender], [MotherMaiden]) VALUES (11112, N'Valdi', N'P', N'Service', CAST(0x0B150B00 AS Date), N'male', N'Davis')
INSERT [dbo].[Trn] ([TrnNum], [Fname], [MiddleName], [Lname], [DOB], [Gender], [MotherMaiden]) VALUES (11113, N'Ronique', N'A', N'Dixon', CAST(0xC7140B00 AS Date), N'female', N'Rhodes')
/****** Object:  StoredProcedure [dbo].[TrnQuery]    Script Date: 04/30/2013 11:59:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TrnQuery] 
(
 @query varchar(300)
)
 AS 
BEGIN 
 SELECT * FROM Trn WHERE 
[Fname] LIKE '%' + @query + '%' OR
[MiddleName] LIKE '%' + @query + '%' OR
[Lname] LIKE '%' + @query + '%' OR
(Convert(varchar(120), [DOB] )) LIKE '%' + @query + '%' OR
[Gender] LIKE '%' + @query + '%' OR
[MotherMaiden] LIKE '%' + @query + '%' END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllTrnById]    Script Date: 04/30/2013 11:59:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectAllTrnById] 
(
@TrnNum int
)
 AS 
 BEGIN 
 SELECT * FROM [Trn] where [TrnNum]=@TrnNum END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllTrn]    Script Date: 04/30/2013 11:59:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectAllTrn] 
 AS 
BEGIN 
 SELECT * FROM [Trn] END
GO
/****** Object:  StoredProcedure [dbo].[SearchTrn]    Script Date: 04/30/2013 11:59:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchTrn] 
 (
@Fname varchar(50) = NULL,

@MiddleName varchar(50) = NULL,

@Lname varchar(50) = NULL,

@DOB date = NULL,

@Gender varchar(10) = NULL,

@MotherMaiden varchar(50) = NULL
) 

 AS 
BEGIN 
 SELECT * FROM Trn WHERE 
 (@Fname IS NULL OR [Fname] LIKE '%' + @Fname + '%')  AND
(@MiddleName IS NULL OR [MiddleName] LIKE '%' + @MiddleName + '%')  AND
(@Lname IS NULL OR [Lname] LIKE '%' + @Lname + '%')  AND
(@DOB IS NULL OR [DOB] = @DOB)  AND
(@Gender IS NULL OR [Gender] LIKE '%' + @Gender + '%')  AND
(@MotherMaiden IS NULL OR [MotherMaiden] LIKE '%' + @MotherMaiden + '%')  
END
GO
