USE [master]
GO
/****** Object:  Database [FYP_UOS_2022]    Script Date: 03/04/2022 11:55:42 pm ******/
CREATE DATABASE [FYP_UOS_2022]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FYP_UOS_2022', FILENAME = N'D:\Installed Softwares\Microsoft Sql Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\FYP_UOS_2022.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FYP_UOS_2022_log', FILENAME = N'D:\Installed Softwares\Microsoft Sql Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\FYP_UOS_2022_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FYP_UOS_2022].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FYP_UOS_2022] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FYP_UOS_2022] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FYP_UOS_2022] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FYP_UOS_2022] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FYP_UOS_2022] SET ARITHABORT OFF 
GO
ALTER DATABASE [FYP_UOS_2022] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FYP_UOS_2022] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FYP_UOS_2022] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FYP_UOS_2022] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FYP_UOS_2022] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FYP_UOS_2022] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FYP_UOS_2022] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FYP_UOS_2022] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FYP_UOS_2022] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FYP_UOS_2022] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FYP_UOS_2022] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FYP_UOS_2022] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FYP_UOS_2022] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FYP_UOS_2022] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FYP_UOS_2022] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FYP_UOS_2022] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FYP_UOS_2022] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FYP_UOS_2022] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FYP_UOS_2022] SET  MULTI_USER 
GO
ALTER DATABASE [FYP_UOS_2022] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FYP_UOS_2022] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FYP_UOS_2022] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FYP_UOS_2022] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FYP_UOS_2022] SET DELAYED_DURABILITY = DISABLED 
GO
USE [FYP_UOS_2022]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 03/04/2022 11:55:42 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Class_Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Examcell]    Script Date: 03/04/2022 11:55:42 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Examcell](
	[Examcell_id] [int] IDENTITY(1,1) NOT NULL,
	[Examcell_Uniqueid] [nvarchar](50) NULL,
	[Examcellpassword] [nvarchar](50) NOT NULL,
	[Examcell_Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Examcell] PRIMARY KEY CLUSTERED 
(
	[Examcell_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 03/04/2022 11:55:42 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Group_id] [nvarchar](50) NOT NULL,
	[supervisor_fid] [int] NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PMO]    Script Date: 03/04/2022 11:55:42 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PMO](
	[PMO_id] [int] IDENTITY(1,1) NOT NULL,
	[PMO_Name] [nvarchar](50) NOT NULL,
	[PMO_Email] [nvarchar](50) NOT NULL,
	[PMO_password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PMO] PRIMARY KEY CLUSTERED 
(
	[PMO_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 03/04/2022 11:55:42 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Student_id] [int] IDENTITY(1,1) NOT NULL,
	[Student_Name] [nvarchar](50) NOT NULL,
	[Student_Email] [nvarchar](50) NOT NULL,
	[Student_Password] [nvarchar](50) NOT NULL,
	[Clas_fid] [int] NULL,
	[Group_fid] [int] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Student_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Task]    Script Date: 03/04/2022 11:55:42 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Task](
	[Task_id] [int] IDENTITY(1,1) NOT NULL,
	[Task_Name] [nvarchar](50) NOT NULL,
	[Task_start_date] [datetime] NOT NULL,
	[Task_end_Date] [datetime] NOT NULL,
	[Task_status] [bit] NOT NULL,
 CONSTRAINT [PK_Student_Task] PRIMARY KEY CLUSTERED 
(
	[Task_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supervisor]    Script Date: 03/04/2022 11:55:42 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supervisor](
	[Supervisor_id] [int] IDENTITY(1,1) NOT NULL,
	[Supervisor_Name] [nvarchar](50) NOT NULL,
	[Supervisor_Email] [nvarchar](50) NOT NULL,
	[Supervisor_Password] [nvarchar](50) NOT NULL,
	[PMO_FID] [int] NULL,
 CONSTRAINT [PK_Supervisor] PRIMARY KEY CLUSTERED 
(
	[Supervisor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task_Assign]    Script Date: 03/04/2022 11:55:42 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task_Assign](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Group_fid] [int] NOT NULL,
	[Task_fid] [int] NOT NULL,
	[Assign_Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Task_Assign] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task_Data]    Script Date: 03/04/2022 11:55:42 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task_Data](
	[id] [int] NOT NULL,
	[TaskData] [nvarchar](max) NOT NULL,
	[Taskassign_fid] [int] NOT NULL,
	[Submit_Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Task_Data] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Class] ON 

INSERT [dbo].[Class] ([id], [Class_Name]) VALUES (1, N'BS-IT')
INSERT [dbo].[Class] ([id], [Class_Name]) VALUES (2, N'Bs-CS')
SET IDENTITY_INSERT [dbo].[Class] OFF
SET IDENTITY_INSERT [dbo].[Examcell] ON 

INSERT [dbo].[Examcell] ([Examcell_id], [Examcell_Uniqueid], [Examcellpassword], [Examcell_Email]) VALUES (4, N'EX-Cell-01', N'Exam1234', N'Exam@mail.com')
INSERT [dbo].[Examcell] ([Examcell_id], [Examcell_Uniqueid], [Examcellpassword], [Examcell_Email]) VALUES (5, N'EX-Cell-27849', N'1234567', N'ahsanchaudary10@gmail.com')
SET IDENTITY_INSERT [dbo].[Examcell] OFF
SET IDENTITY_INSERT [dbo].[Group] ON 

INSERT [dbo].[Group] ([id], [Group_id], [supervisor_fid]) VALUES (1, N'BS-IT-15724', 2)
SET IDENTITY_INSERT [dbo].[Group] OFF
SET IDENTITY_INSERT [dbo].[PMO] ON 

INSERT [dbo].[PMO] ([PMO_id], [PMO_Name], [PMO_Email], [PMO_password]) VALUES (3, N'PMO', N'pmo', N'pmo')
SET IDENTITY_INSERT [dbo].[PMO] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Student_id], [Student_Name], [Student_Email], [Student_Password], [Clas_fid], [Group_fid]) VALUES (1, N'Muhammad Ahsan', N'ahsanchaudary10@gmail.com', N'12345678', 1, NULL)
INSERT [dbo].[Student] ([Student_id], [Student_Name], [Student_Email], [Student_Password], [Clas_fid], [Group_fid]) VALUES (2, N'afifa maqbool', N'afifa.maqbool27@gmail.com', N'12345678', 1, 1)
INSERT [dbo].[Student] ([Student_id], [Student_Name], [Student_Email], [Student_Password], [Clas_fid], [Group_fid]) VALUES (3, N'nawaf', N'nawaf@mail.com', N'12345678', 1, 1)
INSERT [dbo].[Student] ([Student_id], [Student_Name], [Student_Email], [Student_Password], [Clas_fid], [Group_fid]) VALUES (4, N'asad ilyas', N'asad@mail.com', N'12345678', 1, NULL)
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[Student_Task] ON 

INSERT [dbo].[Student_Task] ([Task_id], [Task_Name], [Task_start_date], [Task_end_Date], [Task_status]) VALUES (1, N'First Task', CAST(N'2022-03-04T00:00:00.000' AS DateTime), CAST(N'2022-03-04T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Student_Task] OFF
SET IDENTITY_INSERT [dbo].[Supervisor] ON 

INSERT [dbo].[Supervisor] ([Supervisor_id], [Supervisor_Name], [Supervisor_Email], [Supervisor_Password], [PMO_FID]) VALUES (2, N'Super', N'super', N'super', 3)
SET IDENTITY_INSERT [dbo].[Supervisor] OFF
SET IDENTITY_INSERT [dbo].[Task_Assign] ON 

INSERT [dbo].[Task_Assign] ([id], [Group_fid], [Task_fid], [Assign_Date]) VALUES (3, 1, 1, CAST(N'2022-04-03T15:30:22.017' AS DateTime))
SET IDENTITY_INSERT [dbo].[Task_Assign] OFF
INSERT [dbo].[Task_Data] ([id], [TaskData], [Taskassign_fid], [Submit_Date]) VALUES (0, N'~/content/taskdata/Testproject.zip', 3, CAST(N'2022-04-03T23:47:02.907' AS DateTime))
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Examcell]    Script Date: 03/04/2022 11:55:42 pm ******/
ALTER TABLE [dbo].[Examcell] ADD  CONSTRAINT [IX_Examcell] UNIQUE NONCLUSTERED 
(
	[Examcell_Uniqueid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Group_Supervisor] FOREIGN KEY([supervisor_fid])
REFERENCES [dbo].[Supervisor] ([Supervisor_id])
GO
ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Group_Supervisor]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Class] FOREIGN KEY([Clas_fid])
REFERENCES [dbo].[Class] ([id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Class]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Group] FOREIGN KEY([Group_fid])
REFERENCES [dbo].[Group] ([id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Group]
GO
ALTER TABLE [dbo].[Supervisor]  WITH CHECK ADD  CONSTRAINT [FK_Supervisor_PMO] FOREIGN KEY([PMO_FID])
REFERENCES [dbo].[PMO] ([PMO_id])
GO
ALTER TABLE [dbo].[Supervisor] CHECK CONSTRAINT [FK_Supervisor_PMO]
GO
ALTER TABLE [dbo].[Task_Assign]  WITH CHECK ADD  CONSTRAINT [FK_Task_Assign_Group] FOREIGN KEY([Group_fid])
REFERENCES [dbo].[Group] ([id])
GO
ALTER TABLE [dbo].[Task_Assign] CHECK CONSTRAINT [FK_Task_Assign_Group]
GO
ALTER TABLE [dbo].[Task_Assign]  WITH CHECK ADD  CONSTRAINT [FK_Task_Assign_Student_Task] FOREIGN KEY([Task_fid])
REFERENCES [dbo].[Student_Task] ([Task_id])
GO
ALTER TABLE [dbo].[Task_Assign] CHECK CONSTRAINT [FK_Task_Assign_Student_Task]
GO
ALTER TABLE [dbo].[Task_Data]  WITH CHECK ADD  CONSTRAINT [FK_Task_Data_Student_Task] FOREIGN KEY([Taskassign_fid])
REFERENCES [dbo].[Task_Assign] ([id])
GO
ALTER TABLE [dbo].[Task_Data] CHECK CONSTRAINT [FK_Task_Data_Student_Task]
GO
USE [master]
GO
ALTER DATABASE [FYP_UOS_2022] SET  READ_WRITE 
GO
