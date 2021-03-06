USE [master]
GO
/****** Object:  Database [ProjectOne]    Script Date: 25-Sep-17 3:42:30 AM ******/
CREATE DATABASE [ProjectOne]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectOne', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ProjectOne.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProjectOne_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ProjectOne_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProjectOne] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectOne].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectOne] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectOne] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectOne] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectOne] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectOne] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectOne] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectOne] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectOne] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectOne] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectOne] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectOne] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectOne] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectOne] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectOne] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectOne] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectOne] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectOne] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectOne] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectOne] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectOne] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectOne] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectOne] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectOne] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectOne] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProjectOne] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectOne] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectOne] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectOne] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectOne] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ProjectOne]
GO
/****** Object:  Table [dbo].[BillDateTotalFee]    Script Date: 25-Sep-17 3:42:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BillDateTotalFee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BillDate] [date] NOT NULL,
	[BillNumber] [varchar](50) NOT NULL,
	[TotalFee] [float] NOT NULL,
	[PatientId] [int] NOT NULL,
	[BillStatus] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BillDateTotalFee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 25-Sep-17 3:42:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Patient](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Mobile] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PatientTest]    Script Date: 25-Sep-17 3:42:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientTest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TestSetupId] [int] NOT NULL,
	[PatientId] [int] NOT NULL,
 CONSTRAINT [PK_PatientTest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TestSetup]    Script Date: 25-Sep-17 3:42:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestSetup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TestName] [varchar](50) NOT NULL,
	[Fee] [float] NOT NULL,
	[TestTypeId] [int] NOT NULL,
 CONSTRAINT [PK_TestSetup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TestType]    Script Date: 25-Sep-17 3:42:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TestType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[vw_three]    Script Date: 25-Sep-17 3:42:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vw_three]
as
(select t.Id TestId,t.TestName TestName,t.Fee Fee,p.Id PatientId from PatientTest pt
inner join Patient p on pt.PatientId=p.id
right join TestSetup t on pt.TestSetupId=t.id) 


GO
/****** Object:  View [dbo].[vw_four]    Script Date: 25-Sep-17 3:42:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vw_four]
as
select  three.TestId TestId,three.TestName TestName,three.Fee Fee,bd.Date,three.PatientId PatientID from vw_three three
left join BillDateTotalFee bd on three.PatientId=bd.PatientId


GO
/****** Object:  View [dbo].[vw_five]    Script Date: 25-Sep-17 3:42:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vw_five]
as
(select four.TestName,count(four.PatientId) TotalTest,sum(case when four.PatientID is not null then four.Fee else 0 end) TotalAmount from vw_four four 
group by four.TestName)


GO
/****** Object:  View [dbo].[VW_TestSetupView]    Script Date: 25-Sep-17 3:42:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW  [dbo].[VW_TestSetupView] AS
SELECT ts.*,tt.TypeName FROM TestSetup ts INNER JOIN TestType tt ON
ts.TestTypeId=tt.Id




GO
/****** Object:  View [dbo].[VW_ThirdCaseInformation]    Script Date: 25-Sep-17 3:42:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[VW_ThirdCaseInformation] AS
select ts.TestName,ts.Fee,p.Id from TestSetup ts inner join PatientTest pt on
ts.Id=pt.TestSetupId inner join Patient p on
p.Id=pt.PatientId 




GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_TestType]    Script Date: 25-Sep-17 3:42:30 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TestType] ON [dbo].[TestType]
(
	[TypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_Patient] FOREIGN KEY([Id])
REFERENCES [dbo].[Patient] ([Id])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_Patient]
GO
ALTER TABLE [dbo].[PatientTest]  WITH CHECK ADD  CONSTRAINT [FK_PatientTest_Patient] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([Id])
GO
ALTER TABLE [dbo].[PatientTest] CHECK CONSTRAINT [FK_PatientTest_Patient]
GO
ALTER TABLE [dbo].[PatientTest]  WITH CHECK ADD  CONSTRAINT [FK_PatientTest_TestSetup] FOREIGN KEY([TestSetupId])
REFERENCES [dbo].[TestSetup] ([Id])
GO
ALTER TABLE [dbo].[PatientTest] CHECK CONSTRAINT [FK_PatientTest_TestSetup]
GO
ALTER TABLE [dbo].[TestSetup]  WITH CHECK ADD  CONSTRAINT [FK_TestSetup_TestType] FOREIGN KEY([TestTypeId])
REFERENCES [dbo].[TestType] ([Id])
GO
ALTER TABLE [dbo].[TestSetup] CHECK CONSTRAINT [FK_TestSetup_TestType]
GO
USE [master]
GO
ALTER DATABASE [ProjectOne] SET  READ_WRITE 
GO
