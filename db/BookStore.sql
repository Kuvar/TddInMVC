USE [BookStore]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 4/5/2018 10:28:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [nvarchar](100) NULL,
	[AuthorName] [nvarchar](100) NULL,
	[ISBN] [nchar](10) NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
