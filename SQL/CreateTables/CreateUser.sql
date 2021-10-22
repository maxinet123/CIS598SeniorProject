USE [InternshipDb]
GO

/****** Object:  Table [dbo].[User]    Script Date: 10/22/2021 7:54:09 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NULL,
	[UserName] [varchar](50) NOT NULL,
	[Email] [varchar](180) NOT NULL UNIQUE,
	[MajorId] [int] NOT NULL,
	FOREIGN KEY (MajorId) REFERENCES Major(Id)
) ON [PRIMARY]
GO


