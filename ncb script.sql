USE [NCB]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 05/06/2013 11:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[Account#] [int] NOT NULL,
	[Fname] [varchar](50) NULL,
	[MiddleName] [varchar](50) NULL,
	[Lname] [varchar](50) NULL,
	[DOB] [date] NULL,
	[Gender] [varchar](10) NULL,
	[Addr] [varchar](100) NULL,
	[MotherMaiden] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[CellNum] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Account#] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Customer] ([Account#], [Fname], [MiddleName], [Lname], [DOB], [Gender], [Addr], [MotherMaiden], [Email], [CellNum]) VALUES (1000009, N'Kareem', N'S', N'Scott', CAST(0xCE140B00 AS Date), N'male', N'123 Street', N'Craig', NULL, NULL)
