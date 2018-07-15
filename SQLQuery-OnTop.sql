USE [BancoOnTop]
GO

/****** Object:  Database [BancoOnTop]    Script Date: 03/07/2018 15:09:55 ******/
CREATE DATABASE [BancoOnTop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BancoOnTop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\BancoOnTop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BancoOnTop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\BancoOnTop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [BancoOnTop] SET COMPATIBILITY_LEVEL = 130
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BancoOnTop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [BancoOnTop] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [BancoOnTop] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [BancoOnTop] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [BancoOnTop] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [BancoOnTop] SET ARITHABORT OFF 
GO

ALTER DATABASE [BancoOnTop] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [BancoOnTop] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [BancoOnTop] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [BancoOnTop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [BancoOnTop] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [BancoOnTop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [BancoOnTop] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [BancoOnTop] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [BancoOnTop] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [BancoOnTop] SET  ENABLE_BROKER 
GO

ALTER DATABASE [BancoOnTop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [BancoOnTop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [BancoOnTop] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [BancoOnTop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [BancoOnTop] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [BancoOnTop] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [BancoOnTop] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [BancoOnTop] SET RECOVERY FULL 
GO

ALTER DATABASE [BancoOnTop] SET  MULTI_USER 
GO

ALTER DATABASE [BancoOnTop] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [BancoOnTop] SET DB_CHAINING OFF 
GO

ALTER DATABASE [BancoOnTop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [BancoOnTop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [BancoOnTop] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [BancoOnTop] SET QUERY_STORE = OFF
GO

USE [BancoOnTop]
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO

ALTER DATABASE [BancoOnTop] SET  READ_WRITE 
GO


/****** Object:  Table [dbo].[TbCargo]    Script Date: 04/07/2018 22:26:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TbCargo](
	[IdCargo] [int] IDENTITY(1,1) NOT NULL,
	[DescricaoCargo] [varchar](50) NOT NULL,
	[DataCadastro] [datetime] NULL,
 CONSTRAINT [PK_IdCargo] PRIMARY KEY CLUSTERED 
(
	[IdCargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[TbDepartamento]    Script Date: 04/07/2018 22:26:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TbDepartamento](
	[IdDepartamento] [int] IDENTITY(1,1) NOT NULL,
	[NomeDepartamento] [varchar](50) NOT NULL,
	[DataCadastro] [datetime] NULL,
 CONSTRAINT [PK_IdDepartamento] PRIMARY KEY CLUSTERED 
(
	[IdDepartamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[TbFuncionario]    Script Date: 04/07/2018 22:27:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TbFuncionario](
	[IdFuncionario] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](60) NULL,
	[Cpf] [varchar](20) NULL,
	[Rg] [varchar](15) NULL,
	[Endereco] [varchar](50) NULL,
	[Cep] [varchar](8) NULL,
	[Cidade] [varchar](40) NULL,
	[Estado] [varchar](2) NULL,
	[Pais] [varchar](30) NULL,
	[IdSupervisor] [int] NOT NULL,
	[IdDepartamento] [int] NOT NULL,
	[IdCargo] [int] NOT NULL,
 CONSTRAINT [PK_IdUsuario] PRIMARY KEY CLUSTERED 
(
	[IdFuncionario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TbFuncionario]  WITH CHECK ADD  CONSTRAINT [FK_TbFuncionario_TbCargo] FOREIGN KEY([IdCargo])
REFERENCES [dbo].[TbCargo] ([IdCargo])
GO

ALTER TABLE [dbo].[TbFuncionario] CHECK CONSTRAINT [FK_TbFuncionario_TbCargo]
GO

ALTER TABLE [dbo].[TbFuncionario]  WITH CHECK ADD  CONSTRAINT [FK_TbFuncionario_TbDepartamento] FOREIGN KEY([IdDepartamento])
REFERENCES [dbo].[TbDepartamento] ([IdDepartamento])
GO

ALTER TABLE [dbo].[TbFuncionario] CHECK CONSTRAINT [FK_TbFuncionario_TbDepartamento]
GO


/****** Object:  Table [dbo].[TbLogin]    Script Date: 04/07/2018 22:27:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TbLogin](
	[IdLogin] [int] IDENTITY(1,1) NOT NULL,
	[IdFuncionario] [int] NOT NULL,
	[LoginFuncionario] [varchar](50) NOT NULL,
	[SenhaFuncionario] [varchar](250) NOT NULL,
	[SenhaHash] [varchar](150) NULL,
 CONSTRAINT [PK_IdLogin] PRIMARY KEY CLUSTERED 
(
	[IdLogin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TbLogin]  WITH CHECK ADD  CONSTRAINT [FK_TbLogin_TbFuncionario] FOREIGN KEY([IdFuncionario])
REFERENCES [dbo].[TbFuncionario] ([IdFuncionario])
GO

ALTER TABLE [dbo].[TbLogin] CHECK CONSTRAINT [FK_TbLogin_TbFuncionario]
GO

-----------------------------------------------------------------------------------------------------------------
INSERT INTO dbo.TbCargo (DescricaoCargo,DataCadastro) VALUES('Analista Desenvelvedor', '2018-07-03 00:00:00.000')
INSERT INTO dbo.TbCargo (DescricaoCargo,DataCadastro) VALUES('Analista de Requisitos', '2018-07-03 00:00:00.000')
INSERT INTO dbo.TbCargo (DescricaoCargo,DataCadastro) VALUES('Gerente de Projeto', '2018-07-03 00:00:00.000')
INSERT INTO dbo.TbCargo (DescricaoCargo,DataCadastro) VALUES('Supervisor', '2018-07-03 00:00:00.000')
INSERT INTO dbo.TbCargo (DescricaoCargo,DataCadastro) VALUES('Analista RH', '2018-07-03 00:00:00.000')
GO

INSERT INTO dbo.TbDepartamento (NomeDepartamento,DataCadastro) VALUES('Desenvolvimento', '2018-07-03 00:00:00.000')
INSERT INTO dbo.TbDepartamento (NomeDepartamento,DataCadastro) VALUES('Projeto', '2018-07-03 00:00:00.000')
INSERT INTO dbo.TbDepartamento (NomeDepartamento,DataCadastro) VALUES('RH', '2018-07-03 00:00:00.000')
GO

INSERT INTO dbo.TbFuncionario (Nome,Cpf,Rg,Endereco,Cep,Cidade,Estado,Pais,IdSupervisor,IdDepartamento,IdCargo) VALUES('José Delfino','94769485310','270151698','Rua Teste, 10','01152000','São Paulo','SP','Brasil',0,1,4)
INSERT INTO dbo.TbFuncionario (Nome,Cpf,Rg,Endereco,Cep,Cidade,Estado,Pais,IdSupervisor,IdDepartamento,IdCargo) VALUES('José da Silva','94769485310','270151698','Rua Teste, 10','01152000','São Paulo','SP','Brasil',0,1,4)
INSERT INTO dbo.TbFuncionario (Nome,Cpf,Rg,Endereco,Cep,Cidade,Estado,Pais,IdSupervisor,IdDepartamento,IdCargo) VALUES('Pedro de Oliveira','94769485310','270151698','Rua Teste, 10','01152000','São Paulo','SP','Brasil',1,1,1)
INSERT INTO dbo.TbFuncionario (Nome,Cpf,Rg,Endereco,Cep,Cidade,Estado,Pais,IdSupervisor,IdDepartamento,IdCargo) VALUES('Marco de Brito','94769485310','270151698','Rua Teste, 10','01152000','São Paulo','SP','Brasil',1,1,1)
INSERT INTO dbo.TbFuncionario (Nome,Cpf,Rg,Endereco,Cep,Cidade,Estado,Pais,IdSupervisor,IdDepartamento,IdCargo) VALUES('Antonia Marcos','94769485310','270151698','Rua Teste, 10','01152000','São Paulo','SP','Brasil',1,1,1)
INSERT INTO dbo.TbFuncionario (Nome,Cpf,Rg,Endereco,Cep,Cidade,Estado,Pais,IdSupervisor,IdDepartamento,IdCargo) VALUES('Carla Pascal','94769485310','270151698','Rua Teste, 10','01152000','São Paulo','SP','Brasil',1,1,1)
GO

INSERT INTO [dbo].[TbLogin] (IdFuncionario,LoginFuncionario,SenhaFuncionario,SenhaHash) VALUES(11,'jdelfino','teste@123','7f4ee8db597c3153b7963808858e310b49fa5c1e1669f03c1097cedddcc76002')
GO
-----------------------------------------------------------------------------------------------------------------

