﻿/*
Deployment script for ExpenseLogger

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ExpenseLogger"
:setvar DefaultFilePrefix "ExpenseLogger"
:setvar DefaultDataPath "C:\Users\Bradley\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB"
:setvar DefaultLogPath "C:\Users\Bradley\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creating [dbo].[Categories]...';


GO
CREATE TABLE [dbo].[Categories] (
    [Id]     INT           IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (50) NOT NULL,
    [UserID] INT           NOT NULL,
    CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Categories].[IX_UserID]...';


GO
CREATE NONCLUSTERED INDEX [IX_UserID]
    ON [dbo].[Categories]([UserID] ASC);


GO
PRINT N'Creating [dbo].[Expenses]...';


GO
CREATE TABLE [dbo].[Expenses] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [CreatedDate]  DATETIME        NOT NULL,
    [CategoryName] NVARCHAR (MAX)  NULL,
    [Amount]       DECIMAL (18, 2) NOT NULL,
    [UserID]       INT             NOT NULL,
    CONSTRAINT [PK_dbo.Expenses] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Expenses].[IX_UserID]...';


GO
CREATE NONCLUSTERED INDEX [IX_UserID]
    ON [dbo].[Expenses]([UserID] ASC);


GO
PRINT N'Creating [dbo].[Settings]...';


GO
CREATE TABLE [dbo].[Settings] (
    [Id]     INT           IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (30) NULL,
    [Value]  NVARCHAR (30) NULL,
    [UserID] INT           NOT NULL,
    CONSTRAINT [PK_dbo.Settings] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Settings].[IX_UserID]...';


GO
CREATE NONCLUSTERED INDEX [IX_UserID]
    ON [dbo].[Settings]([UserID] ASC);


GO
PRINT N'Creating [dbo].[Users]...';


GO
CREATE TABLE [dbo].[Users] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]    NVARCHAR (50)  NOT NULL,
    [LastName]     NVARCHAR (50)  NOT NULL,
    [EmailAddress] NVARCHAR (255) NOT NULL,
    [Gender]       BIT            NOT NULL,
    [Password]     NVARCHAR (100) NULL,
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[FK_dbo.Categories_dbo.Users_UserID]...';


GO
ALTER TABLE [dbo].[Categories]
    ADD CONSTRAINT [FK_dbo.Categories_dbo.Users_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[FK_dbo.Expenses_dbo.Users_UserID]...';


GO
ALTER TABLE [dbo].[Expenses]
    ADD CONSTRAINT [FK_dbo.Expenses_dbo.Users_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([Id]);


GO
PRINT N'Creating [dbo].[FK_dbo.Settings_dbo.Users_UserID]...';


GO
ALTER TABLE [dbo].[Settings]
    ADD CONSTRAINT [FK_dbo.Settings_dbo.Users_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE;


GO
USE [ExpenseLogger]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [EmailAddress], [Gender], [Password]) VALUES (1, N'Admin', N'System', N'admin@gmail.com', 1, N'/fvqx+m2xEpjERwBKgbhow==')
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [UserID]) VALUES (1, N'Meals', 1)
INSERT [dbo].[Categories] ([Id], [Name], [UserID]) VALUES (2, N'Transportation', 1)
INSERT [dbo].[Categories] ([Id], [Name], [UserID]) VALUES (3, N'Housing', 1)
INSERT [dbo].[Categories] ([Id], [Name], [UserID]) VALUES (4, N'Entertainment', 1)
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Expenses] ON 

INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (1, CAST(N'2020-03-15T20:46:46.137' AS DateTime), N'Meals', CAST(10.35 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (2, CAST(N'2020-03-15T20:46:46.137' AS DateTime), N'Meals', CAST(20.20 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (3, CAST(N'2020-03-15T20:46:46.137' AS DateTime), N'Transportation', CAST(170.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (4, CAST(N'2020-03-15T20:46:46.137' AS DateTime), N'Housing', CAST(550.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (5, CAST(N'2020-03-15T20:46:46.137' AS DateTime), N'Entertainment', CAST(30.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (6, CAST(N'2020-03-15T20:21:46.137' AS DateTime), N'Meals', CAST(20.20 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (7, CAST(N'2020-03-15T20:21:46.137' AS DateTime), N'Transportation', CAST(170.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (8, CAST(N'2020-03-15T20:21:46.137' AS DateTime), N'Housing', CAST(550.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (9, CAST(N'2020-03-15T20:21:46.137' AS DateTime), N'Entertainment', CAST(30.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (10, CAST(N'2020-03-15T20:20:46.137' AS DateTime), N'Meals', CAST(15.35 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (11, CAST(N'2020-03-15T20:20:46.137' AS DateTime), N'Meals', CAST(17.35 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (12, CAST(N'2020-03-15T20:20:46.137' AS DateTime), N'Meals', CAST(19.35 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (13, CAST(N'2020-03-15T20:20:46.137' AS DateTime), N'Meals', CAST(21.35 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (14, CAST(N'2020-03-15T20:20:46.137' AS DateTime), N'Meals', CAST(101.35 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (15, CAST(N'2020-03-07T21:23:46.137' AS DateTime), N'Meals', CAST(10.35 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (16, CAST(N'2020-03-07T21:23:46.137' AS DateTime), N'Meals', CAST(40.20 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (17, CAST(N'2020-03-07T21:23:46.137' AS DateTime), N'Transportation', CAST(170.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (18, CAST(N'2020-03-07T21:23:46.137' AS DateTime), N'Entertainment', CAST(30.50 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (19, CAST(N'2020-03-06T21:23:46.137' AS DateTime), N'Meals', CAST(10.35 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (20, CAST(N'2020-03-06T21:23:46.137' AS DateTime), N'Meals', CAST(40.20 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (21, CAST(N'2020-03-06T21:23:46.137' AS DateTime), N'Transportation', CAST(170.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (22, CAST(N'2020-03-06T21:23:46.137' AS DateTime), N'Entertainment', CAST(30.50 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (23, CAST(N'2020-03-05T21:23:46.137' AS DateTime), N'Meals', CAST(10.35 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (24, CAST(N'2020-03-05T21:23:46.137' AS DateTime), N'Meals', CAST(20.20 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (25, CAST(N'2020-03-05T21:23:46.137' AS DateTime), N'Transportation', CAST(170.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (26, CAST(N'2020-03-05T21:23:46.137' AS DateTime), N'Housing', CAST(550.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (27, CAST(N'2020-03-05T21:23:46.137' AS DateTime), N'Entertainment', CAST(30.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (28, CAST(N'2020-02-07T21:23:46.137' AS DateTime), N'Meals', CAST(10.35 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (29, CAST(N'2020-02-07T21:23:46.137' AS DateTime), N'Meals', CAST(20.20 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (30, CAST(N'2020-02-07T21:23:46.137' AS DateTime), N'Transportation', CAST(170.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (31, CAST(N'2020-02-07T21:23:46.137' AS DateTime), N'Housing', CAST(550.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (32, CAST(N'2020-02-07T21:23:46.137' AS DateTime), N'Entertainment', CAST(30.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (33, CAST(N'2020-01-13T21:23:46.137' AS DateTime), N'Meals', CAST(20.20 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (34, CAST(N'2020-01-13T21:23:46.137' AS DateTime), N'Transportation', CAST(170.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (35, CAST(N'2020-01-13T21:23:46.137' AS DateTime), N'Housing', CAST(550.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (36, CAST(N'2020-01-13T21:23:46.137' AS DateTime), N'Entertainment', CAST(30.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (37, CAST(N'2020-01-12T21:23:46.137' AS DateTime), N'Meals', CAST(15.35 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (38, CAST(N'2020-01-12T21:23:46.137' AS DateTime), N'Meals', CAST(17.35 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (39, CAST(N'2020-01-12T21:23:46.137' AS DateTime), N'Meals', CAST(19.35 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (40, CAST(N'2020-01-12T21:23:46.137' AS DateTime), N'Meals', CAST(21.35 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (41, CAST(N'2020-01-12T21:23:46.137' AS DateTime), N'Meals', CAST(101.35 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (42, CAST(N'2019-12-16T21:23:46.137' AS DateTime), N'Meals', CAST(10.35 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (43, CAST(N'2019-12-16T21:23:46.137' AS DateTime), N'Meals', CAST(40.20 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (44, CAST(N'2019-12-16T21:23:46.137' AS DateTime), N'Transportation', CAST(170.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (45, CAST(N'2019-12-16T21:23:46.137' AS DateTime), N'Entertainment', CAST(30.50 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (46, CAST(N'2019-12-16T21:23:46.137' AS DateTime), N'Meals', CAST(10.35 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (47, CAST(N'2019-12-15T21:23:46.137' AS DateTime), N'Meals', CAST(40.20 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (48, CAST(N'2019-12-15T21:23:46.137' AS DateTime), N'Transportation', CAST(170.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (49, CAST(N'2019-12-15T21:23:46.137' AS DateTime), N'Entertainment', CAST(30.50 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (50, CAST(N'2019-12-14T21:23:46.137' AS DateTime), N'Meals', CAST(10.35 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (51, CAST(N'2019-12-14T21:23:46.137' AS DateTime), N'Meals', CAST(20.20 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (52, CAST(N'2019-12-14T21:23:46.137' AS DateTime), N'Transportation', CAST(170.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (53, CAST(N'2019-12-14T21:23:46.137' AS DateTime), N'Meals', CAST(10.35 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (54, CAST(N'2019-12-14T21:23:46.137' AS DateTime), N'Meals', CAST(40.20 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (55, CAST(N'2019-12-14T21:23:46.137' AS DateTime), N'Transportation', CAST(170.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (56, CAST(N'2019-12-14T21:23:46.137' AS DateTime), N'Entertainment', CAST(30.50 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (57, CAST(N'2019-12-14T21:23:46.137' AS DateTime), N'Meals', CAST(10.35 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (58, CAST(N'2019-11-06T21:23:46.137' AS DateTime), N'Meals', CAST(40.20 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (59, CAST(N'2019-11-06T21:23:46.137' AS DateTime), N'Transportation', CAST(170.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (60, CAST(N'2019-11-06T21:23:46.137' AS DateTime), N'Entertainment', CAST(30.50 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (61, CAST(N'2019-11-06T21:23:46.137' AS DateTime), N'Meals', CAST(10.35 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (62, CAST(N'2019-11-05T21:23:46.137' AS DateTime), N'Meals', CAST(40.20 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (63, CAST(N'2019-11-05T21:23:46.137' AS DateTime), N'Transportation', CAST(170.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (64, CAST(N'2019-11-05T21:23:46.137' AS DateTime), N'Entertainment', CAST(30.50 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (65, CAST(N'2019-11-04T21:23:46.137' AS DateTime), N'Meals', CAST(10.35 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (66, CAST(N'2019-11-04T21:23:46.137' AS DateTime), N'Meals', CAST(20.20 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (67, CAST(N'2019-11-04T21:23:46.137' AS DateTime), N'Transportation', CAST(170.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (68, CAST(N'2019-11-04T21:23:46.137' AS DateTime), N'Meals', CAST(10.35 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (69, CAST(N'2019-11-04T21:23:46.137' AS DateTime), N'Meals', CAST(40.20 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (70, CAST(N'2019-11-04T21:23:46.137' AS DateTime), N'Transportation', CAST(170.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (71, CAST(N'2019-11-04T21:23:46.137' AS DateTime), N'Entertainment', CAST(30.50 AS Decimal(18, 2)), 1)
INSERT [dbo].[Expenses] ([Id], [CreatedDate], [CategoryName], [Amount], [UserID]) VALUES (72, CAST(N'2019-11-04T21:23:46.137' AS DateTime), N'Meals', CAST(10.35 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[Expenses] OFF
SET IDENTITY_INSERT [dbo].[Settings] ON 

INSERT [dbo].[Settings] ([Id], [Name], [Value], [UserID]) VALUES (1, N'Currency', N'€', 1)
SET IDENTITY_INSERT [dbo].[Settings] OFF
GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO