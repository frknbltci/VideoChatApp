
GO

ALTER DATABASE [ChatDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ChatDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ChatDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ChatDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ChatDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ChatDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ChatDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ChatDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ChatDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ChatDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ChatDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ChatDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ChatDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ChatDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ChatDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ChatDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ChatDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ChatDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ChatDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ChatDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ChatDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ChatDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ChatDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ChatDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ChatDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ChatDB] SET  MULTI_USER 
GO
ALTER DATABASE [ChatDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ChatDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ChatDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ChatDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ChatDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ChatDB]
GO
/****** Object:  Table [dbo].[AdminUser]    Script Date: 12/16/2020 11:17:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminUser](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](8) NULL,
 CONSTRAINT [PK_AdminUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BodyTypes]    Script Date: 12/16/2020 11:17:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BodyTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BodyTypeName] [nvarchar](30) NULL,
 CONSTRAINT [PK_BodyTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 12/16/2020 11:17:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[BtPrice] [int] NULL,
	[ImageURL] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[GenderID] [int] NULL,
	[GenderChoiceID] [int] NULL,
	[StatusID] [int] NULL,
	[ContractAcceptance] [bit] NULL CONSTRAINT [DF_Customer_ContractAcceptance]  DEFAULT ((1)),
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerPayment]    Script Date: 12/16/2020 11:17:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerPayment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[PaymentCredit] [int] NULL,
	[EmployeeID] [int] NULL,
	[CreatedTime] [datetime] NULL,
 CONSTRAINT [PK_CustomerPayment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 12/16/2020 11:17:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[BankName] [nvarchar](50) NULL,
	[IBAN] [nvarchar](50) NULL,
	[ImageURL] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[GenderID] [int] NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[NickName] [nvarchar](50) NULL,
	[StatusID] [int] NULL,
	[About] [nvarchar](255) NULL,
	[Length] [float] NULL,
	[Weight] [float] NULL,
	[HairTypeID] [int] NULL,
	[BodyTypeID] [int] NULL,
	[BirthDate] [date] NULL,
	[EyeColorID] [int] NULL,
	[HairColorID] [int] NULL,
	[Confirmation] [bit] NULL,
	[ContractAcceptance] [bit] NULL CONSTRAINT [DF_Employee_ContractAcceptance]  DEFAULT ((1)),
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EyeColors]    Script Date: 12/16/2020 11:17:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EyeColors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ColorName] [nvarchar](50) NULL,
 CONSTRAINT [PK_EyeColors] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Favorites]    Script Date: 12/16/2020 11:17:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favorites](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[EmployeeID] [int] NULL,
 CONSTRAINT [PK_Favorites] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gender]    Script Date: 12/16/2020 11:17:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GenderType] [nvarchar](50) NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GenderChoice]    Script Date: 12/16/2020 11:17:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenderChoice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GenChoice] [nvarchar](50) NULL,
 CONSTRAINT [PK_GenderChoice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HairColors]    Script Date: 12/16/2020 11:17:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HairColors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ColorName] [nvarchar](50) NULL,
 CONSTRAINT [PK_HairColors] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HairTypes]    Script Date: 12/16/2020 11:17:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HairTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HairType] [nvarchar](50) NULL,
 CONSTRAINT [PK_HairTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MessageCusAdmin]    Script Date: 12/16/2020 11:17:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageCusAdmin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AdminID] [int] NULL,
	[CusID] [int] NULL,
	[Message] [nvarchar](max) NULL,
	[Viewed] [bit] NULL,
	[SendDate] [datetime] NULL,
	[About] [nvarchar](max) NULL,
 CONSTRAINT [PK_MessageCusAdmin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MessageEmpAdmin]    Script Date: 12/16/2020 11:17:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageEmpAdmin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AdminID] [int] NULL,
	[EmpID] [int] NULL,
	[Message] [nvarchar](max) NULL,
	[Viewed] [bit] NULL CONSTRAINT [DF_MessageEmpAdmin_Viewed]  DEFAULT ((0)),
	[SendDate] [datetime] NULL,
	[About] [nvarchar](max) NULL,
 CONSTRAINT [PK_MessageEmpAdmin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Messages]    Script Date: 12/16/2020 11:17:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[SenderID] [int] NULL,
	[ReceiverID] [int] NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PayChart]    Script Date: 12/16/2020 11:17:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayChart](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AdminID] [int] NULL,
	[EmployeeID] [int] NULL,
	[Quantity] [float] NULL,
	[CreatedDate] [datetime] NULL,
	[PayImg] [nvarchar](250) NULL,
 CONSTRAINT [PK_PayChart] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payment]    Script Date: 12/16/2020 11:17:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[OrderId] [nvarchar](max) NULL,
	[PaymentDate] [datetime] NULL,
	[Price] [decimal](18, 0) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PoolBan]    Script Date: 12/16/2020 11:17:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PoolBan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[EmployeeID] [int] NULL,
 CONSTRAINT [PK_PoolBan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Status]    Script Date: 12/16/2020 11:17:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TimeLine]    Script Date: 12/16/2020 11:17:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeLine](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[EmployeeID] [int] NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[TotalTime] [datetime] NULL,
	[Room] [nvarchar](50) NULL,
 CONSTRAINT [PK_TimeLine] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[AdminUser] ON 

INSERT [dbo].[AdminUser] ([ID], [UserName], [Password]) VALUES (1, N'admin', N'123.,-')
INSERT [dbo].[AdminUser] ([ID], [UserName], [Password]) VALUES (2, N'admin2', N'123.,-')
INSERT [dbo].[AdminUser] ([ID], [UserName], [Password]) VALUES (3, N'admin3', N'123.,-')
SET IDENTITY_INSERT [dbo].[AdminUser] OFF
SET IDENTITY_INSERT [dbo].[BodyTypes] ON 

INSERT [dbo].[BodyTypes] ([ID], [BodyTypeName]) VALUES (1, N'Zayıf ')
INSERT [dbo].[BodyTypes] ([ID], [BodyTypeName]) VALUES (2, N'Kaslı')
INSERT [dbo].[BodyTypes] ([ID], [BodyTypeName]) VALUES (3, N'Kilolu')
INSERT [dbo].[BodyTypes] ([ID], [BodyTypeName]) VALUES (4, N'Balık Etli')
SET IDENTITY_INSERT [dbo].[BodyTypes] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([ID], [UserName], [Password], [Email], [BtPrice], [ImageURL], [IsActive], [GenderID], [GenderChoiceID], [StatusID], [ContractAcceptance]) VALUES (4, N'Faruk', N'faruk', N'faruk@gmail.com', 100, N'/Assets/ModelImg/unnamed.jpg', 1, 1, 2, 2, 1)
INSERT [dbo].[Customer] ([ID], [UserName], [Password], [Email], [BtPrice], [ImageURL], [IsActive], [GenderID], [GenderChoiceID], [StatusID], [ContractAcceptance]) VALUES (5, N'Santiago', N'123123', N'santi@gmail.com', 1849, N'/Areas/Assets/StaticCustomerImages/resim6.jpg', 1, 1, 2, 2, 1)
INSERT [dbo].[Customer] ([ID], [UserName], [Password], [Email], [BtPrice], [ImageURL], [IsActive], [GenderID], [GenderChoiceID], [StatusID], [ContractAcceptance]) VALUES (6, N'deneme45', N'deneme', N'denemee@gmail.com', 200, N'/Assets/ModelImg/unnamed.jpg', 1, 1, 2, 1, 1)
INSERT [dbo].[Customer] ([ID], [UserName], [Password], [Email], [BtPrice], [ImageURL], [IsActive], [GenderID], [GenderChoiceID], [StatusID], [ContractAcceptance]) VALUES (7, N'Deneme285', N'deneme2', N'deneme@hotmail.com', 290, N'/Assets/ModelImg/indir (1).jpg', 0, 1, 2, 3, 1)
INSERT [dbo].[Customer] ([ID], [UserName], [Password], [Email], [BtPrice], [ImageURL], [IsActive], [GenderID], [GenderChoiceID], [StatusID], [ContractAcceptance]) VALUES (11, N'Santiago2', N'123123', N'santi23@gmail.com', 0, NULL, 0, 1, 2, 2, 1)
INSERT [dbo].[Customer] ([ID], [UserName], [Password], [Email], [BtPrice], [ImageURL], [IsActive], [GenderID], [GenderChoiceID], [StatusID], [ContractAcceptance]) VALUES (12, N'recrec', N'123123', N'recrec@gmail.com', 60, N'/Areas/Assets/CustomerImg/f8a24c08-08ed-4060-a336-9230358ccf15.jpg', 1, 1, 2, 3, 1)
INSERT [dbo].[Customer] ([ID], [UserName], [Password], [Email], [BtPrice], [ImageURL], [IsActive], [GenderID], [GenderChoiceID], [StatusID], [ContractAcceptance]) VALUES (13, N'deneme453', N'123123', N'faruk2222222@gmail.com', 0, NULL, 1, 1, 2, 2, 1)
INSERT [dbo].[Customer] ([ID], [UserName], [Password], [Email], [BtPrice], [ImageURL], [IsActive], [GenderID], [GenderChoiceID], [StatusID], [ContractAcceptance]) VALUES (14, N'frknfrkn', N'123123', N'frkn9@gmail.com', 470, N'/Areas/Assets/CustomerImg/men.png', 1, 1, 2, 3, 1)
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[CustomerPayment] ON 

INSERT [dbo].[CustomerPayment] ([ID], [CustomerID], [PaymentCredit], [EmployeeID], [CreatedTime]) VALUES (1, 5, 10, 3, CAST(N'2020-10-13 00:00:00.000' AS DateTime))
INSERT [dbo].[CustomerPayment] ([ID], [CustomerID], [PaymentCredit], [EmployeeID], [CreatedTime]) VALUES (2, 5, 10, 3, CAST(N'2020-10-13 00:00:00.000' AS DateTime))
INSERT [dbo].[CustomerPayment] ([ID], [CustomerID], [PaymentCredit], [EmployeeID], [CreatedTime]) VALUES (3, 5, 10, 3, CAST(N'2020-10-13 00:00:00.000' AS DateTime))
INSERT [dbo].[CustomerPayment] ([ID], [CustomerID], [PaymentCredit], [EmployeeID], [CreatedTime]) VALUES (4, 5, 10, 3, CAST(N'2020-10-13 00:00:00.000' AS DateTime))
INSERT [dbo].[CustomerPayment] ([ID], [CustomerID], [PaymentCredit], [EmployeeID], [CreatedTime]) VALUES (5, 12, 10, 3, CAST(N'2020-10-14 00:00:00.000' AS DateTime))
INSERT [dbo].[CustomerPayment] ([ID], [CustomerID], [PaymentCredit], [EmployeeID], [CreatedTime]) VALUES (6, 12, 10, 3, CAST(N'2020-10-14 00:00:00.000' AS DateTime))
INSERT [dbo].[CustomerPayment] ([ID], [CustomerID], [PaymentCredit], [EmployeeID], [CreatedTime]) VALUES (7, 12, 10, 3, CAST(N'2020-10-15 00:00:00.000' AS DateTime))
INSERT [dbo].[CustomerPayment] ([ID], [CustomerID], [PaymentCredit], [EmployeeID], [CreatedTime]) VALUES (8, 12, 10, 3, CAST(N'2020-10-15 00:00:00.000' AS DateTime))
INSERT [dbo].[CustomerPayment] ([ID], [CustomerID], [PaymentCredit], [EmployeeID], [CreatedTime]) VALUES (9, 12, 10, 3, CAST(N'2020-10-15 00:00:00.000' AS DateTime))
INSERT [dbo].[CustomerPayment] ([ID], [CustomerID], [PaymentCredit], [EmployeeID], [CreatedTime]) VALUES (10, 12, 10, 3, CAST(N'2020-10-15 00:00:00.000' AS DateTime))
INSERT [dbo].[CustomerPayment] ([ID], [CustomerID], [PaymentCredit], [EmployeeID], [CreatedTime]) VALUES (11, 12, 10, 3, CAST(N'2020-10-15 00:00:00.000' AS DateTime))
INSERT [dbo].[CustomerPayment] ([ID], [CustomerID], [PaymentCredit], [EmployeeID], [CreatedTime]) VALUES (12, 12, 10, 3, CAST(N'2020-10-15 00:00:00.000' AS DateTime))
INSERT [dbo].[CustomerPayment] ([ID], [CustomerID], [PaymentCredit], [EmployeeID], [CreatedTime]) VALUES (13, 14, 10, 3, CAST(N'2020-10-16 00:00:00.000' AS DateTime))
INSERT [dbo].[CustomerPayment] ([ID], [CustomerID], [PaymentCredit], [EmployeeID], [CreatedTime]) VALUES (14, 14, 10, 3, CAST(N'2020-10-16 00:00:00.000' AS DateTime))
INSERT [dbo].[CustomerPayment] ([ID], [CustomerID], [PaymentCredit], [EmployeeID], [CreatedTime]) VALUES (15, 14, 10, 3, CAST(N'2020-10-16 00:00:00.000' AS DateTime))
INSERT [dbo].[CustomerPayment] ([ID], [CustomerID], [PaymentCredit], [EmployeeID], [CreatedTime]) VALUES (16, 5, 20, 3, CAST(N'2020-10-19 00:00:00.000' AS DateTime))
INSERT [dbo].[CustomerPayment] ([ID], [CustomerID], [PaymentCredit], [EmployeeID], [CreatedTime]) VALUES (17, 5, 170, 3, CAST(N'2020-10-19 00:00:00.000' AS DateTime))
INSERT [dbo].[CustomerPayment] ([ID], [CustomerID], [PaymentCredit], [EmployeeID], [CreatedTime]) VALUES (18, 5, 50, 3, CAST(N'2020-10-19 00:00:00.000' AS DateTime))
INSERT [dbo].[CustomerPayment] ([ID], [CustomerID], [PaymentCredit], [EmployeeID], [CreatedTime]) VALUES (19, 5, 50, 3, CAST(N'2020-10-19 00:00:00.000' AS DateTime))
INSERT [dbo].[CustomerPayment] ([ID], [CustomerID], [PaymentCredit], [EmployeeID], [CreatedTime]) VALUES (20, 5, 50, 3, CAST(N'2020-10-20 00:00:00.000' AS DateTime))
INSERT [dbo].[CustomerPayment] ([ID], [CustomerID], [PaymentCredit], [EmployeeID], [CreatedTime]) VALUES (21, 5, 100, 3, CAST(N'2020-10-20 00:00:00.000' AS DateTime))
INSERT [dbo].[CustomerPayment] ([ID], [CustomerID], [PaymentCredit], [EmployeeID], [CreatedTime]) VALUES (25, 5, 1, 3, CAST(N'2020-10-03 00:00:00.000' AS DateTime))
INSERT [dbo].[CustomerPayment] ([ID], [CustomerID], [PaymentCredit], [EmployeeID], [CreatedTime]) VALUES (43, 5, 1, 3, CAST(N'2020-11-04 11:42:52.057' AS DateTime))
INSERT [dbo].[CustomerPayment] ([ID], [CustomerID], [PaymentCredit], [EmployeeID], [CreatedTime]) VALUES (44, 5, 1, 23, CAST(N'2020-11-04 11:42:56.223' AS DateTime))
INSERT [dbo].[CustomerPayment] ([ID], [CustomerID], [PaymentCredit], [EmployeeID], [CreatedTime]) VALUES (45, 5, 1, 8, CAST(N'2020-11-04 16:33:57.283' AS DateTime))
SET IDENTITY_INSERT [dbo].[CustomerPayment] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([ID], [UserName], [Password], [Email], [BankName], [IBAN], [ImageURL], [IsActive], [GenderID], [FirstName], [LastName], [NickName], [StatusID], [About], [Length], [Weight], [HairTypeID], [BodyTypeID], [BirthDate], [EyeColorID], [HairColorID], [Confirmation], [ContractAcceptance]) VALUES (3, N'Sibel', N'deneme1', N'deneme@gmail.com', N'YapıKredi', N'123123123123', N'/Areas/Assets/StaticModelImages/resim6.jpg', 1, 2, N'SİBEL', N'SİBEL', N'Sibelll', 2, N'Merhaba ben sibel', 170, 75, 1, 1, CAST(N'1990-10-18' AS Date), 2, 6, 1, 1)
INSERT [dbo].[Employee] ([ID], [UserName], [Password], [Email], [BankName], [IBAN], [ImageURL], [IsActive], [GenderID], [FirstName], [LastName], [NickName], [StatusID], [About], [Length], [Weight], [HairTypeID], [BodyTypeID], [BirthDate], [EyeColorID], [HairColorID], [Confirmation], [ContractAcceptance]) VALUES (8, N'Olga', N'deneme2', N'denemeasd@gmail.com', N'İş', N'12312132131', N'/Assets/ModelImg/Angelina.jpg', 0, 2, N'OLGA', N'DESOUZA', N'Olga', 1, N'Merhaba Ben Olga', 165, 60, 2, 1, CAST(N'1995-06-08' AS Date), 1, 1, 1, 1)
INSERT [dbo].[Employee] ([ID], [UserName], [Password], [Email], [BankName], [IBAN], [ImageURL], [IsActive], [GenderID], [FirstName], [LastName], [NickName], [StatusID], [About], [Length], [Weight], [HairTypeID], [BodyTypeID], [BirthDate], [EyeColorID], [HairColorID], [Confirmation], [ContractAcceptance]) VALUES (9, N'Güler', N'model3', N'model3@gmail.com', N'İş', N'6565656565', N'/Assets/ModelImg/foto1.jpg', 0, 2, N'GÜLER', N'BODRUM', N'Güler', 1, N'MERHABA BEN GÜLER', 168, 59, 2, 1, CAST(N'1991-04-22' AS Date), 1, 2, 1, 1)
INSERT [dbo].[Employee] ([ID], [UserName], [Password], [Email], [BankName], [IBAN], [ImageURL], [IsActive], [GenderID], [FirstName], [LastName], [NickName], [StatusID], [About], [Length], [Weight], [HairTypeID], [BodyTypeID], [BirthDate], [EyeColorID], [HairColorID], [Confirmation], [ContractAcceptance]) VALUES (10, N'Nilay ', N'model4', N'model4@gmail.com', N'Ziraat', N'54545555', N'/Assets/ModelImg/foto4.jpg', 1, 2, N'Gülay', N'Nilay', N'Nilay', 1, N'Merhaba Ben Nilay', 17, 70, 2, 1, CAST(N'1990-05-12' AS Date), 2, 3, 1, 1)
INSERT [dbo].[Employee] ([ID], [UserName], [Password], [Email], [BankName], [IBAN], [ImageURL], [IsActive], [GenderID], [FirstName], [LastName], [NickName], [StatusID], [About], [Length], [Weight], [HairTypeID], [BodyTypeID], [BirthDate], [EyeColorID], [HairColorID], [Confirmation], [ContractAcceptance]) VALUES (11, N'Selin ', N'model5', N'model5@gmail.com', N'Kuveytürk', N'654654646', N'/Assets/ModelImg/foto1.jpg', 1, 2, N'Selen', N'Selenay', N'Selin', 1, N'Merhaba Ben Selin', 17, 59, 1, 1, CAST(N'1990-07-01' AS Date), 1, 2, 1, 1)
INSERT [dbo].[Employee] ([ID], [UserName], [Password], [Email], [BankName], [IBAN], [ImageURL], [IsActive], [GenderID], [FirstName], [LastName], [NickName], [StatusID], [About], [Length], [Weight], [HairTypeID], [BodyTypeID], [BirthDate], [EyeColorID], [HairColorID], [Confirmation], [ContractAcceptance]) VALUES (12, N'Hande', N'model6', N'model6@gmail.com', N'YapıKredi', N'545454555', NULL, 1, 2, N'Hande', N'GG', N'Hande', 1, N'Merhaba Ben Hande', 180, 70, 1, 1, CAST(N'1994-05-05' AS Date), 1, 1, 1, 1)
INSERT [dbo].[Employee] ([ID], [UserName], [Password], [Email], [BankName], [IBAN], [ImageURL], [IsActive], [GenderID], [FirstName], [LastName], [NickName], [StatusID], [About], [Length], [Weight], [HairTypeID], [BodyTypeID], [BirthDate], [EyeColorID], [HairColorID], [Confirmation], [ContractAcceptance]) VALUES (13, N'Tülay ', N'model7', N'model7@gmail.com', N'YapıKredi', N'545454555', N'/Assets/ModelImg/foto5.jpg', 0, 2, N'Tülay', N'Tülay', N'Tülay', 1, N'Merhaba Ben Tülay', 177, 59, 1, 1, CAST(N'1992-06-06' AS Date), 1, 1, 1, 1)
INSERT [dbo].[Employee] ([ID], [UserName], [Password], [Email], [BankName], [IBAN], [ImageURL], [IsActive], [GenderID], [FirstName], [LastName], [NickName], [StatusID], [About], [Length], [Weight], [HairTypeID], [BodyTypeID], [BirthDate], [EyeColorID], [HairColorID], [Confirmation], [ContractAcceptance]) VALUES (14, N'Meltem', N'model8', N'model8@gmail.com', N'İş', N'4654656565', N'/Assets/ModelImg/foto5.jpg', 1, 2, N'Meltem', N'GG', N'Meltem', 1, N'Merhaba Ben Meltem', 175, 6, 1, 1, CAST(N'1995-06-07' AS Date), 1, 1, 1, 1)
INSERT [dbo].[Employee] ([ID], [UserName], [Password], [Email], [BankName], [IBAN], [ImageURL], [IsActive], [GenderID], [FirstName], [LastName], [NickName], [StatusID], [About], [Length], [Weight], [HairTypeID], [BodyTypeID], [BirthDate], [EyeColorID], [HairColorID], [Confirmation], [ContractAcceptance]) VALUES (15, N'Sezen', N'model9', N'model9@gmail.com', N'İş', N'64554545454', N'/Assets/ModelImg/Angelina.jpg', 1, 2, N'Sezen', N'gg', N'Sezen', 2, N'Merhaba Ben Sezen', 165, 58, 1, 1, CAST(N'1992-07-08' AS Date), 1, 1, 1, 1)
INSERT [dbo].[Employee] ([ID], [UserName], [Password], [Email], [BankName], [IBAN], [ImageURL], [IsActive], [GenderID], [FirstName], [LastName], [NickName], [StatusID], [About], [Length], [Weight], [HairTypeID], [BodyTypeID], [BirthDate], [EyeColorID], [HairColorID], [Confirmation], [ContractAcceptance]) VALUES (23, N'Selda', N'selen123', N'selen@gmail.com', N'YapıKredi', N'TR123123123123123123', N'/Areas/Assets/ModelImg/women.png', 1, 2, N'Selen', N'XYZ', N'Selda', 1, NULL, 165, 70, 1, 1, CAST(N'1990-10-20' AS Date), 1, 2, 1, 1)
INSERT [dbo].[Employee] ([ID], [UserName], [Password], [Email], [BankName], [IBAN], [ImageURL], [IsActive], [GenderID], [FirstName], [LastName], [NickName], [StatusID], [About], [Length], [Weight], [HairTypeID], [BodyTypeID], [BirthDate], [EyeColorID], [HairColorID], [Confirmation], [ContractAcceptance]) VALUES (24, N'denemesoz', N'123123', N'denemesoz@gmail.com', NULL, NULL, N'/Areas/Assets/ModelImg/women.png', 0, 2, N'denemesoz', N'sss', N'denemesoz12', 2, NULL, 0, 0, 2, 1, CAST(N'1988-12-21' AS Date), 2, 2, 0, 1)
INSERT [dbo].[Employee] ([ID], [UserName], [Password], [Email], [BankName], [IBAN], [ImageURL], [IsActive], [GenderID], [FirstName], [LastName], [NickName], [StatusID], [About], [Length], [Weight], [HairTypeID], [BodyTypeID], [BirthDate], [EyeColorID], [HairColorID], [Confirmation], [ContractAcceptance]) VALUES (32, N'deneme1a', N'123123', N'fbaltaci.34@gmail.com', NULL, NULL, N'/Areas/Assets/ModelImg/women.png', 0, 2, N'asdasdasd', N'asdasdasd', N'asdadasda', 2, NULL, 0, 0, 1, 2, CAST(N'1991-12-21' AS Date), 2, 2, 0, 1)
INSERT [dbo].[Employee] ([ID], [UserName], [Password], [Email], [BankName], [IBAN], [ImageURL], [IsActive], [GenderID], [FirstName], [LastName], [NickName], [StatusID], [About], [Length], [Weight], [HairTypeID], [BodyTypeID], [BirthDate], [EyeColorID], [HairColorID], [Confirmation], [ContractAcceptance]) VALUES (36, N'şazi123', N'123', N'sazi@gmail.com', NULL, NULL, N'/Areas/Assets/ModelImg/women.png', 0, 2, N'şaziye123', N'güzel123', N'asdad123123', 2, NULL, 0, 0, 2, 1, CAST(N'0001-01-01' AS Date), 1, 2, 0, 1)
INSERT [dbo].[Employee] ([ID], [UserName], [Password], [Email], [BankName], [IBAN], [ImageURL], [IsActive], [GenderID], [FirstName], [LastName], [NickName], [StatusID], [About], [Length], [Weight], [HairTypeID], [BodyTypeID], [BirthDate], [EyeColorID], [HairColorID], [Confirmation], [ContractAcceptance]) VALUES (39, N'deneme1b', N'123', N'fbaltaci.34332@gmail.com', NULL, NULL, N'/Areas/Assets/ModelImg/women.png', 0, 2, N'asdasdasdadsa', N'asdasdasdasd', N'asdasd', 2, NULL, 0, 0, 1, 1, CAST(N'0001-01-01' AS Date), 1, 2, 0, 1)
INSERT [dbo].[Employee] ([ID], [UserName], [Password], [Email], [BankName], [IBAN], [ImageURL], [IsActive], [GenderID], [FirstName], [LastName], [NickName], [StatusID], [About], [Length], [Weight], [HairTypeID], [BodyTypeID], [BirthDate], [EyeColorID], [HairColorID], [Confirmation], [ContractAcceptance]) VALUES (40, N'deneme1c', N'123', N'fbaltaci.22234@gmail.com', NULL, NULL, N'/Areas/Assets/ModelImg/women.png', 0, 2, N'adewq', N'sadwqe', N'ASDSADFD', 2, NULL, 0, 0, 1, 1, CAST(N'0001-01-01' AS Date), 1, 1, 0, 1)
INSERT [dbo].[Employee] ([ID], [UserName], [Password], [Email], [BankName], [IBAN], [ImageURL], [IsActive], [GenderID], [FirstName], [LastName], [NickName], [StatusID], [About], [Length], [Weight], [HairTypeID], [BodyTypeID], [BirthDate], [EyeColorID], [HairColorID], [Confirmation], [ContractAcceptance]) VALUES (41, N'Hande2', N'123123', N'sazi22@gmail.com', NULL, NULL, N'/Areas/Assets/ModelImg/women.png', 1, 2, N'Aksu', N'Aksu', N'hnde', 2, NULL, 0, 0, 1, 1, CAST(N'0001-01-01' AS Date), 1, 1, 0, 1)
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[EyeColors] ON 

INSERT [dbo].[EyeColors] ([ID], [ColorName]) VALUES (1, N'Mavi')
INSERT [dbo].[EyeColors] ([ID], [ColorName]) VALUES (2, N'Yeşil')
INSERT [dbo].[EyeColors] ([ID], [ColorName]) VALUES (3, N'Kahverengi')
INSERT [dbo].[EyeColors] ([ID], [ColorName]) VALUES (4, N'Siyah')
SET IDENTITY_INSERT [dbo].[EyeColors] OFF
SET IDENTITY_INSERT [dbo].[Favorites] ON 

INSERT [dbo].[Favorites] ([ID], [CustomerID], [EmployeeID]) VALUES (106, 12, 3)
INSERT [dbo].[Favorites] ([ID], [CustomerID], [EmployeeID]) VALUES (107, 12, 8)
INSERT [dbo].[Favorites] ([ID], [CustomerID], [EmployeeID]) VALUES (108, 14, 3)
SET IDENTITY_INSERT [dbo].[Favorites] OFF
SET IDENTITY_INSERT [dbo].[Gender] ON 

INSERT [dbo].[Gender] ([ID], [GenderType]) VALUES (1, N'Erkek ')
INSERT [dbo].[Gender] ([ID], [GenderType]) VALUES (2, N'Kadın')
INSERT [dbo].[Gender] ([ID], [GenderType]) VALUES (3, N'Diğer')
SET IDENTITY_INSERT [dbo].[Gender] OFF
SET IDENTITY_INSERT [dbo].[GenderChoice] ON 

INSERT [dbo].[GenderChoice] ([ID], [GenChoice]) VALUES (1, N'GenChoice1')
INSERT [dbo].[GenderChoice] ([ID], [GenChoice]) VALUES (2, N'GenChoice2')
SET IDENTITY_INSERT [dbo].[GenderChoice] OFF
SET IDENTITY_INSERT [dbo].[HairColors] ON 

INSERT [dbo].[HairColors] ([ID], [ColorName]) VALUES (1, N'Sarı')
INSERT [dbo].[HairColors] ([ID], [ColorName]) VALUES (2, N'Kahverengi')
INSERT [dbo].[HairColors] ([ID], [ColorName]) VALUES (3, N'Siyah')
INSERT [dbo].[HairColors] ([ID], [ColorName]) VALUES (4, N'Mavi')
INSERT [dbo].[HairColors] ([ID], [ColorName]) VALUES (5, N'Kızıl')
INSERT [dbo].[HairColors] ([ID], [ColorName]) VALUES (6, N'Turuncu')
SET IDENTITY_INSERT [dbo].[HairColors] OFF
SET IDENTITY_INSERT [dbo].[HairTypes] ON 

INSERT [dbo].[HairTypes] ([ID], [HairType]) VALUES (1, N'Kıvırcık')
INSERT [dbo].[HairTypes] ([ID], [HairType]) VALUES (2, N'Düz')
INSERT [dbo].[HairTypes] ([ID], [HairType]) VALUES (3, N'Dalgalı')
SET IDENTITY_INSERT [dbo].[HairTypes] OFF
SET IDENTITY_INSERT [dbo].[MessageCusAdmin] ON 

INSERT [dbo].[MessageCusAdmin] ([ID], [AdminID], [CusID], [Message], [Viewed], [SendDate], [About]) VALUES (1, 1, 5, N'sdfsdfds', 1, CAST(N'2020-01-02 00:00:00.000' AS DateTime), N'Ödeme İşlemi')
INSERT [dbo].[MessageCusAdmin] ([ID], [AdminID], [CusID], [Message], [Viewed], [SendDate], [About]) VALUES (2, 1, 5, N'Merhaba Santiago', 1, CAST(N'2020-01-02 00:00:00.000' AS DateTime), N'Ödeme İşlemi')
INSERT [dbo].[MessageCusAdmin] ([ID], [AdminID], [CusID], [Message], [Viewed], [SendDate], [About]) VALUES (3, 1, 5, N'asdadasda', 1, CAST(N'2020-01-02 00:00:00.000' AS DateTime), N'Ödeme İşlemi')
INSERT [dbo].[MessageCusAdmin] ([ID], [AdminID], [CusID], [Message], [Viewed], [SendDate], [About]) VALUES (4, 1, 5, N'deneme mesajı', 0, CAST(N'2020-10-06 00:00:00.000' AS DateTime), N'Ödeme Hk.')
INSERT [dbo].[MessageCusAdmin] ([ID], [AdminID], [CusID], [Message], [Viewed], [SendDate], [About]) VALUES (5, 1, 4, N'deneme mesajı 5', 0, CAST(N'2020-10-06 00:00:00.000' AS DateTime), N'Ödeme Hk.')
INSERT [dbo].[MessageCusAdmin] ([ID], [AdminID], [CusID], [Message], [Viewed], [SendDate], [About]) VALUES (6, 1, 4, N'Toplu Mesajdır', 0, CAST(N'2020-10-06 00:00:00.000' AS DateTime), N'İşleyiş Hk')
INSERT [dbo].[MessageCusAdmin] ([ID], [AdminID], [CusID], [Message], [Viewed], [SendDate], [About]) VALUES (7, 1, 5, N'Toplu Mesajdır', 1, CAST(N'2020-10-06 00:00:00.000' AS DateTime), N'İşleyiş Hk')
INSERT [dbo].[MessageCusAdmin] ([ID], [AdminID], [CusID], [Message], [Viewed], [SendDate], [About]) VALUES (8, 1, 6, N'Toplu Mesajdır', 0, CAST(N'2020-10-06 00:00:00.000' AS DateTime), N'İşleyiş Hk')
INSERT [dbo].[MessageCusAdmin] ([ID], [AdminID], [CusID], [Message], [Viewed], [SendDate], [About]) VALUES (9, 1, 7, N'Toplu Mesajdır', 0, CAST(N'2020-10-06 00:00:00.000' AS DateTime), N'İşleyiş Hk')
INSERT [dbo].[MessageCusAdmin] ([ID], [AdminID], [CusID], [Message], [Viewed], [SendDate], [About]) VALUES (10, 1, 11, N'Toplu Mesajdır', 0, CAST(N'2020-10-06 00:00:00.000' AS DateTime), N'İşleyiş Hk')
INSERT [dbo].[MessageCusAdmin] ([ID], [AdminID], [CusID], [Message], [Viewed], [SendDate], [About]) VALUES (11, 1, 4, N'Deneme', 0, CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Kontrol Deneme')
INSERT [dbo].[MessageCusAdmin] ([ID], [AdminID], [CusID], [Message], [Viewed], [SendDate], [About]) VALUES (12, 1, 5, N'Deneme', 1, CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Kontrol Deneme')
INSERT [dbo].[MessageCusAdmin] ([ID], [AdminID], [CusID], [Message], [Viewed], [SendDate], [About]) VALUES (13, 1, 6, N'Deneme', 0, CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Kontrol Deneme')
INSERT [dbo].[MessageCusAdmin] ([ID], [AdminID], [CusID], [Message], [Viewed], [SendDate], [About]) VALUES (14, 1, 7, N'Deneme', 0, CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Kontrol Deneme')
INSERT [dbo].[MessageCusAdmin] ([ID], [AdminID], [CusID], [Message], [Viewed], [SendDate], [About]) VALUES (15, 1, 11, N'Deneme', 0, CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Kontrol Deneme')
INSERT [dbo].[MessageCusAdmin] ([ID], [AdminID], [CusID], [Message], [Viewed], [SendDate], [About]) VALUES (16, 1, 12, N'Deneme', 0, CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Kontrol Deneme')
INSERT [dbo].[MessageCusAdmin] ([ID], [AdminID], [CusID], [Message], [Viewed], [SendDate], [About]) VALUES (17, 1, 13, N'Deneme', 0, CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Kontrol Deneme')
INSERT [dbo].[MessageCusAdmin] ([ID], [AdminID], [CusID], [Message], [Viewed], [SendDate], [About]) VALUES (18, 1, 14, N'Deneme', 0, CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Kontrol Deneme')
SET IDENTITY_INSERT [dbo].[MessageCusAdmin] OFF
SET IDENTITY_INSERT [dbo].[MessageEmpAdmin] ON 

INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (1, 1, 3, N'Merhaba Sibel Hanım', 1, CAST(N'2020-01-02 00:00:00.000' AS DateTime), N'Ödeme')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (2, 1, 3, N'Merhaba Sibel Hanım', 1, CAST(N'2020-01-02 00:00:00.000' AS DateTime), N'Ödeme İşlemi')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (3, 1, 3, N'Merhaba Sibel HanımMerhaba Sibel HanımMerhaba Sibel HanımMerhaba Sibel HanımMerhaba Sibel HanımMerhaba Sibel HanımMerhaba Sibel HanımMerhaba Sibel HanımMerhaba Sibel HanımMerhaba Sibel HanımMerhaba Sibel HanımMerhaba Sibel HanımMerhaba Sibel HanımMerhaba Sibel HanımMerhaba Sibel HanımMerhaba Sibel Hanım', 1, CAST(N'2020-01-02 00:00:00.000' AS DateTime), N'Gönderilen Mail')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (4, 1, 13, N'Ödemeniz alınmıştır', 0, CAST(N'2020-10-06 00:00:00.000' AS DateTime), N'Ödeme Hk.')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (5, 1, 3, N'Toplu Mesajdır', 0, CAST(N'2020-10-06 00:00:00.000' AS DateTime), N'İşleyiş Hk')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (6, 1, 8, N'Toplu Mesajdır', 0, CAST(N'2020-10-06 00:00:00.000' AS DateTime), N'İşleyiş Hk')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (7, 1, 9, N'Toplu Mesajdır', 0, CAST(N'2020-10-06 00:00:00.000' AS DateTime), N'İşleyiş Hk')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (8, 1, 10, N'Toplu Mesajdır', 0, CAST(N'2020-10-06 00:00:00.000' AS DateTime), N'İşleyiş Hk')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (9, 1, 11, N'Toplu Mesajdır', 0, CAST(N'2020-10-06 00:00:00.000' AS DateTime), N'İşleyiş Hk')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (10, 1, 12, N'Toplu Mesajdır', 0, CAST(N'2020-10-06 00:00:00.000' AS DateTime), N'İşleyiş Hk')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (11, 1, 13, N'Toplu Mesajdır', 0, CAST(N'2020-10-06 00:00:00.000' AS DateTime), N'İşleyiş Hk')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (12, 1, 14, N'Toplu Mesajdır', 0, CAST(N'2020-10-06 00:00:00.000' AS DateTime), N'İşleyiş Hk')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (13, 1, 15, N'Toplu Mesajdır', 0, CAST(N'2020-10-06 00:00:00.000' AS DateTime), N'İşleyiş Hk')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (14, 1, 23, N'Toplu Mesajdır', 0, CAST(N'2020-10-06 00:00:00.000' AS DateTime), N'İşleyiş Hk')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (15, 1, 3, N'Deneme', 0, CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Kontrol Deneme')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (16, 1, 8, N'Deneme', 0, CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Kontrol Deneme')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (17, 1, 9, N'Deneme', 0, CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Kontrol Deneme')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (18, 1, 10, N'Deneme', 0, CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Kontrol Deneme')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (19, 1, 11, N'Deneme', 0, CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Kontrol Deneme')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (20, 1, 12, N'Deneme', 0, CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Kontrol Deneme')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (21, 1, 13, N'Deneme', 0, CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Kontrol Deneme')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (22, 1, 14, N'Deneme', 0, CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Kontrol Deneme')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (23, 1, 15, N'Deneme', 0, CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Kontrol Deneme')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (24, 1, 23, N'Deneme', 0, CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Kontrol Deneme')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (25, 1, 24, N'Deneme', 0, CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Kontrol Deneme')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (26, 1, 32, N'Deneme', 0, CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Kontrol Deneme')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (27, 1, 36, N'Deneme', 0, CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Kontrol Deneme')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (28, 1, 39, N'Deneme', 0, CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Kontrol Deneme')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (29, 1, 40, N'Deneme', 0, CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Kontrol Deneme')
INSERT [dbo].[MessageEmpAdmin] ([ID], [AdminID], [EmpID], [Message], [Viewed], [SendDate], [About]) VALUES (30, 1, 41, N'Deneme', 0, CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Kontrol Deneme')
SET IDENTITY_INSERT [dbo].[MessageEmpAdmin] OFF
SET IDENTITY_INSERT [dbo].[Messages] ON 

INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (405, N'selam&nbsp;<div><br></div>', CAST(N'2020-11-03 13:01:52.963' AS DateTime), 5, 3)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (406, N'nasılsınız<div><br></div>', CAST(N'2020-11-03 14:39:28.270' AS DateTime), 5, 3)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (407, N'iyiyim sizler<div><br></div>', CAST(N'2020-11-03 14:39:38.473' AS DateTime), 3, 5)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (408, N'iyiyim bende<div><br></div>', CAST(N'2020-11-03 14:39:49.217' AS DateTime), 5, 3)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (409, N'nasıl gidiyor ?&nbsp;<div><br></div>', CAST(N'2020-11-03 14:39:55.857' AS DateTime), 3, 5)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (410, N'asd<div><br></div>', CAST(N'2020-11-03 17:41:52.113' AS DateTime), 3, 5)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (411, N'asd<div><br></div>', CAST(N'2020-11-03 17:41:56.310' AS DateTime), 3, 5)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (412, N'asd<div><br></div>', CAST(N'2020-11-03 18:03:13.330' AS DateTime), 3, 5)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (413, N'eee<div><br></div>', CAST(N'2020-11-03 18:03:18.417' AS DateTime), 3, 5)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (414, N'selam<div><br></div>', CAST(N'2020-11-03 18:03:28.037' AS DateTime), 5, 3)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (415, N'selam<div><br></div>', CAST(N'2020-11-03 18:03:31.210' AS DateTime), 3, 5)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (416, N'iyimsiin&nbsp; ?<div><br></div>', CAST(N'2020-11-03 18:03:40.337' AS DateTime), 3, 5)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (417, N'evet neden<div><br></div>', CAST(N'2020-11-03 18:03:44.580' AS DateTime), 5, 3)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (418, N'&nbsp;?<div><br></div>', CAST(N'2020-11-03 18:03:45.687' AS DateTime), 5, 3)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (419, N'<img src="https://twemoji.maxcdn.com/2/72x72/1f53d.png">&nbsp;mod&nbsp;<div><br></div>', CAST(N'2020-11-03 18:03:52.510' AS DateTime), 3, 5)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (420, N':)) yok yok&nbsp;<div><br></div>', CAST(N'2020-11-03 18:03:57.820' AS DateTime), 5, 3)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (421, N'nasıl<div><br></div>', CAST(N'2020-11-03 18:04:11.470' AS DateTime), 5, 3)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (422, N'evet<div><br></div>', CAST(N'2020-11-03 18:04:20.557' AS DateTime), 3, 5)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (423, N'selam<div><br></div>', CAST(N'2020-11-03 18:07:44.537' AS DateTime), 3, 4)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (424, N'selam<div><br></div>', CAST(N'2020-11-03 18:07:49.390' AS DateTime), 4, 3)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (425, N'naber&nbsp;<div><br></div>', CAST(N'2020-11-03 18:08:30.520' AS DateTime), 5, 3)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (426, N'iyidir&nbsp;<div><br></div>', CAST(N'2020-11-03 18:08:39.573' AS DateTime), 3, 5)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (427, N'ne var ne yok&nbsp;<div><br></div>', CAST(N'2020-11-03 18:08:49.593' AS DateTime), 5, 3)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (428, N'iyidir<div><br></div>', CAST(N'2020-11-03 18:08:54.200' AS DateTime), 3, 5)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (429, N'öyle tamam<div><br></div>', CAST(N'2020-11-03 18:09:04.103' AS DateTime), 4, 3)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (430, N'görüşürüz<div><br></div>', CAST(N'2020-11-03 18:09:10.000' AS DateTime), 3, 4)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (431, N'görüşürüz<div><br></div>', CAST(N'2020-11-03 18:09:21.380' AS DateTime), 4, 3)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (432, N'selam<div><br></div>', CAST(N'2020-11-04 12:07:18.117' AS DateTime), 3, 6)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (433, N'selam<div><br></div>', CAST(N'2020-11-04 12:15:20.743' AS DateTime), 3, 6)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (434, N'selam3', CAST(N'2020-11-04 12:15:24.043' AS DateTime), 3, 6)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (435, N'kredin bitmiş&nbsp;<div><br></div>', CAST(N'2020-11-04 12:16:03.060' AS DateTime), 3, 5)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (436, N'evet<div><br></div>', CAST(N'2020-11-04 12:16:10.953' AS DateTime), 5, 3)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (437, N'selam bu arada', CAST(N'2020-11-04 12:16:19.100' AS DateTime), 5, 3)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (438, N'selam', CAST(N'2020-11-04 12:16:23.423' AS DateTime), 3, 5)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (439, N'<img src="https://twemoji.maxcdn.com/2/72x72/1f620.png"><div><br></div>', CAST(N'2020-11-04 12:16:31.293' AS DateTime), 3, 5)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (440, N':))<div><br></div>', CAST(N'2020-11-04 12:16:37.480' AS DateTime), 5, 3)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (441, N'selam<div><br></div>', CAST(N'2020-11-04 16:33:59.540' AS DateTime), 5, 8)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (442, N'selam<div><br></div>', CAST(N'2020-11-04 16:34:33.713' AS DateTime), 3, 5)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (443, N'selam<div><br></div>', CAST(N'2020-11-04 16:34:46.277' AS DateTime), 5, 8)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (444, N'asd<div><br></div>', CAST(N'2020-11-04 16:34:55.850' AS DateTime), 5, 8)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (445, N'hey<div><br></div>', CAST(N'2020-11-04 16:35:10.963' AS DateTime), 5, 8)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (446, N'hey<div><br></div>', CAST(N'2020-11-04 16:35:14.597' AS DateTime), 3, 5)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (447, N'asdad<div><br></div>', CAST(N'2020-11-04 16:35:18.037' AS DateTime), 5, 8)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (448, N'asdsad<div><br></div>', CAST(N'2020-11-04 16:35:29.637' AS DateTime), 5, 8)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (449, N'asdsad<div><br></div>', CAST(N'2020-11-04 16:35:37.873' AS DateTime), 3, 5)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (450, N'asd<div><br></div>', CAST(N'2020-11-04 16:35:46.530' AS DateTime), 5, 8)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (451, N'asdasd<div><br></div>', CAST(N'2020-11-04 16:35:57.763' AS DateTime), 3, 5)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (452, N'asdasd<div><br></div>', CAST(N'2020-11-04 16:36:01.117' AS DateTime), 5, 8)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (453, N'asd', CAST(N'2020-11-04 16:36:43.790' AS DateTime), 5, 8)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (454, N'dasdad', CAST(N'2020-11-04 16:36:55.963' AS DateTime), 5, 8)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (455, N'selam<div><br></div>', CAST(N'2020-11-04 16:38:33.570' AS DateTime), 5, 3)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (456, N'bağlantı sorunu oldu&nbsp;<div><br></div>', CAST(N'2020-11-04 16:38:47.600' AS DateTime), 3, 5)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (457, N'evet<div><br></div>', CAST(N'2020-11-04 16:38:57.483' AS DateTime), 5, 3)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (458, N':))<div><br></div>', CAST(N'2020-11-04 16:39:02.493' AS DateTime), 3, 5)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (459, N'merhaba<div><br></div>', CAST(N'2020-11-04 16:39:41.083' AS DateTime), 5, 3)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (460, N'merhaba<div><br></div>', CAST(N'2020-11-04 16:39:56.120' AS DateTime), 3, 5)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (461, N'hey<div><br></div>', CAST(N'2020-11-04 16:40:04.433' AS DateTime), 5, 3)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (1404, N'hey&nbsp;<div><br></div>', CAST(N'2020-12-11 18:19:13.547' AS DateTime), 3, 5)
INSERT [dbo].[Messages] ([ID], [Message], [CreatedDate], [SenderID], [ReceiverID]) VALUES (1405, N'selam&nbsp;<div><br></div>', CAST(N'2020-12-11 18:19:26.690' AS DateTime), 5, 3)
SET IDENTITY_INSERT [dbo].[Messages] OFF
SET IDENTITY_INSERT [dbo].[PayChart] ON 

INSERT [dbo].[PayChart] ([ID], [AdminID], [EmployeeID], [Quantity], [CreatedDate], [PayImg]) VALUES (1, 1, 8, 200, CAST(N'2020-09-15 00:00:00.000' AS DateTime), N'/Areas/Assets/Custom/PayImages/unnamed.jpg')
INSERT [dbo].[PayChart] ([ID], [AdminID], [EmployeeID], [Quantity], [CreatedDate], [PayImg]) VALUES (2, 2, 8, 426.7, CAST(N'2020-09-15 00:00:00.000' AS DateTime), N'/Areas/Assets/Custom/PayImages/unnamed.jpg')
INSERT [dbo].[PayChart] ([ID], [AdminID], [EmployeeID], [Quantity], [CreatedDate], [PayImg]) VALUES (3, 1, 3, 230, CAST(N'2020-10-20 00:00:00.000' AS DateTime), N'http://localhost:53176/Assets/Custom/DecImages/8dc35ae7-a957-4821-ba86-a42806823fd0.jpg')
INSERT [dbo].[PayChart] ([ID], [AdminID], [EmployeeID], [Quantity], [CreatedDate], [PayImg]) VALUES (4, 1, 3, 350, CAST(N'2020-10-20 00:00:00.000' AS DateTime), N'http://localhost:53176/Assets/Custom/DecImages/19fcc97c-0703-46ad-83d8-d11e21df9fd9.jpg')
INSERT [dbo].[PayChart] ([ID], [AdminID], [EmployeeID], [Quantity], [CreatedDate], [PayImg]) VALUES (5, 1, 3, 200, CAST(N'2020-10-21 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[PayChart] ([ID], [AdminID], [EmployeeID], [Quantity], [CreatedDate], [PayImg]) VALUES (6, 1, 11, 20, CAST(N'2020-10-21 00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[PayChart] OFF
SET IDENTITY_INSERT [dbo].[Payment] ON 

INSERT [dbo].[Payment] ([Id], [CustomerId], [OrderId], [PaymentDate], [Price], [Status]) VALUES (1, 5, N'8759e054-dd33-492a-bffd-5b699c758e1f', CAST(N'2020-12-09 13:03:12.950' AS DateTime), CAST(50 AS Decimal(18, 0)), 0)
INSERT [dbo].[Payment] ([Id], [CustomerId], [OrderId], [PaymentDate], [Price], [Status]) VALUES (2, 5, N'f0686524-fc35-42ab-a824-4dce993fb651', CAST(N'2020-12-09 13:57:47.383' AS DateTime), CAST(50 AS Decimal(18, 0)), 0)
INSERT [dbo].[Payment] ([Id], [CustomerId], [OrderId], [PaymentDate], [Price], [Status]) VALUES (3, 5, N'a85c619f-a0e9-4816-b032-48da1839da76', CAST(N'2020-12-09 13:59:58.263' AS DateTime), CAST(50 AS Decimal(18, 0)), 0)
INSERT [dbo].[Payment] ([Id], [CustomerId], [OrderId], [PaymentDate], [Price], [Status]) VALUES (4, 5, N'0d656c4a-2dd4-45be-8156-52d5f1a23798', CAST(N'2020-12-09 14:02:15.373' AS DateTime), CAST(50 AS Decimal(18, 0)), 0)
INSERT [dbo].[Payment] ([Id], [CustomerId], [OrderId], [PaymentDate], [Price], [Status]) VALUES (5, 5, N'4acb6501-061d-4755-a8b5-f5aa2952950b', CAST(N'2020-12-09 14:21:54.257' AS DateTime), CAST(50 AS Decimal(18, 0)), 0)
INSERT [dbo].[Payment] ([Id], [CustomerId], [OrderId], [PaymentDate], [Price], [Status]) VALUES (6, 5, N'64b86aab-4c1f-4fb2-9f6a-f1fe2289bfa0', CAST(N'2020-12-09 14:24:26.353' AS DateTime), CAST(50 AS Decimal(18, 0)), 0)
INSERT [dbo].[Payment] ([Id], [CustomerId], [OrderId], [PaymentDate], [Price], [Status]) VALUES (7, 5, N'29bcd121-a9f6-4adb-92c3-c0709a68d866', CAST(N'2020-12-09 14:27:45.920' AS DateTime), CAST(50 AS Decimal(18, 0)), 0)
INSERT [dbo].[Payment] ([Id], [CustomerId], [OrderId], [PaymentDate], [Price], [Status]) VALUES (8, 5, N'47d912dd-f847-4a07-8524-c1d8a5de3b71', CAST(N'2020-12-09 14:48:25.657' AS DateTime), CAST(50 AS Decimal(18, 0)), 0)
INSERT [dbo].[Payment] ([Id], [CustomerId], [OrderId], [PaymentDate], [Price], [Status]) VALUES (9, 5, N'dff28c58-75df-47cf-aa38-5b0000cc47d7', CAST(N'2020-12-09 15:48:01.180' AS DateTime), CAST(50 AS Decimal(18, 0)), 0)
INSERT [dbo].[Payment] ([Id], [CustomerId], [OrderId], [PaymentDate], [Price], [Status]) VALUES (10, 5, N'4bbf1c28-1b60-44ec-8c0c-d21e174276cb', CAST(N'2020-12-09 15:54:18.213' AS DateTime), CAST(50 AS Decimal(18, 0)), 0)
INSERT [dbo].[Payment] ([Id], [CustomerId], [OrderId], [PaymentDate], [Price], [Status]) VALUES (11, 5, N'4c5f8d3b-2d06-4908-bc07-72ccb62473c1', CAST(N'2020-12-09 16:01:47.303' AS DateTime), CAST(50 AS Decimal(18, 0)), 0)
INSERT [dbo].[Payment] ([Id], [CustomerId], [OrderId], [PaymentDate], [Price], [Status]) VALUES (12, 5, N'99943168-3859-4363-acd9-74a3c2be2a1c', CAST(N'2020-12-09 16:04:59.270' AS DateTime), CAST(50 AS Decimal(18, 0)), 0)
INSERT [dbo].[Payment] ([Id], [CustomerId], [OrderId], [PaymentDate], [Price], [Status]) VALUES (13, 5, N'cf349046-9108-4841-a692-4bb99ed1e946', CAST(N'2020-12-09 17:08:14.370' AS DateTime), CAST(110 AS Decimal(18, 0)), 0)
INSERT [dbo].[Payment] ([Id], [CustomerId], [OrderId], [PaymentDate], [Price], [Status]) VALUES (14, 5, N'eb063392-2d99-4062-8ced-97e8704799ae', CAST(N'2020-12-09 17:20:38.567' AS DateTime), CAST(110 AS Decimal(18, 0)), 1)
SET IDENTITY_INSERT [dbo].[Payment] OFF
SET IDENTITY_INSERT [dbo].[PoolBan] ON 

INSERT [dbo].[PoolBan] ([ID], [CustomerID], [EmployeeID]) VALUES (8, 5, 12)
SET IDENTITY_INSERT [dbo].[PoolBan] OFF
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([ID], [StatusName]) VALUES (1, N'Çevrimiçi')
INSERT [dbo].[Status] ([ID], [StatusName]) VALUES (2, N'Çevrimdışı')
INSERT [dbo].[Status] ([ID], [StatusName]) VALUES (3, N'Meşgul')
SET IDENTITY_INSERT [dbo].[Status] OFF
SET IDENTITY_INSERT [dbo].[TimeLine] ON 

INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (7, 5, 3, CAST(N'2020-09-22 15:42:32.517' AS DateTime), CAST(N'2020-09-22 15:42:32.570' AS DateTime), CAST(N'2020-09-22 15:42:32.593' AS DateTime), N'vnTsn1xNcfSsW')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (8, 5, 3, CAST(N'2020-09-22 16:00:35.417' AS DateTime), CAST(N'2020-09-22 16:00:35.417' AS DateTime), CAST(N'2020-09-22 16:00:35.417' AS DateTime), N'HNDBxUG7RCDTv')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (9, 5, 3, CAST(N'2020-09-22 16:00:47.523' AS DateTime), CAST(N'2020-09-22 16:00:47.523' AS DateTime), CAST(N'2020-09-22 16:00:47.523' AS DateTime), N'A3nPoSz4pYSuY')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (10, 5, 3, CAST(N'2020-09-22 16:23:56.573' AS DateTime), CAST(N'2020-09-22 16:23:56.573' AS DateTime), CAST(N'2020-09-22 16:23:56.573' AS DateTime), N'bfUy7r0S670qG')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (11, 5, 3, CAST(N'2020-09-22 16:26:05.170' AS DateTime), CAST(N'2020-09-22 16:26:05.170' AS DateTime), CAST(N'2020-09-22 16:26:05.170' AS DateTime), N'Xcu3rpEGYA6HX')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (12, 5, 3, CAST(N'2020-09-22 16:26:40.547' AS DateTime), CAST(N'2020-09-22 16:26:40.547' AS DateTime), CAST(N'2020-09-22 16:26:40.547' AS DateTime), N'IhF8sPb3h2JKd')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (13, 5, 3, CAST(N'2020-09-22 16:30:01.467' AS DateTime), CAST(N'2020-09-22 16:30:01.467' AS DateTime), CAST(N'2020-09-22 16:30:01.467' AS DateTime), N'MicPeiUnNAEtR')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (14, 5, 3, CAST(N'2020-09-22 16:48:54.213' AS DateTime), CAST(N'2020-09-22 16:48:54.213' AS DateTime), CAST(N'2020-09-22 16:48:54.213' AS DateTime), N'aDRUZkOJykY9e')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (15, 5, 3, CAST(N'2020-09-22 16:51:41.797' AS DateTime), CAST(N'2020-09-22 16:51:41.797' AS DateTime), CAST(N'2020-09-22 16:51:41.797' AS DateTime), N'lkbXs1lZiQosm')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (16, 5, 3, CAST(N'2020-09-22 17:15:42.787' AS DateTime), CAST(N'2020-09-22 17:15:42.787' AS DateTime), CAST(N'2020-09-22 17:15:42.787' AS DateTime), N'hHcEW8T0Zn0ai')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (17, 5, 3, CAST(N'2020-09-22 17:32:12.243' AS DateTime), CAST(N'2020-09-22 17:32:12.247' AS DateTime), CAST(N'2020-09-22 17:32:12.247' AS DateTime), N'qjjU0PRKmKG8n')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (18, 5, 3, CAST(N'2020-09-22 17:43:32.653' AS DateTime), CAST(N'2020-09-22 17:43:32.653' AS DateTime), CAST(N'2020-09-22 17:43:32.653' AS DateTime), N'W11ae7OP2QLdl')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (19, 5, 3, CAST(N'2020-09-22 17:55:02.290' AS DateTime), CAST(N'2020-09-22 17:55:02.290' AS DateTime), CAST(N'2020-09-22 17:55:02.290' AS DateTime), N'jsGzFLdk9XMx3')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (20, 5, 3, CAST(N'2020-09-22 18:06:19.043' AS DateTime), CAST(N'2020-09-22 18:06:19.043' AS DateTime), CAST(N'2020-09-22 18:06:19.043' AS DateTime), N'W3QOcwCZmlvkp')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (21, 5, 3, CAST(N'2020-09-22 18:16:25.520' AS DateTime), CAST(N'2020-09-22 18:16:25.520' AS DateTime), CAST(N'2020-09-22 18:16:25.520' AS DateTime), N'E3PJ6YvEWRJfP')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (22, 5, 3, CAST(N'2020-09-22 18:21:16.057' AS DateTime), CAST(N'2020-09-22 18:21:16.057' AS DateTime), CAST(N'2020-09-22 18:21:16.057' AS DateTime), N'xDy585tq4EJxD')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (23, 5, 3, CAST(N'2020-09-22 18:25:28.307' AS DateTime), CAST(N'2020-09-22 18:25:28.307' AS DateTime), CAST(N'2020-09-22 18:25:28.307' AS DateTime), N'H16mr9mEZbfPy')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (24, 5, 3, CAST(N'2020-09-22 18:40:10.867' AS DateTime), CAST(N'2020-09-22 18:40:10.867' AS DateTime), CAST(N'2020-09-22 18:40:10.867' AS DateTime), N'cPDnFQRl5ysrG')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (25, 5, 3, CAST(N'2020-10-01 15:32:53.320' AS DateTime), CAST(N'2020-10-01 15:32:53.320' AS DateTime), CAST(N'2020-10-01 15:32:53.320' AS DateTime), N'ZOWGNDcCtV8qo')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (26, 5, 3, CAST(N'2020-10-01 15:41:43.987' AS DateTime), CAST(N'2020-10-01 15:41:43.987' AS DateTime), CAST(N'2020-10-01 15:41:43.987' AS DateTime), N'anpcJBbaO17qi')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (27, 5, 3, CAST(N'2020-10-03 20:44:22.543' AS DateTime), CAST(N'2020-10-03 20:44:22.543' AS DateTime), CAST(N'2020-10-03 20:44:22.543' AS DateTime), N'Kf1mHiQR8iYuD')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (28, 5, 3, CAST(N'2020-10-03 20:47:00.893' AS DateTime), CAST(N'2020-10-03 20:47:00.893' AS DateTime), CAST(N'2020-10-03 20:47:00.893' AS DateTime), N'XyndKDjWkbHLR')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (29, 5, 3, CAST(N'2020-10-03 20:49:09.987' AS DateTime), CAST(N'2020-10-03 20:49:09.987' AS DateTime), CAST(N'2020-10-03 20:49:09.987' AS DateTime), N'jLs9GJUwQi39C')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (30, 5, 3, CAST(N'2020-10-03 20:53:48.377' AS DateTime), CAST(N'2020-10-03 20:53:48.377' AS DateTime), CAST(N'2020-10-03 20:53:48.377' AS DateTime), N'dGHvdy04viPNB')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (31, 5, 3, CAST(N'2020-10-03 21:00:30.477' AS DateTime), CAST(N'2020-10-03 21:00:30.477' AS DateTime), CAST(N'2020-10-03 21:00:30.477' AS DateTime), N'rks65Dxxpk84k')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (32, 5, 3, CAST(N'2020-10-05 12:15:59.447' AS DateTime), CAST(N'2020-10-05 12:15:59.447' AS DateTime), CAST(N'2020-10-05 12:15:59.447' AS DateTime), N'3k35Frit9xSrB')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (33, 5, 3, CAST(N'2020-10-05 12:16:26.287' AS DateTime), CAST(N'2020-10-05 12:16:26.287' AS DateTime), CAST(N'2020-10-05 12:16:26.287' AS DateTime), N'Bu9WhDpHFsIle')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (34, 5, 3, CAST(N'2020-10-05 12:16:51.547' AS DateTime), CAST(N'2020-10-05 12:16:51.547' AS DateTime), CAST(N'2020-10-05 12:16:51.547' AS DateTime), N'PRuowuqwVAHap')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (35, 5, 3, CAST(N'2020-10-05 12:17:26.320' AS DateTime), CAST(N'2020-10-05 12:17:26.320' AS DateTime), CAST(N'2020-10-05 12:17:26.320' AS DateTime), N'9RrTc0WWz9goV')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (36, 5, 3, CAST(N'2020-10-05 12:19:04.217' AS DateTime), CAST(N'2020-10-05 12:19:04.217' AS DateTime), CAST(N'2020-10-05 12:19:04.217' AS DateTime), N'hN2Gh5yxhdeKE')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (37, 5, 3, CAST(N'2020-10-05 12:19:15.807' AS DateTime), CAST(N'2020-10-05 12:19:15.807' AS DateTime), CAST(N'2020-10-05 12:19:15.807' AS DateTime), N'45uEoERHpCKpw')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (38, 5, 3, CAST(N'2020-10-05 12:19:36.993' AS DateTime), CAST(N'2020-10-05 12:19:36.993' AS DateTime), CAST(N'2020-10-05 12:19:36.993' AS DateTime), N'lIRAOSYftuXYn')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (39, 5, 3, CAST(N'2020-10-05 12:20:02.763' AS DateTime), CAST(N'2020-10-05 12:20:02.763' AS DateTime), CAST(N'2020-10-05 12:20:02.763' AS DateTime), N'uNuJhuS2we6e3')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (40, 5, 3, CAST(N'2020-10-05 12:20:36.457' AS DateTime), CAST(N'2020-10-05 12:20:36.457' AS DateTime), CAST(N'2020-10-05 12:20:36.457' AS DateTime), N'5fFlluDfyIeZJ')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (41, 5, 3, CAST(N'2020-10-05 12:20:54.973' AS DateTime), CAST(N'2020-10-05 12:20:54.973' AS DateTime), CAST(N'2020-10-05 12:20:54.973' AS DateTime), N'STr2HPhJyuWjr')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (42, 5, 3, CAST(N'2020-10-05 12:21:02.553' AS DateTime), CAST(N'2020-10-05 12:21:02.553' AS DateTime), CAST(N'2020-10-05 12:21:02.553' AS DateTime), N'NIaWt9xwYdySs')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (43, 5, 3, CAST(N'2020-10-05 12:21:09.803' AS DateTime), CAST(N'2020-10-05 12:21:09.803' AS DateTime), CAST(N'2020-10-05 12:21:09.803' AS DateTime), N'Dt1PJnOJk0wo7')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (44, 5, 3, CAST(N'2020-10-05 12:21:19.727' AS DateTime), CAST(N'2020-10-05 12:21:19.727' AS DateTime), CAST(N'2020-10-05 12:21:19.727' AS DateTime), N't94noVMkIkTMc')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (45, 5, 3, CAST(N'2020-10-05 12:21:30.103' AS DateTime), CAST(N'2020-10-05 12:21:30.103' AS DateTime), CAST(N'2020-10-05 12:21:30.103' AS DateTime), N'JqIbxabzLHSwH')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (46, 5, 3, CAST(N'2020-10-05 12:21:40.287' AS DateTime), CAST(N'2020-10-05 12:21:40.287' AS DateTime), CAST(N'2020-10-05 12:21:40.287' AS DateTime), N'8Ei3pOwEYZ8oA')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (47, 5, 3, CAST(N'2020-10-05 12:22:46.597' AS DateTime), CAST(N'2020-10-05 12:22:46.597' AS DateTime), CAST(N'2020-10-05 12:22:46.597' AS DateTime), N'c6tQofnqY9tIj')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (48, 5, 3, CAST(N'2020-10-05 12:23:01.757' AS DateTime), CAST(N'2020-10-05 12:23:01.757' AS DateTime), CAST(N'2020-10-05 12:23:01.757' AS DateTime), N'w2IlJKiPBQTzb')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (49, 5, 3, CAST(N'2020-10-05 12:23:30.213' AS DateTime), CAST(N'2020-10-05 12:23:30.213' AS DateTime), CAST(N'2020-10-05 12:23:30.213' AS DateTime), N'Q1Vy9DdMTaN0I')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (50, 5, 3, CAST(N'2020-10-05 12:26:53.093' AS DateTime), CAST(N'2020-10-05 12:26:53.093' AS DateTime), CAST(N'2020-10-05 12:26:53.093' AS DateTime), N'mbGI2GHuwHlkj')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (51, 5, 3, CAST(N'2020-10-05 12:27:21.747' AS DateTime), CAST(N'2020-10-05 12:27:21.747' AS DateTime), CAST(N'2020-10-05 12:27:21.747' AS DateTime), N'CxhSeI0BvrLg9')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (52, 5, 3, CAST(N'2020-10-06 05:05:00.737' AS DateTime), CAST(N'2020-10-06 05:05:00.737' AS DateTime), CAST(N'2020-10-06 05:05:00.737' AS DateTime), N'oTBXCEcZjpS72')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (53, 5, 3, CAST(N'2020-10-06 05:05:31.610' AS DateTime), CAST(N'2020-10-06 05:05:31.610' AS DateTime), CAST(N'2020-10-06 05:05:31.610' AS DateTime), N'aoNV6808yOJzB')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (54, 5, 3, CAST(N'2020-10-06 05:06:35.223' AS DateTime), CAST(N'2020-10-06 05:06:35.223' AS DateTime), CAST(N'2020-10-06 05:06:35.223' AS DateTime), N'pZfliilfTBuBm')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (55, 5, 3, CAST(N'2020-10-06 05:06:58.683' AS DateTime), CAST(N'2020-10-06 05:06:58.683' AS DateTime), CAST(N'2020-10-06 05:06:58.683' AS DateTime), N'WpZCct6nlEB3k')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (56, 5, 3, CAST(N'2020-10-06 05:08:05.513' AS DateTime), CAST(N'2020-10-06 05:08:05.513' AS DateTime), CAST(N'2020-10-06 05:08:05.513' AS DateTime), N'DlrP9HLLDXgb9')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (57, 5, 3, CAST(N'2020-10-06 05:08:39.610' AS DateTime), CAST(N'2020-10-06 05:08:39.610' AS DateTime), CAST(N'2020-10-06 05:08:39.610' AS DateTime), N'8fPznBkgpd38S')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (58, 5, 3, CAST(N'2020-10-08 11:45:18.760' AS DateTime), CAST(N'2020-10-08 11:45:18.760' AS DateTime), CAST(N'2020-10-08 11:45:18.760' AS DateTime), N'HJqXoLc49CMyU')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (59, 5, 3, CAST(N'2020-10-08 12:57:13.367' AS DateTime), CAST(N'2020-10-08 12:57:13.367' AS DateTime), CAST(N'2020-10-08 12:57:13.367' AS DateTime), N'XG64pbc5Z23dz')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (60, 5, 3, CAST(N'2020-10-08 13:04:11.743' AS DateTime), CAST(N'2020-10-08 13:04:11.743' AS DateTime), CAST(N'2020-10-08 13:04:11.743' AS DateTime), N'vyWrnnpIP9nVt')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (61, 5, 3, CAST(N'2020-10-08 14:32:19.063' AS DateTime), CAST(N'2020-10-08 14:32:19.063' AS DateTime), CAST(N'2020-10-08 14:32:19.063' AS DateTime), N'Mf7lxzNQ2kg8E')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (62, 5, 3, CAST(N'2020-10-09 15:04:38.180' AS DateTime), CAST(N'2020-10-09 15:04:38.180' AS DateTime), CAST(N'2020-10-09 15:04:38.180' AS DateTime), N'7ETAOyAVaXDb6')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (63, 5, 3, CAST(N'2020-10-09 15:39:50.490' AS DateTime), CAST(N'2020-10-09 15:39:50.490' AS DateTime), CAST(N'2020-10-09 15:39:50.490' AS DateTime), N'1LW3ZcTHB0ZV2')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (64, 5, 3, CAST(N'2020-10-09 15:41:38.210' AS DateTime), CAST(N'2020-10-09 15:41:38.210' AS DateTime), CAST(N'2020-10-09 15:41:38.210' AS DateTime), N'rr42h174U3nwZ')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (65, 5, 3, CAST(N'2020-10-09 15:45:55.490' AS DateTime), CAST(N'2020-10-09 15:45:55.490' AS DateTime), CAST(N'2020-10-09 15:45:55.490' AS DateTime), N'r0K6h8TsrM6xB')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (66, 5, 3, CAST(N'2020-10-09 16:10:49.643' AS DateTime), CAST(N'2020-10-09 16:10:49.643' AS DateTime), CAST(N'2020-10-09 16:10:49.643' AS DateTime), N'7gNVw9MV7Ky3m')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (67, 5, 3, CAST(N'2020-10-09 16:16:11.377' AS DateTime), CAST(N'2020-10-09 16:16:11.377' AS DateTime), CAST(N'2020-10-09 16:16:11.377' AS DateTime), N'ad5xagU93eobA')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (68, 5, 3, CAST(N'2020-10-09 16:21:56.867' AS DateTime), CAST(N'2020-10-09 16:21:56.867' AS DateTime), CAST(N'2020-10-09 16:21:56.867' AS DateTime), N'8ibnlnmzvVXsw')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (69, 5, 3, CAST(N'2020-10-12 10:51:24.693' AS DateTime), CAST(N'2020-10-12 10:51:24.693' AS DateTime), CAST(N'2020-10-12 10:51:24.693' AS DateTime), N'Oso0wRKptOJ2i')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (70, 5, 3, CAST(N'2020-10-12 11:27:23.783' AS DateTime), CAST(N'2020-10-12 11:27:23.787' AS DateTime), CAST(N'2020-10-12 11:27:23.787' AS DateTime), N'ZCSDKzwfFsla5')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (71, 5, 3, CAST(N'2020-10-12 11:41:43.493' AS DateTime), CAST(N'2020-10-12 11:41:43.493' AS DateTime), CAST(N'2020-10-12 11:41:43.493' AS DateTime), N'y2Bmys7AAqk0g')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (72, 5, 3, CAST(N'2020-10-12 11:46:35.140' AS DateTime), CAST(N'2020-10-12 11:46:35.140' AS DateTime), CAST(N'2020-10-12 11:46:35.140' AS DateTime), N'Ny6NlgmNWA2Xq')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (73, 5, 3, CAST(N'2020-10-12 12:14:09.847' AS DateTime), CAST(N'2020-10-12 12:14:09.847' AS DateTime), CAST(N'2020-10-12 12:14:09.847' AS DateTime), N'h5tMqtEEh7AIi')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (74, 5, 3, CAST(N'2020-10-12 12:16:59.057' AS DateTime), CAST(N'2020-10-12 12:16:59.057' AS DateTime), CAST(N'2020-10-12 12:16:59.057' AS DateTime), N'Bg67lppnDO4fg')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (75, 5, 3, CAST(N'2020-10-12 12:23:54.677' AS DateTime), CAST(N'2020-10-12 12:23:54.677' AS DateTime), CAST(N'2020-10-12 12:23:54.677' AS DateTime), N'xh92griNqf3Ai')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (76, 5, 3, CAST(N'2020-10-12 13:01:44.073' AS DateTime), CAST(N'2020-10-12 13:01:44.073' AS DateTime), CAST(N'2020-10-12 13:01:44.073' AS DateTime), N'5OflgDsWzS7Ps')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (77, 5, 3, CAST(N'2020-10-12 13:32:56.333' AS DateTime), CAST(N'2020-10-12 13:32:56.333' AS DateTime), CAST(N'2020-10-12 13:32:56.333' AS DateTime), N'IUigxPJ1yq5Bg')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (78, 5, 3, CAST(N'2020-10-12 14:21:41.287' AS DateTime), CAST(N'2020-10-12 14:21:41.287' AS DateTime), CAST(N'2020-10-12 14:21:41.287' AS DateTime), N'0vnhoTgVLmtZq')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (79, 5, 3, CAST(N'2020-10-12 14:53:45.913' AS DateTime), CAST(N'2020-10-12 14:53:45.913' AS DateTime), CAST(N'2020-10-12 14:53:45.913' AS DateTime), N'gMrzvDRXMDoEC')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (80, 5, 3, CAST(N'2020-10-12 15:22:33.820' AS DateTime), CAST(N'2020-10-12 15:22:33.820' AS DateTime), CAST(N'2020-10-12 15:22:33.820' AS DateTime), N'FRR7vF2u4VEKp')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (81, 5, 3, CAST(N'2020-10-12 15:32:43.087' AS DateTime), CAST(N'2020-10-12 15:32:43.087' AS DateTime), CAST(N'2020-10-12 15:32:43.087' AS DateTime), N'6zpEr2egeEUK8')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (82, 5, 3, CAST(N'2020-10-12 15:37:55.343' AS DateTime), CAST(N'2020-10-12 15:37:55.343' AS DateTime), CAST(N'2020-10-12 15:37:55.343' AS DateTime), N'RpXNllauUfl9o')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (83, 5, 3, CAST(N'2020-10-12 16:11:53.640' AS DateTime), CAST(N'2020-10-12 16:11:53.640' AS DateTime), CAST(N'2020-10-12 16:11:53.640' AS DateTime), N'xvKiSNh94t6sX')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (84, 5, 3, CAST(N'2020-10-12 16:49:54.727' AS DateTime), CAST(N'2020-10-12 16:49:54.727' AS DateTime), CAST(N'2020-10-12 16:49:54.727' AS DateTime), N'qn7nVbB4KoxIP')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (85, 5, 3, CAST(N'2020-10-12 17:16:15.760' AS DateTime), CAST(N'2020-10-12 17:16:15.760' AS DateTime), CAST(N'2020-10-12 17:16:15.760' AS DateTime), N'JQqPFosDbuoAp')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (86, 5, 3, CAST(N'2020-10-13 11:52:40.377' AS DateTime), CAST(N'2020-10-13 11:52:40.377' AS DateTime), CAST(N'2020-10-13 11:52:40.377' AS DateTime), N'oC2elWE2aELuc')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (87, 5, 3, CAST(N'2020-10-13 12:02:13.660' AS DateTime), CAST(N'2020-10-13 12:02:13.660' AS DateTime), CAST(N'2020-10-13 12:02:13.660' AS DateTime), N'lxt5kHKMY4bvE')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (88, 5, 3, CAST(N'2020-10-13 12:15:12.197' AS DateTime), CAST(N'2020-10-13 12:15:12.197' AS DateTime), CAST(N'2020-10-13 12:15:12.197' AS DateTime), N'XR41K4Bn1eHq1')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (89, 5, 3, CAST(N'2020-10-13 12:34:42.200' AS DateTime), CAST(N'2020-10-13 12:34:42.200' AS DateTime), CAST(N'2020-10-13 12:34:42.200' AS DateTime), N'BcHdgxzTYgWMw')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (90, 5, 3, CAST(N'2020-10-13 12:48:15.397' AS DateTime), CAST(N'2020-10-13 12:48:15.397' AS DateTime), CAST(N'2020-10-13 12:48:15.397' AS DateTime), N'95mYJhnGlIuHT')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (91, 5, 3, CAST(N'2020-10-13 12:51:49.297' AS DateTime), CAST(N'2020-10-13 12:51:49.297' AS DateTime), CAST(N'2020-10-13 12:51:49.297' AS DateTime), N'dgUwxbS3UjN9d')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (92, 5, 3, CAST(N'2020-10-13 12:52:17.617' AS DateTime), CAST(N'2020-10-13 12:52:17.617' AS DateTime), CAST(N'2020-10-13 12:52:17.617' AS DateTime), N'4pteyg3X8Gbia')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (93, 5, 3, CAST(N'2020-10-13 12:52:24.397' AS DateTime), CAST(N'2020-10-13 12:52:24.397' AS DateTime), CAST(N'2020-10-13 12:52:24.397' AS DateTime), N'h7m2xSksPAXlD')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (94, 5, 3, CAST(N'2020-10-13 12:54:01.890' AS DateTime), CAST(N'2020-10-13 12:54:01.890' AS DateTime), CAST(N'2020-10-13 12:54:01.890' AS DateTime), N'4uoLACjlJUpfm')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (95, 5, 3, CAST(N'2020-10-13 12:57:05.940' AS DateTime), CAST(N'2020-10-13 12:57:05.940' AS DateTime), CAST(N'2020-10-13 12:57:05.940' AS DateTime), N'YsaJ5aCLUx95e')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (96, 5, 3, CAST(N'2020-10-13 12:57:32.307' AS DateTime), CAST(N'2020-10-13 12:57:32.307' AS DateTime), CAST(N'2020-10-13 12:57:32.307' AS DateTime), N'bywUDcv0UUhAr')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (97, 5, 3, CAST(N'2020-10-13 12:57:46.430' AS DateTime), CAST(N'2020-10-13 12:57:46.430' AS DateTime), CAST(N'2020-10-13 12:57:46.430' AS DateTime), N'csSL8vfeO6B3i')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (98, 5, 3, CAST(N'2020-10-13 12:57:57.197' AS DateTime), CAST(N'2020-10-13 12:57:57.197' AS DateTime), CAST(N'2020-10-13 12:57:57.197' AS DateTime), N'sK1sq0lYlKeRa')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (99, 5, 3, CAST(N'2020-10-13 13:01:37.523' AS DateTime), CAST(N'2020-10-13 13:01:37.523' AS DateTime), CAST(N'2020-10-13 13:01:37.523' AS DateTime), N'fs35QUTGRwjYT')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (100, 5, 3, CAST(N'2020-10-13 18:41:20.500' AS DateTime), CAST(N'2020-10-13 18:41:20.503' AS DateTime), CAST(N'2020-10-13 18:41:20.507' AS DateTime), N'TEI2iU6qsZRfQ')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (101, 5, 3, CAST(N'2020-10-13 18:46:29.227' AS DateTime), CAST(N'2020-10-13 18:46:29.230' AS DateTime), CAST(N'2020-10-13 18:46:29.230' AS DateTime), N'ljPIrNjlYXcMA')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (102, 5, 3, CAST(N'2020-10-14 12:34:12.300' AS DateTime), CAST(N'2020-10-14 12:34:12.300' AS DateTime), CAST(N'2020-10-14 12:34:12.300' AS DateTime), N'bJ6NtKrELsuI3')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (103, 5, 3, CAST(N'2020-10-14 13:03:22.557' AS DateTime), CAST(N'2020-10-14 13:03:22.557' AS DateTime), CAST(N'2020-10-14 13:03:22.557' AS DateTime), N'TvWZaQY30Gx4q')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (104, 12, 3, CAST(N'2020-10-14 14:42:20.280' AS DateTime), CAST(N'2020-10-14 14:42:20.280' AS DateTime), CAST(N'2020-10-14 14:42:20.280' AS DateTime), N'zr0DoO1IfmAdP')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (105, 12, 3, CAST(N'2020-10-15 14:09:37.673' AS DateTime), CAST(N'2020-10-15 14:09:37.677' AS DateTime), CAST(N'2020-10-15 14:09:37.677' AS DateTime), N'XROaVnRsVDVWI')
GO
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (106, 12, 3, CAST(N'2020-10-15 14:26:57.803' AS DateTime), CAST(N'2020-10-15 14:26:57.803' AS DateTime), CAST(N'2020-10-15 14:26:57.807' AS DateTime), N'RKn0ugBHnxEVB')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (107, 12, 3, CAST(N'2020-10-15 14:44:28.970' AS DateTime), CAST(N'2020-10-15 14:44:28.970' AS DateTime), CAST(N'2020-10-15 14:44:28.970' AS DateTime), N'aZLOh1lD5nTAm')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (108, 14, 3, CAST(N'2020-10-16 10:29:04.520' AS DateTime), CAST(N'2020-10-16 10:29:04.520' AS DateTime), CAST(N'2020-10-16 10:29:04.520' AS DateTime), N'Ync4rVVjFus5b')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (109, 14, 3, CAST(N'2020-10-16 10:32:40.880' AS DateTime), CAST(N'2020-10-16 10:32:40.880' AS DateTime), CAST(N'2020-10-16 10:32:40.880' AS DateTime), N'CPNvRcQwTwWmb')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (110, 14, 3, CAST(N'2020-10-16 10:33:16.267' AS DateTime), CAST(N'2020-10-16 10:33:16.267' AS DateTime), CAST(N'2020-10-16 10:33:16.267' AS DateTime), N'yAMedbAOFzqw0')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (111, 14, 3, CAST(N'2020-10-16 10:49:18.537' AS DateTime), CAST(N'2020-10-16 10:49:18.537' AS DateTime), CAST(N'2020-10-16 10:49:18.537' AS DateTime), N'huTSzxa4kZ4o0')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (112, 14, 3, CAST(N'2020-10-16 11:03:28.080' AS DateTime), CAST(N'2020-10-16 11:03:28.080' AS DateTime), CAST(N'2020-10-16 11:03:28.080' AS DateTime), N'J49VPkfMvKXPi')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (113, 14, 3, CAST(N'2020-10-16 11:06:17.300' AS DateTime), CAST(N'2020-10-16 11:06:17.300' AS DateTime), CAST(N'2020-10-16 11:06:17.300' AS DateTime), N'6FPdJnF6rXa5P')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (114, 14, 3, CAST(N'2020-10-16 11:10:21.853' AS DateTime), CAST(N'2020-10-16 11:10:21.853' AS DateTime), CAST(N'2020-10-16 11:10:21.853' AS DateTime), N'wv3Fx5YqH5HuB')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (115, 14, 3, CAST(N'2020-10-16 11:14:12.753' AS DateTime), CAST(N'2020-10-16 11:14:12.753' AS DateTime), CAST(N'2020-10-16 11:14:12.753' AS DateTime), N'5lZ14y3acmifL')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (116, 14, 3, CAST(N'2020-10-16 11:15:24.430' AS DateTime), CAST(N'2020-10-16 11:15:24.430' AS DateTime), CAST(N'2020-10-16 11:15:24.430' AS DateTime), N'2O9eeAbbVWHBQ')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (117, 5, 3, CAST(N'2020-10-19 12:01:16.607' AS DateTime), CAST(N'2020-10-19 12:01:16.607' AS DateTime), CAST(N'2020-10-19 12:01:16.607' AS DateTime), N'9jNvfwNdDAMhs')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (118, 5, 3, CAST(N'2020-10-20 16:25:54.300' AS DateTime), CAST(N'2020-10-20 16:25:54.300' AS DateTime), CAST(N'2020-10-20 16:25:54.300' AS DateTime), N'eGVzu4S3DiStY')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (119, 5, 3, CAST(N'2020-10-21 16:17:27.540' AS DateTime), CAST(N'2020-10-21 16:17:27.540' AS DateTime), CAST(N'2020-10-21 16:17:27.540' AS DateTime), N'xnh1gtunldXwf')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (120, 5, 3, CAST(N'2020-10-21 16:18:25.787' AS DateTime), CAST(N'2020-10-21 16:18:25.787' AS DateTime), CAST(N'2020-10-21 16:18:25.787' AS DateTime), N'pbmEVyv1hqkop')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (121, 5, 3, CAST(N'2020-10-22 13:30:25.103' AS DateTime), CAST(N'2020-10-22 13:30:25.103' AS DateTime), CAST(N'2020-10-22 13:30:25.103' AS DateTime), N'Qs499fBnCvfaD')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (122, 5, 3, CAST(N'2020-10-28 13:52:47.897' AS DateTime), CAST(N'2020-10-28 13:52:47.897' AS DateTime), CAST(N'2020-10-28 13:52:47.897' AS DateTime), N'wUHs2bFJ1a7ZO')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (123, 5, 3, CAST(N'2020-10-28 14:39:29.643' AS DateTime), CAST(N'2020-10-28 14:39:29.643' AS DateTime), CAST(N'2020-10-28 14:39:29.643' AS DateTime), N'tRgH5OBE3fC9u')
INSERT [dbo].[TimeLine] ([ID], [CustomerID], [EmployeeID], [StartTime], [EndTime], [TotalTime], [Room]) VALUES (124, 5, 3, CAST(N'2020-12-11 18:19:41.783' AS DateTime), CAST(N'2020-12-11 18:19:41.783' AS DateTime), CAST(N'2020-12-11 18:19:41.783' AS DateTime), N'B16uu2q2zZhpI')
SET IDENTITY_INSERT [dbo].[TimeLine] OFF
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Gender] FOREIGN KEY([GenderID])
REFERENCES [dbo].[Gender] ([ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Gender]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_GenderChoice] FOREIGN KEY([GenderChoiceID])
REFERENCES [dbo].[GenderChoice] ([ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_GenderChoice]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Status]
GO
ALTER TABLE [dbo].[CustomerPayment]  WITH CHECK ADD  CONSTRAINT [FK_CustomerPayment_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[CustomerPayment] CHECK CONSTRAINT [FK_CustomerPayment_Customer]
GO
ALTER TABLE [dbo].[CustomerPayment]  WITH CHECK ADD  CONSTRAINT [FK_CustomerPayment_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[CustomerPayment] CHECK CONSTRAINT [FK_CustomerPayment_Employee]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_BodyTypes] FOREIGN KEY([BodyTypeID])
REFERENCES [dbo].[BodyTypes] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_BodyTypes]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_EyeColors] FOREIGN KEY([EyeColorID])
REFERENCES [dbo].[EyeColors] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_EyeColors]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Gender] FOREIGN KEY([GenderID])
REFERENCES [dbo].[Gender] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Gender]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_HairColors] FOREIGN KEY([HairColorID])
REFERENCES [dbo].[HairColors] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_HairColors]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_HairTypes] FOREIGN KEY([HairTypeID])
REFERENCES [dbo].[HairTypes] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_HairTypes]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Status]
GO
ALTER TABLE [dbo].[Favorites]  WITH CHECK ADD  CONSTRAINT [FK_Favorites_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[Favorites] CHECK CONSTRAINT [FK_Favorites_Customer]
GO
ALTER TABLE [dbo].[Favorites]  WITH CHECK ADD  CONSTRAINT [FK_Favorites_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Favorites] CHECK CONSTRAINT [FK_Favorites_Employee]
GO
ALTER TABLE [dbo].[MessageCusAdmin]  WITH CHECK ADD  CONSTRAINT [FK_MessageCusAdmin_AdminUser] FOREIGN KEY([AdminID])
REFERENCES [dbo].[AdminUser] ([ID])
GO
ALTER TABLE [dbo].[MessageCusAdmin] CHECK CONSTRAINT [FK_MessageCusAdmin_AdminUser]
GO
ALTER TABLE [dbo].[MessageCusAdmin]  WITH CHECK ADD  CONSTRAINT [FK_MessageCusAdmin_Customer] FOREIGN KEY([CusID])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[MessageCusAdmin] CHECK CONSTRAINT [FK_MessageCusAdmin_Customer]
GO
ALTER TABLE [dbo].[MessageEmpAdmin]  WITH CHECK ADD  CONSTRAINT [FK_MessageEmpAdmin_AdminUser] FOREIGN KEY([AdminID])
REFERENCES [dbo].[AdminUser] ([ID])
GO
ALTER TABLE [dbo].[MessageEmpAdmin] CHECK CONSTRAINT [FK_MessageEmpAdmin_AdminUser]
GO
ALTER TABLE [dbo].[MessageEmpAdmin]  WITH CHECK ADD  CONSTRAINT [FK_MessageEmpAdmin_Employee] FOREIGN KEY([EmpID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[MessageEmpAdmin] CHECK CONSTRAINT [FK_MessageEmpAdmin_Employee]
GO
ALTER TABLE [dbo].[PayChart]  WITH CHECK ADD  CONSTRAINT [FK_PayChart_AdminUser] FOREIGN KEY([AdminID])
REFERENCES [dbo].[AdminUser] ([ID])
GO
ALTER TABLE [dbo].[PayChart] CHECK CONSTRAINT [FK_PayChart_AdminUser]
GO
ALTER TABLE [dbo].[PayChart]  WITH CHECK ADD  CONSTRAINT [FK_PayChart_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[PayChart] CHECK CONSTRAINT [FK_PayChart_Employee]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Customer]
GO
ALTER TABLE [dbo].[PoolBan]  WITH CHECK ADD  CONSTRAINT [FK_PoolBan_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[PoolBan] CHECK CONSTRAINT [FK_PoolBan_Customer]
GO
ALTER TABLE [dbo].[PoolBan]  WITH CHECK ADD  CONSTRAINT [FK_PoolBan_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[PoolBan] CHECK CONSTRAINT [FK_PoolBan_Employee]
GO
ALTER TABLE [dbo].[TimeLine]  WITH CHECK ADD  CONSTRAINT [FK_TimeLine_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[TimeLine] CHECK CONSTRAINT [FK_TimeLine_Customer]
GO
ALTER TABLE [dbo].[TimeLine]  WITH CHECK ADD  CONSTRAINT [FK_TimeLine_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[TimeLine] CHECK CONSTRAINT [FK_TimeLine_Employee]
GO
USE [master]
GO
ALTER DATABASE [ChatDB] SET  READ_WRITE 
GO
