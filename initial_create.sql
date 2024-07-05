﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
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

BEGIN TRANSACTION;
GO

CREATE TABLE [TB_Classificacao] (
    [idClassficacao] int NOT NULL IDENTITY,
    [PosicaoTime] int NOT NULL,
    [NomeTime] varChar(200) NOT NULL,
    [numJogos] int NOT NULL,
    [numVitorias] int NOT NULL,
    [numEmpates] int NOT NULL,
    [numDerrotas] int NOT NULL,
    [GolsFeitos] int NOT NULL,
    [GolsSofridos] int NOT NULL,
    [Pontos] int NOT NULL,
    [ultiomojogos1] varChar(200) NOT NULL,
    [ultiomojogos2] varChar(200) NOT NULL,
    [ultiomojogos3] varChar(200) NOT NULL,
    [ultiomojogos4] varChar(200) NOT NULL,
    [ultiomojogos5] varChar(200) NOT NULL,
    CONSTRAINT [PK_TB_Classificacao] PRIMARY KEY ([idClassficacao])
);
GO

CREATE TABLE [Tb_EstatisticaFora] (
    [IdEstatisticaFora] int NOT NULL IDENTITY,
    [NomeTimeFora] varChar(200) NOT NULL,
    [GolsFora] int NOT NULL,
    [TentativasGolsFora] int NOT NULL,
    [chutesnoGolsFora] int NOT NULL,
    [chutespraforaFora] int NOT NULL,
    [escanteiosFora] int NOT NULL,
    [InpedimentosFora] int NOT NULL,
    [DefesaGoleiroFora] int NOT NULL,
    [FaltasForas] int NOT NULL,
    [CartoesVermelhosFora] int NOT NULL,
    [CartoesAmareloFora] int NOT NULL,
    [PassesTotaisFora] int NOT NULL,
    [PassesCompletosFora] int NOT NULL,
    [AtaquesperigososFora] int NOT NULL,
    CONSTRAINT [PK_Tb_EstatisticaFora] PRIMARY KEY ([IdEstatisticaFora])
);
GO

CREATE TABLE [TB_TBCampeonato] (
    [idCampeonato] int NOT NULL IDENTITY,
    [NomeCampeonato] varChar(200) NOT NULL,
    [data] datetime2 NOT NULL,
    [ClassificacaoIds] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TB_TBCampeonato] PRIMARY KEY ([idCampeonato])
);
GO

CREATE TABLE [TB_Partidas] (
    [idPartida] int NOT NULL IDENTITY,
    [NomeTimeCasa] varChar(200) NOT NULL,
    [NomeTimeFora] varChar(200) NOT NULL,
    [data] datetime2 NOT NULL,
    [Campeonato] varChar(200) NOT NULL,
    [IdEstatisticaCasa] int NOT NULL,
    [IdEstatisticaFora] int NOT NULL,
    CONSTRAINT [PK_TB_Partidas] PRIMARY KEY ([idPartida]),
    CONSTRAINT [FK_TB_Partidas_Tb_EstatisticaCasa_IdEstatisticaCasa] FOREIGN KEY ([IdEstatisticaCasa]) REFERENCES [Tb_EstatisticaCasa] ([IdEstatisticaCasa]) ON DELETE CASCADE,
    CONSTRAINT [FK_TB_Partidas_Tb_EstatisticaFora_IdEstatisticaFora] FOREIGN KEY ([IdEstatisticaFora]) REFERENCES [Tb_EstatisticaFora] ([IdEstatisticaFora]) ON DELETE CASCADE
);
GO

CREATE TABLE [TB_Palpites] (
    [idPalpites] int NOT NULL IDENTITY,
    [idPartida] int NOT NULL,
    [tipoAposta] int NOT NULL,
    [num] float NULL,
    [descricao] varChar(200) NOT NULL,
    CONSTRAINT [PK_TB_Palpites] PRIMARY KEY ([idPalpites]),
    CONSTRAINT [FK_TB_Palpites_TB_Partidas_idPartida] FOREIGN KEY ([idPartida]) REFERENCES [TB_Partidas] ([idPartida]) ON DELETE CASCADE
);
GO

UPDATE [Tb_EstatisticaCasa] SET [NomeTimeCasa] = 'Corinthians'
WHERE [IdEstatisticaCasa] = 2;
SELECT @@ROWCOUNT;

GO

CREATE INDEX [IX_TB_Palpites_idPartida] ON [TB_Palpites] ([idPartida]);
GO

CREATE INDEX [IX_TB_Partidas_IdEstatisticaCasa] ON [TB_Partidas] ([IdEstatisticaCasa]);
GO

CREATE INDEX [IX_TB_Partidas_IdEstatisticaFora] ON [TB_Partidas] ([IdEstatisticaFora]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240702214418_AddTabelaCampeonatoAndClassificacao', N'8.0.6');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [TB_Partidas] DROP CONSTRAINT [FK_TB_Partidas_Tb_EstatisticaCasa_IdEstatisticaCasa];
GO

ALTER TABLE [TB_Partidas] DROP CONSTRAINT [FK_TB_Partidas_Tb_EstatisticaFora_IdEstatisticaFora];
GO

DELETE FROM [Tb_EstatisticaCasa]
WHERE [IdEstatisticaCasa] = 1;
SELECT @@ROWCOUNT;

GO

DELETE FROM [Tb_EstatisticaCasa]
WHERE [IdEstatisticaCasa] = 2;
SELECT @@ROWCOUNT;

GO

DELETE FROM [Tb_EstatisticaCasa]
WHERE [IdEstatisticaCasa] = 3;
SELECT @@ROWCOUNT;

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_TBCampeonato]') AND [c].[name] = N'NomeCampeonato');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [TB_TBCampeonato] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [TB_TBCampeonato] ALTER COLUMN [NomeCampeonato] varChar(200) NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_TBCampeonato]') AND [c].[name] = N'ClassificacaoIds');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [TB_TBCampeonato] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [TB_TBCampeonato] ALTER COLUMN [ClassificacaoIds] nvarchar(max) NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_Partidas]') AND [c].[name] = N'NomeTimeFora');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [TB_Partidas] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [TB_Partidas] ALTER COLUMN [NomeTimeFora] varChar(200) NULL;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_Partidas]') AND [c].[name] = N'NomeTimeCasa');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [TB_Partidas] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [TB_Partidas] ALTER COLUMN [NomeTimeCasa] varChar(200) NULL;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_Partidas]') AND [c].[name] = N'IdEstatisticaFora');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [TB_Partidas] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [TB_Partidas] ALTER COLUMN [IdEstatisticaFora] int NULL;
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_Partidas]') AND [c].[name] = N'IdEstatisticaCasa');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [TB_Partidas] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [TB_Partidas] ALTER COLUMN [IdEstatisticaCasa] int NULL;
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_Partidas]') AND [c].[name] = N'Campeonato');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [TB_Partidas] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [TB_Partidas] ALTER COLUMN [Campeonato] varChar(200) NULL;
GO

ALTER TABLE [TB_Partidas] ADD [PartidaAnalise] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_Palpites]') AND [c].[name] = N'descricao');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [TB_Palpites] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [TB_Palpites] ALTER COLUMN [descricao] varChar(200) NULL;
GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tb_EstatisticaFora]') AND [c].[name] = N'escanteiosFora');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Tb_EstatisticaFora] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [Tb_EstatisticaFora] ALTER COLUMN [escanteiosFora] int NULL;
GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tb_EstatisticaFora]') AND [c].[name] = N'chutesnoGolsFora');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Tb_EstatisticaFora] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [Tb_EstatisticaFora] ALTER COLUMN [chutesnoGolsFora] int NULL;
GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tb_EstatisticaFora]') AND [c].[name] = N'NomeTimeFora');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Tb_EstatisticaFora] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [Tb_EstatisticaFora] ALTER COLUMN [NomeTimeFora] varChar(200) NULL;
GO

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tb_EstatisticaFora]') AND [c].[name] = N'InpedimentosFora');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Tb_EstatisticaFora] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [Tb_EstatisticaFora] ALTER COLUMN [InpedimentosFora] int NULL;
GO

DECLARE @var12 sysname;
SELECT @var12 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tb_EstatisticaFora]') AND [c].[name] = N'DefesaGoleiroFora');
IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Tb_EstatisticaFora] DROP CONSTRAINT [' + @var12 + '];');
ALTER TABLE [Tb_EstatisticaFora] ALTER COLUMN [DefesaGoleiroFora] int NULL;
GO

DECLARE @var13 sysname;
SELECT @var13 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tb_EstatisticaFora]') AND [c].[name] = N'CartoesVermelhosFora');
IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [Tb_EstatisticaFora] DROP CONSTRAINT [' + @var13 + '];');
ALTER TABLE [Tb_EstatisticaFora] ALTER COLUMN [CartoesVermelhosFora] int NULL;
GO

DECLARE @var14 sysname;
SELECT @var14 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tb_EstatisticaFora]') AND [c].[name] = N'CartoesAmareloFora');
IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [Tb_EstatisticaFora] DROP CONSTRAINT [' + @var14 + '];');
ALTER TABLE [Tb_EstatisticaFora] ALTER COLUMN [CartoesAmareloFora] int NULL;
GO

ALTER TABLE [Tb_EstatisticaFora] ADD [AdversarioCasa] varChar(200) NULL;
GO

ALTER TABLE [Tb_EstatisticaFora] ADD [GolsSofridosFora] int NOT NULL DEFAULT 0;
GO

DECLARE @var15 sysname;
SELECT @var15 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tb_EstatisticaCasa]') AND [c].[name] = N'escanteiosCasa');
IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [Tb_EstatisticaCasa] DROP CONSTRAINT [' + @var15 + '];');
ALTER TABLE [Tb_EstatisticaCasa] ALTER COLUMN [escanteiosCasa] int NULL;
GO

DECLARE @var16 sysname;
SELECT @var16 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tb_EstatisticaCasa]') AND [c].[name] = N'chutesnoGolsCasa');
IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [Tb_EstatisticaCasa] DROP CONSTRAINT [' + @var16 + '];');
ALTER TABLE [Tb_EstatisticaCasa] ALTER COLUMN [chutesnoGolsCasa] int NULL;
GO

DECLARE @var17 sysname;
SELECT @var17 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tb_EstatisticaCasa]') AND [c].[name] = N'NomeTimeCasa');
IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [Tb_EstatisticaCasa] DROP CONSTRAINT [' + @var17 + '];');
ALTER TABLE [Tb_EstatisticaCasa] ALTER COLUMN [NomeTimeCasa] varChar(200) NULL;
GO

DECLARE @var18 sysname;
SELECT @var18 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tb_EstatisticaCasa]') AND [c].[name] = N'InpedimentosCasa');
IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [Tb_EstatisticaCasa] DROP CONSTRAINT [' + @var18 + '];');
ALTER TABLE [Tb_EstatisticaCasa] ALTER COLUMN [InpedimentosCasa] int NULL;
GO

DECLARE @var19 sysname;
SELECT @var19 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tb_EstatisticaCasa]') AND [c].[name] = N'DefesaGoleiroCasa');
IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [Tb_EstatisticaCasa] DROP CONSTRAINT [' + @var19 + '];');
ALTER TABLE [Tb_EstatisticaCasa] ALTER COLUMN [DefesaGoleiroCasa] int NULL;
GO

DECLARE @var20 sysname;
SELECT @var20 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tb_EstatisticaCasa]') AND [c].[name] = N'CartoesVermelhosCasa');
IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [Tb_EstatisticaCasa] DROP CONSTRAINT [' + @var20 + '];');
ALTER TABLE [Tb_EstatisticaCasa] ALTER COLUMN [CartoesVermelhosCasa] int NULL;
GO

DECLARE @var21 sysname;
SELECT @var21 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tb_EstatisticaCasa]') AND [c].[name] = N'CartoesAmareloCasa');
IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [Tb_EstatisticaCasa] DROP CONSTRAINT [' + @var21 + '];');
ALTER TABLE [Tb_EstatisticaCasa] ALTER COLUMN [CartoesAmareloCasa] int NULL;
GO

ALTER TABLE [Tb_EstatisticaCasa] ADD [AdversarioFora] varChar(200) NULL;
GO

ALTER TABLE [Tb_EstatisticaCasa] ADD [GolsSofridosCasa] int NOT NULL DEFAULT 0;
GO

DECLARE @var22 sysname;
SELECT @var22 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_Classificacao]') AND [c].[name] = N'ultiomojogos5');
IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [TB_Classificacao] DROP CONSTRAINT [' + @var22 + '];');
ALTER TABLE [TB_Classificacao] ALTER COLUMN [ultiomojogos5] varChar(200) NULL;
GO

DECLARE @var23 sysname;
SELECT @var23 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_Classificacao]') AND [c].[name] = N'ultiomojogos4');
IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [TB_Classificacao] DROP CONSTRAINT [' + @var23 + '];');
ALTER TABLE [TB_Classificacao] ALTER COLUMN [ultiomojogos4] varChar(200) NULL;
GO

DECLARE @var24 sysname;
SELECT @var24 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_Classificacao]') AND [c].[name] = N'ultiomojogos3');
IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [TB_Classificacao] DROP CONSTRAINT [' + @var24 + '];');
ALTER TABLE [TB_Classificacao] ALTER COLUMN [ultiomojogos3] varChar(200) NULL;
GO

DECLARE @var25 sysname;
SELECT @var25 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_Classificacao]') AND [c].[name] = N'ultiomojogos2');
IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [TB_Classificacao] DROP CONSTRAINT [' + @var25 + '];');
ALTER TABLE [TB_Classificacao] ALTER COLUMN [ultiomojogos2] varChar(200) NULL;
GO

DECLARE @var26 sysname;
SELECT @var26 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_Classificacao]') AND [c].[name] = N'ultiomojogos1');
IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [TB_Classificacao] DROP CONSTRAINT [' + @var26 + '];');
ALTER TABLE [TB_Classificacao] ALTER COLUMN [ultiomojogos1] varChar(200) NULL;
GO

DECLARE @var27 sysname;
SELECT @var27 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_Classificacao]') AND [c].[name] = N'NomeTime');
IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [TB_Classificacao] DROP CONSTRAINT [' + @var27 + '];');
ALTER TABLE [TB_Classificacao] ALTER COLUMN [NomeTime] varChar(200) NULL;
GO

CREATE TABLE [Tb_EstatisticaTimes] (
    [IdTime] int NOT NULL IDENTITY,
    [NomeTime] varChar(200) NULL,
    [GolMedias] int NOT NULL,
    [GolMaior] int NOT NULL,
    [GolMenor] int NOT NULL,
    [GolMediasCF] int NOT NULL,
    [TentativasGolsMedias] int NOT NULL,
    [TentativasGolsMenor] int NOT NULL,
    [TentativasGolsMaior] int NOT NULL,
    [TentativasGolsMediasCF] int NOT NULL,
    [chutesnoGolsMedia] int NOT NULL,
    [chutesnoGolsMenor] int NOT NULL,
    [chutesnoGolsMaior] int NOT NULL,
    [chutesnoGolsMediaCF] int NOT NULL,
    [chutespraforaMedia] int NOT NULL,
    [chutespraforaMenor] int NOT NULL,
    [chutespraforaMaior] int NOT NULL,
    [chutespraforaMediaCF] int NOT NULL,
    [escanteiosMedia] int NOT NULL,
    [escanteiosMenor] int NOT NULL,
    [escanteiosMaior] int NOT NULL,
    [escanteiosMediaCF] int NOT NULL,
    [InpedimentosMedia] int NOT NULL,
    [InpedimentosMenor] int NOT NULL,
    [InpedimentosMaior] int NOT NULL,
    [InpedimentosMediaCF] int NOT NULL,
    [DefesaGoleiroMedia] int NOT NULL,
    [DefesaGoleiroMenor] int NOT NULL,
    [DefesaGoleiroMaior] int NOT NULL,
    [DefesaGoleiroMediaCF] int NOT NULL,
    [FaltasMedia] int NOT NULL,
    [FaltasMenor] int NOT NULL,
    [FaltasMaior] int NOT NULL,
    [FaltasMediaCF] int NOT NULL,
    [CartoesVermelhosMedia] int NOT NULL,
    [CartoesAmareloMedia] int NOT NULL,
    [CartoesAmareloMenor] int NOT NULL,
    [CartoesAmareloMaior] int NOT NULL,
    [CartoesAmareloMediaCF] int NOT NULL,
    [PassesTotaisMedia] int NOT NULL,
    [PassesTotaisMenor] int NOT NULL,
    [PassesTotaisMaior] int NOT NULL,
    [PassesTotaisMediaCF] int NOT NULL,
    [PassesCompletosMedia] int NOT NULL,
    [PassesCompletosMediaCF] int NOT NULL,
    [PassesCompletosMaior] int NOT NULL,
    [PassesCompletosMenor] int NOT NULL,
    [AtaquesperigososMedia] int NOT NULL,
    [AtaquesperigososMediaCF] int NOT NULL,
    CONSTRAINT [PK_Tb_EstatisticaTimes] PRIMARY KEY ([IdTime])
);
GO

ALTER TABLE [TB_Partidas] ADD CONSTRAINT [FK_TB_Partidas_Tb_EstatisticaCasa_IdEstatisticaCasa] FOREIGN KEY ([IdEstatisticaCasa]) REFERENCES [Tb_EstatisticaCasa] ([IdEstatisticaCasa]);
GO

ALTER TABLE [TB_Partidas] ADD CONSTRAINT [FK_TB_Partidas_Tb_EstatisticaFora_IdEstatisticaFora] FOREIGN KEY ([IdEstatisticaFora]) REFERENCES [Tb_EstatisticaFora] ([IdEstatisticaFora]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240704181835_AddPEstatisticaTimes', N'8.0.6');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Tb_EstatisticaTimes] ADD [GolsSofridosMaior] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Tb_EstatisticaTimes] ADD [GolsSofridosMedias] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Tb_EstatisticaTimes] ADD [GolsSofridosMediasCF] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Tb_EstatisticaTimes] ADD [GolsSofridosMenor] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240704182308_AddEstatisticaTimes', N'8.0.6');
GO

COMMIT;
GO

