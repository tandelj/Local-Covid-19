IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Cities] (
    [Id] int NOT NULL IDENTITY,
    [CityName] nvarchar(max) NULL,
    [Population] int NOT NULL,
    CONSTRAINT [PK_Cities] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Datas] (
    [Id] int NOT NULL IDENTITY,
    [Date] datetime2 NOT NULL,
    [Cases] int NOT NULL,
    [Deaths] int NOT NULL,
    [Tested] int NOT NULL,
    [Population] int NOT NULL,
    [CityId2] int NOT NULL,
    CONSTRAINT [PK_Datas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Datas_Cities_CityId2] FOREIGN KEY ([CityId2]) REFERENCES [Cities] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Datas_CityId2] ON [Datas] ([CityId2]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200713212332_initalschema', N'3.1.5');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200713213042_new', N'3.1.5');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Cities]') AND [c].[name] = N'Population');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Cities] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Cities] DROP COLUMN [Population];

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200713235645_ChangedSchem', N'3.1.5');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200714000150_updateschema', N'3.1.5');

GO

