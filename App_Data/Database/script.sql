USE [Latihan]
GO
/****** Object:  Table [dbo].[TBBrand]    Script Date: 7/25/2023 04:11:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBBrand](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UID] [uniqueidentifier] NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [text] NULL,
	[Telephone] [varchar](14) NULL,
	[Email] [varchar](50) NULL,
	[CreatedAt] [datetime] NULL,
 CONSTRAINT [PK_TBBrand] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBCompany]    Script Date: 7/25/2023 04:11:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBCompany](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UID] [uniqueidentifier] NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [text] NULL,
	[Telephone] [varchar](14) NULL,
	[CreatedAt] [datetime] NULL,
 CONSTRAINT [PK_TBCompany] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[TBCompany] ON 

INSERT [dbo].[TBCompany] ([ID], [UID], [Name], [Address], [Telephone], [CreatedAt]) VALUES (2, N'f060d758-6bb2-4e39-889f-0e50575af725', N'ABC', N'-', N'-         ', CAST(N'2023-07-24T11:57:53.977' AS DateTime))
SET IDENTITY_INSERT [dbo].[TBCompany] OFF
GO
USE [master]
GO
ALTER DATABASE [Latihan] SET  READ_WRITE 
GO
