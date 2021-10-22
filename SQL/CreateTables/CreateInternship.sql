USE [InternshipDb]
GO

/****** Object:  Table [dbo].[Internship]    Script Date: 10/22/2021 8:04:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Internship](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Position] [varchar](180) NOT NULL,
	[CompanyId] [int] NOT NULL FOREIGN KEY REFERENCES Company(Id),
	[DisciplineId] [int] NOT NULL FOREIGN KEY REFERENCES Discipline(Id),
	[UserId] [int] NOT NULL FOREIGN KEY REFERENCES [User](Id),
	[RatingId] [int] NOT NULL FOREIGN KEY REFERENCES Rating(Id),
	[IsRemote] [bit] NOT NULL DEFAULT 0,
	[HasHousing] [bit] NOT NULL DEFAULT 0,
	[Salary] [decimal](19, 2) NULL,
	[Duration] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL
) ON [PRIMARY]
GO


