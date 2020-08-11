USE [master]
GO
/****** Object:  Database [WaterMargin]    Script Date: 2020/8/11 9:59:43 ******/
CREATE DATABASE [WaterMargin]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WaterMargin', FILENAME = N'D:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\WaterMargin.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WaterMargin_log', FILENAME = N'D:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\WaterMargin_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WaterMargin] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WaterMargin].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WaterMargin] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WaterMargin] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WaterMargin] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WaterMargin] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WaterMargin] SET ARITHABORT OFF 
GO
ALTER DATABASE [WaterMargin] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WaterMargin] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WaterMargin] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WaterMargin] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WaterMargin] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WaterMargin] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WaterMargin] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WaterMargin] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WaterMargin] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WaterMargin] SET  ENABLE_BROKER 
GO
ALTER DATABASE [WaterMargin] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WaterMargin] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WaterMargin] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WaterMargin] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WaterMargin] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WaterMargin] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [WaterMargin] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WaterMargin] SET RECOVERY FULL 
GO
ALTER DATABASE [WaterMargin] SET  MULTI_USER 
GO
ALTER DATABASE [WaterMargin] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WaterMargin] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WaterMargin] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WaterMargin] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [WaterMargin] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'WaterMargin', N'ON'
GO
USE [WaterMargin]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2020/8/11 9:59:43 ******/
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
/****** Object:  Table [dbo].[Hostility]    Script Date: 2020/8/11 9:59:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hostility](
	[HostilityId] [varchar](50) NOT NULL,
	[CreateTime] [datetime] NULL,
	[CreateBy] [varchar](50) NULL,
	[UpdateTime] [datetime] NULL,
	[UpdateBy] [varchar](50) NULL,
	[QQNumber] [varchar](50) NOT NULL,
	[HostilityName] [varchar](50) NOT NULL,
	[RoleLevel] [int] NOT NULL,
	[MilitaryPower] [int] NOT NULL,
	[HostilityLevel] [nvarchar](max) NULL,
	[IsSurpass] [bit] NOT NULL,
	[Remark] [varchar](1000) NULL,
 CONSTRAINT [PK_Hostility] PRIMARY KEY CLUSTERED 
(
	[HostilityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StoredEvent]    Script Date: 2020/8/11 9:59:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoredEvent](
	[Id] [varchar](50) NOT NULL,
	[Timestamp] [datetime] NOT NULL,
	[MessageType] [varchar](100) NULL,
	[AggregateId] [uniqueidentifier] NOT NULL,
	[Data] [varchar](max) NULL,
	[UserName] [varchar](100) NULL,
 CONSTRAINT [PK_StoredEvent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemRole]    Script Date: 2020/8/11 9:59:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemRole](
	[Id] [varchar](50) NOT NULL,
	[CreateTime] [datetime] NULL,
	[CreateBy] [varchar](50) NULL,
	[UpdateTime] [datetime] NULL,
	[UpdateBy] [varchar](50) NULL,
	[RoleName] [varchar](50) NULL,
 CONSTRAINT [PK_SystemRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemUser]    Script Date: 2020/8/11 9:59:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemUser](
	[Id] [varchar](50) NOT NULL,
	[CreateTime] [datetime] NULL,
	[CreateBy] [varchar](50) NULL,
	[UpdateTime] [datetime] NULL,
	[UpdateBy] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Nick] [varchar](50) NOT NULL,
	[AccountName] [varchar](100) NOT NULL,
	[PassWord] [varchar](50) NOT NULL,
	[QQNumber] [varchar](20) NULL,
	[Tel] [varchar](20) NULL,
	[EmadilAddress] [varchar](100) NULL,
	[AddressProvince] [varchar](50) NULL,
	[AddressCity] [varchar](50) NULL,
	[AddressLocation] [varchar](50) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_SystemUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemUserRoleRelation]    Script Date: 2020/8/11 9:59:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemUserRoleRelation](
	[Id] [varchar](50) NOT NULL,
	[UserId] [varchar](50) NULL,
	[RoleId] [varchar](50) NULL,
 CONSTRAINT [PK_SystemUserRoleRelation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200809055533_initial', N'3.1.6')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200811015304_init', N'3.1.6')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SystemUserRoleRelation_RoleId]    Script Date: 2020/8/11 9:59:44 ******/
CREATE NONCLUSTERED INDEX [IX_SystemUserRoleRelation_RoleId] ON [dbo].[SystemUserRoleRelation]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SystemUserRoleRelation_UserId]    Script Date: 2020/8/11 9:59:44 ******/
CREATE NONCLUSTERED INDEX [IX_SystemUserRoleRelation_UserId] ON [dbo].[SystemUserRoleRelation]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Hostility] ADD  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[SystemRole] ADD  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[SystemUser] ADD  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[SystemUserRoleRelation]  WITH CHECK ADD  CONSTRAINT [FK_SystemUserRoleRelation_SystemRole_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[SystemRole] ([Id])
GO
ALTER TABLE [dbo].[SystemUserRoleRelation] CHECK CONSTRAINT [FK_SystemUserRoleRelation_SystemRole_RoleId]
GO
ALTER TABLE [dbo].[SystemUserRoleRelation]  WITH CHECK ADD  CONSTRAINT [FK_SystemUserRoleRelation_SystemUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[SystemUser] ([Id])
GO
ALTER TABLE [dbo].[SystemUserRoleRelation] CHECK CONSTRAINT [FK_SystemUserRoleRelation_SystemUser_UserId]
GO
USE [master]
GO
ALTER DATABASE [WaterMargin] SET  READ_WRITE 
GO
