USE [master]
GO
/****** Object:  Database [MixedMediaInventoryTracker]    Script Date: 6/23/2018 8:20:58 AM ******/
CREATE DATABASE [MixedMediaInventoryTracker]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MixedMediaInventoryTracker', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MixedMediaInventoryTracker.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MixedMediaInventoryTracker_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MixedMediaInventoryTracker_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MixedMediaInventoryTracker].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET ARITHABORT OFF 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET  MULTI_USER 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET QUERY_STORE = OFF
GO
USE [MixedMediaInventoryTracker]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [MixedMediaInventoryTracker]
GO
/****** Object:  Table [dbo].[LentMedia]    Script Date: 6/23/2018 8:20:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LentMedia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MediaId] [int] NOT NULL,
	[LendeeName] [varchar](100) NOT NULL,
	[MediaConditionId] [int] NOT NULL,
	[DateLent] [date] NOT NULL,
	[Notes] [varchar](200) NULL,
 CONSTRAINT [PK_LentMedia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Media]    Script Date: 6/23/2018 8:20:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Media](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MediaTypeId] [int] NOT NULL,
	[MediaConditionId] [int] NOT NULL,
	[Title] [varchar](200) NULL,
	[DatePurchased] [date] NULL,
	[DateAdded] [date] NOT NULL,
	[IsLentOut] [bit] NOT NULL,
	[IsSold] [bit] NULL,
	[Notes] [varchar](200) NULL,
	[artworkUrl100] [varchar](500) NULL,
	[Artist] [varchar](50) NULL,
	[Album] [varchar](100) NULL,
	[Author] [varchar](100) NULL,
 CONSTRAINT [PK_05_25_18-MediaTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MediaCondition]    Script Date: 6/23/2018 8:20:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MediaCondition](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MediaCondition] [varchar](100) NOT NULL,
 CONSTRAINT [PK_MediaCondition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MediaType]    Script Date: 6/23/2018 8:20:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MediaType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MediaType] [varchar](100) NOT NULL,
	[Image] [varchar](100) NULL,
 CONSTRAINT [PK_MediaType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SoldMedia]    Script Date: 6/23/2018 8:20:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SoldMedia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MediaId] [int] NOT NULL,
	[Buyer] [varchar](50) NOT NULL,
	[Amount] [money] NULL,
	[SoldDate] [date] NOT NULL,
	[Notes] [varchar](200) NULL,
	[MediaConditionId] [int] NOT NULL,
 CONSTRAINT [PK_SoldMedia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Media] ADD  CONSTRAINT [DF_05_25_18-MediaTable_DateAdded]  DEFAULT (getdate()) FOR [DateAdded]
GO
ALTER TABLE [dbo].[LentMedia]  WITH CHECK ADD  CONSTRAINT [FK_LentMedia_Media] FOREIGN KEY([MediaId])
REFERENCES [dbo].[Media] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LentMedia] CHECK CONSTRAINT [FK_LentMedia_Media]
GO
ALTER TABLE [dbo].[LentMedia]  WITH CHECK ADD  CONSTRAINT [FK_LentMedia_MediaCondition] FOREIGN KEY([MediaConditionId])
REFERENCES [dbo].[MediaCondition] ([Id])
GO
ALTER TABLE [dbo].[LentMedia] CHECK CONSTRAINT [FK_LentMedia_MediaCondition]
GO
ALTER TABLE [dbo].[Media]  WITH CHECK ADD  CONSTRAINT [FK_Media_MediaCondition] FOREIGN KEY([MediaConditionId])
REFERENCES [dbo].[MediaCondition] ([Id])
GO
ALTER TABLE [dbo].[Media] CHECK CONSTRAINT [FK_Media_MediaCondition]
GO
ALTER TABLE [dbo].[Media]  WITH CHECK ADD  CONSTRAINT [FK_Media_MediaType] FOREIGN KEY([MediaTypeId])
REFERENCES [dbo].[MediaType] ([Id])
GO
ALTER TABLE [dbo].[Media] CHECK CONSTRAINT [FK_Media_MediaType]
GO
ALTER TABLE [dbo].[SoldMedia]  WITH CHECK ADD  CONSTRAINT [FK_SoldMedia_Media] FOREIGN KEY([MediaId])
REFERENCES [dbo].[Media] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SoldMedia] CHECK CONSTRAINT [FK_SoldMedia_Media]
GO
ALTER TABLE [dbo].[SoldMedia]  WITH CHECK ADD  CONSTRAINT [FK_SoldMedia_MediaCondition] FOREIGN KEY([MediaConditionId])
REFERENCES [dbo].[MediaCondition] ([Id])
GO
ALTER TABLE [dbo].[SoldMedia] CHECK CONSTRAINT [FK_SoldMedia_MediaCondition]
GO
USE [master]
GO
ALTER DATABASE [MixedMediaInventoryTracker] SET  READ_WRITE 
GO
