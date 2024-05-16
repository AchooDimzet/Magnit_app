USE [master]
GO
/****** Object:  Database [Magnit_db]    Script Date: 16.05.2024 20:00:27 ******/
CREATE DATABASE [Magnit_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Magnit_db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Magnit_db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Magnit_db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Magnit_db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 COLLATE Cyrillic_General_CI_AS
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Magnit_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Magnit_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Magnit_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Magnit_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Magnit_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Magnit_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [Magnit_db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Magnit_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Magnit_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Magnit_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Magnit_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Magnit_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Magnit_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Magnit_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Magnit_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Magnit_db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Magnit_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Magnit_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Magnit_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Magnit_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Magnit_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Magnit_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Magnit_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Magnit_db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Magnit_db] SET  MULTI_USER 
GO
ALTER DATABASE [Magnit_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Magnit_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Magnit_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Magnit_db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Magnit_db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Magnit_db] SET QUERY_STORE = OFF
GO
USE [Magnit_db]
GO
/****** Object:  Table [dbo].[ClientDiscount]    Script Date: 16.05.2024 20:00:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientDiscount](
	[DiscountNumber] [int] NOT NULL,
	[First_name] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Last_name] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Patronimyc] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NULL,
	[Phone_number] [nvarchar](12) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Gender] [int] NOT NULL,
 CONSTRAINT [PK_ClientDiscount] PRIMARY KEY CLUSTERED 
(
	[DiscountNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 16.05.2024 20:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_category]    Script Date: 16.05.2024 20:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL,
 CONSTRAINT [PK_Product_category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_items]    Script Date: 16.05.2024 20:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_items](
	[Article_number] [int] NOT NULL,
	[Name] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Photo] [varbinary](max) NULL,
	[Category] [int] NOT NULL,
 CONSTRAINT [PK_Product_items] PRIMARY KEY CLUSTERED 
(
	[Article_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSales]    Script Date: 16.05.2024 20:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSales](
	[Id_sale] [int] NOT NULL,
	[Id_product] [int] NOT NULL,
	[Count] [int] NOT NULL,
 CONSTRAINT [PK_ProductSales] PRIMARY KEY CLUSTERED 
(
	[Id_sale] ASC,
	[Id_product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 16.05.2024 20:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 16.05.2024 20:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[Id_sale] [int] NOT NULL,
	[Id_worker] [int] NOT NULL,
	[Id_item] [int] NOT NULL,
	[Date] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL,
 CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED 
(
	[Id_sale] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Store]    Script Date: 16.05.2024 20:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[Id] [int] NOT NULL,
	[Adress] [nvarchar](80) COLLATE Cyrillic_General_CI_AS NOT NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Worker_tasks]    Script Date: 16.05.2024 20:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Worker_tasks](
	[Id] [int] NOT NULL,
	[Id_worker] [int] NOT NULL,
	[Task_text] [nvarchar](max) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Is_comleted] [bit] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workers]    Script Date: 16.05.2024 20:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workers](
	[First_name] [nvarchar](20) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Last_name] [nvarchar](20) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Patronimyc] [nvarchar](20) COLLATE Cyrillic_General_CI_AS NULL,
	[Adress] [nvarchar](80) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Login] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Password] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Id_store] [int] NOT NULL,
	[Id_role] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Gender] [int] NOT NULL,
	[Photo] [varbinary](max) NULL,
 CONSTRAINT [PK_Workers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[ClientDiscount]  WITH CHECK ADD  CONSTRAINT [FK_ClientDiscount_Gender] FOREIGN KEY([Gender])
REFERENCES [dbo].[Gender] ([Id])
GO
ALTER TABLE [dbo].[ClientDiscount] CHECK CONSTRAINT [FK_ClientDiscount_Gender]
GO
ALTER TABLE [dbo].[Product_items]  WITH CHECK ADD  CONSTRAINT [FK_Product_items_Product_category] FOREIGN KEY([Category])
REFERENCES [dbo].[Product_category] ([Id])
GO
ALTER TABLE [dbo].[Product_items] CHECK CONSTRAINT [FK_Product_items_Product_category]
GO
ALTER TABLE [dbo].[ProductSales]  WITH CHECK ADD  CONSTRAINT [FK_ProductSales_Product_items] FOREIGN KEY([Id_product])
REFERENCES [dbo].[Product_items] ([Article_number])
GO
ALTER TABLE [dbo].[ProductSales] CHECK CONSTRAINT [FK_ProductSales_Product_items]
GO
ALTER TABLE [dbo].[ProductSales]  WITH CHECK ADD  CONSTRAINT [FK_ProductSales_Sales] FOREIGN KEY([Id_sale])
REFERENCES [dbo].[Sales] ([Id_sale])
GO
ALTER TABLE [dbo].[ProductSales] CHECK CONSTRAINT [FK_ProductSales_Sales]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Workers] FOREIGN KEY([Id_worker])
REFERENCES [dbo].[Workers] ([Id])
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Workers]
GO
ALTER TABLE [dbo].[Worker_tasks]  WITH CHECK ADD  CONSTRAINT [FK_Worker_tasks_Workers] FOREIGN KEY([Id_worker])
REFERENCES [dbo].[Workers] ([Id])
GO
ALTER TABLE [dbo].[Worker_tasks] CHECK CONSTRAINT [FK_Worker_tasks_Workers]
GO
ALTER TABLE [dbo].[Workers]  WITH CHECK ADD  CONSTRAINT [FK_Workers_Gender] FOREIGN KEY([Gender])
REFERENCES [dbo].[Gender] ([Id])
GO
ALTER TABLE [dbo].[Workers] CHECK CONSTRAINT [FK_Workers_Gender]
GO
ALTER TABLE [dbo].[Workers]  WITH CHECK ADD  CONSTRAINT [FK_Workers_Roles] FOREIGN KEY([Id_role])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Workers] CHECK CONSTRAINT [FK_Workers_Roles]
GO
ALTER TABLE [dbo].[Workers]  WITH CHECK ADD  CONSTRAINT [FK_Workers_Store] FOREIGN KEY([Id_store])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[Workers] CHECK CONSTRAINT [FK_Workers_Store]
GO
USE [master]
GO
ALTER DATABASE [Magnit_db] SET  READ_WRITE 
GO
