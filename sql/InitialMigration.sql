IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Authors] (
    [Id] uniqueidentifier NOT NULL,
    [Cpf] varchar(11) NOT NULL,
    [Name] varchar(200) NOT NULL,
    [Birthdate] datetime2 NOT NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Categories] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(50) NOT NULL,
    [Code] int NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Books] (
    [Id] uniqueidentifier NOT NULL,
    [CategoryId] uniqueidentifier NOT NULL,
    [AuthorId] uniqueidentifier NOT NULL,
    [Title] varchar(100) NOT NULL,
    [StockQuantity] int NOT NULL,
    [ReleaseDate] datetime2 NOT NULL,
    [Isbn] varchar(13) NOT NULL,
    [RegisterDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Books_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Books_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Books_AuthorId] ON [Books] ([AuthorId]);

GO

CREATE INDEX [IX_Books_CategoryId] ON [Books] ([CategoryId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191227052154_Initial', N'3.1.0');

GO

