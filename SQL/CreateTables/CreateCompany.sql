USE [InternshipDb]
GO

/****** Object:  Table [dbo].[Company]    Script Date: 10/22/2021 7:43:41 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [varchar](256) NOT NULL
) ON [PRIMARY]
GO


