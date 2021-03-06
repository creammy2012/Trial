


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
