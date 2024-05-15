USE master
GO

-- Drop the database if it exists
IF EXISTS (
    SELECT 1
    FROM sys.databases
    WHERE name = 'MOVIEDB'
)
DROP DATABASE MOVIEDB;

GO

-- Create the database
CREATE DATABASE MOVIEDB;
GO

USE MOVIEDB;

-- Create the GENRES table
CREATE TABLE GENRES (
    genreID INT PRIMARY KEY,
    genreName VARCHAR(255)
);

-- Create the MOVIES table
CREATE TABLE MOVIES (
    movieID INT PRIMARY KEY,
    movieName VARCHAR(255),
    movieOriginalName VARCHAR(255),
    releaseDate DATE,
    overview TEXT,
    popularity DECIMAL(10,2),
    voteAverage DECIMAL(3,2),
    voteCount INT,
    posterPath VARCHAR(255),
    backdropPath VARCHAR(255),
    video BIT,
    originalLanguage VARCHAR(10),
    adult BIT,
    tag VARCHAR(255) -- removed genreID
);

-- Create the SERIES table
CREATE TABLE SERIES (
    serieID INT PRIMARY KEY,
    serieName VARCHAR(255),
    serieOriginalName VARCHAR(255),
    firstAirDate DATE,
    lastAirDate DATE,
    status VARCHAR(50),
    tagline VARCHAR(255),
    overview TEXT,
    homepage VARCHAR(255),
    popularity DECIMAL(10,2),
    voteAverage DECIMAL(3,2),
    voteCount INT,
    posterPath VARCHAR(255),
    backdropPath VARCHAR(255),
    trailer VARCHAR(255),
    numberOfSeasons INT,
    numberOfEpisodes INT,
    type VARCHAR(50),
    tag VARCHAR(255),
    adult BIT
);

-- Create the SEASONS table
CREATE TABLE SEASONS (
    seasonID INT PRIMARY KEY,
    serieID INT,
    airdate DATE,
    seasonName VARCHAR(255),
    overview TEXT,
    posterPath VARCHAR(255),
    seasonNumber INT,
    voteAverage DECIMAL(3,2),
    FOREIGN KEY (serieID) REFERENCES SERIES(serieID)
);

-- Create the USERS table
CREATE TABLE USERS (
    userID INT PRIMARY KEY,
    username VARCHAR(50),
    password VARCHAR(50),
    fullname VARCHAR(100),
    birthdate DATE,
    gender VARCHAR(10),
    profileImage VARCHAR(255),
    email VARCHAR(100)
);

-- Create the REVIEWS table
CREATE TABLE REVIEWS (
    reviewID INT PRIMARY KEY,
    mediaID INT,
    mediaType VARCHAR(50),
    author VARCHAR(100),
    content TEXT,
    rating DECIMAL(3,2),
    created_at DATETIME,
    url VARCHAR(255),
    userID INT,
    FOREIGN KEY (mediaID) REFERENCES MOVIES(movieID),
    FOREIGN KEY (mediaID) REFERENCES SERIES(serieID),
    FOREIGN KEY (userID) REFERENCES USERS(userID)
);

-- Create the WATCHLISTS table
CREATE TABLE WATCHLISTS (
    watchlistID INT PRIMARY KEY,
    watchlistName VARCHAR(255),
    userID INT,
    movieID INT,
    serieID INT,
    CONSTRAINT UC_UserMovieSerie UNIQUE (userID, movieID, serieID), -- Ensure only one connection per user, movie, and serie
    FOREIGN KEY (userID) REFERENCES USERS(userID),
    FOREIGN KEY (movieID) REFERENCES MOVIES(movieID),
    FOREIGN KEY (serieID) REFERENCES SERIES(serieID)
);

-- Create the ACTORS table
CREATE TABLE ACTORS (
    actorID INT PRIMARY KEY,
    actorName VARCHAR(100),
    gender VARCHAR(10),
    knownForDepartment VARCHAR(100),
    originalName VARCHAR(100),
    popularity DECIMAL(10,2),
    profilePath VARCHAR(255),
    biography TEXT,
    birthdate DATE,
    placeOfBirth VARCHAR(255),
    imdbID VARCHAR(20)
);

-- Create the many-to-many relationship table for movie-genre
CREATE TABLE Movie_Genre (
    movieID INT,
    genreID INT,
    PRIMARY KEY (movieID, genreID),
    FOREIGN KEY (movieID) REFERENCES MOVIES(movieID),
    FOREIGN KEY (genreID) REFERENCES GENRES(genreID)
);

-- Create the many-to-many relationship table for serie-genre
CREATE TABLE Serie_Genre (
    serieID INT,
    genreID INT,
    PRIMARY KEY (serieID, genreID),
    FOREIGN KEY (serieID) REFERENCES SERIES(serieID),
    FOREIGN KEY (genreID) REFERENCES GENRES(genreID)
);

-- Create the many-to-many relationship table for actor-movie
CREATE TABLE Actor_Movie (
    actorID INT,
    movieID INT,
    PRIMARY KEY (actorID, movieID),
    FOREIGN KEY (actorID) REFERENCES ACTORS(actorID),
    FOREIGN KEY (movieID) REFERENCES MOVIES(movieID)
);

-- Create the many-to-many relationship table for actor-serie
CREATE TABLE Actor_Serie (
    actorID INT,
    serieID INT,
    PRIMARY KEY (actorID, serieID),
    FOREIGN KEY (actorID) REFERENCES ACTORS(actorID),
    FOREIGN KEY (serieID) REFERENCES SERIES(serieID)
);

-- Create the foreign key relationship between REVIEWS and USERS
ALTER TABLE REVIEWS
ADD CONSTRAINT FK_Reviews_Users FOREIGN KEY (userID) REFERENCES USERS(userID);

