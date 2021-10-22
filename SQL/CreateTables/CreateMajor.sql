USE [InternshipDb]
GO

/****** Object:  Table [dbo].[Major]    Script Date: 10/22/2021 7:40:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Major](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [varchar](50) NOT NULL
) ON [PRIMARY]
GO


