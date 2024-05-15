USE [movieweb]
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_SSMA_SOURCE' , @level0type=N'SCHEMA',@level0name=N'movieweb', @level1type=N'TABLE',@level1name=N'actors_movies'
GO
ALTER TABLE [movieweb].[actors_movies] DROP CONSTRAINT [FK_actors_movies_movie]
GO
ALTER TABLE [movieweb].[actors_movies] DROP CONSTRAINT [FK_actors_movies_actors]
GO
/****** Object:  Index [movieID_idx]    Script Date: 5/15/2024 8:01:05 PM ******/
DROP INDEX [movieID_idx] ON [movieweb].[actors_movies]
GO
/****** Object:  Table [movieweb].[actors_movies]    Script Date: 5/15/2024 8:01:05 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[movieweb].[actors_movies]') AND type in (N'U'))
DROP TABLE [movieweb].[actors_movies]
GO
/****** Object:  Table [movieweb].[actors_movies]    Script Date: 5/15/2024 8:01:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [movieweb].[actors_movies](
	[actorID] [int] NOT NULL,
	[movieID] [int] NOT NULL,
 CONSTRAINT [PK_actors_movies_actorID] PRIMARY KEY CLUSTERED 
(
	[actorID] ASC,
	[movieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [movieID_idx]    Script Date: 5/15/2024 8:01:05 PM ******/
CREATE NONCLUSTERED INDEX [movieID_idx] ON [movieweb].[actors_movies]
(
	[movieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [movieweb].[actors_movies]  WITH CHECK ADD  CONSTRAINT [FK_actors_movies_actors] FOREIGN KEY([actorID])
REFERENCES [movieweb].[actors] ([actorID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [movieweb].[actors_movies] CHECK CONSTRAINT [FK_actors_movies_actors]
GO
ALTER TABLE [movieweb].[actors_movies]  WITH CHECK ADD  CONSTRAINT [FK_actors_movies_movie] FOREIGN KEY([movieID])
REFERENCES [movieweb].[movie] ([movieID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [movieweb].[actors_movies] CHECK CONSTRAINT [FK_actors_movies_movie]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'movieweb.actors_movies' , @level0type=N'SCHEMA',@level0name=N'movieweb', @level1type=N'TABLE',@level1name=N'actors_movies'
GO
