USE [SimpleModularApplication]
GO

/****** Object: Table [dbo].[Customers] Script Date: 4/9/2018 8:54:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers] (
    [Id]        BIGINT          NOT NULL IDENTITY(1,1),
    [Name]      VARCHAR (50) NULL,
    [Surrname]  VARCHAR (50) NULL,
    [Telephone] VARCHAR (50) NULL,
    [Address]   VARCHAR (50) NULL
);


