USE [master]
GO

/****** Object:  Database [OrmTests]    Script Date: 15/05/2022 17:33:47 ******/
CREATE DATABASE [OrmTests]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OrmTests', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.LOCALSQLSERVER\MSSQL\DATA\OrmTests.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OrmTests_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.LOCALSQLSERVER\MSSQL\DATA\OrmTests_log.ldf' , SIZE = 139264KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO


USE [OrmTests]
GO

/** Object:  Table [dbo].[Data]    Script Date: 15/05/2022 16:27:57 **/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Data](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Item1] [varchar](50) NULL,
	[Item2] [varchar](50) NULL,
	[Item3] [varchar](50) NULL,
	[Item4] [varchar](50) NULL,
	[Item5] [varchar](50) NULL,
	[Item6] [varchar](50) NULL,
	[Item7] [varchar](50) NULL,
	[Item8] [varchar](50) NULL,
	[Item9] [varchar](50) NULL,
	[Item10] [varchar](50) NULL,
 CONSTRAINT [PK_Data] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

declare @i int = 1;
while(@i <= 60000)
begin
insert into Data values (@i * 1,@i * 2, @i * 3,@i * 4,@i * 5,@i * 6,@i * 7,@i * 8, @i * 9,@i * 10)
set @i = @i + 1
end


USE [OrmTests]
GO

/** Object:  StoredProcedure [dbo].[GetData]    Script Date: 15/05/2022 16:38:17 **/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetData] 

	
AS
BEGIN

	SET NOCOUNT ON;

  
	 select 
	 Id,
	 Item1,
	 Item2,
	 Item3,
	 Item4,
	 Item5,
	 Item6,
	 Item7,
	 Item8,
	 Item9,
	 Item10
	 from Data
END
GO

