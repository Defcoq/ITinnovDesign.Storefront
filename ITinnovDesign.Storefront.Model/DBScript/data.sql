USE [ITinnovDesignStorefront]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 28/02/2021 13:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 28/02/2021 13:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 28/02/2021 13:51:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductColors]    Script Date: 28/02/2021 13:51:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductColors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProductColors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 28/02/2021 13:51:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ProductColorId] [int] NOT NULL,
	[ProductSizeId] [int] NOT NULL,
	[ProductTitleId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSizes]    Script Date: 28/02/2021 13:51:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSizes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProductSizes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductTitles]    Script Date: 28/02/2021 13:51:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTitles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[BrandId] [int] NULL,
	[CategoryId] [int] NULL,
	[ColorId] [int] NULL,
 CONSTRAINT [PK_ProductTitles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201110183014_CreateITinnovDesignStorefront', N'3.1.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201110183837_CreateITinnovDesignStorefront2', N'3.1.1')
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([Id], [Name]) VALUES (1, N'JPCollection')
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (2, N'SofiaCollection')
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (3, N'SienaCollection')
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (4, N'Bench')
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (5, N'Levi')
SET IDENTITY_INSERT [dbo].[Brands] OFF
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Clothes')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Geans')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'T-Shirt')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Trousers')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[ProductColors] ON 

INSERT [dbo].[ProductColors] ([Id], [Name]) VALUES (1, N'Red')
INSERT [dbo].[ProductColors] ([Id], [Name]) VALUES (2, N'Green')
INSERT [dbo].[ProductColors] ([Id], [Name]) VALUES (3, N'White')
INSERT [dbo].[ProductColors] ([Id], [Name]) VALUES (4, N'Yellow')
INSERT [dbo].[ProductColors] ([Id], [Name]) VALUES (6, N'Blue')
INSERT [dbo].[ProductColors] ([Id], [Name]) VALUES (7, N'Black')
INSERT [dbo].[ProductColors] ([Id], [Name]) VALUES (8, N'Brown')
INSERT [dbo].[ProductColors] ([Id], [Name]) VALUES (9, N'Green')
INSERT [dbo].[ProductColors] ([Id], [Name]) VALUES (10, N'Red')
INSERT [dbo].[ProductColors] ([Id], [Name]) VALUES (11, N'White')
INSERT [dbo].[ProductColors] ([Id], [Name]) VALUES (12, N'Silver')
SET IDENTITY_INSERT [dbo].[ProductColors] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [BrandId], [CategoryId], [ProductColorId], [ProductSizeId], [ProductTitleId]) VALUES (1, 1, 1, 1, 1, 1)
INSERT [dbo].[Products] ([Id], [BrandId], [CategoryId], [ProductColorId], [ProductSizeId], [ProductTitleId]) VALUES (2, 2, 2, 2, 2, 2)
INSERT [dbo].[Products] ([Id], [BrandId], [CategoryId], [ProductColorId], [ProductSizeId], [ProductTitleId]) VALUES (3, 3, 3, 3, 3, 3)
INSERT [dbo].[Products] ([Id], [BrandId], [CategoryId], [ProductColorId], [ProductSizeId], [ProductTitleId]) VALUES (4, 1, 1, 2, 1, 2)
INSERT [dbo].[Products] ([Id], [BrandId], [CategoryId], [ProductColorId], [ProductSizeId], [ProductTitleId]) VALUES (5, 2, 1, 1, 2, 1)
INSERT [dbo].[Products] ([Id], [BrandId], [CategoryId], [ProductColorId], [ProductSizeId], [ProductTitleId]) VALUES (6, 1, 3, 2, 3, 2)
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[ProductSizes] ON 

INSERT [dbo].[ProductSizes] ([Id], [Name]) VALUES (1, N'30x30')
INSERT [dbo].[ProductSizes] ([Id], [Name]) VALUES (2, N'25x30')
INSERT [dbo].[ProductSizes] ([Id], [Name]) VALUES (3, N'45x24')
INSERT [dbo].[ProductSizes] ([Id], [Name]) VALUES (5, N'M ')
INSERT [dbo].[ProductSizes] ([Id], [Name]) VALUES (6, N'L')
INSERT [dbo].[ProductSizes] ([Id], [Name]) VALUES (7, N'XL')
INSERT [dbo].[ProductSizes] ([Id], [Name]) VALUES (8, N'S')
SET IDENTITY_INSERT [dbo].[ProductSizes] OFF
SET IDENTITY_INSERT [dbo].[ProductTitles] ON 

INSERT [dbo].[ProductTitles] ([Id], [Name], [Price], [BrandId], [CategoryId], [ColorId]) VALUES (1, N'T-Shirt Siena', CAST(20.00 AS Decimal(18, 2)), 1, 1, 1)
INSERT [dbo].[ProductTitles] ([Id], [Name], [Price], [BrandId], [CategoryId], [ColorId]) VALUES (2, N'T-Shiert-Sofia', CAST(50.00 AS Decimal(18, 2)), 2, 2, 2)
INSERT [dbo].[ProductTitles] ([Id], [Name], [Price], [BrandId], [CategoryId], [ColorId]) VALUES (3, N'Gean-Sofia', CAST(100.00 AS Decimal(18, 2)), 3, 3, 3)
INSERT [dbo].[ProductTitles] ([Id], [Name], [Price], [BrandId], [CategoryId], [ColorId]) VALUES (4, N'Gean-JP', CAST(30.00 AS Decimal(18, 2)), 1, 1, 1)
INSERT [dbo].[ProductTitles] ([Id], [Name], [Price], [BrandId], [CategoryId], [ColorId]) VALUES (5, N'T-Siena', CAST(27.00 AS Decimal(18, 2)), 2, 2, 2)
INSERT [dbo].[ProductTitles] ([Id], [Name], [Price], [BrandId], [CategoryId], [ColorId]) VALUES (6, N'T-JPP', CAST(230.00 AS Decimal(18, 2)), 1, 3, 1)
INSERT [dbo].[ProductTitles] ([Id], [Name], [Price], [BrandId], [CategoryId], [ColorId]) VALUES (7, N'T-Sirt-Sofia', CAST(100.00 AS Decimal(18, 2)), 2, 1, 2)
INSERT [dbo].[ProductTitles] ([Id], [Name], [Price], [BrandId], [CategoryId], [ColorId]) VALUES (8, N'Gean-JPP', CAST(150.00 AS Decimal(18, 2)), 2, 1, 3)
INSERT [dbo].[ProductTitles] ([Id], [Name], [Price], [BrandId], [CategoryId], [ColorId]) VALUES (9, N'Gean-Siena', CAST(34.00 AS Decimal(18, 2)), 1, 1, 2)
INSERT [dbo].[ProductTitles] ([Id], [Name], [Price], [BrandId], [CategoryId], [ColorId]) VALUES (10, N'TShiet-Roma', CAST(35.00 AS Decimal(18, 2)), 2, 3, 1)
INSERT [dbo].[ProductTitles] ([Id], [Name], [Price], [BrandId], [CategoryId], [ColorId]) VALUES (11, N'Lucian Straight Jeans ', CAST(22.99 AS Decimal(18, 2)), 4, 4, 6)
INSERT [dbo].[ProductTitles] ([Id], [Name], [Price], [BrandId], [CategoryId], [ColorId]) VALUES (12, N'506 Stretch Diamond ', CAST(27.99 AS Decimal(18, 2)), 5, 4, 7)
INSERT [dbo].[ProductTitles] ([Id], [Name], [Price], [BrandId], [CategoryId], [ColorId]) VALUES (13, N'506 Dark Stuff Straight ', CAST(25.99 AS Decimal(18, 2)), 4, 4, 6)
INSERT [dbo].[ProductTitles] ([Id], [Name], [Price], [BrandId], [CategoryId], [ColorId]) VALUES (14, N'512 Bootcut Jeans', CAST(22.99 AS Decimal(18, 2)), 5, 4, 7)
INSERT [dbo].[ProductTitles] ([Id], [Name], [Price], [BrandId], [CategoryId], [ColorId]) VALUES (15, N'Lucian Straight Jeans 2 ', CAST(22.99 AS Decimal(18, 2)), 4, 4, 6)
INSERT [dbo].[ProductTitles] ([Id], [Name], [Price], [BrandId], [CategoryId], [ColorId]) VALUES (16, N'506 Stretch Diamond 2 ', CAST(27.99 AS Decimal(18, 2)), 5, 4, 7)
INSERT [dbo].[ProductTitles] ([Id], [Name], [Price], [BrandId], [CategoryId], [ColorId]) VALUES (18, N'506 Dark Stuff Straight 2 ', CAST(25.99 AS Decimal(18, 2)), 4, 4, 6)
INSERT [dbo].[ProductTitles] ([Id], [Name], [Price], [BrandId], [CategoryId], [ColorId]) VALUES (19, N'512 Bootcut Jeans 2', CAST(22.99 AS Decimal(18, 2)), 5, 4, 7)
SET IDENTITY_INSERT [dbo].[ProductTitles] OFF
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [BrandId]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [CategoryId]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [ProductColorId]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [ProductSizeId]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [ProductTitleId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Brands_BrandId] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Brands_BrandId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductColors_ProductColorId] FOREIGN KEY([ProductColorId])
REFERENCES [dbo].[ProductColors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductColors_ProductColorId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductSizes_ProductSizeId] FOREIGN KEY([ProductSizeId])
REFERENCES [dbo].[ProductSizes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductSizes_ProductSizeId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductTitles_ProductTitleId] FOREIGN KEY([ProductTitleId])
REFERENCES [dbo].[ProductTitles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductTitles_ProductTitleId]
GO
ALTER TABLE [dbo].[ProductTitles]  WITH CHECK ADD  CONSTRAINT [FK_ProductTitles_Brands_BrandId] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([Id])
GO
ALTER TABLE [dbo].[ProductTitles] CHECK CONSTRAINT [FK_ProductTitles_Brands_BrandId]
GO
ALTER TABLE [dbo].[ProductTitles]  WITH CHECK ADD  CONSTRAINT [FK_ProductTitles_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[ProductTitles] CHECK CONSTRAINT [FK_ProductTitles_Categories_CategoryId]
GO
ALTER TABLE [dbo].[ProductTitles]  WITH CHECK ADD  CONSTRAINT [FK_ProductTitles_ProductColors_ColorId] FOREIGN KEY([ColorId])
REFERENCES [dbo].[ProductColors] ([Id])
GO
ALTER TABLE [dbo].[ProductTitles] CHECK CONSTRAINT [FK_ProductTitles_ProductColors_ColorId]
GO
