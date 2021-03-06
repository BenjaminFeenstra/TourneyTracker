USE [master]
GO
/****** Object:  Database [TourneyTrackerDB]    Script Date: 14/04/2015 12:24:04 ******/
CREATE DATABASE [TourneyTrackerDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TourneyTrackerDB', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLSERVER\MSSQL\DATA\TourneyTrackerDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TourneyTrackerDB_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLSERVER\MSSQL\DATA\TourneyTrackerDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TourneyTrackerDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TourneyTrackerDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TourneyTrackerDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TourneyTrackerDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TourneyTrackerDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TourneyTrackerDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TourneyTrackerDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TourneyTrackerDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TourneyTrackerDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TourneyTrackerDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TourneyTrackerDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TourneyTrackerDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TourneyTrackerDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TourneyTrackerDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TourneyTrackerDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TourneyTrackerDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TourneyTrackerDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TourneyTrackerDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TourneyTrackerDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TourneyTrackerDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TourneyTrackerDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TourneyTrackerDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TourneyTrackerDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TourneyTrackerDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TourneyTrackerDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TourneyTrackerDB] SET  MULTI_USER 
GO
ALTER DATABASE [TourneyTrackerDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TourneyTrackerDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TourneyTrackerDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TourneyTrackerDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TourneyTrackerDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [TourneyTrackerDB]
GO
/****** Object:  Table [dbo].[account]    Script Date: 14/04/2015 12:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account](
	[account_id] [int] IDENTITY(1,1) NOT NULL,
	[emailaddress] [nvarchar](max) NOT NULL,
	[password_salt] [nvarchar](max) NOT NULL,
	[password_hash] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_account] PRIMARY KEY CLUSTERED 
(
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[match]    Script Date: 14/04/2015 12:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[match](
	[match_id] [int] IDENTITY(1,1) NOT NULL,
	[tournament_id] [int] NOT NULL,
	[participant_number_one] [int] NOT NULL,
	[participant_number_two] [int] NOT NULL,
	[score_one] [int] NULL,
	[score_two] [int] NULL,
	[match_winner_type_id] [int] NULL,
	[message] [nvarchar](max) NULL,
 CONSTRAINT [PK_match] PRIMARY KEY CLUSTERED 
(
	[match_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[match_winner_type]    Script Date: 14/04/2015 12:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[match_winner_type](
	[match_winner_type_id] [int] IDENTITY(1,1) NOT NULL,
	[match_winner_type_value] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_match_winner_type] PRIMARY KEY CLUSTERED 
(
	[match_winner_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[participant]    Script Date: 14/04/2015 12:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[participant](
	[participant_id] [int] IDENTITY(1,1) NOT NULL,
	[participant_name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_participant] PRIMARY KEY CLUSTERED 
(
	[participant_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tournament]    Script Date: 14/04/2015 12:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tournament](
	[tournament_id] [int] IDENTITY(1,1) NOT NULL,
	[tournament_name] [nvarchar](max) NOT NULL,
	[tournament_host_id] [int] NOT NULL,
	[tournament_type_id] [int] NOT NULL,
	[number_participants] [int] NOT NULL,
 CONSTRAINT [PK_tournament] PRIMARY KEY CLUSTERED 
(
	[tournament_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tournament_participant_rel]    Script Date: 14/04/2015 12:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tournament_participant_rel](
	[tournament_participant_id] [int] IDENTITY(1,1) NOT NULL,
	[tournament_id] [int] NOT NULL,
	[participant_id] [int] NOT NULL,
 CONSTRAINT [PK_tournament_participant_rel] PRIMARY KEY CLUSTERED 
(
	[tournament_participant_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tournament_type]    Script Date: 14/04/2015 12:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tournament_type](
	[tournament_type_id] [int] IDENTITY(1,1) NOT NULL,
	[tournament_type_name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_tournament_type] PRIMARY KEY CLUSTERED 
(
	[tournament_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[match]  WITH CHECK ADD  CONSTRAINT [FK_match_match_winner_type] FOREIGN KEY([match_winner_type_id])
REFERENCES [dbo].[match_winner_type] ([match_winner_type_id])
GO
ALTER TABLE [dbo].[match] CHECK CONSTRAINT [FK_match_match_winner_type]
GO
ALTER TABLE [dbo].[match]  WITH CHECK ADD  CONSTRAINT [FK_match_participant] FOREIGN KEY([participant_number_one])
REFERENCES [dbo].[participant] ([participant_id])
GO
ALTER TABLE [dbo].[match] CHECK CONSTRAINT [FK_match_participant]
GO
ALTER TABLE [dbo].[match]  WITH CHECK ADD  CONSTRAINT [FK_match_participant1] FOREIGN KEY([participant_number_two])
REFERENCES [dbo].[participant] ([participant_id])
GO
ALTER TABLE [dbo].[match] CHECK CONSTRAINT [FK_match_participant1]
GO
ALTER TABLE [dbo].[match]  WITH CHECK ADD  CONSTRAINT [FK_match_tournament] FOREIGN KEY([tournament_id])
REFERENCES [dbo].[tournament] ([tournament_id])
GO
ALTER TABLE [dbo].[match] CHECK CONSTRAINT [FK_match_tournament]
GO
ALTER TABLE [dbo].[tournament]  WITH CHECK ADD  CONSTRAINT [FK_tournament_account] FOREIGN KEY([tournament_host_id])
REFERENCES [dbo].[account] ([account_id])
GO
ALTER TABLE [dbo].[tournament] CHECK CONSTRAINT [FK_tournament_account]
GO
ALTER TABLE [dbo].[tournament]  WITH CHECK ADD  CONSTRAINT [FK_tournament_tournament_type] FOREIGN KEY([tournament_type_id])
REFERENCES [dbo].[tournament_type] ([tournament_type_id])
GO
ALTER TABLE [dbo].[tournament] CHECK CONSTRAINT [FK_tournament_tournament_type]
GO
ALTER TABLE [dbo].[tournament_participant_rel]  WITH CHECK ADD  CONSTRAINT [FK_tournament_participant_rel_participant] FOREIGN KEY([participant_id])
REFERENCES [dbo].[participant] ([participant_id])
GO
ALTER TABLE [dbo].[tournament_participant_rel] CHECK CONSTRAINT [FK_tournament_participant_rel_participant]
GO
ALTER TABLE [dbo].[tournament_participant_rel]  WITH CHECK ADD  CONSTRAINT [FK_tournament_participant_rel_tournament] FOREIGN KEY([tournament_id])
REFERENCES [dbo].[tournament] ([tournament_id])
GO
ALTER TABLE [dbo].[tournament_participant_rel] CHECK CONSTRAINT [FK_tournament_participant_rel_tournament]
GO
USE [master]
GO
ALTER DATABASE [TourneyTrackerDB] SET  READ_WRITE 
GO
