create database QLCHBanGiay
USE [QLCHBanGiay]
GO
/****** Object:  Table [dbo].[tBillOfSale]    Script Date: 11/9/2022 3:54:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tBillOfSale](
	[CodeBill] [nvarchar](50) NOT NULL,
	[DateSale] [date] NULL,
	[PaymentMethods] [nvarchar](50) NULL,
	[EmployeeCode] [nvarchar](50) NULL,
	[CustomerCode] [nvarchar](50) NULL,
	[Discount] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[CodeBill] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tCategory]    Script Date: 11/9/2022 3:54:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tCategory](
	[CategoryCode] [nvarchar](50) NOT NULL,
	[Brand] [nvarchar](50) NULL,
	[Origin] [nvarchar](50) NULL,
 CONSTRAINT [PK_tCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tCustomer]    Script Date: 11/9/2022 3:54:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tCustomer](
	[CustomerCode] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Gender] [nvarchar](10) NULL,
	[Address] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](20) NULL,
	[Point] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tDetailBillOfSale]    Script Date: 11/9/2022 3:54:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tDetailBillOfSale](
	[DetailProductCode] [nvarchar](50) NOT NULL,
	[CodeBill] [nvarchar](50) NOT NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_tDetailBillOfSale] PRIMARY KEY CLUSTERED 
(
	[DetailProductCode] ASC,
	[CodeBill] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tDetailImportBill]    Script Date: 11/9/2022 3:54:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tDetailImportBill](
	[DetailProductCode] [nvarchar](50) NOT NULL,
	[CodeBill] [nvarchar](50) NOT NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_tDetailImportBill] PRIMARY KEY CLUSTERED 
(
	[DetailProductCode] ASC,
	[CodeBill] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tDetailProduct]    Script Date: 11/9/2022 3:54:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tDetailProduct](
	[DetailProductCode] [nvarchar](50) NOT NULL,
	[ProductCode] [nvarchar](50) NULL,
	[Size] [nvarchar](20) NULL,
	[Color] [nvarchar](20) NULL,
	[ImportPrice] [money] NULL,
	[Price] [money] NULL,
	[Quantity] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tDetailProduct] PRIMARY KEY CLUSTERED 
(
	[DetailProductCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tEmployee]    Script Date: 11/9/2022 3:54:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tEmployee](
	[EmployeeCode] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[ID] [nvarchar](20) NULL,
	[Gender] [nvarchar](10) NULL,
	[DOB] [date] NULL,
	[Address] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](20) NULL,
	[UserName] [nvarchar](50) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tImportBill]    Script Date: 11/9/2022 3:54:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tImportBill](
	[CodeBill] [nvarchar](50) NOT NULL,
	[DateImport] [date] NULL,
	[EmployeeCode] [nvarchar](50) NULL,
	[ProviderCode] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CodeBill] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tLogin]    Script Date: 11/9/2022 3:54:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tLogin](
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NULL,
	[Role] [bit] default 0,
	[Status] [bit] default 1,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tProduct]    Script Date: 11/9/2022 3:54:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tProduct](
	[ProductCode] [nvarchar](50) NOT NULL,
	[NameProduct] [nvarchar](50) NULL,
	[Image] [nvarchar](50) NULL,
	[CategoryCode] [nvarchar](50) NULL,
 CONSTRAINT [PK__tProduct__2F4E024E92219230] PRIMARY KEY CLUSTERED 
(
	[ProductCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tProvider]    Script Date: 11/9/2022 3:54:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tProvider](
	[ProviderCode] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProviderCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tBillOfSale] ([CodeBill], [DateSale], [PaymentMethods], [EmployeeCode], [CustomerCode], [Discount]) VALUES (N'HDB01', CAST(N'2022-01-29' AS Date), N'Tiền Mặt', N'NV01', N'KH01', NULL)
INSERT [dbo].[tBillOfSale] ([CodeBill], [DateSale], [PaymentMethods], [EmployeeCode], [CustomerCode], [Discount]) VALUES (N'HDB02', CAST(N'2022-02-14' AS Date), N'Banking', N'NV01', N'KH02', NULL)
INSERT [dbo].[tBillOfSale] ([CodeBill], [DateSale], [PaymentMethods], [EmployeeCode], [CustomerCode], [Discount]) VALUES (N'HDB03', CAST(N'2022-03-01' AS Date), N'Quẹt Thẻ', N'NV02', N'KH03', NULL)
INSERT [dbo].[tBillOfSale] ([CodeBill], [DateSale], [PaymentMethods], [EmployeeCode], [CustomerCode], [Discount]) VALUES (N'HDB04', CAST(N'2022-04-14' AS Date), N'Tiền Mặt', N'NV02', N'KH04', NULL)
INSERT [dbo].[tBillOfSale] ([CodeBill], [DateSale], [PaymentMethods], [EmployeeCode], [CustomerCode], [Discount]) VALUES (N'HDB05', CAST(N'2022-06-27' AS Date), N'Tiền Mặt', N'NV01', N'KH05', NULL)
GO
INSERT [dbo].[tCategory] ([CategoryCode], [Brand], [Origin]) VALUES (N'ATQ', N'Adidas', N'Trung Quốc')
INSERT [dbo].[tCategory] ([CategoryCode], [Brand], [Origin]) VALUES (N'BVN', N'Biti''s', N'Việt Nam')
INSERT [dbo].[tCategory] ([CategoryCode], [Brand], [Origin]) VALUES (N'NTQ', N'Nike', N'Trung Quốc')
GO
INSERT [dbo].[tCustomer] ([CustomerCode], [Name], [Gender], [Address], [PhoneNumber], [Point]) VALUES (N'KH01', N'Nguyễn Quỳnh Mai', N'Nữ', N'Hà Nội', N'0395461255', NULL)
INSERT [dbo].[tCustomer] ([CustomerCode], [Name], [Gender], [Address], [PhoneNumber], [Point]) VALUES (N'KH02', N'Trần Hải An', N'Nam', N'Hà Nội', N'0354785566', NULL)
INSERT [dbo].[tCustomer] ([CustomerCode], [Name], [Gender], [Address], [PhoneNumber], [Point]) VALUES (N'KH03', N'Lê Thái Bình', N'Nam', N'Thái Bình', N'0365544778', NULL)
INSERT [dbo].[tCustomer] ([CustomerCode], [Name], [Gender], [Address], [PhoneNumber], [Point]) VALUES (N'KH04', N'Nguyễn Thị Hà', N'Nữ ', N'Hải Phòng', N'0368777445', NULL)
INSERT [dbo].[tCustomer] ([CustomerCode], [Name], [Gender], [Address], [PhoneNumber], [Point]) VALUES (N'KH05', N'Nguyễn Hồng Nhung', N'Nữ ', N'Hà Nội', N'0987442445', NULL)
GO
INSERT [dbo].[tDetailBillOfSale] ([DetailProductCode], [CodeBill], [Quantity]) VALUES (N'AAB10D40', N'HDB04', 5)
INSERT [dbo].[tDetailBillOfSale] ([DetailProductCode], [CodeBill], [Quantity]) VALUES (N'AAB10T41', N'HDB02', 3)
INSERT [dbo].[tDetailBillOfSale] ([DetailProductCode], [CodeBill], [Quantity]) VALUES (N'AR2D40', N'HDB01', 2)
INSERT [dbo].[tDetailBillOfSale] ([DetailProductCode], [CodeBill], [Quantity]) VALUES (N'AR2T40', N'HDB03', 1)
INSERT [dbo].[tDetailBillOfSale] ([DetailProductCode], [CodeBill], [Quantity]) VALUES (N'AY350V2D41', N'HDB05', 10)
GO
INSERT [dbo].[tDetailImportBill] ([DetailProductCode], [CodeBill], [Quantity]) VALUES (N'AAB10D40', N'HDN01', 100)
INSERT [dbo].[tDetailImportBill] ([DetailProductCode], [CodeBill], [Quantity]) VALUES (N'AAB10D41', N'HDN02', 120)
INSERT [dbo].[tDetailImportBill] ([DetailProductCode], [CodeBill], [Quantity]) VALUES (N'AAB10T40', N'HDN03', 150)
INSERT [dbo].[tDetailImportBill] ([DetailProductCode], [CodeBill], [Quantity]) VALUES (N'AAB10T41', N'HDN04', 180)
INSERT [dbo].[tDetailImportBill] ([DetailProductCode], [CodeBill], [Quantity]) VALUES (N'AR2D40', N'HDN05', 200)
GO
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'AAB10D40', N'AAB10', N'40', N'Đen', 1000000.0000, 2000000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'AAB10D41', N'AAB10', N'41', N'Đen', 1000000.0000, 2000000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'AAB10T40', N'AAB10', N'40', N'Trắng', 1200000.0000, 2200000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'AAB10T41', N'AAB10', N'41', N'Trắng', 1200000.0000, 2200000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'AR2D40', N'AR2', N'40', N'Đen', 1500000.0000, 2300000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'AR2D41', N'AR2', N'41', N'Đen', 1500000.0000, 2300000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'AR2T40', N'AR2', N'40', N'Trắng', 1500000.0000, 2300000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'AR2T41', N'AR2', N'41', N'Trắng', 1500000.0000, 2300000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'AU20D40', N'AU20', N'40', N'Đen', 1000000.0000, 2000000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'AU20D41', N'AU20', N'41', N'Đen', 1000000.0000, 2000000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'AU20T40', N'AU20', N'40', N'Trắng', 1000000.0000, 2000000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'AU20T41', N'AU20', N'41', N'Trắng', 1000000.0000, 2000000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'AU21D40', N'AU21', N'40', N'Đen', 1000000.0000, 2000000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'AU21D41', N'AU21', N'41', N'Đen', 1000000.0000, 2000000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'AU21T40', N'AU21', N'40', N'Trắng', 1000000.0000, 2000000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'AU21T41', N'AU21', N'41', N'Trắng', 1000000.0000, 2000000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'AY350D40', N'AY350', N'40', N'Đen', 2000000.0000, 3000000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'AY350D41', N'AY350', N'41', N'Đen', 2000000.0000, 3000000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'AY350T40', N'AY350', N'40', N'Trắng', 2000000.0000, 2800000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'AY350T41', N'AY350', N'41', N'Trắng', 2000000.0000, 2800000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'AY350V2D40', N'AY350V2', N'40', N'Đen', 2500000.0000, 3500000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'AY350V2D41', N'AY350V2', N'41', N'Đen', 2500000.0000, 3500000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'AY350V2T40', N'AY350V2', N'40', N'Trắng', 2500000.0000, 3300000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'AY350V2T41', N'AY350V2', N'41', N'Trắng', 2500000.0000, 3300000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'BHCD40', N'BHC', N'40', N'Đen', 500000.0000, 900000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'BHCD41', N'BHC', N'41', N'Đen', 500000.0000, 900000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'BHCT40', N'BHC', N'40', N'Trắng', 500000.0000, 900000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'BHCT41', N'BHC', N'41', N'Trắng', 500000.0000, 900000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'BHLUD40', N'BHLU', N'40', N'Đen', 600000.0000, 1000000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'BHLUD41', N'BHLU', N'41', N'Đen', 600000.0000, 1000000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'BHLUT40', N'BHLU', N'40', N'Trắng', 600000.0000, 1000000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'BHLUT41', N'BHLU', N'41', N'Trắng', 600000.0000, 1000000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'BHTD40', N'BHT', N'40', N'Đen', 900000.0000, 1500000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'BHTD41', N'BHT', N'41', N'Đen', 900000.0000, 1500000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'BHTT40', N'BHT', N'40', N'Trắng', 900000.0000, 1500000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'BHTT41', N'BHT', N'41', N'Trắng', 900000.0000, 1500000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'BHTZD40', N'BHTZ', N'40', N'Đen', 1000000.0000, 2000000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'BHTZD41', N'BHTZ', N'41', N'Đen', 1000000.0000, 2000000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'BHTZT40', N'BHTZ', N'40', N'Trắng', 1000000.0000, 2000000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'BHTZT41', N'BHTZ', N'41', N'Trắng', 1000000.0000, 2000000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'BHX2K22D40', N'BHX2K22', N'40', N'Đen', 600000.0000, 1000000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'BHX2K22D41', N'BHX2K22', N'41', N'Đen', 600000.0000, 1000000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'BHX2K22T40', N'BHX2K22', N'40', N'Trắng', 600000.0000, 1000000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'BHX2K22T41', N'BHX2K22', N'41', N'Trắng', 600000.0000, 1000000.0000, 200, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'BHXCOD40', N'BHXCO', N'40', N'Đen', 500000.0000, 900000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'BHXCOD41', N'BHXCO', N'41', N'Đen', 500000.0000, 900000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'BHXCOT40', N'BHXCO', N'40', N'Trắng', 500000.0000, 900000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'BHXCOT41', N'BHXCO', N'41', N'Trắng', 500000.0000, 900000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NAF1D40', N'NAF1', N'40', N'Đen', 1000000.0000, 2000000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NAF1D41', N'NAF1', N'41', N'Đen', 1000000.0000, 2000000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NAF1T40', N'NAF1', N'40', N'Trắng', 1000000.0000, 2000000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NAF1T41', N'NAF1', N'41', N'Trắng', 1000000.0000, 2000000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NAMAD40', N'NAMA', N'40', N'Đen', 1200000.0000, 1800000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NAMAD41', N'NAMA', N'41', N'Đen', 1200000.0000, 1800000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NAMAT40', N'NAMA', N'40', N'Trắng', 1200000.0000, 1800000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NAMAT41', N'NAMA', N'41', N'Trắng', 1200000.0000, 1800000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NAMED40', N'NAME', N'40', N'Đen', 1200000.0000, 1800000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NAMED41', N'NAME', N'41', N'Đen', 1200000.0000, 1800000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NAMET40', N'NAME', N'40', N'Trắng', 1200000.0000, 1800000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NAMET41', N'NAME', N'41', N'Trắng', 1200000.0000, 1800000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NJTD40', N'NJT', N'40', N'Đen', 2000000.0000, 3000000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NJTD41', N'NJT', N'41', N'Đen', 2000000.0000, 3000000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NJTT40', N'NJT', N'40', N'Trắng', 2000000.0000, 3000000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NJTT41', N'NJT', N'41', N'Trắng', 2000000.0000, 3000000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NR6NND40', N'NR6NN', N'40', N'Đen', 1000000.0000, 1500000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NR6NND41', N'NR6NN', N'41', N'Đen', 1000000.0000, 1500000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NR6NNT40', N'NR6NN', N'40', N'Trắng', 1000000.0000, 1500000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NR6NNT41', N'NR6NN', N'41', N'Trắng', 1000000.0000, 1500000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NRR3D40', N'NRR3', N'40', N'Đen', 1000000.0000, 2000000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NRR3D41', N'NRR3', N'41', N'Đen', 1000000.0000, 2000000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NRR3T40', N'NRR3', N'40', N'Trắng', 1000000.0000, 2000000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NRR3T41', N'NRR3', N'41', N'Trắng', 1000000.0000, 2000000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NTD40', N'NT', N'40', N'Đen', 1500000.0000, 2500000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NTD41', N'NT', N'41', N'Đen', 1500000.0000, 2500000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NTT40', N'NT', N'40', N'Trắng', 1500000.0000, 2500000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NTT41', N'NT', N'41', N'Trắng', 1500000.0000, 2500000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NVD40', N'NV', N'40', N'Đen', 1200000.0000, 200000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NVD41', N'NV', N'41', N'Đen', 1200000.0000, 2000000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NVT40', N'NV', N'40', N'Trắng', 1200000.0000, 2000000.0000, NULL, 1)
INSERT [dbo].[tDetailProduct] ([DetailProductCode], [ProductCode], [Size], [Color], [ImportPrice], [Price], [Quantity], [Status]) VALUES (N'NVT41', N'NV', N'41', N'Trắng', 1200000.0000, 2000000.0000, NULL, 1)
GO
INSERT [dbo].[tEmployee] ([EmployeeCode], [Name], [ID], [Gender], [DOB], [Address], [PhoneNumber], [UserName], [Status]) VALUES (N'NV01', N'Lê Hải Minh', N'001202000336', N'Nam', CAST(N'2000-04-10' AS Date), N'Hà Nội', N'0396557712', N'lehaiminh', 1)
INSERT [dbo].[tEmployee] ([EmployeeCode], [Name], [ID], [Gender], [DOB], [Address], [PhoneNumber], [UserName], [Status]) VALUES (N'NV02', N'Nguyễn Bình Minh', N'001204000558', N'Nam', CAST(N'1999-04-08' AS Date), N'Hà Nội', N'0395541122', N'nguyenbinhminh', 1)
GO
INSERT [dbo].[tImportBill] ([CodeBill], [DateImport], [EmployeeCode], [ProviderCode]) VALUES (N'HDN01', CAST(N'2022-01-25' AS Date), N'NV01', N'NCC01')
INSERT [dbo].[tImportBill] ([CodeBill], [DateImport], [EmployeeCode], [ProviderCode]) VALUES (N'HDN02', CAST(N'2022-02-14' AS Date), N'NV02', N'NCC02')
INSERT [dbo].[tImportBill] ([CodeBill], [DateImport], [EmployeeCode], [ProviderCode]) VALUES (N'HDN03', CAST(N'2022-03-16' AS Date), N'NV02', N'NCC02')
INSERT [dbo].[tImportBill] ([CodeBill], [DateImport], [EmployeeCode], [ProviderCode]) VALUES (N'HDN04', CAST(N'2022-04-01' AS Date), N'NV01', N'NCC01')
INSERT [dbo].[tImportBill] ([CodeBill], [DateImport], [EmployeeCode], [ProviderCode]) VALUES (N'HDN05', CAST(N'2022-06-10' AS Date), N'NV01', N'NCC01')
GO
INSERT [dbo].[tLogin] ([UserName], [Password], [Role], [Status]) VALUES (N'admin', N'123456', 1, 1)
INSERT [dbo].[tLogin] ([UserName], [Password], [Role], [Status]) VALUES (N'lehaiminh', N'123456', 0, 1)
INSERT [dbo].[tLogin] ([UserName], [Password], [Role], [Status]) VALUES (N'nguyenbinhminh', N'123456', 0, 1)
GO
INSERT [dbo].[tProduct] ([ProductCode], [NameProduct], [Image], [CategoryCode]) VALUES (N'AAB10', N'Adidas Adizero Boston 10', N'aab10.jpg', N'ATQ')
INSERT [dbo].[tProduct] ([ProductCode], [NameProduct], [Image], [CategoryCode]) VALUES (N'AR2', N'Adidas Runfalcon 2.0', N'ar2.jpg', N'ATQ')
INSERT [dbo].[tProduct] ([ProductCode], [NameProduct], [Image], [CategoryCode]) VALUES (N'AU20', N'Adidas Ultraboost 20', N'au20', N'ATQ')
INSERT [dbo].[tProduct] ([ProductCode], [NameProduct], [Image], [CategoryCode]) VALUES (N'AU21', N'Adidas Ultraboost 21', N'au21.jpg', N'ATQ')
INSERT [dbo].[tProduct] ([ProductCode], [NameProduct], [Image], [CategoryCode]) VALUES (N'AY350', N'Adidas Yeezy 350', N'ay350.jpg', N'ATQ')
INSERT [dbo].[tProduct] ([ProductCode], [NameProduct], [Image], [CategoryCode]) VALUES (N'AY350V2', N'Adidas Yeezy 350 V2', N'ay350v2.jpg', N'ATQ')
INSERT [dbo].[tProduct] ([ProductCode], [NameProduct], [Image], [CategoryCode]) VALUES (N'BHC', N'Biti''s Hunter Core', N'bhc.jpg', N'BVN')
INSERT [dbo].[tProduct] ([ProductCode], [NameProduct], [Image], [CategoryCode]) VALUES (N'BHLU', N'Biti''s Hunter Layered Upper', N'bhlu.jpg', N'BVN')
INSERT [dbo].[tProduct] ([ProductCode], [NameProduct], [Image], [CategoryCode]) VALUES (N'BHT', N'Biti''s Hunter Street', N'bht.jpg', N'BVN')
INSERT [dbo].[tProduct] ([ProductCode], [NameProduct], [Image], [CategoryCode]) VALUES (N'BHTZ', N'Biti''s Hunter Street Z', N'bhtz.jpg', N'BVN')
INSERT [dbo].[tProduct] ([ProductCode], [NameProduct], [Image], [CategoryCode]) VALUES (N'BHX2K22', N'Biti''s Hunter X 2k22', N'bhx2k22.jpg', N'BVN')
INSERT [dbo].[tProduct] ([ProductCode], [NameProduct], [Image], [CategoryCode]) VALUES (N'BHXCO', N'Biti''s Hunter X Cut-Out', N'bhxco.jpg', N'BVN')
INSERT [dbo].[tProduct] ([ProductCode], [NameProduct], [Image], [CategoryCode]) VALUES (N'NAF1', N'Nike Air Force 1', N'naf1.jpg', N'NTQ')
INSERT [dbo].[tProduct] ([ProductCode], [NameProduct], [Image], [CategoryCode]) VALUES (N'NAMA', N'Nike Air Max Alpha', N'nama.jpg', N'NTQ')
INSERT [dbo].[tProduct] ([ProductCode], [NameProduct], [Image], [CategoryCode]) VALUES (N'NAME', N'Nike Air Max Excee', N'name.jog', N'NTQ')
INSERT [dbo].[tProduct] ([ProductCode], [NameProduct], [Image], [CategoryCode]) VALUES (N'NJT', N'Nike Juniper Trail', N'njt.jpg', N'NTQ')
INSERT [dbo].[tProduct] ([ProductCode], [NameProduct], [Image], [CategoryCode]) VALUES (N'NR6NN', N'Nike Revolution 6 Next Nature', N'nr6nn.jpg', N'NTQ')
INSERT [dbo].[tProduct] ([ProductCode], [NameProduct], [Image], [CategoryCode]) VALUES (N'NRR3', N'Nike Renew Ride 3', N'nrr3.jpg', N'NTQ')
INSERT [dbo].[tProduct] ([ProductCode], [NameProduct], [Image], [CategoryCode]) VALUES (N'NT', N'Nike Tanjun', N'nt.jpg', N'NTQ')
INSERT [dbo].[tProduct] ([ProductCode], [NameProduct], [Image], [CategoryCode]) VALUES (N'NV', N'Nike Venture', N'nv.jpg', N'NTQ')
GO
INSERT [dbo].[tProvider] ([ProviderCode], [Name], [Address]) VALUES (N'NCC01', N'CTTNHH Giày Thành Công', N'Hà Nội')
INSERT [dbo].[tProvider] ([ProviderCode], [Name], [Address]) VALUES (N'NCC02', N'CTTNHH Giày True Sport', N'Thanh Hóa')
GO
ALTER TABLE [dbo].[tBillOfSale]  WITH CHECK ADD FOREIGN KEY([CustomerCode])
REFERENCES [dbo].[tCustomer] ([CustomerCode])
GO
ALTER TABLE [dbo].[tBillOfSale]  WITH CHECK ADD FOREIGN KEY([EmployeeCode])
REFERENCES [dbo].[tEmployee] ([EmployeeCode])
GO
ALTER TABLE [dbo].[tDetailBillOfSale]  WITH CHECK ADD  CONSTRAINT [FK_tDetailBillOfSale_tBillOfSale] FOREIGN KEY([CodeBill])
REFERENCES [dbo].[tBillOfSale] ([CodeBill])
GO
ALTER TABLE [dbo].[tDetailBillOfSale] CHECK CONSTRAINT [FK_tDetailBillOfSale_tBillOfSale]
GO
ALTER TABLE [dbo].[tDetailBillOfSale]  WITH CHECK ADD  CONSTRAINT [FK_tDetailBillOfSale_tDetailProduct] FOREIGN KEY([DetailProductCode])
REFERENCES [dbo].[tDetailProduct] ([DetailProductCode])
GO
ALTER TABLE [dbo].[tDetailBillOfSale] CHECK CONSTRAINT [FK_tDetailBillOfSale_tDetailProduct]
GO
ALTER TABLE [dbo].[tDetailImportBill]  WITH CHECK ADD  CONSTRAINT [FK_tDetailImportBill_tDetailProduct] FOREIGN KEY([DetailProductCode])
REFERENCES [dbo].[tDetailProduct] ([DetailProductCode])
GO
ALTER TABLE [dbo].[tDetailImportBill] CHECK CONSTRAINT [FK_tDetailImportBill_tDetailProduct]
GO
ALTER TABLE [dbo].[tDetailImportBill]  WITH CHECK ADD  CONSTRAINT [FK_tDetailImportBill_tImportBill] FOREIGN KEY([CodeBill])
REFERENCES [dbo].[tImportBill] ([CodeBill])
GO
ALTER TABLE [dbo].[tDetailImportBill] CHECK CONSTRAINT [FK_tDetailImportBill_tImportBill]
GO
ALTER TABLE [dbo].[tDetailProduct]  WITH CHECK ADD  CONSTRAINT [FK_tDetailProduct_tProduct] FOREIGN KEY([ProductCode])
REFERENCES [dbo].[tProduct] ([ProductCode])
GO
ALTER TABLE [dbo].[tDetailProduct] CHECK CONSTRAINT [FK_tDetailProduct_tProduct]
GO
ALTER TABLE [dbo].[tEmployee]  WITH CHECK ADD FOREIGN KEY([UserName])
REFERENCES [dbo].[tLogin] ([UserName])
GO
ALTER TABLE [dbo].[tImportBill]  WITH CHECK ADD FOREIGN KEY([EmployeeCode])
REFERENCES [dbo].[tEmployee] ([EmployeeCode])
GO
ALTER TABLE [dbo].[tImportBill]  WITH CHECK ADD FOREIGN KEY([ProviderCode])
REFERENCES [dbo].[tProvider] ([ProviderCode])
GO
ALTER TABLE [dbo].[tProduct]  WITH CHECK ADD  CONSTRAINT [FK_tProduct_tCategory] FOREIGN KEY([CategoryCode])
REFERENCES [dbo].[tCategory] ([CategoryCode])
GO
ALTER TABLE [dbo].[tProduct] CHECK CONSTRAINT [FK_tProduct_tCategory]
GO

