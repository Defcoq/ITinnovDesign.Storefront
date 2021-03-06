USE [ITinnovDesignStorefront]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Trousers')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[ProductColors] ON 

INSERT [dbo].[ProductColors] ([Id], [Name]) VALUES (6, N'Blue')
INSERT [dbo].[ProductColors] ([Id], [Name]) VALUES (7, N'Black')
INSERT [dbo].[ProductColors] ([Id], [Name]) VALUES (8, N'Brown')
INSERT [dbo].[ProductColors] ([Id], [Name]) VALUES (9, N'Green')
INSERT [dbo].[ProductColors] ([Id], [Name]) VALUES (10, N'Red')
INSERT [dbo].[ProductColors] ([Id], [Name]) VALUES (11, N'White')
INSERT [dbo].[ProductColors] ([Id], [Name]) VALUES (12, N'Silver')
SET IDENTITY_INSERT [dbo].[ProductColors] OFF
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([Id], [Name]) VALUES (4, N'Bench')
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (5, N'Levi')
SET IDENTITY_INSERT [dbo].[Brands] OFF
SET IDENTITY_INSERT [dbo].[ProductTitles] ON 

INSERT [dbo].[ProductTitles] ([Id], [Name], [ColorId], [BrandId], [CategoryId], [Price]) VALUES (15, N'Lucian Straight Jeans 2 ', 6, 4, 4, CAST(22.99 AS Decimal(18, 2)))
INSERT [dbo].[ProductTitles] ([Id], [Name], [ColorId], [BrandId], [CategoryId], [Price]) VALUES (16, N'506 Stretch Diamond 2 ', 7, 5, 4, CAST(27.99 AS Decimal(18, 2)))
INSERT [dbo].[ProductTitles] ([Id], [Name], [ColorId], [BrandId], [CategoryId], [Price]) VALUES (18, N'506 Dark Stuff Straight 2 ', 6, 4, 4, CAST(25.99 AS Decimal(18, 2)))
INSERT [dbo].[ProductTitles] ([Id], [Name], [ColorId], [BrandId], [CategoryId], [Price]) VALUES (19, N'512 Bootcut Jeans 2', 7, 5, 4, CAST(22.99 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[ProductTitles] OFF
SET IDENTITY_INSERT [dbo].[ProductSizes] ON 

INSERT [dbo].[ProductSizes] ([Id], [Name]) VALUES (5, N'M ')
INSERT [dbo].[ProductSizes] ([Id], [Name]) VALUES (6, N'L')
INSERT [dbo].[ProductSizes] ([Id], [Name]) VALUES (7, N'XL')
INSERT [dbo].[ProductSizes] ([Id], [Name]) VALUES (8, N'S')
SET IDENTITY_INSERT [dbo].[ProductSizes] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id],[BrandId],[CategoryId],[ProductColorId], [ProductSizeId], [ProductTitleId]) VALUES (4,4,6,7, 5, 11)
INSERT [dbo].[Products] ([Id],[BrandId],[CategoryId],[ProductColorId], [ProductSizeId], [ProductTitleId]) VALUES (4,4,7,8, 6, 12)
INSERT [dbo].[Products] ([Id],[BrandId],[CategoryId],[ProductColorId], [ProductSizeId], [ProductTitleId]) VALUES (5,4,6,9, 7, 13)
INSERT [dbo].[Products] ([Id],[BrandId],[CategoryId],[ProductColorId], [ProductSizeId], [ProductTitleId]) VALUES (6,4,7,10, 8, 14)
INSERT [dbo].[Products] ([Id],[BrandId],[CategoryId],[ProductColorId], [ProductSizeId], [ProductTitleId]) VALUES (5,4,7,11, 8, 11)
SET IDENTITY_INSERT [dbo].[Products] OFF
