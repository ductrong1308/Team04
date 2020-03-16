CREATE TABLE [dbo].[Settings] (
    [Id]     INT           IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (30) NULL,
    [Value]  NVARCHAR (30) NULL,
    [UserID] INT           NOT NULL,
    CONSTRAINT [PK_dbo.Settings] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Settings_dbo.Users_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserID]
    ON [dbo].[Settings]([UserID] ASC);

