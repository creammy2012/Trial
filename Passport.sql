

CREATE TABLE [dbo].[Passport](
	[PassportNum] [int] NOT NULL,
	[Fname] [varchar](50) NULL,
	[MiddleName] [varchar](50) NULL,
	[Lname] [varchar](50) NULL,
	[DOB] [date] NULL,
	[Gender] [varchar](10) NULL,
	[Nationality] [varchar](50) NULL,
	[CountryOfBirth] [varchar](50) NULL,
	[CellNum] [int] NULL,
	[EmailAddr] [varchar](50) NULL,
	[StreetNum] [int] NULL,
	[StreetName] [varchar](100) NULL,
	[City] [varchar](50) NULL,
	[Parish] [varchar](50) NULL,
	[MotherMaiden] [varchar](50) NULL,
	[DateIssued] [datetime] NULL,
	[DateExpired] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PassportNum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Passport] ([PassportNum], [Fname], [MiddleName], [Lname], [DOB], [Gender], [Nationality], [CountryOfBirth], [CellNum], [EmailAddr], [StreetNum], [StreetName], [City], [Parish], [MotherMaiden], [DateIssued], [DateExpired]) VALUES (1234, N'Kareem', N'S', N'Scott', CAST(0xCE140B00 AS Date), N'male', N'Jamaican', N'Jamaica', 345, N'ro2gmail.ccomww', 23, N'gsgs', N'gdt', N'dtgs', N'Craig', CAST(0x00007F7300000000 AS DateTime), CAST(0x00007F7300000000 AS DateTime))
INSERT [dbo].[Passport] ([PassportNum], [Fname], [MiddleName], [Lname], [DOB], [Gender], [Nationality], [CountryOfBirth], [CellNum], [EmailAddr], [StreetNum], [StreetName], [City], [Parish], [MotherMaiden], [DateIssued], [DateExpired]) VALUES (1235, N'Valdi', N'P', N'Service', CAST(0x0B150B00 AS Date), N'male', N'Jamaican', N'Jamaica', 7645, N'abc@gmail.com', 333, N'qwer', N'asd', N'zxc', N'Davis', CAST(0x00007FB000000000 AS DateTime), CAST(0x000080E000000000 AS DateTime))
INSERT [dbo].[Passport] ([PassportNum], [Fname], [MiddleName], [Lname], [DOB], [Gender], [Nationality], [CountryOfBirth], [CellNum], [EmailAddr], [StreetNum], [StreetName], [City], [Parish], [MotherMaiden], [DateIssued], [DateExpired]) VALUES (1236, N'Ronique', N'A', N'Dixon', CAST(0xC7140B00 AS Date), N'female', N'Jamaican', N'Jamaica', 4666336, N'rowrow89@gmail.com', 567, N'red', N'thf', N'yhs', N'Rhodes', CAST(0x00007F5500000000 AS DateTime), CAST(0x0000824D00000000 AS DateTime))
/****** Object:  StoredProcedure [dbo].[SelectAllPassportById]    Script Date: 04/30/2013 11:57:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectAllPassportById] 
(
@PassportNum int
)
 AS 
 BEGIN 
 SELECT * FROM [Passport] where PassportNum=@PassportNum  END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllPassport]    Script Date: 04/30/2013 11:57:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectAllPassport] 
 AS 
BEGIN 
 SELECT * FROM [Passport] END
GO
/****** Object:  StoredProcedure [dbo].[SearchPassport]    Script Date: 04/30/2013 11:57:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchPassport] 
 (
@Fname varchar(50) = NULL,

@MiddleName varchar(50) = NULL,

@Lname varchar(50) = NULL,

@DOB date = NULL,

@Gender varchar(10) = NULL,

@Nationality varchar(50) = NULL,

@CountryOfBirth varchar(50) = NULL,

@CellNum int = NULL,

@EmailAddr varchar(50) = NULL,

@StreetNum int = NULL,

@StreetName varchar(100) = NULL,

@City varchar(50) = NULL,

@Parish varchar(50) = NULL,

@MotherMaiden varchar(50) = NULL,

@DateIssued datetime = NULL,

@DateExpired datetime = NULL
) 

 AS 
BEGIN 
 SELECT * FROM Passport WHERE 
 (@Fname IS NULL OR [Fname] LIKE '%' + @Fname + '%')  AND
(@MiddleName IS NULL OR [MiddleName] LIKE '%' + @MiddleName + '%')  AND
(@Lname IS NULL OR [Lname] LIKE '%' + @Lname + '%')  AND
(@DOB IS NULL OR [DOB] = @DOB)  AND
(@Gender IS NULL OR [Gender] LIKE '%' + @Gender + '%')  AND
(@Nationality IS NULL OR [Nationality] LIKE '%' + @Nationality + '%')  AND
(@CountryOfBirth IS NULL OR [CountryOfBirth] LIKE '%' + @CountryOfBirth + '%')  AND
(@CellNum IS NULL OR [CellNum] = @CellNum)  AND
(@EmailAddr IS NULL OR [EmailAddr] LIKE '%' + @EmailAddr + '%')  AND
(@StreetNum IS NULL OR [StreetNum] = @StreetNum)  AND
(@StreetName IS NULL OR [StreetName] LIKE '%' + @StreetName + '%')  AND
(@City IS NULL OR [City] LIKE '%' + @City + '%')  AND
(@Parish IS NULL OR [Parish] LIKE '%' + @Parish + '%')  AND
(@MotherMaiden IS NULL OR [MotherMaiden] LIKE '%' + @MotherMaiden + '%')  AND
(@DateIssued IS NULL OR (Convert(varchar(120), [DateIssued] )) LIKE '%' + @DateIssued + '%')  AND
(@DateExpired IS NULL OR (Convert(varchar(120), [DateExpired] )) LIKE '%' + @DateExpired + '%')  
END
GO
/****** Object:  StoredProcedure [dbo].[PassportQuery]    Script Date: 04/30/2013 11:57:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PassportQuery] 
(
 @query varchar(300)
)
 AS 
BEGIN 
 SELECT * FROM Passport WHERE 
[Fname] LIKE '%' + @query + '%' OR
[MiddleName] LIKE '%' + @query + '%' OR
[Lname] LIKE '%' + @query + '%' OR
(Convert(varchar(120), [DOB] )) LIKE '%' + @query + '%' OR
[Gender] LIKE '%' + @query + '%' OR
[Nationality] LIKE '%' + @query + '%' OR
[CountryOfBirth] LIKE '%' + @query + '%' OR
(Convert(varchar(120), [CellNum] )) LIKE '%' + @query + '%' OR
[EmailAddr] LIKE '%' + @query + '%' OR
(Convert(varchar(120), [StreetNum] )) LIKE '%' + @query + '%' OR
[StreetName] LIKE '%' + @query + '%' OR
[City] LIKE '%' + @query + '%' OR
[Parish] LIKE '%' + @query + '%' OR
[MotherMaiden] LIKE '%' + @query + '%' OR
(Convert(varchar(120), [DateIssued] )) LIKE '%' + @query + '%' OR
(Convert(varchar(120), [DateExpired] )) LIKE '%' + @query + '%' END
GO
