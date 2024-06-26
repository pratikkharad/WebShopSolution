USE [master]
GO
/****** Object:  Database [Shop]    Script Date: 01-Apr-24 7:57:25 AM ******/
CREATE DATABASE [Shop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Shop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Shop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Shop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Shop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Shop] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Shop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Shop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Shop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Shop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Shop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Shop] SET ARITHABORT OFF 
GO
ALTER DATABASE [Shop] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Shop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Shop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Shop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Shop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Shop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Shop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Shop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Shop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Shop] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Shop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Shop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Shop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Shop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Shop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Shop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Shop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Shop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Shop] SET  MULTI_USER 
GO
ALTER DATABASE [Shop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Shop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Shop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Shop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Shop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Shop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Shop] SET QUERY_STORE = OFF
GO
USE [Shop]
GO
/****** Object:  Table [dbo].[ErrorLog]    Script Date: 01-Apr-24 7:57:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorLog](
	[ErrorLogID] [int] IDENTITY(1,1) NOT NULL,
	[ProcedureName] [nvarchar](255) NULL,
	[ErrorMessage] [nvarchar](max) NULL,
	[ErrorTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ErrorLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblRole]    Script Date: 01-Apr-24 7:57:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRole](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](20) NOT NULL,
	[IsDeleted] [bit] NULL,
	[IsStatus] [bit] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[UpdatedDate] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 01-Apr-24 7:57:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserGuid] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[NormalizedFirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[NormalizedLastName] [nvarchar](50) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[NormalizedUserName] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NOT NULL,
	[NormalizedEmail] [nvarchar](100) NOT NULL,
	[EmailConfirmed] [bit] NULL,
	[PasswordHash] [nvarchar](max) NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](15) NOT NULL,
	[PhoneNumberConfirmed] [bit] NULL,
	[JwtToken] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NULL,
	[AccessFailedCount] [int] NULL,
	[IsDeleted] [bit] NULL,
	[IsStatus] [bit] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[UpdateDate] [datetime2](7) NULL,
 CONSTRAINT [PK__tblUser__3214EC274DBC1C91] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_tblUser_Email]    Script Date: 01-Apr-24 7:57:26 AM ******/
CREATE NONCLUSTERED INDEX [IX_tblUser_Email] ON [dbo].[tblUser]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblUser] ADD  CONSTRAINT [DF_tblUser_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tblUser] ADD  CONSTRAINT [DF_tblUser_IsStatus]  DEFAULT ((1)) FOR [IsStatus]
GO
ALTER TABLE [dbo].[tblUser] ADD  CONSTRAINT [DF_tblUser_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  StoredProcedure [dbo].[User_EmailVerifyPassword]    Script Date: 01-Apr-24 7:57:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PRATIK KHARAD 
-- Create date: 30-JANUARY-2024
-- Description:	User verification password and email address is valid or not 
-- =============================================
CREATE PROCEDURE [dbo].[User_EmailVerifyPassword]
	@Email  NVARCHAR(100),
	@PasswordHash NVARCHAR(MAX)
AS
BEGIN

	SET NOCOUNT ON;

	BEGIN TRY

		IF EXISTS(
			SELECT 1 FROM tblUser WITH(NOLOCK)
			WHERE NormalizedEmail = @Email 
			AND PasswordHash = @PasswordHash
		)
		BEGIN
			   -- Login successful
			SELECT 1 AS LoginResult;
		END
		ELSE
		BEGIN
			 -- Invalid username or password
			SELECT 0 AS LoginResult;

			-- Error message
			THROW 50001, 'Invalid username or password',1;

		END

	END TRY 
	BEGIN CATCH
		
		     -- Log the error
        INSERT INTO ErrorLog (ProcedureName, ErrorMessage, ErrorTime)
        VALUES ('User_EmailVerifyPassword ', ERROR_MESSAGE(), GETDATE());

        -- Re-throw the error to the calling application
        THROW;

	END CATCH 

	
END
GO
/****** Object:  StoredProcedure [dbo].[User_GetEmailPassword]    Script Date: 01-Apr-24 7:57:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PRATIK KHARAD 
-- Create date: 30-JANUARY-2024
-- Description:	User verification password and email address is valid or not 
-- =============================================

-- User_GetEmailPassword 'pratik@example.com'

CREATE PROCEDURE [dbo].[User_GetEmailPassword]
	@Email  NVARCHAR(100)
AS
BEGIN

	SET NOCOUNT ON;

	BEGIN TRY

		IF EXISTS(
			SELECT 1 FROM tblUser WITH(NOLOCK)
			WHERE NormalizedEmail = @Email 
		)
		BEGIN
			   -- User details find successful
			SELECT Email,PasswordHash FROM tblUser WITH(NOLOCK) 
			WHERE NormalizedEmail = @Email;
		END
		ELSE
		BEGIN
			 -- User not found
			SELECT 0 AS Result;

			-- Error message
			THROW 50001, 'User details not found',1;

		END

	END TRY 
	BEGIN CATCH
		
		     -- Log the error
        INSERT INTO ErrorLog (ProcedureName, ErrorMessage, ErrorTime)
        VALUES ('User_GetEmailPassword ', ERROR_MESSAGE(), GETDATE());

        -- Re-throw the error to the calling application
        THROW;

	END CATCH 

	
END
GO
/****** Object:  StoredProcedure [dbo].[User_GetPageNumberAndSize]    Script Date: 01-Apr-24 7:57:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[User_GetPageNumberAndSize]
    @PageNumber INT,
    @PageSize INT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;
    
	

    SELECT *
    FROM (
        SELECT *,
               ROW_NUMBER() OVER (ORDER BY Id) AS RowNum
        FROM tblUser
    ) AS PagedUsers
    WHERE RowNum > @Offset
    AND RowNum <= @Offset + @PageSize;
END;
GO
/****** Object:  StoredProcedure [dbo].[User_GetPersonByUserName]    Script Date: 01-Apr-24 7:57:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		PRATIK KHARAD 
-- Create date: 30-JANUARY-2024
-- Description:	User verification password and email address is valid or not 
-- =============================================

-- User_GetEmailPassword 'pratik@example.com'

-- User_GetPersonByUserName 'pratik@example.com'

CREATE PROCEDURE [dbo].[User_GetPersonByUserName]
@Email nvarchar(200) 	
AS
BEGIN

	SET NOCOUNT ON;

	BEGIN TRY

		
			SELECT TOP 1 * FROM tblUser WITH(NOLOCK)
			WHERE NormalizedEmail = @Email
		
			   -- User details find successful
			
		

	END TRY 
	BEGIN CATCH
		
		     -- Log the error
        INSERT INTO ErrorLog (ProcedureName, ErrorMessage, ErrorTime)
        VALUES ('User_GetPersonByUserName', ERROR_MESSAGE(), GETDATE());

        -- Re-throw the error to the calling application
        THROW;

	END CATCH 

	
END
GO
/****** Object:  StoredProcedure [dbo].[User_GetSortedUsers]    Script Date: 01-Apr-24 7:57:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_GetSortedUsers]
    @SortBy NVARCHAR(50),
    @Descending BIT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @SortOrder NVARCHAR(4) = CASE WHEN @Descending = 1 THEN 'DESC' ELSE 'ASC' END;
    
    DECLARE @Sql NVARCHAR(MAX) = '
        SELECT *
        FROM tblUser
        ORDER BY ' + QUOTENAME(@SortBy) + ' ' + @SortOrder + ';';
    
    EXEC sp_executesql @Sql;
END;
GO
/****** Object:  StoredProcedure [dbo].[User_GetTotalUserCount]    Script Date: 01-Apr-24 7:57:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		PRATIK KHARAD 
-- Create date: 30-JANUARY-2024
-- Description:	User verification password and email address is valid or not 
-- =============================================

-- User_GetEmailPassword 'pratik@example.com'

-- User_GetUserList 0
CREATE PROCEDURE [dbo].[User_GetTotalUserCount]
	
AS
BEGIN

	SET NOCOUNT ON;

	BEGIN TRY

		
			SELECT COUNT(*) FROM tblUser WITH(NOLOCK)
		
			   -- User details find successful
			
		

	END TRY 
	BEGIN CATCH
		
		     -- Log the error
        INSERT INTO ErrorLog (ProcedureName, ErrorMessage, ErrorTime)
        VALUES ('User_GetTotalUserCount', ERROR_MESSAGE(), GETDATE());

        -- Re-throw the error to the calling application
        THROW;

	END CATCH 

	
END
GO
/****** Object:  StoredProcedure [dbo].[User_GetUserList]    Script Date: 01-Apr-24 7:57:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		PRATIK KHARAD 
-- Create date: 30-JANUARY-2024
-- Description:	User verification password and email address is valid or not 
-- =============================================

-- User_GetEmailPassword 'pratik@example.com'

-- User_GetUserList 0
CREATE PROCEDURE [dbo].[User_GetUserList]
	
AS
BEGIN

	SET NOCOUNT ON;

	BEGIN TRY

		
			SELECT * FROM tblUser WITH(NOLOCK)
		
			   -- User details find successful
			
		

	END TRY 
	BEGIN CATCH
		
		     -- Log the error
        INSERT INTO ErrorLog (ProcedureName, ErrorMessage, ErrorTime)
        VALUES ('User_GetEmailPassword ', ERROR_MESSAGE(), GETDATE());

        -- Re-throw the error to the calling application
        THROW;

	END CATCH 

	
END
GO
/****** Object:  StoredProcedure [dbo].[User_Register]    Script Date: 01-Apr-24 7:57:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		 PRATIK KHARAD
-- Create date:  28 January 2024
-- Description:	 User is register then use this store procedure.
-- =============================================
CREATE PROCEDURE  [dbo].[User_Register] 
	
	
	@ID			  int = null OUTPUT,
	@UserGuid	  NVARCHAR(36),
	@FirstName	  NVARCHAR(50),
	@LastName	  NVARCHAR(50),
	@DateOfBirth  DATETIME,
	@Email		  NVARCHAR(100),
	@PhoneNumber  NVARCHAR(15),
	@PasswordHash NVARCHAR(MAX)
	
AS
BEGIN

	SET NOCOUNT ON;

	BEGIN TRY  
		
		-- FirstName 
		DECLARE @NormalizedFirstNameUppercaseValue NVARCHAR(50);
		SET @NormalizedFirstNameUppercaseValue = UPPER(@FirstName);

		-- LastName
		DECLARE @NormalizedLastNameUppercaseValue NVARCHAR(50);
		SET @NormalizedLastNameUppercaseValue = UPPER(@LastName);

		-- Email 
		DECLARE @NormalizedEmailUppercaseValue NVARCHAR(100);
		SET @NormalizedEmailUppercaseValue = UPPER(@Email);
		
		

		INSERT INTO tblUser
		(
			UserGuid,
			FirstName,
			NormalizedFirstName,
			LastName,
			NormalizedLastName,
			DateOfBirth,
			Email,
			NormalizedEmail,
			PhoneNumber,
			PasswordHash
		)
		VALUES
		(
			@UserGuid,
			@FirstName,
			@NormalizedFirstNameUppercaseValue,
			@LastName,
			@NormalizedLastNameUppercaseValue,
			@DateOfBirth,
			@Email,
			@NormalizedEmailUppercaseValue,
			@PhoneNumber,
			@PasswordHash

		)

		-- Return the identity value
		SET @ID = SCOPE_IDENTITY();

		IF @ID IS NULL 
		BEGIN
			THROW 50001,'User data is not inserted',1;
		END

	END TRY
    BEGIN CATCH
	        -- Log the error
        INSERT INTO ErrorLog (ProcedureName, ErrorMessage, ErrorTime)
        VALUES ('User_Register ', ERROR_MESSAGE(), GETDATE());

        -- Re-throw the error to the calling application
        THROW;

    END CATCH

END
GO
USE [master]
GO
ALTER DATABASE [Shop] SET  READ_WRITE 
GO
