USE [Employee]
GO

/****** Object:  Table [dbo].[Task]    Script Date: 1/5/2019 6:27:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Task](
	[Task_Id] [int] IDENTITY(1,1) NOT NULL,
	[Parent_Id] [int] NULL,
	[Project_Id] [int] NULL,
	[Task_Description] [varchar](50) NOT NULL,
	[Start_Date] [date] NOT NULL,
	[End_Date] [date] NOT NULL,
	[Priority] [int] NOT NULL,
	[Status] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Task_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Project] FOREIGN KEY([Project_Id])
REFERENCES [dbo].[Project] ([Project_Id])
GO

ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Project]
GO


