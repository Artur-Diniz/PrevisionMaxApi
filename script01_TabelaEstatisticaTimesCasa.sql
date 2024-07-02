IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Tb_EstatisticaCasa] (
    [IdEstatisticaCasa] int NOT NULL IDENTITY,
    [NomeTimeCasa] varChar(200) NOT NULL,
    [GolsCasa] int NOT NULL,
    [TentativasGolsCasa] int NOT NULL,
    [chutesnoGolsCasa] int NOT NULL,
    [chutespraforaCasa] int NOT NULL,
    [escanteiosCasa] int NOT NULL,
    [InpedimentosCasa] int NOT NULL,
    [DefesaGoleiroCasa] int NOT NULL,
    [FaltasCasas] int NOT NULL,
    [CartoesVermelhosCasa] int NOT NULL,
    [CartoesAmareloCasa] int NOT NULL,
    [PassesTotaisCasa] int NOT NULL,
    [PassesCompletosCasa] int NOT NULL,
    [AtaquesperigososCasa] int NOT NULL,
    CONSTRAINT [PK_Tb_EstatisticaCasa] PRIMARY KEY ([IdEstatisticaCasa])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdEstatisticaCasa', N'AtaquesperigososCasa', N'CartoesAmareloCasa', N'CartoesVermelhosCasa', N'DefesaGoleiroCasa', N'FaltasCasas', N'GolsCasa', N'InpedimentosCasa', N'NomeTimeCasa', N'PassesCompletosCasa', N'PassesTotaisCasa', N'TentativasGolsCasa', N'chutesnoGolsCasa', N'chutespraforaCasa', N'escanteiosCasa') AND [object_id] = OBJECT_ID(N'[Tb_EstatisticaCasa]'))
    SET IDENTITY_INSERT [Tb_EstatisticaCasa] ON;
INSERT INTO [Tb_EstatisticaCasa] ([IdEstatisticaCasa], [AtaquesperigososCasa], [CartoesAmareloCasa], [CartoesVermelhosCasa], [DefesaGoleiroCasa], [FaltasCasas], [GolsCasa], [InpedimentosCasa], [NomeTimeCasa], [PassesCompletosCasa], [PassesTotaisCasa], [TentativasGolsCasa], [chutesnoGolsCasa], [chutespraforaCasa], [escanteiosCasa])
VALUES (1, 0, 0, 0, 0, 0, 99, 0, 'Palmeiras', 0, 0, 0, 0, 0, 0),
(2, 0, 0, 0, 0, 0, -31, 0, 'Cortinas', 0, 0, 0, 0, 0, 0),
(3, 0, 0, 0, 0, 0, 2, 0, 'Flamengo', 0, 0, 0, 0, 0, 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdEstatisticaCasa', N'AtaquesperigososCasa', N'CartoesAmareloCasa', N'CartoesVermelhosCasa', N'DefesaGoleiroCasa', N'FaltasCasas', N'GolsCasa', N'InpedimentosCasa', N'NomeTimeCasa', N'PassesCompletosCasa', N'PassesTotaisCasa', N'TentativasGolsCasa', N'chutesnoGolsCasa', N'chutespraforaCasa', N'escanteiosCasa') AND [object_id] = OBJECT_ID(N'[Tb_EstatisticaCasa]'))
    SET IDENTITY_INSERT [Tb_EstatisticaCasa] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240702121423_InitialCreate', N'8.0.6');
GO

COMMIT;
GO

