USE [C:\PROJECTMANAGER\PROJECTMANAGERWEB\APP_DATA\PROJECTMANAGER.MDF]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ForumPost](
	[ForumId] [int] IDENTITY(1,1) NOT NULL,
	[ForumSubject] [varchar](max) NULL,
	[ForumPost] [varchar](max) NULL,
	[UserId] [int] NOT NULL,
	[DateEntered] [datetime] NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_ForumPost] PRIMARY KEY CLUSTERED 
(
	[ForumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

