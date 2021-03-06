USE [Dietter]
GO
/****** Object:  Schema [EventLogging]    Script Date: 16.05.2021 16:42:26 ******/
CREATE SCHEMA [EventLogging]
GO
/****** Object:  Table [dbo].[assignedList]    Script Date: 16.05.2021 16:42:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[assignedList](
	[id] [int] NOT NULL,
	[listId] [int] NULL,
	[clientId] [int] NULL,
	[foodId] [int] NULL,
	[date] [int] NULL,
 CONSTRAINT [PK_assignedList] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 16.05.2021 16:42:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[clientID] [int] NOT NULL,
	[clientName] [nchar](50) NOT NULL,
	[isdeleted] [bit] NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[clientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Foods]    Script Date: 16.05.2021 16:42:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Foods](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[foodName] [nvarchar](100) NULL,
	[foodType] [int] NULL,
	[calorie] [int] NULL,
 CONSTRAINT [PK_Foods] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodTypes]    Script Date: 16.05.2021 16:42:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodTypes](
	[foodTypeId] [int] IDENTITY(1,1) NOT NULL,
	[foodTypeName] [nchar](50) NULL,
 CONSTRAINT [PK_FoodTypes] PRIMARY KEY CLUSTERED 
(
	[foodTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lists]    Script Date: 16.05.2021 16:42:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lists](
	[listID] [int] NOT NULL,
	[date] [date] NULL,
	[clientID] [int] NULL,
	[Id] [int] NOT NULL,
 CONSTRAINT [PK_Lists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [EventLogging].[Logs]    Script Date: 16.05.2021 16:42:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [EventLogging].[Logs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](max) NULL,
	[TimeStamp] [datetime] NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [nvarchar](max) NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[assignedList]  WITH CHECK ADD  CONSTRAINT [FK_assignedList_Foods] FOREIGN KEY([foodId])
REFERENCES [dbo].[Foods] ([id])
GO
ALTER TABLE [dbo].[assignedList] CHECK CONSTRAINT [FK_assignedList_Foods]
GO
ALTER TABLE [dbo].[assignedList]  WITH CHECK ADD  CONSTRAINT [FK_assignedList_Lists] FOREIGN KEY([listId])
REFERENCES [dbo].[Lists] ([Id])
GO
ALTER TABLE [dbo].[assignedList] CHECK CONSTRAINT [FK_assignedList_Lists]
GO
ALTER TABLE [dbo].[Foods]  WITH CHECK ADD  CONSTRAINT [FK_Foods_FoodTypes] FOREIGN KEY([foodType])
REFERENCES [dbo].[FoodTypes] ([foodTypeId])
GO
ALTER TABLE [dbo].[Foods] CHECK CONSTRAINT [FK_Foods_FoodTypes]
GO
ALTER TABLE [dbo].[Lists]  WITH CHECK ADD  CONSTRAINT [FK_Lists_Clients] FOREIGN KEY([clientID])
REFERENCES [dbo].[Clients] ([clientID])
GO
ALTER TABLE [dbo].[Lists] CHECK CONSTRAINT [FK_Lists_Clients]
GO
