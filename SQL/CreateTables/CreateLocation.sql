USE [InternshipDb]
GO

/****** Object:  Table [dbo].[Location]    Script Date: 10/22/2021 7:38:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Location](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[City] [varchar](100) NOT NULL,
	[State] [varchar](100) NOT NULL,
	[ZipCode] [varchar](6) NOT NULL
) ON [PRIMARY]
GO


