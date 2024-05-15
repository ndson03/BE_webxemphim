USE [movieweb]
GO
/****** Object:  Table [movieweb].[reviews]    Script Date: 5/15/2024 10:58:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [movieweb].[reviews](
	[reviewID] [int] NOT NULL,
	[content] [nvarchar](max) NULL,
	[rating] [real] NULL,
	[timestamp] [nvarchar](45) NULL,
	[movieID] [int] NULL,
	[serieID] [int] NULL,
	[userID] [int] NULL,
 CONSTRAINT [PK_reviews_reviewID] PRIMARY KEY CLUSTERED 
(
	[reviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [movieReview_idx]    Script Date: 5/15/2024 10:58:41 AM ******/
CREATE NONCLUSTERED INDEX [movieReview_idx] ON [movieweb].[reviews]
(
	[movieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [serieReview_idx]    Script Date: 5/15/2024 10:58:41 AM ******/
CREATE NONCLUSTERED INDEX [serieReview_idx] ON [movieweb].[reviews]
(
	[serieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [userReview_idx]    Script Date: 5/15/2024 10:58:41 AM ******/
CREATE NONCLUSTERED INDEX [userReview_idx] ON [movieweb].[reviews]
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [movieweb].[reviews] ADD  DEFAULT (NULL) FOR [rating]
GO
ALTER TABLE [movieweb].[reviews] ADD  DEFAULT (NULL) FOR [timestamp]
GO
ALTER TABLE [movieweb].[reviews] ADD  DEFAULT ((0)) FOR [movieID]
GO
ALTER TABLE [movieweb].[reviews] ADD  DEFAULT ((0)) FOR [serieID]
GO
ALTER TABLE [movieweb].[reviews] ADD  DEFAULT ((0)) FOR [userID]
GO
ALTER TABLE [movieweb].[reviews]  WITH NOCHECK ADD  CONSTRAINT [FK_reviews_movie] FOREIGN KEY([movieID])
REFERENCES [movieweb].[movie] ([movieID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [movieweb].[reviews] CHECK CONSTRAINT [FK_reviews_movie]
GO
ALTER TABLE [movieweb].[reviews]  WITH NOCHECK ADD  CONSTRAINT [FK_reviews_series] FOREIGN KEY([serieID])
REFERENCES [movieweb].[series] ([serieID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [movieweb].[reviews] CHECK CONSTRAINT [FK_reviews_series]
GO
ALTER TABLE [movieweb].[reviews]  WITH NOCHECK ADD  CONSTRAINT [FK_reviews_users] FOREIGN KEY([userID])
REFERENCES [movieweb].[users] ([userID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [movieweb].[reviews] CHECK CONSTRAINT [FK_reviews_users]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'movieweb.reviews' , @level0type=N'SCHEMA',@level0name=N'movieweb', @level1type=N'TABLE',@level1name=N'reviews'
GO
