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

