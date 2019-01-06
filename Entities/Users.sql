/****** Object:  Table [dbo].[Users]    Script Date: 1/5/2019 6:23:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[User_Id] [int] IDENTITY(1,1) NOT NULL,
	[First_Name] [varchar](50) NOT NULL,
	[Last_Name] [varchar](50) NOT NULL,
	[Employee_Id] [int] NOT NULL,
	[Project_Id] [int] NULL,
	[Task_Id] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Project] FOREIGN KEY([Project_Id])
REFERENCES [dbo].[Project] ([Project_Id])
GO

ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Project]
GO

ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Task] FOREIGN KEY([Task_Id])
REFERENCES [dbo].[Task] ([Task_Id])
GO

ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Task]
GO


