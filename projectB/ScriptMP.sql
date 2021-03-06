USE [master]
GO
/****** Object:  Database [ProjectB]    Script Date: 5/3/2019 8:13:32 AM ******/
CREATE DATABASE [ProjectB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ProjectB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProjectB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ProjectB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProjectB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProjectB] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ProjectB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ProjectB]
GO
/****** Object:  Table [dbo].[Assessment]    Script Date: 5/3/2019 8:13:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assessment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[TotalMarks] [int] NOT NULL,
	[TotalWeightage] [int] NOT NULL,
 CONSTRAINT [PK_Assessment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AssessmentComponent]    Script Date: 5/3/2019 8:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssessmentComponent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[RubricId] [int] NOT NULL,
	[TotalMarks] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
	[AssessmentId] [int] NOT NULL,
 CONSTRAINT [PK_AssessmentRubric] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClassAttendance]    Script Date: 5/3/2019 8:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassAttendance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AttendanceDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ClassAttendance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Clo]    Script Date: 5/3/2019 8:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_Clo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lookup]    Script Date: 5/3/2019 8:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lookup](
	[LookupId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Lookup] PRIMARY KEY CLUSTERED 
(
	[LookupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rubric]    Script Date: 5/3/2019 8:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rubric](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Details] [nvarchar](max) NOT NULL,
	[CloId] [int] NOT NULL,
 CONSTRAINT [PK_Rubric] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RubricLevel]    Script Date: 5/3/2019 8:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RubricLevel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RubricId] [int] NOT NULL,
	[Details] [nvarchar](max) NOT NULL,
	[MeasurementLevel] [int] NOT NULL,
 CONSTRAINT [PK_RubricLevel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 5/3/2019 8:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[Contact] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[RegistrationNumber] [nvarchar](20) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentAttendance]    Script Date: 5/3/2019 8:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentAttendance](
	[AttendanceId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[AttendanceStatus] [int] NOT NULL,
 CONSTRAINT [PK_StudentAttendance] PRIMARY KEY CLUSTERED 
(
	[AttendanceId] ASC,
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentResult]    Script Date: 5/3/2019 8:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentResult](
	[StudentId] [int] NOT NULL,
	[AssessmentComponentId] [int] NOT NULL,
	[RubricMeasurementId] [int] NOT NULL,
	[EvaluationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_StudentResult] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[AssessmentComponentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Assessment] ON 

INSERT [dbo].[Assessment] ([Id], [Title], [DateCreated], [TotalMarks], [TotalWeightage]) VALUES (6, N'Lab5', CAST(N'2019-03-31 07:39:40.000' AS DateTime), 45, 23)
INSERT [dbo].[Assessment] ([Id], [Title], [DateCreated], [TotalMarks], [TotalWeightage]) VALUES (7, N'Lab6', CAST(N'2019-03-31 14:23:01.000' AS DateTime), 45, 30)
INSERT [dbo].[Assessment] ([Id], [Title], [DateCreated], [TotalMarks], [TotalWeightage]) VALUES (8, N'Lab7', CAST(N'2019-03-31 14:23:20.000' AS DateTime), 50, 30)
INSERT [dbo].[Assessment] ([Id], [Title], [DateCreated], [TotalMarks], [TotalWeightage]) VALUES (9, N'Lab3', CAST(N'2019-03-31 14:23:37.000' AS DateTime), 25, 10)
SET IDENTITY_INSERT [dbo].[Assessment] OFF
SET IDENTITY_INSERT [dbo].[AssessmentComponent] ON 

INSERT [dbo].[AssessmentComponent] ([Id], [Name], [RubricId], [TotalMarks], [DateCreated], [DateUpdated], [AssessmentId]) VALUES (15, N'Question1', 1, 30, CAST(N'2019-03-31 14:23:55.000' AS DateTime), CAST(N'2019-03-31 14:23:55.000' AS DateTime), 6)
INSERT [dbo].[AssessmentComponent] ([Id], [Name], [RubricId], [TotalMarks], [DateCreated], [DateUpdated], [AssessmentId]) VALUES (16, N'Question1', 1, 30, CAST(N'2019-03-31 14:23:58.000' AS DateTime), CAST(N'2019-03-31 14:23:58.000' AS DateTime), 6)
INSERT [dbo].[AssessmentComponent] ([Id], [Name], [RubricId], [TotalMarks], [DateCreated], [DateUpdated], [AssessmentId]) VALUES (17, N'Question2', 9, 25, CAST(N'2019-03-31 14:25:40.000' AS DateTime), CAST(N'2019-03-31 14:25:40.000' AS DateTime), 7)
INSERT [dbo].[AssessmentComponent] ([Id], [Name], [RubricId], [TotalMarks], [DateCreated], [DateUpdated], [AssessmentId]) VALUES (18, N'Question2', 9, 25, CAST(N'2019-03-31 14:25:45.000' AS DateTime), CAST(N'2019-03-31 14:25:45.000' AS DateTime), 7)
SET IDENTITY_INSERT [dbo].[AssessmentComponent] OFF
SET IDENTITY_INSERT [dbo].[ClassAttendance] ON 

INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (3, CAST(N'2019-03-30 13:04:11.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (4, CAST(N'2019-03-30 13:09:25.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (5, CAST(N'2019-03-30 13:10:00.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (6, CAST(N'2019-03-30 13:10:14.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (7, CAST(N'2019-03-30 13:10:47.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (8, CAST(N'2019-03-30 14:34:26.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (9, CAST(N'2019-03-30 14:34:35.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (10, CAST(N'2019-03-30 14:35:09.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (11, CAST(N'2019-03-30 14:36:27.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (12, CAST(N'2019-03-30 14:38:56.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (13, CAST(N'2019-03-30 14:39:22.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (14, CAST(N'2019-03-30 14:43:08.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (15, CAST(N'2019-03-30 14:44:17.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (16, CAST(N'2019-03-30 14:44:58.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (17, CAST(N'2019-03-30 14:52:15.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (18, CAST(N'2019-03-30 14:53:11.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (19, CAST(N'2019-03-30 14:57:29.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (20, CAST(N'2019-03-30 14:58:23.000' AS DateTime))
INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (21, CAST(N'2019-03-31 14:27:38.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[ClassAttendance] OFF
SET IDENTITY_INSERT [dbo].[Clo] ON 

INSERT [dbo].[Clo] ([Id], [Name], [DateCreated], [DateUpdated]) VALUES (1, N'CLO1', CAST(N'2019-03-15 18:17:23.000' AS DateTime), CAST(N'2019-03-15 18:17:23.000' AS DateTime))
INSERT [dbo].[Clo] ([Id], [Name], [DateCreated], [DateUpdated]) VALUES (3, N'CLO3', CAST(N'2019-03-15 18:17:34.000' AS DateTime), CAST(N'2019-03-15 18:17:34.000' AS DateTime))
INSERT [dbo].[Clo] ([Id], [Name], [DateCreated], [DateUpdated]) VALUES (5, N'CLO9', CAST(N'2019-03-15 18:17:45.000' AS DateTime), CAST(N'2019-03-15 19:49:16.000' AS DateTime))
INSERT [dbo].[Clo] ([Id], [Name], [DateCreated], [DateUpdated]) VALUES (6, N'CLO6', CAST(N'2019-03-15 18:17:52.000' AS DateTime), CAST(N'2019-03-15 18:17:52.000' AS DateTime))
INSERT [dbo].[Clo] ([Id], [Name], [DateCreated], [DateUpdated]) VALUES (7, N'CLO8', CAST(N'2019-03-31 07:37:46.000' AS DateTime), CAST(N'2019-03-31 14:09:20.000' AS DateTime))
INSERT [dbo].[Clo] ([Id], [Name], [DateCreated], [DateUpdated]) VALUES (8, N'CLO2', CAST(N'2019-03-31 14:08:46.000' AS DateTime), CAST(N'2019-03-31 14:08:46.000' AS DateTime))
INSERT [dbo].[Clo] ([Id], [Name], [DateCreated], [DateUpdated]) VALUES (9, N'CLO5', CAST(N'2019-03-31 14:08:56.000' AS DateTime), CAST(N'2019-03-31 14:08:56.000' AS DateTime))
INSERT [dbo].[Clo] ([Id], [Name], [DateCreated], [DateUpdated]) VALUES (10, N'CLO10', CAST(N'2019-03-31 14:09:07.000' AS DateTime), CAST(N'2019-03-31 14:09:07.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Clo] OFF
SET IDENTITY_INSERT [dbo].[Lookup] ON 

INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (1, N'Present', N'ATTENDANCE_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (2, N'Absent', N'ATTENDANCE_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (3, N'Leave', N'ATTENDANCE_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (4, N'Late', N'ATTENDANCE_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (5, N'Active', N'STUDENT_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (6, N'InActive', N'STUDENT_STATUS')
SET IDENTITY_INSERT [dbo].[Lookup] OFF
SET IDENTITY_INSERT [dbo].[Rubric] ON 

INSERT [dbo].[Rubric] ([Id], [Details], [CloId]) VALUES (1, N'Design', 3)
INSERT [dbo].[Rubric] ([Id], [Details], [CloId]) VALUES (2, N'Coding', 3)
INSERT [dbo].[Rubric] ([Id], [Details], [CloId]) VALUES (9, N'Testing', 3)
INSERT [dbo].[Rubric] ([Id], [Details], [CloId]) VALUES (10, N'Designn', 7)
INSERT [dbo].[Rubric] ([Id], [Details], [CloId]) VALUES (11, N'Design', 1)
INSERT [dbo].[Rubric] ([Id], [Details], [CloId]) VALUES (12, N'Coding', 1)
INSERT [dbo].[Rubric] ([Id], [Details], [CloId]) VALUES (13, N'Testing', 1)
SET IDENTITY_INSERT [dbo].[Rubric] OFF
SET IDENTITY_INSERT [dbo].[RubricLevel] ON 

INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (14, 9, N'fair', 2)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (17, 9, N'Unsatisfactory', 1)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (18, 9, N'Good', 3)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (19, 9, N'Exceptional', 4)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (20, 1, N'fair', 2)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (21, 1, N'Unsatisfactory', 1)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (22, 1, N'Good', 3)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (23, 1, N'Exceptional', 4)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (24, 13, N'fair', 2)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (25, 9, N'Unsatisfactory', 1)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (26, 9, N'Good', 3)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (27, 9, N'Exceptional', 4)
SET IDENTITY_INSERT [dbo].[RubricLevel] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (1, N'Rahat', N'Attique', N'12345678999', N'rahatattique1@gmail.com', N'2016-CS-444', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (2, N'Rayha', N'Rohi', N'98765432123', N'rayha@gmail.com', N'2016-CS-545', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (6, N'Fatima', N'Khan', N'23124234583', N'fatima@gmail.com', N'2016-CS-488', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (8, N'Rimsha', N'Arshad', N'12145678569', N'rismsha@gmail.com', N'2016-CS-433', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (9, N'robi', N'qaum', N'21345364748', N'robi@gmail.com', N'2016-CS-422', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (10, N'maryam', N'mushtaq', N'46666666666', N'maryam@gmail.com', N'2016-CS-555', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (12, N'Amara', N'rauf', N'57847777777', N'amara@gmaiil.com', N'2016-CS-123', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (13, N'veronica', N'lodge', N'2385772956', N'lodge@gmail.com', N'2016-CS-233', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (14, N'jug', N'head', N'98566666666', N'jug@gmail.com', N'2016-CS-222', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (17, N'mehak', N'noor', N'58888875999', N'nooe@gmail.com', N'2016-CS-222', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (20, N'abpara', N'gul', N'2345678900', N'gul2@gmail.com', N'2016-CS-213', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (23, N'maral', N'fatima', N'03009998766', N'maralfatima1@gmail.com', N'2016-CS-288', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (24, N'urwa ', N'kashif', N'03004433327', N'urwach2@gmail.com', N'2016-CS-280', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (25, N'iqra', N'munir', N'03216380119', N'iqramunir4@gmail.com', N'2016-CS-366', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (26, N'komal ', N'saleem', N'03245675433', N'komalsaleem8@gmail.com', N'2016-CS-255', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (27, N'rimsha', N'tasneem', N'03242567887', N'rimshatasneem8@gmail.com', N'2016-CS-244', 5)
SET IDENTITY_INSERT [dbo].[Student] OFF
INSERT [dbo].[StudentAttendance] ([AttendanceId], [StudentId], [AttendanceStatus]) VALUES (9, 1, 2)
INSERT [dbo].[StudentAttendance] ([AttendanceId], [StudentId], [AttendanceStatus]) VALUES (10, 8, 4)
INSERT [dbo].[StudentAttendance] ([AttendanceId], [StudentId], [AttendanceStatus]) VALUES (12, 6, 4)
INSERT [dbo].[StudentAttendance] ([AttendanceId], [StudentId], [AttendanceStatus]) VALUES (13, 6, 2)
INSERT [dbo].[StudentAttendance] ([AttendanceId], [StudentId], [AttendanceStatus]) VALUES (15, 6, 1)
INSERT [dbo].[StudentAttendance] ([AttendanceId], [StudentId], [AttendanceStatus]) VALUES (18, 6, 1)
INSERT [dbo].[StudentAttendance] ([AttendanceId], [StudentId], [AttendanceStatus]) VALUES (19, 2, 2)
INSERT [dbo].[StudentAttendance] ([AttendanceId], [StudentId], [AttendanceStatus]) VALUES (20, 6, 4)
INSERT [dbo].[StudentAttendance] ([AttendanceId], [StudentId], [AttendanceStatus]) VALUES (21, 13, 1)
INSERT [dbo].[StudentResult] ([StudentId], [AssessmentComponentId], [RubricMeasurementId], [EvaluationDate]) VALUES (1, 15, 20, CAST(N'2019-03-31 14:26:51.000' AS DateTime))
INSERT [dbo].[StudentResult] ([StudentId], [AssessmentComponentId], [RubricMeasurementId], [EvaluationDate]) VALUES (2, 15, 20, CAST(N'2019-03-31 14:26:55.000' AS DateTime))
INSERT [dbo].[StudentResult] ([StudentId], [AssessmentComponentId], [RubricMeasurementId], [EvaluationDate]) VALUES (9, 15, 23, CAST(N'2019-03-31 14:27:30.000' AS DateTime))
INSERT [dbo].[StudentResult] ([StudentId], [AssessmentComponentId], [RubricMeasurementId], [EvaluationDate]) VALUES (12, 15, 22, CAST(N'2019-03-31 14:27:23.000' AS DateTime))
ALTER TABLE [dbo].[AssessmentComponent]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentComponent_Assessment] FOREIGN KEY([AssessmentId])
REFERENCES [dbo].[Assessment] ([Id])
GO
ALTER TABLE [dbo].[AssessmentComponent] CHECK CONSTRAINT [FK_AssessmentComponent_Assessment]
GO
ALTER TABLE [dbo].[AssessmentComponent]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentComponent_Rubric] FOREIGN KEY([RubricId])
REFERENCES [dbo].[Rubric] ([Id])
GO
ALTER TABLE [dbo].[AssessmentComponent] CHECK CONSTRAINT [FK_AssessmentComponent_Rubric]
GO
ALTER TABLE [dbo].[Rubric]  WITH CHECK ADD  CONSTRAINT [FK_Rubric_Clo] FOREIGN KEY([CloId])
REFERENCES [dbo].[Clo] ([Id])
GO
ALTER TABLE [dbo].[Rubric] CHECK CONSTRAINT [FK_Rubric_Clo]
GO
ALTER TABLE [dbo].[RubricLevel]  WITH CHECK ADD  CONSTRAINT [FK_RubricLevel_Rubric] FOREIGN KEY([RubricId])
REFERENCES [dbo].[Rubric] ([Id])
GO
ALTER TABLE [dbo].[RubricLevel] CHECK CONSTRAINT [FK_RubricLevel_Rubric]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Lookup] FOREIGN KEY([Status])
REFERENCES [dbo].[Lookup] ([LookupId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Lookup]
GO
ALTER TABLE [dbo].[StudentAttendance]  WITH CHECK ADD  CONSTRAINT [FK_StudentAttendance_ClassAttendance] FOREIGN KEY([AttendanceId])
REFERENCES [dbo].[ClassAttendance] ([Id])
GO
ALTER TABLE [dbo].[StudentAttendance] CHECK CONSTRAINT [FK_StudentAttendance_ClassAttendance]
GO
ALTER TABLE [dbo].[StudentAttendance]  WITH CHECK ADD  CONSTRAINT [FK_StudentAttendance_Lookup] FOREIGN KEY([AttendanceStatus])
REFERENCES [dbo].[Lookup] ([LookupId])
GO
ALTER TABLE [dbo].[StudentAttendance] CHECK CONSTRAINT [FK_StudentAttendance_Lookup]
GO
ALTER TABLE [dbo].[StudentAttendance]  WITH CHECK ADD  CONSTRAINT [FK_StudentAttendance_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[StudentAttendance] CHECK CONSTRAINT [FK_StudentAttendance_Student]
GO
ALTER TABLE [dbo].[StudentResult]  WITH CHECK ADD  CONSTRAINT [FK_StudentResult_AssessmentComponent] FOREIGN KEY([AssessmentComponentId])
REFERENCES [dbo].[AssessmentComponent] ([Id])
GO
ALTER TABLE [dbo].[StudentResult] CHECK CONSTRAINT [FK_StudentResult_AssessmentComponent]
GO
ALTER TABLE [dbo].[StudentResult]  WITH CHECK ADD  CONSTRAINT [FK_StudentResult_RubricLevel] FOREIGN KEY([RubricMeasurementId])
REFERENCES [dbo].[RubricLevel] ([Id])
GO
ALTER TABLE [dbo].[StudentResult] CHECK CONSTRAINT [FK_StudentResult_RubricLevel]
GO
ALTER TABLE [dbo].[StudentResult]  WITH CHECK ADD  CONSTRAINT [FK_StudentResult_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[StudentResult] CHECK CONSTRAINT [FK_StudentResult_Student]
GO
USE [master]
GO
ALTER DATABASE [ProjectB] SET  READ_WRITE 
GO
