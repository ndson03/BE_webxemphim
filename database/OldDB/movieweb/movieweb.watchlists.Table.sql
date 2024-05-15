USE [movieweb]
GO
/****** Object:  Table [movieweb].[watchlists]    Script Date: 5/15/2024 10:58:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [movieweb].[watchlists](
	[watchlistID] [int] NOT NULL,
	[watchlistName] [nvarchar](45) NULL,
	[userID] [int] NULL,
 CONSTRAINT [PK_watchlists_watchlistID] PRIMARY KEY CLUSTERED 
(
	[watchlistID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [movieweb].[watchlists] ([watchlistID], [watchlistName], [userID]) VALUES (1, N'favoriteList', 1)
GO
/****** Object:  Index [wlist_user_idx]    Script Date: 5/15/2024 10:58:41 AM ******/
CREATE NONCLUSTERED INDEX [wlist_user_idx] ON [movieweb].[watchlists]
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [movieweb].[watchlists] ADD  DEFAULT (NULL) FOR [watchlistName]
GO
ALTER TABLE [movieweb].[watchlists] ADD  DEFAULT (NULL) FOR [userID]
GO
ALTER TABLE [movieweb].[watchlists]  WITH CHECK ADD  CONSTRAINT [FK_watchlists_users] FOREIGN KEY([userID])
REFERENCES [movieweb].[users] ([userID])
GO
ALTER TABLE [movieweb].[watchlists] CHECK CONSTRAINT [FK_watchlists_users]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'movieweb.watchlists' , @level0type=N'SCHEMA',@level0name=N'movieweb', @level1type=N'TABLE',@level1name=N'watchlists'
GO
