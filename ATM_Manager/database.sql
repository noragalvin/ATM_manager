USE [master]
GO
/****** Object:  Database [ATMManager]    Script Date: 12/11/18 12:00:43 PM ******/
CREATE DATABASE [ATMManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ATMManager', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ATMManager.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ATMManager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ATMManager_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ATMManager] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ATMManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ATMManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ATMManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ATMManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ATMManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ATMManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [ATMManager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ATMManager] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ATMManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ATMManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ATMManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ATMManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ATMManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ATMManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ATMManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ATMManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ATMManager] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ATMManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ATMManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ATMManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ATMManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ATMManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ATMManager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ATMManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ATMManager] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ATMManager] SET  MULTI_USER 
GO
ALTER DATABASE [ATMManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ATMManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ATMManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ATMManager] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ATMManager]
GO
/****** Object:  Table [dbo].[tblAccount]    Script Date: 12/11/18 12:00:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAccount](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[CustID] [int] NULL,
	[AccountNo] [nvarchar](50) NULL,
	[ODID] [int] NULL,
	[WDID] [int] NULL,
	[Balance] [int] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblATM]    Script Date: 12/11/18 12:00:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblATM](
	[ATMID] [int] NOT NULL,
	[Branch] [nvarchar](50) NULL,
	[Address] [nvarchar](100) NULL,
 CONSTRAINT [PK_ATM] PRIMARY KEY CLUSTERED 
(
	[ATMID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCard]    Script Date: 12/11/18 12:00:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCard](
	[CardNo] [nvarchar](50) NOT NULL,
	[Status] [int] NULL,
	[AccountID] [int] NULL,
	[PIN] [nvarchar](50) NULL,
	[StartDate] [date] NULL,
	[ExpiredDate] [date] NULL,
	[Attempt] [int] NULL,
 CONSTRAINT [PK_Card] PRIMARY KEY CLUSTERED 
(
	[CardNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblConfig]    Script Date: 12/11/18 12:00:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblConfig](
	[DateModified] [date] NULL,
	[MinWithDraw] [int] NULL,
	[MaxWithDraw] [int] NULL,
	[NumPerPage] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCustomer]    Script Date: 12/11/18 12:00:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCustomer](
	[CustID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](32) NULL,
	[Phone] [nvarchar](12) NULL,
	[Email] [nvarchar](50) NULL,
	[Addr] [nvarchar](100) NULL,
 CONSTRAINT [PK_tblCustomer] PRIMARY KEY CLUSTERED 
(
	[CustID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblLog]    Script Date: 12/11/18 12:00:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLog](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[LogTypeID] [int] NULL,
	[ATMID] [int] NULL,
	[CardNo] [nvarchar](50) NULL,
	[LogDate] [datetime] NULL,
	[Amout] [int] NULL,
	[Details] [nvarchar](100) NULL,
	[CardNoTo] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblLog] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblLogType]    Script Date: 12/11/18 12:00:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLogType](
	[LogTypeID] [int] NOT NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_tblLogType] PRIMARY KEY CLUSTERED 
(
	[LogTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblMoney]    Script Date: 12/11/18 12:00:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMoney](
	[MoneyID] [int] NOT NULL,
	[MoneyValue] [float] NULL,
 CONSTRAINT [PK_tblMoney] PRIMARY KEY CLUSTERED 
(
	[MoneyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblOverDrawftLimit]    Script Date: 12/11/18 12:00:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOverDrawftLimit](
	[ODID] [int] NOT NULL,
	[Value] [int] NULL,
 CONSTRAINT [PK_OverDrawft_Limit] PRIMARY KEY CLUSTERED 
(
	[ODID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblStock]    Script Date: 12/11/18 12:00:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStock](
	[StockID] [int] NOT NULL,
	[MoneyID] [int] NULL,
	[ATMID] [int] NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_tblStock] PRIMARY KEY CLUSTERED 
(
	[StockID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblWithDrawLimit]    Script Date: 12/11/18 12:00:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblWithDrawLimit](
	[WDID] [int] NOT NULL,
	[Value] [int] NULL,
 CONSTRAINT [PK_WithDraw_Limit] PRIMARY KEY CLUSTERED 
(
	[WDID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tblAccount] ON 

INSERT [dbo].[tblAccount] ([AccountID], [CustID], [AccountNo], [ODID], [WDID], [Balance]) VALUES (1, 1, N'11111111', 1, 1, 1897500)
INSERT [dbo].[tblAccount] ([AccountID], [CustID], [AccountNo], [ODID], [WDID], [Balance]) VALUES (5, 2, N'22222222', 2, 2, 2100000)
INSERT [dbo].[tblAccount] ([AccountID], [CustID], [AccountNo], [ODID], [WDID], [Balance]) VALUES (6, 3, N'33333333', 3, 3, 2000000)
INSERT [dbo].[tblAccount] ([AccountID], [CustID], [AccountNo], [ODID], [WDID], [Balance]) VALUES (7, 4, N'44444444', 4, 4, -1100)
SET IDENTITY_INSERT [dbo].[tblAccount] OFF
INSERT [dbo].[tblATM] ([ATMID], [Branch], [Address]) VALUES (1, N'Ha Tay', N'Ha Noi')
INSERT [dbo].[tblCard] ([CardNo], [Status], [AccountID], [PIN], [StartDate], [ExpiredDate], [Attempt]) VALUES (N'11111111', 1, 1, N'123456', CAST(N'2018-05-01' AS Date), CAST(N'2023-05-01' AS Date), 2)
INSERT [dbo].[tblCard] ([CardNo], [Status], [AccountID], [PIN], [StartDate], [ExpiredDate], [Attempt]) VALUES (N'22222222', 1, 5, N'123456', CAST(N'2018-05-02' AS Date), CAST(N'2018-05-02' AS Date), 1)
INSERT [dbo].[tblCard] ([CardNo], [Status], [AccountID], [PIN], [StartDate], [ExpiredDate], [Attempt]) VALUES (N'33333333', 1, 6, N'123456', CAST(N'2018-05-01' AS Date), CAST(N'2018-05-01' AS Date), 1)
INSERT [dbo].[tblCard] ([CardNo], [Status], [AccountID], [PIN], [StartDate], [ExpiredDate], [Attempt]) VALUES (N'44444444', 1, 7, N'123456', CAST(N'2018-05-01' AS Date), CAST(N'2018-05-01' AS Date), 1)
INSERT [dbo].[tblConfig] ([DateModified], [MinWithDraw], [MaxWithDraw], [NumPerPage]) VALUES (CAST(N'2018-11-21' AS Date), 50000, 5000000, 5)
SET IDENTITY_INSERT [dbo].[tblCustomer] ON 

INSERT [dbo].[tblCustomer] ([CustID], [Name], [Phone], [Email], [Addr]) VALUES (1, N'BUI NGOC MINH', N'01667998642', N'minhnora98@gmail.com', N'Quang Trung, Ha Dong, Ha Noi')
INSERT [dbo].[tblCustomer] ([CustID], [Name], [Phone], [Email], [Addr]) VALUES (2, N'TRAN THI ANH NGOC', N'974193852', N'nvana@gmail.com', N'Viet Nam')
INSERT [dbo].[tblCustomer] ([CustID], [Name], [Phone], [Email], [Addr]) VALUES (3, N'NGUYEN VAN TUAN', N'9741938234', N'nvab@gmail.com', N'Viet Nam')
INSERT [dbo].[tblCustomer] ([CustID], [Name], [Phone], [Email], [Addr]) VALUES (4, N'PHAM THI HIEN', N'9741938234', N'nvanc@gmail.com', N'Viet Nam')
SET IDENTITY_INSERT [dbo].[tblCustomer] OFF
SET IDENTITY_INSERT [dbo].[tblLog] ON 

INSERT [dbo].[tblLog] ([LogID], [LogTypeID], [ATMID], [CardNo], [LogDate], [Amout], [Details], [CardNoTo]) VALUES (70, 1, 1, N'22222222', CAST(N'2018-12-03 15:51:14.000' AS DateTime), 1000000, N'Rút tiền', NULL)
INSERT [dbo].[tblLog] ([LogID], [LogTypeID], [ATMID], [CardNo], [LogDate], [Amout], [Details], [CardNoTo]) VALUES (71, 1, 1, N'33333333', CAST(N'2018-12-03 20:00:35.000' AS DateTime), 1500000, N'Rút tiền', NULL)
INSERT [dbo].[tblLog] ([LogID], [LogTypeID], [ATMID], [CardNo], [LogDate], [Amout], [Details], [CardNoTo]) VALUES (72, 1, 1, N'11111111', CAST(N'2018-12-08 22:50:24.000' AS DateTime), 200000, N'Rút tiền', NULL)
INSERT [dbo].[tblLog] ([LogID], [LogTypeID], [ATMID], [CardNo], [LogDate], [Amout], [Details], [CardNoTo]) VALUES (73, 1, 1, N'11111111', CAST(N'2018-12-08 22:51:35.000' AS DateTime), 200000, N'Rút tiền', NULL)
INSERT [dbo].[tblLog] ([LogID], [LogTypeID], [ATMID], [CardNo], [LogDate], [Amout], [Details], [CardNoTo]) VALUES (74, 1, 1, N'11111111', CAST(N'2018-12-08 22:51:44.000' AS DateTime), 500000, N'Rút tiền', NULL)
INSERT [dbo].[tblLog] ([LogID], [LogTypeID], [ATMID], [CardNo], [LogDate], [Amout], [Details], [CardNoTo]) VALUES (75, 1, 1, N'11111111', CAST(N'2018-12-08 22:51:51.000' AS DateTime), 500000, N'Rút tiền', NULL)
INSERT [dbo].[tblLog] ([LogID], [LogTypeID], [ATMID], [CardNo], [LogDate], [Amout], [Details], [CardNoTo]) VALUES (76, 1, 1, N'11111111', CAST(N'2018-12-08 22:51:57.000' AS DateTime), 200000, N'Rút tiền', NULL)
INSERT [dbo].[tblLog] ([LogID], [LogTypeID], [ATMID], [CardNo], [LogDate], [Amout], [Details], [CardNoTo]) VALUES (77, 2, 1, N'22222222', CAST(N'2018-12-08 23:18:10.000' AS DateTime), 123, N'Chuyển tiền', N'11111111')
INSERT [dbo].[tblLog] ([LogID], [LogTypeID], [ATMID], [CardNo], [LogDate], [Amout], [Details], [CardNoTo]) VALUES (78, 1, 1, N'11111111', CAST(N'2018-12-08 23:27:10.000' AS DateTime), 200000, N'Rút tiền', NULL)
INSERT [dbo].[tblLog] ([LogID], [LogTypeID], [ATMID], [CardNo], [LogDate], [Amout], [Details], [CardNoTo]) VALUES (80, 1, 1, N'44444444', CAST(N'2018-12-09 00:12:28.000' AS DateTime), 2000000, N'Rút tiền', NULL)
INSERT [dbo].[tblLog] ([LogID], [LogTypeID], [ATMID], [CardNo], [LogDate], [Amout], [Details], [CardNoTo]) VALUES (81, 2, 1, N'11111111', CAST(N'2018-12-09 00:18:25.000' AS DateTime), 1000000, N'Chuyển tiền', N'22222222')
INSERT [dbo].[tblLog] ([LogID], [LogTypeID], [ATMID], [CardNo], [LogDate], [Amout], [Details], [CardNoTo]) VALUES (82, 2, 1, N'11111111', CAST(N'2018-12-09 00:20:55.000' AS DateTime), 1000000, N'Chuyển tiền', N'22222222')
INSERT [dbo].[tblLog] ([LogID], [LogTypeID], [ATMID], [CardNo], [LogDate], [Amout], [Details], [CardNoTo]) VALUES (83, 2, 1, N'11111111', CAST(N'2018-12-09 00:22:42.000' AS DateTime), 100, N'Chuyển tiền', N'22222222')
INSERT [dbo].[tblLog] ([LogID], [LogTypeID], [ATMID], [CardNo], [LogDate], [Amout], [Details], [CardNoTo]) VALUES (84, 2, 1, N'11111111', CAST(N'2018-12-09 00:25:02.000' AS DateTime), 100000, N'Chuyển tiền', N'22222222')
SET IDENTITY_INSERT [dbo].[tblLog] OFF
INSERT [dbo].[tblLogType] ([LogTypeID], [Description]) VALUES (1, N'Rút tiền')
INSERT [dbo].[tblLogType] ([LogTypeID], [Description]) VALUES (2, N'Chuyển tiền')
INSERT [dbo].[tblLogType] ([LogTypeID], [Description]) VALUES (3, N'Đổi pin')
INSERT [dbo].[tblMoney] ([MoneyID], [MoneyValue]) VALUES (1, 20000)
INSERT [dbo].[tblMoney] ([MoneyID], [MoneyValue]) VALUES (2, 50000)
INSERT [dbo].[tblMoney] ([MoneyID], [MoneyValue]) VALUES (3, 100000)
INSERT [dbo].[tblMoney] ([MoneyID], [MoneyValue]) VALUES (4, 200000)
INSERT [dbo].[tblMoney] ([MoneyID], [MoneyValue]) VALUES (5, 500000)
INSERT [dbo].[tblOverDrawftLimit] ([ODID], [Value]) VALUES (1, 1000000)
INSERT [dbo].[tblOverDrawftLimit] ([ODID], [Value]) VALUES (2, 2000000)
INSERT [dbo].[tblOverDrawftLimit] ([ODID], [Value]) VALUES (3, 1000000)
INSERT [dbo].[tblOverDrawftLimit] ([ODID], [Value]) VALUES (4, 2000000)
INSERT [dbo].[tblStock] ([StockID], [MoneyID], [ATMID], [Quantity]) VALUES (1, 1, 1, 100)
INSERT [dbo].[tblStock] ([StockID], [MoneyID], [ATMID], [Quantity]) VALUES (2, 2, 1, 100)
INSERT [dbo].[tblStock] ([StockID], [MoneyID], [ATMID], [Quantity]) VALUES (3, 3, 1, 95)
INSERT [dbo].[tblStock] ([StockID], [MoneyID], [ATMID], [Quantity]) VALUES (4, 4, 1, 86)
INSERT [dbo].[tblStock] ([StockID], [MoneyID], [ATMID], [Quantity]) VALUES (5, 5, 1, 50)
INSERT [dbo].[tblWithDrawLimit] ([WDID], [Value]) VALUES (1, 5000000)
INSERT [dbo].[tblWithDrawLimit] ([WDID], [Value]) VALUES (2, 3000000)
INSERT [dbo].[tblWithDrawLimit] ([WDID], [Value]) VALUES (3, 2000000)
INSERT [dbo].[tblWithDrawLimit] ([WDID], [Value]) VALUES (4, 3000000)
ALTER TABLE [dbo].[tblAccount]  WITH CHECK ADD  CONSTRAINT [FK_tblAccount_tblCustomer] FOREIGN KEY([CustID])
REFERENCES [dbo].[tblCustomer] ([CustID])
GO
ALTER TABLE [dbo].[tblAccount] CHECK CONSTRAINT [FK_tblAccount_tblCustomer]
GO
ALTER TABLE [dbo].[tblAccount]  WITH CHECK ADD  CONSTRAINT [FK_tblAccount_tblOverDrawftLimit] FOREIGN KEY([ODID])
REFERENCES [dbo].[tblOverDrawftLimit] ([ODID])
GO
ALTER TABLE [dbo].[tblAccount] CHECK CONSTRAINT [FK_tblAccount_tblOverDrawftLimit]
GO
ALTER TABLE [dbo].[tblAccount]  WITH CHECK ADD  CONSTRAINT [FK_tblAccount_tblWithDrawLimit] FOREIGN KEY([WDID])
REFERENCES [dbo].[tblWithDrawLimit] ([WDID])
GO
ALTER TABLE [dbo].[tblAccount] CHECK CONSTRAINT [FK_tblAccount_tblWithDrawLimit]
GO
ALTER TABLE [dbo].[tblCard]  WITH CHECK ADD  CONSTRAINT [FK_tblCard_tblAccount] FOREIGN KEY([AccountID])
REFERENCES [dbo].[tblAccount] ([AccountID])
GO
ALTER TABLE [dbo].[tblCard] CHECK CONSTRAINT [FK_tblCard_tblAccount]
GO
ALTER TABLE [dbo].[tblLog]  WITH CHECK ADD  CONSTRAINT [FK_tblLog_tblATM] FOREIGN KEY([ATMID])
REFERENCES [dbo].[tblATM] ([ATMID])
GO
ALTER TABLE [dbo].[tblLog] CHECK CONSTRAINT [FK_tblLog_tblATM]
GO
ALTER TABLE [dbo].[tblLog]  WITH NOCHECK ADD  CONSTRAINT [FK_tblLog_tblCard] FOREIGN KEY([CardNo])
REFERENCES [dbo].[tblCard] ([CardNo])
GO
ALTER TABLE [dbo].[tblLog] NOCHECK CONSTRAINT [FK_tblLog_tblCard]
GO
ALTER TABLE [dbo].[tblLog]  WITH NOCHECK ADD  CONSTRAINT [FK_tblLog_tblLogType] FOREIGN KEY([LogTypeID])
REFERENCES [dbo].[tblLogType] ([LogTypeID])
GO
ALTER TABLE [dbo].[tblLog] NOCHECK CONSTRAINT [FK_tblLog_tblLogType]
GO
ALTER TABLE [dbo].[tblStock]  WITH CHECK ADD  CONSTRAINT [FK_tblStock_tblATM] FOREIGN KEY([ATMID])
REFERENCES [dbo].[tblATM] ([ATMID])
GO
ALTER TABLE [dbo].[tblStock] CHECK CONSTRAINT [FK_tblStock_tblATM]
GO
ALTER TABLE [dbo].[tblStock]  WITH CHECK ADD  CONSTRAINT [FK_tblStock_tblMoney] FOREIGN KEY([MoneyID])
REFERENCES [dbo].[tblMoney] ([MoneyID])
GO
ALTER TABLE [dbo].[tblStock] CHECK CONSTRAINT [FK_tblStock_tblMoney]
GO
USE [master]
GO
ALTER DATABASE [ATMManager] SET  READ_WRITE 
GO
