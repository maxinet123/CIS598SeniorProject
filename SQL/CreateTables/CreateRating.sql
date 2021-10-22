USE [InternshipDb]
GO

/****** Object:  Table [dbo].[Rating]    Script Date: 10/22/2021 7:46:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Rating](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Number] [int] NOT NULL
) ON [PRIMARY]
GO


