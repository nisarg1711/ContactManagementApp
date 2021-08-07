USE [ContactManagement]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 2021-08-06 6:00:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactDetails]    Script Date: 2021-08-06 6:00:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContactName] [varchar](80) NOT NULL,
	[JobTitle] [varchar](30) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Address] [varchar](200) NOT NULL,
	[Phone] [varchar](15) NOT NULL,
	[Email] [varchar](70) NOT NULL,
	[LastDateContacted] [date] NULL,
	[Comments] [varchar](200) NULL,
	[IsActive] [bit] NULL,
	[LastUpdated] [datetime] NULL,
 CONSTRAINT [PK_ContactDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Company] ON 
GO
INSERT [dbo].[Company] ([CompanyId], [CompanyName]) VALUES (1, N'HP')
GO
INSERT [dbo].[Company] ([CompanyId], [CompanyName]) VALUES (2, N'Disney')
GO
INSERT [dbo].[Company] ([CompanyId], [CompanyName]) VALUES (3, N'MNP')
GO
INSERT [dbo].[Company] ([CompanyId], [CompanyName]) VALUES (4, N'Microsoft')
GO
INSERT [dbo].[Company] ([CompanyId], [CompanyName]) VALUES (5, N'Google')
GO
INSERT [dbo].[Company] ([CompanyId], [CompanyName]) VALUES (6, N'Amazon')
GO
INSERT [dbo].[Company] ([CompanyId], [CompanyName]) VALUES (7, N'Facebook')
GO
SET IDENTITY_INSERT [dbo].[Company] OFF
GO
ALTER TABLE [dbo].[ContactDetails] ADD  CONSTRAINT [DF_ContactDetails_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[ContactDetails]  WITH CHECK ADD  CONSTRAINT [FK_ContactDetails_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([CompanyId])
GO

ALTER TABLE [dbo].[ContactDetails] CHECK CONSTRAINT [FK_ContactDetails_Company]
GO

GO
ALTER TABLE [dbo].[ContactDetails]  WITH CHECK ADD  CONSTRAINT [FK_ContactDetails_ContactDetails] FOREIGN KEY([Id])
REFERENCES [dbo].[ContactDetails] ([Id])
GO

ALTER TABLE [dbo].[ContactDetails] CHECK CONSTRAINT [FK_ContactDetails_ContactDetails]
GO

GO
