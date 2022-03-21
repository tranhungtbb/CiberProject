USE [master]
GO
/****** Object:  Database [Ciber]    Script Date: 3/21/2022 6:11:04 PM ******/
CREATE DATABASE [Ciber]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Ciber', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Ciber.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Ciber_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Ciber_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Ciber] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Ciber].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Ciber] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Ciber] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Ciber] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Ciber] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Ciber] SET ARITHABORT OFF 
GO
ALTER DATABASE [Ciber] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Ciber] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Ciber] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Ciber] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Ciber] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Ciber] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Ciber] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Ciber] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Ciber] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Ciber] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Ciber] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Ciber] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Ciber] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Ciber] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Ciber] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Ciber] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Ciber] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Ciber] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Ciber] SET  MULTI_USER 
GO
ALTER DATABASE [Ciber] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Ciber] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Ciber] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Ciber] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Ciber] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Ciber] SET QUERY_STORE = OFF
GO
USE [Ciber]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Ciber]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 3/21/2022 6:11:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Description] [nvarchar](450) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 3/21/2022 6:11:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Address] [nvarchar](350) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 3/21/2022 6:11:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Customer] [int] NULL,
	[Product] [int] NULL,
	[Amount] [int] NULL,
	[OrderDate] [datetime] NULL,
	[OrderName] [nvarchar](250) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 3/21/2022 6:11:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](350) NULL,
	[Price] [nchar](10) NULL,
	[Description] [nvarchar](450) NULL,
	[Quantity] [int] NULL,
	[Category] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (1, N'Đồ ăn nhanh', NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (2, N'Đồ uống', NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (3, N'Đồ gia dụng', NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Name], [Address]) VALUES (1, N'Hùng Trần Đình', NULL)
INSERT [dbo].[Customer] ([Id], [Name], [Address]) VALUES (2, N'Nguyễn Văn A', NULL)
INSERT [dbo].[Customer] ([Id], [Name], [Address]) VALUES (3, N'Trần Văn B', NULL)
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [Customer], [Product], [Amount], [OrderDate], [OrderName]) VALUES (1, 1, 3, 2, NULL, NULL)
INSERT [dbo].[Order] ([Id], [Customer], [Product], [Amount], [OrderDate], [OrderName]) VALUES (2, 1, 2, 1, NULL, NULL)
INSERT [dbo].[Order] ([Id], [Customer], [Product], [Amount], [OrderDate], [OrderName]) VALUES (3, 2, 3, NULL, CAST(N'2022-03-07T00:00:00.000' AS DateTime), N'dsfsdf')
INSERT [dbo].[Order] ([Id], [Customer], [Product], [Amount], [OrderDate], [OrderName]) VALUES (4, 2, 3, 1, CAST(N'2022-03-04T00:00:00.000' AS DateTime), N'dsfsdf')
INSERT [dbo].[Order] ([Id], [Customer], [Product], [Amount], [OrderDate], [OrderName]) VALUES (5, 3, 2, 12, CAST(N'2022-03-18T00:00:00.000' AS DateTime), N'dsfsdf')
INSERT [dbo].[Order] ([Id], [Customer], [Product], [Amount], [OrderDate], [OrderName]) VALUES (6, 3, 2, 12, CAST(N'2022-03-03T00:00:00.000' AS DateTime), N'dsfsdf')
INSERT [dbo].[Order] ([Id], [Customer], [Product], [Amount], [OrderDate], [OrderName]) VALUES (7, 2, 4, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Price], [Description], [Quantity], [Category]) VALUES (2, N'Product 1', N'120323.34 ', N'sdfjnsdfsdf', 1223, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Description], [Quantity], [Category]) VALUES (3, N'Product 2', N'123324    ', NULL, 12, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Description], [Quantity], [Category]) VALUES (4, N'Product 3', N'2000      ', NULL, 123, 2)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Description], [Quantity], [Category]) VALUES (5, N'Product 4', N'1500      ', NULL, 2342, 3)
SET IDENTITY_INSERT [dbo].[Product] OFF
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [fk_customer] FOREIGN KEY([Customer])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [fk_customer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [fk_product] FOREIGN KEY([Product])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [fk_product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [fk_category] FOREIGN KEY([Category])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [fk_category]
GO
/****** Object:  StoredProcedure [dbo].[GetDropDownCustomer]    Script Date: 3/21/2022 6:11:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetDropDownCustomer]
as
begin
	select Id Value, Name Text from Customer 
end
GO
/****** Object:  StoredProcedure [dbo].[GetDropDownProduct]    Script Date: 3/21/2022 6:11:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[GetDropDownProduct]
as
begin
	select Id Value, Name Text from Product 
end
GO
/****** Object:  StoredProcedure [dbo].[OrderGetList]    Script Date: 3/21/2022 6:11:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[OrderGetList]
	@KeySearch nvarchar(250) = null,
	@OrderBy int = null,
	@PageSize int = 10,
	@PageIndex int = 1
as
begin
	
	select COUNT(1) OVER() as RowNumber, ord.*, product.Name ProductName, category.Name CategoryName, cus.Name CustomerName
	from [Order] ord 
		join Product product on (ord.Product = product.Id)
		join Customer cus on (ord.Customer = cus.Id)
		join Category category on (category.Id = product.Category)
	where 
		(@KeySearch is null OR (product.[Name] like N'%' + @KeySearch + N'%'))

	ORDER BY
		case when @OrderBy = 0 or @OrderBy is null then ord.Id end desc,
		case when @OrderBy = 1 then product.Name end desc,
		case when @OrderBy = 2 then category.Name end desc,
		case when @OrderBy = 3 then cus.Name end desc
			
	OFFSET (@PageIndex-1) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY
end
GO
USE [master]
GO
ALTER DATABASE [Ciber] SET  READ_WRITE 
GO
