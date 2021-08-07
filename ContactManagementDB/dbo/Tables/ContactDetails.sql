CREATE TABLE [dbo].[ContactDetails] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [ContactName]       VARCHAR (80)  NOT NULL,
    [JobTitle]          VARCHAR (30)  NOT NULL,
    [CompanyId]         INT           NOT NULL,
    [Address]           VARCHAR (200) NOT NULL,
    [Phone]             VARCHAR (15)  NOT NULL,
    [Email]             VARCHAR (70)  NOT NULL,
    [LastDateContacted] DATE          NULL,
    [Comments]          VARCHAR (200) NULL,
    [IsActive]          BIT           CONSTRAINT [DF_ContactDetails_IsActive] DEFAULT ((1)) NULL,
    [LastUpdated]       DATETIME      NULL,
    CONSTRAINT [PK_ContactDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ContactDetails_Company] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([CompanyId]),
    CONSTRAINT [FK_ContactDetails_ContactDetails] FOREIGN KEY ([Id]) REFERENCES [dbo].[ContactDetails] ([Id])
);

