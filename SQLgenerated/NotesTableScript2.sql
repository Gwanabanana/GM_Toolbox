CREATE TABLE [dbo].[Notes] (
    [Id]      INT            NOT NULL,
    [Creator] NVARCHAR (MAX) NOT NULL,
	[Title] NVARCHAR (MAX) NOT NULL,
    [Content] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

