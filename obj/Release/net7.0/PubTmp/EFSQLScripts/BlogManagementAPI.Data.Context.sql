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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230517142409_first mig')
BEGIN
    CREATE TABLE [Categorys] (
        [CategoryID] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NOT NULL,
        [Description] nvarchar(200) NOT NULL,
        CONSTRAINT [PK_Categorys] PRIMARY KEY ([CategoryID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230517142409_first mig')
BEGIN
    CREATE TABLE [Roles] (
        [RoleID] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Roles] PRIMARY KEY ([RoleID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230517142409_first mig')
BEGIN
    CREATE TABLE [Users] (
        [UserID] int NOT NULL IDENTITY,
        [UserName] nvarchar(50) NOT NULL,
        [Password] nvarchar(100) NOT NULL,
        [RoleID] int NOT NULL,
        [Email] nvarchar(100) NOT NULL,
        [DateRegistered] datetime2 NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([UserID]),
        CONSTRAINT [FK_Users_Roles_RoleID] FOREIGN KEY ([RoleID]) REFERENCES [Roles] ([RoleID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230517142409_first mig')
BEGIN
    CREATE TABLE [Comments] (
        [CommentID] int NOT NULL IDENTITY,
        [UserComment] nvarchar(500) NOT NULL,
        [UserID] int NOT NULL,
        [DateCommented] datetime2 NOT NULL,
        CONSTRAINT [PK_Comments] PRIMARY KEY ([CommentID]),
        CONSTRAINT [FK_Comments_Users_UserID] FOREIGN KEY ([UserID]) REFERENCES [Users] ([UserID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230517142409_first mig')
BEGIN
    CREATE TABLE [Posts] (
        [PostID] int NOT NULL IDENTITY,
        [Title] nvarchar(50) NOT NULL,
        [Content] nvarchar(max) NOT NULL,
        [UserID] int NOT NULL,
        [DatePosted] datetime2 NOT NULL,
        [CategoryID] int NOT NULL,
        CONSTRAINT [PK_Posts] PRIMARY KEY ([PostID]),
        CONSTRAINT [FK_Posts_Categorys_CategoryID] FOREIGN KEY ([CategoryID]) REFERENCES [Categorys] ([CategoryID]) ON DELETE CASCADE,
        CONSTRAINT [FK_Posts_Users_UserID] FOREIGN KEY ([UserID]) REFERENCES [Users] ([UserID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230517142409_first mig')
BEGIN
    CREATE TABLE [ImageUrl] (
        [ImageUrlID] int NOT NULL IDENTITY,
        [Url] nvarchar(200) NOT NULL,
        [PostID] int NOT NULL,
        CONSTRAINT [PK_ImageUrl] PRIMARY KEY ([ImageUrlID]),
        CONSTRAINT [FK_ImageUrl_Posts_PostID] FOREIGN KEY ([PostID]) REFERENCES [Posts] ([PostID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230517142409_first mig')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CategoryID', N'Description', N'Name') AND [object_id] = OBJECT_ID(N'[Categorys]'))
        SET IDENTITY_INSERT [Categorys] ON;
    EXEC(N'INSERT INTO [Categorys] ([CategoryID], [Description], [Name])
    VALUES (1, N''Everything about regarding programming and technology.'', N''Programming''),
    (2, N''Non-programming stuff, activites'', N''Hobby''),
    (3, N''General news regarding the blog, website and programming.'', N''News'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CategoryID', N'Description', N'Name') AND [object_id] = OBJECT_ID(N'[Categorys]'))
        SET IDENTITY_INSERT [Categorys] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230517142409_first mig')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleID', N'Name') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] ON;
    EXEC(N'INSERT INTO [Roles] ([RoleID], [Name])
    VALUES (1, N''User''),
    (2, N''Moderator''),
    (3, N''Admin'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleID', N'Name') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230517142409_first mig')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserID', N'DateRegistered', N'Email', N'Password', N'RoleID', N'UserName') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] ON;
    EXEC(N'INSERT INTO [Users] ([UserID], [DateRegistered], [Email], [Password], [RoleID], [UserName])
    VALUES (1, ''2023-05-17T16:24:09.0115408+02:00'', N''alvin.strandberg@proton.me'', N''Billyidol96'', 3, N''Alvin''),
    (2, ''2023-05-17T16:24:09.0115455+02:00'', N''majanilsson8131@gmail.se'', N''TrollHealer96'', 2, N''Maja'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserID', N'DateRegistered', N'Email', N'Password', N'RoleID', N'UserName') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230517142409_first mig')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PostID', N'CategoryID', N'Content', N'DatePosted', N'Title', N'UserID') AND [object_id] = OBJECT_ID(N'[Posts]'))
        SET IDENTITY_INSERT [Posts] ON;
    EXEC(N'INSERT INTO [Posts] ([PostID], [CategoryID], [Content], [DatePosted], [Title], [UserID])
    VALUES (1, 1, N''Splitting some wood.'', ''2023-05-17T16:24:09.0115494+02:00'', N''Wood splitting'', 1)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PostID', N'CategoryID', N'Content', N'DatePosted', N'Title', N'UserID') AND [object_id] = OBJECT_ID(N'[Posts]'))
        SET IDENTITY_INSERT [Posts] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230517142409_first mig')
BEGIN
    CREATE INDEX [IX_Comments_UserID] ON [Comments] ([UserID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230517142409_first mig')
BEGIN
    CREATE INDEX [IX_ImageUrl_PostID] ON [ImageUrl] ([PostID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230517142409_first mig')
BEGIN
    CREATE INDEX [IX_Posts_CategoryID] ON [Posts] ([CategoryID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230517142409_first mig')
BEGIN
    CREATE INDEX [IX_Posts_UserID] ON [Posts] ([UserID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230517142409_first mig')
BEGIN
    CREATE INDEX [IX_Users_RoleID] ON [Users] ([RoleID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230517142409_first mig')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230517142409_first mig', N'7.0.5');
END;
GO

COMMIT;
GO

