
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/04/2016 13:22:27
-- Generated from EDMX file: C:\Users\halle\Documents\NetClass\RecreationalRespiteDashboardDesigned\RecreationalRespiteDashboardDesigned\Models\RecDatabaseModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [recDashFirebase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserInformations'
CREATE TABLE [dbo].[UserInformations] (
    [username] int IDENTITY(1,1) NOT NULL,
    [city] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NOT NULL,
    [firstname] nvarchar(max)  NOT NULL,
    [lastname] nvarchar(max)  NOT NULL,
    [phoneNumber] nvarchar(max)  NOT NULL,
    [region] nvarchar(max)  NOT NULL,
    [userType] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'participants'
CREATE TABLE [dbo].[participants] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [diagnosis] nvarchar(max)  NOT NULL,
    [firstname] nvarchar(max)  NOT NULL,
    [gender] nvarchar(max)  NOT NULL,
    [lastname] nvarchar(max)  NOT NULL,
    [notes] nvarchar(max)  NOT NULL,
    [program] nvarchar(max)  NOT NULL,
    [username] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'articles'
CREATE TABLE [dbo].[articles] (
    [articleId] int IDENTITY(1,1) NOT NULL,
    [articleImage] nvarchar(max)  NOT NULL,
    [articlePDF] nvarchar(max)  NOT NULL,
    [description] nvarchar(max)  NOT NULL,
    [name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'diagnosis'
CREATE TABLE [dbo].[diagnosis] (
    [diagnosisId] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'events'
CREATE TABLE [dbo].[events] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [cost] nvarchar(max)  NOT NULL,
    [date] nvarchar(max)  NOT NULL,
    [endTime] nvarchar(max)  NOT NULL,
    [endDescription] nvarchar(max)  NOT NULL,
    [eventImage] nvarchar(max)  NOT NULL,
    [eventName] nvarchar(max)  NOT NULL,
    [location] nvarchar(max)  NOT NULL,
    [region] nvarchar(max)  NOT NULL,
    [startTime] nvarchar(max)  NOT NULL,
    [totalSeats] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'registrations'
CREATE TABLE [dbo].[registrations] (
    [username] int IDENTITY(1,1) NOT NULL,
    [age] nvarchar(max)  NOT NULL,
    [allergies] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NOT NULL,
    [emergencyPhone] nvarchar(max)  NOT NULL,
    [expectationsAndGoals] nvarchar(max)  NOT NULL,
    [location] nvarchar(max)  NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [paymentType] nvarchar(max)  NOT NULL,
    [phone] nvarchar(max)  NOT NULL,
    [programOfInterest] nvarchar(max)  NOT NULL,
    [recreationalInterest] nvarchar(max)  NOT NULL,
    [specialNeeds] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'regions'
CREATE TABLE [dbo].[regions] (
    [regionId] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [username] in table 'UserInformations'
ALTER TABLE [dbo].[UserInformations]
ADD CONSTRAINT [PK_UserInformations]
    PRIMARY KEY CLUSTERED ([username] ASC);
GO

-- Creating primary key on [Id] in table 'participants'
ALTER TABLE [dbo].[participants]
ADD CONSTRAINT [PK_participants]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [articleId] in table 'articles'
ALTER TABLE [dbo].[articles]
ADD CONSTRAINT [PK_articles]
    PRIMARY KEY CLUSTERED ([articleId] ASC);
GO

-- Creating primary key on [diagnosisId] in table 'diagnosis'
ALTER TABLE [dbo].[diagnosis]
ADD CONSTRAINT [PK_diagnosis]
    PRIMARY KEY CLUSTERED ([diagnosisId] ASC);
GO

-- Creating primary key on [Id] in table 'events'
ALTER TABLE [dbo].[events]
ADD CONSTRAINT [PK_events]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [username] in table 'registrations'
ALTER TABLE [dbo].[registrations]
ADD CONSTRAINT [PK_registrations]
    PRIMARY KEY CLUSTERED ([username] ASC);
GO

-- Creating primary key on [regionId] in table 'regions'
ALTER TABLE [dbo].[regions]
ADD CONSTRAINT [PK_regions]
    PRIMARY KEY CLUSTERED ([regionId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------