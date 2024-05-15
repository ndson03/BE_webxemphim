USE [movieweb]
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_SSMA_SOURCE' , @level0type=N'SCHEMA',@level0name=N'movieweb', @level1type=N'TABLE',@level1name=N'list_watchlist'
GO
ALTER TABLE [movieweb].[list_watchlist] DROP CONSTRAINT [FK_list_watchlist_watchlists]
GO
ALTER TABLE [movieweb].[list_watchlist] DROP CONSTRAINT [FK_list_watchlist_series]
GO
ALTER TABLE [movieweb].[list_watchlist] DROP CONSTRAINT [FK_list_watchlist_movie]
GO
/****** Object:  Index [wtchlist_serie_idx]    Script Date: 5/15/2024 8:01:05 PM ******/
DROP INDEX [wtchlist_serie_idx] ON [movieweb].[list_watchlist]
GO
/****** Object:  Index [wtchlist_movie_idx]    Script Date: 5/15/2024 8:01:05 PM ******/
DROP INDEX [wtchlist_movie_idx] ON [movieweb].[list_watchlist]
GO
/****** Object:  Table [movieweb].[list_watchlist]    Script Date: 5/15/2024 8:01:05 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[movieweb].[list_watchlist]') AND type in (N'U'))
DROP TABLE [movieweb].[list_watchlist]
GO
/****** Object:  Table [movieweb].[list_watchlist]    Script Date: 5/15/2024 8:01:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [movieweb].[list_watchlist](
	[watchlistID] [int] NULL,
	[movieID] [int] NULL,
	[serieID] [int] NULL,
	[listID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_list_watchlist_watchlistID] PRIMARY KEY CLUSTERED 
(
	[listID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [movieweb].[list_watchlist] ON 

INSERT [movieweb].[list_watchlist] ([watchlistID], [movieID], [serieID], [listID]) VALUES (1, 155, NULL, 3)
INSERT [movieweb].[list_watchlist] ([watchlistID], [movieID], [serieID], [listID]) VALUES (1, NULL, 456, 4)
INSERT [movieweb].[list_watchlist] ([watchlistID], [movieID], [serieID], [listID]) VALUES (1, 13, NULL, 5)
INSERT [movieweb].[list_watchlist] ([watchlistID], [movieID], [serieID], [listID]) VALUES (1, NULL, 246, 6)
INSERT [movieweb].[list_watchlist] ([watchlistID], [movieID], [serieID], [listID]) VALUES (2, 155, NULL, 9)
SET IDENTITY_INSERT [movieweb].[list_watchlist] OFF
GO
/****** Object:  Index [wtchlist_movie_idx]    Script Date: 5/15/2024 8:01:05 PM ******/
CREATE NONCLUSTERED INDEX [wtchlist_movie_idx] ON [movieweb].[list_watchlist]
(
	[movieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [wtchlist_serie_idx]    Script Date: 5/15/2024 8:01:05 PM ******/
CREATE NONCLUSTERED INDEX [wtchlist_serie_idx] ON [movieweb].[list_watchlist]
(
	[serieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [movieweb].[list_watchlist]  WITH CHECK ADD  CONSTRAINT [FK_list_watchlist_movie] FOREIGN KEY([movieID])
REFERENCES [movieweb].[movie] ([movieID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [movieweb].[list_watchlist] CHECK CONSTRAINT [FK_list_watchlist_movie]
GO
ALTER TABLE [movieweb].[list_watchlist]  WITH CHECK ADD  CONSTRAINT [FK_list_watchlist_series] FOREIGN KEY([serieID])
REFERENCES [movieweb].[series] ([serieID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [movieweb].[list_watchlist] CHECK CONSTRAINT [FK_list_watchlist_series]
GO
ALTER TABLE [movieweb].[list_watchlist]  WITH CHECK ADD  CONSTRAINT [FK_list_watchlist_watchlists] FOREIGN KEY([watchlistID])
REFERENCES [movieweb].[watchlists] ([watchlistID])
GO
ALTER TABLE [movieweb].[list_watchlist] CHECK CONSTRAINT [FK_list_watchlist_watchlists]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'movieweb.list_watchlist' , @level0type=N'SCHEMA',@level0name=N'movieweb', @level1type=N'TABLE',@level1name=N'list_watchlist'
GO
