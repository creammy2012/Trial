

GO
/****** Object:  Table [dbo].[Person]    Script Date: 04/30/2013 11:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Person](
	[CustID] [int] IDENTITY(1,1) NOT NULL,
	[Fname] [varchar](50) NULL,
	[MiddleName] [varchar](50) NULL,
	[Lname] [varchar](50) NULL,
	[DOB] [date] NULL,
	[Gender] [varchar](10) NULL,
	[Addr] [varchar](100) NULL,
	[MotherMaiden] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[CellNum] [int] NULL,
 CONSTRAINT [PK__Person__049E3A897F60ED59] PRIMARY KEY CLUSTERED 
(
	[CustID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Person] ON
INSERT [dbo].[Person] ([CustID], [Fname], [MiddleName], [Lname], [DOB], [Gender], [Addr], [MotherMaiden], [Email], [CellNum]) VALUES (1, N'Kareem', N'S', N'Scott', CAST(0xCE140B00 AS Date), N'male', N'123 Street', N'Craig', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Person] OFF
/****** Object:  Table [dbo].[NatID]    Script Date: 04/30/2013 11:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NatID](
	[NatIDNum] [int] NOT NULL,
	[CustID] [int] NOT NULL,
	[Fname] [varchar](50) NULL,
	[MiddleName] [varchar](50) NULL,
	[Lname] [varchar](50) NULL,
	[DOB] [date] NULL,
	[Gender] [varchar](10) NULL,
	[MotherMaiden] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[NatIDNum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[NatID] ([NatIDNum], [CustID], [Fname], [MiddleName], [Lname], [DOB], [Gender], [MotherMaiden]) VALUES (123, 1, N'Kareem', N'S', N'Scott', CAST(0xCE140B00 AS Date), N'male', N'Craig')
/****** Object:  Table [dbo].[Passport]    Script Date: 04/30/2013 11:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Passport](
	[PassportNum] [int] NOT NULL,
	[CustID] [int] NOT NULL,
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
INSERT [dbo].[Passport] ([PassportNum], [CustID], [Fname], [MiddleName], [Lname], [DOB], [Gender], [Nationality], [CountryOfBirth], [CellNum], [EmailAddr], [StreetNum], [StreetName], [City], [Parish], [MotherMaiden], [DateIssued], [DateExpired]) VALUES (1234, 1, N'Kareem', N'S', N'Scott', CAST(0xCE140B00 AS Date), N'male', N'Jamaican', N'Jamaica', 345, N'ro2gmail.ccomww', 23, N'gsgs', N'gdt', N'dtgs', N'Craig', CAST(0x00007F7300000000 AS DateTime), CAST(0x00007F7300000000 AS DateTime))
/****** Object:  StoredProcedure [dbo].[SelectAllPersonById]    Script Date: 04/30/2013 11:54:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectAllPersonById] 
(
@CustID int
)
 AS 
 BEGIN 
 SELECT * FROM [Person] where CustID=@CustID  END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllPerson]    Script Date: 04/30/2013 11:54:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectAllPerson] 
 AS 
BEGIN 
 SELECT * FROM [Person] END
GO
/****** Object:  Table [dbo].[Trn]    Script Date: 04/30/2013 11:54:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Trn](
	[TrnNum] [int] NOT NULL,
	[CustID] [int] NOT NULL,
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
INSERT [dbo].[Trn] ([TrnNum], [CustID], [Fname], [MiddleName], [Lname], [DOB], [Gender], [MotherMaiden]) VALUES (11111, 1, N'Kareem', N'S', N'Scott', CAST(0xCE140B00 AS Date), N'male', N'Craig')
/****** Object:  StoredProcedure [dbo].[SearchPerson]    Script Date: 04/30/2013 11:54:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchPerson] 
 (
@Fname varchar(50) = NULL,

@MiddleName varchar(50) = NULL,

@Lname varchar(50) = NULL,

@DOB dateTIME = NULL,

@Gender varchar(10) = NULL,

@Addr varchar(100) = NULL,

@MotherMaiden varchar(50) = NULL,

@Email varchar(50) = NULL,

@CellNum int = NULL
) 

 AS 
BEGIN 
 SELECT * FROM Person WHERE 
 (@Fname IS NULL OR [Fname] LIKE '%' + @Fname + '%')  AND
(@MiddleName IS NULL OR [MiddleName] LIKE '%' + @MiddleName + '%')  AND
(@Lname IS NULL OR [Lname] LIKE '%' + @Lname + '%')  AND
(@DOB IS NULL OR [dob] = @DOB)  AND
(@Gender IS NULL OR [Gender] LIKE '%' + @Gender + '%')  AND
(@Addr IS NULL OR [Addr] LIKE '%' + @Addr + '%')  AND
(@MotherMaiden IS NULL OR [MotherMaiden] LIKE '%' + @MotherMaiden + '%')  AND
(@Email IS NULL OR [Email] LIKE '%' + @Email + '%')  AND
(@CellNum IS NULL OR [CellNum] = @CellNum)  
END
GO
/****** Object:  StoredProcedure [dbo].[PersonQuery]    Script Date: 04/30/2013 11:54:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PersonQuery] 
(
 @query varchar(300)
)
 AS 
BEGIN 
 SELECT * FROM Person WHERE 
[Fname] LIKE '%' + @query + '%' OR
[MiddleName] LIKE '%' + @query + '%' OR
[Lname] LIKE '%' + @query + '%' OR
(Convert(varchar(120), [DOB] )) LIKE '%' + @query + '%' OR
[Gender] LIKE '%' + @query + '%' OR
[Addr] LIKE '%' + @query + '%' OR
[MotherMaiden] LIKE '%' + @query + '%' OR
[Email] LIKE '%' + @query + '%' OR
(Convert(varchar(120), [CellNum] )) LIKE '%' + @query + '%' END
GO
/****** Object:  StoredProcedure [dbo].[TrnQuery]    Script Date: 04/30/2013 11:54:30 ******/
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
(Convert(varchar(120), [CustID] )) LIKE '%' + @query + '%' OR
[Fname] LIKE '%' + @query + '%' OR
[MiddleName] LIKE '%' + @query + '%' OR
[Lname] LIKE '%' + @query + '%' OR
(Convert(varchar(120), [DOB] )) LIKE '%' + @query + '%' OR
[Gender] LIKE '%' + @query + '%' OR
[MotherMaiden] LIKE '%' + @query + '%' END
GO
/****** Object:  StoredProcedure [dbo].[SearchPassport]    Script Date: 04/30/2013 11:54:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchPassport] 
 (
@CustID int = NULL,

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
 (@CustID IS NULL OR [CustID] = @CustID)  AND
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
/****** Object:  StoredProcedure [dbo].[SearchNatID]    Script Date: 04/30/2013 11:54:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchNatID] 
 (
@CustID int = NULL,

@Fname varchar(50) = NULL,

@MiddleName varchar(50) = NULL,

@Lname varchar(50) = NULL,

@DOB date = NULL,

@Gender varchar(10) = NULL,

@MotherMaiden varchar(50) = NULL
) 

 AS 
BEGIN 
 SELECT * FROM NatID WHERE 
 (@CustID IS NULL OR [CustID] = @CustID)  AND
(@Fname IS NULL OR [Fname] LIKE '%' + @Fname + '%')  AND
(@MiddleName IS NULL OR [MiddleName] LIKE '%' + @MiddleName + '%')  AND
(@Lname IS NULL OR [Lname] LIKE '%' + @Lname + '%')  AND
(@DOB IS NULL OR  [DOB] =@DOB )  AND
(@Gender IS NULL OR [Gender] LIKE '%' + @Gender + '%')  AND
(@MotherMaiden IS NULL OR [MotherMaiden] LIKE '%' + @MotherMaiden + '%')  
END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllTrnById]    Script Date: 04/30/2013 11:54:30 ******/
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
 SELECT * FROM [Trn] where TrnNum=@TrnNum  END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllTrn]    Script Date: 04/30/2013 11:54:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectAllTrn] 
 AS 
BEGIN 
 SELECT * FROM [Trn] END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllPassportById]    Script Date: 04/30/2013 11:54:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SelectAllPassport]    Script Date: 04/30/2013 11:54:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectAllPassport] 
 AS 
BEGIN 
 SELECT * FROM [Passport] END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllNatIDById]    Script Date: 04/30/2013 11:54:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectAllNatIDById] 
(
@NatIDNum int
)
 AS 
 BEGIN 
 SELECT * FROM [NatID] where NatIDNum=@NatIDNum  END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllNatID]    Script Date: 04/30/2013 11:54:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectAllNatID] 
 AS 
BEGIN 
 SELECT * FROM [NatID] END
GO
/****** Object:  StoredProcedure [dbo].[SearchTrn]    Script Date: 04/30/2013 11:54:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchTrn] 
 (
@CustID int = NULL,

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
 (@CustID IS NULL OR [CustID] = @CustID)  AND
(@Fname IS NULL OR [Fname] LIKE '%' + @Fname + '%')  AND
(@MiddleName IS NULL OR [MiddleName] LIKE '%' + @MiddleName + '%')  AND
(@Lname IS NULL OR [Lname] LIKE '%' + @Lname + '%')  AND
(@DOB IS NULL OR  [DOB] =@DOB )  AND
(@Gender IS NULL OR [Gender] LIKE '%' + @Gender + '%')  AND
(@MotherMaiden IS NULL OR [MotherMaiden] LIKE '%' + @MotherMaiden + '%')  
END
GO
/****** Object:  StoredProcedure [dbo].[PassportQuery]    Script Date: 04/30/2013 11:54:30 ******/
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
(Convert(varchar(120), [CustID] )) LIKE '%' + @query + '%' OR
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
/****** Object:  StoredProcedure [dbo].[NatIDQuery]    Script Date: 04/30/2013 11:54:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NatIDQuery] 
(
 @query varchar(300)
)
 AS 
BEGIN 
 SELECT * FROM NatID WHERE 
(Convert(varchar(120), [CustID] )) LIKE '%' + @query + '%' OR
[Fname] LIKE '%' + @query + '%' OR
[MiddleName] LIKE '%' + @query + '%' OR
[Lname] LIKE '%' + @query + '%' OR
(Convert(varchar(120), [DOB] )) LIKE '%' + @query + '%' OR
[Gender] LIKE '%' + @query + '%' OR
[MotherMaiden] LIKE '%' + @query + '%' END
GO
/****** Object:  ForeignKey [FK__NatID__CustID__0519C6AF]    Script Date: 04/30/2013 11:54:16 ******/
ALTER TABLE [dbo].[NatID]  WITH CHECK ADD  CONSTRAINT [FK__NatID__CustID__0519C6AF] FOREIGN KEY([CustID])
REFERENCES [dbo].[Person] ([CustID])
GO
ALTER TABLE [dbo].[NatID] CHECK CONSTRAINT [FK__NatID__CustID__0519C6AF]
GO
/****** Object:  ForeignKey [FK__Passport__CustID__09DE7BCC]    Script Date: 04/30/2013 11:54:16 ******/
ALTER TABLE [dbo].[Passport]  WITH CHECK ADD  CONSTRAINT [FK__Passport__CustID__09DE7BCC] FOREIGN KEY([CustID])
REFERENCES [dbo].[Person] ([CustID])
GO
ALTER TABLE [dbo].[Passport] CHECK CONSTRAINT [FK__Passport__CustID__09DE7BCC]
GO
/****** Object:  ForeignKey [FK__Trn__CustID__0EA330E9]    Script Date: 04/30/2013 11:54:30 ******/
ALTER TABLE [dbo].[Trn]  WITH CHECK ADD  CONSTRAINT [FK__Trn__CustID__0EA330E9] FOREIGN KEY([CustID])
REFERENCES [dbo].[Person] ([CustID])
GO
ALTER TABLE [dbo].[Trn] CHECK CONSTRAINT [FK__Trn__CustID__0EA330E9]
GO
