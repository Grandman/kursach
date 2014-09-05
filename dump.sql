CREATE TABLE months_records
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [limit] INT NOT NULL, 
    [size] INT NOT NULL, 
    [diff] INT NOT NULL, 
    [month] DATE NOT NULL
)
CREATE TABLE accounting (
    [Id]         INT  IDENTITY (1, 1) NOT NULL,
    [article_id] INT  NOT NULL,
    [date]       DATE NOT NULL,
    [size]       INT  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE articles (
    [id]    INT           IDENTITY (1, 1) NOT NULL,
    [type]  INT           NOT NULL,
    [limit] INT           NOT NULL,
    [name]  NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);
CREATE TABLE client_tour (
    [id]        INT IDENTITY (1, 1) NOT NULL,
    [tour_id]   INT NOT NULL,
    [client_id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);
CREATE TABLE clients (
    [id]     INT        IDENTITY (1, 1) NOT NULL,
    [fio]    NCHAR (50) NOT NULL,
    [phone]  INT        NOT NULL,
    [age]    INT        NOT NULL,
    [budget] INT        NOT NULL,
    [min]    INT        NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);
CREATE TABLE tours (
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





