IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Team]') AND type in (N'U'))
BEGIN
  CREATE TABLE [dbo].[Team]
  (
    [Id] INT NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    [UserAId] INT NOT NULL,
    [UserBId] INT NOT NULL,
    CONSTRAINT [FK_Team_UserA] FOREIGN KEY (UserAId) REFERENCES [User](Id),
    CONSTRAINT [FK_Team_UserB] FOREIGN KEY (UserBId) REFERENCES [User](Id)
  )
END