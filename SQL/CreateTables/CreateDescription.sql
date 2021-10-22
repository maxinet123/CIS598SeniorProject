USE [InternshipDb]
GO

/****** Object:  Table [dbo].[Description]    Script Date: 10/22/2021 8:09:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Description](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[InternshipId] [int] NOT NULL FOREIGN KEY REFERENCES Internship(Id),
	[Description] [varchar](500) NOT NULL
) ON [PRIMARY]
GO


