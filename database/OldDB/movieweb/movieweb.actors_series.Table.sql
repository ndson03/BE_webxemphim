USE [movieweb]
GO
/****** Object:  Table [movieweb].[actors_series]    Script Date: 5/15/2024 10:58:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [movieweb].[actors_series](
	[actorID] [int] NOT NULL,
	[serieID] [int] NOT NULL,
 CONSTRAINT [PK_actors_series_actorID] PRIMARY KEY CLUSTERED 
(
	[actorID] ASC,
	[serieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [serieID_idx]    Script Date: 5/15/2024 10:58:41 AM ******/
CREATE NONCLUSTERED INDEX [serieID_idx] ON [movieweb].[actors_series]
(
	[serieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [movieweb].[actors_series]  WITH CHECK ADD  CONSTRAINT [FK_actors_series_actors] FOREIGN KEY([actorID])
REFERENCES [movieweb].[actors] ([actorID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [movieweb].[actors_series] CHECK CONSTRAINT [FK_actors_series_actors]
GO
ALTER TABLE [movieweb].[actors_series]  WITH CHECK ADD  CONSTRAINT [FK_actors_series_series] FOREIGN KEY([serieID])
REFERENCES [movieweb].[series] ([serieID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [movieweb].[actors_series] CHECK CONSTRAINT [FK_actors_series_series]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'movieweb.actors_series' , @level0type=N'SCHEMA',@level0name=N'movieweb', @level1type=N'TABLE',@level1name=N'actors_series'
GO
