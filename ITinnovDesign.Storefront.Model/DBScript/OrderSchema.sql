USE [191B2EE5D77351FBDC15FE5FD9229ADB_ASPPATTERNS.CHAP14\AGATHAS.STOREFRONT - VS 2010\AGATHAS.STOREFRONT.UI.WEB.MVC\APP_DATA\SHOP.MDF]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 20/03/2021 20:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Qty] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
 CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 20/03/2021 20:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[ShippingCharge] [decimal](18, 2) NOT NULL,
	[ShippingServiceId] [int] NOT NULL,
	[PaymentDate] [datetime] NULL,
	[PaymentTransactionId] [nvarchar](250) NULL,
	[PaymentAmount] [decimal](18, 2) NULL,
	[PaymentMerchant] [nvarchar](50) NULL,
	[DeliveryAddressLine1] [nvarchar](50) NOT NULL,
	[DeliveryAddressLine2] [nvarchar](50) NOT NULL,
	[DeliveryCity] [nvarchar](50) NOT NULL,
	[DeliveryState] [nvarchar](50) NOT NULL,
	[DeliveryZipCode] [nvarchar](50) NOT NULL,
	[DeliveryCountry] [nvarchar](50) NOT NULL,
	[StateId] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStates]    Script Date: 20/03/2021 20:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStates](
	[Id] [int] NOT NULL,
	[StateName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_OrderStates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[OrderItems] ON 

INSERT [dbo].[OrderItems] ([Id], [ProductId], [Price], [Qty], [OrderId]) VALUES (1, 2, CAST(27.99 AS Decimal(18, 2)), 1, 1)
INSERT [dbo].[OrderItems] ([Id], [ProductId], [Price], [Qty], [OrderId]) VALUES (2, 3, CAST(25.99 AS Decimal(18, 2)), 1, 2)
SET IDENTITY_INSERT [dbo].[OrderItems] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [OrderDate], [CustomerId], [ShippingCharge], [ShippingServiceId], [PaymentDate], [PaymentTransactionId], [PaymentAmount], [PaymentMerchant], [DeliveryAddressLine1], [DeliveryAddressLine2], [DeliveryCity], [DeliveryState], [DeliveryZipCode], [DeliveryCountry], [StateId]) VALUES (1, CAST(N'2010-07-12T23:14:33.000' AS DateTime), 3, CAST(0.00 AS Decimal(18, 2)), 4, NULL, NULL, NULL, NULL, N'dfg', N'fdgdfg', N'fdg', N'dfg', N'fdg', N'dfgd', 1)
INSERT [dbo].[Orders] ([Id], [OrderDate], [CustomerId], [ShippingCharge], [ShippingServiceId], [PaymentDate], [PaymentTransactionId], [PaymentAmount], [PaymentMerchant], [DeliveryAddressLine1], [DeliveryAddressLine2], [DeliveryCity], [DeliveryState], [DeliveryZipCode], [DeliveryCountry], [StateId]) VALUES (2, CAST(N'2010-08-25T21:24:29.000' AS DateTime), 1, CAST(0.00 AS Decimal(18, 2)), 4, NULL, NULL, NULL, NULL, N'kjhkjh', N'44444444', N'kjhkjh', N'kjh', N'kjhkj', N'kjhkjhkj', 1)
SET IDENTITY_INSERT [dbo].[Orders] OFF
INSERT [dbo].[OrderStates] ([Id], [StateName]) VALUES (1, N'Open')
INSERT [dbo].[OrderStates] ([Id], [StateName]) VALUES (2, N'Submitted')
