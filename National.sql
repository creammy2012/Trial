

CREATE TABLE [dbo].[NatID](
	[NatIDNum] [int] NOT NULL,
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
INSERT [dbo].[NatID] ([NatIDNum], [Fname], [MiddleName], [Lname], [DOB], [Gender], [MotherMaiden]) VALUES (123, N'Kareem', N'S', N'Scott', CAST(0xCE140B00 AS Date), N'male', N'Craig')
INSERT [dbo].[NatID] ([NatIDNum], [Fname], [MiddleName], [Lname], [DOB], [Gender], [MotherMaiden]) VALUES (124, N'Valdi', N'P', N'Service', CAST(0x0B150B00 AS Date), N'male', N'Davis')
INSERT [dbo].[NatID] ([NatIDNum], [Fname], [MiddleName], [Lname], [DOB], [Gender], [MotherMaiden]) VALUES (125, N'Ronique', N'A', N'Dixon', CAST(0xC7140B00 AS Date), N'female', N'Rhodes')
/****** Object:  StoredProcedure [dbo].[SelectAllNatIDById]    Script Date: 04/30/2013 11:56:36 ******/
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
 SELECT * FROM [NatID] where [NatIDNum]=@NatIDNum END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllNatID]    Script Date: 04/30/2013 11:56:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectAllNatID] 
 AS 
BEGIN 
 SELECT * FROM [NatID] END
GO
/****** Object:  StoredProcedure [dbo].[SearchNatID]    Script Date: 04/30/2013 11:56:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchNatID] 
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
 SELECT * FROM NatID WHERE 
 (@Fname IS NULL OR [Fname] LIKE '%' + @Fname + '%')  AND
(@MiddleName IS NULL OR [MiddleName] LIKE '%' + @MiddleName + '%')  AND
(@Lname IS NULL OR [Lname] LIKE '%' + @Lname + '%') AND
(@DOB IS NULL OR [DOB] = @DOB )  AND
(@Gender IS NULL OR [Gender] LIKE '%' + @Gender + '%')  AND
(@MotherMaiden IS NULL OR [MotherMaiden] LIKE '%' + @MotherMaiden + '%')  
END
GO
/****** Object:  StoredProcedure [dbo].[NatIDQuery]    Script Date: 04/30/2013 11:56:36 ******/
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
[Fname] LIKE '%' + @query + '%' OR
[MiddleName] LIKE '%' + @query + '%' OR
[Lname] LIKE '%' + @query + '%' OR
(Convert(varchar(120), [DOB] )) LIKE '%' + @query + '%' OR
[Gender] LIKE '%' + @query + '%' OR
[MotherMaiden] LIKE '%' + @query + '%' END
GO
