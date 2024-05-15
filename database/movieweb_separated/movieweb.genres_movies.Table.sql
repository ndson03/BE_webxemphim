USE [movieweb]
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_SSMA_SOURCE' , @level0type=N'SCHEMA',@level0name=N'movieweb', @level1type=N'TABLE',@level1name=N'genres_movies'
GO
ALTER TABLE [movieweb].[genres_movies] DROP CONSTRAINT [FK_genres_movies_movie]
GO
ALTER TABLE [movieweb].[genres_movies] DROP CONSTRAINT [FK_genres_movies_genre]
GO
/****** Object:  Index [movieID_idx]    Script Date: 5/15/2024 8:01:05 PM ******/
DROP INDEX [movieID_idx] ON [movieweb].[genres_movies]
GO
/****** Object:  Table [movieweb].[genres_movies]    Script Date: 5/15/2024 8:01:05 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[movieweb].[genres_movies]') AND type in (N'U'))
DROP TABLE [movieweb].[genres_movies]
GO
/****** Object:  Table [movieweb].[genres_movies]    Script Date: 5/15/2024 8:01:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [movieweb].[genres_movies](
	[genreID] [int] NOT NULL,
	[movieID] [int] NOT NULL,
 CONSTRAINT [PK_genres_movies_genreID] PRIMARY KEY CLUSTERED 
(
	[genreID] ASC,
	[movieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (18, 13)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (35, 13)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (10749, 13)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (12, 122)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (14, 122)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (28, 122)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (14, 129)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (16, 129)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (10751, 129)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (18, 155)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (28, 155)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (18, 238)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (80, 238)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (18, 240)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (80, 240)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (18, 278)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (80, 278)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (18, 346)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (28, 346)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (18, 389)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (18, 424)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (36, 424)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (10752, 424)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (37, 429)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (14, 497)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (18, 497)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (80, 497)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (18, 637)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (35, 637)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (53, 680)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (80, 680)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (18, 769)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (80, 769)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (18, 11216)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (10749, 11216)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (16, 12477)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (18, 12477)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (10752, 12477)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (18, 19404)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (35, 19404)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (10749, 19404)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (16, 372058)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (18, 372058)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (10749, 372058)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (27, 437342)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (12, 438631)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (878, 438631)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (18, 467244)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (36, 467244)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (10752, 467244)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (18, 496243)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (35, 496243)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (53, 496243)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (12, 508883)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (14, 508883)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (16, 508883)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (12, 624091)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (14, 624091)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (18, 624091)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (28, 624091)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (878, 624091)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (14, 634492)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (28, 634492)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (12, 693134)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (878, 693134)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (27, 744857)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (53, 744857)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (18, 760774)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (36, 760774)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (10752, 760774)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (12, 763215)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (14, 763215)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (28, 763215)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (9648, 763215)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (14, 787699)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (35, 787699)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (10751, 787699)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (35, 792307)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (878, 792307)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (10749, 792307)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (18, 802219)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (36, 802219)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (10402, 802219)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (12, 823464)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (28, 823464)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (878, 823464)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (27, 838209)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (53, 838209)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (9648, 838209)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (16, 838240)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (18, 838240)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (35, 838240)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (10751, 838240)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (12, 848538)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (28, 848538)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (35, 848538)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (18, 850165)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (36, 850165)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (18, 866398)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (28, 866398)
GO
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (53, 866398)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (18, 872585)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (36, 872585)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (28, 897087)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (35, 897087)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (53, 915935)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (80, 915935)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (9648, 915935)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (28, 927107)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (53, 927107)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (28, 932420)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (80, 932420)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (878, 932420)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (12, 940551)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (16, 940551)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (28, 940551)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (35, 940551)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (10751, 940551)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (12, 967847)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (14, 967847)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (35, 967847)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (28, 969492)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (53, 969492)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (10752, 969492)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (12, 1011985)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (16, 1011985)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (28, 1011985)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (35, 1011985)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (10751, 1011985)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (14, 1019420)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (35, 1019420)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (10749, 1019420)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (28, 1046090)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (80, 1046090)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (28, 1049948)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (35, 1072790)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (10749, 1072790)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (28, 1081620)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (28, 1094556)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (35, 1094556)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (878, 1094556)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (10751, 1094556)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (27, 1096197)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (28, 1096197)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (53, 1096197)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (27, 1125311)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (53, 1125311)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (9648, 1125311)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (16, 1239251)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (35, 1239251)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (878, 1239251)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (18, 1248795)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (28, 1248795)
INSERT [movieweb].[genres_movies] ([genreID], [movieID]) VALUES (10749, 1248795)
GO
/****** Object:  Index [movieID_idx]    Script Date: 5/15/2024 8:01:05 PM ******/
CREATE NONCLUSTERED INDEX [movieID_idx] ON [movieweb].[genres_movies]
(
	[movieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [movieweb].[genres_movies]  WITH CHECK ADD  CONSTRAINT [FK_genres_movies_genre] FOREIGN KEY([genreID])
REFERENCES [movieweb].[genre] ([genreID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [movieweb].[genres_movies] CHECK CONSTRAINT [FK_genres_movies_genre]
GO
ALTER TABLE [movieweb].[genres_movies]  WITH CHECK ADD  CONSTRAINT [FK_genres_movies_movie] FOREIGN KEY([movieID])
REFERENCES [movieweb].[movie] ([movieID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [movieweb].[genres_movies] CHECK CONSTRAINT [FK_genres_movies_movie]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'movieweb.genres_movies' , @level0type=N'SCHEMA',@level0name=N'movieweb', @level1type=N'TABLE',@level1name=N'genres_movies'
GO
