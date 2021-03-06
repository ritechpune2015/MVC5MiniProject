USE [MiniApp]
GO
/****** Object:  Table [dbo].[CartTbl]    Script Date: 18/01/2020 1:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartTbl](
	[CartID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NULL,
	[ProductID] [bigint] NULL,
	[Qty] [int] NULL,
	[Price] [decimal](18, 2) NULL,
 CONSTRAINT [PK_CartTbl] PRIMARY KEY CLUSTERED 
(
	[CartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CategoryTbl]    Script Date: 18/01/2020 1:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CategoryTbl](
	[CategoryID] [bigint] IDENTITY(1,1) NOT NULL,
	[MainCategoryID] [bigint] NULL,
	[CategoryName] [varchar](100) NULL,
 CONSTRAINT [PK_CategoryTbl] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MainCategoryTbl]    Script Date: 18/01/2020 1:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MainCategoryTbl](
	[MainCategoryID] [bigint] IDENTITY(1,1) NOT NULL,
	[MainCategory] [varchar](100) NULL,
 CONSTRAINT [PK_MainCategoryTbl] PRIMARY KEY CLUSTERED 
(
	[MainCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderDetTbl]    Script Date: 18/01/2020 1:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetTbl](
	[OrderDetID] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderID] [bigint] NULL,
	[ProductID] [bigint] NULL,
	[Qty] [bigint] NULL,
	[Price] [decimal](18, 2) NULL,
 CONSTRAINT [PK_OrderDetTbl] PRIMARY KEY CLUSTERED 
(
	[OrderDetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderTbl]    Script Date: 18/01/2020 1:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderTbl](
	[OrderID] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NULL,
	[UserID] [bigint] NULL,
 CONSTRAINT [PK_OrderTbl] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductTbl]    Script Date: 18/01/2020 1:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductTbl](
	[ProductID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](100) NULL,
	[CategoryID] [bigint] NULL,
	[ProductDesc] [varchar](200) NULL,
	[Price] [decimal](18, 2) NULL,
	[MfgName] [varchar](100) NULL,
	[ImagePath] [varchar](100) NULL,
 CONSTRAINT [PK_ProductTbl] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StoreTbl]    Script Date: 18/01/2020 1:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StoreTbl](
	[StoreID] [bigint] IDENTITY(1,1) NOT NULL,
	[StoreName] [varchar](100) NULL,
	[Address] [varchar](50) NULL,
	[EmailID] [varchar](50) NULL,
	[MobileNo] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_StoreTbl] PRIMARY KEY CLUSTERED 
(
	[StoreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserTbl]    Script Date: 18/01/2020 1:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserTbl](
	[UserID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Address] [varchar](200) NULL,
	[EmailID] [varchar](20) NULL,
	[MobileNo] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_UserTbl] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[CartTbl]  WITH CHECK ADD  CONSTRAINT [FK_CartTbl_ProductTbl] FOREIGN KEY([ProductID])
REFERENCES [dbo].[ProductTbl] ([ProductID])
GO
ALTER TABLE [dbo].[CartTbl] CHECK CONSTRAINT [FK_CartTbl_ProductTbl]
GO
ALTER TABLE [dbo].[CartTbl]  WITH CHECK ADD  CONSTRAINT [FK_CartTbl_UserTbl] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTbl] ([UserID])
GO
ALTER TABLE [dbo].[CartTbl] CHECK CONSTRAINT [FK_CartTbl_UserTbl]
GO
ALTER TABLE [dbo].[CategoryTbl]  WITH CHECK ADD  CONSTRAINT [FK_CategoryTbl_MainCategoryTbl] FOREIGN KEY([MainCategoryID])
REFERENCES [dbo].[MainCategoryTbl] ([MainCategoryID])
GO
ALTER TABLE [dbo].[CategoryTbl] CHECK CONSTRAINT [FK_CategoryTbl_MainCategoryTbl]
GO
ALTER TABLE [dbo].[OrderDetTbl]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetTbl_OrderTbl] FOREIGN KEY([OrderID])
REFERENCES [dbo].[OrderTbl] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetTbl] CHECK CONSTRAINT [FK_OrderDetTbl_OrderTbl]
GO
ALTER TABLE [dbo].[OrderDetTbl]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetTbl_ProductTbl] FOREIGN KEY([ProductID])
REFERENCES [dbo].[ProductTbl] ([ProductID])
GO
ALTER TABLE [dbo].[OrderDetTbl] CHECK CONSTRAINT [FK_OrderDetTbl_ProductTbl]
GO
ALTER TABLE [dbo].[OrderTbl]  WITH CHECK ADD  CONSTRAINT [FK_OrderTbl_UserTbl] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTbl] ([UserID])
GO
ALTER TABLE [dbo].[OrderTbl] CHECK CONSTRAINT [FK_OrderTbl_UserTbl]
GO
ALTER TABLE [dbo].[ProductTbl]  WITH CHECK ADD  CONSTRAINT [FK_ProductTbl_CategoryTbl] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[CategoryTbl] ([CategoryID])
GO
ALTER TABLE [dbo].[ProductTbl] CHECK CONSTRAINT [FK_ProductTbl_CategoryTbl]
GO
