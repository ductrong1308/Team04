CREATE TABLE [dbo].[Expenses] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [CreatedDate]  DATETIME        NOT NULL,
    [CategoryName] NVARCHAR (MAX)  NULL,
    [Amount]       DECIMAL (18, 2) NOT NULL,
    [UserID]       INT             NOT NULL,
    CONSTRAINT [PK_dbo.Expenses] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Expenses_dbo.Users_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_UserID]
    ON [dbo].[Expenses]([UserID] ASC);

