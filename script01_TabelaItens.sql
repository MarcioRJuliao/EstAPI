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

CREATE TABLE [TB_ITENS] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Qtd] int NOT NULL,
    [Categoria] int NOT NULL,
    CONSTRAINT [PK_TB_ITENS] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Categoria', N'Nome', N'Qtd') AND [object_id] = OBJECT_ID(N'[TB_ITENS]'))
    SET IDENTITY_INSERT [TB_ITENS] ON;
INSERT INTO [TB_ITENS] ([Id], [Categoria], [Nome], [Qtd])
VALUES (1, 2, N'Lapis', 5),
(2, 3, N'Sabao', 4),
(3, 1, N'Carne', 7),
(4, 2, N'Caneta', 15),
(5, 3, N'Agua Sanitaria', 2),
(6, 1, N'Saco de Arroz', 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Categoria', N'Nome', N'Qtd') AND [object_id] = OBJECT_ID(N'[TB_ITENS]'))
    SET IDENTITY_INSERT [TB_ITENS] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231128200029_InitialCreate', N'7.0.14');
GO

COMMIT;
GO

