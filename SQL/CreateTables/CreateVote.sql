USE [InternshipDb]
GO

/****** Object:  Table [dbo].[Vote]    Script Date: 10/22/2021 8:10:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Vote](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[InternshipId] [int] NOT NULL FOREIGN KEY REFERENCES Internship(Id),
	[UserId] [int] NOT NULL FOREIGN KEY REFERENCES [User](Id),
	[Number] [int] NOT NULL
) ON [PRIMARY]
GO


