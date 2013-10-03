CREATE TABLE [dbo].[articles] (
    [id]   INT  IDENTITY (1, 1) NOT NULL,
    [size] INT  NOT NULL,
    [date] DATE NOT NULL,
    [type] INT  NOT NULL,
    [kind] INT  NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);
CREATE TABLE [dbo].[client_tour] (
    [id]        INT IDENTITY (1, 1) NOT NULL,
    [tour_id]   INT NOT NULL,
    [client_id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);
CREATE TABLE [dbo].[clients] (
    [id]     INT        IDENTITY (1, 1) NOT NULL,
    [fio]    NCHAR (50) NOT NULL,
    [phone]  INT        NOT NULL,
    [age]    INT        NOT NULL,
    [budget] INT        NOT NULL,
    [min]    INT        NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);
CREATE TABLE [dbo].[tours] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [price]       INT            NULL,
    [date]        DATE           NULL,
    [description] NVARCHAR (100) NULL,
    [hotel]       NVARCHAR (50)  NULL,
    [stars]       INT            NULL,
    [url]         NVARCHAR (100) NULL,
    [country]     NVARCHAR (60)  NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);